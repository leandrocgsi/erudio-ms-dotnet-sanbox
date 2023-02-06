using GeekShop.CartApi.DTOs;
using GeekShop.CartApi.IRepository;
using GeekShop.CartApi.IService;

namespace GeekShop.CartApi.Services
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;

        public CartService(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task<bool> ApplyCoupon(string userId, string couponCode)
        {
            var isApplied = await _cartRepository.ApplyCoupon(userId, couponCode);
            return isApplied;
        }

        public async Task<bool> RemoveCoupon(string userId)
        {
            var isRemoved = await _cartRepository.RemoveCoupon(userId);
            return isRemoved;
        }



        public async Task<bool> ClearCart(string userId)
        {
            var isCleaned = await _cartRepository.ClearCart(userId);
            return isCleaned;
        }

        public async Task<CartDto> FindCartByUserId(string userId)
        {
            var cartDto = await _cartRepository.FindCartByUserId(userId);
            return cartDto;
        }

        public async Task<bool> RemoveFromCart(int cartDetailId)
        {
            var isRemoved = await _cartRepository.RemoveFromCart(cartDetailId);
            return isRemoved;
        }

        public async Task<CartDto> SaveOrUpdateCart(CartDto cartDto)
        {
            var cartDtoDB = await _cartRepository.SaveOrUpdateCart(cartDto);
            return cartDtoDB;
        }
    }
}
