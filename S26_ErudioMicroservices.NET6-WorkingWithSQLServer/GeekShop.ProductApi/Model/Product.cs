using GeekShop.ProductApi.Model.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeekShop.ProductApi.Model
{
    [Table("product")]
    public class Product : BaseEntity
    {
        [Column("name")]
        [Required]
        [StringLength(150)]
        public string Name { get; set; } = string.Empty;

        [Column("price")]
        [Required]
        [Range(1, 10000)]
        public decimal price { get; set; }

        [Column("description")]
        [StringLength(500)]
        public string Description { get; set; } = string.Empty ;

        [Column("category_name")]
        [StringLength(50)]
        public string CategoryName { get; set; } = string.Empty ;

        [Column("image_url")]
        [StringLength(300)]
        public string ImageUrl { get; set; } = string.Empty ;

    }
}
