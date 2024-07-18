using System.Text.Json.Serialization;

namespace SolutionsByText.NET.Models.Responses;

/// <summary>
/// Represents the response received after sending a message through the Solutions By Text system.
/// </summary>
public class SendMessageResponse
{
    /// <summary>
    /// Gets or sets the unique identifier assigned to the sent message.
    /// </summary>
    [JsonPropertyName("messageId")]
    public string MessageId { get; set; }

    /// <summary>
    /// Gets or sets the status of the sent message.
    /// </summary>
    [JsonPropertyName("status")]
    public string Status { get; set; }
}