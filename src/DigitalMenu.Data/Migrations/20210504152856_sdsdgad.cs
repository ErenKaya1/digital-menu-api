using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DigitalMenu.Data.Migrations
{
    public partial class sdsdgad : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "CategoryDescriptionColor",
                table: "menu",
                type: "character varying(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "role",
                columns: new[] { "Id", "RoleName" },
                values: new object[] { new Guid("a26a1363-896a-4290-9072-22ac5763b0ae"), "Customer" });

            migrationBuilder.InsertData(
                table: "subscription_type_translation",
                columns: new[] { "Id", "CultureId", "SubscriptionTypeId", "Title" },
                values: new object[,]
                {
                    { new Guid("6381c6b6-9fc7-4950-b339-047408239408"), new Guid("48c92719-ebe7-4b4c-9814-9c8f1a57b1ff"), new Guid("638885d5-6b38-4c01-903a-449c676b86f5"), "Giriş" },
                    { new Guid("90e4f01d-efef-46d2-a676-052f37c57f41"), new Guid("41d8d90c-2224-42fb-ac80-c27b87e74371"), new Guid("638885d5-6b38-4c01-903a-449c676b86f5"), "Starter" },
                    { new Guid("a111209a-a635-4194-8782-58445ed891f5"), new Guid("48c92719-ebe7-4b4c-9814-9c8f1a57b1ff"), new Guid("971daed0-4c56-4e5b-b9a9-74eb975c54eb"), "Ekonomik" },
                    { new Guid("97707032-660d-45d1-a3ba-4d465040225f"), new Guid("41d8d90c-2224-42fb-ac80-c27b87e74371"), new Guid("971daed0-4c56-4e5b-b9a9-74eb975c54eb"), "Economic" },
                    { new Guid("c8ca276f-929a-473c-bb99-606952845734"), new Guid("48c92719-ebe7-4b4c-9814-9c8f1a57b1ff"), new Guid("e0f8c62e-9769-4520-a46b-2d23f6abe7e3"), "Premium" },
                    { new Guid("7e2fad8b-d1e7-45e9-a3cd-0a9a8bfaba79"), new Guid("41d8d90c-2224-42fb-ac80-c27b87e74371"), new Guid("e0f8c62e-9769-4520-a46b-2d23f6abe7e3"), "Premium" }
                });

            migrationBuilder.InsertData(
                table: "subsctiption_type_feature_translation",
                columns: new[] { "Id", "CultureId", "Name", "SubscriptionTypeFeatureId" },
                values: new object[,]
                {
                    { new Guid("dee68636-512b-49f1-b045-9e7762308f5e"), new Guid("48c92719-ebe7-4b4c-9814-9c8f1a57b1ff"), "Ürün", new Guid("41cdda69-aa5f-496f-8c1a-3f26d1a32dae") },
                    { new Guid("4793248a-948e-43ae-bfa2-f91ca4a37577"), new Guid("41d8d90c-2224-42fb-ac80-c27b87e74371"), "Product", new Guid("41cdda69-aa5f-496f-8c1a-3f26d1a32dae") },
                    { new Guid("d2545f73-ae5e-46b1-b702-f24e05c67141"), new Guid("48c92719-ebe7-4b4c-9814-9c8f1a57b1ff"), "Ürün", new Guid("9abf06ab-0c1a-4c63-a141-e512fe306c1e") },
                    { new Guid("207efa92-a37c-432e-b1f1-fa17686de98a"), new Guid("41d8d90c-2224-42fb-ac80-c27b87e74371"), "Product", new Guid("9abf06ab-0c1a-4c63-a141-e512fe306c1e") },
                    { new Guid("7e73d30f-ee41-46f7-9388-b8f76d3a228a"), new Guid("48c92719-ebe7-4b4c-9814-9c8f1a57b1ff"), "Ürün", new Guid("da12028f-418a-4bd2-9617-27c4aec8372c") },
                    { new Guid("1bd63483-1a27-4ab3-b2e4-a0f0add728ec"), new Guid("41d8d90c-2224-42fb-ac80-c27b87e74371"), "Product", new Guid("da12028f-418a-4bd2-9617-27c4aec8372c") }
                });

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "Id", "CompanyId", "CreatedAt", "EmailAddress", "FirstName", "LastName", "PasswordHash", "PhoneNumber", "RoleId", "UserName" },
                values: new object[] { new Guid("874382e8-2009-406e-ab1e-7ca202f3f00a"), null, new DateTime(2021, 5, 4, 15, 28, 55, 541, DateTimeKind.Utc).AddTicks(1975), "test@gmail.com", "admin", "test", "JaXGmn0+qpLRduAniDSq4Jn3PoaW+oh/hQJiNptum+Y=", "123456789", new Guid("b19ebe2e-0dad-4445-896c-b0b2d0a33157"), "admintest" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "Id",
                keyValue: new Guid("a26a1363-896a-4290-9072-22ac5763b0ae"));

            migrationBuilder.DeleteData(
                table: "subscription_type_translation",
                keyColumn: "Id",
                keyValue: new Guid("6381c6b6-9fc7-4950-b339-047408239408"));

            migrationBuilder.DeleteData(
                table: "subscription_type_translation",
                keyColumn: "Id",
                keyValue: new Guid("7e2fad8b-d1e7-45e9-a3cd-0a9a8bfaba79"));

            migrationBuilder.DeleteData(
                table: "subscription_type_translation",
                keyColumn: "Id",
                keyValue: new Guid("90e4f01d-efef-46d2-a676-052f37c57f41"));

            migrationBuilder.DeleteData(
                table: "subscription_type_translation",
                keyColumn: "Id",
                keyValue: new Guid("97707032-660d-45d1-a3ba-4d465040225f"));

            migrationBuilder.DeleteData(
                table: "subscription_type_translation",
                keyColumn: "Id",
                keyValue: new Guid("a111209a-a635-4194-8782-58445ed891f5"));

            migrationBuilder.DeleteData(
                table: "subscription_type_translation",
                keyColumn: "Id",
                keyValue: new Guid("c8ca276f-929a-473c-bb99-606952845734"));

            migrationBuilder.DeleteData(
                table: "subsctiption_type_feature_translation",
                keyColumn: "Id",
                keyValue: new Guid("1bd63483-1a27-4ab3-b2e4-a0f0add728ec"));

            migrationBuilder.DeleteData(
                table: "subsctiption_type_feature_translation",
                keyColumn: "Id",
                keyValue: new Guid("207efa92-a37c-432e-b1f1-fa17686de98a"));

            migrationBuilder.DeleteData(
                table: "subsctiption_type_feature_translation",
                keyColumn: "Id",
                keyValue: new Guid("4793248a-948e-43ae-bfa2-f91ca4a37577"));

            migrationBuilder.DeleteData(
                table: "subsctiption_type_feature_translation",
                keyColumn: "Id",
                keyValue: new Guid("7e73d30f-ee41-46f7-9388-b8f76d3a228a"));

            migrationBuilder.DeleteData(
                table: "subsctiption_type_feature_translation",
                keyColumn: "Id",
                keyValue: new Guid("d2545f73-ae5e-46b1-b702-f24e05c67141"));

            migrationBuilder.DeleteData(
                table: "subsctiption_type_feature_translation",
                keyColumn: "Id",
                keyValue: new Guid("dee68636-512b-49f1-b045-9e7762308f5e"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "Id",
                keyValue: new Guid("874382e8-2009-406e-ab1e-7ca202f3f00a"));

            migrationBuilder.DropColumn(
                name: "CategoryDescriptionColor",
                table: "menu");

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
    }
}
