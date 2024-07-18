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
    /// Represents the response received after confirming a brand subscriber.
    /// </summary>
    public class ConfirmBrandSubscriberResponse
    {
        /// <summary>
        /// Gets or sets the status of the confirmation operation.
        /// </summary>
        [JsonPropertyName("status")]
        public OperationStatus Status { get; set; }
    }
}
