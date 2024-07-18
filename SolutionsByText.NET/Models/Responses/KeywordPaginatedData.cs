using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SolutionsByText.NET.Models.Responses
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
