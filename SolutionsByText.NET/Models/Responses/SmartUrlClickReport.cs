using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SolutionsByText.NET.Models.Responses
{
    public class SmartUrlClickReport : SmartUrlBaseItem
    {

        /// <summary>
        /// The date and time when the SmartURL was created, in local timezone.
        /// </summary>
        [JsonPropertyName("createdOnLocal")]
        public DateTime CreatedOnLocal { get; set; }


        /// <summary>
        /// Indicates if a custom suffix is used.
        /// </summary>
        [JsonPropertyName("isCustomSuffix")]
        public bool IsCustomSuffix { get; set; }


        /// <summary>
        /// The number of clicks on this SmartURL.
        /// </summary>
        [JsonPropertyName("clickCount")]
        public int ClickCount { get; set; }

        /// <summary>
        /// The total number of clicks recorded for this SmartURL.
        /// </summary>
        [JsonPropertyName("totalClicks")]
        public int TotalClicks { get; set; }
    }
}
