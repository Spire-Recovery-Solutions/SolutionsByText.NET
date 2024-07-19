﻿using System.Text.Json.Serialization;

namespace SolutionsByText.NET.Models.Requests
{
    public class DeleteMMSRequest
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
