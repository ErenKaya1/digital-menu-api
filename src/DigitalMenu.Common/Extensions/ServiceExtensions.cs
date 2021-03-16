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

namespace DigitalMenu.Common.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("PostgreSqlProvider");
            services.AddDbContext<DMContext>(options => options.UseNpgsql(connectionString));
        }

        public static void ConfigureEncryption(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<EncryptionConfig>(configuration.GetSection("EncryptionConfig"));
            services.AddTransient<IEncryption, Encryption>();
        }

        public static void ConfigureHasher(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<HasherConfig>(configuration.GetSection("HasherConfig"));
            services.AddTransient<IHasher, Hasher>();
        }

        public static void ConfigureRepository(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserService, UserService>();
        }

        public static void ConfigureAutoMapper(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(config =>
            {
                config.CreateMap<UserDTO, DMUser>();
                config.CreateMap<DMUser, UserDTO>();
            });
        }
    }
}