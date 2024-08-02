using System.Text.Json.Serialization;

namespace SolutionsByText.NET.Models.Responses.Subscriptions
{
    public class ConfirmGroupSubscriber
    {
        /// <summary>
        /// Gets or sets the message ID.
        /// </summary>
        [JsonPropertyName("messageId")]
        public string? MessageId { get; set; }

        /// <summary>
        /// Gets or sets the MSISDN.
        /// </summary>
        [JsonPropertyName("msisdn")]
        public string? Msisdn { get; set; }

    }
}
