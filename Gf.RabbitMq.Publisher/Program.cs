using System;

namespace Gf.RabbitMq.Publisher
{
    internal class Program
    {
        private static void Main()
        {
            var publisher = new Core.Components.Publisher();
            publisher.PublishMessage("Hello World!",
                                     "helloworld");
            Console.ReadLine();
        }
    }
}
