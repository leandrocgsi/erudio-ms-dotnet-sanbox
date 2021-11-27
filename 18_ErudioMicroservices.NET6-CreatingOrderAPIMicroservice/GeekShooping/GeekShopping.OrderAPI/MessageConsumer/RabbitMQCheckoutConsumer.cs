using GeekShopping.OrderAPI.Messages;
using GeekShopping.OrderAPI.Model;
using GeekShopping.OrderAPI.RabbitMQSender;
using GeekShopping.OrderAPI.Repository;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Mango.Services.OrderAPI.Messaging
{
    public class RabbitMQCheckoutConsumer : BackgroundService
    {
        private readonly OrderRepository _repository;
        private IConnection _connection;
        private IModel _channel;

        public RabbitMQCheckoutConsumer(OrderRepository repository)
        {
            _repository = repository;
            var factory = new ConnectionFactory
            {
                HostName = "localhost",
                UserName = "guest",
                Password = "guest"
            };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare(queue: "checkoutqueue", false, false, false, arguments: null);
        }
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (ch, ea) =>
            {
                var content = Encoding.UTF8.GetString(ea.Body.ToArray());
                CheckoutHeaderVO checkoutHeaderVO = JsonSerializer.Deserialize<CheckoutHeaderVO>(content);
                HandleMessage(checkoutHeaderVO).GetAwaiter().GetResult();

                _channel.BasicAck(ea.DeliveryTag, false);
            };
            _channel.BasicConsume("checkoutqueue", false, consumer);

            return Task.CompletedTask;
        }

        private async Task HandleMessage(CheckoutHeaderVO checkoutHeaderVO)
        {
            OrderHeader header = new()
            {
                UserId = checkoutHeaderVO.UserId,
                FirstName = checkoutHeaderVO.FirstName,
                LastName = checkoutHeaderVO.LastName,
                OrderDetails = new List<OrderDetail>(),
                CardNumber = checkoutHeaderVO.CardNumber,
                CouponCode = checkoutHeaderVO.CouponCode,
                CVV = checkoutHeaderVO.CVV,
                DiscountAmount = checkoutHeaderVO.DiscountAmount,
                Email = checkoutHeaderVO.Email,
                ExpiryMonthYear = checkoutHeaderVO.ExpiryMonthYear,
                OrderTime = DateTime.Now,
                PurchaseAmount = checkoutHeaderVO.PurchaseAmount,
                PaymentStatus = false,
                Phone = checkoutHeaderVO.Phone,
                DateTime = checkoutHeaderVO.DateTime
            };

            foreach (var detailList in checkoutHeaderVO.CartDetails)
            {
                OrderDetail orderDetails = new()
                {
                    ProductId = detailList.ProductId,
                    ProductName = detailList.Product.Name,
                    Price = detailList.Product.Price,
                    Count = detailList.Count
                };
                header.CartTotalItems += detailList.Count;
                header.OrderDetails.Add(orderDetails);
            }

            await _repository.AddOrder(header);


            /*PaymentRequestMessage paymentRequestMessage = new()
            {
                Name = orderHeader.FirstName + " " + orderHeader.LastName,
                CardNumber = orderHeader.CardNumber,
                CVV = orderHeader.CVV,
                ExpiryMonthYear = orderHeader.ExpiryMonthYear,
                OrderId = orderHeader.OrderHeaderId,
                OrderTotal = orderHeader.OrderTotal,
                Email = orderHeader.Email
            };

            try
            {
                //await _messageBus.PublishMessage(paymentRequestMessage, orderPaymentProcessTopic);
                //await args.CompleteMessageAsync(args.Message);
                _rabbitMQMessageSender.SendMessage(paymentRequestMessage, "orderpaymentprocesstopic");
            }
            catch (Exception e)
            {
                throw;
            }*/
        }
    }
}
