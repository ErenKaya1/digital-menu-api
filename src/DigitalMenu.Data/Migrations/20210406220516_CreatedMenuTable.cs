using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DigitalMenu.Data.Migrations
{
    public partial class CreatedMenuTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "culture",
                keyColumn: "Id",
                keyValue: new Guid("5696be22-2eb2-43ec-b304-cc6d6f276ebe"));

            migrationBuilder.DeleteData(
                table: "culture",
                keyColumn: "Id",
                keyValue: new Guid("9bcb8710-e6ba-490e-9eec-52157bb334df"));

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "Id",
                keyValue: new Guid("e8a56f0a-d030-49ae-ad1a-ce71c6cb3db4"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "Id",
                keyValue: new Guid("9a8a7cb0-9aca-4c4d-91ab-f0bd7a8ca1cd"));

            migrationBuilder.AddColumn<Guid>(
                name: "MenuId",
                table: "product",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "menu",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    QrCode = table.Column<string>(type: "text", nullable: true),
                    QrCodeColor = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_menu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_menu_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "culture",
                columns: new[] { "Id", "CultureCode", "IsDefaultCulture" },
                values: new object[,]
                {
                    { new Guid("e2a641cc-2bce-469b-85a2-866535ec879e"), "tr", true },
                    { new Guid("cf9799f0-d5ca-401a-b588-991c3746f0b7"), "en", false }
                });

            migrationBuilder.InsertData(
                table: "role",
                columns: new[] { "Id", "RoleName" },
                values: new object[] { new Guid("83651d50-b01e-496f-9f6a-2152f0b2b55d"), "Customer" });

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "Id", "CompanyId", "CreatedAt", "EmailAddress", "FirstName", "LastName", "PasswordHash", "PhoneNumber", "RoleId", "UserName" },
                values: new object[] { new Guid("e8ff5d29-f482-4fa2-9f37-ea1d54b6da54"), null, new DateTime(2021, 4, 6, 22, 5, 15, 693, DateTimeKind.Utc).AddTicks(192), "test@gmail.com", "admin", "test", "JaXGmn0+qpLRduAniDSq4Jn3PoaW+oh/hQJiNptum+Y=", "123456789", new Guid("b19ebe2e-0dad-4445-896c-b0b2d0a33157"), "admintest" });

            migrationBuilder.CreateIndex(
                name: "IX_product_MenuId",
                table: "product",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_menu_UserId",
                table: "menu",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_product_menu_MenuId",
                table: "product",
                column: "MenuId",
                principalTable: "menu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_product_menu_MenuId",
                table: "product");

            migrationBuilder.DropTable(
                name: "menu");

            migrationBuilder.DropIndex(
                name: "IX_product_MenuId",
                table: "product");

            migrationBuilder.DeleteData(
                table: "culture",
                keyColumn: "Id",
                keyValue: new Guid("cf9799f0-d5ca-401a-b588-991c3746f0b7"));

            migrationBuilder.DeleteData(
                table: "culture",
                keyColumn: "Id",
                keyValue: new Guid("e2a641cc-2bce-469b-85a2-866535ec879e"));

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "Id",
                keyValue: new Guid("83651d50-b01e-496f-9f6a-2152f0b2b55d"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "Id",
                keyValue: new Guid("e8ff5d29-f482-4fa2-9f37-ea1d54b6da54"));

            migrationBuilder.DropColumn(
                name: "MenuId",
                table: "product");

            migrationBuilder.InsertData(
                table: "culture",
                columns: new[] { "Id", "CultureCode", "IsDefaultCulture" },
                values: new object[,]
                {
                    { new Guid("5696be22-2eb2-43ec-b304-cc6d6f276ebe"), "tr", true },
                    { new Guid("9bcb8710-e6ba-490e-9eec-52157bb334df"), "en", false }
                });

            migrationBuilder.InsertData(
                table: "role",
                columns: new[] { "Id", "RoleName" },
                values: new object[] { new Guid("e8a56f0a-d030-49ae-ad1a-ce71c6cb3db4"), "Customer" });

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "Id", "CompanyId", "CreatedAt", "EmailAddress", "FirstName", "LastName", "PasswordHash", "PhoneNumber", "RoleId", "UserName" },
                values: new object[] { new Guid("9a8a7cb0-9aca-4c4d-91ab-f0bd7a8ca1cd"), null, new DateTime(2021, 4, 6, 13, 5, 41, 588, DateTimeKind.Utc).AddTicks(1272), "test@gmail.com", "admin", "test", "JaXGmn0+qpLRduAniDSq4Jn3PoaW+oh/hQJiNptum+Y=", "123456789", new Guid("b19ebe2e-0dad-4445-896c-b0b2d0a33157"), "admintest" });
        }
    }
}
