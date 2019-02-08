#region Usings

using System;
using Gf.RabbitMq.Core.Components;

#endregion

namespace Gf.RabbitMq.QueueConsumer
{
    internal class Program
    {
        #region  Private Methods

        private static void Main()
        {
            var rabbitMqConnectionOptions = new RabbitMqConnectionOptions("localhost",
                                                                          2001);
            var consumerId = Guid.NewGuid().ToString();

            var queueConsumer = new CoreQueueConsumer(consumerId,
                                                      "queue",
                                                      rabbitMqConnectionOptions);

            queueConsumer.StartConsuming();
        }

        #endregion
    }
}