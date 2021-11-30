using GeekShopping.Email.Messages;
using System.Threading.Tasks;

namespace GeekShopping.Email.Repository
{
    public interface IEmailRepository
    {
        Task SendAndLogEmail(UpdatePaymentResultMessage message);
    }
}
