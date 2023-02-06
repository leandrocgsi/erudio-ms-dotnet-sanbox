using GeekShop.CartApi.Model.Base;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeekShop.CartApi.Model
{
    public class CartHeader : BaseEntity
    {
        public string UserId { get; set; }

        public string CouponCode { get; set; }

        [Precision(18, 2)]
        public decimal DiscountAmount { get; set; }
    }
}
