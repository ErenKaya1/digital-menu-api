using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DigitalMenu.Data.Migrations
{
    public partial class sdf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "Id",
                keyValue: new Guid("c8024dfe-145b-48a7-9bee-aa5b2320c9c2"));

            migrationBuilder.DeleteData(
                table: "subscription_type_translation",
                keyColumn: "Id",
                keyValue: new Guid("0547525a-9052-40d6-a0a2-38f6488dda6a"));

            migrationBuilder.DeleteData(
                table: "subscription_type_translation",
                keyColumn: "Id",
                keyValue: new Guid("6ebd768f-c064-4d79-8be9-5676fe903102"));

            migrationBuilder.DeleteData(
                table: "subscription_type_translation",
                keyColumn: "Id",
                keyValue: new Guid("7afba862-ee79-403f-995a-c60b810749d5"));

            migrationBuilder.DeleteData(
                table: "subscription_type_translation",
                keyColumn: "Id",
                keyValue: new Guid("8028b38b-e681-4a5c-925d-f4b04dae4f91"));

            migrationBuilder.DeleteData(
                table: "subscription_type_translation",
                keyColumn: "Id",
                keyValue: new Guid("81e756e2-8330-4436-9ead-8aa56bb98e44"));

            migrationBuilder.DeleteData(
                table: "subscription_type_translation",
                keyColumn: "Id",
                keyValue: new Guid("f201de50-6adc-4a6f-8a29-596411ba6094"));

            migrationBuilder.DeleteData(
                table: "subsctiption_type_feature_translation",
                keyColumn: "Id",
                keyValue: new Guid("2cf20a11-7d5a-4e1c-8340-42829ad0e11e"));

            migrationBuilder.DeleteData(
                table: "subsctiption_type_feature_translation",
                keyColumn: "Id",
                keyValue: new Guid("5645036c-71b7-44c2-ad67-d6d21104a613"));

            migrationBuilder.DeleteData(
                table: "subsctiption_type_feature_translation",
                keyColumn: "Id",
                keyValue: new Guid("5d6a0d20-2283-4507-8fdc-bb4eb26cdb39"));

            migrationBuilder.DeleteData(
                table: "subsctiption_type_feature_translation",
                keyColumn: "Id",
                keyValue: new Guid("77be136a-d9dc-4937-bab5-accedbad0942"));

            migrationBuilder.DeleteData(
                table: "subsctiption_type_feature_translation",
                keyColumn: "Id",
                keyValue: new Guid("b19fea22-2029-4385-adb4-26ac11b1e828"));

            migrationBuilder.DeleteData(
                table: "subsctiption_type_feature_translation",
                keyColumn: "Id",
                keyValue: new Guid("fd5cb3c8-9b3c-4a69-adf5-ae6d8de209d8"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "Id",
                keyValue: new Guid("8c467ace-16df-49e4-a92a-083c6da680b3"));

            migrationBuilder.AddColumn<Guid>(
                name: "ProductGroupId",
                table: "product_translation",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ProductGroupId",
                table: "product",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "product_group",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Price = table.Column<double>(type: "double precision", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    MenuId = table.Column<Guid>(type: "uuid", nullable: false),
                    ImageName = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_group", x => x.Id);
                    table.ForeignKey(
                        name: "FK_product_group_category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_product_group_menu_MenuId",
                        column: x => x.MenuId,
                        principalTable: "menu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "role",
                columns: new[] { "Id", "RoleName" },
                values: new object[] { new Guid("451db7ac-ec0d-4b44-aed0-0e9f11155949"), "Customer" });

            migrationBuilder.InsertData(
                table: "subscription_type_translation",
                columns: new[] { "Id", "CultureId", "SubscriptionTypeId", "Title" },
                values: new object[,]
                {
                    { new Guid("c67c4ecd-8cb3-46b9-9be2-ee4f1f103468"), new Guid("48c92719-ebe7-4b4c-9814-9c8f1a57b1ff"), new Guid("638885d5-6b38-4c01-903a-449c676b86f5"), "Giriş" },
                    { new Guid("8c9af387-c67c-4cd0-9a6c-c6b33b258dc2"), new Guid("41d8d90c-2224-42fb-ac80-c27b87e74371"), new Guid("638885d5-6b38-4c01-903a-449c676b86f5"), "Starter" },
                    { new Guid("588aa280-9774-420e-bbfa-e1bcc718922e"), new Guid("48c92719-ebe7-4b4c-9814-9c8f1a57b1ff"), new Guid("971daed0-4c56-4e5b-b9a9-74eb975c54eb"), "Ekonomik" },
                    { new Guid("8a7bc23a-0cd5-44c5-842a-5e798e7c12ff"), new Guid("41d8d90c-2224-42fb-ac80-c27b87e74371"), new Guid("971daed0-4c56-4e5b-b9a9-74eb975c54eb"), "Economic" },
                    { new Guid("e87b6d4c-d0ec-44a9-b39d-6ae5e216cbcb"), new Guid("48c92719-ebe7-4b4c-9814-9c8f1a57b1ff"), new Guid("e0f8c62e-9769-4520-a46b-2d23f6abe7e3"), "Premium" },
                    { new Guid("4bfb6da9-4140-41a6-86be-be03a3408230"), new Guid("41d8d90c-2224-42fb-ac80-c27b87e74371"), new Guid("e0f8c62e-9769-4520-a46b-2d23f6abe7e3"), "Premium" }
                });

            migrationBuilder.InsertData(
                table: "subsctiption_type_feature_translation",
                columns: new[] { "Id", "CultureId", "Name", "SubscriptionTypeFeatureId" },
                values: new object[,]
                {
                    { new Guid("88226061-e640-49e8-b2de-22dc842dd3e3"), new Guid("48c92719-ebe7-4b4c-9814-9c8f1a57b1ff"), "Ürün", new Guid("41cdda69-aa5f-496f-8c1a-3f26d1a32dae") },
                    { new Guid("64af3528-df12-49e0-8320-c37d21c275eb"), new Guid("41d8d90c-2224-42fb-ac80-c27b87e74371"), "Product", new Guid("41cdda69-aa5f-496f-8c1a-3f26d1a32dae") },
                    { new Guid("f45d970d-039a-499c-86bb-b958463dc957"), new Guid("48c92719-ebe7-4b4c-9814-9c8f1a57b1ff"), "Ürün", new Guid("9abf06ab-0c1a-4c63-a141-e512fe306c1e") },
                    { new Guid("18524766-08b3-4319-ac7f-e5148ed80842"), new Guid("41d8d90c-2224-42fb-ac80-c27b87e74371"), "Product", new Guid("9abf06ab-0c1a-4c63-a141-e512fe306c1e") },
                    { new Guid("5565690e-dd15-426e-b386-4e7b6a1fb323"), new Guid("48c92719-ebe7-4b4c-9814-9c8f1a57b1ff"), "Ürün", new Guid("da12028f-418a-4bd2-9617-27c4aec8372c") },
                    { new Guid("c6b7dc8a-e231-4094-895a-a72b54bd5981"), new Guid("41d8d90c-2224-42fb-ac80-c27b87e74371"), "Product", new Guid("da12028f-418a-4bd2-9617-27c4aec8372c") }
                });

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "Id", "CompanyId", "CreatedAt", "EmailAddress", "FirstName", "LastName", "PasswordHash", "PhoneNumber", "RoleId", "UserName" },
                values: new object[] { new Guid("2b4ec6d9-09eb-4318-ac42-3de4937f9692"), null, new DateTime(2021, 4, 20, 18, 35, 10, 46, DateTimeKind.Utc).AddTicks(9235), "test@gmail.com", "admin", "test", "JaXGmn0+qpLRduAniDSq4Jn3PoaW+oh/hQJiNptum+Y=", "123456789", new Guid("b19ebe2e-0dad-4445-896c-b0b2d0a33157"), "admintest" });

            migrationBuilder.CreateIndex(
                name: "IX_product_translation_ProductGroupId",
                table: "product_translation",
                column: "ProductGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_product_ProductGroupId",
                table: "product",
                column: "ProductGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_product_group_CategoryId",
                table: "product_group",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_product_group_MenuId",
                table: "product_group",
                column: "MenuId");

            migrationBuilder.AddForeignKey(
                name: "FK_product_product_group_ProductGroupId",
                table: "product",
                column: "ProductGroupId",
                principalTable: "product_group",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_product_translation_product_group_ProductGroupId",
                table: "product_translation",
                column: "ProductGroupId",
                principalTable: "product_group",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_product_product_group_ProductGroupId",
                table: "product");

            migrationBuilder.DropForeignKey(
                name: "FK_product_translation_product_group_ProductGroupId",
                table: "product_translation");

            migrationBuilder.DropTable(
                name: "product_group");

            migrationBuilder.DropIndex(
                name: "IX_product_translation_ProductGroupId",
                table: "product_translation");

            migrationBuilder.DropIndex(
                name: "IX_product_ProductGroupId",
                table: "product");

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "Id",
                keyValue: new Guid("451db7ac-ec0d-4b44-aed0-0e9f11155949"));

            migrationBuilder.DeleteData(
                table: "subscription_type_translation",
                keyColumn: "Id",
                keyValue: new Guid("4bfb6da9-4140-41a6-86be-be03a3408230"));

            migrationBuilder.DeleteData(
                table: "subscription_type_translation",
                keyColumn: "Id",
                keyValue: new Guid("588aa280-9774-420e-bbfa-e1bcc718922e"));

            migrationBuilder.DeleteData(
                table: "subscription_type_translation",
                keyColumn: "Id",
                keyValue: new Guid("8a7bc23a-0cd5-44c5-842a-5e798e7c12ff"));

            migrationBuilder.DeleteData(
                table: "subscription_type_translation",
                keyColumn: "Id",
                keyValue: new Guid("8c9af387-c67c-4cd0-9a6c-c6b33b258dc2"));

            migrationBuilder.DeleteData(
                table: "subscription_type_translation",
                keyColumn: "Id",
                keyValue: new Guid("c67c4ecd-8cb3-46b9-9be2-ee4f1f103468"));

            migrationBuilder.DeleteData(
                table: "subscription_type_translation",
                keyColumn: "Id",
                keyValue: new Guid("e87b6d4c-d0ec-44a9-b39d-6ae5e216cbcb"));

            migrationBuilder.DeleteData(
                table: "subsctiption_type_feature_translation",
                keyColumn: "Id",
                keyValue: new Guid("18524766-08b3-4319-ac7f-e5148ed80842"));

            migrationBuilder.DeleteData(
                table: "subsctiption_type_feature_translation",
                keyColumn: "Id",
                keyValue: new Guid("5565690e-dd15-426e-b386-4e7b6a1fb323"));

            migrationBuilder.DeleteData(
                table: "subsctiption_type_feature_translation",
                keyColumn: "Id",
                keyValue: new Guid("64af3528-df12-49e0-8320-c37d21c275eb"));

            migrationBuilder.DeleteData(
                table: "subsctiption_type_feature_translation",
                keyColumn: "Id",
                keyValue: new Guid("88226061-e640-49e8-b2de-22dc842dd3e3"));

            migrationBuilder.DeleteData(
                table: "subsctiption_type_feature_translation",
                keyColumn: "Id",
                keyValue: new Guid("c6b7dc8a-e231-4094-895a-a72b54bd5981"));

            migrationBuilder.DeleteData(
                table: "subsctiption_type_feature_translation",
                keyColumn: "Id",
                keyValue: new Guid("f45d970d-039a-499c-86bb-b958463dc957"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "Id",
                keyValue: new Guid("2b4ec6d9-09eb-4318-ac42-3de4937f9692"));

            migrationBuilder.DropColumn(
                name: "ProductGroupId",
                table: "product_translation");

            migrationBuilder.DropColumn(
                name: "ProductGroupId",
                table: "product");

            migrationBuilder.InsertData(
                table: "role",
                columns: new[] { "Id", "RoleName" },
                values: new object[] { new Guid("c8024dfe-145b-48a7-9bee-aa5b2320c9c2"), "Customer" });

            migrationBuilder.InsertData(
                table: "subscription_type_translation",
                columns: new[] { "Id", "CultureId", "SubscriptionTypeId", "Title" },
                values: new object[,]
                {
                    { new Guid("0547525a-9052-40d6-a0a2-38f6488dda6a"), new Guid("48c92719-ebe7-4b4c-9814-9c8f1a57b1ff"), new Guid("638885d5-6b38-4c01-903a-449c676b86f5"), "Giriş" },
                    { new Guid("6ebd768f-c064-4d79-8be9-5676fe903102"), new Guid("41d8d90c-2224-42fb-ac80-c27b87e74371"), new Guid("638885d5-6b38-4c01-903a-449c676b86f5"), "Starter" },
                    { new Guid("f201de50-6adc-4a6f-8a29-596411ba6094"), new Guid("48c92719-ebe7-4b4c-9814-9c8f1a57b1ff"), new Guid("971daed0-4c56-4e5b-b9a9-74eb975c54eb"), "Ekonomik" },
                    { new Guid("7afba862-ee79-403f-995a-c60b810749d5"), new Guid("41d8d90c-2224-42fb-ac80-c27b87e74371"), new Guid("971daed0-4c56-4e5b-b9a9-74eb975c54eb"), "Economic" },
                    { new Guid("8028b38b-e681-4a5c-925d-f4b04dae4f91"), new Guid("48c92719-ebe7-4b4c-9814-9c8f1a57b1ff"), new Guid("e0f8c62e-9769-4520-a46b-2d23f6abe7e3"), "Premium" },
                    { new Guid("81e756e2-8330-4436-9ead-8aa56bb98e44"), new Guid("41d8d90c-2224-42fb-ac80-c27b87e74371"), new Guid("e0f8c62e-9769-4520-a46b-2d23f6abe7e3"), "Premium" }
                });

            migrationBuilder.InsertData(
                table: "subsctiption_type_feature_translation",
                columns: new[] { "Id", "CultureId", "Name", "SubscriptionTypeFeatureId" },
                values: new object[,]
                {
                    { new Guid("5645036c-71b7-44c2-ad67-d6d21104a613"), new Guid("48c92719-ebe7-4b4c-9814-9c8f1a57b1ff"), "Ürün", new Guid("41cdda69-aa5f-496f-8c1a-3f26d1a32dae") },
                    { new Guid("77be136a-d9dc-4937-bab5-accedbad0942"), new Guid("41d8d90c-2224-42fb-ac80-c27b87e74371"), "Product", new Guid("41cdda69-aa5f-496f-8c1a-3f26d1a32dae") },
                    { new Guid("5d6a0d20-2283-4507-8fdc-bb4eb26cdb39"), new Guid("48c92719-ebe7-4b4c-9814-9c8f1a57b1ff"), "Ürün", new Guid("9abf06ab-0c1a-4c63-a141-e512fe306c1e") },
                    { new Guid("fd5cb3c8-9b3c-4a69-adf5-ae6d8de209d8"), new Guid("41d8d90c-2224-42fb-ac80-c27b87e74371"), "Product", new Guid("9abf06ab-0c1a-4c63-a141-e512fe306c1e") },
                    { new Guid("b19fea22-2029-4385-adb4-26ac11b1e828"), new Guid("48c92719-ebe7-4b4c-9814-9c8f1a57b1ff"), "Ürün", new Guid("da12028f-418a-4bd2-9617-27c4aec8372c") },
                    { new Guid("2cf20a11-7d5a-4e1c-8340-42829ad0e11e"), new Guid("41d8d90c-2224-42fb-ac80-c27b87e74371"), "Product", new Guid("da12028f-418a-4bd2-9617-27c4aec8372c") }
                });

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "Id", "CompanyId", "CreatedAt", "EmailAddress", "FirstName", "LastName", "PasswordHash", "PhoneNumber", "RoleId", "UserName" },
                values: new object[] { new Guid("8c467ace-16df-49e4-a92a-083c6da680b3"), null, new DateTime(2021, 4, 20, 0, 46, 59, 79, DateTimeKind.Utc).AddTicks(7206), "test@gmail.com", "admin", "test", "JaXGmn0+qpLRduAniDSq4Jn3PoaW+oh/hQJiNptum+Y=", "123456789", new Guid("b19ebe2e-0dad-4445-896c-b0b2d0a33157"), "admintest" });
        }
    }
}
