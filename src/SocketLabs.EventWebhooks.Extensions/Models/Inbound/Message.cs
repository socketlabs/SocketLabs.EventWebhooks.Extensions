namespace SocketLabs.EventWebhooks.Extensions.Models.Inbound
{
    public class Message
    {
        public IEnumerable<Email> To { get; set; } = Array.Empty<Email>();
        public Email? From { get; set; }
        public string? Subject { get; set; }
        public string? TextBody { get; set; }
        public string? HtmlBody { get; set; }
        public string? MessageId { get; set; }
        public string? MailingId { get; set; }
        public string? TextCharSet { get; set; }
        public string? HtmlCharSet { get; set; }
        public IEnumerable<CustomHeader> CustomHeaders { get; set; } = Array.Empty<CustomHeader>();
        public IEnumerable<Email>? CC { get; set; }
        public IEnumerable<Email>? BCC { get; set; }
        public Email? ReplyTo { get; set; }
        public IEnumerable<Attachment> Attachments { get; set; } = Array.Empty<Attachment>();
        public IEnumerable<Attachment> EmbeddedMedia { get; set; } = Array.Empty<Attachment>();
    }
}
