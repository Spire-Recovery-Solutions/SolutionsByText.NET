using System.Text.Json.Serialization;

namespace SolutionsByText.NET.Models.Requests.Subscriptions;

/// <summary>
/// Request model for updating subscriber data within a brand.
/// Maps to the ContactParam schema in the API specification.
/// </summary>
public class UpdateSubscriberDataRequest
{
    /// <summary>
    /// Gets or sets the group ID where the subscriber data will be updated.
    /// Note: The API has malformed double brackets in the path, but we use single brackets.
    /// </summary>
    [JsonIgnore]
    public string GroupId { get; set; } = string.Empty;
    
    /// <summary>
    /// Gets or sets the mobile number with dialing code (required).
    /// Eleven digits with no plus sign (e.g., 12345678902).
    /// </summary>
    [JsonPropertyName("msisdn")]
    public string Msisdn { get; set; } = string.Empty;
    
    /// <summary>
    /// Gets or sets the subscriber's first name (optional).
    /// </summary>
    [JsonPropertyName("firstName")]
    public string? FirstName { get; set; }
    
    /// <summary>
    /// Gets or sets the subscriber's last name (optional).
    /// </summary>
    [JsonPropertyName("lastName")]
    public string? LastName { get; set; }
    
    /// <summary>
    /// Gets or sets the subscriber's middle name (optional).
    /// </summary>
    [JsonPropertyName("middleName")]
    public string? MiddleName { get; set; }
    
    /// <summary>
    /// Gets or sets the subscriber's landline number (optional).
    /// </summary>
    [JsonPropertyName("landLineNo")]
    public string? LandLineNo { get; set; }
    
    /// <summary>
    /// Gets or sets the subscriber's image URL (optional).
    /// </summary>
    [JsonPropertyName("imageUrl")]
    public string? ImageUrl { get; set; }
    
    /// <summary>
    /// Gets or sets the subscriber's email address (optional).
    /// </summary>
    [JsonPropertyName("email")]
    public string? Email { get; set; }
    
    /// <summary>
    /// Gets or sets the subscriber's gender (optional).
    /// </summary>
    [JsonPropertyName("gender")]
    public string? Gender { get; set; }
    
    /// <summary>
    /// Gets or sets the subscriber's birth date (optional).
    /// </summary>
    [JsonPropertyName("birthDate")]
    public DateTimeOffset? BirthDate { get; set; }
    
    /// <summary>
    /// Gets or sets the subscriber's address information (optional).
    /// </summary>
    [JsonPropertyName("address")]
    public UpdateSubscriberAddress? Address { get; set; }
    
    /// <summary>
    /// Gets or sets the subscriber's relation information (optional).
    /// </summary>
    [JsonPropertyName("relation")]
    public UpdateSubscriberRelation? Relation { get; set; }
    
    /// <summary>
    /// Gets or sets custom properties for the subscriber (optional).
    /// </summary>
    [JsonPropertyName("properties")]
    public List<UpdateSubscriberProperty>? Properties { get; set; }
}

/// <summary>
/// Represents address information for a subscriber update.
/// </summary>
public class UpdateSubscriberAddress
{
    /// <summary>
    /// Gets or sets the street address.
    /// </summary>
    [JsonPropertyName("address1")]
    public string? Address1 { get; set; }
    
    /// <summary>
    /// Gets or sets additional address information.
    /// </summary>
    [JsonPropertyName("address2")]
    public string? Address2 { get; set; }
    
    /// <summary>
    /// Gets or sets the city.
    /// </summary>
    [JsonPropertyName("city")]
    public string? City { get; set; }
    
    /// <summary>
    /// Gets or sets the state or province.
    /// </summary>
    [JsonPropertyName("state")]
    public string? State { get; set; }
    
    /// <summary>
    /// Gets or sets the postal/zip code.
    /// </summary>
    [JsonPropertyName("postalCode")]
    public string? PostalCode { get; set; }
    
    /// <summary>
    /// Gets or sets the country.
    /// </summary>
    [JsonPropertyName("country")]
    public string? Country { get; set; }
}

/// <summary>
/// Represents relation information for a subscriber update.
/// </summary>
public class UpdateSubscriberRelation
{
    /// <summary>
    /// Gets or sets the type of relation.
    /// </summary>
    [JsonPropertyName("type")]
    public string? Type { get; set; }
    
    /// <summary>
    /// Gets or sets the value of the relation.
    /// </summary>
    [JsonPropertyName("value")]
    public string? Value { get; set; }
}

/// <summary>
/// Represents a custom property for a subscriber update.
/// </summary>
public class UpdateSubscriberProperty
{
    /// <summary>
    /// Gets or sets the property name.
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;
    
    /// <summary>
    /// Gets or sets the property value.
    /// </summary>
    [JsonPropertyName("value")]
    public string? Value { get; set; }
}