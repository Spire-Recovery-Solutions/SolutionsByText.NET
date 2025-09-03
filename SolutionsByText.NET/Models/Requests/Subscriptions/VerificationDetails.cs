using System.Text.Json.Serialization;
using SolutionsByText.NET.Models.Requests.Enums;

namespace SolutionsByText.NET.Models.Requests.Subscriptions;

/// <summary>
/// Represents the verification details structure as expected by the API.
/// </summary>
public class VerificationDetails
{
    /// <summary>
    /// Gets or sets the type of verification.
    /// </summary>
    [JsonPropertyName("type")]
    [JsonConverter(typeof(JsonStringEnumConverter<VerificationType>))]
    public VerificationType? Type { get; set; }
    
    /// <summary>
    /// Gets or sets whether to force the verification.
    /// Default is false.
    /// </summary>
    [JsonPropertyName("force")]
    public bool Force { get; set; } = false;
}