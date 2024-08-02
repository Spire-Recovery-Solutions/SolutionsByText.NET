using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SolutionsByText.NET.Models.Responses.Reports
{
    public class CarrierChange
    {
        /// <summary>
        /// The date and time of the process.
        /// </summary>
        [JsonPropertyName("processDateTime")]
        public DateTime ProcessDateTime { get; set; }

        /// <summary>
        /// The ID of the old carrier.
        /// </summary>
        [JsonPropertyName("oldCarrierId")]
        public string? OldCarrierId { get; set; }

        /// <summary>
        /// The name of the old carrier.
        /// </summary>
        [JsonPropertyName("oldCarrierName")]
        public string? OldCarrierName { get; set; }

        /// <summary>
        /// The ID of the new carrier.
        /// </summary>
        [JsonPropertyName("newCarrierId")]
        public string? NewCarrierId { get; set; }

        /// <summary>
        /// The country code.
        /// </summary>
        [JsonPropertyName("countryCode")]
        public string? CountryCode { get; set; }

        /// <summary>
        /// The name of the new carrier.
        /// </summary>
        [JsonPropertyName("newCarrierName")]
        public string? NewCarrierName { get; set; }

        /// <summary>
        /// The mobile status.
        /// </summary>
        [JsonPropertyName("mobileStatus")]
        public string? MobileStatus { get; set; }

        /// <summary>
        /// The event description.
        /// </summary>
        [JsonPropertyName("event")]
        public string? Event { get; set; }

        /// <summary>
        /// The date of the event.
        /// </summary>
        [JsonPropertyName("eventDate")]
        public DateTime EventDate { get; set; }
    }
}
