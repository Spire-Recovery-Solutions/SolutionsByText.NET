using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization.Metadata;
using System.Text.RegularExpressions;
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
                    Console.WriteLine(
                        $"Delaying for {timespan.TotalSeconds} seconds, then making retry {retryAttempt}");
                }
            );
    }

    /// <summary>
    /// Sends a message to one or more subscribers in a group.
    /// </summary>
    /// <param name="request">The request containing the message details and recipient information.</param>
    /// <returns>A response containing the message ID and delivery status.</returns>
    public async Task<SendMessageResponse?> SendMessageAsync(SendMessageRequest request)
    {
        var endpoint = $"{_baseUrl}/groups/{request.GroupId}/messages";
        return await SendRequestAsync<SendMessageRequest, SendMessageResponse?>(HttpMethod.Post, endpoint, request);
    }

    /// <summary>
    /// Sends a template message to one or more subscribers in a group.
    /// </summary>
    /// <param name="request">The request containing the template ID, variables, and recipient information.</param>
    /// <returns>A response containing the message ID and delivery status.</returns>
    public async Task<SendTemplateMessageResponse?> SendTemplateMessageAsync(SendTemplateMessageRequest request)
    {
        var endpoint = $"{_baseUrl}/groups/{request.GroupId}/template-messages";
        return await SendRequestAsync<SendTemplateMessageRequest, SendTemplateMessageResponse?>(HttpMethod.Post,
            endpoint, request);
    }

    /// <summary>
    /// Schedules a message to be sent at a future time.
    /// </summary>
    /// <param name="request">The request containing the message details, recipient information, and scheduled time.</param>
    /// <returns>A response containing the scheduled message ID.</returns>
    public async Task<ScheduleMessageResponse?> ScheduleMessageAsync(ScheduleMessageRequest request)
    {
        var endpoint = $"{_baseUrl}/groups/{request.GroupId}/schedule-messages";
        return await SendRequestAsync<ScheduleMessageRequest, ScheduleMessageResponse?>(HttpMethod.Post, endpoint,
            request);
    }

    /// <summary>
    /// Retrieves the status of one or more subscribers in a group.
    /// </summary>
    /// <param name="request">The request containing group ID and list of phone numbers.</param>
    /// <returns>A response containing the status of the requested subscribers.</returns>
    public async Task<GetSubscriberStatusResponse?> GetSubscriberStatusAsync(GetSubscriberStatusRequest request)
    {
        var endpoint =
            $"{_baseUrl}/groups/{request.GroupId}/subscribers/status?msisdn={string.Join(",", request.Msisdn)}";
        return await SendRequestAsync<GetSubscriberStatusRequest, GetSubscriberStatusResponse?>(HttpMethod.Get,
            endpoint);
    }

    /// <summary>
    /// Adds a new subscriber to a specified group.
    /// </summary>
    /// <param name="request">The request containing subscriber details and group information.</param>
    /// <returns>A response indicating the success or failure of the operation.</returns>
    public async Task<AddSubscriberResponse?> AddSubscriberAsync(AddSubscriberRequest request)
    {
        var endpoint = $"{_baseUrl}/groups/{request.GroupId}/subscribers";
        return await SendRequestAsync<AddSubscriberRequest, AddSubscriberResponse?>(HttpMethod.Post, endpoint, request);
    }

    /// <summary>
    /// Confirms a subscriber's opt-in using a PIN.
    /// </summary>
    /// <param name="request">The request containing the subscriber's phone number, group ID, and PIN.</param>
    /// <returns>A response indicating whether the confirmation was successful.</returns>
    public async Task<ConfirmSubscriberResponse?> ConfirmSubscriberAsync(ConfirmSubscriberRequest request)
    {
        var endpoint = $"{_baseUrl}/groups/{request.GroupId}/subscribers/{request.Msisdn}/verification";
        return await SendRequestAsync<ConfirmSubscriberRequest, ConfirmSubscriberResponse?>(HttpMethod.Post, endpoint,
            request);
    }

    /// <summary>
    /// Removes a subscriber from a specified group.
    /// </summary>
    /// <param name="request">The request containing the subscriber's phone number and group ID.</param>
    /// <returns>A response indicating the success or failure of the operation.</returns>
    public async Task<DeleteSubscriberResponse?> DeleteSubscriberAsync(DeleteSubscriberRequest request)
    {
        var endpoint = $"{_baseUrl}/groups/{request.GroupId}/subscribers/{request.Msisdn}";
        return await SendRequestAsync<DeleteSubscriberRequest, DeleteSubscriberResponse?>(HttpMethod.Delete, endpoint);
    }

    /// <summary>
    /// Retrieves information about a specific group.
    /// </summary>
    /// <param name="request">The request containing the group ID.</param>
    /// <returns>A response containing detailed information about the group.</returns>
    public async Task<GetGroupResponse?> GetGroupAsync(GetGroupRequest request)
    {
        var endpoint = $"{_baseUrl}/groups/{request.GroupId}";
        return await SendRequestAsync<GetGroupRequest, GetGroupResponse?>(HttpMethod.Get, endpoint);
    }

    /// <summary>
    /// Retrieves details of outbound messages for a specific group.
    /// </summary>
    /// <param name="request">The request containing the group ID and optional filters.</param>
    /// <returns>A response containing a list of outbound message details.</returns>
    public async Task<GetOutboundMessagesResponse?> GetOutboundMessagesAsync(GetOutboundMessagesRequest request)
    {
        var endpoint = $"{_baseUrl}/groups/{request.GroupId}/outbound-messages";
        return await SendRequestAsync<GetOutboundMessagesRequest, GetOutboundMessagesResponse?>(HttpMethod.Get,
            endpoint);
    }

    /// <summary>
    /// Retrieves details of inbound messages for a specific group.
    /// </summary>
    /// <param name="request">The request containing the group ID and optional filters.</param>
    /// <returns>A response containing a list of inbound message details.</returns>
    public async Task<GetInboundMessagesResponse?> GetInboundMessagesAsync(GetInboundMessagesRequest request)
    {
        var endpoint = $"{_baseUrl}/groups/{request.GroupId}/inbound-messages";
        return await SendRequestAsync<GetInboundMessagesRequest, GetInboundMessagesResponse?>(HttpMethod.Get, endpoint);
    }

    /// <summary>
    /// Creates a new SmartURL (shortened URL) for a group.
    /// </summary>
    /// <param name="request">The request containing the long URL and group ID.</param>
    /// <returns>A response containing the created SmartURL.</returns>
    public async Task<CreateSmartURLResponse?> CreateSmartURLAsync(CreateSmartURLRequest request)
    {
        var endpoint = $"{_baseUrl}/groups/{request.GroupId}/shortUrls";
        return await SendRequestAsync<CreateSmartURLRequest, CreateSmartURLResponse?>(HttpMethod.Post, endpoint,
            request);
    }

    /// <summary>
    /// Retrieves carrier information for one or more phone numbers.
    /// </summary>
    /// <param name="request">The request containing the list of phone numbers to look up.</param>
    /// <returns>A response containing carrier information for each phone number.</returns>
    public async Task<GetPhoneNumberDataResponse?> GetPhoneNumberDataAsync(GetPhoneNumberDataRequest request)
    {
        var endpoint = $"{_baseUrl}/phonenumbers-data?msisdn={string.Join(",", request.Msisdn)}";
        return await SendRequestAsync<GetPhoneNumberDataRequest, GetPhoneNumberDataResponse?>(HttpMethod.Get, endpoint);
    }

    /// <summary>
    /// Adds a new subscriber to a brand.
    /// </summary>
    /// <param name="request">The request containing subscriber details and brand information.</param>
    /// <returns>A response indicating the success or failure of the operation.</returns>
    public async Task<AddBrandSubscriberResponse?> AddBrandSubscriberAsync(AddBrandSubscriberRequest request)
    {
        var endpoint = $"{_baseUrl}/brands/{request.BrandId}/subscribers";
        return await SendRequestAsync<AddBrandSubscriberRequest, AddBrandSubscriberResponse?>(HttpMethod.Post, endpoint,
            request);
    }

    /// <summary>
    /// Confirms a subscriber's opt-in for a brand using a PIN.
    /// </summary>
    /// <param name="request">The request containing the subscriber's phone number, brand ID, and PIN.</param>
    /// <returns>A response indicating whether the confirmation was successful.</returns>
    public async Task<ConfirmBrandSubscriberResponse?> ConfirmBrandSubscriberAsync(ConfirmBrandSubscriberRequest request)
    {
        var endpoint = $"{_baseUrl}/brands/{request.BrandId}/subscribers/{request.Msisdn}/verification";
        return await SendRequestAsync<ConfirmBrandSubscriberRequest, ConfirmBrandSubscriberResponse?>(HttpMethod.Post,
            endpoint, request);
    }

    /// <summary>
    /// Sends an HTTP request to the specified endpoint and returns the deserialized response.
    /// </summary>
    /// <typeparam name="TRequest">The type of the request body.</typeparam>
    /// <typeparam name="TResponse">The type of the response data.</typeparam>
    /// <param name="method">The HTTP method to use for the request.</param>
    /// <param name="endpoint">The API endpoint to send the request to.</param>
    /// <param name="request">The request body (optional).</param>
    /// <returns>The deserialized response data.</returns>
    /// <exception cref="InvalidOperationException">Thrown when the request or response type is not registered in the JSON context.</exception>
    /// <exception cref="NotSupportedException">Thrown when an unsupported HTTP method is used.</exception>
    /// <exception cref="ApiException">Thrown when the API returns an error or when an unexpected error occurs.</exception>
    private async Task<TResponse?> SendRequestAsync<TRequest, TResponse>(HttpMethod method, string endpoint,
        TRequest request = default)
    {
        var requestInfo = SolutionsByTextJsonContext.Default.GetTypeInfo(typeof(TRequest)) as JsonTypeInfo<TRequest>;
        var responseInfo =
            SolutionsByTextJsonContext.Default.GetTypeInfo(typeof(ApiResponse<TResponse?>)) as
                JsonTypeInfo<ApiResponse<TResponse?>>;

        if (requestInfo == null || responseInfo == null)
        {
            throw new InvalidOperationException(
                $"Type {typeof(TRequest)} or {typeof(ApiResponse<TResponse?>)} is not registered in SolutionsByTextJsonContext.");
        }

        var content = request != null
            ? new StringContent(JsonSerializer.Serialize(request, requestInfo), System.Text.Encoding.UTF8,
                "application/json")
            : null;

        try
        {
            var response = await _retryPolicy.ExecuteAsync(async () =>
            {
                var httpResponse = method switch
                {
                    var m when m == HttpMethod.Get => await _httpClient.GetAsync(endpoint),
                    var m when m == HttpMethod.Post => await _httpClient.PostAsync(endpoint, content),
                    var m when m == HttpMethod.Put => await _httpClient.PutAsync(endpoint, content),
                    var m when m == HttpMethod.Delete => await _httpClient.DeleteAsync(endpoint),
                    _ => throw new NotSupportedException($"HTTP method {method} is not supported.")
                };

                return httpResponse;
            });

            var responseContent = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var apiResponse = JsonSerializer.Deserialize(responseContent, responseInfo);
                if (apiResponse == null || apiResponse.Data == null)
                {
                    throw new ApiException("Failed to deserialize the response.");
                }

                return apiResponse.Data;
            }
            else
            {
                var errorResponse = JsonSerializer.Deserialize(responseContent,
                    SolutionsByTextJsonContext.Default.ErrorResponse);

                if (errorResponse != null)
                {
                    throw new ApiException(errorResponse.AppCode, errorResponse.Message);
                }
                else
                {
                    throw new ApiException(response.StatusCode.ToString(), responseContent);
                }
            }
        }
        catch (ApiException)
        {
            throw;
        }
        catch (Exception ex)
        {
            throw new ApiException("An unexpected error occurred", ex.Message);
        }
    }

    public async Task<ScheduleTemplateMessageResponse?> ScheduleTemplateMessageAsync(ScheduleTemplateMessageRequest request)
    {
        var endpoint = $"{_baseUrl}/groups/{request.GroupId}/schedule-template-messages";
        return await SendRequestAsync<ScheduleTemplateMessageRequest, ScheduleTemplateMessageResponse?>(HttpMethod.Post,
            endpoint, request);
    }

    public async Task<GetDeactivationEventsResponse?> GetDeactivationEventsAsync(GetDeactivationEventsRequest request)
    {
        var endpoint =
            $"{_baseUrl}/accounts/deactevents?EventDate={request.EventDate}&EventType={request.EventType}&CountryCode={request.CountryCode}";

        if (request.PageNumber.HasValue)
        {
            endpoint += $"&pageNumber={request.PageNumber}";
        }

        if (request.PageSize.HasValue)
        {
            endpoint += $"&pageSize={request.PageSize}";
        }

        return await SendRequestAsync<GetDeactivationEventsRequest, GetDeactivationEventsResponse?>(HttpMethod.Get,
            endpoint);
    }

    public async Task<UpdateSmartURLResponse?> UpdateSmartURLAsync(UpdateSmartURLRequest request)
    {
        var endpoint =
                $"{_baseUrl}/groups/{request.GroupId}/shortUrls/{request.ShortUrl}";

        return await SendRequestAsync<UpdateSmartURLRequest, UpdateSmartURLResponse?>(HttpMethod.Patch,
            endpoint,request);
    }

    public async Task<AddKeywordResponse?> AddKeywordAsync(AddKeywordRequest request)
    {
         var endpoint = $"{_baseUrl}/groups/{request.GroupId}/keywords";

        return await SendRequestAsync<AddKeywordRequest, AddKeywordResponse?>(HttpMethod.Post,
            endpoint, request);
    }

    public async Task<GetKeywordsResponse?> GetKeywordsAsync(GetKeywordsRequest request)
    {
        var endpoint = $"{_baseUrl}/groups/{request.GroupId}/keywords";

        var queryParameters = new List<string>();

        if (!string.IsNullOrEmpty(request.Filter))
        {
            queryParameters.Add($"filter={request.Filter}");
        }

        if (request.PageNumber.HasValue)
        {
            queryParameters.Add($"pageNumber={request.PageNumber}");
        }

        if (request.PageSize.HasValue)
        {
            queryParameters.Add($"pageSize={request.PageSize}");
        }

        if (queryParameters.Any())
        {
            endpoint += "?" + string.Join("&", queryParameters);
        }

        return await SendRequestAsync<GetKeywordsRequest, GetKeywordsResponse?>(HttpMethod.Get, endpoint, request);
    }


    public async Task<RetrieveMMSResponse?> RetrieveMMSAsync(RetrieveMMSRequest request)
    {
          var endpoint = $"{_baseUrl}/groups/{request.GroupId}/media-messages/{request.MessageId}/file/{request.FileId}";

        return await SendRequestAsync<RetrieveMMSRequest, RetrieveMMSResponse?>(HttpMethod.Get,
            endpoint);
    }

    public async Task<DeleteMMSResponse?> DeleteMMSAsync(DeleteMMSRequest request)
    {
         var endpoint = $"{_baseUrl}/groups/{request.GroupId}/media-messages/{request.MessageId}/file/{request.FileId}";

        return await SendRequestAsync<DeleteMMSRequest, DeleteMMSResponse?>(HttpMethod.Delete,
            endpoint);
    }

    public async Task<GetBrandSubscriberStatusResponse?> GetBrandSubscriberStatusAsync(GetBrandSubscriberStatusRequest request)
    {
        var endpoint = $"{_baseUrl}/brands/{request.BrandId}/subscribers/status?msisdn={request.Msisdn}";
        return await SendRequestAsync<GetBrandSubscriberStatusRequest, GetBrandSubscriberStatusResponse?>(HttpMethod.Get, endpoint);
    }

    public async Task<GetTemplatesResponse?> GetTemplatesAsync(GetTemplatesRequest request)
    {
        var endpoint = $"{_baseUrl}/groups/{request.GroupId}/templates";
        var queryParams = new List<string>();

        if (!string.IsNullOrEmpty(request.Search))
        {
            queryParams.Add($"search={Uri.EscapeDataString(request.Search)}");
        }

        if (request.PageNumber > 0)
        {
            queryParams.Add($"pageNumber={request.PageNumber}");
        }

        if (request.PageSize > 0)
        {
            queryParams.Add($"pageSize={request.PageSize}");
        }

        if (queryParams.Count > 0)
        {
            endpoint += "?" + string.Join("&", queryParams);
        }

        return await SendRequestAsync<GetTemplatesRequest, GetTemplatesResponse?>(HttpMethod.Get, endpoint);
    }

    public async Task<GetTemplateResponse?> GetTemplateAsync(GetTemplateRequest request)
    {
       var endpoint = $"{_baseUrl}/groups/{request.GroupId}/templates/{request.TemplateId}";
        return await SendRequestAsync<GetTemplateRequest, GetTemplateResponse?>(HttpMethod.Get, endpoint);
    }
}