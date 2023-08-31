using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SocketLabs.EventWebhooks.Extensions.Configuration;
using SocketLabs.EventWebhooks.Extensions.Models;

namespace SocketLabs.EventWebhooks.Extensions.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class WebhookEventsController : ControllerBase
    {
        private readonly IWebhookEventHandler _webhookEventHandler;
        private readonly ILogger<WebhookEventsController> _logger;
        private readonly WebhookOptions _options;

        public WebhookEventsController(
            IWebhookEventHandler webhookEventHandler,
            ILogger<WebhookEventsController> logger,
            IOptionsMonitor<WebhookOptions> options
            )
        {
            _webhookEventHandler = webhookEventHandler;
            _logger = logger;
            _options = options.CurrentValue;
        }

        [HttpPost]
        [Route("{id}")]
        public async Task<IActionResult> Post(NotificationEventBase webhookEvent, string id)
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
                    ComplaintEvent eventItem => ProcessEvent(eventItem),
                    DeferredEvent eventItem => ProcessEvent(eventItem),
                    EngagementEvent eventItem => ProcessEvent(eventItem),
                    FailedEvent eventItem => ProcessEvent(eventItem),
                    QueuedEvent eventItem => ProcessEvent(eventItem),
                    SentEvent eventItem => ProcessEvent(eventItem),
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

        private async Task ProcessEvent(ComplaintEvent webhookEvent)
        {
            webhookEvent.Type = "Complaint";
            _logger.LogTrace("Begin processing webhook event for {SystemMessageId}", webhookEvent.MessageId);
            await _webhookEventHandler.ProcessAsync(webhookEvent);
        }

        private async Task ProcessEvent(DeferredEvent webhookEvent)
        {
            webhookEvent.Type = "Deferred";
            _logger.LogTrace("Begin processing webhook event for {SystemMessageId}", webhookEvent.MessageId);
            await _webhookEventHandler.ProcessAsync(webhookEvent);
        }

        private async Task ProcessEvent(EngagementEvent webhookEvent)
        {
            webhookEvent.Type = "Tracking";
            _logger.LogTrace("Begin processing webhook event for {SystemMessageId}", webhookEvent.MessageId);
            await _webhookEventHandler.ProcessAsync(webhookEvent);
        }

        private async Task ProcessEvent(FailedEvent webhookEvent)
        {
            webhookEvent.Type = "Failed";
            _logger.LogTrace("Begin processing webhook event for {SystemMessageId}", webhookEvent.MessageId);
            await _webhookEventHandler.ProcessAsync(webhookEvent);
        }

        private async Task ProcessEvent(QueuedEvent webhookEvent)
        {
            webhookEvent.Type = "Queued";
            _logger.LogTrace("Begin processing webhook event for {SystemMessageId}", webhookEvent.MessageId);
            await _webhookEventHandler.ProcessAsync(webhookEvent);
        }

        private async Task ProcessEvent(SentEvent webhookEvent)
        {
            webhookEvent.Type = "Delivered";
            _logger.LogTrace("Begin processing webhook event for {SystemMessageId}", webhookEvent.MessageId);
            await _webhookEventHandler.ProcessAsync(webhookEvent);
        }

        private async Task ProcessEvent(ValidationEvent webhookEvent)
        {
            webhookEvent.Type = "Validation";
            _logger.LogTrace("Begin processing webhook event for {SystemMessageId}", webhookEvent.MessageId);
            await _webhookEventHandler.ProcessAsync(webhookEvent);
        }
    }
}