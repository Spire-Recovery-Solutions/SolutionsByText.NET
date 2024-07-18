using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SolutionsByText.NET.Models.Requests
{
    /// <summary>
    /// Represents a request to add a new subscriber to a group.
    /// </summary>
    public class AddSubscriberRequest
    {
        /// <summary>
        /// Gets or sets the unique identifier of the group to add the subscriber to.
        /// </summary>
        [JsonPropertyName("groupId")]
        public string GroupId { get; set; }

        /// <summary>
        /// Gets or sets the phone number of the subscriber.
        /// </summary>
        [JsonPropertyName("msisdn")]
        public string Msisdn { get; set; }

        /// <summary>
        /// Gets or sets the first name of the subscriber.
        /// </summary>
        [JsonPropertyName("firstName")]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name of the subscriber.
        /// </summary>
        [JsonPropertyName("lastName")]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the email of the subscriber.
        /// </summary>
        [JsonPropertyName("email")]
        public string Email { get; set; }
    }
}
