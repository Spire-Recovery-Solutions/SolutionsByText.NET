using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SolutionsByText.NET.Models.Responses
{
    public class GetTemplateResponse : BaseResponse
    {
        /// <summary>
        /// Gets or sets the data item.
        /// </summary>
        [JsonPropertyName("data")]
        public TemplateItem Data { get; set; }
    }
}
