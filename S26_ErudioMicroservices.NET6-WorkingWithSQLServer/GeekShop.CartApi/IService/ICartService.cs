﻿using GeekShop.CartApi.DTOs;

namespace GeekShop.CartApi.IService
{
    public interface ICartService
    {
        Task<bool> ApplyCoupon(string userId, string couponCode);
        Task<bool> ClearCart(string userId);
        Task<CartDto> FindCartByUserId(string userId);
        Task<bool> RemoveFromCart(int cartDetailId);
        Task<bool> RemoveCoupon(string userId);
        Task<CartDto> SaveOrUpdateCart(CartDto cartDto);
    }
}
