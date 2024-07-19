using System.Text.Json.Serialization;

namespace SolutionsByText.NET.Models.Requests
{
    public class AddKeywordRequest
    {
        /// <summary>
        /// Gets or sets the group ID.
        /// This parameter is required.
        /// </summary>
        [JsonPropertyName("groupId")]
        public string GroupId { get; set; }

        // <summary>
        /// The name of the subscriber.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// The contact information for the subscriber.
        /// </summary>
        [JsonPropertyName("onContact")]
        public string? OnContact { get; set; }

        /// <summary>
        /// The list of email addresses to be used for notifications.
        /// </summary>
        [JsonPropertyName("notificationEmails")]
        public List<string>? NotificationEmails { get; set; }

        /// <summary>
        /// The list of mobile numbers to be used for notifications.
        /// </summary>
        [JsonPropertyName("notificationMobileNos")]
        public List<string>? NotificationMobileNos { get; set; }

        /// <summary>
        /// The user ID associated with the subscriber.
        /// </summary>
        [JsonPropertyName("userId")]
        public string UserId { get; set; }
    }
}
