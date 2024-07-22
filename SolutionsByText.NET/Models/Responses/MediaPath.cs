using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SolutionsByText.NET.Models.Responses
{
    /// <summary>
    /// Represents media path details.
    /// </summary>
    public class MediaPath
    {
        [JsonPropertyName("fileName")]
        public string FileName { get; set; }

        [JsonPropertyName("extension")]
        public string Extension { get; set; }

        [JsonPropertyName("fileSaveId")]
        public string FileSaveId { get; set; }

        [JsonPropertyName("mimetype")]
        public string Mimetype { get; set; }
    }
}
