#region Usings

using System;
using Gf.RabbitMq.Core.Components;

#endregion

namespace Gf.RabbitMq.Consumer
{
    internal class Program
    {
        #region  Private Methods

        private static void Main()
        {
            var consumer = new CoreConsumer();
            consumer.ConsumeMessage();
        }

        #endregion
    }
}