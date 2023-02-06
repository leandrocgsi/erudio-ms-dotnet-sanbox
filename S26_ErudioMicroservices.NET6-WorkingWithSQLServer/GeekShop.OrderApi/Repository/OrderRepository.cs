using GeekShop.OrderApi.Model;
using GeekShop.OrderApi.Model.Context;
using Microsoft.EntityFrameworkCore;

namespace GeekShop.OrderApi.Repository
{
    public class OrderRepository
    {
        private readonly DbContextOptions<DataContext> _context;

        public OrderRepository(DbContextOptions<DataContext> context)
        {
            _context = context;
        }

        public async Task<bool> AddOrder(OrderHeader header)
        {
            if (header == null) return false;
            await using var _db = new DataContext(_context);
            _db.OrderHeaders.Add(header);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task UpdateOrderPaymentStatus(long orderHeaderId, bool status)
        {
            await using var _db = new DataContext(_context);
            var header = await _db.OrderHeaders.FirstOrDefaultAsync(o => o.Id == orderHeaderId);
            if (header != null)
            {
                header.PaymentStatus = status;
                await _db.SaveChangesAsync();
            };
        }
    }
}
