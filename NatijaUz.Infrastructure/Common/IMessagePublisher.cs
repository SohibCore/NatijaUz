namespace NatijaUz.Infrastructure.Common
{
    public interface IMessagePublisher
    {
        Task PublishAsync<T>(T message, string queueName, CancellationToken cancellation = default) where T : class;
    }
}
