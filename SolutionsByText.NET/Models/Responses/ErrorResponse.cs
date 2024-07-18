using System.Text.Json.Serialization;

namespace SolutionsByText.NET.Models.Responses;

public class ErrorResponse
{
    [JsonPropertyName("appCode")]
    public string AppCode { get; set; }

    [JsonPropertyName("message")]
    public string Message { get; set; }

    [JsonPropertyName("isError")]
    public bool IsError { get; set; }
}