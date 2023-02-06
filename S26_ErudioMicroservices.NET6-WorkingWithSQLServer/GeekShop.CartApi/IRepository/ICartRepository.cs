using GeekShop.CartApi.DTOs;

namespace GeekShop.CartApi.IRepository
{
    public interface ICartRepository
    {
        Task<bool> ApplyCoupon(string userId, string couponCode);
        Task<bool> ClearCart(string userId);
        Task<CartDto> FindCartByUserId(string userId);
        Task<bool> RemoveCoupon(string userId);
        Task<bool> RemoveFromCart(int cartDetailId);
        Task<CartDto> SaveOrUpdateCart(CartDto cartDto);
    }
}