using System.Text.Json.Serialization;

namespace SolutionsByText.NET.Models.Responses.Reports;

/// <summary>
/// Response data for brand usage report.
/// </summary>
public class BrandUsageReportData
{
    /// <summary>
    /// Gets or sets the identifier of the brand being polled.
    /// </summary>
    [JsonPropertyName("brandId")]
    public string? BrandId { get; set; }
    
    /// <summary>
    /// Gets or sets the name of the brand polled.
    /// </summary>
    [JsonPropertyName("brandName")]
    public string? BrandName { get; set; }
    
    /// <summary>
    /// Gets or sets the product type usage information.
    /// </summary>
    [JsonPropertyName("productType")]
    public ProductTypeUsage? ProductType { get; set; }
}

/// <summary>
/// Product type usage information.
/// </summary>
public class ProductTypeUsage
{
    /// <summary>
    /// Gets or sets the type of messaging operation searched for.
    /// </summary>
    [JsonPropertyName("productType")]
    public string? ProductType { get; set; }
    
    /// <summary>
    /// Gets or sets the number of messages or operations of that type 
    /// sent, received, or made during the specified time frame.
    /// </summary>
    [JsonPropertyName("volume")]
    public int? Volume { get; set; }
    
    /// <summary>
    /// Gets or sets the rate per product type.
    /// </summary>
    [JsonPropertyName("ratePerProductType")]
    public decimal? RatePerProductType { get; set; }
    
    /// <summary>
    /// Gets or sets the usage (volume times rate).
    /// </summary>
    [JsonPropertyName("usage")]
    public decimal? Usage { get; set; }
}

/// <summary>
/// Response model for brand usage report requests.
/// </summary>
public class GetUsageBrandBreakdownResponse : ApiResponse<List<BrandUsageReportData>>
{
}