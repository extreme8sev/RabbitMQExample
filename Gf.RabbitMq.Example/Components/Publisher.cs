#region Usings

using System;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

#endregion

namespace Gf.RabbitMq.Example.Components
{
    public class Publisher
    {
        #region  Public Methods

        public void PublishMessage(string message,
                                   string routingKey)
        {
            var factory = new ConnectionFactory {HostName = "localhost", Port = 2001};
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare("hello",
                                         false,
                                         false,
                                         false,
                                         null);

                    var body = Encoding.UTF8.GetBytes(message);
                    channel.BasicPublish("",
                                         routingKey,
                                         null,
                                         body);
                }
            }
        }

        #endregion
    }

    public class Consumer
    {
        public void ConsumeMessage(string routingKey)
        {
            var factory = new ConnectionFactory {HostName = "localhost", Port = 2001};
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: "hello",
                                         durable: false,
                                         exclusive: false,
                                         autoDelete: false,
                                         arguments: null);

                    var consumer = new EventingBasicConsumer(channel);
                    consumer.Received += (model,
                                          ea) =>
                    {
                        var body = ea.Body;
                        var message = Encoding.UTF8.GetString(body);
                        Console.WriteLine($" [x] received {message}");
                    };

                    channel.BasicConsume("hello",
                                         false,
                                         consumer);
                }
            }
        }
    }
}