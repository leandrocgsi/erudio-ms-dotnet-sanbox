using GeekShopping.CartAPI.Data.DTOs;
using GeekShopping.CartAPI.Data.Enuns;
using GeekShopping.CartAPI.Messages;
using GeekShopping.CartAPI.RabbitMQSender;
using GeekShopping.CartAPI.Repository;
using GeekShopping.Utils;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.CartAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CartController : ControllerBase
    {
        private ICartRepository _cartRepository;
        private ICouponRepository _couponRepository;
        private IRabbitMQMessageSender _rabbitMQMessageSender;

        public CartController(
                ICartRepository cartRepository,
                ICouponRepository couponRepository,
                IRabbitMQMessageSender rabbitMQMessageSender
            )
        {
            _cartRepository = cartRepository ?? throw new ArgumentNullException(nameof(cartRepository));
            _couponRepository = couponRepository ?? throw new ArgumentNullException(nameof(couponRepository));
            _rabbitMQMessageSender = rabbitMQMessageSender?? throw new ArgumentNullException(nameof(rabbitMQMessageSender));
        }        

        [HttpGet("find-cart/{id}")]        
        public async Task<ActionResult<CartDTO>> FindById(string id)
        {
            var cart = await _cartRepository.FindCartByUserId(id);
            if (cart == null)
                return NotFound();

            return Ok(cart);
        }

        [HttpPost("add-cart")]
        public async Task<ActionResult<CartDTO>> AddCart([FromBody] CartDTO cartDTO)
        {
            var cart = await _cartRepository.SaveOrUpdateCart(cartDTO);
            if (cart == null)
                return NotFound();

            return Ok(cart);
        }

        [HttpPut("update-cart")]
        public async Task<ActionResult<CartDTO>> UpdateCart([FromBody] CartDTO cartDTO)
        {
            var cart = await _cartRepository.SaveOrUpdateCart(cartDTO);
            if (cart == null)
                return NotFound();

            return Ok(cart);
        }

        [HttpDelete("remove-cart/{id}")]
        public async Task<ActionResult<CartDTO>> RemoveCart(int id)
        {
            var status = await _cartRepository.RemoveFromCart(id);
            if (!status)
                return BadRequest();

            return Ok(status);
        }

        [HttpPost("apply-coupon")]
        public async Task<ActionResult<CartDTO>> ApplyCoupon(CartDTO cartDTO)
        {
            var status = await _cartRepository.ApplyCoupon(cartDTO.CartHeader.UserId, cartDTO.CartHeader.CouponCode);
            if (!status)
                return NotFound();

            return Ok(status);
        }

        [HttpDelete("remove-coupon/{userId}")]
        public async Task<ActionResult<CartDTO>> ApplyCoupon(string userId)
        {
            var status = await _cartRepository.RemoveCoupon(userId);
            if (!status)
                return NotFound();

            return Ok(status);
        }

        [HttpPost("checkout")]
        public async Task<ActionResult<CheckoutHeaderDTO>> Checkout(CheckoutHeaderDTO model)
        {
            if (model?.UserId == null)
                return BadRequest();

            var cart = await _cartRepository.FindCartByUserId(model.UserId);
            if (cart == null)
                return NotFound();

            if (!string.IsNullOrEmpty(model.CouponCode))
            {
                var token = await HttpContext.GetTokenAsync("access_token");
                CouponDTO coupon = await _couponRepository.GetCoupon(
                        model.CouponCode, 
                        token
                    );

                if (model.DiscountAmount != coupon.DiscountAmount)
                    return StatusCode(412);
            }

            model.CartDetails = cart.CartDetails;
            model.DateTime = DateTime.Now;

            _rabbitMQMessageSender.SendMessage(model, QueueName.Checkout.GetDescription());

            await _cartRepository.ClearCart(model.UserId);

            return Ok(model);
        }
    }
}