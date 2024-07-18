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
        [JsonPropertyName("messageId")]
        public string MessageId { get; set; }
    }
}