using System.Text.Json.Serialization;

namespace SolutionsByText.NET.Models.Requests.Reports;

/// <summary>
/// Request model for retrieving brand usage reports.
/// Pulls data for messaging operations (Product Types) for an entire Account or specified Brand.
/// Only available for customers on subscription model.
/// </summary>
public class GetUsageBrandBreakdownRequest
{
    /// <summary>
    /// Gets or sets the month to search.
    /// Two-number format (e.g., Apr = 04, Nov = 11).
    /// Required field.
    /// </summary>
    [JsonPropertyName("month")]
    public int Month { get; set; }
    
    /// <summary>
    /// Gets or sets the year to search.
    /// Four-number format (e.g., 2024).
    /// Required field.
    /// </summary>
    [JsonPropertyName("year")]
    public int Year { get; set; }
    
    /// <summary>
    /// Gets or sets the identifier for a specific brand to be polled (optional).
    /// If not specified, data for all brands in the account will be returned.
    /// </summary>
    [JsonPropertyName("brandId")]
    public string? BrandId { get; set; }
    
    /// <summary>
    /// Gets or sets the type of messaging operation to search (optional).
    /// Types: CarrierLookup, inboundSMS, outboundCompliance, outboundSMS, 
    /// ExtraoutboundCompliance, outboundComplianceMMS, outboundMMS, inboundMMS, 
    /// ExtraoutboundSMS, smartclick
    /// </summary>
    [JsonPropertyName("productType")]
    public string? ProductType { get; set; }
}