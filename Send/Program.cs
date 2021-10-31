using RabbitMQ.Client;
using System.Text;

class Send
{
    public static void Main()
    {
        var factory = new ConnectionFactory() { HostName = "localhost" };
        using var connection = factory.CreateConnection();
        using var channel = connection.CreateModel();
        channel.QueueDeclare(queue: "app",
                             durable: false,
                             exclusive: false,
                             autoDelete: false,
                             arguments: null);
        int count = 0;
        while (true)
        {
            string message = $"{count++} Hello World!";
            var body = Encoding.UTF8.GetBytes(message);

            channel.BasicPublish(exchange: "",
                                 routingKey: "app",
                                 basicProperties: null,
                                 body: body);
            Console.WriteLine($" [x] Sent {message}");

            Thread.Sleep(1000);
        }
    }
}