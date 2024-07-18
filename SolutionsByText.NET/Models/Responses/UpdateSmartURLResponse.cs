using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SolutionsByText.NET.Models.Responses
{
    public class UpdateSmartURLResponse : BaseResponse
    {
        /// <summary>
        /// The data returned in the response.
        /// </summary>
        [JsonPropertyName("data")]
        public string Data { get; set; }
    }
}
