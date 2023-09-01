using System;

namespace SocketLabs.EventWebhooks.Extensions.Models
{
    public class DeferredEvent : WebhookEventBase
    {
        public string? FromAddress { get; set; }
        public int DeferralCode { get; set; }
        public string? Reason { get; set; }
        public string? ClientIp { get; set; }
        public string? Url { get; set; }
        public string? UserAgent { get; set; }
    }
}