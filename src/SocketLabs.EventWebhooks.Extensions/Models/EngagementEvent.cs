﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocketLabs.EventWebhooks.Extensions.Models
{
    public class EngagementEvent : WebhookEventBase
    {
        public TrackingType TrackingType { get; set; }
        public string? ClientIp { get; set; }
        public string? Url { get; set; }
        public string? UserAgent { get; set; }
    }

    public enum TrackingType
    {
        Click = 0,
        Open = 1,
        Unsubscribe = 2
    }
}
