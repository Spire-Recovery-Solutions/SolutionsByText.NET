using System.Text.Json.Serialization;

namespace SolutionsByText.NET.Models.Requests
{
    /// <summary>
    /// Represents the payload for inbound MMS webhooks, extending the base inbound message request.
    /// </summary>
    public class InboundMMSRequest : InboundMessageRequest
    {
        /// <summary>
        /// Gets or sets the list of media files associated with the MMS message.
        /// </summary>
        [JsonPropertyName("Files")]
        public List<MediaFile> Files { get; set; }
    }
}
