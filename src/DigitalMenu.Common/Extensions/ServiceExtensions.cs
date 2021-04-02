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
using System.Collections.Generic;
using DigitalMenu.Core.Cache;
using DigitalMenu.Service.BackgroundServices;
using DigitalMenu.RabbitMQ.Consumer.Consumers;

namespace DigitalMenu.Common.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("PostgreSqlProvider");
            services.AddDbContext<DMContext>(options =>
            {
                options.UseNpgsql(connectionString);
            });
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
            services.Configure<RabbitMQConfig>(configuration.GetSection("RabbitMQConfig"));

            services.AddTransient<IRabbitMQService>(x => new RabbitMQService
            {
                Hostname = configuration["RabbitMQConfig:Host"],
                Username = configuration["RabbitMQConfig:Username"],
                Password = configuration["RabbitMQConfig:password"],
            });
        }

        public static void ConfigureRedis(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IRedisCacheService>(x => new RedisCacheService(
                host: configuration["RedisConfig:Host"],
                port: string.IsNullOrEmpty(configuration["RedisConfig:Port"]) ? 0 : Convert.ToInt32(configuration["RedisConfig:Port"]),
                timeout: string.IsNullOrEmpty(configuration["RedisConfig:Timeout"]) ? 0 : Convert.ToInt32(configuration["RedisConfig:Timeout"])
            ));
        }

        public static void ConfigureHostedServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHostedService<EmailSender>();
            services.AddHostedService<SubscriptionReminder>();
        }
    }
}