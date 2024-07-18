using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SolutionsByText.NET.Models.Responses
{
   
    /// <summary>
    /// Represents the response received after creating a SmartURL.
    /// </summary>
    public class CreateSmartURLResponse
    {
        /// <summary>
        /// Gets or sets the shortened URL.
        /// </summary>
        [JsonPropertyName("shortUrl")]
        public string ShortUrl { get; set; }
    }
}
