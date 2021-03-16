using DigitalMenu.Core.Model;
using DigitalMenu.Core.Security;
using DigitalMenu.Core.Security.Contracts;
using DigitalMenu.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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
    }
}