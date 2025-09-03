using System.Text.Json.Serialization;

namespace SolutionsByText.NET.Models.Requests.Subscriptions;

/// <summary>
/// Request model for deleting/cancelling a subscriber's subscription in a group (Delete Subscriber v2).
/// Removes a subscriber from receiving messages from any specified groups.
/// </summary>
public class CancelSubscriptionRequest
{
    /// <summary>
    /// Gets or sets the group ID from which the subscriber will be deleted.
    /// </summary>
    [JsonIgnore]
    public string GroupId { get; set; } = string.Empty;
    
    /// <summary>
    /// Gets or sets the phone number (MSISDN) of the subscriber to delete.
    /// Format: Country code + phone number (e.g., 12345678910 for US numbers).
    /// </summary>
    [JsonIgnore]
    public string Msisdn { get; set; } = string.Empty;
    
    /// <summary>
    /// Gets or sets whether to silently delete the subscriber.
    /// Default is false. If false, SBT posts a stop to the Inbound Message Status webhook.
    /// </summary>
    [JsonPropertyName("silent")]
    public bool Silent { get; set; } = false;
}