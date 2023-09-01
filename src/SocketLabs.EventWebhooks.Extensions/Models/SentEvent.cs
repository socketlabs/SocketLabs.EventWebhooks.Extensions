using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocketLabs.EventWebhooks.Extensions.Models
{
    public class SentEvent : WebhookEventBase
    {
        public string? Response { get; set; }
        public string? LocalIp { get; set; }
        public string? RemoteMta { get; set; }
    }
}
