using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SocketLabs.EventWebhooks.Extensions.Models.Events
{
    public class FailedEvent : WebhookEventBase
    {
        public string? DiagnosticCode { get; set; }
        public string? BounceStatus { get; set; }
        public string? FromAddress { get; set; }
        public int FailureCode { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public FailureType FailureType { get; set; }
        public string? Reason { get; set; }
        public string? RemoteMta { get; set; }
    }

    public enum FailureType
    {
        Temporary = 0,
        Permanent = 1,
        Suppressed = 2
    }
}
