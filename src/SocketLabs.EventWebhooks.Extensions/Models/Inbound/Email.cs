namespace SocketLabs.EventWebhooks.Extensions.Models.Inbound
{
    public class Email
    {
        public required string EmailAddress { get; set; }
        public string? FriendlyName { get; set; }
    }
}
