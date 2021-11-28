using GeekShopping.OrderAPI.Model;
using System.Threading.Tasks;

namespace GeekShopping.OrderAPI.Repository
{
    public interface IOrderRepository
    {
        Task<bool> AddOrder(OrderHeader header);
        Task UpdateOrderPaymentStatus(int orderHeaderId, bool paid);
    }
}
