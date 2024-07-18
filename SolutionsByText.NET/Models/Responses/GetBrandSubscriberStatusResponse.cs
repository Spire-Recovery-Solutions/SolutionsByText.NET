using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SolutionsByText.NET.Models.Responses
{
    public class GetBrandSubscriberStatusResponse : BaseResponse
    {
        /// <summary>
        /// Gets or sets the collection of consent items.
        /// </summary>
        [JsonPropertyName("data")]
        public List<ConsentItem> Data { get; set; }
    }
}
