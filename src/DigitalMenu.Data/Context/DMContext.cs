using System;
using System.Collections.Generic;
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
            modelBuilder.Entity<DMRole>().HasData(
                new DMRole
                {
                    Id = Guid.Parse("b19ebe2e-0dad-4445-896c-b0b2d0a33157"),
                    RoleName = "Admin"
                },
                new DMRole
                {
                    Id = Guid.NewGuid(),
                    RoleName = "Customer"
                }
            );

            modelBuilder.Entity<DMUser>().HasIndex(x => x.UserName).IsUnique();
            modelBuilder.Entity<DMUser>().HasIndex(x => x.EmailAddress).IsUnique();
            modelBuilder.Entity<DMUser>().HasData(
                new DMUser
                {
                    Id = Guid.NewGuid(),
                    UserName = "admintest",
                    FirstName = "admin",
                    LastName = "test",
                    EmailAddress = "test@gmail.com", // 7kZ70Fsg/M1ldDvytd2IRgGLScOsY7TbRdiVV0/1UNc=
                    PhoneNumber = "123456789", // vcX83jUAd/UJxiqFkb6nQP2bAAjt87nF
                    CreatedAt = DateTime.UtcNow,
                    PasswordHash = "JaXGmn0+qpLRduAniDSq4Jn3PoaW+oh/hQJiNptum+Y=", // admintest123
                    RoleId = Guid.Parse("b19ebe2e-0dad-4445-896c-b0b2d0a33157") // admin
                });

            modelBuilder.Entity<Culture>().HasData(
                new Culture
                {
                    Id = Guid.NewGuid(),
                    CultureCode = "tr",
                    IsDefaultCulture = true
                },
                new Culture
                {
                    Id = Guid.NewGuid(),
                    CultureCode = "en",
                    IsDefaultCulture = false
                }
            );
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
    }
}