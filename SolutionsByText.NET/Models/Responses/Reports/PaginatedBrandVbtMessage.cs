using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SolutionsByText.NET.Models.Responses.Reports
{
    public class PaginatedBrandVbtMessage : PaginationData
    {
        //</summary>
        ///  Brand Vbt Message Detials
        /// </summary>
        [JsonPropertyName("data")]
        public List<BrandVbtMessage>? Items { get; set; }
    }
}
