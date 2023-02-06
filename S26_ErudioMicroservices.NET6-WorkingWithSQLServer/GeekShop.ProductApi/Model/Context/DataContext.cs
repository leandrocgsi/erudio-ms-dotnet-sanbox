using Microsoft.EntityFrameworkCore;

namespace GeekShop.ProductApi.Model.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Product> Products => Set<Product>();
    }
}

