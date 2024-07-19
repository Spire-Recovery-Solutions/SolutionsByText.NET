using System.Text.Json.Serialization;

namespace SolutionsByText.NET.Models.Requests
{
    public class GetTemplatesRequest
    {
        /// <summary>
    /// The unique identifier for the group.
    /// </summary>
    [JsonPropertyName("groupId")]
    public string GroupId { get; set; }

    /// <summary>
    /// The search term to filter results.
    /// </summary>
    [JsonPropertyName("search")]
    public string Search { get; set; }

    /// <summary>
    /// The page number for pagination.
    /// </summary>
    [JsonPropertyName("pageNumber")]
    public int PageNumber { get; set; }

    /// <summary>
    /// The number of items to return per page.
    /// </summary>
    [JsonPropertyName("pageSize")]
    public int PageSize { get; set; }
    }
}
