using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SolutionsByText.NET.Models.Requests
{
    
    /// <summary>
    /// Represents the payload for outbound message status webhooks.
    /// </summary>
    public class OutboundMessageStatusRequest : WebhookPayload
    {
        [JsonPropertyName("Payload")]
        public OutboundMessageStatusData Payload { get; set; }
    }
}
