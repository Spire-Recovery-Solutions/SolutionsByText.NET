using System.Text.Json.Serialization;

namespace SolutionsByText.NET.Models.Requests.Messages
{
    public class RetrieveMMSRequest
    {
        /// <summary>
        /// The unique identifier for the group.
        /// </summary>
        [JsonIgnore]
        public string GroupId { get; set; } = string.Empty;

        /// <summary>
        /// The unique identifier for the message.
        /// </summary>
        [JsonIgnore]
        public string MessageId { get; set; } = string.Empty;

        /// <summary>
        /// The unique identifier for the file.
        /// </summary>
        [JsonIgnore]
        public string FileId { get; set; } = string.Empty;
    }
}
