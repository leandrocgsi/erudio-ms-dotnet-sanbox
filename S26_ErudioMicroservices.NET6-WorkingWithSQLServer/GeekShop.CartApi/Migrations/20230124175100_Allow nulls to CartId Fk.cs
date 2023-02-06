using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeekShop.CartApi.Migrations
{
    public partial class AllownullstoCartIdFk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cart_Detail_Carts_CartId",
                table: "Cart_Detail");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cart_Detail_Carts_CartId",
                table: "Cart_Detail");

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
    }
}
