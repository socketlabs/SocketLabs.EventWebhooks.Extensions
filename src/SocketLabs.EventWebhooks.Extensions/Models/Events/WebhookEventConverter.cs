using System.Text.Json;
using System.Text.Json.Serialization;
using SocketLabs.EventWebhooks.Extensions.Models.Inbound;

namespace SocketLabs.EventWebhooks.Extensions.Models.Events
{
    internal class WebhookEventConverter : JsonConverter<WebhookEventBase>
    {
        public override WebhookEventBase? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            Utf8JsonReader readerClone = reader;

            if (JsonDocument.TryParseValue(ref readerClone, out var document))
            {
                if (document.RootElement.TryGetProperty("Type", out var element))
                {
                    var typeDiscriminator = element.GetString();

                    WebhookEventBase? webhookEvent = typeDiscriminator switch
                    {
                        "Complaint" => JsonSerializer.Deserialize<ComplaintEvent>(ref reader),
                        "Deferred" => JsonSerializer.Deserialize<DeferredEvent>(ref reader),
                        "Tracking" => JsonSerializer.Deserialize<EngagementEvent>(ref reader),
                        "Failed" => JsonSerializer.Deserialize<FailedEvent>(ref reader),
                        "Queued" => JsonSerializer.Deserialize<QueuedEvent>(ref reader),
                        "Delivered" => JsonSerializer.Deserialize<SentEvent>(ref reader),
                        "Validation" => JsonSerializer.Deserialize<ValidationEvent>(ref reader),
                        _ => throw new JsonException("Unknown event type")
                    };

                    return webhookEvent;
                }
            }

            // Try to parse it as a message parsed event.
            
            var parsedEvent = JsonSerializer.Deserialize<MessageParsedEvent>(ref reader);

            if (parsedEvent != null) 
                return parsedEvent;

            throw new JsonException("Unknown event type");
        }

        public override void Write(Utf8JsonWriter writer, WebhookEventBase value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value, options);
        }
    }
}
