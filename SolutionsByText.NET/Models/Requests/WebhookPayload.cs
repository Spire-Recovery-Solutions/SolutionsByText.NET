using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SolutionsByText.NET.Models.Requests
{
    /// <summary>
    /// Base class for all webhook payloads.
    /// </summary>
    public abstract class WebhookPayload
    {
        [JsonPropertyName("Type")]
        public string Type { get; set; }
    }
}
