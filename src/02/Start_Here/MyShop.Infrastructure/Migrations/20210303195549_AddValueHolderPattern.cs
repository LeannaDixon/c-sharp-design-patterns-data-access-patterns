using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyShop.Infrastructure.Migrations
{
    public partial class AddValueHolderPattern : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("0a402a50-9447-4b31-b863-62e39ff3075a"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("24bfdb57-248b-4e42-a776-9f7d527f614f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("ba377c1b-0eb1-413e-905b-95226fbb5e0f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("d2005bd1-ccd4-4c23-b9cf-4afaca14babb"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("e6f62f39-0f74-4f79-9630-a7e8d942a6f5"));

            migrationBuilder.AlterColumn<string>(
                name: "ShippingAddress",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PostalCode",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Country",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("d76e68d3-7980-4ad9-b438-c38fbdf1a897"), "Canon EOS 70D", 599m },
                    { new Guid("2e911ce3-47f6-4ef9-980d-27e2d6be4c93"), "Shure SM7B", 245m },
                    { new Guid("478b2636-bbf5-4442-809a-e7585cdb78e5"), "Key Light", 59.99m },
                    { new Guid("dc1a905d-dc0e-49d1-8250-63833da481c1"), "Android Phone", 259.59m },
                    { new Guid("4046babb-57ba-4cfe-8717-fbd88a6004b5"), "5.1 Speaker System", 799.99m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("2e911ce3-47f6-4ef9-980d-27e2d6be4c93"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("4046babb-57ba-4cfe-8717-fbd88a6004b5"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("478b2636-bbf5-4442-809a-e7585cdb78e5"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("d76e68d3-7980-4ad9-b438-c38fbdf1a897"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("dc1a905d-dc0e-49d1-8250-63833da481c1"));

            migrationBuilder.AlterColumn<string>(
                name: "ShippingAddress",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "PostalCode",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Country",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("ba377c1b-0eb1-413e-905b-95226fbb5e0f"), "Canon EOS 70D", 599m },
                    { new Guid("0a402a50-9447-4b31-b863-62e39ff3075a"), "Shure SM7B", 245m },
                    { new Guid("24bfdb57-248b-4e42-a776-9f7d527f614f"), "Key Light", 59.99m },
                    { new Guid("e6f62f39-0f74-4f79-9630-a7e8d942a6f5"), "Android Phone", 259.59m },
                    { new Guid("d2005bd1-ccd4-4c23-b9cf-4afaca14babb"), "5.1 Speaker System", 799.99m }
                });
        }
    }
}
