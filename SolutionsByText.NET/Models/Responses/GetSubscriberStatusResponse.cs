using System.Text.Json.Serialization;
namespace SolutionsByText.NET.Models.Responses
{
    /// <summary>
    /// Represents the response received after requesting subscriber status.
    /// </summary>
    public class GetSubscriberStatusResponse
    {
        /// <summary>
        /// Gets or sets the list of subscriber statuses.
        /// </summary>
        [JsonPropertyName("subscribers")]
        public List<SubscriberStatus> Subscribers { get; set; }
    }

}