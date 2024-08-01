using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using SolutionsByText.NET.Models.Requests.Reports;

namespace SolutionsByText.NET.Models.Responses.Reports
{
    /// <summary>
    /// Represents the data payload of inbound messages.
    /// </summary>
    public class InboundOutboundMessagesData : PaginationData
    {
        /// <summary>
        /// Gets or sets the list of inbound messages.
        /// </summary>
        [JsonPropertyName("data")]
        public List<WebhookMessage> Data { get; set; }
    }
}
