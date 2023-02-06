using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeekShop.CartApi.Migrations
{
    public partial class Altertablesdescriptions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cart_Detail_Cart_Header_CartHeaderId",
                table: "Cart_Detail");

            migrationBuilder.DropForeignKey(
                name: "FK_Cart_Detail_Carts_CartId",
                table: "Cart_Detail");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropIndex(
                name: "IX_Cart_Detail_CartId",
                table: "Cart_Detail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cart_Header",
                table: "Cart_Header");

            migrationBuilder.DropColumn(
                name: "CartId",
                table: "Cart_Detail");

            migrationBuilder.RenameTable(
                name: "Cart_Header",
                newName: "CartHeaders");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "CartHeaders",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "coupon_code",
                table: "CartHeaders",
                newName: "CouponCode");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CartHeaders",
                table: "CartHeaders",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_Detail_CartHeaders_CartHeaderId",
                table: "Cart_Detail",
                column: "CartHeaderId",
                principalTable: "CartHeaders",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cart_Detail_CartHeaders_CartHeaderId",
                table: "Cart_Detail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CartHeaders",
                table: "CartHeaders");

            migrationBuilder.RenameTable(
                name: "CartHeaders",
                newName: "Cart_Header");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Cart_Header",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "CouponCode",
                table: "Cart_Header",
                newName: "coupon_code");

            migrationBuilder.AddColumn<int>(
                name: "CartId",
                table: "Cart_Detail",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cart_Header",
                table: "Cart_Header",
                column: "id");

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CartHeaderId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.id);
                    table.ForeignKey(
                        name: "FK_Carts_Cart_Header_CartHeaderId",
                        column: x => x.CartHeaderId,
                        principalTable: "Cart_Header",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cart_Detail_CartId",
                table: "Cart_Detail",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_CartHeaderId",
                table: "Carts",
                column: "CartHeaderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_Detail_Cart_Header_CartHeaderId",
                table: "Cart_Detail",
                column: "CartHeaderId",
                principalTable: "Cart_Header",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_Detail_Carts_CartId",
                table: "Cart_Detail",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "id");
        }
    }
}
