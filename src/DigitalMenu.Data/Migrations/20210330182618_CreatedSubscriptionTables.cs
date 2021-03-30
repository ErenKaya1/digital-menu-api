using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DigitalMenu.Data.Migrations
{
    public partial class CreatedSubscriptionTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "culture",
                keyColumn: "Id",
                keyValue: new Guid("1b66763d-4d4e-4855-bc93-368c90a9869b"));

            migrationBuilder.DeleteData(
                table: "culture",
                keyColumn: "Id",
                keyValue: new Guid("ad0f4d2c-1329-401b-937e-cfde41e81c2d"));

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "Id",
                keyValue: new Guid("3338aecf-f375-48f2-9a50-481da91aa062"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "Id",
                keyValue: new Guid("37997b33-45cb-4bea-8d7d-cddf9c906572"));

            migrationBuilder.DropColumn(
                name: "InTrialModel",
                table: "subscription");

            migrationBuilder.AddColumn<Guid>(
                name: "SubscriptionTypeId",
                table: "subscription",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "subscription_type",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Price = table.Column<double>(type: "double precision", nullable: false),
                    InTrialModel = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subscription_type", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "subscription_type_feature",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IsUnlimited = table.Column<bool>(type: "boolean", nullable: false),
                    TotalValue = table.Column<int>(type: "integer", nullable: true),
                    ValueUsed = table.Column<int>(type: "integer", nullable: false),
                    ValueRemained = table.Column<int>(type: "integer", nullable: true),
                    SubscriptionTypeId = table.Column<Guid>(type: "uuid", nullable: false)
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
                    SubscriptionTypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    CultureId = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Culture = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subscription_type_translation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_subscription_type_translation_subscription_type_Subscriptio~",
                        column: x => x.SubscriptionTypeId,
                        principalTable: "subscription_type",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "subscription_type_feature_translation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FeatureName = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    SubscriptionTypeFeatureId = table.Column<Guid>(type: "uuid", nullable: false),
                    CultureId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subscription_type_feature_translation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_subscription_type_feature_translation_culture_CultureId",
                        column: x => x.CultureId,
                        principalTable: "culture",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_subscription_type_feature_translation_subscription_type_fea~",
                        column: x => x.SubscriptionTypeFeatureId,
                        principalTable: "subscription_type_feature",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "culture",
                columns: new[] { "Id", "CultureCode", "IsDefaultCulture" },
                values: new object[,]
                {
                    { new Guid("8d934f36-c20d-4d1d-969f-af4f0b926798"), "tr", true },
                    { new Guid("faa2cfb7-174e-4f0d-8a52-ed98a2587927"), "en", false }
                });

            migrationBuilder.InsertData(
                table: "role",
                columns: new[] { "Id", "RoleName" },
                values: new object[] { new Guid("d8148ada-6f66-4f89-9e32-3f5ee2fec8d6"), "Customer" });

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "Id", "CreatedAt", "EmailAddress", "FirstName", "LastName", "PasswordHash", "PhoneNumber", "RoleId", "UserName" },
                values: new object[] { new Guid("493141b2-a45c-4e63-8769-bf4353dddd53"), new DateTime(2021, 3, 30, 18, 26, 17, 985, DateTimeKind.Utc).AddTicks(4917), "test@gmail.com", "admin", "test", "JaXGmn0+qpLRduAniDSq4Jn3PoaW+oh/hQJiNptum+Y=", "123456789", new Guid("b19ebe2e-0dad-4445-896c-b0b2d0a33157"), "admintest" });

            migrationBuilder.CreateIndex(
                name: "IX_subscription_SubscriptionTypeId",
                table: "subscription",
                column: "SubscriptionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_subscription_type_feature_SubscriptionTypeId",
                table: "subscription_type_feature",
                column: "SubscriptionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_subscription_type_feature_translation_CultureId",
                table: "subscription_type_feature_translation",
                column: "CultureId");

            migrationBuilder.CreateIndex(
                name: "IX_subscription_type_feature_translation_SubscriptionTypeFeatu~",
                table: "subscription_type_feature_translation",
                column: "SubscriptionTypeFeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_subscription_type_translation_SubscriptionTypeId",
                table: "subscription_type_translation",
                column: "SubscriptionTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_subscription_subscription_type_SubscriptionTypeId",
                table: "subscription",
                column: "SubscriptionTypeId",
                principalTable: "subscription_type",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_subscription_subscription_type_SubscriptionTypeId",
                table: "subscription");

            migrationBuilder.DropTable(
                name: "subscription_type_feature_translation");

            migrationBuilder.DropTable(
                name: "subscription_type_translation");

            migrationBuilder.DropTable(
                name: "subscription_type_feature");

            migrationBuilder.DropTable(
                name: "subscription_type");

            migrationBuilder.DropIndex(
                name: "IX_subscription_SubscriptionTypeId",
                table: "subscription");

            migrationBuilder.DeleteData(
                table: "culture",
                keyColumn: "Id",
                keyValue: new Guid("8d934f36-c20d-4d1d-969f-af4f0b926798"));

            migrationBuilder.DeleteData(
                table: "culture",
                keyColumn: "Id",
                keyValue: new Guid("faa2cfb7-174e-4f0d-8a52-ed98a2587927"));

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "Id",
                keyValue: new Guid("d8148ada-6f66-4f89-9e32-3f5ee2fec8d6"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "Id",
                keyValue: new Guid("493141b2-a45c-4e63-8769-bf4353dddd53"));

            migrationBuilder.DropColumn(
                name: "SubscriptionTypeId",
                table: "subscription");

            migrationBuilder.AddColumn<bool>(
                name: "InTrialModel",
                table: "subscription",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "culture",
                columns: new[] { "Id", "CultureCode", "IsDefaultCulture" },
                values: new object[,]
                {
                    { new Guid("ad0f4d2c-1329-401b-937e-cfde41e81c2d"), "tr", true },
                    { new Guid("1b66763d-4d4e-4855-bc93-368c90a9869b"), "en", false }
                });

            migrationBuilder.InsertData(
                table: "role",
                columns: new[] { "Id", "RoleName" },
                values: new object[] { new Guid("3338aecf-f375-48f2-9a50-481da91aa062"), "Customer" });

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "Id", "CreatedAt", "EmailAddress", "FirstName", "LastName", "PasswordHash", "PhoneNumber", "RoleId", "UserName" },
                values: new object[] { new Guid("37997b33-45cb-4bea-8d7d-cddf9c906572"), new DateTime(2021, 3, 30, 18, 9, 30, 836, DateTimeKind.Utc).AddTicks(83), "test@gmail.com", "admin", "test", "JaXGmn0+qpLRduAniDSq4Jn3PoaW+oh/hQJiNptum+Y=", "123456789", new Guid("b19ebe2e-0dad-4445-896c-b0b2d0a33157"), "admintest" });
        }
    }
}
