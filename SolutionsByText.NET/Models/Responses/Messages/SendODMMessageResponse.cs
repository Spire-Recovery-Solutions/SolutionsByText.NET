using System.Text.Json.Serialization;

namespace SolutionsByText.NET.Models.Responses.Messages;

/// <summary>
/// Response model for ODM message sending requests.
/// Returns a simple status response with no data payload.
/// </summary>
public class SendODMMessageResponse
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