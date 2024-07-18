using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SolutionsByText.NET.Models.Responses
{
   
    /// <summary>
    /// Represents the response received after requesting outbound messages.
    /// </summary>
    public class GetOutboundMessagesResponse
    {
        /// <summary>
        /// Gets or sets the list of outbound messages.
        /// </summary>
        [JsonPropertyName("messages")]
        public List<OutboundMessage> Messages { get; set; }
    }

}
