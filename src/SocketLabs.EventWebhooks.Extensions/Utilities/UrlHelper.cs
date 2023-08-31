using System;
using System.Collections.Generic;
using System.Text;

namespace SocketLabs.EventWebhooks.Extensions.Utilities
{
    public class UrlHelper
    {
        public static string? AddQueryStrings(string? url, Dictionary<string, string> keyValuePairs)
        {
            url ??= string.Empty;
            var sb = new StringBuilder(url);

            bool containsParams = url.LastIndexOf('?') > 0;

            foreach (var item in keyValuePairs)
            {
                if (string.IsNullOrWhiteSpace(item.Key)) continue;
                if (string.IsNullOrWhiteSpace(item.Value)) continue;

                string? value = Uri.EscapeDataString(item.Value);

                if (containsParams)
                {
                    sb.AppendFormat("&{0}={1}", item.Key, value);
                }
                else
                {
                    sb.AppendFormat("?{0}={1}", item.Key, value);
                }

                containsParams = true;
            }

            return sb.ToString();
        }
    }
}