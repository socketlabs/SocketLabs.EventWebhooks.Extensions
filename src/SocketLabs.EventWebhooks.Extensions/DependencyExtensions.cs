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

        public static IServiceCollection AddWebhookEndpoints(this IServiceCollection services, IConfiguration configuration, Action<WebhookOptions> options)
        {
            var section = configuration.GetSection(nameof(WebhookOptions));
            //var instance = section.Get<WebhookOptions>();

            //if (instance is not null)
            //    options.Invoke(instance);
                        
            services.Configure<WebhookOptions>(options);
            services.Configure<WebhookOptions>(section);

            //services.PostConfigure(options);

            return services;
        }

        public static IApplicationBuilder UseWebhookEndpoints(this IApplicationBuilder applicationBuilder)
        {
            return applicationBuilder;
        }
    }
}
