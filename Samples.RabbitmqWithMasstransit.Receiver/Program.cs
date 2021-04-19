using MassTransit;
using System;

namespace Samples.RabbitmqWithMasstransit.Receiver
{
    class Program
    {
        static void Main(string[] args)
        {
            var bus = Bus.Factory.CreateUsingRabbitMq(sbc => {
                sbc.Host(new Uri("rabbitmq://localhost"), h => {
                    h.Username("guest");
                    h.Password("guest");
                });

                sbc.ReceiveEndpoint("new_queue", ep => {
                    ep.Consumer<MessageConsumer>();
                });
            });

            bus.Start();
            Console.WriteLine("Press any key to exist");
            Console.ReadKey();
            bus.Stop();
        }
    }
}
