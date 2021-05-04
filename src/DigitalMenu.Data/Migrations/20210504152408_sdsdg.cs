using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DigitalMenu.Data.Migrations
{
    public partial class sdsdg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "Id",
                keyValue: new Guid("aefa287f-f61a-453c-abf4-8b84319f6e06"));

            migrationBuilder.DeleteData(
                table: "subscription_type_translation",
                keyColumn: "Id",
                keyValue: new Guid("005dee2d-4f4e-4f30-8ccd-2f79bce9dd83"));

            migrationBuilder.DeleteData(
                table: "subscription_type_translation",
                keyColumn: "Id",
                keyValue: new Guid("04c7685e-3fa5-4f90-8bc3-4e0a36d33126"));

            migrationBuilder.DeleteData(
                table: "subscription_type_translation",
                keyColumn: "Id",
                keyValue: new Guid("3ca39573-6c3a-4dfd-afff-04b91c2e6ccb"));

            migrationBuilder.DeleteData(
                table: "subscription_type_translation",
                keyColumn: "Id",
                keyValue: new Guid("3ec2fd89-dc47-43af-8d89-ed27c1b9e035"));

            migrationBuilder.DeleteData(
                table: "subscription_type_translation",
                keyColumn: "Id",
                keyValue: new Guid("529ff91f-d6df-4d17-a669-296c1f4aca0a"));

            migrationBuilder.DeleteData(
                table: "subscription_type_translation",
                keyColumn: "Id",
                keyValue: new Guid("b4d0c39a-684a-4c66-bf21-17d2b788d660"));

            migrationBuilder.DeleteData(
                table: "subsctiption_type_feature_translation",
                keyColumn: "Id",
                keyValue: new Guid("05c15194-b3a3-42b9-ab0a-1ce48000280c"));

            migrationBuilder.DeleteData(
                table: "subsctiption_type_feature_translation",
                keyColumn: "Id",
                keyValue: new Guid("5c024a8c-046f-4820-b6ac-02a7c9442c6e"));

            migrationBuilder.DeleteData(
                table: "subsctiption_type_feature_translation",
                keyColumn: "Id",
                keyValue: new Guid("5d2c3137-60a5-48e6-91f9-63f94efa41c0"));

            migrationBuilder.DeleteData(
                table: "subsctiption_type_feature_translation",
                keyColumn: "Id",
                keyValue: new Guid("64ed4136-7ae9-45ee-8a72-0eda6d762294"));

            migrationBuilder.DeleteData(
                table: "subsctiption_type_feature_translation",
                keyColumn: "Id",
                keyValue: new Guid("9c7921c7-bbf2-4022-9739-ea836e750a2b"));

            migrationBuilder.DeleteData(
                table: "subsctiption_type_feature_translation",
                keyColumn: "Id",
                keyValue: new Guid("ba8ef476-6065-4004-9ec4-26fe63b4b3ae"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "Id",
                keyValue: new Guid("76a932fc-91ee-4f54-b453-bea0e9ea8840"));

            migrationBuilder.AddColumn<string>(
                name: "BackgroundColor",
                table: "menu",
                type: "character varying(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LanguageCurrencyBackgroundColor",
                table: "menu",
                type: "character varying(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LanguageCurrencyTextColor",
                table: "menu",
                type: "character varying(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LinkColor",
                table: "menu",
                type: "character varying(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PriceColor",
                table: "menu",
                type: "character varying(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProductBackgroundColor",
                table: "menu",
                type: "character varying(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SelectedCategoryBorderColor",
                table: "menu",
                type: "character varying(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TextColor",
                table: "menu",
                type: "character varying(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "role",
                columns: new[] { "Id", "RoleName" },
                values: new object[] { new Guid("ed83d501-1388-4791-accf-e85c4e72f92a"), "Customer" });

            migrationBuilder.InsertData(
                table: "subscription_type_translation",
                columns: new[] { "Id", "CultureId", "SubscriptionTypeId", "Title" },
                values: new object[,]
                {
                    { new Guid("db9ab098-95a1-4fa2-8fae-27b3f4b8a506"), new Guid("48c92719-ebe7-4b4c-9814-9c8f1a57b1ff"), new Guid("638885d5-6b38-4c01-903a-449c676b86f5"), "Giriş" },
                    { new Guid("89629076-5dd4-484b-9073-85a9d77cb6bc"), new Guid("41d8d90c-2224-42fb-ac80-c27b87e74371"), new Guid("638885d5-6b38-4c01-903a-449c676b86f5"), "Starter" },
                    { new Guid("8fb51520-118c-4de2-89a0-dac4f6148bd0"), new Guid("48c92719-ebe7-4b4c-9814-9c8f1a57b1ff"), new Guid("971daed0-4c56-4e5b-b9a9-74eb975c54eb"), "Ekonomik" },
                    { new Guid("d67d8fc9-ab56-482e-9149-294aacc08ab2"), new Guid("41d8d90c-2224-42fb-ac80-c27b87e74371"), new Guid("971daed0-4c56-4e5b-b9a9-74eb975c54eb"), "Economic" },
                    { new Guid("ea705c90-fbb2-40c0-a4f0-5517901247eb"), new Guid("48c92719-ebe7-4b4c-9814-9c8f1a57b1ff"), new Guid("e0f8c62e-9769-4520-a46b-2d23f6abe7e3"), "Premium" },
                    { new Guid("bef12744-063e-4e7d-b628-bfa72d097e63"), new Guid("41d8d90c-2224-42fb-ac80-c27b87e74371"), new Guid("e0f8c62e-9769-4520-a46b-2d23f6abe7e3"), "Premium" }
                });

            migrationBuilder.InsertData(
                table: "subsctiption_type_feature_translation",
                columns: new[] { "Id", "CultureId", "Name", "SubscriptionTypeFeatureId" },
                values: new object[,]
                {
                    { new Guid("b80b9c33-4694-4ba8-9af3-1b1bb34b8254"), new Guid("48c92719-ebe7-4b4c-9814-9c8f1a57b1ff"), "Ürün", new Guid("41cdda69-aa5f-496f-8c1a-3f26d1a32dae") },
                    { new Guid("4a159c0d-b210-451f-b0da-83a29762125d"), new Guid("41d8d90c-2224-42fb-ac80-c27b87e74371"), "Product", new Guid("41cdda69-aa5f-496f-8c1a-3f26d1a32dae") },
                    { new Guid("15f71ec6-6693-4db0-8add-8141e619db88"), new Guid("48c92719-ebe7-4b4c-9814-9c8f1a57b1ff"), "Ürün", new Guid("9abf06ab-0c1a-4c63-a141-e512fe306c1e") },
                    { new Guid("4f5594ac-98aa-4750-a161-a903491ef7f5"), new Guid("41d8d90c-2224-42fb-ac80-c27b87e74371"), "Product", new Guid("9abf06ab-0c1a-4c63-a141-e512fe306c1e") },
                    { new Guid("e0e50744-d44b-43f8-af83-29ef58d1c290"), new Guid("48c92719-ebe7-4b4c-9814-9c8f1a57b1ff"), "Ürün", new Guid("da12028f-418a-4bd2-9617-27c4aec8372c") },
                    { new Guid("61f974ab-137a-4186-a7b7-8785972c26fd"), new Guid("41d8d90c-2224-42fb-ac80-c27b87e74371"), "Product", new Guid("da12028f-418a-4bd2-9617-27c4aec8372c") }
                });

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "Id", "CompanyId", "CreatedAt", "EmailAddress", "FirstName", "LastName", "PasswordHash", "PhoneNumber", "RoleId", "UserName" },
                values: new object[] { new Guid("2937ce0c-74b3-4627-bc20-51bef19427b1"), null, new DateTime(2021, 5, 4, 15, 24, 8, 499, DateTimeKind.Utc).AddTicks(676), "test@gmail.com", "admin", "test", "JaXGmn0+qpLRduAniDSq4Jn3PoaW+oh/hQJiNptum+Y=", "123456789", new Guid("b19ebe2e-0dad-4445-896c-b0b2d0a33157"), "admintest" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "Id",
                keyValue: new Guid("ed83d501-1388-4791-accf-e85c4e72f92a"));

            migrationBuilder.DeleteData(
                table: "subscription_type_translation",
                keyColumn: "Id",
                keyValue: new Guid("89629076-5dd4-484b-9073-85a9d77cb6bc"));

            migrationBuilder.DeleteData(
                table: "subscription_type_translation",
                keyColumn: "Id",
                keyValue: new Guid("8fb51520-118c-4de2-89a0-dac4f6148bd0"));

            migrationBuilder.DeleteData(
                table: "subscription_type_translation",
                keyColumn: "Id",
                keyValue: new Guid("bef12744-063e-4e7d-b628-bfa72d097e63"));

            migrationBuilder.DeleteData(
                table: "subscription_type_translation",
                keyColumn: "Id",
                keyValue: new Guid("d67d8fc9-ab56-482e-9149-294aacc08ab2"));

            migrationBuilder.DeleteData(
                table: "subscription_type_translation",
                keyColumn: "Id",
                keyValue: new Guid("db9ab098-95a1-4fa2-8fae-27b3f4b8a506"));

            migrationBuilder.DeleteData(
                table: "subscription_type_translation",
                keyColumn: "Id",
                keyValue: new Guid("ea705c90-fbb2-40c0-a4f0-5517901247eb"));

            migrationBuilder.DeleteData(
                table: "subsctiption_type_feature_translation",
                keyColumn: "Id",
                keyValue: new Guid("15f71ec6-6693-4db0-8add-8141e619db88"));

            migrationBuilder.DeleteData(
                table: "subsctiption_type_feature_translation",
                keyColumn: "Id",
                keyValue: new Guid("4a159c0d-b210-451f-b0da-83a29762125d"));

            migrationBuilder.DeleteData(
                table: "subsctiption_type_feature_translation",
                keyColumn: "Id",
                keyValue: new Guid("4f5594ac-98aa-4750-a161-a903491ef7f5"));

            migrationBuilder.DeleteData(
                table: "subsctiption_type_feature_translation",
                keyColumn: "Id",
                keyValue: new Guid("61f974ab-137a-4186-a7b7-8785972c26fd"));

            migrationBuilder.DeleteData(
                table: "subsctiption_type_feature_translation",
                keyColumn: "Id",
                keyValue: new Guid("b80b9c33-4694-4ba8-9af3-1b1bb34b8254"));

            migrationBuilder.DeleteData(
                table: "subsctiption_type_feature_translation",
                keyColumn: "Id",
                keyValue: new Guid("e0e50744-d44b-43f8-af83-29ef58d1c290"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "Id",
                keyValue: new Guid("2937ce0c-74b3-4627-bc20-51bef19427b1"));

            migrationBuilder.DropColumn(
                name: "BackgroundColor",
                table: "menu");

            migrationBuilder.DropColumn(
                name: "LanguageCurrencyBackgroundColor",
                table: "menu");

            migrationBuilder.DropColumn(
                name: "LanguageCurrencyTextColor",
                table: "menu");

            migrationBuilder.DropColumn(
                name: "LinkColor",
                table: "menu");

            migrationBuilder.DropColumn(
                name: "PriceColor",
                table: "menu");

            migrationBuilder.DropColumn(
                name: "ProductBackgroundColor",
                table: "menu");

            migrationBuilder.DropColumn(
                name: "SelectedCategoryBorderColor",
                table: "menu");

            migrationBuilder.DropColumn(
                name: "TextColor",
                table: "menu");

            migrationBuilder.InsertData(
                table: "role",
                columns: new[] { "Id", "RoleName" },
                values: new object[] { new Guid("aefa287f-f61a-453c-abf4-8b84319f6e06"), "Customer" });

            migrationBuilder.InsertData(
                table: "subscription_type_translation",
                columns: new[] { "Id", "CultureId", "SubscriptionTypeId", "Title" },
                values: new object[,]
                {
                    { new Guid("005dee2d-4f4e-4f30-8ccd-2f79bce9dd83"), new Guid("48c92719-ebe7-4b4c-9814-9c8f1a57b1ff"), new Guid("638885d5-6b38-4c01-903a-449c676b86f5"), "Giriş" },
                    { new Guid("b4d0c39a-684a-4c66-bf21-17d2b788d660"), new Guid("41d8d90c-2224-42fb-ac80-c27b87e74371"), new Guid("638885d5-6b38-4c01-903a-449c676b86f5"), "Starter" },
                    { new Guid("04c7685e-3fa5-4f90-8bc3-4e0a36d33126"), new Guid("48c92719-ebe7-4b4c-9814-9c8f1a57b1ff"), new Guid("971daed0-4c56-4e5b-b9a9-74eb975c54eb"), "Ekonomik" },
                    { new Guid("3ec2fd89-dc47-43af-8d89-ed27c1b9e035"), new Guid("41d8d90c-2224-42fb-ac80-c27b87e74371"), new Guid("971daed0-4c56-4e5b-b9a9-74eb975c54eb"), "Economic" },
                    { new Guid("3ca39573-6c3a-4dfd-afff-04b91c2e6ccb"), new Guid("48c92719-ebe7-4b4c-9814-9c8f1a57b1ff"), new Guid("e0f8c62e-9769-4520-a46b-2d23f6abe7e3"), "Premium" },
                    { new Guid("529ff91f-d6df-4d17-a669-296c1f4aca0a"), new Guid("41d8d90c-2224-42fb-ac80-c27b87e74371"), new Guid("e0f8c62e-9769-4520-a46b-2d23f6abe7e3"), "Premium" }
                });

            migrationBuilder.InsertData(
                table: "subsctiption_type_feature_translation",
                columns: new[] { "Id", "CultureId", "Name", "SubscriptionTypeFeatureId" },
                values: new object[,]
                {
                    { new Guid("64ed4136-7ae9-45ee-8a72-0eda6d762294"), new Guid("48c92719-ebe7-4b4c-9814-9c8f1a57b1ff"), "Ürün", new Guid("41cdda69-aa5f-496f-8c1a-3f26d1a32dae") },
                    { new Guid("5d2c3137-60a5-48e6-91f9-63f94efa41c0"), new Guid("41d8d90c-2224-42fb-ac80-c27b87e74371"), "Product", new Guid("41cdda69-aa5f-496f-8c1a-3f26d1a32dae") },
                    { new Guid("ba8ef476-6065-4004-9ec4-26fe63b4b3ae"), new Guid("48c92719-ebe7-4b4c-9814-9c8f1a57b1ff"), "Ürün", new Guid("9abf06ab-0c1a-4c63-a141-e512fe306c1e") },
                    { new Guid("5c024a8c-046f-4820-b6ac-02a7c9442c6e"), new Guid("41d8d90c-2224-42fb-ac80-c27b87e74371"), "Product", new Guid("9abf06ab-0c1a-4c63-a141-e512fe306c1e") },
                    { new Guid("05c15194-b3a3-42b9-ab0a-1ce48000280c"), new Guid("48c92719-ebe7-4b4c-9814-9c8f1a57b1ff"), "Ürün", new Guid("da12028f-418a-4bd2-9617-27c4aec8372c") },
                    { new Guid("9c7921c7-bbf2-4022-9739-ea836e750a2b"), new Guid("41d8d90c-2224-42fb-ac80-c27b87e74371"), "Product", new Guid("da12028f-418a-4bd2-9617-27c4aec8372c") }
                });

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "Id", "CompanyId", "CreatedAt", "EmailAddress", "FirstName", "LastName", "PasswordHash", "PhoneNumber", "RoleId", "UserName" },
                values: new object[] { new Guid("76a932fc-91ee-4f54-b453-bea0e9ea8840"), null, new DateTime(2021, 5, 4, 3, 53, 57, 438, DateTimeKind.Utc).AddTicks(8939), "test@gmail.com", "admin", "test", "JaXGmn0+qpLRduAniDSq4Jn3PoaW+oh/hQJiNptum+Y=", "123456789", new Guid("b19ebe2e-0dad-4445-896c-b0b2d0a33157"), "admintest" });
        }
    }
}
