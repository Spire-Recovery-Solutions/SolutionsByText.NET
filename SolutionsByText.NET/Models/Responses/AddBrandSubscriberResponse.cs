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
    /// Represents the response received after adding a brand subscriber.
    /// </summary>
    public class AddBrandSubscriberResponse
    {
        /// <summary>
        /// Gets or sets the unique identifier assigned to the new subscriber.
        /// </summary>
        [JsonPropertyName("subscriberId")]
        public string SubscriberId { get; set; }

        /// <summary>
        /// Gets or sets the status of the add operation.
        /// </summary>
        [JsonPropertyName("status")]
        public OperationStatus Status { get; set; }
    }
}
