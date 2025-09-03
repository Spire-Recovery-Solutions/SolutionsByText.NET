using System.Text.Json.Serialization;

namespace SolutionsByText.NET.Models.Requests.Messages;

/// <summary>
/// Request model for sending On-Demand Messages (ODM) to a single phone number.
/// ODM allows sending template-based messages to non-subscribers.
/// The template must be pre-loaded by SBT customer support.
/// </summary>
public class SendODMMessageRequest
{
    /// <summary>
    /// Gets or sets the group ID from which the message will be sent.
    /// </summary>
    [JsonIgnore]
    public string GroupId { get; set; } = string.Empty;
    
    /// <summary>
    /// Gets or sets the identifying number of the template.
    /// </summary>
    [JsonPropertyName("templateId")]
    public string? Template { get; set; }
    
    /// <summary>
    /// Gets or sets the template name.
    /// Only considered when template ID is not provided.
    /// </summary>
    [JsonPropertyName("templateName")]
    public string? TemplateName { get; set; }
    
    /// <summary>
    /// Gets or sets the customer-defined identifier for the message (optional).
    /// </summary>
    [JsonPropertyName("referenceId")]
    public string? ReferenceId { get; set; }
    
    /// <summary>
    /// Gets or sets the mobile number with dialing code.
    /// Eleven digits with no plus sign (e.g., 12345678902).
    /// </summary>
    [JsonPropertyName("msisdn")]
    public string? Msisdn { get; set; }
    
    /// <summary>
    /// Gets or sets the variables for template substitution (optional).
    /// Can include custom variables and SystemPIN for auto-generated 6-digit PIN.
    /// </summary>
    [JsonPropertyName("variables")]
    public List<Variable>? Variables { get; set; }
}