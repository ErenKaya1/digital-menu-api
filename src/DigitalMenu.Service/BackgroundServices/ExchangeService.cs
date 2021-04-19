using System;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using DigitalMenu.Core.Cache;
using DigitalMenu.Core.Constants;
using DigitalMenu.Data.Context;
using DigitalMenu.Entity.Entities;
using HtmlAgilityPack;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DigitalMenu.Service.BackgroundServices
{
    public class ExchangeService : IHostedService, IDisposable
    {
        private bool disposedValue;
        private CancellationToken _cancellationToken;
        private readonly IServiceProvider _services;
        private readonly ILogger<ExchangeService> _logger;
        private readonly IHttpClientFactory _httpClientFactory;
        private DMContext _dbContext;
        private IRedisCacheService _redisCacheService;

        public ExchangeService(IServiceProvider services, ILogger<ExchangeService> logger, IHttpClientFactory httpClientFactory)
        {
            _services = services;
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }

        Task IHostedService.StartAsync(CancellationToken cancellationToken)
        {
            _cancellationToken = cancellationToken;
            _logger.LogInformation("exchange background service was started.");
            DoWork();
            return Task.CompletedTask;
        }

        public async void DoWork()
        {
            while (true)
            {
                using (var scope = _services.CreateScope())
                {
                    _dbContext = scope.ServiceProvider.GetRequiredService<DMContext>();
                    _redisCacheService = scope.ServiceProvider.GetRequiredService<IRedisCacheService>();

                    using (var client = _httpClientFactory.CreateClient("exchange"))
                    {
                        var request = new HttpRequestMessage(HttpMethod.Get, "");
                        var response = await client.SendAsync(request);

                        if (response.IsSuccessStatusCode)
                        {
                            HtmlDocument document = new HtmlDocument();
                            var html = await response.Content.ReadAsStringAsync();
                            document.LoadHtml(html);

                            var exchangeContainer = document.DocumentNode.Descendants("div").First(x => x.HasClass("market-data"));
                            var dolarTag = exchangeContainer.Descendants("div").Where(x => x.HasClass("item")).ToList()[1];
                            var euroTag = exchangeContainer.Descendants("div").Where(x => x.HasClass("item")).ToList()[2];
                            var USDtoTRY = dolarTag.Descendants("span").First(x => x.HasClass("value")).InnerText;
                            var EURtoTRY = euroTag.Descendants("span").First(x => x.HasClass("value")).InnerText;

                            var entity = _dbContext.ExchangeType.FirstOrDefault();
                            if (entity != null)
                            {
                                entity.USDtoTRY = double.Parse(USDtoTRY);
                                entity.EURtoTRY = double.Parse(EURtoTRY);

                                _dbContext.ExchangeType.Update(entity);
                            }
                            else
                            {
                                entity = new ExchangeType
                                {
                                    Id = Guid.NewGuid(),
                                    USDtoTRY = double.Parse(USDtoTRY),
                                    EURtoTRY = double.Parse(EURtoTRY),
                                };

                                _dbContext.ExchangeType.Add(entity);
                            }

                            await _dbContext.SaveChangesAsync();

                            // set cache
                            _redisCacheService.Set(RedisKeyPrefixes.USDtoTRY, USDtoTRY);
                            _redisCacheService.Set(RedisKeyPrefixes.EURtoTRY, EURtoTRY);
                        }
                    }
                }

                // 1 hour delay
                await Task.Delay(3600000, _cancellationToken);
            }
        }

        Task IHostedService.StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}