using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SolutionsByText.NET.Models.Responses
{
   /// <summary>
    /// Represents a keyword item with its associated details.
    /// </summary>
    public class KeywordItem
    {
        /// <summary>
        /// Gets or sets the name of the keyword.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the response associated with the keyword.
        /// </summary>
        [JsonPropertyName("response")]
        public string Response { get; set; }

        /// <summary>
        /// Gets or sets the list of notification email addresses.
        /// </summary>
        [JsonPropertyName("notificationEmails")]
        public List<string> NotificationEmails { get; set; }

        /// <summary>
        /// Gets or sets the list of notification mobile numbers.
        /// </summary>
        [JsonPropertyName("notificationMobileNos")]
        public List<string> NotificationMobileNos { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the keyword was created.
        /// </summary>
        [JsonPropertyName("createdOn")]
        public DateTime CreatedOn { get; set; }
    }
}
