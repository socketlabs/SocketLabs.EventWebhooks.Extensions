using SocketLabs.EventWebhooks.Extensions.Models.Events;

namespace SocketLabs.EventWebhooks.Extensions
{
    public interface IWebhookEventHandler
    {
        Task ProcessAsync(ComplaintEvent webhookEvent);
        Task ProcessAsync(DeferredEvent webhookEvent);
        Task ProcessAsync(EngagementEvent webhookEvent);
        Task ProcessAsync(FailedEvent webhookEvent);
        Task ProcessAsync(QueuedEvent webhookEvent);
        Task ProcessAsync(SentEvent webhookEvent);
        Task ProcessAsync(ValidationEvent webhookEvent) => Task.CompletedTask;
    }
}