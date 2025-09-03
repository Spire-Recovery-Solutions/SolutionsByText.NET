using System.Text.Json.Serialization;

namespace SolutionsByText.NET.Models.Responses.Messages;

/// <summary>
/// Response data for ODM PIN verification.
/// </summary>
public class VerifyODMData
{
    /// <summary>
    /// Gets or sets whether the PIN validation was successful.
    /// </summary>
    [JsonPropertyName("validation")]
    public bool Validation { get; set; } = true;
    
    /// <summary>
    /// Gets or sets the mobile number with dialing code.
    /// Eleven digits with no plus sign (e.g., 12345678902).
    /// </summary>
    [JsonPropertyName("msisdn")]
    public string? Msisdn { get; set; }
}

/// <summary>
/// Response model for ODM verification requests.
/// </summary>
public class VerifyODMResponse : ApiResponse<VerifyODMData>
{
}