using System.Text.Json.Serialization;

namespace SolutionsByText.NET.Models.Responses;

public class SendMessageResponse
{
    [JsonPropertyName("messageId")]
    public string MessageId { get; set; }

    [JsonPropertyName("status")]
    public string Status { get; set; }
}