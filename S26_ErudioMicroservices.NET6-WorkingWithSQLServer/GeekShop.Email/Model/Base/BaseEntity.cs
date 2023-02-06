using System.ComponentModel.DataAnnotations;

namespace GeekShop.Email.Model.Base
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
