
using System;
using System.Threading.Tasks;
using Topshelf;

namespace Samples.RabbitmqWithMasstransit.Publisher
{
    class Program
    {
        static async Task Main(string[] args)
        {
            HostFactory.Run(x => {
                x.Service<PublisherService>(sc => {
                    sc.ConstructUsing(name => new PublisherService());
                    sc.WhenStarted(s => s.Start());
                    sc.WhenStopped(s => s.Stop());
                });
            });
        }
    }
}
