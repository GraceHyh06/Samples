using MassTransit;
using Samples.Messages;
using System;

namespace Samples.RabbitmqWithMasstransit.Publisher
{
    public class PublisherService
    {
        IBusControl _bus;
        public void Start()
        {
            Console.WriteLine("Publisher start.");
            _bus = Bus.Factory.CreateUsingRabbitMq(bc => bc.Host(new Uri("rabbitmq://localhost"), c => {
                c.Username("guest");
                c.Password("guest");
            }));
            _bus.Start();
            Console.WriteLine("输入发送到Rabbitmq的消息:");
            while(true)
            {
                var line = Console.ReadLine();
                _bus.Publish(new SimpleMessage { Greetings = $"输入的消息是{line}" });
            }
        }

        public void Stop()
        {
            Console.WriteLine("Publisher stop.");
            _bus.Stop();
        }
    }
}
