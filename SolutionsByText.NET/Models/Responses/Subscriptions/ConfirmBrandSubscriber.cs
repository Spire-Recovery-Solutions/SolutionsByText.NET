using System.Text.Json.Serialization;

namespace SolutionsByText.NET.Models.Responses.Subscriptions
{
    public class ConfirmBrandSubscriber
    {
        /// <summary>
        /// Gets or sets the transaction ID.
        /// </summary>
        [JsonPropertyName("transactionId")]
        public string? TransactionId { get; set; }
    }
}
