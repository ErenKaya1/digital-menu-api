using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DigitalMenu.Data.Migrations
{
    public partial class asdasdsadasda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "culture",
                keyColumn: "Id",
                keyValue: new Guid("0cdca127-8dcf-423a-8402-863a0f70e3e1"));

            migrationBuilder.DeleteData(
                table: "culture",
                keyColumn: "Id",
                keyValue: new Guid("abdcc14f-bc95-457b-98b7-703b20b876b2"));

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "Id",
                keyValue: new Guid("a3e5dae1-d975-472e-9b46-6dfc2c8995aa"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "Id",
                keyValue: new Guid("204fb38b-4e15-438b-bcdd-aeb347b9974f"));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "product_translation",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "product_translation",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "culture",
                columns: new[] { "Id", "CultureCode", "IsDefaultCulture" },
                values: new object[,]
                {
                    { new Guid("abdcc14f-bc95-457b-98b7-703b20b876b2"), "tr", true },
                    { new Guid("0cdca127-8dcf-423a-8402-863a0f70e3e1"), "en", false }
                });

            migrationBuilder.InsertData(
                table: "role",
                columns: new[] { "Id", "RoleName" },
                values: new object[] { new Guid("a3e5dae1-d975-472e-9b46-6dfc2c8995aa"), "Customer" });

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "Id", "CompanyId", "CreatedAt", "EmailAddress", "FirstName", "LastName", "PasswordHash", "PhoneNumber", "RoleId", "UserName" },
                values: new object[] { new Guid("204fb38b-4e15-438b-bcdd-aeb347b9974f"), null, new DateTime(2021, 4, 7, 13, 55, 47, 430, DateTimeKind.Utc).AddTicks(7154), "test@gmail.com", "admin", "test", "JaXGmn0+qpLRduAniDSq4Jn3PoaW+oh/hQJiNptum+Y=", "123456789", new Guid("b19ebe2e-0dad-4445-896c-b0b2d0a33157"), "admintest" });
        }
    }
}
