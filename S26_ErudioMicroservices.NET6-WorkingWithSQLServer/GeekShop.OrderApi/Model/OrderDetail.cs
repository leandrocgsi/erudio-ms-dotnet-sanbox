using GeekShop.OrderApi.Model.Base;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeekShop.OrderApi.Model
{
    public class OrderDetail : BaseEntity
    {
        public int OrderHeaderId { get; set; }

        [ForeignKey("OrderHeaderId")]
        public virtual OrderHeader OrderHeader { get; set; }

        public int ProductId { get; set; }

        public int Count { get; set; }

        public string ProductName { get; set; }

        [Precision(18,2)]
        public decimal Price { get; set; }
    }
}