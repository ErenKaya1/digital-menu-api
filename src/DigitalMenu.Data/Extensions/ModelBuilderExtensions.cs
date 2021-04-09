using System;
using DigitalMenu.Common.Enum;
using DigitalMenu.Entity.Entities;
using Microsoft.EntityFrameworkCore;

namespace DigitalMenu.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DMRole>().HasIndex(x => x.RoleName).IsUnique();

            // default roles
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
                }
            );

            modelBuilder.Entity<Culture>().HasData(
                new Culture
                {
                    Id = Guid.Parse("48c92719-ebe7-4b4c-9814-9c8f1a57b1ff"),
                    CultureCode = "tr",
                    IsDefaultCulture = true
                },
                new Culture
                {
                    Id = Guid.Parse("41d8d90c-2224-42fb-ac80-c27b87e74371"),
                    CultureCode = "en",
                    IsDefaultCulture = false
                }
            );

            // default subscription types
            modelBuilder.Entity<SubscriptionType>().HasData(
                // starter
                new SubscriptionType
                {
                    Id = Guid.Parse("638885d5-6b38-4c01-903a-449c676b86f5"),
                    Price = 5,
                },

                // economic
                new SubscriptionType
                {
                    Id = Guid.Parse("971daed0-4c56-4e5b-b9a9-74eb975c54eb"),
                    Price = 10,
                },

                // premium
                new SubscriptionType
                {
                    Id = Guid.Parse("e0f8c62e-9769-4520-a46b-2d23f6abe7e3"),
                    Price = 20,
                }
            );

            modelBuilder.Entity<SubscriptionTypeFeature>().HasData(
                new SubscriptionTypeFeature
                {
                    Id = Guid.Parse("41cdda69-aa5f-496f-8c1a-3f26d1a32dae"),
                    TotalValue = 20,
                    IsUnlimited = false,
                    SubscriptionTypeId = Guid.Parse("638885d5-6b38-4c01-903a-449c676b86f5"),
                    SubscriptionFeatureName = SubscriptionFeatureName.Product,
                },
                new SubscriptionTypeFeature
                {
                    Id = Guid.Parse("9abf06ab-0c1a-4c63-a141-e512fe306c1e"),
                    TotalValue = 40,
                    SubscriptionTypeId = Guid.Parse("971daed0-4c56-4e5b-b9a9-74eb975c54eb"),
                    IsUnlimited = false,
                    SubscriptionFeatureName = SubscriptionFeatureName.Product,
                },
                new SubscriptionTypeFeature
                {
                    Id = Guid.Parse("da12028f-418a-4bd2-9617-27c4aec8372c"),
                    IsUnlimited = true,
                    SubscriptionTypeId = Guid.Parse("e0f8c62e-9769-4520-a46b-2d23f6abe7e3"),
                    SubscriptionFeatureName = SubscriptionFeatureName.Product,
                }
            );

            modelBuilder.Entity<SubscriptionTypeTranslation>().HasData(
                new SubscriptionTypeTranslation
                {
                    Id = Guid.NewGuid(),
                    CultureId = Guid.Parse("48c92719-ebe7-4b4c-9814-9c8f1a57b1ff"),
                    Title = "Giriş",
                    SubscriptionTypeId = Guid.Parse("638885d5-6b38-4c01-903a-449c676b86f5"),
                },
                new SubscriptionTypeTranslation
                {
                    Id = Guid.NewGuid(),
                    CultureId = Guid.Parse("41d8d90c-2224-42fb-ac80-c27b87e74371"),
                    Title = "Starter",
                    SubscriptionTypeId = Guid.Parse("638885d5-6b38-4c01-903a-449c676b86f5"),
                },
                new SubscriptionTypeTranslation
                {
                    Id = Guid.NewGuid(),
                    CultureId = Guid.Parse("48c92719-ebe7-4b4c-9814-9c8f1a57b1ff"),
                    Title = "Ekonomik",
                    SubscriptionTypeId = Guid.Parse("971daed0-4c56-4e5b-b9a9-74eb975c54eb"),
                },
                new SubscriptionTypeTranslation
                {
                    Id = Guid.NewGuid(),
                    CultureId = Guid.Parse("41d8d90c-2224-42fb-ac80-c27b87e74371"),
                    Title = "Economic",
                    SubscriptionTypeId = Guid.Parse("971daed0-4c56-4e5b-b9a9-74eb975c54eb"),
                },
                new SubscriptionTypeTranslation
                {
                    Id = Guid.NewGuid(),
                    CultureId = Guid.Parse("48c92719-ebe7-4b4c-9814-9c8f1a57b1ff"),
                    Title = "Premium",
                    SubscriptionTypeId = Guid.Parse("e0f8c62e-9769-4520-a46b-2d23f6abe7e3"),
                },
                new SubscriptionTypeTranslation
                {
                    Id = Guid.NewGuid(),
                    CultureId = Guid.Parse("41d8d90c-2224-42fb-ac80-c27b87e74371"),
                    Title = "Premium",
                    SubscriptionTypeId = Guid.Parse("e0f8c62e-9769-4520-a46b-2d23f6abe7e3"),
                }
            );

            modelBuilder.Entity<SubscriptionTypeFeatureTranslation>().HasData(
                new SubscriptionTypeFeatureTranslation
                {
                    Id = Guid.NewGuid(),
                    CultureId = Guid.Parse("48c92719-ebe7-4b4c-9814-9c8f1a57b1ff"),
                    Name = "Ürün",
                    SubscriptionTypeFeatureId = Guid.Parse("41cdda69-aa5f-496f-8c1a-3f26d1a32dae")
                },
                new SubscriptionTypeFeatureTranslation
                {
                    Id = Guid.NewGuid(),
                    CultureId = Guid.Parse("41d8d90c-2224-42fb-ac80-c27b87e74371"),
                    Name = "Product",
                    SubscriptionTypeFeatureId = Guid.Parse("41cdda69-aa5f-496f-8c1a-3f26d1a32dae")
                },
                new SubscriptionTypeFeatureTranslation
                {
                    Id = Guid.NewGuid(),
                    CultureId = Guid.Parse("48c92719-ebe7-4b4c-9814-9c8f1a57b1ff"),
                    Name = "Ürün",
                    SubscriptionTypeFeatureId = Guid.Parse("9abf06ab-0c1a-4c63-a141-e512fe306c1e")
                },
                new SubscriptionTypeFeatureTranslation
                {
                    Id = Guid.NewGuid(),
                    CultureId = Guid.Parse("41d8d90c-2224-42fb-ac80-c27b87e74371"),
                    Name = "Product",
                    SubscriptionTypeFeatureId = Guid.Parse("9abf06ab-0c1a-4c63-a141-e512fe306c1e")
                },
                new SubscriptionTypeFeatureTranslation
                {
                    Id = Guid.NewGuid(),
                    CultureId = Guid.Parse("48c92719-ebe7-4b4c-9814-9c8f1a57b1ff"),
                    Name = "Ürün",
                    SubscriptionTypeFeatureId = Guid.Parse("da12028f-418a-4bd2-9617-27c4aec8372c")
                },
                new SubscriptionTypeFeatureTranslation
                {
                    Id = Guid.NewGuid(),
                    CultureId = Guid.Parse("41d8d90c-2224-42fb-ac80-c27b87e74371"),
                    Name = "Product",
                    SubscriptionTypeFeatureId = Guid.Parse("da12028f-418a-4bd2-9617-27c4aec8372c")
                }
            );
        }
    }
}