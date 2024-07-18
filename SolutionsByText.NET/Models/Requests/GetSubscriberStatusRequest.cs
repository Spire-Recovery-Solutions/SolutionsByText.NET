using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SolutionsByText.NET.Models.Requests
{

    /// <summary>
    /// Represents a request to get the status of one or more subscribers in a group.
    /// </summary>
    public class GetSubscriberStatusRequest
    {
        /// <summary>
        /// Gets or sets the unique identifier of the group.
        /// </summary>
        [JsonPropertyName("groupId")]
        public string GroupId { get; set; }

        /// <summary>
        /// Gets or sets the list of phone numbers to check the status for.
        /// </summary>
        [JsonPropertyName("msisdn")]
        public List<string> Msisdn { get; set; }
    }
}
