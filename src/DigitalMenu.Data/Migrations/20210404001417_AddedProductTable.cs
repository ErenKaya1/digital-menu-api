using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DigitalMenu.Data.Migrations
{
    public partial class AddedProductTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryTranslation_Category_CategoryId",
                table: "CategoryTranslation");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryTranslation_culture_CultureId",
                table: "CategoryTranslation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                table: "Category");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryTranslation",
                table: "CategoryTranslation");

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

            migrationBuilder.RenameTable(
                name: "Category",
                newName: "category");

            migrationBuilder.RenameTable(
                name: "CategoryTranslation",
                newName: "category_translation");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryTranslation_CultureId",
                table: "category_translation",
                newName: "IX_category_translation_CultureId");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryTranslation_CategoryId",
                table: "category_translation",
                newName: "IX_category_translation_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_category",
                table: "category",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_category_translation",
                table: "category_translation",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "product",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Price = table.Column<double>(type: "double precision", nullable: false),
                    Order = table.Column<int>(type: "integer", nullable: false),
                    ImageName = table.Column<string>(type: "text", nullable: true),
                    CategoryId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_product_category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "product_translation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    CultureId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_translation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_product_translation_culture_CultureId",
                        column: x => x.CultureId,
                        principalTable: "culture",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_product_translation_product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_product_CategoryId",
                table: "product",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_product_translation_CultureId",
                table: "product_translation",
                column: "CultureId");

            migrationBuilder.CreateIndex(
                name: "IX_product_translation_ProductId",
                table: "product_translation",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_category_translation_category_CategoryId",
                table: "category_translation",
                column: "CategoryId",
                principalTable: "category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_category_translation_culture_CultureId",
                table: "category_translation",
                column: "CultureId",
                principalTable: "culture",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_category_translation_category_CategoryId",
                table: "category_translation");

            migrationBuilder.DropForeignKey(
                name: "FK_category_translation_culture_CultureId",
                table: "category_translation");

            migrationBuilder.DropTable(
                name: "product_translation");

            migrationBuilder.DropTable(
                name: "product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_category",
                table: "category");

            migrationBuilder.DropPrimaryKey(
                name: "PK_category_translation",
                table: "category_translation");

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

            migrationBuilder.RenameTable(
                name: "category",
                newName: "Category");

            migrationBuilder.RenameTable(
                name: "category_translation",
                newName: "CategoryTranslation");

            migrationBuilder.RenameIndex(
                name: "IX_category_translation_CultureId",
                table: "CategoryTranslation",
                newName: "IX_CategoryTranslation_CultureId");

            migrationBuilder.RenameIndex(
                name: "IX_category_translation_CategoryId",
                table: "CategoryTranslation",
                newName: "IX_CategoryTranslation_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                table: "Category",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryTranslation",
                table: "CategoryTranslation",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryTranslation_Category_CategoryId",
                table: "CategoryTranslation",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryTranslation_culture_CultureId",
                table: "CategoryTranslation",
                column: "CultureId",
                principalTable: "culture",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
