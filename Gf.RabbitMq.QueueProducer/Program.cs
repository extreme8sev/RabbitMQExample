using System;
using Gf.RabbitMq.Core.Components;

namespace Gf.RabbitMq.QueueProducer
{
    internal class Program
    {
        private static void Main()
        {
            var rabbitMqConnectionOptions = new RabbitMqConnectionOptions("localhost",
                                                                          2001);
            var coreQueueProducer = new CoreQueueProducer("queue",
                                                          rabbitMqConnectionOptions);

            do
            {
                Console.WriteLine("Enter the task's name:");
                var taskName = Console.ReadLine();
                coreQueueProducer.ProduceMessage(taskName);
                Console.WriteLine("Press any key to continue or press ESC to exit...");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
