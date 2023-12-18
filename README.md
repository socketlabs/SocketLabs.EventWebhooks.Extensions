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

Inject the webhook services

```csharp
var builder = WebApplication.CreateBuilder(args);

// Code removed for brevity ...

// Add the webhook endpoints
builder.Services.AddWebhookEndpoints(builder.Configuration);

// Add custom implementation of IWebhookEventHandler
builder.Services.AddSingleton<IWebhookEventHandler, WebhookEventHandler>();

```

Add webhook configurations

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

Configure Endpoint URL in portal

```
https://example.com/api/v1/webhookevents/cc0b4dc6-d867-49f5-9d8e-8357997789af
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