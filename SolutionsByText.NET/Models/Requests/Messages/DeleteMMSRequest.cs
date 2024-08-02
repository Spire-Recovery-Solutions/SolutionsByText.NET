using System.Text.Json.Serialization;

namespace SolutionsByText.NET.Models.Requests.Messages
{
    public class DeleteMMSRequest
    {
        /// <summary>
        /// The unique identifier for the group.
        /// </summary>
        [JsonPropertyName("groupId")]
        public required string GroupId { get; set; }

        /// <summary>
        /// The unique identifier for the message.
        /// </summary>
        [JsonPropertyName("messageId")]
        public required string MessageId { get; set; }

        /// <summary>
        /// The unique identifier for the file.
        /// </summary>
        [JsonPropertyName("fileId")]
        public required string FileId { get; set; }
    }
}
