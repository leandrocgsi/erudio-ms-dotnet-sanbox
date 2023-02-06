using System.ComponentModel.DataAnnotations;

namespace GeekShop.OrderApi.Model.Base
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
