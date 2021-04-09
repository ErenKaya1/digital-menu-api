using System.IO;
using DigitalMenu.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace DigitalMenu.Data.Factory
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<DMContext>
    {
        public DMContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<DMContext>();
            var configPath = Path.Combine(Directory.GetCurrentDirectory(), "../DigitalMenu.Api");
            var configuration = new ConfigurationBuilder()
                                    .SetBasePath(configPath)
                                    .AddJsonFile("appsettings.json")
                                    .Build();
            var connectionString = configuration.GetConnectionString("PostgreSqlProvider");
            builder.UseNpgsql(connectionString);

            return new DMContext(builder.Options);
        }
    }
}