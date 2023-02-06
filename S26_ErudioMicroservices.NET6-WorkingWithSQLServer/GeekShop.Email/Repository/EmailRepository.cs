using GeekShop.Email.IRepository;
using GeekShop.Email.Messages;
using GeekShop.Email.Model.Context;
using GeekShop.OrderApi.Model;
using Microsoft.EntityFrameworkCore;

namespace GeekShop.Email.Repository
{
    public class EmailRepository : IEmailRepository
    {
        private readonly DbContextOptions<DataContext> _dataContext;

        public EmailRepository(DbContextOptions<DataContext> dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task LogEmail(UpdatePaymentResultMessage message)
        {
            EmailLog email = new EmailLog()
            {
                Email = message.Email,
                SentDate = DateTime.Now,
                Log = $"Order - {message.OrderId} has been created successfully!"
            };

            await using var _db = new DataContext(_dataContext);
            _db.Emails.Add(email);
            await _db.SaveChangesAsync();
        }
    }
}
