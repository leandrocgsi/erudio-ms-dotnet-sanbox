using System.ComponentModel.DataAnnotations;

namespace GeekShop.CartApi.Model.Base
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
