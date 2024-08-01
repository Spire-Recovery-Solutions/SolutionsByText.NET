using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SolutionsByText.NET.Models.Responses.Reports
{
    public class SmartUrlDetailClickReport : SmartUrlBaseItem
    {
        /// <summary>
        /// The date and time when the link was clicked, in local timezone.
        /// </summary>
        [JsonPropertyName("clickedDateTimeLocal")]
        public DateTime ClickedDateTimeLocal { get; set; }

        /// <summary>
        /// The date and time when the link was clicked, in UTC.
        /// </summary>
        [JsonPropertyName("clickedDateTime")]
        public DateTime ClickedDateTime { get; set; }

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
        /// The IP address of the user who clicked the link.
        /// </summary>
        [JsonPropertyName("ip")]
        public string Ip { get; set; }

        /// <summary>
        /// The operating system of the device used to click the link.
        /// </summary>
        [JsonPropertyName("os")]
        public string Os { get; set; }

        /// <summary>
        /// Information about the device used to click the link.
        /// </summary>
        [JsonPropertyName("deviceInfo")]
        public string DeviceInfo { get; set; }
    }
}
