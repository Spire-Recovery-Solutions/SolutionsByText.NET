using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SolutionsByText.NET.Models.Responses.Reports
{
    public class SmartUrlBaseItem
    {

        /// <summary>
        /// The long URL associated with the SmartURL.
        /// </summary>
        [JsonPropertyName("longUrl")]
        public string LongUrl { get; set; }

        /// <summary>
        /// The short URL string.
        /// </summary>
        [JsonPropertyName("shortUrl")]
        public string ShortUrl { get; set; }

        /// <summary>
        /// The date and time when the SmartURL was created, in UTC.
        /// </summary>
        [JsonPropertyName("createdOn")]
        public string CreatedOn { get; set; }
    }
}
