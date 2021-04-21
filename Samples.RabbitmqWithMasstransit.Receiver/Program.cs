using Topshelf;

namespace Samples.RabbitmqWithMasstransit.Receiver
{
    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(x => {
                x.Service<ReceiverService>(sc => {
                    sc.ConstructUsing(name => new ReceiverService());
                    sc.WhenStarted(s => s.Start());
                    sc.WhenStopped(s => s.Stop());
                });
            });
        }
    }
}
