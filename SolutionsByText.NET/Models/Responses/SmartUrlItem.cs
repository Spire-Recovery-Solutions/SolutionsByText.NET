using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SolutionsByText.NET.Models.Responses
{
    public class SmartUrlItem : SmartUrlBaseItem
    {
        /// <summary>
        /// The unique identifier for the SmartURL.
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }


        /// <summary>
        /// The date the SmartURL was last updated.
        /// </summary>
        [JsonPropertyName("updatedOn")]
        public string UpdatedOn { get; set; }

        /// <summary>
        /// The total number of clicks on the SmartURL.
        /// </summary>
        [JsonPropertyName("clickCount")]
        public string ClickCount { get; set; }
    }
}
