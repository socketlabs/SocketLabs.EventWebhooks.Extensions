namespace SocketLabs.EventWebhooks.Extensions.Configuration
{
    public class InboundOptions
    {
        public List<InboundEndpoint> InboundEndpoints { get; set; } = new();

        public bool TryGetWebhook(string name, out InboundEndpoint? inboundEndpoint)
        {
            inboundEndpoint = InboundEndpoints.FirstOrDefault(x => x.Name == name);

            return inboundEndpoint is not null;
        }
    }
}