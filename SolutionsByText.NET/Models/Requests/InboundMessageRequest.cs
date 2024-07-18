using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SolutionsByText.NET.Models.Requests
{
    public class InboundMessageRequest
    {
        [JsonPropertyName("Payload")]
        public InboundMessageData Payload { get; set; }
    }
}
