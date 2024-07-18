using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization.Metadata;
using Polly;
using Polly.Retry;
using SolutionsByText.NET.Models.Exceptions;
using SolutionsByText.NET.Models.Requests;
using SolutionsByText.NET.Models.Responses;

namespace SolutionsByText.NET;

public class SolutionsByTextClient : ISolutionsByTextClient
{
    private readonly HttpClient _httpClient;
    private readonly string _baseUrl;
    private readonly string _apiKey;
    private readonly AsyncRetryPolicy<HttpResponseMessage> _retryPolicy;

    public SolutionsByTextClient(string baseUrl, string apiKey)
    {
        _baseUrl = baseUrl;
        _apiKey = apiKey;
        _httpClient = new HttpClient();
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiKey);
        // Define the retry policy
        _retryPolicy = Policy
            .HandleResult<HttpResponseMessage>(r => !r.IsSuccessStatusCode)
            .WaitAndRetryAsync(
                3,
                retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)),
                onRetry: (outcome, timespan, retryAttempt, context) =>
                {
                    Console.WriteLine($"Delaying for {timespan.TotalSeconds} seconds, then making retry {retryAttempt}");
                }
            );
    }

    public Task<GetSubscriberStatusResponse> GetSubscriberStatusAsync(GetSubscriberStatusRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<AddSubscriberResponse> AddSubscriberAsync(AddSubscriberRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<ConfirmSubscriberResponse> ConfirmSubscriberAsync(ConfirmSubscriberRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<DeleteSubscriberResponse> DeleteSubscriberAsync(DeleteSubscriberRequest request)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Sends a message to one or more subscribers in a group.
    /// </summary>
    /// <param name="request">The request containing the message details and recipient information.</param>
    /// <returns>A response containing the message ID and delivery status.</returns>
    /// <exception cref="ApiException">Thrown when the API returns an error.</exception>
    public async Task<SendMessageResponse?> SendMessageAsync(SendMessageRequest request)
    {
        var endpoint = $"{_baseUrl}/groups/{request.GroupId}/messages";
        return await SendRequestAsync<SendMessageRequest, SendMessageResponse?>(HttpMethod.Post, endpoint, request);
    }

    public Task<SendTemplateMessageResponse> SendTemplateMessageAsync(SendTemplateMessageRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<ScheduleMessageResponse> ScheduleMessageAsync(ScheduleMessageRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<ScheduleTemplateMessageResponse> ScheduleTemplateMessageAsync(ScheduleTemplateMessageRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<GetGroupResponse> GetGroupAsync(GetGroupRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<UpdateGroupResponse> UpdateGroupAsync(UpdateGroupRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<GetOutboundMessagesResponse> GetOutboundMessagesAsync(GetOutboundMessagesRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<GetInboundMessagesResponse> GetInboundMessagesAsync(GetInboundMessagesRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<GetDeactivationEventsResponse> GetDeactivationEventsAsync(GetDeactivationEventsRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<CreateSmartURLResponse> CreateSmartURLAsync(CreateSmartURLRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<UpdateSmartURLResponse> UpdateSmartURLAsync(UpdateSmartURLRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<GetPhoneNumberDataResponse> GetPhoneNumberDataAsync(GetPhoneNumberDataRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<AddKeywordResponse> AddKeywordAsync(AddKeywordRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<GetKeywordsResponse> GetKeywordsAsync(GetKeywordsRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<RetrieveMMSResponse> RetrieveMMSAsync(RetrieveMMSRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<DeleteMMSResponse> DeleteMMSAsync(DeleteMMSRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<AddBrandSubscriberResponse> AddBrandSubscriberAsync(AddBrandSubscriberRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<ConfirmBrandSubscriberResponse> ConfirmBrandSubscriberAsync(ConfirmBrandSubscriberRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<GetBrandSubscriberStatusResponse> GetBrandSubscriberStatusAsync(GetBrandSubscriberStatusRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<GetTemplatesResponse> GetTemplatesAsync(GetTemplatesRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<GetTemplateResponse> GetTemplateAsync(GetTemplateRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<RegisterWebhookResponse> RegisterWebhookAsync(RegisterWebhookRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<UpdateWebhookResponse> UpdateWebhookAsync(UpdateWebhookRequest request)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Sends an HTTP request to the specified endpoint and returns the deserialized response.
    /// </summary>
    /// <typeparam name="TRequest">The type of the request body.</typeparam>
    /// <typeparam name="TResponse">The type of the response body.</typeparam>
    /// <param name="method">The HTTP method to use for the request.</param>
    /// <param name="endpoint">The API endpoint to send the request to.</param>
    /// <param name="request">The request body (optional).</param>
    /// <returns>The deserialized response from the API.</returns>
    /// <exception cref="InvalidOperationException">Thrown when the request or response type is not registered in the JSON context.</exception>
    /// <exception cref="ApiException">Thrown when the API returns an error or when an unexpected error occurs.</exception>

    private async Task<TResponse?> SendRequestAsync<TRequest, TResponse>(HttpMethod method, string endpoint,
        TRequest request = default!)
    {
        var requestInfo = SolutionsByTextJsonContext.Default.GetTypeInfo(typeof(TRequest)) as JsonTypeInfo<TRequest>;
        var responseInfo = SolutionsByTextJsonContext.Default.GetTypeInfo(typeof(TResponse)) as JsonTypeInfo<TResponse>;

        if (requestInfo == null || responseInfo == null)
        {
            throw new InvalidOperationException(
                $"Type {typeof(TRequest)} or {typeof(TResponse)} is not registered in SolutionsByTextJsonContext.");
        }

        var content = request != null
            ? new StringContent(JsonSerializer.Serialize(request, requestInfo), Encoding.UTF8, "application/json")
            : null;

        try
        {
            var response = await _retryPolicy.ExecuteAsync(async () =>
            {
                var httpResponse = method switch
                {
                    _ when method == HttpMethod.Get => await _httpClient.GetAsync(endpoint),
                    _ when method == HttpMethod.Post => await _httpClient.PostAsync(endpoint, content),
                    _ when method == HttpMethod.Put => await _httpClient.PutAsync(endpoint, content),
                    _ when method == HttpMethod.Delete => await _httpClient.DeleteAsync(endpoint),
                    _ => throw new NotSupportedException($"HTTP method {method} is not supported.")
                };

                if (httpResponse.IsSuccessStatusCode)
                    return httpResponse;

                if (httpResponse.StatusCode == System.Net.HttpStatusCode.Unauthorized ||
                    httpResponse.StatusCode == System.Net.HttpStatusCode.Forbidden)
                {
                    throw new ApiException((int)httpResponse.StatusCode, "Authentication failed");
                }

                return httpResponse;
            });

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize(responseContent, responseInfo);
            }

            var errorContent = await response.Content.ReadAsStringAsync();
            throw new ApiException((int)response.StatusCode, errorContent);
        }
        catch (ApiException)
        {
            throw;
        }
        catch (Exception ex)
        {
            throw new ApiException(500, $"An error occurred while sending the request: {ex.Message}");
        }
    }
}

}