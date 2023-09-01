using System;

namespace SocketLabs.EventWebhooks.Extensions.Models
{
    public class QueuedEvent : WebhookEventBase
    {
        public string? FromAddress { get; set; }
        public string? SubjectLine { get; set; }
        public int MessageSize { get; set; }
        public string? ClientIp { get; set; }
        public string? Url { get; set; }
        public string? UserAgent { get; set; }
    }
}