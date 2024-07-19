using System.Text.Json.Serialization;

public class ApiResponse<T>
{
    /// <summary>
    /// Gets or sets the data payload of the API response, which can be of any type specified by T.
    /// </summary>
    [JsonPropertyName("data")]
    public T Data { get; set; }

    /// <summary>
    /// Gets or sets the application code associated with the API response.
    /// </summary>
    [JsonPropertyName("appCode")]
    public string AppCode { get; set; }

    /// <summary>
    /// Gets or sets the message providing additional information about the API response.
    /// </summary>
    [JsonPropertyName("message")]
    public string Message { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the API response indicates an error.
    /// </summary>
    [JsonPropertyName("isError")]
    public bool IsError { get; set; }
}