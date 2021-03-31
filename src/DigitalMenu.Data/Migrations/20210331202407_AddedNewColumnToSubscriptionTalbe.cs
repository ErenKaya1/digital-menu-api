using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DigitalMenu.Data.Migrations
{
    public partial class AddedNewColumnToSubscriptionTalbe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "culture",
                keyColumn: "Id",
                keyValue: new Guid("18ecd6e2-09b4-457b-8fa8-042db418a0cf"));

            migrationBuilder.DeleteData(
                table: "culture",
                keyColumn: "Id",
                keyValue: new Guid("8b53e7ea-a9e8-4f19-bb72-90649ea0db15"));

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "Id",
                keyValue: new Guid("38d33773-9203-44a8-887e-ae76fda3714a"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "Id",
                keyValue: new Guid("0754a1ed-318f-47c1-a8ac-0cfdb4d9f120"));

            migrationBuilder.RenameColumn(
                name: "IsTrialModel",
                table: "subscription",
                newName: "IsTrialMode");

            migrationBuilder.AddColumn<bool>(
                name: "IsSubscriptionReminderMailSent",
                table: "subscription",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "culture",
                columns: new[] { "Id", "CultureCode", "IsDefaultCulture" },
                values: new object[,]
                {
                    { new Guid("a7aefd6a-920c-4b17-af58-1677306ce256"), "tr", true },
                    { new Guid("d36a52f8-a3fb-4831-a7c0-6d8cb1c21460"), "en", false }
                });

            migrationBuilder.InsertData(
                table: "role",
                columns: new[] { "Id", "RoleName" },
                values: new object[] { new Guid("c39b5359-5037-42dd-bca6-7d569567e8b3"), "Customer" });

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "Id", "CreatedAt", "EmailAddress", "FirstName", "LastName", "PasswordHash", "PhoneNumber", "RoleId", "UserName" },
                values: new object[] { new Guid("0d66f1a7-241f-4da5-a3dc-d693a0829009"), new DateTime(2021, 3, 31, 20, 24, 6, 991, DateTimeKind.Utc).AddTicks(5793), "test@gmail.com", "admin", "test", "JaXGmn0+qpLRduAniDSq4Jn3PoaW+oh/hQJiNptum+Y=", "123456789", new Guid("b19ebe2e-0dad-4445-896c-b0b2d0a33157"), "admintest" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "culture",
                keyColumn: "Id",
                keyValue: new Guid("a7aefd6a-920c-4b17-af58-1677306ce256"));

            migrationBuilder.DeleteData(
                table: "culture",
                keyColumn: "Id",
                keyValue: new Guid("d36a52f8-a3fb-4831-a7c0-6d8cb1c21460"));

            migrationBuilder.DeleteData(
                table: "role",
                keyColumn: "Id",
                keyValue: new Guid("c39b5359-5037-42dd-bca6-7d569567e8b3"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "Id",
                keyValue: new Guid("0d66f1a7-241f-4da5-a3dc-d693a0829009"));

            migrationBuilder.DropColumn(
                name: "IsSubscriptionReminderMailSent",
                table: "subscription");

            migrationBuilder.RenameColumn(
                name: "IsTrialMode",
                table: "subscription",
                newName: "IsTrialModel");

            migrationBuilder.InsertData(
                table: "culture",
                columns: new[] { "Id", "CultureCode", "IsDefaultCulture" },
                values: new object[,]
                {
                    { new Guid("18ecd6e2-09b4-457b-8fa8-042db418a0cf"), "tr", true },
                    { new Guid("8b53e7ea-a9e8-4f19-bb72-90649ea0db15"), "en", false }
                });

            migrationBuilder.InsertData(
                table: "role",
                columns: new[] { "Id", "RoleName" },
                values: new object[] { new Guid("38d33773-9203-44a8-887e-ae76fda3714a"), "Customer" });

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "Id", "CreatedAt", "EmailAddress", "FirstName", "LastName", "PasswordHash", "PhoneNumber", "RoleId", "UserName" },
                values: new object[] { new Guid("0754a1ed-318f-47c1-a8ac-0cfdb4d9f120"), new DateTime(2021, 3, 30, 20, 3, 42, 521, DateTimeKind.Utc).AddTicks(1080), "test@gmail.com", "admin", "test", "JaXGmn0+qpLRduAniDSq4Jn3PoaW+oh/hQJiNptum+Y=", "123456789", new Guid("b19ebe2e-0dad-4445-896c-b0b2d0a33157"), "admintest" });
        }
    }
}
