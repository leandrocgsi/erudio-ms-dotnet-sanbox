using System.ComponentModel.DataAnnotations;

namespace GeekShop.CuponApi.Model.Base
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
