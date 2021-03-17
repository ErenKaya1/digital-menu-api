using System;
using DigitalMenu.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DigitalMenu.Data.Context
{
    public class DMContext : DbContext
    {
        public DMContext(DbContextOptions<DMContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
        }

        public DbSet<DMUser> User { get; set; }
        public DbSet<RefreshToken> RefreshToken { get; set; }
    }
}