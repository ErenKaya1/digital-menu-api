using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DigitalMenu.Data.Migrations
{
    public partial class asdasdasdsa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "culture",
                keyColumn: "Id",
                keyValue: new Guid("50ea1e81-fe52-4f46-956b-a7bf30104019"));

            migrationBuilder.DeleteData(
                table: "culture",
                keyColumn: "Id",
                keyValue: new Guid("e358cf80-ae22-432f-b4b4-cc6afeb04f6d"));

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "Id",
                keyValue: new Guid("6b32047c-edee-4c10-8caf-cc87167b9b46"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "Id",
                keyValue: new Guid("07936122-7ff1-4cae-9816-e48d14d99155"));

            migrationBuilder.DropColumn(
                name: "QrCode",
                table: "menu");

            migrationBuilder.AlterColumn<string>(
                name: "QrCodeColor",
                table: "menu",
                type: "character varying(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "QrCodeBackgroundColor",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "QrCodeMargin",
                table: "menu");

            migrationBuilder.DropColumn(
                name: "QrCodeScale",
                table: "menu");

            migrationBuilder.AlterColumn<string>(
                name: "QrCodeColor",
                table: "menu",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "QrCode",
                table: "menu",
                type: "text",
                nullable: true);

            migrationBuilder.InsertData(
                table: "culture",
                columns: new[] { "Id", "CultureCode", "IsDefaultCulture" },
                values: new object[,]
                {
                    { new Guid("50ea1e81-fe52-4f46-956b-a7bf30104019"), "tr", true },
                    { new Guid("e358cf80-ae22-432f-b4b4-cc6afeb04f6d"), "en", false }
                });

            migrationBuilder.InsertData(
                table: "role",
                columns: new[] { "Id", "RoleName" },
                values: new object[] { new Guid("6b32047c-edee-4c10-8caf-cc87167b9b46"), "Customer" });

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "Id", "CompanyId", "CreatedAt", "EmailAddress", "FirstName", "LastName", "PasswordHash", "PhoneNumber", "RoleId", "UserName" },
                values: new object[] { new Guid("07936122-7ff1-4cae-9816-e48d14d99155"), null, new DateTime(2021, 4, 7, 17, 39, 41, 640, DateTimeKind.Utc).AddTicks(8108), "test@gmail.com", "admin", "test", "JaXGmn0+qpLRduAniDSq4Jn3PoaW+oh/hQJiNptum+Y=", "123456789", new Guid("b19ebe2e-0dad-4445-896c-b0b2d0a33157"), "admintest" });
        }
    }
}
