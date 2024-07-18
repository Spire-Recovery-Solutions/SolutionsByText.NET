using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SolutionsByText.NET.Models.Requests
{
    /// <summary>
    /// Represents a request to confirm a subscriber's opt-in for a brand using a PIN.
    /// </summary>
    public class ConfirmBrandSubscriberRequest
    {
        /// <summary>
        /// Gets or sets the unique identifier of the brand.
        /// </summary>
        [JsonPropertyName("brandId")]
        public string BrandId { get; set; }

        /// <summary>
        /// Gets or sets the phone number of the subscriber.
        /// </summary>
        [JsonPropertyName("msisdn")]
        public string Msisdn { get; set; }

        /// <summary>
        /// Gets or sets the PIN provided by the subscriber.
        /// </summary>
        [JsonPropertyName("pin")]
        public string Pin { get; set; }
    }
}
