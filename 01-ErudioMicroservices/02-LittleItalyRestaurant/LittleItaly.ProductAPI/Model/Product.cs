using LittleItaly.ProductAPI.Model.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LittleItaly.ProductAPI.Model
{
    [Table("product")]
    public class Product : BaseEntity
    {
        [Column("name")]
        [Required]
        public string Name { get; set; }

        [Column("price")]
        [Range(1,10000)]
        public double Price { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("category_name")]
        public string CategoryName { get; set; }

        [Column("image_url")]
        public string ImageURL { get; set; }


    }
}
