using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DigitalMenu.Data.Migrations
{
    public partial class asdasd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_product_menu_MenuId",
                table: "product");

            migrationBuilder.DropForeignKey(
                name: "FK_user_menu_MenuId",
                table: "user");

            migrationBuilder.DropIndex(
                name: "IX_user_MenuId",
                table: "user");

            migrationBuilder.DeleteData(
                table: "culture",
                keyColumn: "Id",
                keyValue: new Guid("0e396a8c-582b-4d7a-b5aa-5a7660b4204b"));

            migrationBuilder.DeleteData(
                table: "culture",
                keyColumn: "Id",
                keyValue: new Guid("6d51e3e6-5813-403d-83fe-94395d17eb4b"));

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "Id",
                keyValue: new Guid("be6bf99f-b026-4ec4-bdcc-93be9119859d"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "Id",
                keyValue: new Guid("d3d5b3b1-3ae6-421d-be98-9f9c41d0d3b7"));

            migrationBuilder.DropColumn(
                name: "MenuId",
                table: "user");

            migrationBuilder.AlterColumn<Guid>(
                name: "MenuId",
                table: "product",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "menu",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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

            migrationBuilder.CreateIndex(
                name: "IX_menu_UserId",
                table: "menu",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_menu_user_UserId",
                table: "menu",
                column: "UserId",
                principalTable: "user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_product_menu_MenuId",
                table: "product",
                column: "MenuId",
                principalTable: "menu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_menu_user_UserId",
                table: "menu");

            migrationBuilder.DropForeignKey(
                name: "FK_product_menu_MenuId",
                table: "product");

            migrationBuilder.DropIndex(
                name: "IX_menu_UserId",
                table: "menu");

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

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "menu");

            migrationBuilder.AddColumn<Guid>(
                name: "MenuId",
                table: "user",
                type: "uuid",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "MenuId",
                table: "product",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.InsertData(
                table: "culture",
                columns: new[] { "Id", "CultureCode", "IsDefaultCulture" },
                values: new object[,]
                {
                    { new Guid("6d51e3e6-5813-403d-83fe-94395d17eb4b"), "tr", true },
                    { new Guid("0e396a8c-582b-4d7a-b5aa-5a7660b4204b"), "en", false }
                });

            migrationBuilder.InsertData(
                table: "role",
                columns: new[] { "Id", "RoleName" },
                values: new object[] { new Guid("be6bf99f-b026-4ec4-bdcc-93be9119859d"), "Customer" });

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "Id", "CompanyId", "CreatedAt", "EmailAddress", "FirstName", "LastName", "MenuId", "PasswordHash", "PhoneNumber", "RoleId", "UserName" },
                values: new object[] { new Guid("d3d5b3b1-3ae6-421d-be98-9f9c41d0d3b7"), null, new DateTime(2021, 4, 6, 22, 10, 59, 884, DateTimeKind.Utc).AddTicks(407), "test@gmail.com", "admin", "test", null, "JaXGmn0+qpLRduAniDSq4Jn3PoaW+oh/hQJiNptum+Y=", "123456789", new Guid("b19ebe2e-0dad-4445-896c-b0b2d0a33157"), "admintest" });

            migrationBuilder.CreateIndex(
                name: "IX_user_MenuId",
                table: "user",
                column: "MenuId");

            migrationBuilder.AddForeignKey(
                name: "FK_product_menu_MenuId",
                table: "product",
                column: "MenuId",
                principalTable: "menu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_user_menu_MenuId",
                table: "user",
                column: "MenuId",
                principalTable: "menu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
