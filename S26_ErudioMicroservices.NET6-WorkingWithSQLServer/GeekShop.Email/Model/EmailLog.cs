using GeekShop.Email.Model.Base;

namespace GeekShop.OrderApi.Model
{
    public class EmailLog : BaseEntity
    {
        public string Email  { get; set; }

        public string Log { get; set; }

        public DateTime SentDate { get; set; }
    }
}