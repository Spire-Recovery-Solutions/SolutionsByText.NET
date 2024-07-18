using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SolutionsByText.NET.Models.Responses
{
    /// <summary>
    /// Represents the response for getting deactivation events.
    /// Inherits common response properties from the BaseResponse class.
    /// </summary>
    public class GetDeactivationEventsResponse : BaseResponse
    {
        /// <summary>
        /// Gets or sets the data for the deactivation events.
        /// </summary>
        [JsonPropertyName("data")]
        public DeactivateEventData Data { get; set; }
    }
}
