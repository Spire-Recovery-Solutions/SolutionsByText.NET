using System.Text.Json.Serialization;

namespace SolutionsByText.NET.Models.Requests.Messages;

/// <summary>
/// Request model for verifying an ODM recipient's PIN.
/// The PIN must be verified within 20 minutes of being sent.
/// </summary>
public class VerifyODMRequest
{
    /// <summary>
    /// Gets or sets the group ID for the verification.
    /// </summary>
    [JsonIgnore]
    public string GroupId { get; set; } = string.Empty;
    
    /// <summary>
    /// Gets or sets the phone number (MSISDN) to verify.
    /// Format: Country code + phone number (e.g., 12345678910 for US numbers).
    /// </summary>
    [JsonIgnore]
    public string Msisdn { get; set; } = string.Empty;
    
    /// <summary>
    /// Gets or sets the PIN sent to the subscriber.
    /// Required field.
    /// </summary>
    [JsonPropertyName("pin")]
    public string Pin { get; set; } = string.Empty;
}