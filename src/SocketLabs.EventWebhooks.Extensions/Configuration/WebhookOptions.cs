using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketLabs.EventWebhooks.Extensions.Configuration
{
    public class WebhookOptions
    {
        public List<WebhookEndpoint> WebhookEndpoints { get; set; } = new();

        public bool TryGetWebhook(string name, out WebhookEndpoint? webhookEndpoint)
        {
            webhookEndpoint = WebhookEndpoints.FirstOrDefault(x => x.Name == name);

            return webhookEndpoint is not null;
        }
    }
}
