using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DigitalMenu.Data.Migrations
{
    public partial class initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "Id",
                keyValue: new Guid("39c3ebd6-afbc-4493-bcc6-79e01574b79a"));

            migrationBuilder.DeleteData(
                table: "subscription_type_translation",
                keyColumn: "Id",
                keyValue: new Guid("387917e2-c4c5-46c6-96f8-7bad9d91c071"));

            migrationBuilder.DeleteData(
                table: "subscription_type_translation",
                keyColumn: "Id",
                keyValue: new Guid("58927704-6745-41ea-a931-e509855561f6"));

            migrationBuilder.DeleteData(
                table: "subscription_type_translation",
                keyColumn: "Id",
                keyValue: new Guid("90b0eb4d-2642-4d84-9837-9e11829b111e"));

            migrationBuilder.DeleteData(
                table: "subscription_type_translation",
                keyColumn: "Id",
                keyValue: new Guid("9ce18c56-b2f7-42dd-b729-6b6abdc4839a"));

            migrationBuilder.DeleteData(
                table: "subscription_type_translation",
                keyColumn: "Id",
                keyValue: new Guid("c18c9f59-86ef-454c-baa8-0e4bf470b03c"));

            migrationBuilder.DeleteData(
                table: "subscription_type_translation",
                keyColumn: "Id",
                keyValue: new Guid("f7c0fe8b-8b14-43df-95db-fe572dff1538"));

            migrationBuilder.DeleteData(
                table: "subsctiption_type_feature_translation",
                keyColumn: "Id",
                keyValue: new Guid("11b0143d-9263-4705-bd38-b1b0c09be803"));

            migrationBuilder.DeleteData(
                table: "subsctiption_type_feature_translation",
                keyColumn: "Id",
                keyValue: new Guid("21f10fca-9de5-45d5-8bf9-51bf8f95034f"));

            migrationBuilder.DeleteData(
                table: "subsctiption_type_feature_translation",
                keyColumn: "Id",
                keyValue: new Guid("568e759e-3644-4aa9-89f1-e7d08107e116"));

            migrationBuilder.DeleteData(
                table: "subsctiption_type_feature_translation",
                keyColumn: "Id",
                keyValue: new Guid("987d4e27-cf6f-41e9-8650-aa7b1a186af3"));

            migrationBuilder.DeleteData(
                table: "subsctiption_type_feature_translation",
                keyColumn: "Id",
                keyValue: new Guid("9bc9c832-600b-4e04-a845-4173743a1cee"));

            migrationBuilder.DeleteData(
                table: "subsctiption_type_feature_translation",
                keyColumn: "Id",
                keyValue: new Guid("b977af20-96e8-43c3-8dd1-6e8b16f8f5be"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "Id",
                keyValue: new Guid("bbb1adb6-36a2-4d80-bad9-8ca3da2a1aab"));

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "user",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.InsertData(
                table: "role",
                columns: new[] { "Id", "RoleName" },
                values: new object[] { new Guid("e4696a92-5cbd-4df2-b2ca-f1c2de65df6e"), "Customer" });

            migrationBuilder.InsertData(
                table: "subscription_type_translation",
                columns: new[] { "Id", "CultureId", "SubscriptionTypeId", "Title" },
                values: new object[,]
                {
                    { new Guid("a414c83e-c482-4bf0-b48d-b5a6f9825775"), new Guid("48c92719-ebe7-4b4c-9814-9c8f1a57b1ff"), new Guid("638885d5-6b38-4c01-903a-449c676b86f5"), "Giriş" },
                    { new Guid("5224f4d6-2d64-4f59-91f4-e49c307b3ea4"), new Guid("41d8d90c-2224-42fb-ac80-c27b87e74371"), new Guid("638885d5-6b38-4c01-903a-449c676b86f5"), "Starter" },
                    { new Guid("e203e68e-1ea9-4557-a83c-1719ea2ecc31"), new Guid("48c92719-ebe7-4b4c-9814-9c8f1a57b1ff"), new Guid("971daed0-4c56-4e5b-b9a9-74eb975c54eb"), "Ekonomik" },
                    { new Guid("f2130c94-1508-4906-b6ab-e12bf309f1ea"), new Guid("41d8d90c-2224-42fb-ac80-c27b87e74371"), new Guid("971daed0-4c56-4e5b-b9a9-74eb975c54eb"), "Economic" },
                    { new Guid("106a7d69-21fe-4359-995e-90a54363dffe"), new Guid("48c92719-ebe7-4b4c-9814-9c8f1a57b1ff"), new Guid("e0f8c62e-9769-4520-a46b-2d23f6abe7e3"), "Premium" },
                    { new Guid("30c3b052-c835-4086-8eec-8d33cbe2e78b"), new Guid("41d8d90c-2224-42fb-ac80-c27b87e74371"), new Guid("e0f8c62e-9769-4520-a46b-2d23f6abe7e3"), "Premium" }
                });

            migrationBuilder.InsertData(
                table: "subsctiption_type_feature_translation",
                columns: new[] { "Id", "CultureId", "Name", "SubscriptionTypeFeatureId" },
                values: new object[,]
                {
                    { new Guid("6395bb1a-235f-4685-84cd-374f3a814f0b"), new Guid("48c92719-ebe7-4b4c-9814-9c8f1a57b1ff"), "Ürün", new Guid("41cdda69-aa5f-496f-8c1a-3f26d1a32dae") },
                    { new Guid("04d75416-aeae-424d-a087-09a7b637b218"), new Guid("41d8d90c-2224-42fb-ac80-c27b87e74371"), "Product", new Guid("41cdda69-aa5f-496f-8c1a-3f26d1a32dae") },
                    { new Guid("bd1c2e15-1329-42b5-80df-52c717405aa5"), new Guid("48c92719-ebe7-4b4c-9814-9c8f1a57b1ff"), "Ürün", new Guid("9abf06ab-0c1a-4c63-a141-e512fe306c1e") },
                    { new Guid("f2082061-8bf0-4f7d-82ec-fb7110431b21"), new Guid("41d8d90c-2224-42fb-ac80-c27b87e74371"), "Product", new Guid("9abf06ab-0c1a-4c63-a141-e512fe306c1e") },
                    { new Guid("f4593287-10fb-4300-acdc-bd31af8c8867"), new Guid("48c92719-ebe7-4b4c-9814-9c8f1a57b1ff"), "Ürün", new Guid("da12028f-418a-4bd2-9617-27c4aec8372c") },
                    { new Guid("e42e7f00-e873-4166-9980-322a69765ccf"), new Guid("41d8d90c-2224-42fb-ac80-c27b87e74371"), "Product", new Guid("da12028f-418a-4bd2-9617-27c4aec8372c") }
                });

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "Id", "CompanyId", "CreatedAt", "EmailAddress", "FirstName", "LastName", "PasswordHash", "PhoneNumber", "RoleId", "UserName" },
                values: new object[] { new Guid("8ebf2266-0d4d-478d-a381-8f13f86792ac"), null, new DateTime(2021, 4, 10, 12, 1, 21, 362, DateTimeKind.Utc).AddTicks(9639), "test@gmail.com", "admin", "test", "JaXGmn0+qpLRduAniDSq4Jn3PoaW+oh/hQJiNptum+Y=", "123456789", new Guid("b19ebe2e-0dad-4445-896c-b0b2d0a33157"), "admintest" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "Id",
                keyValue: new Guid("e4696a92-5cbd-4df2-b2ca-f1c2de65df6e"));

            migrationBuilder.DeleteData(
                table: "subscription_type_translation",
                keyColumn: "Id",
                keyValue: new Guid("106a7d69-21fe-4359-995e-90a54363dffe"));

            migrationBuilder.DeleteData(
                table: "subscription_type_translation",
                keyColumn: "Id",
                keyValue: new Guid("30c3b052-c835-4086-8eec-8d33cbe2e78b"));

            migrationBuilder.DeleteData(
                table: "subscription_type_translation",
                keyColumn: "Id",
                keyValue: new Guid("5224f4d6-2d64-4f59-91f4-e49c307b3ea4"));

            migrationBuilder.DeleteData(
                table: "subscription_type_translation",
                keyColumn: "Id",
                keyValue: new Guid("a414c83e-c482-4bf0-b48d-b5a6f9825775"));

            migrationBuilder.DeleteData(
                table: "subscription_type_translation",
                keyColumn: "Id",
                keyValue: new Guid("e203e68e-1ea9-4557-a83c-1719ea2ecc31"));

            migrationBuilder.DeleteData(
                table: "subscription_type_translation",
                keyColumn: "Id",
                keyValue: new Guid("f2130c94-1508-4906-b6ab-e12bf309f1ea"));

            migrationBuilder.DeleteData(
                table: "subsctiption_type_feature_translation",
                keyColumn: "Id",
                keyValue: new Guid("04d75416-aeae-424d-a087-09a7b637b218"));

            migrationBuilder.DeleteData(
                table: "subsctiption_type_feature_translation",
                keyColumn: "Id",
                keyValue: new Guid("6395bb1a-235f-4685-84cd-374f3a814f0b"));

            migrationBuilder.DeleteData(
                table: "subsctiption_type_feature_translation",
                keyColumn: "Id",
                keyValue: new Guid("bd1c2e15-1329-42b5-80df-52c717405aa5"));

            migrationBuilder.DeleteData(
                table: "subsctiption_type_feature_translation",
                keyColumn: "Id",
                keyValue: new Guid("e42e7f00-e873-4166-9980-322a69765ccf"));

            migrationBuilder.DeleteData(
                table: "subsctiption_type_feature_translation",
                keyColumn: "Id",
                keyValue: new Guid("f2082061-8bf0-4f7d-82ec-fb7110431b21"));

            migrationBuilder.DeleteData(
                table: "subsctiption_type_feature_translation",
                keyColumn: "Id",
                keyValue: new Guid("f4593287-10fb-4300-acdc-bd31af8c8867"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "Id",
                keyValue: new Guid("8ebf2266-0d4d-478d-a381-8f13f86792ac"));

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "user",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "role",
                columns: new[] { "Id", "RoleName" },
                values: new object[] { new Guid("39c3ebd6-afbc-4493-bcc6-79e01574b79a"), "Customer" });

            migrationBuilder.InsertData(
                table: "subscription_type_translation",
                columns: new[] { "Id", "CultureId", "SubscriptionTypeId", "Title" },
                values: new object[,]
                {
                    { new Guid("387917e2-c4c5-46c6-96f8-7bad9d91c071"), new Guid("48c92719-ebe7-4b4c-9814-9c8f1a57b1ff"), new Guid("638885d5-6b38-4c01-903a-449c676b86f5"), "Giriş" },
                    { new Guid("c18c9f59-86ef-454c-baa8-0e4bf470b03c"), new Guid("41d8d90c-2224-42fb-ac80-c27b87e74371"), new Guid("638885d5-6b38-4c01-903a-449c676b86f5"), "Starter" },
                    { new Guid("f7c0fe8b-8b14-43df-95db-fe572dff1538"), new Guid("48c92719-ebe7-4b4c-9814-9c8f1a57b1ff"), new Guid("971daed0-4c56-4e5b-b9a9-74eb975c54eb"), "Ekonomik" },
                    { new Guid("58927704-6745-41ea-a931-e509855561f6"), new Guid("41d8d90c-2224-42fb-ac80-c27b87e74371"), new Guid("971daed0-4c56-4e5b-b9a9-74eb975c54eb"), "Economic" },
                    { new Guid("90b0eb4d-2642-4d84-9837-9e11829b111e"), new Guid("48c92719-ebe7-4b4c-9814-9c8f1a57b1ff"), new Guid("e0f8c62e-9769-4520-a46b-2d23f6abe7e3"), "Premium" },
                    { new Guid("9ce18c56-b2f7-42dd-b729-6b6abdc4839a"), new Guid("41d8d90c-2224-42fb-ac80-c27b87e74371"), new Guid("e0f8c62e-9769-4520-a46b-2d23f6abe7e3"), "Premium" }
                });

            migrationBuilder.InsertData(
                table: "subsctiption_type_feature_translation",
                columns: new[] { "Id", "CultureId", "Name", "SubscriptionTypeFeatureId" },
                values: new object[,]
                {
                    { new Guid("568e759e-3644-4aa9-89f1-e7d08107e116"), new Guid("48c92719-ebe7-4b4c-9814-9c8f1a57b1ff"), "Ürün", new Guid("41cdda69-aa5f-496f-8c1a-3f26d1a32dae") },
                    { new Guid("b977af20-96e8-43c3-8dd1-6e8b16f8f5be"), new Guid("41d8d90c-2224-42fb-ac80-c27b87e74371"), "Product", new Guid("41cdda69-aa5f-496f-8c1a-3f26d1a32dae") },
                    { new Guid("9bc9c832-600b-4e04-a845-4173743a1cee"), new Guid("48c92719-ebe7-4b4c-9814-9c8f1a57b1ff"), "Ürün", new Guid("9abf06ab-0c1a-4c63-a141-e512fe306c1e") },
                    { new Guid("987d4e27-cf6f-41e9-8650-aa7b1a186af3"), new Guid("41d8d90c-2224-42fb-ac80-c27b87e74371"), "Product", new Guid("9abf06ab-0c1a-4c63-a141-e512fe306c1e") },
                    { new Guid("11b0143d-9263-4705-bd38-b1b0c09be803"), new Guid("48c92719-ebe7-4b4c-9814-9c8f1a57b1ff"), "Ürün", new Guid("da12028f-418a-4bd2-9617-27c4aec8372c") },
                    { new Guid("21f10fca-9de5-45d5-8bf9-51bf8f95034f"), new Guid("41d8d90c-2224-42fb-ac80-c27b87e74371"), "Product", new Guid("da12028f-418a-4bd2-9617-27c4aec8372c") }
                });

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "Id", "CompanyId", "CreatedAt", "EmailAddress", "FirstName", "LastName", "PasswordHash", "PhoneNumber", "RoleId", "UserName" },
                values: new object[] { new Guid("bbb1adb6-36a2-4d80-bad9-8ca3da2a1aab"), null, new DateTime(2021, 4, 9, 14, 9, 14, 179, DateTimeKind.Utc).AddTicks(972), "test@gmail.com", "admin", "test", "JaXGmn0+qpLRduAniDSq4Jn3PoaW+oh/hQJiNptum+Y=", "123456789", new Guid("b19ebe2e-0dad-4445-896c-b0b2d0a33157"), "admintest" });
        }
    }
}
