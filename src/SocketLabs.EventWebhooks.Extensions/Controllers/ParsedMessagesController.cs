using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SocketLabs.EventWebhooks.Extensions.Configuration;
using SocketLabs.EventWebhooks.Extensions.Models.Events;
using SocketLabs.EventWebhooks.Extensions.Models.Inbound;

namespace SocketLabs.EventWebhooks.Extensions.Controllers
{

    [Route("api/v1/[controller]")]
    [ApiController]
    public class ParsedMessagesController : ControllerBase
    {
        private readonly IParsedMessagesEventHandler _parsedMessagesEventHandler;
        private readonly ILogger<ParsedMessagesController> _logger;
        private readonly InboundOptions _options;

        public ParsedMessagesController(
            IParsedMessagesEventHandler parsedMessagesEventHandler,
            ILogger<ParsedMessagesController> logger,
            IOptionsMonitor<InboundOptions> options
            )
        {
            _parsedMessagesEventHandler = parsedMessagesEventHandler;
            _logger = logger;
            _options = options.CurrentValue;
        }


        [HttpPost]
        [Route("{id}")]
        public async Task<IActionResult> Post(WebhookEventBase webhookEvent, string id)
        {
            if (!_options.TryGetWebhook(id, out var endpoint) || endpoint?.SecretKey != webhookEvent.SecretKey)
            {
                return Unauthorized();
            }

            try
            {
                webhookEvent.WebhookEndpointName = id;

                Task result = webhookEvent switch
                {
                    MessageParsedEvent eventItem => ProcessEvent(eventItem),
                    ValidationEvent eventItem => ProcessEvent(eventItem),
                    _ => throw new InvalidOperationException("Unable to convert event type.")
                };

                await result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unable to process webhook event.");

                return BadRequest();
            }

            return Ok();
        }

        private async Task ProcessEvent(MessageParsedEvent webhookEvent)
        {
            webhookEvent.Type = "MessageParsed";
            webhookEvent.MailingId = webhookEvent.Message?.MailingId;
            webhookEvent.MessageId = webhookEvent.Message?.MessageId;

            var dateHeader = webhookEvent.Message?
                .CustomHeaders
                .FirstOrDefault(x => x.Name is not null && x.Name.Equals("Date", StringComparison.OrdinalIgnoreCase));

            if (DateTime.TryParse(dateHeader?.Value, out var date))
            {
                webhookEvent.DateTime = date;
            }

            _logger.LogTrace("Begin processing parsed message for {ServerId}", webhookEvent.ServerId);
            await _parsedMessagesEventHandler.ProcessAsync(webhookEvent);
        }

        private async Task ProcessEvent(ValidationEvent webhookEvent)
        {
            webhookEvent.Type = "Validation";
            _logger.LogTrace("Begin processing validation message for {ServerId}", webhookEvent.ServerId);
            await _parsedMessagesEventHandler.ProcessAsync(webhookEvent);
        }
    }
}
