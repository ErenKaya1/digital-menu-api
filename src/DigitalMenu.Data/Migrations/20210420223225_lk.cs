using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DigitalMenu.Data.Migrations
{
    public partial class lk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_product_product_group_ProductGroupId",
                table: "product");

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
                table: "product");

            migrationBuilder.CreateTable(
                name: "ProductProductGroup",
                columns: table => new
                {
                    ProductGroupId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductProductGroup", x => new { x.ProductGroupId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_ProductProductGroup_product_group_ProductGroupId",
                        column: x => x.ProductGroupId,
                        principalTable: "product_group",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductProductGroup_product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "role",
                columns: new[] { "Id", "RoleName" },
                values: new object[] { new Guid("0374f26b-fe54-484e-8a35-07ff6b07629d"), "Customer" });

            migrationBuilder.InsertData(
                table: "subscription_type_translation",
                columns: new[] { "Id", "CultureId", "SubscriptionTypeId", "Title" },
                values: new object[,]
                {
                    { new Guid("b6dcadb4-cf72-47b6-b698-d7b09fb9d2f1"), new Guid("48c92719-ebe7-4b4c-9814-9c8f1a57b1ff"), new Guid("638885d5-6b38-4c01-903a-449c676b86f5"), "Giriş" },
                    { new Guid("fbf534b1-81e4-4862-89a7-8b3da60edc4b"), new Guid("41d8d90c-2224-42fb-ac80-c27b87e74371"), new Guid("638885d5-6b38-4c01-903a-449c676b86f5"), "Starter" },
                    { new Guid("34cd4585-8a37-488c-b5e4-da6396041b03"), new Guid("48c92719-ebe7-4b4c-9814-9c8f1a57b1ff"), new Guid("971daed0-4c56-4e5b-b9a9-74eb975c54eb"), "Ekonomik" },
                    { new Guid("a1d38006-b4a5-4543-b6f8-7477a3dba523"), new Guid("41d8d90c-2224-42fb-ac80-c27b87e74371"), new Guid("971daed0-4c56-4e5b-b9a9-74eb975c54eb"), "Economic" },
                    { new Guid("d0787658-aca3-4848-8ff9-d16d0d2743be"), new Guid("48c92719-ebe7-4b4c-9814-9c8f1a57b1ff"), new Guid("e0f8c62e-9769-4520-a46b-2d23f6abe7e3"), "Premium" },
                    { new Guid("f4c0dba8-da5a-4d74-93f5-fabab3176bf9"), new Guid("41d8d90c-2224-42fb-ac80-c27b87e74371"), new Guid("e0f8c62e-9769-4520-a46b-2d23f6abe7e3"), "Premium" }
                });

            migrationBuilder.InsertData(
                table: "subsctiption_type_feature_translation",
                columns: new[] { "Id", "CultureId", "Name", "SubscriptionTypeFeatureId" },
                values: new object[,]
                {
                    { new Guid("63407d18-1b57-41de-a964-03cad8411ec7"), new Guid("48c92719-ebe7-4b4c-9814-9c8f1a57b1ff"), "Ürün", new Guid("41cdda69-aa5f-496f-8c1a-3f26d1a32dae") },
                    { new Guid("dcb553f5-cd3f-4361-ba0b-72c339e3cfcf"), new Guid("41d8d90c-2224-42fb-ac80-c27b87e74371"), "Product", new Guid("41cdda69-aa5f-496f-8c1a-3f26d1a32dae") },
                    { new Guid("907cf224-02fa-4542-9b32-a0232eeec0cf"), new Guid("48c92719-ebe7-4b4c-9814-9c8f1a57b1ff"), "Ürün", new Guid("9abf06ab-0c1a-4c63-a141-e512fe306c1e") },
                    { new Guid("4f7a4ca8-9c95-4778-9b60-e4b22beda62c"), new Guid("41d8d90c-2224-42fb-ac80-c27b87e74371"), "Product", new Guid("9abf06ab-0c1a-4c63-a141-e512fe306c1e") },
                    { new Guid("2fcb13c3-b330-4eb5-9e0a-efe2907cdf7a"), new Guid("48c92719-ebe7-4b4c-9814-9c8f1a57b1ff"), "Ürün", new Guid("da12028f-418a-4bd2-9617-27c4aec8372c") },
                    { new Guid("29069e03-a2a3-4800-82ac-5ed4263d2320"), new Guid("41d8d90c-2224-42fb-ac80-c27b87e74371"), "Product", new Guid("da12028f-418a-4bd2-9617-27c4aec8372c") }
                });

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "Id", "CompanyId", "CreatedAt", "EmailAddress", "FirstName", "LastName", "PasswordHash", "PhoneNumber", "RoleId", "UserName" },
                values: new object[] { new Guid("b6804b18-f05a-49be-9ff9-4877cce17ca2"), null, new DateTime(2021, 4, 20, 22, 32, 24, 696, DateTimeKind.Utc).AddTicks(6447), "test@gmail.com", "admin", "test", "JaXGmn0+qpLRduAniDSq4Jn3PoaW+oh/hQJiNptum+Y=", "123456789", new Guid("b19ebe2e-0dad-4445-896c-b0b2d0a33157"), "admintest" });

            migrationBuilder.CreateIndex(
                name: "IX_ProductProductGroup_ProductId",
                table: "ProductProductGroup",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductProductGroup");

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "Id",
                keyValue: new Guid("0374f26b-fe54-484e-8a35-07ff6b07629d"));

            migrationBuilder.DeleteData(
                table: "subscription_type_translation",
                keyColumn: "Id",
                keyValue: new Guid("34cd4585-8a37-488c-b5e4-da6396041b03"));

            migrationBuilder.DeleteData(
                table: "subscription_type_translation",
                keyColumn: "Id",
                keyValue: new Guid("a1d38006-b4a5-4543-b6f8-7477a3dba523"));

            migrationBuilder.DeleteData(
                table: "subscription_type_translation",
                keyColumn: "Id",
                keyValue: new Guid("b6dcadb4-cf72-47b6-b698-d7b09fb9d2f1"));

            migrationBuilder.DeleteData(
                table: "subscription_type_translation",
                keyColumn: "Id",
                keyValue: new Guid("d0787658-aca3-4848-8ff9-d16d0d2743be"));

            migrationBuilder.DeleteData(
                table: "subscription_type_translation",
                keyColumn: "Id",
                keyValue: new Guid("f4c0dba8-da5a-4d74-93f5-fabab3176bf9"));

            migrationBuilder.DeleteData(
                table: "subscription_type_translation",
                keyColumn: "Id",
                keyValue: new Guid("fbf534b1-81e4-4862-89a7-8b3da60edc4b"));

            migrationBuilder.DeleteData(
                table: "subsctiption_type_feature_translation",
                keyColumn: "Id",
                keyValue: new Guid("29069e03-a2a3-4800-82ac-5ed4263d2320"));

            migrationBuilder.DeleteData(
                table: "subsctiption_type_feature_translation",
                keyColumn: "Id",
                keyValue: new Guid("2fcb13c3-b330-4eb5-9e0a-efe2907cdf7a"));

            migrationBuilder.DeleteData(
                table: "subsctiption_type_feature_translation",
                keyColumn: "Id",
                keyValue: new Guid("4f7a4ca8-9c95-4778-9b60-e4b22beda62c"));

            migrationBuilder.DeleteData(
                table: "subsctiption_type_feature_translation",
                keyColumn: "Id",
                keyValue: new Guid("63407d18-1b57-41de-a964-03cad8411ec7"));

            migrationBuilder.DeleteData(
                table: "subsctiption_type_feature_translation",
                keyColumn: "Id",
                keyValue: new Guid("907cf224-02fa-4542-9b32-a0232eeec0cf"));

            migrationBuilder.DeleteData(
                table: "subsctiption_type_feature_translation",
                keyColumn: "Id",
                keyValue: new Guid("dcb553f5-cd3f-4361-ba0b-72c339e3cfcf"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "Id",
                keyValue: new Guid("b6804b18-f05a-49be-9ff9-4877cce17ca2"));

            migrationBuilder.AddColumn<Guid>(
                name: "ProductGroupId",
                table: "product",
                type: "uuid",
                nullable: true);

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
                name: "IX_product_ProductGroupId",
                table: "product",
                column: "ProductGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_product_product_group_ProductGroupId",
                table: "product",
                column: "ProductGroupId",
                principalTable: "product_group",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
