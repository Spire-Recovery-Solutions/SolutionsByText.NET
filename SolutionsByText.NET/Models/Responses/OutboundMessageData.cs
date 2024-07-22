using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SolutionsByText.NET.Models.Responses
{
    public class OutboundMessageData : PaginationData
    {
        /// <summary>
        /// Gets or sets the list of outbound messages.
        /// </summary>
        [JsonPropertyName("data")]
        public List<WebhookMessage> Messages { get; set; }
    }
}
