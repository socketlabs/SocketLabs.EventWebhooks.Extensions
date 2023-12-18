using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocketLabs.EventWebhooks.Extensions.Models.Events
{
    public class ComplaintEvent : WebhookEventBase
    {
        public string? FblType { get; set; }
        public string? UserAgent { get; set; }
        public string? From { get; set; }
        public string? To { get; set; }
        public int Length { get; set; }
    }
}
