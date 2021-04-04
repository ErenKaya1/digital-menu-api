using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DigitalMenu.Data.Migrations
{
    public partial class AddedCategoryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "culture",
                keyColumn: "Id",
                keyValue: new Guid("36ff9ab1-6e68-4500-8fb9-f6bcc5d013bf"));

            migrationBuilder.DeleteData(
                table: "culture",
                keyColumn: "Id",
                keyValue: new Guid("fdca6ecd-af69-4215-b610-92ba075605a8"));

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "Id",
                keyValue: new Guid("98b5f41c-6092-425e-8768-9a682505b0c6"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "Id",
                keyValue: new Guid("c52ff520-8b03-4c39-bf5d-2d723dd7db80"));

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ImageName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CategoryTranslation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CultureId = table.Column<Guid>(type: "uuid", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryTranslation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CategoryTranslation_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CategoryTranslation_culture_CultureId",
                        column: x => x.CultureId,
                        principalTable: "culture",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "culture",
                columns: new[] { "Id", "CultureCode", "IsDefaultCulture" },
                values: new object[,]
                {
                    { new Guid("1a8953e3-aa5e-4a83-8be3-becee9432748"), "tr", true },
                    { new Guid("82baa84e-7c8c-4edc-a097-2734d32e237a"), "en", false }
                });

            migrationBuilder.InsertData(
                table: "role",
                columns: new[] { "Id", "RoleName" },
                values: new object[] { new Guid("b5df88a8-30d3-48f1-bc87-4558d4e06b3a"), "Customer" });

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "Id", "CompanyId", "CreatedAt", "EmailAddress", "FirstName", "LastName", "PasswordHash", "PhoneNumber", "RoleId", "UserName" },
                values: new object[] { new Guid("9b04a6ba-cd42-4de6-85c5-6de4342e3478"), null, new DateTime(2021, 4, 4, 0, 2, 8, 100, DateTimeKind.Utc).AddTicks(460), "test@gmail.com", "admin", "test", "JaXGmn0+qpLRduAniDSq4Jn3PoaW+oh/hQJiNptum+Y=", "123456789", new Guid("b19ebe2e-0dad-4445-896c-b0b2d0a33157"), "admintest" });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryTranslation_CategoryId",
                table: "CategoryTranslation",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryTranslation_CultureId",
                table: "CategoryTranslation",
                column: "CultureId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryTranslation");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DeleteData(
                table: "culture",
                keyColumn: "Id",
                keyValue: new Guid("1a8953e3-aa5e-4a83-8be3-becee9432748"));

            migrationBuilder.DeleteData(
                table: "culture",
                keyColumn: "Id",
                keyValue: new Guid("82baa84e-7c8c-4edc-a097-2734d32e237a"));

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "Id",
                keyValue: new Guid("b5df88a8-30d3-48f1-bc87-4558d4e06b3a"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "Id",
                keyValue: new Guid("9b04a6ba-cd42-4de6-85c5-6de4342e3478"));

            migrationBuilder.InsertData(
                table: "culture",
                columns: new[] { "Id", "CultureCode", "IsDefaultCulture" },
                values: new object[,]
                {
                    { new Guid("fdca6ecd-af69-4215-b610-92ba075605a8"), "tr", true },
                    { new Guid("36ff9ab1-6e68-4500-8fb9-f6bcc5d013bf"), "en", false }
                });

            migrationBuilder.InsertData(
                table: "role",
                columns: new[] { "Id", "RoleName" },
                values: new object[] { new Guid("98b5f41c-6092-425e-8768-9a682505b0c6"), "Customer" });

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "Id", "CompanyId", "CreatedAt", "EmailAddress", "FirstName", "LastName", "PasswordHash", "PhoneNumber", "RoleId", "UserName" },
                values: new object[] { new Guid("c52ff520-8b03-4c39-bf5d-2d723dd7db80"), null, new DateTime(2021, 4, 2, 16, 40, 28, 976, DateTimeKind.Utc).AddTicks(3500), "test@gmail.com", "admin", "test", "JaXGmn0+qpLRduAniDSq4Jn3PoaW+oh/hQJiNptum+Y=", "123456789", new Guid("b19ebe2e-0dad-4445-896c-b0b2d0a33157"), "admintest" });
        }
    }
}
