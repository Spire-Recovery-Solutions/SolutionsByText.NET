using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SolutionsByText.NET.Models.Responses
{
    public class GetTemplatesResponse : PaginationData
    {
        /// <summary>
        /// Gets or sets the collection of data items.
        /// </summary>
        [JsonPropertyName("data")]
        public List<TemplateItem> Data { get; set; }
    }
}
