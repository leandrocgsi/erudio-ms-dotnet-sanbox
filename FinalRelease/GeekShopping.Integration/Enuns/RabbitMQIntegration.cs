using System.ComponentModel;

namespace GeekShopping.Integration.Enuns
{
    public enum QueueName
    {
        [Description("checkout")]
        Checkout,

        [Description("order_payment_process")]
        OrderPaymentProcess,

        [Description("order_payment_result")]
        OrderPaymentResult,

        [Description("payment_email_update")]
        PaymentEmailUpdate,

        [Description("payment_order_update")]
        PaymentOrderUpdate
    }

    public enum ExchangeName
    {
        [Description("direct_payment_update")]
        DirectPaymentUpdate
    }

    public enum RoutingKey
    {
        [Description("PaymentEmail")]
        PaymentEmail,

        [Description("PaymentOrder")]
        PaymentOrder
    }
}
