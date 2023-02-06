using GeekShop.CuponApi.Model.Base;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace GeekShop.CuponApi.Model
{
    public class Coupon :BaseEntity
    {
        [Required]
        [StringLength(30)]
        public string CouponCode { get; set; }

        [Required]
        [Precision(18, 2)]
        public decimal DiscountAmount { get; set; }
    }
}
