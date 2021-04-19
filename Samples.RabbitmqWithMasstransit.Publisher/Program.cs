using MassTransit;
using Samples.Messages;
using System;
using System.Threading.Tasks;

namespace Samples.RabbitmqWithMasstransit.Publisher
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var bus = Bus.Factory.CreateUsingRabbitMq(sbc => {
                sbc.Host(new Uri("rabbitmq://localhost"), h => {
                    h.Username("guest");
                    h.Password("guest");
                });
            });

            bus.Start();
            Console.WriteLine("Input the line to send to RabbitMq:");
            while (true)
            {
                var line =Console.ReadLine();
                if (line == "exit")
                    break;
                await bus.Publish(new SimpleMessage { Greetings = line });
            }
            bus.Stop();
        }
    }
}
