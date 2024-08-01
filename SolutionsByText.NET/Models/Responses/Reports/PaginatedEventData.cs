using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SolutionsByText.NET.Models.Responses.Reports
{
    public class PaginatedEventData : PaginationData
    {
        [JsonPropertyName("data")]
        public List<EventData> Data { get; set; }
    }
}
