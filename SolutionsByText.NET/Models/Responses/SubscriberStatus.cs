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
    /// Represents the status of a single subscriber.
    /// </summary>
    public class SubscriberStatus
    {
        /// <summary>
        /// Gets or sets the phone number of the subscriber.
        /// </summary>
        [JsonPropertyName("msisdn")]
        public string Msisdn { get; set; }

        /// <summary>
        /// Gets or sets the status of the subscriber.
        /// </summary>
        [JsonPropertyName("status")]
        public SubscriptionStatus Status { get; set; }
    }
}
