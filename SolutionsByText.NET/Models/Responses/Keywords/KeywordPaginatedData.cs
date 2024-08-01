using System.Text.Json.Serialization;
namespace SolutionsByText.NET.Models.Responses.Keywords
{
    /// <summary>
    /// Represents paginated data for keyword items.
    /// Inherits pagination properties from the PaginationData base class.
    /// </summary>
    public class KeywordPaginatedData : PaginationData
    {
        /// <summary>
        /// Gets or sets the collection of keyword items.
        /// </summary>
        [JsonPropertyName("data")]
        public List<KeywordItem> Items { get; set; }
    }
}
