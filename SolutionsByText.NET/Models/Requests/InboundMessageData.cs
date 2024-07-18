using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SolutionsByText.NET.Models.Requests
{
     public class InboundMessageData
    {
        [JsonPropertyName("AccountId")]
        public string AccountId { get; set; }

        [JsonPropertyName("Message")]
        public string Message { get; set; }

        [JsonPropertyName("OriginalMessage")]
        public string OriginalMessage { get; set; }

        [JsonPropertyName("Msisdn")]
        public string Msisdn { get; set; }

        [JsonPropertyName("GroupName")]
        public string GroupName { get; set; }

        [JsonPropertyName("GroupId")]
        public string GroupId { get; set; }

        [JsonPropertyName("CommunicationCode")]
        public string CommunicationCode { get; set; }

        [JsonPropertyName("MessageType")]
        public string MessageType { get; set; }

        [JsonPropertyName("ReceivedTime")]
        public DateTime ReceivedTime { get; set; }

        [JsonPropertyName("Properties")]
        public List<Property> Properties { get; set; }

        [JsonPropertyName("ReferenceId")]
        public string ReferenceId { get; set; }

        [JsonPropertyName("MessageId")]
        public string MessageId { get; set; }
    }
}
