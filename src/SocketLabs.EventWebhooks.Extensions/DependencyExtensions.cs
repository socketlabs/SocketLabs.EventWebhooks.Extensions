using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using SocketLabs.EventWebhooks.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DependencyExtensions
    {
        public static IServiceCollection AddWebhookEndpoints(this IServiceCollection services, IConfiguration configuration)
            => AddWebhookEndpoints(services, configuration, options => { });

        public static IServiceCollection AddInboundParseEndpoints(this IServiceCollection services, IConfiguration configuration)
            => AddInboundParseEndpoints(services, configuration, options => { });

        public static IServiceCollection AddWebhookEndpoints(this IServiceCollection services, IConfiguration configuration, Action<WebhookOptions> options)
        {
            var section = configuration.GetSection(nameof(WebhookOptions));
                        
            services.Configure<WebhookOptions>(options);
            services.Configure<WebhookOptions>(section);

            return services;
        }
        
        public static IServiceCollection AddInboundParseEndpoints(this IServiceCollection services, IConfiguration configuration, Action<InboundOptions> options)
        {
            var section = configuration.GetSection(nameof(InboundOptions));
            
            services.Configure<InboundOptions>(options);
            services.Configure<InboundOptions>(section);

            return services;
        }

        public static IApplicationBuilder UseWebhookEndpoints(this IApplicationBuilder applicationBuilder)
        {
            return applicationBuilder;
        }        
        
        public static IApplicationBuilder UseInboundEndpoints(this IApplicationBuilder applicationBuilder)
        {
            return applicationBuilder;
        }
    }
}
