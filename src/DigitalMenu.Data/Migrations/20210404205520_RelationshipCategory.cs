using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DigitalMenu.Data.Migrations
{
    public partial class RelationshipCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "culture",
                keyColumn: "Id",
                keyValue: new Guid("30dd4d7e-f227-404e-8d59-f4df305ef095"));

            migrationBuilder.DeleteData(
                table: "culture",
                keyColumn: "Id",
                keyValue: new Guid("5af19ecd-739e-41f8-b51d-770ac75607de"));

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "Id",
                keyValue: new Guid("4a61fea9-19e1-4161-8688-542e2a7454e7"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "Id",
                keyValue: new Guid("c309dd75-1e23-4eb0-af44-ae670fe65dc5"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "category",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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

            migrationBuilder.CreateIndex(
                name: "IX_category_UserId",
                table: "category",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_category_user_UserId",
                table: "category",
                column: "UserId",
                principalTable: "user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_category_user_UserId",
                table: "category");

            migrationBuilder.DropIndex(
                name: "IX_category_UserId",
                table: "category");

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

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "category");

            migrationBuilder.InsertData(
                table: "culture",
                columns: new[] { "Id", "CultureCode", "IsDefaultCulture" },
                values: new object[,]
                {
                    { new Guid("30dd4d7e-f227-404e-8d59-f4df305ef095"), "tr", true },
                    { new Guid("5af19ecd-739e-41f8-b51d-770ac75607de"), "en", false }
                });

            migrationBuilder.InsertData(
                table: "role",
                columns: new[] { "Id", "RoleName" },
                values: new object[] { new Guid("4a61fea9-19e1-4161-8688-542e2a7454e7"), "Customer" });

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "Id", "CompanyId", "CreatedAt", "EmailAddress", "FirstName", "LastName", "PasswordHash", "PhoneNumber", "RoleId", "UserName" },
                values: new object[] { new Guid("c309dd75-1e23-4eb0-af44-ae670fe65dc5"), null, new DateTime(2021, 4, 4, 0, 14, 17, 606, DateTimeKind.Utc).AddTicks(5515), "test@gmail.com", "admin", "test", "JaXGmn0+qpLRduAniDSq4Jn3PoaW+oh/hQJiNptum+Y=", "123456789", new Guid("b19ebe2e-0dad-4445-896c-b0b2d0a33157"), "admintest" });
        }
    }
}
