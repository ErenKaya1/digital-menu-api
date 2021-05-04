using System;
using DigitalMenu.Middleware.CustomMiddlewares;
using DigitalMenu.RabbitMQ.Consumer.Consumers;
using DigitalMenu.Service.BackgroundServices;
using DigitalMenu.Service.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;

namespace DigitalMenu.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DigitalMenu.Api", Version = "v1" });
            });

            services.AddDataProtection();
            services.ConfigureDbContext(Configuration);
            services.ConfigureEncryption(Configuration);
            services.ConfigureHasher(Configuration);
            services.ConfigureRepository(Configuration);
            services.ConfigureAutoMapper(Configuration);
            services.ConfigureAuthentication(Configuration);
            services.ConfigureEmailService(Configuration);
            services.ConfigureRabbitMQ(Configuration);
            services.ConfigureRedis(Configuration);
            services.AddHostedService<EmailSender>();
            services.ConfigureBackgroundServices(Configuration);
            services.ConfigureHttpClients(Configuration);
            services.ConfigureIyzico(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DigitalMenu.Api v1"));
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseStaticFiles();
            app.UseCors(builder =>
            {
                builder
                    .WithOrigins("http://localhost:8080")
                    .WithExposedHeaders("X-New-Jwt-Token")
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
            });
            app.UseMiddleware<RefreshTokenMiddleware>();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
