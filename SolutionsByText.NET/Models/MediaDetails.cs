using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SolutionsByText.NET.Models
{
    /// <summary>
    /// Represents media details associated with the message.
    /// </summary>
    public class MediaDetails
    {
        [JsonPropertyName("mediaPath")]
        public List<MediaPath>? MediaPath { get; set; }
    }
}
