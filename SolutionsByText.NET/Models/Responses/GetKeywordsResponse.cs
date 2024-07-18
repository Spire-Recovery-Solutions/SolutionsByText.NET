using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SolutionsByText.NET.Models.Responses
{
    public class GetKeywordsResponse : BaseResponse
    {
         /// <summary>
        /// The paginated data containing the keywords.
        /// </summary>
       [JsonPropertyName("data")]
        public KeywordPaginatedData PaginatedData { get; set; }
    }
}
