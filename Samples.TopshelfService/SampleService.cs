using System;

namespace Samples.TopshelfService
{
    public class SampleService
    {
        public void Start() {
            Console.WriteLine("Service start...");
        }

        public void Stop() {
            Console.WriteLine("Service stop.");
        }
    }
}