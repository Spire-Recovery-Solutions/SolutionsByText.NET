using System.Text.Json.Serialization;

namespace SolutionsByText.NET.Models.Requests.Subscriptions
{

    /// <summary>
    /// Represents a request to get the status of one or more subscribers in a group.
    /// </summary>
    public class GetGroupSubscriberStatusRequest
    {
        /// <summary>
        /// The group of which the subscriber is a member.
        /// </summary>
        [JsonIgnore]
        public string GroupId { get; set; } = string.Empty;

        /// <summary>
        /// Mobile number with dialing code. Eleven digits with no plus sign (12345678902).
        /// Can check up to 50 numbers in a batch.
        /// </summary>
        [JsonIgnore]
        public required List<string> Msisdn { get; set; }
    }
}
