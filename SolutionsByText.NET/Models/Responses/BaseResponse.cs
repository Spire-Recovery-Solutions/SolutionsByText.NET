using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SolutionsByText.NET.Models.Responses
{
    public class BaseResponse
    {
        /// <summary>
    /// The app code associated with the response.
    /// </summary>
    [JsonPropertyName("appCode")]
    public string AppCode { get; set; }

    /// <summary>
    /// The message associated with the response.
    /// </summary>
    [JsonPropertyName("message")]
    public string Message { get; set; }

    /// <summary>
    /// A flag indicating whether the response represents an error.
    /// </summary>
    [JsonPropertyName("isError")]
    public bool IsError { get; set; }
    }
}
