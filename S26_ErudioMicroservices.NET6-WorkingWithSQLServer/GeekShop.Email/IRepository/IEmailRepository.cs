using GeekShop.Email.Messages;

namespace GeekShop.Email.IRepository
{
    public interface IEmailRepository
    {
        Task LogEmail(UpdatePaymentResultMessage message);
    }
}
