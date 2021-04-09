﻿// <auto-generated />
using System;
using DigitalMenu.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DigitalMenu.Data.Migrations
{
    [DbContext(typeof(DMContext))]
    [Migration("20210408235839_asdasdasdsas")]
    partial class asdasdasdsas
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityByDefaultColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("DigitalMenu.Entity.Entities.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("ImageName")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("category");
                });

            modelBuilder.Entity("DigitalMenu.Entity.Entities.CategoryTranslation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("CultureId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("CultureId");

                    b.ToTable("category_translation");
                });

            modelBuilder.Entity("DigitalMenu.Entity.Entities.Company", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("LogoName")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<string>("Slug")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.HasKey("Id");

                    b.ToTable("company");
                });

            modelBuilder.Entity("DigitalMenu.Entity.Entities.Culture", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("CultureCode")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("character varying(5)");

                    b.Property<bool>("IsDefaultCulture")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.ToTable("culture");

                    b.HasData(
                        new
                        {
                            Id = new Guid("59e939a9-41c1-4990-bbca-2f4f8826613a"),
                            CultureCode = "tr",
                            IsDefaultCulture = true
                        },
                        new
                        {
                            Id = new Guid("b09aa585-a95d-4698-a44f-f91e59b5393b"),
                            CultureCode = "en",
                            IsDefaultCulture = false
                        });
                });

            modelBuilder.Entity("DigitalMenu.Entity.Entities.DMRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.HasKey("Id");

                    b.HasIndex("RoleName")
                        .IsUnique();

                    b.ToTable("role");

                    b.HasData(
                        new
                        {
                            Id = new Guid("b19ebe2e-0dad-4445-896c-b0b2d0a33157"),
                            RoleName = "Admin"
                        },
                        new
                        {
                            Id = new Guid("d8a8f2f2-5196-4ac5-b5eb-d1ea15b9146f"),
                            RoleName = "Customer"
                        });
                });

            modelBuilder.Entity("DigitalMenu.Entity.Entities.DMUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("CompanyId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("character varying(16)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("character varying(16)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("character varying(16)");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("EmailAddress")
                        .IsUnique();

                    b.HasIndex("RoleId");

                    b.HasIndex("UserName")
                        .IsUnique();

                    b.ToTable("user");

                    b.HasData(
                        new
                        {
                            Id = new Guid("469b6dbe-ba51-49d8-b32d-736661f3cd15"),
                            CreatedAt = new DateTime(2021, 4, 8, 23, 58, 38, 967, DateTimeKind.Utc).AddTicks(6145),
                            EmailAddress = "test@gmail.com",
                            FirstName = "admin",
                            LastName = "test",
                            PasswordHash = "JaXGmn0+qpLRduAniDSq4Jn3PoaW+oh/hQJiNptum+Y=",
                            PhoneNumber = "123456789",
                            RoleId = new Guid("b19ebe2e-0dad-4445-896c-b0b2d0a33157"),
                            UserName = "admintest"
                        });
                });

            modelBuilder.Entity("DigitalMenu.Entity.Entities.Menu", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("menu");
                });

            modelBuilder.Entity("DigitalMenu.Entity.Entities.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uuid");

                    b.Property<string>("ImageName")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<Guid>("MenuId")
                        .HasColumnType("uuid");

                    b.Property<int>("Order")
                        .HasColumnType("integer");

                    b.Property<double>("Price")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("MenuId");

                    b.ToTable("product");
                });

            modelBuilder.Entity("DigitalMenu.Entity.Entities.ProductTranslation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CultureId")
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("CultureId");

                    b.HasIndex("ProductId");

                    b.ToTable("product_translation");
                });

            modelBuilder.Entity("DigitalMenu.Entity.Entities.RefreshToken", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CreatedByIp")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("Expires")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("ReplacedByToken")
                        .HasColumnType("text");

                    b.Property<DateTime?>("RevokedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("RevokedByIp")
                        .HasColumnType("text");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("refresh_token");
                });

            modelBuilder.Entity("DigitalMenu.Entity.Entities.ResetPasswordToken", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Expires")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("TokenHash")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("reset_password_token");
                });

            modelBuilder.Entity("DigitalMenu.Entity.Entities.Subscription", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("date");

                    b.Property<bool>("IsSubscriptionReminderMailSent")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsTrialMode")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("date");

                    b.Property<byte>("SubscriptionStatus")
                        .HasColumnType("smallint");

                    b.Property<Guid?>("SubscriptionTypeId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("SubscriptionTypeId");

                    b.HasIndex("UserId");

                    b.ToTable("subscription");
                });

            modelBuilder.Entity("DigitalMenu.Entity.Entities.SubscriptionType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<double>("Price")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.ToTable("subscription_type");
                });

            modelBuilder.Entity("DigitalMenu.Entity.Entities.SubscriptionTypeFeature", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("IsUnlimited")
                        .HasColumnType("boolean");

                    b.Property<byte>("SubscriptionFeatureName")
                        .HasColumnType("smallint");

                    b.Property<Guid?>("SubscriptionTypeId")
                        .HasColumnType("uuid");

                    b.Property<int?>("TotalValue")
                        .HasColumnType("integer");

                    b.Property<int?>("ValueRemained")
                        .HasColumnType("integer");

                    b.Property<int?>("ValueUsed")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("SubscriptionTypeId");

                    b.ToTable("subscription_type_feature");
                });

            modelBuilder.Entity("DigitalMenu.Entity.Entities.SubscriptionTypeFeatureTranslation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CultureId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<Guid>("SubscriptionTypeFeatureId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("CultureId");

                    b.HasIndex("SubscriptionTypeFeatureId");

                    b.ToTable("subsctiption_type_feature_translation");
                });

            modelBuilder.Entity("DigitalMenu.Entity.Entities.SubscriptionTypeTranslation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CultureId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("SubscriptionTypeId")
                        .HasColumnType("uuid");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CultureId");

                    b.HasIndex("SubscriptionTypeId");

                    b.ToTable("subscription_type_translation");
                });

            modelBuilder.Entity("DigitalMenu.Entity.Entities.Category", b =>
                {
                    b.HasOne("DigitalMenu.Entity.Entities.DMUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("DigitalMenu.Entity.Entities.CategoryTranslation", b =>
                {
                    b.HasOne("DigitalMenu.Entity.Entities.Category", "Category")
                        .WithMany("CategoryTranslation")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DigitalMenu.Entity.Entities.Culture", "Culture")
                        .WithMany()
                        .HasForeignKey("CultureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Culture");
                });

            modelBuilder.Entity("DigitalMenu.Entity.Entities.DMUser", b =>
                {
                    b.HasOne("DigitalMenu.Entity.Entities.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId");

                    b.HasOne("DigitalMenu.Entity.Entities.DMRole", "Role")
                        .WithMany("User")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("DigitalMenu.Entity.Entities.Menu", b =>
                {
                    b.HasOne("DigitalMenu.Entity.Entities.DMUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("DigitalMenu.Entity.Entities.Product", b =>
                {
                    b.HasOne("DigitalMenu.Entity.Entities.Category", "Category")
                        .WithMany("Product")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DigitalMenu.Entity.Entities.Menu", "Menu")
                        .WithMany("Product")
                        .HasForeignKey("MenuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Menu");
                });

            modelBuilder.Entity("DigitalMenu.Entity.Entities.ProductTranslation", b =>
                {
                    b.HasOne("DigitalMenu.Entity.Entities.Culture", "Culture")
                        .WithMany()
                        .HasForeignKey("CultureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DigitalMenu.Entity.Entities.Product", "Product")
                        .WithMany("ProductTranslation")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Culture");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("DigitalMenu.Entity.Entities.RefreshToken", b =>
                {
                    b.HasOne("DigitalMenu.Entity.Entities.DMUser", "User")
                        .WithMany("RefreshToken")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("DigitalMenu.Entity.Entities.ResetPasswordToken", b =>
                {
                    b.HasOne("DigitalMenu.Entity.Entities.DMUser", "User")
                        .WithMany("ResetPasswordToken")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("DigitalMenu.Entity.Entities.Subscription", b =>
                {
                    b.HasOne("DigitalMenu.Entity.Entities.SubscriptionType", "SubscriptionType")
                        .WithMany()
                        .HasForeignKey("SubscriptionTypeId");

                    b.HasOne("DigitalMenu.Entity.Entities.DMUser", "User")
                        .WithMany("Subscription")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SubscriptionType");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DigitalMenu.Entity.Entities.SubscriptionTypeFeature", b =>
                {
                    b.HasOne("DigitalMenu.Entity.Entities.SubscriptionType", null)
                        .WithMany("SubscriptionTypeFeature")
                        .HasForeignKey("SubscriptionTypeId");
                });

            modelBuilder.Entity("DigitalMenu.Entity.Entities.SubscriptionTypeFeatureTranslation", b =>
                {
                    b.HasOne("DigitalMenu.Entity.Entities.Culture", "Culture")
                        .WithMany()
                        .HasForeignKey("CultureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DigitalMenu.Entity.Entities.SubscriptionTypeFeature", "SubscriptionTypeFeature")
                        .WithMany("SubscriptionTypeFeatureTranslation")
                        .HasForeignKey("SubscriptionTypeFeatureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Culture");

                    b.Navigation("SubscriptionTypeFeature");
                });

            modelBuilder.Entity("DigitalMenu.Entity.Entities.SubscriptionTypeTranslation", b =>
                {
                    b.HasOne("DigitalMenu.Entity.Entities.Culture", "Culture")
                        .WithMany()
                        .HasForeignKey("CultureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DigitalMenu.Entity.Entities.SubscriptionType", "SubscriptionType")
                        .WithMany("SubscriptionTypeTranslation")
                        .HasForeignKey("SubscriptionTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Culture");

                    b.Navigation("SubscriptionType");
                });

            modelBuilder.Entity("DigitalMenu.Entity.Entities.Category", b =>
                {
                    b.Navigation("CategoryTranslation");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("DigitalMenu.Entity.Entities.DMRole", b =>
                {
                    b.Navigation("User");
                });

            modelBuilder.Entity("DigitalMenu.Entity.Entities.DMUser", b =>
                {
                    b.Navigation("RefreshToken");

                    b.Navigation("ResetPasswordToken");

                    b.Navigation("Subscription");
                });

            modelBuilder.Entity("DigitalMenu.Entity.Entities.Menu", b =>
                {
                    b.Navigation("Product");
                });

            modelBuilder.Entity("DigitalMenu.Entity.Entities.Product", b =>
                {
                    b.Navigation("ProductTranslation");
                });

            modelBuilder.Entity("DigitalMenu.Entity.Entities.SubscriptionType", b =>
                {
                    b.Navigation("SubscriptionTypeFeature");

                    b.Navigation("SubscriptionTypeTranslation");
                });

            modelBuilder.Entity("DigitalMenu.Entity.Entities.SubscriptionTypeFeature", b =>
                {
                    b.Navigation("SubscriptionTypeFeatureTranslation");
                });
#pragma warning restore 612, 618
        }
    }
}
