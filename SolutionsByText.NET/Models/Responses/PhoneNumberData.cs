using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SolutionsByText.NET.Models.Responses
{
    /// <summary>
    /// Represents data for a single phone number.
    /// </summary>
    public class PhoneNumberData
    {
        /// <summary>
        /// Gets or sets the phone number.
        /// </summary>
        [JsonPropertyName("msisdn")]
        public string Msisdn { get; set; }

        /// <summary>
        /// Gets or sets the carrier information.
        /// </summary>
        [JsonPropertyName("carrier")]
        public CarrierInfo Carrier { get; set; }
    }
}
