using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using SolutionsByText.NET.Models.Responses.Enums;

namespace SolutionsByText.NET.Models.Responses
{
      /// <summary>
    /// Represents the response received after sending a message.
    /// </summary>
    public class SendMessageResponse
    {
        /// <summary>
        /// Gets or sets the unique identifier assigned to the sent message.
        /// </summary>
        [JsonPropertyName("messageId")]
        public string MessageId { get; set; }

        /// <summary>
        /// Gets or sets the status of the sent message.
        /// </summary>
        [JsonPropertyName("status")]
        public MessageStatus Status { get; set; }
    }
}
