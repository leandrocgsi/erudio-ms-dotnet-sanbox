using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeekShop.CartApi.Model
{
    public class Product
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        [Required]
        [Precision(18, 2)]
        [Range(1, 10000)]
        public decimal Price { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [StringLength(50)]
        public string CategoryName { get; set; }

        [StringLength(300)]
        public string ImageURL { get; set; }
    }
}
