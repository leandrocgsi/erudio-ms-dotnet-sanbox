using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeekShop.CartApi.Migrations
{
    public partial class AlterTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cart_Detail_Carts_CartId",
                table: "Cart_Detail");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Products",
                newName: "price");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Products",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Products",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Products",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "Products",
                newName: "image_url");

            migrationBuilder.RenameColumn(
                name: "CategoryName",
                table: "Products",
                newName: "category_name");

            migrationBuilder.RenameColumn(
                name: "Count",
                table: "Cart_Detail",
                newName: "count");

            migrationBuilder.AlterColumn<int>(
                name: "CartId",
                table: "Cart_Detail",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_Detail_Carts_CartId",
                table: "Cart_Detail",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cart_Detail_Carts_CartId",
                table: "Cart_Detail");

            migrationBuilder.RenameColumn(
                name: "price",
                table: "Products",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Products",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Products",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Products",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "image_url",
                table: "Products",
                newName: "ImageUrl");

            migrationBuilder.RenameColumn(
                name: "category_name",
                table: "Products",
                newName: "CategoryName");

            migrationBuilder.RenameColumn(
                name: "count",
                table: "Cart_Detail",
                newName: "Count");

            migrationBuilder.AlterColumn<int>(
                name: "CartId",
                table: "Cart_Detail",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_Detail_Carts_CartId",
                table: "Cart_Detail",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "id");
        }
    }
}
