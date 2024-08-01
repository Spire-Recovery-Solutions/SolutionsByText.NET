using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SolutionsByText.NET.Models.Responses.Subscriptions
{
    public class AddSubscriber
    {
        /// <summary>
        /// Gets or sets the unique identifier assigned to the message.
        /// </summary>
        [JsonPropertyName("messageId")]
        public string MessageId { get; set; }

        /// <summary>
        /// Gets or sets the phone number of the subscriber.
        /// </summary>
        [JsonPropertyName("msisdn")]
        public string Msisdn { get; set; }

        /// <summary>
        /// Gets or sets the PIN for the subscriber.
        /// </summary>
        [JsonPropertyName("pin")]
        public string Pin { get; set; }
    }
}
