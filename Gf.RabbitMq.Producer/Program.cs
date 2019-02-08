#region Usings

using Gf.RabbitMq.Core.Components;

#endregion

namespace Gf.RabbitMq.Producer
{
    internal class Program
    {
        #region  Private Methods

        private static void Main()
        {
            var producer = new CoreProducer();
            producer.PublishMessage("hello world");
        }

        #endregion
    }
}