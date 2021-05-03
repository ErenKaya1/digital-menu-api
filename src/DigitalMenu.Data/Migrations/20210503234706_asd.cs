using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DigitalMenu.Data.Migrations
{
    public partial class asd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "Id",
                keyValue: new Guid("47c78660-31f0-4158-8ca6-82ec9b904993"));

            migrationBuilder.DeleteData(
                table: "subscription_type_translation",
                keyColumn: "Id",
                keyValue: new Guid("15c40564-2dd8-4be2-a004-b6ad76d6a836"));

            migrationBuilder.DeleteData(
                table: "subscription_type_translation",
                keyColumn: "Id",
                keyValue: new Guid("1b304f3a-0fff-4c55-8da9-f97acc4b678c"));

            migrationBuilder.DeleteData(
                table: "subscription_type_translation",
                keyColumn: "Id",
                keyValue: new Guid("6af4216d-86a8-4ce0-af4e-97f034102995"));

            migrationBuilder.DeleteData(
                table: "subscription_type_translation",
                keyColumn: "Id",
                keyValue: new Guid("bdf250ed-f1a9-44a4-8356-17cd91f66c00"));

            migrationBuilder.DeleteData(
                table: "subscription_type_translation",
                keyColumn: "Id",
                keyValue: new Guid("d9d2be6b-64f4-4ce6-b2f8-4c21fba8f416"));

            migrationBuilder.DeleteData(
                table: "subscription_type_translation",
                keyColumn: "Id",
                keyValue: new Guid("e22270be-ed2e-4feb-b978-ac7527707b72"));

            migrationBuilder.DeleteData(
                table: "subsctiption_type_feature_translation",
                keyColumn: "Id",
                keyValue: new Guid("098d679a-6a3d-4f6c-b4ca-7771b3383024"));

            migrationBuilder.DeleteData(
                table: "subsctiption_type_feature_translation",
                keyColumn: "Id",
                keyValue: new Guid("1a6f629e-4350-426d-b1ca-9dc7f7cd63eb"));

            migrationBuilder.DeleteData(
                table: "subsctiption_type_feature_translation",
                keyColumn: "Id",
                keyValue: new Guid("296b3ff4-6865-4f89-b67b-505f59fd4103"));

            migrationBuilder.DeleteData(
                table: "subsctiption_type_feature_translation",
                keyColumn: "Id",
                keyValue: new Guid("7480ffd2-205a-46c9-b728-e072d2792d36"));

            migrationBuilder.DeleteData(
                table: "subsctiption_type_feature_translation",
                keyColumn: "Id",
                keyValue: new Guid("8daff81b-fcf4-4010-8dcc-1798f0e9b81d"));

            migrationBuilder.DeleteData(
                table: "subsctiption_type_feature_translation",
                keyColumn: "Id",
                keyValue: new Guid("93cadc92-8d5f-41de-a4ae-58d23e85bbce"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "Id",
                keyValue: new Guid("e5ac5f54-5a51-4d94-be70-9e9dfaa81acb"));

            migrationBuilder.CreateTable(
                name: "payment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Amount = table.Column<double>(type: "double precision", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    SubscriptionId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_payment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_payment_subscription_SubscriptionId",
                        column: x => x.SubscriptionId,
                        principalTable: "subscription",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_payment_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "role",
                columns: new[] { "Id", "RoleName" },
                values: new object[] { new Guid("bed4026c-b47a-46ad-9ca8-dd81ac31818e"), "Customer" });

            migrationBuilder.InsertData(
                table: "subscription_type_translation",
                columns: new[] { "Id", "CultureId", "SubscriptionTypeId", "Title" },
                values: new object[,]
                {
                    { new Guid("1fbdab1c-72f4-4870-99bf-652ff38b7fe2"), new Guid("48c92719-ebe7-4b4c-9814-9c8f1a57b1ff"), new Guid("638885d5-6b38-4c01-903a-449c676b86f5"), "Giriş" },
                    { new Guid("95a0fece-639f-415c-9d87-76a078509cbd"), new Guid("41d8d90c-2224-42fb-ac80-c27b87e74371"), new Guid("638885d5-6b38-4c01-903a-449c676b86f5"), "Starter" },
                    { new Guid("55fea7ac-1ea9-4804-b94e-3ae37daa7bf6"), new Guid("48c92719-ebe7-4b4c-9814-9c8f1a57b1ff"), new Guid("971daed0-4c56-4e5b-b9a9-74eb975c54eb"), "Ekonomik" },
                    { new Guid("dbd71bb9-1d9b-4fc0-a5f9-f568f59d0abe"), new Guid("41d8d90c-2224-42fb-ac80-c27b87e74371"), new Guid("971daed0-4c56-4e5b-b9a9-74eb975c54eb"), "Economic" },
                    { new Guid("9d5df9a6-7feb-4177-8afb-ab263de184c0"), new Guid("48c92719-ebe7-4b4c-9814-9c8f1a57b1ff"), new Guid("e0f8c62e-9769-4520-a46b-2d23f6abe7e3"), "Premium" },
                    { new Guid("54aae9c1-8fd5-411b-837a-fe73480cb259"), new Guid("41d8d90c-2224-42fb-ac80-c27b87e74371"), new Guid("e0f8c62e-9769-4520-a46b-2d23f6abe7e3"), "Premium" }
                });

            migrationBuilder.InsertData(
                table: "subsctiption_type_feature_translation",
                columns: new[] { "Id", "CultureId", "Name", "SubscriptionTypeFeatureId" },
                values: new object[,]
                {
                    { new Guid("7f69744a-ae1e-40af-904f-0b9dec031c24"), new Guid("48c92719-ebe7-4b4c-9814-9c8f1a57b1ff"), "Ürün", new Guid("41cdda69-aa5f-496f-8c1a-3f26d1a32dae") },
                    { new Guid("3f90b41d-114f-40a0-845d-23822f6c9b75"), new Guid("41d8d90c-2224-42fb-ac80-c27b87e74371"), "Product", new Guid("41cdda69-aa5f-496f-8c1a-3f26d1a32dae") },
                    { new Guid("5c5b5e53-fadb-4bfb-9219-0f7168b879ca"), new Guid("48c92719-ebe7-4b4c-9814-9c8f1a57b1ff"), "Ürün", new Guid("9abf06ab-0c1a-4c63-a141-e512fe306c1e") },
                    { new Guid("c69c5043-31bb-4c68-ab44-be38bf670093"), new Guid("41d8d90c-2224-42fb-ac80-c27b87e74371"), "Product", new Guid("9abf06ab-0c1a-4c63-a141-e512fe306c1e") },
                    { new Guid("4e40accf-3a1a-41aa-8075-3ab114064e3c"), new Guid("48c92719-ebe7-4b4c-9814-9c8f1a57b1ff"), "Ürün", new Guid("da12028f-418a-4bd2-9617-27c4aec8372c") },
                    { new Guid("ab776587-8bba-40cc-9aef-54d590d870bd"), new Guid("41d8d90c-2224-42fb-ac80-c27b87e74371"), "Product", new Guid("da12028f-418a-4bd2-9617-27c4aec8372c") }
                });

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "Id", "CompanyId", "CreatedAt", "EmailAddress", "FirstName", "LastName", "PasswordHash", "PhoneNumber", "RoleId", "UserName" },
                values: new object[] { new Guid("1b5c1fff-1420-47f6-80ae-59772ccf09ef"), null, new DateTime(2021, 5, 3, 23, 47, 6, 216, DateTimeKind.Utc).AddTicks(3545), "test@gmail.com", "admin", "test", "JaXGmn0+qpLRduAniDSq4Jn3PoaW+oh/hQJiNptum+Y=", "123456789", new Guid("b19ebe2e-0dad-4445-896c-b0b2d0a33157"), "admintest" });

            migrationBuilder.CreateIndex(
                name: "IX_payment_SubscriptionId",
                table: "payment",
                column: "SubscriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_payment_UserId",
                table: "payment",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "payment");

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "Id",
                keyValue: new Guid("bed4026c-b47a-46ad-9ca8-dd81ac31818e"));

            migrationBuilder.DeleteData(
                table: "subscription_type_translation",
                keyColumn: "Id",
                keyValue: new Guid("1fbdab1c-72f4-4870-99bf-652ff38b7fe2"));

            migrationBuilder.DeleteData(
                table: "subscription_type_translation",
                keyColumn: "Id",
                keyValue: new Guid("54aae9c1-8fd5-411b-837a-fe73480cb259"));

            migrationBuilder.DeleteData(
                table: "subscription_type_translation",
                keyColumn: "Id",
                keyValue: new Guid("55fea7ac-1ea9-4804-b94e-3ae37daa7bf6"));

            migrationBuilder.DeleteData(
                table: "subscription_type_translation",
                keyColumn: "Id",
                keyValue: new Guid("95a0fece-639f-415c-9d87-76a078509cbd"));

            migrationBuilder.DeleteData(
                table: "subscription_type_translation",
                keyColumn: "Id",
                keyValue: new Guid("9d5df9a6-7feb-4177-8afb-ab263de184c0"));

            migrationBuilder.DeleteData(
                table: "subscription_type_translation",
                keyColumn: "Id",
                keyValue: new Guid("dbd71bb9-1d9b-4fc0-a5f9-f568f59d0abe"));

            migrationBuilder.DeleteData(
                table: "subsctiption_type_feature_translation",
                keyColumn: "Id",
                keyValue: new Guid("3f90b41d-114f-40a0-845d-23822f6c9b75"));

            migrationBuilder.DeleteData(
                table: "subsctiption_type_feature_translation",
                keyColumn: "Id",
                keyValue: new Guid("4e40accf-3a1a-41aa-8075-3ab114064e3c"));

            migrationBuilder.DeleteData(
                table: "subsctiption_type_feature_translation",
                keyColumn: "Id",
                keyValue: new Guid("5c5b5e53-fadb-4bfb-9219-0f7168b879ca"));

            migrationBuilder.DeleteData(
                table: "subsctiption_type_feature_translation",
                keyColumn: "Id",
                keyValue: new Guid("7f69744a-ae1e-40af-904f-0b9dec031c24"));

            migrationBuilder.DeleteData(
                table: "subsctiption_type_feature_translation",
                keyColumn: "Id",
                keyValue: new Guid("ab776587-8bba-40cc-9aef-54d590d870bd"));

            migrationBuilder.DeleteData(
                table: "subsctiption_type_feature_translation",
                keyColumn: "Id",
                keyValue: new Guid("c69c5043-31bb-4c68-ab44-be38bf670093"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "Id",
                keyValue: new Guid("1b5c1fff-1420-47f6-80ae-59772ccf09ef"));

            migrationBuilder.InsertData(
                table: "role",
                columns: new[] { "Id", "RoleName" },
                values: new object[] { new Guid("47c78660-31f0-4158-8ca6-82ec9b904993"), "Customer" });

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

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "Id", "CompanyId", "CreatedAt", "EmailAddress", "FirstName", "LastName", "PasswordHash", "PhoneNumber", "RoleId", "UserName" },
                values: new object[] { new Guid("e5ac5f54-5a51-4d94-be70-9e9dfaa81acb"), null, new DateTime(2021, 5, 3, 22, 49, 42, 862, DateTimeKind.Utc).AddTicks(2490), "test@gmail.com", "admin", "test", "JaXGmn0+qpLRduAniDSq4Jn3PoaW+oh/hQJiNptum+Y=", "123456789", new Guid("b19ebe2e-0dad-4445-896c-b0b2d0a33157"), "admintest" });
        }
    }
}
