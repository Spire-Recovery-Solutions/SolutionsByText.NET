using System.Text.Json.Serialization;

namespace SolutionsByText.NET.Models.Responses.Subscriptions;

/// <summary>
/// Response data for batch subscriber update.
/// </summary>
public class UpdateSubscribersData
{
    /// <summary>
    /// Gets or sets the number of subscribers successfully updated.
    /// </summary>
    [JsonPropertyName("successCount")]
    public int SuccessCount { get; set; }
    
    /// <summary>
    /// Gets or sets the number of subscribers that failed to update.
    /// </summary>
    [JsonPropertyName("failureCount")]
    public int FailureCount { get; set; }
    
    /// <summary>
    /// Gets or sets the total number of subscribers processed.
    /// </summary>
    [JsonPropertyName("totalCount")]
    public int TotalCount { get; set; }
    
    /// <summary>
    /// Gets or sets the details of successful updates.
    /// </summary>
    [JsonPropertyName("successes")]
    public List<UpdateResult>? Successes { get; set; }
    
    /// <summary>
    /// Gets or sets the details of failed updates.
    /// </summary>
    [JsonPropertyName("failures")]
    public List<UpdateResult>? Failures { get; set; }
}

/// <summary>
/// Represents the result of a single subscriber update.
/// </summary>
public class UpdateResult
{
    /// <summary>
    /// Gets or sets the phone number (MSISDN) of the subscriber.
    /// </summary>
    [JsonPropertyName("msisdn")]
    public string? Msisdn { get; set; }
    
    /// <summary>
    /// Gets or sets the status of the update operation.
    /// </summary>
    [JsonPropertyName("status")]
    public string? Status { get; set; }
    
    /// <summary>
    /// Gets or sets the message describing the result.
    /// </summary>
    [JsonPropertyName("message")]
    public string? Message { get; set; }
    
    /// <summary>
    /// Gets or sets the error code if the update failed.
    /// </summary>
    [JsonPropertyName("errorCode")]
    public string? ErrorCode { get; set; }
}

/// <summary>
/// Response model for batch subscriber update requests.
/// </summary>
public class UpdateSubscribersResponse : ApiResponse<UpdateSubscribersData>
{
}