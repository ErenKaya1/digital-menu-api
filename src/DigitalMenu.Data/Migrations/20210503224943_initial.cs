using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DigitalMenu.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "company",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    Slug = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    LogoName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_company", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "culture",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CultureCode = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: false),
                    IsDefaultCulture = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_culture", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "exhange_type",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    USDtoTRY = table.Column<double>(type: "double precision", nullable: false),
                    EURtoTRY = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_exhange_type", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "role",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RoleName = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "subscription_type",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Price = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subscription_type", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserName = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    FirstName = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    EmailAddress = table.Column<string>(type: "text", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_user_role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "subscription_type_feature",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IsUnlimited = table.Column<bool>(type: "boolean", nullable: false),
                    TotalValue = table.Column<int>(type: "integer", nullable: true),
                    SubscriptionTypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    SubscriptionFeatureName = table.Column<byte>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subscription_type_feature", x => x.Id);
                    table.ForeignKey(
                        name: "FK_subscription_type_feature_subscription_type_SubscriptionTyp~",
                        column: x => x.SubscriptionTypeId,
                        principalTable: "subscription_type",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "subscription_type_translation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    CultureId = table.Column<Guid>(type: "uuid", nullable: false),
                    SubscriptionTypeId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subscription_type_translation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_subscription_type_translation_culture_CultureId",
                        column: x => x.CultureId,
                        principalTable: "culture",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_subscription_type_translation_subscription_type_Subscriptio~",
                        column: x => x.SubscriptionTypeId,
                        principalTable: "subscription_type",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "category",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ImageName = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_category", x => x.Id);
                    table.ForeignKey(
                        name: "FK_category_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "menu",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_menu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_menu_company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_menu_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "refresh_token",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Token = table.Column<string>(type: "text", nullable: false),
                    Expires = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedByIp = table.Column<string>(type: "text", nullable: false),
                    RevokedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    RevokedByIp = table.Column<string>(type: "text", nullable: true),
                    ReplacedByToken = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_refresh_token", x => x.Id);
                    table.ForeignKey(
                        name: "FK_refresh_token_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "reset_password_token",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TokenHash = table.Column<string>(type: "text", nullable: false),
                    Expires = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reset_password_token", x => x.Id);
                    table.ForeignKey(
                        name: "FK_reset_password_token_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "subscription",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    StartDate = table.Column<DateTime>(type: "date", nullable: false),
                    EndDate = table.Column<DateTime>(type: "date", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsTrialMode = table.Column<bool>(type: "boolean", nullable: false),
                    IsSuspended = table.Column<bool>(type: "boolean", nullable: false),
                    IsCurrent = table.Column<bool>(type: "boolean", nullable: false),
                    IsSubscriptionReminderMailSent = table.Column<bool>(type: "boolean", nullable: false),
                    SubscriptionTypeId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subscription", x => x.Id);
                    table.ForeignKey(
                        name: "FK_subscription_subscription_type_SubscriptionTypeId",
                        column: x => x.SubscriptionTypeId,
                        principalTable: "subscription_type",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_subscription_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "subsctiption_type_feature_translation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    CultureId = table.Column<Guid>(type: "uuid", nullable: false),
                    SubscriptionTypeFeatureId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subsctiption_type_feature_translation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_subsctiption_type_feature_translation_culture_CultureId",
                        column: x => x.CultureId,
                        principalTable: "culture",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_subsctiption_type_feature_translation_subscription_type_fea~",
                        column: x => x.SubscriptionTypeFeatureId,
                        principalTable: "subscription_type_feature",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "category_translation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    CultureId = table.Column<Guid>(type: "uuid", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_category_translation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_category_translation_category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_category_translation_culture_CultureId",
                        column: x => x.CultureId,
                        principalTable: "culture",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "product",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Price = table.Column<double>(type: "double precision", nullable: false),
                    Order = table.Column<int>(type: "integer", nullable: false),
                    ImageName = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    CategoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    MenuId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_product_category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_product_menu_MenuId",
                        column: x => x.MenuId,
                        principalTable: "menu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "product_group",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Price = table.Column<double>(type: "double precision", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    MenuId = table.Column<Guid>(type: "uuid", nullable: false),
                    ImageName = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_group", x => x.Id);
                    table.ForeignKey(
                        name: "FK_product_group_category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_product_group_menu_MenuId",
                        column: x => x.MenuId,
                        principalTable: "menu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "product_translation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    CultureId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductGroupId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_translation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_product_translation_culture_CultureId",
                        column: x => x.CultureId,
                        principalTable: "culture",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_product_translation_product_group_ProductGroupId",
                        column: x => x.ProductGroupId,
                        principalTable: "product_group",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_product_translation_product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductProductGroup",
                columns: table => new
                {
                    ProductGroupId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductProductGroup", x => new { x.ProductGroupId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_ProductProductGroup_product_group_ProductGroupId",
                        column: x => x.ProductGroupId,
                        principalTable: "product_group",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductProductGroup_product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "culture",
                columns: new[] { "Id", "CultureCode", "IsDefaultCulture" },
                values: new object[,]
                {
                    { new Guid("48c92719-ebe7-4b4c-9814-9c8f1a57b1ff"), "tr", true },
                    { new Guid("41d8d90c-2224-42fb-ac80-c27b87e74371"), "en", false }
                });

            migrationBuilder.InsertData(
                table: "role",
                columns: new[] { "Id", "RoleName" },
                values: new object[,]
                {
                    { new Guid("b19ebe2e-0dad-4445-896c-b0b2d0a33157"), "Admin" },
                    { new Guid("47c78660-31f0-4158-8ca6-82ec9b904993"), "Customer" }
                });

            migrationBuilder.InsertData(
                table: "subscription_type",
                columns: new[] { "Id", "Price" },
                values: new object[,]
                {
                    { new Guid("638885d5-6b38-4c01-903a-449c676b86f5"), 5.0 },
                    { new Guid("971daed0-4c56-4e5b-b9a9-74eb975c54eb"), 10.0 },
                    { new Guid("e0f8c62e-9769-4520-a46b-2d23f6abe7e3"), 20.0 }
                });

            migrationBuilder.InsertData(
                table: "subscription_type_feature",
                columns: new[] { "Id", "IsUnlimited", "SubscriptionFeatureName", "SubscriptionTypeId", "TotalValue" },
                values: new object[,]
                {
                    { new Guid("41cdda69-aa5f-496f-8c1a-3f26d1a32dae"), false, (byte)0, new Guid("638885d5-6b38-4c01-903a-449c676b86f5"), 20 },
                    { new Guid("9abf06ab-0c1a-4c63-a141-e512fe306c1e"), false, (byte)0, new Guid("971daed0-4c56-4e5b-b9a9-74eb975c54eb"), 40 },
                    { new Guid("da12028f-418a-4bd2-9617-27c4aec8372c"), true, (byte)0, new Guid("e0f8c62e-9769-4520-a46b-2d23f6abe7e3"), null }
                });

            migrationBuilder.InsertData(
                table: "subscription_type_translation",
                columns: new[] { "Id", "CultureId", "SubscriptionTypeId", "Title" },
                values: new object[,]
                {
                    { new Guid("1b304f3a-0fff-4c55-8da9-f97acc4b678c"), new Guid("48c92719-ebe7-4b4c-9814-9c8f1a57b1ff"), new Guid("638885d5-6b38-4c01-903a-449c676b86f5"), "Giriş" },
                    { new Guid("bdf250ed-f1a9-44a4-8356-17cd91f66c00"), new Guid("41d8d90c-2224-42fb-ac80-c27b87e74371"), new Guid("638885d5-6b38-4c01-903a-449c676b86f5"), "Starter" },
                    { new Guid("e22270be-ed2e-4feb-b978-ac7527707b72"), new Guid("48c92719-ebe7-4b4c-9814-9c8f1a57b1ff"), new Guid("971daed0-4c56-4e5b-b9a9-74eb975c54eb"), "Ekonomik" },
                    { new Guid("d9d2be6b-64f4-4ce6-b2f8-4c21fba8f416"), new Guid("41d8d90c-2224-42fb-ac80-c27b87e74371"), new Guid("971daed0-4c56-4e5b-b9a9-74eb975c54eb"), "Economic" },
                    { new Guid("15c40564-2dd8-4be2-a004-b6ad76d6a836"), new Guid("48c92719-ebe7-4b4c-9814-9c8f1a57b1ff"), new Guid("e0f8c62e-9769-4520-a46b-2d23f6abe7e3"), "Premium" },
                    { new Guid("6af4216d-86a8-4ce0-af4e-97f034102995"), new Guid("41d8d90c-2224-42fb-ac80-c27b87e74371"), new Guid("e0f8c62e-9769-4520-a46b-2d23f6abe7e3"), "Premium" }
                });

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "Id", "CompanyId", "CreatedAt", "EmailAddress", "FirstName", "LastName", "PasswordHash", "PhoneNumber", "RoleId", "UserName" },
                values: new object[] { new Guid("e5ac5f54-5a51-4d94-be70-9e9dfaa81acb"), null, new DateTime(2021, 5, 3, 22, 49, 42, 862, DateTimeKind.Utc).AddTicks(2490), "test@gmail.com", "admin", "test", "JaXGmn0+qpLRduAniDSq4Jn3PoaW+oh/hQJiNptum+Y=", "123456789", new Guid("b19ebe2e-0dad-4445-896c-b0b2d0a33157"), "admintest" });

            migrationBuilder.InsertData(
                table: "subsctiption_type_feature_translation",
                columns: new[] { "Id", "CultureId", "Name", "SubscriptionTypeFeatureId" },
                values: new object[,]
                {
                    { new Guid("296b3ff4-6865-4f89-b67b-505f59fd4103"), new Guid("48c92719-ebe7-4b4c-9814-9c8f1a57b1ff"), "Ürün", new Guid("41cdda69-aa5f-496f-8c1a-3f26d1a32dae") },
                    { new Guid("7480ffd2-205a-46c9-b728-e072d2792d36"), new Guid("41d8d90c-2224-42fb-ac80-c27b87e74371"), "Product", new Guid("41cdda69-aa5f-496f-8c1a-3f26d1a32dae") },
                    { new Guid("098d679a-6a3d-4f6c-b4ca-7771b3383024"), new Guid("48c92719-ebe7-4b4c-9814-9c8f1a57b1ff"), "Ürün", new Guid("9abf06ab-0c1a-4c63-a141-e512fe306c1e") },
                    { new Guid("1a6f629e-4350-426d-b1ca-9dc7f7cd63eb"), new Guid("41d8d90c-2224-42fb-ac80-c27b87e74371"), "Product", new Guid("9abf06ab-0c1a-4c63-a141-e512fe306c1e") },
                    { new Guid("93cadc92-8d5f-41de-a4ae-58d23e85bbce"), new Guid("48c92719-ebe7-4b4c-9814-9c8f1a57b1ff"), "Ürün", new Guid("da12028f-418a-4bd2-9617-27c4aec8372c") },
                    { new Guid("8daff81b-fcf4-4010-8dcc-1798f0e9b81d"), new Guid("41d8d90c-2224-42fb-ac80-c27b87e74371"), "Product", new Guid("da12028f-418a-4bd2-9617-27c4aec8372c") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_category_UserId",
                table: "category",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_category_translation_CategoryId",
                table: "category_translation",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_category_translation_CultureId",
                table: "category_translation",
                column: "CultureId");

            migrationBuilder.CreateIndex(
                name: "IX_company_Slug",
                table: "company",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_menu_CompanyId",
                table: "menu",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_menu_UserId",
                table: "menu",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_product_CategoryId",
                table: "product",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_product_MenuId",
                table: "product",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_product_group_CategoryId",
                table: "product_group",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_product_group_MenuId",
                table: "product_group",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_product_translation_CultureId",
                table: "product_translation",
                column: "CultureId");

            migrationBuilder.CreateIndex(
                name: "IX_product_translation_ProductGroupId",
                table: "product_translation",
                column: "ProductGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_product_translation_ProductId",
                table: "product_translation",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductProductGroup_ProductId",
                table: "ProductProductGroup",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_refresh_token_UserId",
                table: "refresh_token",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_reset_password_token_UserId",
                table: "reset_password_token",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_role_RoleName",
                table: "role",
                column: "RoleName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_subscription_SubscriptionTypeId",
                table: "subscription",
                column: "SubscriptionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_subscription_UserId",
                table: "subscription",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_subscription_type_feature_SubscriptionTypeId",
                table: "subscription_type_feature",
                column: "SubscriptionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_subscription_type_translation_CultureId",
                table: "subscription_type_translation",
                column: "CultureId");

            migrationBuilder.CreateIndex(
                name: "IX_subscription_type_translation_SubscriptionTypeId",
                table: "subscription_type_translation",
                column: "SubscriptionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_subsctiption_type_feature_translation_CultureId",
                table: "subsctiption_type_feature_translation",
                column: "CultureId");

            migrationBuilder.CreateIndex(
                name: "IX_subsctiption_type_feature_translation_SubscriptionTypeFeatu~",
                table: "subsctiption_type_feature_translation",
                column: "SubscriptionTypeFeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_user_CompanyId",
                table: "user",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_user_EmailAddress",
                table: "user",
                column: "EmailAddress",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_user_RoleId",
                table: "user",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_user_UserName",
                table: "user",
                column: "UserName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "category_translation");

            migrationBuilder.DropTable(
                name: "exhange_type");

            migrationBuilder.DropTable(
                name: "product_translation");

            migrationBuilder.DropTable(
                name: "ProductProductGroup");

            migrationBuilder.DropTable(
                name: "refresh_token");

            migrationBuilder.DropTable(
                name: "reset_password_token");

            migrationBuilder.DropTable(
                name: "subscription");

            migrationBuilder.DropTable(
                name: "subscription_type_translation");

            migrationBuilder.DropTable(
                name: "subsctiption_type_feature_translation");

            migrationBuilder.DropTable(
                name: "product_group");

            migrationBuilder.DropTable(
                name: "product");

            migrationBuilder.DropTable(
                name: "culture");

            migrationBuilder.DropTable(
                name: "subscription_type_feature");

            migrationBuilder.DropTable(
                name: "category");

            migrationBuilder.DropTable(
                name: "menu");

            migrationBuilder.DropTable(
                name: "subscription_type");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "company");

            migrationBuilder.DropTable(
                name: "role");
        }
    }
}
