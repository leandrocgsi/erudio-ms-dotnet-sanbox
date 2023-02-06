using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeekShop.CartApi.Migrations
{
    public partial class Altercartedetaildescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cart_Detail_CartHeaders_CartHeaderId",
                table: "Cart_Detail");

            migrationBuilder.DropForeignKey(
                name: "FK_Cart_Detail_Products_ProductId",
                table: "Cart_Detail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cart_Detail",
                table: "Cart_Detail");

            migrationBuilder.RenameTable(
                name: "Cart_Detail",
                newName: "CartDetails");

            migrationBuilder.RenameIndex(
                name: "IX_Cart_Detail_ProductId",
                table: "CartDetails",
                newName: "IX_CartDetails_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Cart_Detail_CartHeaderId",
                table: "CartDetails",
                newName: "IX_CartDetails_CartHeaderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CartDetails",
                table: "CartDetails",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_CartDetails_CartHeaders_CartHeaderId",
                table: "CartDetails",
                column: "CartHeaderId",
                principalTable: "CartHeaders",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CartDetails_Products_ProductId",
                table: "CartDetails",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartDetails_CartHeaders_CartHeaderId",
                table: "CartDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_CartDetails_Products_ProductId",
                table: "CartDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CartDetails",
                table: "CartDetails");

            migrationBuilder.RenameTable(
                name: "CartDetails",
                newName: "Cart_Detail");

            migrationBuilder.RenameIndex(
                name: "IX_CartDetails_ProductId",
                table: "Cart_Detail",
                newName: "IX_Cart_Detail_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_CartDetails_CartHeaderId",
                table: "Cart_Detail",
                newName: "IX_Cart_Detail_CartHeaderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cart_Detail",
                table: "Cart_Detail",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_Detail_CartHeaders_CartHeaderId",
                table: "Cart_Detail",
                column: "CartHeaderId",
                principalTable: "CartHeaders",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_Detail_Products_ProductId",
                table: "Cart_Detail",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
