using GeekShop.CartApi.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeekShop.CartApi.Model
{
    public class CartDetail : BaseEntity
    {
        public int CartHeaderId { get; set; }

        [ForeignKey("CartHeaderId")]
        public virtual CartHeader CartHeader { get; set; }
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

        [Column("count")]
        public int Count { get; set; }
    }
}