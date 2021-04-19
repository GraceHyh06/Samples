using MassTransit;
using Samples.Messages;
using System;
using System.Threading.Tasks;

namespace Samples.RabbitmqWithMasstransit.Receiver
{
    public class MessageConsumer : IConsumer<SimpleMessage>
    {
        public async Task Consume(ConsumeContext<SimpleMessage> message)
        {
            await Console.Out.WriteLineAsync($"Received: {message.Message.Greetings}");
        }
    }
}