using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SolutionsByText.NET.Models.Responses
{
    /// <summary>
    /// Represents the "data" object in the JSON response.
    /// This class contains information about the pagination and the event data.
    /// </summary>
    public class DeactivateEventData : PaginationData
    {
        /// <summary>
        /// The list of event data.
        /// </summary>
        [JsonPropertyName("data")]
        public List<EventData> EventData { get; set; }
    }
}