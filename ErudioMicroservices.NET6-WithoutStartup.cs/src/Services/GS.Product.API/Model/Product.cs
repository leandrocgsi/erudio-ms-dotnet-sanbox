using GS.Product.API.Model.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GS.Product.API.Model
{
    public class Product : BaseEntity
    {
        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        [Required]
        [Range(1,10000)]
        public decimal Price { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [Column("Category_Name")]
        [StringLength(50)]
        public string CategoryName { get; set; }

        [Column("Image_Url")]
        [StringLength(300)]
        public string ImageUrl { get; set; }
    }
}
