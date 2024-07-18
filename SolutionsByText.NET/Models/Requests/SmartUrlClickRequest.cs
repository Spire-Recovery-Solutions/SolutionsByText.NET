using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SolutionsByText.NET.Models.Requests
{
       /// <summary>
    /// Represents the payload for SmartURL click webhooks.
    /// </summary>
    public class SmartUrlClickRequest : WebhookPayload
    {
        [JsonPropertyName("Payload")]
        public SmartUrlClickData Payload { get; set; }
    }
}
