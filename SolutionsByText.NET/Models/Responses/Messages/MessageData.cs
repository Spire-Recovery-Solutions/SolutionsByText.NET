using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SolutionsByText.NET.Models.Responses.Messages
{
    /// <summary>
    /// Represents the data part of the response containing the message ID.
    /// </summary>
    public class MessageData
    {
        /// <summary>
        /// Gets or sets the unique identifier for the sent message.
        /// </summary>
        [JsonPropertyName("messageId")]
        public string MessageId { get; set; }
    }
}
