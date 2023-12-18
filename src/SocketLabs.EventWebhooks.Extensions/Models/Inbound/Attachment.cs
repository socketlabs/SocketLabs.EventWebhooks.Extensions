namespace SocketLabs.EventWebhooks.Extensions.Models.Inbound
{
    public class Attachment
    {
        public string? Name { get; set; }
        public byte[]? Content { get; set; }
        public string? ContentId { get; set; }
        public string? ContentType { get; set; }
        public IEnumerable<CustomHeader>? CustomHeaders { get; set; }
    }
}
