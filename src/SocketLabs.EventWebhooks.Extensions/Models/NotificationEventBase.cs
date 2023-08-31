using System.Text.Json.Serialization;

namespace SocketLabs.EventWebhooks.Extensions.Models
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = nameof(Type))]
    [JsonDerivedType(typeof(EngagementEvent), typeDiscriminator: "Tracking")]
    [JsonDerivedType(typeof(ComplaintEvent), typeDiscriminator: "Complaint")]
    [JsonDerivedType(typeof(FailedEvent), typeDiscriminator: "Failed")]
    [JsonDerivedType(typeof(SentEvent), typeDiscriminator: "Delivered")]
    [JsonDerivedType(typeof(ValidationEvent), typeDiscriminator: "Validation")]
    [JsonDerivedType(typeof(QueuedEvent), typeDiscriminator: "Queued")]
    [JsonDerivedType(typeof(DeferredEvent), typeDiscriminator: "Deferred")]
    public class NotificationEventBase
    {
        public string? Type { get; set; }
        public DateTime DateTime { get; set; }
        public string? MailingId { get; set; }
        public string? MessageId { get; set; }
        public string? Address { get; set; }
        public int ServerId { get; set; }
        public string? SecretKey { get; set; }
        public Data? Data { get; set; }
        public string? WebhookEndpointName { get; set; }
    }


    public class Data
    {
        public Meta[] Meta { get; set; } = Array.Empty<Meta>();
        public string[] Tags { get; set; } = Array.Empty<string>();
    }

    public class Meta
    {
        public string Key { get; set; } = default!;
        public string Value { get; set; } = default!;
    }

}
