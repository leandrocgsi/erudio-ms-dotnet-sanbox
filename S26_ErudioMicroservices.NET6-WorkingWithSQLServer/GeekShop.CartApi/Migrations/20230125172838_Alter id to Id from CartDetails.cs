using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeekShop.CartApi.Migrations
{
    public partial class AlteridtoIdfromCartDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "CartHeaders",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "CartDetails",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "CartHeaders",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "CartDetails",
                newName: "id");
        }
    }
}
