using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeekShopping.CouponAPI.Migrations
{
    public partial class SeedCouponDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "coupon",
                columns: new[] { "id", "coupon_code", "discount_amount" },
                values: new object[] { 1L, "DSC_2022_A", 10m });

            migrationBuilder.InsertData(
                table: "coupon",
                columns: new[] { "id", "coupon_code", "discount_amount" },
                values: new object[] { 2L, "DSC_2022_B", 15m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "coupon",
                keyColumn: "id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "coupon",
                keyColumn: "id",
                keyValue: 2L);
        }
    }
}
