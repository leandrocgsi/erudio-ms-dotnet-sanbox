using Microsoft.EntityFrameworkCore;

namespace GeekShopping.CouponAPI.Model.Context
{
    public class MySqlContext : DbContext
    {
        public MySqlContext(DbContextOptions<MySqlContext> options)
            : base(options) { }

        public DbSet<Coupon> Coupons { get; set; }    

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Coupon>().HasData(new Coupon
            {
                Id = 1,
                CouponCode = "DSC_2022_A",
                DiscountAmount = 10
            });

            modelBuilder.Entity<Coupon>().HasData(new Coupon
            {
                Id = 2,
                CouponCode = "DSC_2022_B",
                DiscountAmount = 15
            });
        }
    }
}
