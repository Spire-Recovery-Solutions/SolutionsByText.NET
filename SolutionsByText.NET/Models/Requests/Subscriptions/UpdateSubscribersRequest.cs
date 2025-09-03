using System.Text.Json.Serialization;
using SolutionsByText.NET.Models.Responses.Reports;

namespace SolutionsByText.NET.Models.Requests.Subscriptions;

/// <summary>
/// Request model for batch updating subscribers in a group.
/// </summary>
public class UpdateSubscribersRequest
{
    /// <summary>
    /// Gets or sets the group ID where subscribers will be updated.
    /// </summary>
    [JsonIgnore]
    public string GroupId { get; set; } = string.Empty;
    
    /// <summary>
    /// Gets or sets the list of subscribers to update.
    /// </summary>
    [JsonPropertyName("subscribers")]
    public List<UpdateSubscriberItem> Subscribers { get; set; } = new();
}

/// <summary>
/// Represents a single subscriber update item.
/// </summary>
public class UpdateSubscriberItem
{
    /// <summary>
    /// Gets or sets the phone number (MSISDN) of the subscriber.
    /// Format: Country code + phone number (e.g., 12345678910 for US numbers).
    /// </summary>
    [JsonPropertyName("msisdn")]
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
    /// Gets or sets the email address of the subscriber (optional).
    /// </summary>
    [JsonPropertyName("email")]
    public string? Email { get; set; }
    
    /// <summary>
    /// Gets or sets custom parameters for the subscriber (optional).
    /// </summary>
    [JsonPropertyName("customParams")]
    public List<CustomParam>? CustomParams { get; set; }
    
    /// <summary>
    /// Gets or sets the properties for the subscriber (optional).
    /// </summary>
    [JsonPropertyName("properties")]
    public List<Property>? Properties { get; set; }
    
    /// <summary>
    /// Gets or sets the consent categories for the subscriber (optional).
    /// </summary>
    [JsonPropertyName("consentCategories")]
    public List<string>? ConsentCategories { get; set; }
}