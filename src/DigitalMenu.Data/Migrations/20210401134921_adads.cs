using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DigitalMenu.Data.Migrations
{
    public partial class adads : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "culture",
                keyColumn: "Id",
                keyValue: new Guid("51a7d260-021f-4d61-bd27-108961b7f596"));

            migrationBuilder.DeleteData(
                table: "culture",
                keyColumn: "Id",
                keyValue: new Guid("ae5ec309-4efb-47ec-8c20-30dcf91832bc"));

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "Id",
                keyValue: new Guid("2be51e99-953d-4611-a3b6-61d59b378428"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "Id",
                keyValue: new Guid("03ca55dd-cfbb-4720-b9f0-e3f75b6d3502"));

            migrationBuilder.AddColumn<string>(
                name: "CompanyName",
                table: "user",
                type: "character varying(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanySlug",
                table: "user",
                type: "character varying(200)",
                maxLength: 200,
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "CompanyName",
                table: "user");

            migrationBuilder.DropColumn(
                name: "CompanySlug",
                table: "user");

            migrationBuilder.InsertData(
                table: "culture",
                columns: new[] { "Id", "CultureCode", "IsDefaultCulture" },
                values: new object[,]
                {
                    { new Guid("ae5ec309-4efb-47ec-8c20-30dcf91832bc"), "tr", true },
                    { new Guid("51a7d260-021f-4d61-bd27-108961b7f596"), "en", false }
                });

            migrationBuilder.InsertData(
                table: "role",
                columns: new[] { "Id", "RoleName" },
                values: new object[] { new Guid("2be51e99-953d-4611-a3b6-61d59b378428"), "Customer" });

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "Id", "CreatedAt", "EmailAddress", "FirstName", "LastName", "PasswordHash", "PhoneNumber", "RoleId", "UserName" },
                values: new object[] { new Guid("03ca55dd-cfbb-4720-b9f0-e3f75b6d3502"), new DateTime(2021, 4, 1, 11, 59, 26, 676, DateTimeKind.Utc).AddTicks(3027), "test@gmail.com", "admin", "test", "JaXGmn0+qpLRduAniDSq4Jn3PoaW+oh/hQJiNptum+Y=", "123456789", new Guid("b19ebe2e-0dad-4445-896c-b0b2d0a33157"), "admintest" });
        }
    }
}
