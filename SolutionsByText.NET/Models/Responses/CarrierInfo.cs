using SolutionsByText.NET.Models.Requests.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SolutionsByText.NET.Models.Responses
{
      /// <summary>
    /// Represents carrier information for a phone number.
    /// </summary>
    public class CarrierInfo
    {
        /// <summary>
        /// Gets or sets the name of the carrier.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the type of the carrier.
        /// </summary>
        [JsonPropertyName("type")]
        public CarrierType Type { get; set; }
    }

}
