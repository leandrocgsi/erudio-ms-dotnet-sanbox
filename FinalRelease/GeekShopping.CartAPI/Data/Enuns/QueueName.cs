using System.ComponentModel;

namespace GeekShopping.CartAPI.Data.Enuns
{
    public enum QueueName
    {
        [Description("checkout")]
        Checkout,

        [Description("order_payment_process")]
        OrderPaymentProcess
    }
}
