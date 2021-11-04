using GeekShopping.Web.Models;
using System.Threading.Tasks;

namespace GeekShopping.Web.Services.IServices
{
    public interface ICartService
    {
        Task<CartViewModel> FindCartByUserId(string userId, string token = null);
        Task<CartViewModel> AddItemToCart(CartViewModel cart, string token = null);
        Task<CartViewModel> UpdateCart(CartViewModel cart, string token = null);
        Task<bool> RemoveFromCart(long cartId, string token = null);
        Task<bool> ApplyCoupon(CartViewModel cart, string couponCode, string token = null);
        Task<bool> RemoveCoupon(string userId, string token = null);
        Task<bool> ClearCart(string userId, string token = null);

        Task<T> Checkout<T>(CartHeaderViewModel cartHeader, string token = null);
    }
}
