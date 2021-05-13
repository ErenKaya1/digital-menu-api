using DigitalMenu.Core.Model;
using DigitalMenu.Core.Security;
using DigitalMenu.Core.Security.Contracts;
using DigitalMenu.Data.Context;
using DigitalMenu.Entity.Entities;
using DigitalMenu.Repository;
using DigitalMenu.Repository.Contracts;
using DigitalMenu.Service.Contracts;
using DigitalMenu.Service.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DigitalMenu.Entity.DTOs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System;
using DigitalMenu.Core.Model.User;
using DigitalMenu.Core.RabbitMQ;
using DigitalMenu.Core.Cache;
using DigitalMenu.Service.BackgroundServices;
using DigitalMenu.Core.Model.Menu;

namespace DigitalMenu.Service.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = "";
            if (!string.IsNullOrEmpty(Environment.GetEnvironmentVariable("POSTGRESQL_CONNECTION_STRING")))
                connectionString = Environment.GetEnvironmentVariable("POSTGRESQL_CONNECTION_STRING");
            else
                connectionString = configuration.GetConnectionString("PostgreSqlProvider");

            services.AddDbContext<DMContext>(options =>
            {
                options.UseNpgsql(connectionString);
            });

            var scopeFactory = services.BuildServiceProvider().GetRequiredService<IServiceScopeFactory>();
            using (var scope = scopeFactory.CreateScope())
            using (var dbContext = scope.ServiceProvider.GetRequiredService<DMContext>())
                dbContext.Database.Migrate();
        }

        public static void ConfigureEncryption(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IEncryption>(x => new Encryption
            {
                PrivateKey = configuration["EncryptionConfig:PrivateKey"]
            });
        }

        public static void ConfigureHasher(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IHasher>(x => new Hasher
            {
                Salt = configuration["HasherConfig:Salt"]
            });
        }

        public static void ConfigureRepository(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ISubscriptionTypeService, SubscriptionTypeService>();
            services.AddScoped<ISubscriptionService, SubscriptionService>();
            services.AddScoped<IImageService, ImageService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IMenuService, MenuService>();
            services.AddScoped<IPaymentService, PaymentService>();
        }

        public static void ConfigureAutoMapper(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(config =>
            {
                config.CreateMap<UserDTO, DMUser>();
                config.CreateMap<DMUser, UserDTO>();
                config.CreateMap<DMUser, RegisterModel>();
                config.CreateMap<DMUser, UpdateProfileModel>();
                config.CreateMap<UpdateProfileModel, DMUser>();
                config.CreateMap<RegisterModel, DMUser>();
                config.CreateMap<SubscriptionDTO, Subscription>();
                config.CreateMap<Subscription, SubscriptionDTO>();
                config.CreateMap<Company, CompanyDTO>();
                config.CreateMap<CompanyDTO, Company>();
                config.CreateMap<UpdateCompanyModel, Company>();
                config.CreateMap<Company, UpdateCompanyModel>();
                config.CreateMap<MenuThemeModel, Menu>();
                config.CreateMap<Menu, MenuThemeModel>();
            });
        }

        public static void ConfigureAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JwtSettings>(configuration.GetSection("Token"));
            services.AddScoped<ITokenService, TokenService>();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = true,
                    ValidateIssuer = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["Token:Issuer"],
                    ValidAudience = configuration["Token:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration["Token:SecurityKey"])),
                    ClockSkew = TimeSpan.Zero
                };
            });
        }

        public static void ConfigureEmailService(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<MailSettings>(configuration.GetSection("Mail"));
            services.AddScoped<IMailService>(x => new MailService
            {
                Host = configuration["Mail:Host"],
                Port = string.IsNullOrEmpty(configuration["Mail:Port"]) ? 0 : Convert.ToInt32(configuration["Mail:Port"]),
                Username = configuration["Mail:Username"],
                Password = configuration["Mail:Password"],
                UseSsl = !string.IsNullOrEmpty(configuration["Mail:UseSsl"]) && Convert.ToBoolean(configuration["Mail:UseSsl"])
            });
        }

        public static void ConfigureRabbitMQ(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<RabbitMQConfig>(x =>
            {
                x.Host = Environment.GetEnvironmentVariable("RABBITMQ_HOST") ?? configuration["RabbitMQConfig:Host"];
                x.Username = Environment.GetEnvironmentVariable("RABBITMQ_USERNAME") ?? configuration["RabbitMQConfig:Username"];
                x.Password = Environment.GetEnvironmentVariable("RABBITMQ_PASSWORD") ?? configuration["RabbitMQConfig:Password"];
            });

            services.AddScoped<IRabbitMQService>(x => new RabbitMQService
            {
                Hostname = configuration["RabbitMQConfig:Host"],
                Username = configuration["RabbitMQConfig:Username"],
                Password = configuration["RabbitMQConfig:password"],
            });
        }

        public static void ConfigureRedis(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IRedisCacheService>(x => new RedisCacheService(
                host: Environment.GetEnvironmentVariable("REDIS_HOST") ?? configuration["RedisConfig:Host"],
                port: string.IsNullOrEmpty(Environment.GetEnvironmentVariable("REDIS_PORT"))
                        ? Convert.ToInt32(configuration["RedisConfig:Port"])
                        : Convert.ToInt32(Environment.GetEnvironmentVariable("REDIS_PORT")),
                timeout: string.IsNullOrEmpty(configuration["RedisConfig:Timeout"]) ? 0 : Convert.ToInt32(configuration["RedisConfig:Timeout"])
            ));
        }

        public static void ConfigureBackgroundServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHostedService<SubscriptionReminder>();
            services.AddHostedService<ExchangeService>();
        }

        public static void ConfigureHttpClients(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient("exchange", options =>
            {
                options.BaseAddress = new Uri("https://www.doviz.com");
            });
        }

        public static void ConfigureIyzico(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<IyzicoConfig>(configuration.GetSection("IyzicoConfig"));
        }
    }
}