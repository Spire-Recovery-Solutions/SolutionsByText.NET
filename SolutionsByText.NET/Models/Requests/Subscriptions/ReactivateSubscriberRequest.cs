using System.Text.Json.Serialization;
using SolutionsByText.NET.Models.Requests.Enums;

namespace SolutionsByText.NET.Models.Requests.Subscriptions;

/// <summary>
/// Request model for reactivating a subscriber in a group.
/// Used to re-opt-in an inactive subscriber or prompt an unverified subscriber.
/// </summary>
public class ReactivateSubscriberRequest
{
    /// <summary>
    /// Gets or sets the group ID where the subscriber will be reactivated.
    /// </summary>
    [JsonIgnore]
    public string GroupId { get; set; } = string.Empty;
    
    /// <summary>
    /// Gets or sets the phone number (MSISDN) of the subscriber to reactivate.
    /// Format: Country code + phone number (e.g., 12345678910 for US numbers).
    /// </summary>
    [JsonIgnore]
    public string Msisdn { get; set; } = string.Empty;
    
    /// <summary>
    /// Gets or sets the first name of the subscriber (optional).
    /// </summary>
    [JsonPropertyName("firstName")]
    public string? FirstName { get; set; }
    
    /// <summary>
    /// Gets or sets the last name of the subscriber (optional).
    /// </summary>
    [JsonPropertyName("lastName")]
    public string? LastName { get; set; }
    
    /// <summary>
    /// Gets or sets the middle name of the subscriber (optional).
    /// </summary>
    [JsonPropertyName("middleName")]
    public string? MiddleName { get; set; }
    
    /// <summary>
    /// Gets or sets the landline number (optional).
    /// </summary>
    [JsonPropertyName("landLineNo")]
    public string? LandLineNo { get; set; }
    
    /// <summary>
    /// Gets or sets the subscriber image URL (optional).
    /// </summary>
    [JsonPropertyName("imageUrl")]
    public string? ImageUrl { get; set; }
    
    /// <summary>
    /// Gets or sets the email address (optional).
    /// </summary>
    [JsonPropertyName("email")]
    public string? Email { get; set; }
    
    /// <summary>
    /// Gets or sets the gender (optional).
    /// </summary>
    [JsonPropertyName("gender")]
    public string? Gender { get; set; }
    
    /// <summary>
    /// Gets or sets the birth date (optional).
    /// </summary>
    [JsonPropertyName("birthDate")]
    public DateTimeOffset? BirthDate { get; set; }
    
    /// <summary>
    /// Gets or sets the address (optional).
    /// </summary>
    [JsonPropertyName("address")]
    public Address? Address { get; set; }
    
    /// <summary>
    /// Gets or sets the age (optional).
    /// </summary>
    [JsonPropertyName("age")]
    public int? Age { get; set; }
    
    /// <summary>
    /// Gets or sets the customer-defined identifier for the subscriber (optional).
    /// </summary>
    [JsonPropertyName("referenceId")]
    public string? ReferenceId { get; set; }
    
    /// <summary>
    /// Gets or sets the verification settings (optional).
    /// </summary>
    [JsonPropertyName("verification")]
    public VerificationSettings? Verification { get; set; }
    
    /// <summary>
    /// Gets or sets the variables for template messages (optional).
    /// </summary>
    [JsonPropertyName("variables")]
    public List<Variable>? Variables { get; set; }
    
    /// <summary>
    /// Gets or sets the media file in base64 Data URI format or a fully qualified URL (optional).
    /// </summary>
    [JsonPropertyName("media")]
    public string? Media { get; set; }
    
    /// <summary>
    /// Gets or sets the relations (optional).
    /// </summary>
    [JsonPropertyName("relations")]
    public List<Relation>? Relations { get; set; }
    
    /// <summary>
    /// Gets or sets the properties (optional).
    /// </summary>
    [JsonPropertyName("properties")]
    public List<Property>? Properties { get; set; }
}

/// <summary>
/// Verification settings for subscriber reactivation.
/// </summary>
public class VerificationSettings
{
    /// <summary>
    /// Gets or sets the verification type.
    /// </summary>
    [JsonPropertyName("type")]
    public VerificationType? Type { get; set; }
    
    /// <summary>
    /// Gets or sets whether to force verification.
    /// </summary>
    [JsonPropertyName("force")]
    public bool Force { get; set; } = false;
}