﻿// <auto-generated />
using System;
using DigitalMenu.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DigitalMenu.Data.Migrations
{
    [DbContext(typeof(DMContext))]
    partial class DMContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.HasIndex("Slug")
                        .IsUnique();

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
                            Id = new Guid("48c92719-ebe7-4b4c-9814-9c8f1a57b1ff"),
                            CultureCode = "tr",
                            IsDefaultCulture = true
                        },
                        new
                        {
                            Id = new Guid("41d8d90c-2224-42fb-ac80-c27b87e74371"),
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
                            Id = new Guid("e07a821f-866e-48f9-86b2-147eab18ffc9"),
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
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

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
                            Id = new Guid("88769d80-6a01-41f7-b048-d0b41dc9e137"),
                            CreatedAt = new DateTime(2021, 4, 18, 21, 40, 7, 699, DateTimeKind.Utc).AddTicks(3973),
                            EmailAddress = "test@gmail.com",
                            FirstName = "admin",
                            LastName = "test",
                            PasswordHash = "JaXGmn0+qpLRduAniDSq4Jn3PoaW+oh/hQJiNptum+Y=",
                            PhoneNumber = "123456789",
                            RoleId = new Guid("b19ebe2e-0dad-4445-896c-b0b2d0a33157"),
                            UserName = "admintest"
                        });
                });

            modelBuilder.Entity("DigitalMenu.Entity.Entities.ExchangeType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<double>("TRYtoEUR")
                        .HasColumnType("double precision");

                    b.Property<double>("TRYtoUSD")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.ToTable("exhange_type");
                });

            modelBuilder.Entity("DigitalMenu.Entity.Entities.Menu", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("CompanyId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

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

                    b.HasData(
                        new
                        {
                            Id = new Guid("638885d5-6b38-4c01-903a-449c676b86f5"),
                            Price = 5.0
                        },
                        new
                        {
                            Id = new Guid("971daed0-4c56-4e5b-b9a9-74eb975c54eb"),
                            Price = 10.0
                        },
                        new
                        {
                            Id = new Guid("e0f8c62e-9769-4520-a46b-2d23f6abe7e3"),
                            Price = 20.0
                        });
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

                    b.Property<Guid>("SubscriptionTypeId")
                        .HasColumnType("uuid");

                    b.Property<int?>("TotalValue")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("SubscriptionTypeId");

                    b.ToTable("subscription_type_feature");

                    b.HasData(
                        new
                        {
                            Id = new Guid("41cdda69-aa5f-496f-8c1a-3f26d1a32dae"),
                            IsUnlimited = false,
                            SubscriptionFeatureName = (byte)0,
                            SubscriptionTypeId = new Guid("638885d5-6b38-4c01-903a-449c676b86f5"),
                            TotalValue = 20
                        },
                        new
                        {
                            Id = new Guid("9abf06ab-0c1a-4c63-a141-e512fe306c1e"),
                            IsUnlimited = false,
                            SubscriptionFeatureName = (byte)0,
                            SubscriptionTypeId = new Guid("971daed0-4c56-4e5b-b9a9-74eb975c54eb"),
                            TotalValue = 40
                        },
                        new
                        {
                            Id = new Guid("da12028f-418a-4bd2-9617-27c4aec8372c"),
                            IsUnlimited = true,
                            SubscriptionFeatureName = (byte)0,
                            SubscriptionTypeId = new Guid("e0f8c62e-9769-4520-a46b-2d23f6abe7e3")
                        });
                });

            modelBuilder.Entity("DigitalMenu.Entity.Entities.SubscriptionTypeFeatureTranslation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CultureId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<Guid>("SubscriptionTypeFeatureId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("CultureId");

                    b.HasIndex("SubscriptionTypeFeatureId");

                    b.ToTable("subsctiption_type_feature_translation");

                    b.HasData(
                        new
                        {
                            Id = new Guid("17f99bab-248f-4448-95f3-c1c1086ca48d"),
                            CultureId = new Guid("48c92719-ebe7-4b4c-9814-9c8f1a57b1ff"),
                            Name = "Ürün",
                            SubscriptionTypeFeatureId = new Guid("41cdda69-aa5f-496f-8c1a-3f26d1a32dae")
                        },
                        new
                        {
                            Id = new Guid("8d39de66-023d-4cd1-a577-c0c29cc456b7"),
                            CultureId = new Guid("41d8d90c-2224-42fb-ac80-c27b87e74371"),
                            Name = "Product",
                            SubscriptionTypeFeatureId = new Guid("41cdda69-aa5f-496f-8c1a-3f26d1a32dae")
                        },
                        new
                        {
                            Id = new Guid("9f9bfd00-2081-4419-9bf9-321afc7def15"),
                            CultureId = new Guid("48c92719-ebe7-4b4c-9814-9c8f1a57b1ff"),
                            Name = "Ürün",
                            SubscriptionTypeFeatureId = new Guid("9abf06ab-0c1a-4c63-a141-e512fe306c1e")
                        },
                        new
                        {
                            Id = new Guid("eedd3817-3f48-43d0-947b-296184bcc5fb"),
                            CultureId = new Guid("41d8d90c-2224-42fb-ac80-c27b87e74371"),
                            Name = "Product",
                            SubscriptionTypeFeatureId = new Guid("9abf06ab-0c1a-4c63-a141-e512fe306c1e")
                        },
                        new
                        {
                            Id = new Guid("d689ffbb-4ba0-4b98-bf83-4f1ac3895780"),
                            CultureId = new Guid("48c92719-ebe7-4b4c-9814-9c8f1a57b1ff"),
                            Name = "Ürün",
                            SubscriptionTypeFeatureId = new Guid("da12028f-418a-4bd2-9617-27c4aec8372c")
                        },
                        new
                        {
                            Id = new Guid("3e1bddde-d260-46fc-88dd-32eba0cbbcde"),
                            CultureId = new Guid("41d8d90c-2224-42fb-ac80-c27b87e74371"),
                            Name = "Product",
                            SubscriptionTypeFeatureId = new Guid("da12028f-418a-4bd2-9617-27c4aec8372c")
                        });
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
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.HasKey("Id");

                    b.HasIndex("CultureId");

                    b.HasIndex("SubscriptionTypeId");

                    b.ToTable("subscription_type_translation");

                    b.HasData(
                        new
                        {
                            Id = new Guid("64d27573-ea10-4e20-80ad-8552ac6112ec"),
                            CultureId = new Guid("48c92719-ebe7-4b4c-9814-9c8f1a57b1ff"),
                            SubscriptionTypeId = new Guid("638885d5-6b38-4c01-903a-449c676b86f5"),
                            Title = "Giriş"
                        },
                        new
                        {
                            Id = new Guid("817a4f3e-d5a5-46c8-a754-2ca774e12cc6"),
                            CultureId = new Guid("41d8d90c-2224-42fb-ac80-c27b87e74371"),
                            SubscriptionTypeId = new Guid("638885d5-6b38-4c01-903a-449c676b86f5"),
                            Title = "Starter"
                        },
                        new
                        {
                            Id = new Guid("08196d65-71dd-4e10-8a58-473871aef7b6"),
                            CultureId = new Guid("48c92719-ebe7-4b4c-9814-9c8f1a57b1ff"),
                            SubscriptionTypeId = new Guid("971daed0-4c56-4e5b-b9a9-74eb975c54eb"),
                            Title = "Ekonomik"
                        },
                        new
                        {
                            Id = new Guid("4a42bb07-d846-47e5-876f-e9e9c236a81a"),
                            CultureId = new Guid("41d8d90c-2224-42fb-ac80-c27b87e74371"),
                            SubscriptionTypeId = new Guid("971daed0-4c56-4e5b-b9a9-74eb975c54eb"),
                            Title = "Economic"
                        },
                        new
                        {
                            Id = new Guid("a1bd7979-d5da-438e-b80a-1b95b8b72cfd"),
                            CultureId = new Guid("48c92719-ebe7-4b4c-9814-9c8f1a57b1ff"),
                            SubscriptionTypeId = new Guid("e0f8c62e-9769-4520-a46b-2d23f6abe7e3"),
                            Title = "Premium"
                        },
                        new
                        {
                            Id = new Guid("43795660-5b52-4317-88d0-46539fd86b75"),
                            CultureId = new Guid("41d8d90c-2224-42fb-ac80-c27b87e74371"),
                            SubscriptionTypeId = new Guid("e0f8c62e-9769-4520-a46b-2d23f6abe7e3"),
                            Title = "Premium"
                        });
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
                    b.HasOne("DigitalMenu.Entity.Entities.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId");

                    b.HasOne("DigitalMenu.Entity.Entities.DMUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");

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
                    b.HasOne("DigitalMenu.Entity.Entities.SubscriptionType", "SubscriptionType")
                        .WithMany("SubscriptionTypeFeature")
                        .HasForeignKey("SubscriptionTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SubscriptionType");
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
