using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace NatijaUz.Infrastructure.Common
{
    public class RabbitMqPublisher : IMessagePublisher, IAsyncDisposable
    {
        private readonly IConnection _connection;
        private readonly IChannel _channel;

        public RabbitMqPublisher(IConnection connection, IChannel channel)
        {
            _connection = connection;
            _channel = channel;
        }

        public async Task PublishAsync<T>(T message, string queueName, CancellationToken cancellationToken = default) where T : class
        {
            await _channel.QueueDeclareAsync( //queue mavjud yoki yo'qligini tekshirish va yaratish
                queue: queueName,
                durable: true,
                exclusive: false,
                autoDelete: false,
                cancellationToken: cancellationToken);

            var json = JsonSerializer.Serialize(message);
            var body = Encoding.UTF8.GetBytes(json);

            await _channel.BasicPublishAsync( // message ni queue ga yuborish
                exchange: string.Empty,
                routingKey: queueName,
                body: body,
                cancellationToken: cancellationToken);
        }

        public async ValueTask DisposeAsync()
        {
            await _channel.CloseAsync();
            await _connection.CloseAsync();
        }
    }
}
