using Topshelf;

namespace Samples.TopshelfService
{
    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(x =>{
                x.Service<SampleService>(s => {
                    s.ConstructUsing(() => new SampleService());
                    s.WhenStarted(p => p.Start());
                    s.WhenStopped(p => p.Stop());
                });
            });
        }
    }
}
