using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyShop.Infrastructure.Migrations
{
    public partial class AddValueHolder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("5b89f701-2a72-4175-8ae0-792b7ff8177a"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("a088dadc-9e92-46c7-a2e8-37b08818f47f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("c7237e0c-e999-4207-928c-eb205bf3776d"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("d5c6681a-db5e-47e6-9e5d-3d99c85ca6ff"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("de8fe0e7-bd49-4bec-be49-a107b7a1e43d"));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "City",
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
                    { new Guid("ba377c1b-0eb1-413e-905b-95226fbb5e0f"), "Canon EOS 70D", 599m },
                    { new Guid("0a402a50-9447-4b31-b863-62e39ff3075a"), "Shure SM7B", 245m },
                    { new Guid("24bfdb57-248b-4e42-a776-9f7d527f614f"), "Key Light", 59.99m },
                    { new Guid("e6f62f39-0f74-4f79-9630-a7e8d942a6f5"), "Android Phone", 259.59m },
                    { new Guid("d2005bd1-ccd4-4c23-b9cf-4afaca14babb"), "5.1 Speaker System", 799.99m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "Name",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "City",
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
                    { new Guid("d5c6681a-db5e-47e6-9e5d-3d99c85ca6ff"), "Canon EOS 70D", 599m },
                    { new Guid("de8fe0e7-bd49-4bec-be49-a107b7a1e43d"), "Shure SM7B", 245m },
                    { new Guid("c7237e0c-e999-4207-928c-eb205bf3776d"), "Key Light", 59.99m },
                    { new Guid("a088dadc-9e92-46c7-a2e8-37b08818f47f"), "Android Phone", 259.59m },
                    { new Guid("5b89f701-2a72-4175-8ae0-792b7ff8177a"), "5.1 Speaker System", 799.99m }
                });
        }
    }
}
