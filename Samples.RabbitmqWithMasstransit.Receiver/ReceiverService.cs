using System;
using MassTransit;


namespace Samples.RabbitmqWithMasstransit.Receiver
{
    public class ReceiverService
    {
        private IBusControl _bus;
        public void Start()
        {
            Console.WriteLine("Receiver start.");
            _bus = Bus.Factory.CreateUsingRabbitMq(sbc => {
                sbc.Host(new Uri("rabbitmq://localhost"), h => {
                    h.Username("guest");
                    h.Password("guest");
                });

                sbc.ReceiveEndpoint("new_queue", ep => {
                    ep.Consumer<MessageConsumer>();
                });
            });

            _bus.Start();
        }

        public void Stop()
        {
            _bus.Stop();
            Console.WriteLine("Receiver stop.");
        }
    }
}
