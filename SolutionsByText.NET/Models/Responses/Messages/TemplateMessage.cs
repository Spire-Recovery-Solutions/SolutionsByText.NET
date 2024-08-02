using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SolutionsByText.NET.Models.Responses.Messages
{
    public class TemplateMessage
    {
        /// <summary>
        /// Gets or sets the unique identifier assigned to the sent message.
        /// </summary>
        [JsonPropertyName("messageId")]
        public string? MessageId { get; set; }
    }
}
