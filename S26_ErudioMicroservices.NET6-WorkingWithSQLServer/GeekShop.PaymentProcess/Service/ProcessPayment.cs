using GeekShop.PaymentProcess.IService;

namespace GeekShop.PaymentProcess.Service
{
    public class ProcessPayment : IProcessPayment
    {
        public bool PaymentProcessor()
        {
            return true;
        }
    }
}
