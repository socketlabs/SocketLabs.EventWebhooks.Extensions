using SocketLabs.EventWebhooks.Extensions.Models.Events;

namespace SocketLabs.EventWebhooks.Extensions.Models.Inbound
{
    public class MessageParsedEvent : WebhookEventBase
    {
        public string? ErrorLog { get; set; }
        public string? InboundIpAddress { get; set; }
        public string? InboundMailFrom { get; set; }
        public string? InboundRcptTo { get; set; }
        public string? SpamDetails { get; set; }
        public double SpamScore { get; set; }
        public Message? Message { get; set; }
    }
}
