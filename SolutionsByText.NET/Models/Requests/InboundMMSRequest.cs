using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SolutionsByText.NET.Models.Requests
{
    /// <summary>
    /// Represents the payload for inbound MMS webhooks.
    /// </summary>
    public class InboundMMSRequest : InboundMessageRequest
    {
        [JsonPropertyName("Files")]
        public List<MediaFile> Files { get; set; }
    }
}
