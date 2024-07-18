using System.Text.Json.Serialization;

public class ApiResponse<T>
{
    [JsonPropertyName("data")]
    public T Data { get; set; }

    [JsonPropertyName("appCode")]
    public string AppCode { get; set; }

    [JsonPropertyName("message")]
    public string Message { get; set; }

    [JsonPropertyName("isError")]
    public bool IsError { get; set; }
}