using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DigitalMenu.Data.Migrations
{
    public partial class asdasdasdasd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "culture",
                keyColumn: "Id",
                keyValue: new Guid("0f49113d-663f-45ce-bc68-3753a7b95dd4"));

            migrationBuilder.DeleteData(
                table: "culture",
                keyColumn: "Id",
                keyValue: new Guid("dbc05a64-b659-43f3-8eca-63011d5972e3"));

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "Id",
                keyValue: new Guid("b43aba37-1fdc-432f-9372-6ec93df80f08"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "Id",
                keyValue: new Guid("4d83795a-5486-484a-a62f-6395872097f3"));

            migrationBuilder.AddColumn<byte>(
                name: "SubscriptionFeatureName",
                table: "subscription_type_feature",
                type: "smallint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.InsertData(
                table: "culture",
                columns: new[] { "Id", "CultureCode", "IsDefaultCulture" },
                values: new object[,]
                {
                    { new Guid("48736a92-2bd7-4d88-b7a3-24169326fc30"), "tr", true },
                    { new Guid("36548bdf-46ba-4037-8763-822b7e5dce68"), "en", false }
                });

            migrationBuilder.InsertData(
                table: "role",
                columns: new[] { "Id", "RoleName" },
                values: new object[] { new Guid("c0f3539a-6174-4065-85e0-3b1a0d33d6f1"), "Customer" });

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "Id", "CompanyId", "CreatedAt", "EmailAddress", "FirstName", "LastName", "PasswordHash", "PhoneNumber", "RoleId", "UserName" },
                values: new object[] { new Guid("9f1efb1f-8be8-4bc0-a407-7ad3b674feb5"), null, new DateTime(2021, 4, 7, 11, 15, 10, 707, DateTimeKind.Utc).AddTicks(1069), "test@gmail.com", "admin", "test", "JaXGmn0+qpLRduAniDSq4Jn3PoaW+oh/hQJiNptum+Y=", "123456789", new Guid("b19ebe2e-0dad-4445-896c-b0b2d0a33157"), "admintest" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "culture",
                keyColumn: "Id",
                keyValue: new Guid("36548bdf-46ba-4037-8763-822b7e5dce68"));

            migrationBuilder.DeleteData(
                table: "culture",
                keyColumn: "Id",
                keyValue: new Guid("48736a92-2bd7-4d88-b7a3-24169326fc30"));

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "Id",
                keyValue: new Guid("c0f3539a-6174-4065-85e0-3b1a0d33d6f1"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "Id",
                keyValue: new Guid("9f1efb1f-8be8-4bc0-a407-7ad3b674feb5"));

            migrationBuilder.DropColumn(
                name: "SubscriptionFeatureName",
                table: "subscription_type_feature");

            migrationBuilder.InsertData(
                table: "culture",
                columns: new[] { "Id", "CultureCode", "IsDefaultCulture" },
                values: new object[,]
                {
                    { new Guid("0f49113d-663f-45ce-bc68-3753a7b95dd4"), "tr", true },
                    { new Guid("dbc05a64-b659-43f3-8eca-63011d5972e3"), "en", false }
                });

            migrationBuilder.InsertData(
                table: "role",
                columns: new[] { "Id", "RoleName" },
                values: new object[] { new Guid("b43aba37-1fdc-432f-9372-6ec93df80f08"), "Customer" });

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "Id", "CompanyId", "CreatedAt", "EmailAddress", "FirstName", "LastName", "PasswordHash", "PhoneNumber", "RoleId", "UserName" },
                values: new object[] { new Guid("4d83795a-5486-484a-a62f-6395872097f3"), null, new DateTime(2021, 4, 7, 0, 32, 23, 426, DateTimeKind.Utc).AddTicks(909), "test@gmail.com", "admin", "test", "JaXGmn0+qpLRduAniDSq4Jn3PoaW+oh/hQJiNptum+Y=", "123456789", new Guid("b19ebe2e-0dad-4445-896c-b0b2d0a33157"), "admintest" });
        }
    }
}
