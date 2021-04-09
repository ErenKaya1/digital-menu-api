using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DigitalMenu.Data.Migrations
{
    public partial class asdasdasdsas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "culture",
                keyColumn: "Id",
                keyValue: new Guid("b44c0b92-f16a-4fb2-a1e8-f9003208ed2a"));

            migrationBuilder.DeleteData(
                table: "culture",
                keyColumn: "Id",
                keyValue: new Guid("f063aae2-a525-4b03-b754-b2de25add788"));

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "Id",
                keyValue: new Guid("94b5d304-f58d-4a24-a4ae-98498f09a1ec"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "Id",
                keyValue: new Guid("d2881d5e-48f8-46bd-9a5f-a67dec55cbda"));

            migrationBuilder.DropColumn(
                name: "QrCodeBackgroundColor",
                table: "menu");

            migrationBuilder.DropColumn(
                name: "QrCodeColor",
                table: "menu");

            migrationBuilder.DropColumn(
                name: "QrCodeMargin",
                table: "menu");

            migrationBuilder.DropColumn(
                name: "QrCodeScale",
                table: "menu");

            migrationBuilder.InsertData(
                table: "culture",
                columns: new[] { "Id", "CultureCode", "IsDefaultCulture" },
                values: new object[,]
                {
                    { new Guid("59e939a9-41c1-4990-bbca-2f4f8826613a"), "tr", true },
                    { new Guid("b09aa585-a95d-4698-a44f-f91e59b5393b"), "en", false }
                });

            migrationBuilder.InsertData(
                table: "role",
                columns: new[] { "Id", "RoleName" },
                values: new object[] { new Guid("d8a8f2f2-5196-4ac5-b5eb-d1ea15b9146f"), "Customer" });

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "Id", "CompanyId", "CreatedAt", "EmailAddress", "FirstName", "LastName", "PasswordHash", "PhoneNumber", "RoleId", "UserName" },
                values: new object[] { new Guid("469b6dbe-ba51-49d8-b32d-736661f3cd15"), null, new DateTime(2021, 4, 8, 23, 58, 38, 967, DateTimeKind.Utc).AddTicks(6145), "test@gmail.com", "admin", "test", "JaXGmn0+qpLRduAniDSq4Jn3PoaW+oh/hQJiNptum+Y=", "123456789", new Guid("b19ebe2e-0dad-4445-896c-b0b2d0a33157"), "admintest" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "culture",
                keyColumn: "Id",
                keyValue: new Guid("59e939a9-41c1-4990-bbca-2f4f8826613a"));

            migrationBuilder.DeleteData(
                table: "culture",
                keyColumn: "Id",
                keyValue: new Guid("b09aa585-a95d-4698-a44f-f91e59b5393b"));

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "Id",
                keyValue: new Guid("d8a8f2f2-5196-4ac5-b5eb-d1ea15b9146f"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "Id",
                keyValue: new Guid("469b6dbe-ba51-49d8-b32d-736661f3cd15"));

            migrationBuilder.AddColumn<string>(
                name: "QrCodeBackgroundColor",
                table: "menu",
                type: "character varying(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "QrCodeColor",
                table: "menu",
                type: "character varying(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "QrCodeMargin",
                table: "menu",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "QrCodeScale",
                table: "menu",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "culture",
                columns: new[] { "Id", "CultureCode", "IsDefaultCulture" },
                values: new object[,]
                {
                    { new Guid("f063aae2-a525-4b03-b754-b2de25add788"), "tr", true },
                    { new Guid("b44c0b92-f16a-4fb2-a1e8-f9003208ed2a"), "en", false }
                });

            migrationBuilder.InsertData(
                table: "role",
                columns: new[] { "Id", "RoleName" },
                values: new object[] { new Guid("94b5d304-f58d-4a24-a4ae-98498f09a1ec"), "Customer" });

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "Id", "CompanyId", "CreatedAt", "EmailAddress", "FirstName", "LastName", "PasswordHash", "PhoneNumber", "RoleId", "UserName" },
                values: new object[] { new Guid("d2881d5e-48f8-46bd-9a5f-a67dec55cbda"), null, new DateTime(2021, 4, 8, 23, 40, 57, 333, DateTimeKind.Utc).AddTicks(4222), "test@gmail.com", "admin", "test", "JaXGmn0+qpLRduAniDSq4Jn3PoaW+oh/hQJiNptum+Y=", "123456789", new Guid("b19ebe2e-0dad-4445-896c-b0b2d0a33157"), "admintest" });
        }
    }
}
