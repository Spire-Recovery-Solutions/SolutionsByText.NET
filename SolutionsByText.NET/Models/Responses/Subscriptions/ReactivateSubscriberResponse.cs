using System.Text.Json.Serialization;

namespace SolutionsByText.NET.Models.Responses.Subscriptions;

/// <summary>
/// Response data for subscriber reactivation.
/// </summary>
public class ReactivateSubscriberData
{
    /// <summary>
    /// Gets or sets the opt-in verification message tracking ID number from SBT.
    /// </summary>
    [JsonPropertyName("messageId")]
    public string? MessageId { get; set; }
    
    /// <summary>
    /// Gets or sets the mobile number with dialing code.
    /// Eleven digits with no plus sign (e.g., 12345678902).
    /// </summary>
    [JsonPropertyName("msisdn")]
    public string? Msisdn { get; set; }
    
    /// <summary>
    /// Gets or sets the PIN sent to the subscriber.
    /// </summary>
    [JsonPropertyName("pin")]
    public string? Pin { get; set; }
}

/// <summary>
/// Response model for subscriber reactivation requests.
/// </summary>
public class ReactivateSubscriberResponse : ApiResponse<ReactivateSubscriberData>
{
}