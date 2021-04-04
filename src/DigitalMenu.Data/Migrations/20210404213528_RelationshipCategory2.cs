using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DigitalMenu.Data.Migrations
{
    public partial class RelationshipCategory2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_category_translation_category_CategoryId",
                table: "category_translation");

            migrationBuilder.DeleteData(
                table: "culture",
                keyColumn: "Id",
                keyValue: new Guid("96cb7eb2-1e3d-44ab-b655-136209100c65"));

            migrationBuilder.DeleteData(
                table: "culture",
                keyColumn: "Id",
                keyValue: new Guid("ad7c4670-184a-4b10-b6df-de3b29d4d370"));

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "Id",
                keyValue: new Guid("de193ab2-f676-4a57-a2bb-482f7de41e39"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "Id",
                keyValue: new Guid("670abb2c-1b58-4897-b74c-65e8322d3fbe"));

            migrationBuilder.AlterColumn<Guid>(
                name: "CategoryId",
                table: "category_translation",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "culture",
                columns: new[] { "Id", "CultureCode", "IsDefaultCulture" },
                values: new object[,]
                {
                    { new Guid("81f890a8-45b9-4796-9253-da7de161b99a"), "tr", true },
                    { new Guid("fd6b5879-0b38-4749-a09b-df9055f1ba96"), "en", false }
                });

            migrationBuilder.InsertData(
                table: "role",
                columns: new[] { "Id", "RoleName" },
                values: new object[] { new Guid("d03b46d8-e95e-4bac-8be1-c99e9066e51c"), "Customer" });

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "Id", "CompanyId", "CreatedAt", "EmailAddress", "FirstName", "LastName", "PasswordHash", "PhoneNumber", "RoleId", "UserName" },
                values: new object[] { new Guid("b513e4a5-c1dc-419a-a6e1-aa336ccdd20c"), null, new DateTime(2021, 4, 4, 21, 35, 28, 207, DateTimeKind.Utc).AddTicks(3791), "test@gmail.com", "admin", "test", "JaXGmn0+qpLRduAniDSq4Jn3PoaW+oh/hQJiNptum+Y=", "123456789", new Guid("b19ebe2e-0dad-4445-896c-b0b2d0a33157"), "admintest" });

            migrationBuilder.AddForeignKey(
                name: "FK_category_translation_category_CategoryId",
                table: "category_translation",
                column: "CategoryId",
                principalTable: "category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_category_translation_category_CategoryId",
                table: "category_translation");

            migrationBuilder.DeleteData(
                table: "culture",
                keyColumn: "Id",
                keyValue: new Guid("81f890a8-45b9-4796-9253-da7de161b99a"));

            migrationBuilder.DeleteData(
                table: "culture",
                keyColumn: "Id",
                keyValue: new Guid("fd6b5879-0b38-4749-a09b-df9055f1ba96"));

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "Id",
                keyValue: new Guid("d03b46d8-e95e-4bac-8be1-c99e9066e51c"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "Id",
                keyValue: new Guid("b513e4a5-c1dc-419a-a6e1-aa336ccdd20c"));

            migrationBuilder.AlterColumn<Guid>(
                name: "CategoryId",
                table: "category_translation",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.InsertData(
                table: "culture",
                columns: new[] { "Id", "CultureCode", "IsDefaultCulture" },
                values: new object[,]
                {
                    { new Guid("ad7c4670-184a-4b10-b6df-de3b29d4d370"), "tr", true },
                    { new Guid("96cb7eb2-1e3d-44ab-b655-136209100c65"), "en", false }
                });

            migrationBuilder.InsertData(
                table: "role",
                columns: new[] { "Id", "RoleName" },
                values: new object[] { new Guid("de193ab2-f676-4a57-a2bb-482f7de41e39"), "Customer" });

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "Id", "CompanyId", "CreatedAt", "EmailAddress", "FirstName", "LastName", "PasswordHash", "PhoneNumber", "RoleId", "UserName" },
                values: new object[] { new Guid("670abb2c-1b58-4897-b74c-65e8322d3fbe"), null, new DateTime(2021, 4, 4, 20, 55, 20, 386, DateTimeKind.Utc).AddTicks(8173), "test@gmail.com", "admin", "test", "JaXGmn0+qpLRduAniDSq4Jn3PoaW+oh/hQJiNptum+Y=", "123456789", new Guid("b19ebe2e-0dad-4445-896c-b0b2d0a33157"), "admintest" });

            migrationBuilder.AddForeignKey(
                name: "FK_category_translation_category_CategoryId",
                table: "category_translation",
                column: "CategoryId",
                principalTable: "category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
