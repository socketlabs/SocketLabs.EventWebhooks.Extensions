using SocketLabs.EventWebhooks.Extensions.Models.Events;
using SocketLabs.EventWebhooks.Extensions.Models.Inbound;

namespace SocketLabs.EventWebhooks.Extensions
{
    public interface IParsedMessagesEventHandler
    {
        Task ProcessAsync(ValidationEvent webhookEvent);
        Task ProcessAsync(MessageParsedEvent webhookEvent);
    }
}