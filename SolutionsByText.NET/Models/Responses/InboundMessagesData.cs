using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SolutionsByText.NET.Models.Responses
{
    /// <summary>
    /// Represents the data payload of inbound messages.
    /// </summary>
    public class InboundMessagesData : PaginationData
    {
        /// <summary>
        /// Gets or sets the list of inbound messages.
        /// </summary>
        [JsonPropertyName("data")]
        public List<WebhookMessage> Data { get; set; }
    }
}
