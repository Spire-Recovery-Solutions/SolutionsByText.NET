using System.Text.Json.Serialization;

namespace SolutionsByText.NET.Models.Responses.Subscriptions;

/// <summary>
/// Response model for subscription cancellation/deletion requests.
/// This is a simple response with no data payload, only status information.
/// </summary>
public class CancelSubscriptionResponse
{
    /// <summary>
    /// Gets or sets the API response code (e.g., "gen.1200" for success).
    /// </summary>
    [JsonPropertyName("appCode")]
    public string? AppCode { get; set; }
    
    /// <summary>
    /// Gets or sets the API response message (e.g., "Request successful").
    /// </summary>
    [JsonPropertyName("message")]
    public string? Message { get; set; }
    
    /// <summary>
    /// Gets or sets whether the response indicates an error.
    /// If no error, false. If error, true.
    /// </summary>
    [JsonPropertyName("isError")]
    public bool IsError { get; set; }
}