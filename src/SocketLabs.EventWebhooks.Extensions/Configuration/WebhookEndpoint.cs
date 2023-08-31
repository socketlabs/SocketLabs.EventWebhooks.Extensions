using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketLabs.EventWebhooks.Extensions.Configuration
{
    public class WebhookEndpoint
    {
        public string? Name { get; set; }
        public string? SecretKey { get; set; }

    }
}
