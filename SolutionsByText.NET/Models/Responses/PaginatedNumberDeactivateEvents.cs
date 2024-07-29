using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SolutionsByText.NET.Models.Responses
{
    public class PaginatedNumberDeactivateEvents : PaginationData
    {
        /// <summary>
        /// Gets or sets the collection of Carrier items.
        /// </summary>
        [JsonPropertyName("data")]
        public List<CarrierChange> Items { get; set; }
    }
}
