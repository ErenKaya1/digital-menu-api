using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DigitalMenu.Data.Migrations
{
    public partial class AddedCompanyImageNameColumnToUserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "culture",
                keyColumn: "Id",
                keyValue: new Guid("27fcd866-64b3-4301-9d5c-06a30bbd566a"));

            migrationBuilder.DeleteData(
                table: "culture",
                keyColumn: "Id",
                keyValue: new Guid("55ac2cc2-4994-4b6d-baf5-e34b3d95c583"));

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "Id",
                keyValue: new Guid("6e482a26-1f54-46da-bffa-aef67c44b4d5"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "Id",
                keyValue: new Guid("20fc6a89-538e-4d1b-8303-345b72a9ccc2"));

            migrationBuilder.AddColumn<string>(
                name: "CompanyImageName",
                table: "user",
                type: "text",
                nullable: true);

            migrationBuilder.InsertData(
                table: "culture",
                columns: new[] { "Id", "CultureCode", "IsDefaultCulture" },
                values: new object[,]
                {
                    { new Guid("096844c8-3212-4c0f-b03b-30627be365f6"), "tr", true },
                    { new Guid("e4976b11-c24c-4d5c-a9c4-bdf3a04d8117"), "en", false }
                });

            migrationBuilder.InsertData(
                table: "role",
                columns: new[] { "Id", "RoleName" },
                values: new object[] { new Guid("59c5e17e-37f6-44c3-b4d2-e8437915cd22"), "Customer" });

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "Id", "CompanyImageName", "CompanyName", "CompanySlug", "CreatedAt", "EmailAddress", "FirstName", "LastName", "PasswordHash", "PhoneNumber", "RoleId", "UserName" },
                values: new object[] { new Guid("7e301004-18b5-45e0-9b3b-dfdc913fd423"), null, null, null, new DateTime(2021, 4, 1, 23, 58, 22, 887, DateTimeKind.Utc).AddTicks(3887), "test@gmail.com", "admin", "test", "JaXGmn0+qpLRduAniDSq4Jn3PoaW+oh/hQJiNptum+Y=", "123456789", new Guid("b19ebe2e-0dad-4445-896c-b0b2d0a33157"), "admintest" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "culture",
                keyColumn: "Id",
                keyValue: new Guid("096844c8-3212-4c0f-b03b-30627be365f6"));

            migrationBuilder.DeleteData(
                table: "culture",
                keyColumn: "Id",
                keyValue: new Guid("e4976b11-c24c-4d5c-a9c4-bdf3a04d8117"));

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "Id",
                keyValue: new Guid("59c5e17e-37f6-44c3-b4d2-e8437915cd22"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "Id",
                keyValue: new Guid("7e301004-18b5-45e0-9b3b-dfdc913fd423"));

            migrationBuilder.DropColumn(
                name: "CompanyImageName",
                table: "user");

            migrationBuilder.InsertData(
                table: "culture",
                columns: new[] { "Id", "CultureCode", "IsDefaultCulture" },
                values: new object[,]
                {
                    { new Guid("27fcd866-64b3-4301-9d5c-06a30bbd566a"), "tr", true },
                    { new Guid("55ac2cc2-4994-4b6d-baf5-e34b3d95c583"), "en", false }
                });

            migrationBuilder.InsertData(
                table: "role",
                columns: new[] { "Id", "RoleName" },
                values: new object[] { new Guid("6e482a26-1f54-46da-bffa-aef67c44b4d5"), "Customer" });

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "Id", "CompanyName", "CompanySlug", "CreatedAt", "EmailAddress", "FirstName", "LastName", "PasswordHash", "PhoneNumber", "RoleId", "UserName" },
                values: new object[] { new Guid("20fc6a89-538e-4d1b-8303-345b72a9ccc2"), null, null, new DateTime(2021, 4, 1, 13, 49, 21, 163, DateTimeKind.Utc).AddTicks(2077), "test@gmail.com", "admin", "test", "JaXGmn0+qpLRduAniDSq4Jn3PoaW+oh/hQJiNptum+Y=", "123456789", new Guid("b19ebe2e-0dad-4445-896c-b0b2d0a33157"), "admintest" });
        }
    }
}
