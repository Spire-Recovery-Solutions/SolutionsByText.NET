using System.Text.Json.Serialization;

namespace SolutionsByText.NET.Models.Requests.Messages
{
    public class RetrieveMMSRequest
    {
        /// <summary>
        /// The unique identifier for the group.
        /// </summary>
        [JsonPropertyName("groupId")]
        public string GroupId { get; set; }

        /// <summary>
        /// The unique identifier for the message.
        /// </summary>
        [JsonPropertyName("messageId")]
        public string MessageId { get; set; }

        /// <summary>
        /// The unique identifier for the file.
        /// </summary>
        [JsonPropertyName("fileId")]
        public string FileId { get; set; }
    }
}
