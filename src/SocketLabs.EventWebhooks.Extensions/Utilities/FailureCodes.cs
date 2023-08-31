using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocketLabs.EventWebhooks.Extensions.Utilities
{
    public class FailureCodes
    {
        private static Dictionary<int, string> _lookupCodes = new Dictionary<int, string>()
        {
            {1002, "Your message was rejected because it was associated with a blacklist"},
            {1003, "Your message was rejected because it was associated with a blacklist"},
            {1004, "Your message was rejected due to its content"},
            {1006, "Too many connections in a period of time"},
            {1007, "A virus was detected in your message"},
            {1011, "Challenge responses requests"},
            {1999, "Your message was rejected for a reason not specified above Permanent Failures"},
            {2001, "The email address is invalid"},
            {2002, "The domain of the email address is invalid"},
            {2003, "The email address is not in a valid format"},
            {2004, "The email address is no longer valid"},
            {2999, "The email address was rejected for a reason not specified above Temporary Failures"},
            {3001, "The recipient's mailbox is full or over quota"},
            {3002, "Recipient email account is inactive/disabled"},
            {3003, "Recipient’s server continuously asked us to “try later”"},
            {3999, "The email address was rejected for a reason not specified above Communication Failures"},
            {4001, "Recipient’s server too busy"},
            {4002, "Protocol error, invalid command or timeout"},
            {4003, "Unable to connect to recipient's mail server"},
            {4004, "Recipient’s server rejected message as too old"},
            {4006, "Your message was rejected because the receiving server is not accepting mail for the destination domain"},
            {4999, "A system, network or protocol error prevented the delivery of your message for a reason not specified above"},
            {5001, "Out of office / Auto-reply 5999 An informational message was received other than for a reason specified above"},
            {9999, "The reason for the failure is unknown."}
        };

        public static string? Lookup(int code)
        {
            if (_lookupCodes.TryGetValue(code, out string? error))
            {
                return error;
            }
            else
            {
                return $"Unknown error code: {code}";
            }
        }
    }
}
