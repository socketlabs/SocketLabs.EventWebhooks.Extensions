<img src="https://static.socketlabs.com/logos/logo-dark-sans-tag-507x64.png" alt="SocketLabs Logo" width="253" height="32" />  

[![Build status][build-status]][build]
# SocketLabs.EventWebhooks.Extensions
> Library to make consuming SocketLabs webhooks easier.

## Getting Started
### Prerequisites

* Visual Studio or VSCode
* .NET 8

### Usage

Import using dotnet CLI or the Package Manager console in Visual Studio

#### dotnet cli

```shell
dotnet add package SocketLabs.EventWebhooks.Extensions
```

#### Package Manager

```powershell
Install-Package SocketLabs.EventWebhooks.Extensions
```
## Event Webhooks

### Inject the webhook services

```csharp
var builder = WebApplication.CreateBuilder(args);

// Code removed for brevity ...

// Add the webhook endpoints
builder.Services.AddWebhookEndpoints(builder.Configuration);

// Add custom implementation of IWebhookEventHandler
builder.Services.AddSingleton<IWebhookEventHandler, WebhookEventHandler>();

```

### Add webhook configuration options

> [!NOTE]  
> `Name` can be any string. We've chosen a `Guid` for this example. The name is used in the endpoint URL you will configure in the portal.

#### appsettings.json
```javascript
{
  "WebhookOptions": {
    "WebhookEndpoints": [
      {
        "Name": "cc0b4dc6-d867-49f5-9d8e-8357997789af",
        "SecretKey": "Z123456AbcD1234563Ef"
      }
    ]
  }
}
```

### Configure Endpoint URL in portal

```
https://example.com/api/v1/webhookevents/cc0b4dc6-d867-49f5-9d8e-8357997789af
```

## Inbound Parse Webhooks

### Inject the webhook services

> [!IMPORTANT]  
> Kestrel's default [`MaxRequestBodySize`](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.server.kestrel.core.kestrelserverlimits.maxrequestbodysize?view=aspnetcore-8.0#microsoft-aspnetcore-server-kestrel-core-kestrelserverlimits-maxrequestbodysize) is 28.6MB which is smaller then our maximum email message of 50MB

```csharp
var builder = WebApplication.CreateBuilder(args);

// Code removed for brevity ...

// Add the webhook endpoints
builder.Services.AddInboundParseEndpoints(builder.Configuration);

// Add custom implementation of IParsedMessagesEventHandler
builder.Services.AddSingleton<IParsedMessagesEventHandler, ParsedMessageEventHandler>();

// Increase the max body size.
builder.WebHost.ConfigureKestrel(options =>
{
    options.Limits.MaxRequestBodySize = 50 * 1024 * 1024; //50Mib
});
```

### Add inbound configurations

#### appsettings.json
```javascript
{
  "InboundOptions": {
    "InboundEndpoints": [
      {
        "Name": "8c49fad7-7897-4cc7-bbd5-5c26d29dcb7b",
        "SecretKey": "Z123456AbcD1234563Ef"
      }
    ]
  }
}
```

### Configure Endpoint URL in portal

```
https://example.com/api/v1/parsedmessages/8c49fad7-7897-4cc7-bbd5-5c26d29dcb7b
```

### Release History

* 1.0.0 Initial Release

### License

[MIT License](LICENSE.md)

### Contributing

[Contributor Guidelines](CONTRIBUTING.md)

<!-- MARKDOWN LINKS & IMAGES -->
<!-- https://www.markdownguide.org/basic-syntax/#reference-style-links -->
[build-status]: https://dev.azure.com/socketlabs/Public%20Projects/_apis/build/status/SocketLabs.EventWebhooks.Extensions-CI?branchName=main
[build]: https://dev.azure.com/socketlabs/Public%20Projects/_build/latest?definitionId=170
