using GeekShopping.ShoppingCartAPI.Data.ValueObjects;
using GeekShopping.ShoppingCartAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GeekShopping.ShoppingCartAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CartController : Controller
    {
        private readonly ICartRepository _repository;

        public CartController(ICartRepository cartRepository)
        {
            _repository = cartRepository;
        }

        [HttpGet("find-cart/{userId}")]
        public async Task<ActionResult<CartVO>> FindCartByUserId(string userId)
        {
            var cart = await _repository.FindCartByUserId(userId);
            if (cart == null) return NotFound();
            return Ok(cart);
        }

        [HttpPost("add-cart")]
        public async Task<ActionResult<CartVO>> AddCart(CartVO vo)
        {
            var cart = await _repository.SaveOrUpdateCart(vo);
            if (cart == null) return NotFound();
            return Ok(cart);
        }

        [HttpPut("update-cart")]
        public async Task<ActionResult<CartVO>> UpdateCart(CartVO vo)
        {
            var cart = await _repository.SaveOrUpdateCart(vo);
            if (cart == null) return NotFound();
            return Ok(cart);
        }

        [HttpDelete("remove-cart/{id}")]
        public async Task<ActionResult<CartVO>> RemoveCart(int id)
        {
            var status = await _repository.RemoveFromCart(id);
            if (!status) return BadRequest();
            return Ok(status);
        }
    }

        /* [HttpPost("ApplyCoupon")]
        public async Task<object> ApplyCoupon([FromBody] CartVO cart)
        {
            try
            {
                bool isSuccess = await _repository.ApplyCoupon(cart.CartHeader.UserId,
                    cart.CartHeader.CouponCode);
                _response.Result = isSuccess;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpPost("RemoveCoupon")]
        public async Task<object> RemoveCoupon([FromBody] string userId)
        {
            try
            {
                bool isSuccess = await _repository.RemoveCoupon(userId);
                _response.Result = isSuccess;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }**/

        /**[HttpPost("Checkout")]
        public async Task<object> Checkout(CheckoutHeaderVO checkoutHeader)
        {
            try
            {
                CartVO cart = await _repository.GetCartByUserId(checkoutHeader.UserId);
                if (cart == null)
                {
                    return BadRequest();
                }

                if (!string.IsNullOrEmpty(checkoutHeader.CouponCode))
                {
                    CouponVO coupon = await _couponRepository.GetCoupon(checkoutHeader.CouponCode);
                    if (checkoutHeader.DiscountTotal != coupon.DiscountAmount)
                    {
                        _response.IsSuccess = false;
                        _response.ErrorMessages = new List<string>() { "Coupon Price has changed, please confirm" };
                        _response.DisplayMessage = "Coupon Price has changed, please confirm";
                        return _response;
                    }
                }

                checkoutHeader.CartDetails = cart.CartDetails;
                //logic to add message to process order.
                await _messageBus.PublishMessage(checkoutHeader, "checkoutqueue");

                ////rabbitMQ
                //_rabbitMQCartMessageSender.SendMessage(checkoutHeader, "checkoutqueue");
                await _repository.ClearCart(checkoutHeader.UserId);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }
    }*/
}
