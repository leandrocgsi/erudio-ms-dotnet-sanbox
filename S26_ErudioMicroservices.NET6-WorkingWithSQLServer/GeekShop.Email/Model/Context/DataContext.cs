using GeekShop.OrderApi.Model;
using Microsoft.EntityFrameworkCore;

namespace GeekShop.Email.Model.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<EmailLog> Emails { get; set; }
    }
}