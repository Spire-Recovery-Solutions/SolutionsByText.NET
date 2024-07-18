using System.Text.Json.Serialization;
using SolutionsByText.NET.Models.Requests;
using SolutionsByText.NET.Models.Responses;

namespace SolutionsByText.NET;


[JsonSerializable(typeof(SendMessageRequest))]
[JsonSerializable(typeof(SendMessageResponse))]
[JsonSerializable(typeof(GetSubscriberStatusRequest))]
[JsonSerializable(typeof(GetSubscriberStatusResponse))]

[JsonSourceGenerationOptions(
    PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase,
    WriteIndented = true,
    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull)]
public partial class SolutionsByTextJsonContext : JsonSerializerContext
{
}

