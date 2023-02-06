using GeekShop.OrderApi.Model;

namespace GeekShop.OrderApi.IRepository
{
    public interface IOrderRepository
    {
        Task<bool> AddOrder(OrderHeader header);
        Task UpdateOrderPaymentStatus(long orderHeaderId, bool paid);
    }
}
