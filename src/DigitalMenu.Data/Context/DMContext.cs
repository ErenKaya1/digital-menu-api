using System;
using System.Collections.Generic;
using DigitalMenu.Data.Extensions;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DMRole>().HasIndex(x => x.RoleName).IsUnique();
            modelBuilder.Entity<DMUser>().HasIndex(x => x.UserName).IsUnique();
            modelBuilder.Entity<DMUser>().HasIndex(x => x.EmailAddress).IsUnique();
            modelBuilder.Entity<Company>().HasIndex(x => x.Slug).IsUnique();
            modelBuilder.Seed();
        }

        public DbSet<DMUser> User { get; set; }
        public DbSet<RefreshToken> RefreshToken { get; set; }
        public DbSet<DMRole> Role { get; set; }
        public DbSet<Subscription> Subscription { get; set; }
        public DbSet<ResetPasswordToken> ResetPasswordToken { get; set; }
        public DbSet<Culture> Culture { get; set; }
        public DbSet<SubscriptionType> SubscriptionType { get; set; }
        public DbSet<SubscriptionTypeTranslation> SubscriptionTypeTranslation { get; set; }
        public DbSet<SubscriptionTypeFeature> SubscriptionTypeFeature { get; set; }
        public DbSet<SubscriptionTypeFeatureTranslation> SubscriptionTypeFeatureTranslation { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<CategoryTranslation> CategoryTranslation { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductTranslation> ProductTranslation { get; set; }
        public DbSet<Menu> Menu { get; set; }
        public DbSet<ExchangeType> ExchangeType { get; set; }
        public DbSet<Payment> Payment { get; set; }
    }
}