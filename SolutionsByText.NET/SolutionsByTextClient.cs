using Polly;
using Polly.Retry;
using SolutionsByText.NET.Models.Exceptions;
using SolutionsByText.NET.Models.Requests;
using SolutionsByText.NET.Models.Requests.Keywords;
using SolutionsByText.NET.Models.Requests.Messages;
using SolutionsByText.NET.Models.Requests.PhoneNumbers;
using SolutionsByText.NET.Models.Requests.Reports;
using SolutionsByText.NET.Models.Requests.SmartUrl;
using SolutionsByText.NET.Models.Requests.Subscriptions;
using SolutionsByText.NET.Models.Requests.Templates;
using SolutionsByText.NET.Models.Responses;
using SolutionsByText.NET.Models.Responses.Keywords;
using SolutionsByText.NET.Models.Responses.Messages;
using SolutionsByText.NET.Models.Responses.PhoneNumbers;
using SolutionsByText.NET.Models.Responses.Reports;
using SolutionsByText.NET.Models.Responses.SmartUrl;
using SolutionsByText.NET.Models.Responses.Subscriptions;
using SolutionsByText.NET.Models.Responses.Templates;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization.Metadata;

namespace SolutionsByText.NET;

public class SolutionsByTextClient : ISolutionsByTextClient
{
    private readonly HttpClient _httpClient;
    private readonly string _baseUrl;
    private readonly string _tokenUrl;
    private readonly string _clientId;
    private readonly string _clientSecret;
    private readonly AsyncRetryPolicy<HttpResponseMessage> _retryPolicy;
    private readonly AsyncPolicy<HttpResponseMessage> _unauthorizedPolicy;
    private string? _accessToken;
    private TimeSpan _tokenExpiresIn;
    private readonly Stopwatch _tokenStopwatch;
    private readonly TimeSpan _tokenRefreshMargin;
    private static readonly bool _enableResponseLogging = Environment.GetEnvironmentVariable("SBT_DEBUG_RESPONSES") == "true";

    public SolutionsByTextClient(string baseUrl, string tokenUrl, string clientId, string clientSecret)
    {
        _baseUrl = baseUrl;
        _tokenUrl = tokenUrl;
        _clientId = clientId;
        _clientSecret = clientSecret;
        _httpClient = new HttpClient();
        _tokenStopwatch = new Stopwatch();
        _tokenRefreshMargin = TimeSpan.FromSeconds(300);
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
        _unauthorizedPolicy = Policy
            .HandleResult<HttpResponseMessage>(r => r.StatusCode == HttpStatusCode.Unauthorized)
            .WaitAndRetryAsync(1, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)),
                async (outcome, retryAttempt, context) =>
                {
                    Console.WriteLine(
                        $"Unauthorized response. Refreshing token and retrying request. Attempt {retryAttempt}");
                    await RefreshTokenAsync();
                });
    }

    /// <inheritdoc />
    public async Task<SendMessageResponse?> SendMessageAsync(SendMessageRequest request)
    {
        var endpoint = $"{_baseUrl}/groups/{request.GroupId}/messages";
        return await SendPostAsync<SendMessageRequest, SendMessageResponse?>(endpoint, request);
    }

    /// <inheritdoc />
    public async Task<SendTemplateMessageResponse?> SendTemplateMessageAsync(SendTemplateMessageRequest request)
    {
        var endpoint = $"{_baseUrl}/groups/{request.GroupId}/template-messages";
        return await SendPostAsync<SendTemplateMessageRequest, SendTemplateMessageResponse?>(endpoint, request);
    }

    /// <inheritdoc />
    public async Task<ScheduleMessageResponse?> ScheduleMessageAsync(ScheduleMessageRequest request)
    {
        var endpoint = $"{_baseUrl}/groups/{request.GroupId}/schedule-messages";
        return await SendPostAsync<ScheduleMessageRequest, ScheduleMessageResponse?>(endpoint, request);
    }

    /// <inheritdoc />
    public async Task<GetGroupSubscriberStatusResponse?> GetGroupSubscriberStatusAsync(
        GetGroupSubscriberStatusRequest request)
    {
        var queryParams = new Dictionary<string, string?>
        {
            { "msisdn", request.Msisdn != null ? string.Join(",", request.Msisdn) : string.Empty }
        };

        var endpoint =
            this.ConstructEndpointWithQueryParams(_baseUrl, $"/groups/{request.GroupId}/subscribers/status",
                queryParams);
        return await SendGetAsync<GetGroupSubscriberStatusResponse?>(endpoint);
    }

    /// <inheritdoc />
    public async Task<AddSubscriberResponse?> AddGroupSubscriberAsync(AddGroupSubscriberRequest request)
    {
        var endpoint = $"{_baseUrl}/groups/{request.GroupId}/subscribers";
        return await SendPostAsync<AddGroupSubscriberRequest, AddSubscriberResponse?>(endpoint, request);
    }

    /// <inheritdoc />
    public async Task<ConfirmGroupSubscriberResponse?> ConfirmSubscriberAsync(ConfirmGroupSubscriberRequest request)
    {
        var endpoint = $"{_baseUrl}/groups/{request.GroupId}/subscribers/{request.Msisdn}/verification";
        return await SendPostAsync<ConfirmGroupSubscriberRequest, ConfirmGroupSubscriberResponse?>(endpoint, request);
    }

    /// <inheritdoc />
    public async Task<DeleteSubscriberResponse?> DeleteSubscriberAsync(DeleteSubscriberRequest request)
    {
        var endpoint = $"{_baseUrl}/groups/{request.GroupId}/subscribers/{request.Msisdn}/";
        return await SendDeleteAsync<DeleteSubscriberResponse?>(endpoint);
    }

    /// <inheritdoc />
    public async Task<ReactivateSubscriberResponse?> ReactivateSubscriberAsync(ReactivateSubscriberRequest request)
    {
        var endpoint = $"{_baseUrl}/groups/{request.GroupId}/subscribers/{request.Msisdn}/reactivation-request";
        return await SendPostAsync<ReactivateSubscriberRequest, ReactivateSubscriberResponse?>(endpoint, request);
    }

    /// <inheritdoc />
    public async Task<CancelSubscriptionResponse?> CancelSubscriptionAsync(CancelSubscriptionRequest request)
    {
        var endpoint = $"{_baseUrl}/groups/{request.GroupId}/subscribers/{request.Msisdn}/subscription-cancellation";
        return await SendPostAsync<CancelSubscriptionRequest, CancelSubscriptionResponse?>(endpoint, request);
    }

    /// <inheritdoc />
    public async Task<UpdateSubscriberDataResponse?> UpdateSubscriberDataAsync(UpdateSubscriberDataRequest request)
    {
        // Note: The API spec has double brackets {{groupId}} but we use single brackets
        var endpoint = $"{_baseUrl}/groups/{request.GroupId}/subscribers";
        return await SendPutAsync<UpdateSubscriberDataRequest, UpdateSubscriberDataResponse?>(endpoint, request);
    }



    /// <inheritdoc />
    public async Task<GetOutboundMessagesResponse?> GetOutboundMessagesAsync(GetOutboundMessagesRequest request)
    {
        var queryParams = new Dictionary<string, string?>
        {
            { "messageId", request.MessageId },
            { "referenceId", request.ReferenceId },
            { "fromDate", request.FromDate?.ToString("O") },
            { "toDate", request.ToDate?.ToString("O") },
            { "timeZoneOffset", request.TimeZoneOffset },
            { "type", request.Type?.ToString() },
            { "pageNumber", request.PageNumber?.ToString() },
            { "pageSize", request.PageSize?.ToString() }
        };
        var endpoint = this.ConstructEndpointWithQueryParams(_baseUrl, $"/groups/{request.GroupId}/outbound-messages", queryParams);
        return await SendGetAsync<GetOutboundMessagesResponse?>(endpoint);
    }

    /// <inheritdoc />
    public async Task<GetInboundMessagesResponse?> GetInboundMessagesAsync(GetInboundMessagesRequest request)
    {
        var queryParams = new Dictionary<string, string?>
        {
            { "referenceId", request.ReferenceId },
            { "fromDate", request.FromDate?.ToString("O") },
            { "toDate", request.ToDate?.ToString("O") },
            { "timeZoneOffset", request.TimeZoneOffset },
            { "type", request.Type?.ToString() },
            { "pageNumber", request.PageNumber?.ToString() },
            { "pageSize", request.PageSize?.ToString() }
        };
        var endpoint = this.ConstructEndpointWithQueryParams(_baseUrl, $"/groups/{request.GroupId}/inbound-messages", queryParams);
        return await SendGetAsync<GetInboundMessagesResponse?>(endpoint);
    }

    /// <inheritdoc />
    public async Task<CreateSmartURLResponse?> CreateSmartURLAsync(CreateSmartURLRequest request)
    {
        var endpoint = $"{_baseUrl}/groups/{request.GroupId}/shortUrls";
        return await SendPostAsync<CreateSmartURLRequest, CreateSmartURLResponse?>(endpoint, request);
    }

    /// <inheritdoc />
    public async Task<GetPhoneNumberDataResponse?> GetPhoneNumberDataAsync(GetPhoneNumberDataRequest request)
    {
        var queryParams = new Dictionary<string, string?>
        {
            { "msisdn", string.Join(",", request.Msisdn) },
            { "includes", request.Includes }
        };
        var endpoint = this.ConstructEndpointWithQueryParams(_baseUrl, "/phonenumbers-data", queryParams);
        return await SendGetAsync<GetPhoneNumberDataResponse?>(endpoint);
    }

    /// <inheritdoc />
    public async Task<AddSubscriberResponse?> AddBrandSubscriberAsync(AddBrandSubscriberRequest request)
    {
        var endpoint = $"{_baseUrl}/brands/{request.BrandId}/subscribers";
        return await SendPostAsync<AddBrandSubscriberRequest, AddSubscriberResponse?>(endpoint, request);
    }

    /// <inheritdoc />
    public async Task<AddSubscriberResponse?> AddBrandSubscriberV2Async(AddBrandSubscriberRequest request)
    {
        var endpoint = $"{_baseUrl}/v2/brands/{request.BrandId}/subscribers";
        return await SendPostAsync<AddBrandSubscriberRequest, AddSubscriberResponse?>(endpoint, request);
    }

    /// <inheritdoc />
    public async Task<ConfirmBrandSubscriberResponse?> ConfirmBrandSubscriberAsync(
        ConfirmBrandSubscriberRequest request)
    {
        var endpoint = $"{_baseUrl}/brands/{request.BrandId}/subscribers/{request.Msisdn}/verification";
        return await SendPostAsync<ConfirmBrandSubscriberRequest, ConfirmBrandSubscriberResponse?>(endpoint, request);
    }

    /// <inheritdoc />
    public async Task<ScheduleTemplateMessageResponse?> ScheduleTemplateMessageAsync(
        ScheduleTemplateMessageRequest request)
    {
        var endpoint = $"{_baseUrl}/groups/{request.GroupId}/schedule-template-messages";
        return await SendPostAsync<ScheduleTemplateMessageRequest, ScheduleTemplateMessageResponse?>(endpoint, request);
    }

    /// <inheritdoc />
    public async Task<SendODMMessageResponse?> SendODMMessageAsync(SendODMMessageRequest request)
    {
        var endpoint = $"{_baseUrl}/groups/{request.GroupId}/odm/message";
        return await SendPostAsync<SendODMMessageRequest, SendODMMessageResponse?>(endpoint, request);
    }

    /// <inheritdoc />
    public async Task<VerifyODMResponse?> VerifyODMAsync(VerifyODMRequest request)
    {
        var endpoint = $"{_baseUrl}/groups/{request.GroupId}/odm/{request.Msisdn}/verification";
        return await SendPostAsync<VerifyODMRequest, VerifyODMResponse?>(endpoint, request);
    }

    /// <inheritdoc />
    public async Task<GetDeactivationEventsResponse?> GetDeactivationEventsAsync(GetDeactivationEventsRequest request)
    {
        var queryParams = new Dictionary<string, string?>
        {
            { "EventDate", request.EventDate.ToString("O") },
            { "EventType", request.EventType },
            { "CountryCode", request.CountryCode },
            { "pageNumber", request.PageNumber?.ToString() },
            { "pageSize", request.PageSize?.ToString() }
        };
        var endpoint = this.ConstructEndpointWithQueryParams(_baseUrl, "/accounts/deactevents", queryParams);
        return await SendGetAsync<GetDeactivationEventsResponse?>(endpoint);
    }

    /// <inheritdoc />
    public async Task<UpdateSmartURLResponse?> UpdateSmartURLAsync(UpdateSmartURLRequest request)
    {
        var endpoint =
            $"{_baseUrl}/groups/{request.GroupId}/shortUrls/{request.ShortUrl}";

        return await SendPatchAsync<UpdateSmartURLRequest, UpdateSmartURLResponse?>(endpoint, request);
    }


    /// <inheritdoc />
    public async Task<GetKeywordsResponse?> GetKeywordsAsync(GetKeywordsRequest request)
    {
        var queryParams = new Dictionary<string, string?>
        {
            { "filter", request.Filter },
            { "pageNumber", request.PageNumber?.ToString() },
            { "pageSize", request.PageSize?.ToString() }
        };
        var endpoint =
            this.ConstructEndpointWithQueryParams(_baseUrl, $"/groups/{request.GroupId}/keywords", queryParams);
        return await SendGetAsync<GetKeywordsResponse?>(endpoint);
    }

    /// <inheritdoc />
    public async Task<RetrieveMMSResponse?> RetrieveMMSAsync(RetrieveMMSRequest request)
    {
        var endpoint = $"{_baseUrl}/groups/{request.GroupId}/media-messages/{request.MessageId}/file/{request.FileId}";

        return await SendGetAsync<RetrieveMMSResponse?>(endpoint);
    }

    /// <inheritdoc />
    public async Task<DeleteMMSResponse?> DeleteMMSAsync(DeleteMMSRequest request)
    {
        var endpoint = $"{_baseUrl}/groups/{request.GroupId}/media-messages/{request.MessageId}/file/{request.FileId}";

        return await SendDeleteAsync<DeleteMMSResponse?>(endpoint);
    }

    /// <inheritdoc />
    public async Task<GetBrandSubscriberStatusResponse?> GetBrandSubscriberStatusAsync(
        GetBrandSubscriberStatusRequest request)
    {
        var queryParams = new Dictionary<string, string?>
        {
            { "msisdn", request.Msisdn }
        };
        var endpoint =
            this.ConstructEndpointWithQueryParams(_baseUrl, $"/brands/{request.BrandId}/subscribers/status",
                queryParams);
        return await SendGetAsync<GetBrandSubscriberStatusResponse?>(endpoint);
    }


    /// <inheritdoc />
    public async Task<GetNumberDeactivateEventsResponse?> GetNumberDeactivationEventsAsync(
        GetNumberDeactivateEventsRequest request)
    {
        var queryParams = new Dictionary<string, string?>
        {
            { "CountryCode", request.CountryCode },
            { "fromDate", request.FromDate?.ToString("O") },
            { "toDate", request.ToDate?.ToString("O") },
            { "pageNumber", request.PageNumber?.ToString() },
            { "pageSize", request.PageSize?.ToString() }
        };
        var endpoint = this.ConstructEndpointWithQueryParams(_baseUrl,
            $"/groups/{request.GroupId}/phonenumbers/{request.Msisdn}/events", queryParams);

        return await SendGetAsync<GetNumberDeactivateEventsResponse?>(endpoint);
    }

    /// <inheritdoc />
    public async Task<GetTemplatesResponse?> GetTemplatesAsync(GetTemplatesRequest request)
    {
        var queryParams = new Dictionary<string, string?>
        {
            { "search", request.Search },
            { "pageNumber", request.PageNumber?.ToString() },
            { "pageSize", request.PageSize?.ToString() }
        };
        var endpoint =
            this.ConstructEndpointWithQueryParams(_baseUrl, $"/groups/{request.GroupId}/templates", queryParams);
        return await SendGetAsync<GetTemplatesResponse?>(endpoint);
    }

    /// <inheritdoc />
    public async Task<GetTemplateResponse?> GetTemplateAsync(GetTemplateRequest request)
    {
        var endpoint = $"{_baseUrl}/groups/{request.GroupId}/templates/{request.TemplateId}";
        return await SendGetAsync<GetTemplateResponse?>(endpoint);
    }


    /// <inheritdoc />
    public async Task<GetAllSmartUrlResponse?> GetAllSmartUrlsAsync(GetAllSmartUrlRequest request)
    {
        var queryParams = new Dictionary<string, string?>
        {
            { "fromDate", request.FromDate?.ToString("O") },
            { "toDate", request.ToDate?.ToString("O") },
            { "search", request.Search },
            { "shortUrl", request.ShortUrl },
            { "pageNumber", request.PageNumber?.ToString() },
            { "pageSize", request.PageSize?.ToString() }
        };
        var endpoint =
            this.ConstructEndpointWithQueryParams(_baseUrl, $"/groups/{request.GroupId}/shorturls",
                queryParams);

        return await SendGetAsync<GetAllSmartUrlResponse?>(endpoint);
    }

    /// <inheritdoc />
    public async Task<GetSmartUrlClickReportResponse?> GetSmartUrlClickReportAsync(GetSmartUrlReportRequest request)
    {
        var queryParams = new Dictionary<string, string?>
        {
            { "fromDate", request.FromDate?.ToString("O") },
            { "toDate", request.ToDate?.ToString("O") },
            { "isCustomSuffix", request.IsCustomSuffix?.ToString() },
            { "timeZoneOffset", request.TimeZoneOffset },
            { "shortUrl", request.ShortUrl },
            { "pageNumber", request.PageNumber?.ToString() },
            { "pageSize", request.PageSize?.ToString() }
        };
        var endpoint =
            this.ConstructEndpointWithQueryParams(_baseUrl, $"/brands/{request.BrandId}/shorturl-clicks",
                queryParams);

        return await SendGetAsync<GetSmartUrlClickReportResponse?>(endpoint);
    }

    /// <inheritdoc />
    public async Task<GetSmartUrlDetailClickReportResponse?> GetSmartUrlDetailedClickReportAsync(
        GetSmartUrlReportRequest request)
    {
        var queryParams = new Dictionary<string, string?>
        {
            { "fromDate", request.FromDate?.ToString("O") },
            { "toDate", request.ToDate?.ToString("O") },
            { "isCustomSuffix", request.IsCustomSuffix?.ToString() },
            { "timeZoneOffset", request.TimeZoneOffset },
            { "shortUrl", request.ShortUrl },
            { "pageNumber", request.PageNumber?.ToString() },
            { "pageSize", request.PageSize?.ToString() }
        };
        var endpoint =
            this.ConstructEndpointWithQueryParams(_baseUrl, $"/brands/{request.BrandId}/shorturl-click-details",
                queryParams);

        return await SendGetAsync<GetSmartUrlDetailClickReportResponse?>(endpoint);
    }

    /// <inheritdoc />
    public async Task<GetBrandVbtMessageResponse?> GetBrandVbtOutboundMessageAsync(
        GetBrandVbtOutboundMessageRequest request)
    {
        var queryParams = new Dictionary<string, string?>
        {
            { "brandId", request.BrandId },
            { "messageId", request.MessageId },
            { "referenceId", request.ReferenceId },
            { "fromDate", request.FromDate?.ToString("O") },
            { "toDate", request.ToDate?.ToString("O") },
            { "type", request.Type?.ToString() },
            { "timeZoneOffset", request.TimeZoneOffset },
            { "pageNumber", request.PageNumber?.ToString() },
            { "pageSize", request.PageSize?.ToString() }
        };
        var endpoint =
            this.ConstructEndpointWithQueryParams(_baseUrl, "/brand-vbt-outbound-messages",
                queryParams);

        return await SendGetAsync<GetBrandVbtMessageResponse?>(endpoint);
    }

    /// <inheritdoc />
    public async Task<GetBrandVbtMessageResponse?> GetBrandVbtInboundMessageAsync(
        GetBrandVbtInboundMessageRequest request)
    {
        var queryParams = new Dictionary<string, string?>
        {
            { "brandId", request.BrandId },
            { "referenceId", request.ReferenceId },
            { "fromDate", request.FromDate?.ToString("O") },
            { "toDate", request.ToDate?.ToString("O") },
            { "type", request.Type?.ToString() },
            { "timeZoneOffset", request.TimeZoneOffset },
            { "pageNumber", request.PageNumber?.ToString() },
            { "pageSize", request.PageSize?.ToString() }
        };
        var endpoint =
            this.ConstructEndpointWithQueryParams(_baseUrl, "/brand-vbt-inbound-messages",
                queryParams);

        return await SendGetAsync<GetBrandVbtMessageResponse?>(endpoint);
    }

    /// <inheritdoc />
    public async Task<GetUsageBrandBreakdownResponse?> GetUsageBrandBreakdownAsync(GetUsageBrandBreakdownRequest request)
    {
        var queryParams = new Dictionary<string, string?>
        {
            { "month", request.Month.ToString() },
            { "year", request.Year.ToString() },
            { "brandId", request.BrandId },
            { "productType", request.ProductType }
        };

        var endpoint = this.ConstructEndpointWithQueryParams(_baseUrl, "/reports/usage/brand-breakdown", queryParams);
        return await SendGetAsync<GetUsageBrandBreakdownResponse?>(endpoint);
    }

    /// <inheritdoc />
    public async Task<GetAllSubscribersGroupResponse?> GetAllSubscribersGroupAsync(
        GetAllSubscribersGroupRequest request)
    {
        var queryParams = new Dictionary<string, string?>
        {
            { "startsWith", request.StartsWith },
            { "search", request.Search },
            { "from", request.From },
            { "to", request.To },
            { "pageNumber", request.PageNumber?.ToString() },
            { "pageSize", request.PageSize?.ToString() }
        };
        var endpoint =
            this.ConstructEndpointWithQueryParams(_baseUrl, $"/groups/{request.GroupId}/subscribers",
                queryParams);

        return await SendGetAsync<GetAllSubscribersGroupResponse?>(endpoint);
    }

    /// <summary>
    /// Sends a GET request to the specified endpoint and returns the deserialized response.
    /// </summary>
    /// <typeparam name="TResponse">The type of the response data.</typeparam>
    /// <param name="endpoint">The API endpoint to send the request to.</param>
    /// <returns>The deserialized response data.</returns>
    /// <exception cref="InvalidOperationException">Thrown when the response type is not registered in the JSON context.</exception>
    /// <exception cref="ApiException">Thrown when the API returns an error or when an unexpected error occurs.</exception>
    private async Task<TResponse> SendGetAsync<TResponse>(string endpoint)
    {
        await EnsureValidTokenAsync();

        // TResponse should always be a response type that inherits from ApiResponse<T>
        var responseInfo = SolutionsByTextJsonContext.Default.GetTypeInfo(typeof(TResponse)) as JsonTypeInfo<TResponse>;
        if (responseInfo == null)
        {
            throw new InvalidOperationException(
                $"Type {typeof(TResponse)} is not registered in SolutionsByTextJsonContext.");
        }

        try
        {
            var response = await Policy.WrapAsync(_retryPolicy, _unauthorizedPolicy)
                .ExecuteAsync(async () => await _httpClient.GetAsync(endpoint));
                
            var responseContent = await response.Content.ReadAsStringAsync();
            
            // Log raw response for debugging when enabled
            if (_enableResponseLogging)
            {
                LogResponse(response, responseContent, typeof(TResponse).Name);
            }

            if (response.IsSuccessStatusCode)
            {
                var apiResponse = JsonSerializer.Deserialize(responseContent, responseInfo);
                if (apiResponse == null)
                {
                    throw new ApiException("Failed to deserialize the response.");
                }
                return apiResponse;
            }
            else
            {
                // Handle error responses from the API
                var errorResponse = JsonSerializer.Deserialize(responseContent,
                    SolutionsByTextJsonContext.Default.ErrorResponse);

                throw errorResponse != null
                    ? new ApiException(
                        errorResponse.AppCode ?? "Unknown app code",
                        errorResponse.Message ?? "Unknown error message"
                    )
                    : new ApiException(
                        response.StatusCode.ToString(),
                        responseContent ?? "No response content"
                    );
            }
        }
        catch (ApiException)
        {
            throw;
        }
        catch (JsonException jsonEx)
        {
            // Log the problematic response for debugging
            if (_enableResponseLogging)
            {
                Console.WriteLine($"[SBT Debug] JSON deserialization failed for {typeof(TResponse).Name}");
                Console.WriteLine($"[SBT Debug] Error: {jsonEx.Message}");
            }
            throw new ApiException($"JSON deserialization failed for {typeof(TResponse).Name}: {jsonEx.Message}", jsonEx.InnerException?.Message ?? "No inner exception");
        }
        catch (Exception ex)
        {
            throw new ApiException($"An unexpected error occurred: {ex.GetType().Name}", ex.Message);
        }
    }

    /// <summary>
    /// Sends a POST request with a JSON body to the specified endpoint.
    /// </summary>
    private async Task<TResponse> SendPostAsync<TRequest, TResponse>(string endpoint, TRequest request)
    {
        await EnsureValidTokenAsync();

        var requestInfo = SolutionsByTextJsonContext.Default.GetTypeInfo(typeof(TRequest)) as JsonTypeInfo<TRequest>;
        var responseInfo = SolutionsByTextJsonContext.Default.GetTypeInfo(typeof(TResponse)) as JsonTypeInfo<TResponse>;

        if (requestInfo == null || responseInfo == null)
        {
            throw new InvalidOperationException(
                $"Type {typeof(TRequest)} or {typeof(TResponse)} is not registered in SolutionsByTextJsonContext.");
        }

        try
        {
            var json = JsonSerializer.Serialize(request, requestInfo);
            using var content = new StringContent(json, Encoding.UTF8, "application/json");
            
            var response = await Policy.WrapAsync(_retryPolicy, _unauthorizedPolicy)
                .ExecuteAsync(async () => await _httpClient.PostAsync(endpoint, content));
                
            var responseContent = await response.Content.ReadAsStringAsync();
            
            // Log raw response for debugging when enabled
            if (_enableResponseLogging)
            {
                LogResponse(response, responseContent, typeof(TResponse).Name);
            }

            if (response.IsSuccessStatusCode)
            {
                var apiResponse = JsonSerializer.Deserialize(responseContent, responseInfo);
                if (apiResponse == null)
                {
                    throw new ApiException("Failed to deserialize the response.");
                }
                return apiResponse;
            }
            else
            {
                // Handle error responses from the API
                var errorResponse = JsonSerializer.Deserialize(responseContent,
                    SolutionsByTextJsonContext.Default.ErrorResponse);

                throw errorResponse != null
                    ? new ApiException(
                        errorResponse.AppCode ?? "Unknown app code",
                        errorResponse.Message ?? "Unknown error message"
                    )
                    : new ApiException(
                        response.StatusCode.ToString(),
                        responseContent ?? "No response content"
                    );
            }
        }
        catch (ApiException)
        {
            throw;
        }
        catch (JsonException jsonEx)
        {
            // Log the problematic response for debugging
            if (_enableResponseLogging)
            {
                Console.WriteLine($"[SBT Debug] JSON deserialization failed for {typeof(TResponse).Name}");
                Console.WriteLine($"[SBT Debug] Error: {jsonEx.Message}");
            }
            throw new ApiException($"JSON deserialization failed for {typeof(TResponse).Name}: {jsonEx.Message}", jsonEx.InnerException?.Message ?? "No inner exception");
        }
        catch (Exception ex)
        {
            throw new ApiException($"An unexpected error occurred: {ex.GetType().Name}", ex.Message);
        }
    }

    /// <summary>
    /// Sends a PUT request with a JSON body to the specified endpoint.
    /// </summary>
    private async Task<TResponse> SendPutAsync<TRequest, TResponse>(string endpoint, TRequest request)
    {
        await EnsureValidTokenAsync();

        var requestInfo = SolutionsByTextJsonContext.Default.GetTypeInfo(typeof(TRequest)) as JsonTypeInfo<TRequest>;
        var responseInfo = SolutionsByTextJsonContext.Default.GetTypeInfo(typeof(TResponse)) as JsonTypeInfo<TResponse>;

        if (requestInfo == null || responseInfo == null)
        {
            throw new InvalidOperationException(
                $"Type {typeof(TRequest)} or {typeof(TResponse)} is not registered in SolutionsByTextJsonContext.");
        }

        try
        {
            var json = JsonSerializer.Serialize(request, requestInfo);
            using var content = new StringContent(json, Encoding.UTF8, "application/json");
            
            var response = await Policy.WrapAsync(_retryPolicy, _unauthorizedPolicy)
                .ExecuteAsync(async () => await _httpClient.PutAsync(endpoint, content));
                
            var responseContent = await response.Content.ReadAsStringAsync();
            
            // Log raw response for debugging when enabled
            if (_enableResponseLogging)
            {
                LogResponse(response, responseContent, typeof(TResponse).Name);
            }

            if (response.IsSuccessStatusCode)
            {
                var apiResponse = JsonSerializer.Deserialize(responseContent, responseInfo);
                if (apiResponse == null)
                {
                    throw new ApiException("Failed to deserialize the response.");
                }
                return apiResponse;
            }
            else
            {
                // Handle error responses from the API
                var errorResponse = JsonSerializer.Deserialize(responseContent,
                    SolutionsByTextJsonContext.Default.ErrorResponse);

                throw errorResponse != null
                    ? new ApiException(
                        errorResponse.AppCode ?? "Unknown app code",
                        errorResponse.Message ?? "Unknown error message"
                    )
                    : new ApiException(
                        response.StatusCode.ToString(),
                        responseContent ?? "No response content"
                    );
            }
        }
        catch (ApiException)
        {
            throw;
        }
        catch (JsonException jsonEx)
        {
            // Log the problematic response for debugging
            if (_enableResponseLogging)
            {
                Console.WriteLine($"[SBT Debug] JSON deserialization failed for {typeof(TResponse).Name}");
                Console.WriteLine($"[SBT Debug] Error: {jsonEx.Message}");
            }
            throw new ApiException($"JSON deserialization failed for {typeof(TResponse).Name}: {jsonEx.Message}", jsonEx.InnerException?.Message ?? "No inner exception");
        }
        catch (Exception ex)
        {
            throw new ApiException($"An unexpected error occurred: {ex.GetType().Name}", ex.Message);
        }
    }

    /// <summary>
    /// Sends a PATCH request with a JSON body to the specified endpoint.
    /// </summary>
    private async Task<TResponse> SendPatchAsync<TRequest, TResponse>(string endpoint, TRequest request)
    {
        await EnsureValidTokenAsync();

        var requestInfo = SolutionsByTextJsonContext.Default.GetTypeInfo(typeof(TRequest)) as JsonTypeInfo<TRequest>;
        var responseInfo = SolutionsByTextJsonContext.Default.GetTypeInfo(typeof(TResponse)) as JsonTypeInfo<TResponse>;

        if (requestInfo == null || responseInfo == null)
        {
            throw new InvalidOperationException(
                $"Type {typeof(TRequest)} or {typeof(TResponse)} is not registered in SolutionsByTextJsonContext.");
        }

        try
        {
            var json = JsonSerializer.Serialize(request, requestInfo);
            using var content = new StringContent(json, Encoding.UTF8, "application/json");
            
            var response = await Policy.WrapAsync(_retryPolicy, _unauthorizedPolicy)
                .ExecuteAsync(async () => await _httpClient.PatchAsync(endpoint, content));
                
            var responseContent = await response.Content.ReadAsStringAsync();
            
            // Log raw response for debugging when enabled
            if (_enableResponseLogging)
            {
                LogResponse(response, responseContent, typeof(TResponse).Name);
            }

            if (response.IsSuccessStatusCode)
            {
                var apiResponse = JsonSerializer.Deserialize(responseContent, responseInfo);
                if (apiResponse == null)
                {
                    throw new ApiException("Failed to deserialize the response.");
                }
                return apiResponse;
            }
            else
            {
                // Handle error responses from the API
                var errorResponse = JsonSerializer.Deserialize(responseContent,
                    SolutionsByTextJsonContext.Default.ErrorResponse);

                throw errorResponse != null
                    ? new ApiException(
                        errorResponse.AppCode ?? "Unknown app code",
                        errorResponse.Message ?? "Unknown error message"
                    )
                    : new ApiException(
                        response.StatusCode.ToString(),
                        responseContent ?? "No response content"
                    );
            }
        }
        catch (ApiException)
        {
            throw;
        }
        catch (JsonException jsonEx)
        {
            // Log the problematic response for debugging
            if (_enableResponseLogging)
            {
                Console.WriteLine($"[SBT Debug] JSON deserialization failed for {typeof(TResponse).Name}");
                Console.WriteLine($"[SBT Debug] Error: {jsonEx.Message}");
            }
            throw new ApiException($"JSON deserialization failed for {typeof(TResponse).Name}: {jsonEx.Message}", jsonEx.InnerException?.Message ?? "No inner exception");
        }
        catch (Exception ex)
        {
            throw new ApiException($"An unexpected error occurred: {ex.GetType().Name}", ex.Message);
        }
    }

    /// <summary>
    /// Sends a DELETE request to the specified endpoint (no request body).
    /// </summary>
    private async Task<TResponse> SendDeleteAsync<TResponse>(string endpoint)
    {
        await EnsureValidTokenAsync();

        var responseInfo = SolutionsByTextJsonContext.Default.GetTypeInfo(typeof(TResponse)) as JsonTypeInfo<TResponse>;

        if (responseInfo == null)
        {
            throw new InvalidOperationException(
                $"Type {typeof(TResponse)} is not registered in SolutionsByTextJsonContext.");
        }

        try
        {
            var response = await Policy.WrapAsync(_retryPolicy, _unauthorizedPolicy)
                .ExecuteAsync(async () => await _httpClient.DeleteAsync(endpoint));
                
            var responseContent = await response.Content.ReadAsStringAsync();
            
            // Log raw response for debugging when enabled
            if (_enableResponseLogging)
            {
                LogResponse(response, responseContent, typeof(TResponse).Name);
            }

            if (response.IsSuccessStatusCode)
            {
                var apiResponse = JsonSerializer.Deserialize(responseContent, responseInfo);
                if (apiResponse == null)
                {
                    throw new ApiException("Failed to deserialize the response.");
                }
                return apiResponse;
            }
            else
            {
                // Handle error responses from the API
                var errorResponse = JsonSerializer.Deserialize(responseContent,
                    SolutionsByTextJsonContext.Default.ErrorResponse);

                throw errorResponse != null
                    ? new ApiException(
                        errorResponse.AppCode ?? "Unknown app code",
                        errorResponse.Message ?? "Unknown error message"
                    )
                    : new ApiException(
                        response.StatusCode.ToString(),
                        responseContent ?? "No response content"
                    );
            }
        }
        catch (ApiException)
        {
            throw;
        }
        catch (JsonException jsonEx)
        {
            // Log the problematic response for debugging
            if (_enableResponseLogging)
            {
                Console.WriteLine($"[SBT Debug] JSON deserialization failed for {typeof(TResponse).Name}");
                Console.WriteLine($"[SBT Debug] Error: {jsonEx.Message}");
            }
            throw new ApiException($"JSON deserialization failed for {typeof(TResponse).Name}: {jsonEx.Message}", jsonEx.InnerException?.Message ?? "No inner exception");
        }
        catch (Exception ex)
        {
            throw new ApiException($"An unexpected error occurred: {ex.GetType().Name}", ex.Message);
        }
    }


    //Get the bearer token and start the stopwatch
    private async Task ObtainBearerTokenAsync()
    {
        // Check if the tokenUrl already contains the full path
        var tokenEndpoint = _tokenUrl.EndsWith("/connect/token") 
            ? _tokenUrl 
            : $"{_tokenUrl}/connect/token";

        // Prepare the request content for obtaining the bearer token (used x-www-form-urlencoded). 
        var contentString = $@"client_id={Uri.EscapeDataString(_clientId)}&" +
                            $"client_secret={Uri.EscapeDataString(_clientSecret)}&" +
                            $"grant_type={Uri.EscapeDataString("client_credentials")}";

        var content = new StringContent(contentString, Encoding.UTF8, "application/x-www-form-urlencoded");

        // Send the request to obtain the token.
        var response = await _httpClient.PostAsync(tokenEndpoint, content);

        if (response.IsSuccessStatusCode)
        {
            // Read and deserialize the token response.
            var jsonResponse = await response.Content.ReadAsStringAsync();
            var tokenResponse =
                JsonSerializer.Deserialize(jsonResponse, SolutionsByTextJsonContext.Default.TokenResponse);

            if (tokenResponse != null)
            {
                // Set the access token and its expiration.
                var tokenType = tokenResponse.TokenType ?? "Bearer";

            // Set the access token and its expiration.
            _accessToken = tokenResponse.AccessToken;
            _tokenExpiresIn = TimeSpan.FromSeconds(tokenResponse.ExpiresIn);
            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue(tokenType, _accessToken);
            _tokenStopwatch.Restart();
            }
            else
            {
                throw new ApiException("Failed to deserialize the token response.");
            }
        }
        else
        {
            throw new ApiException("Failed to obtain access token", response.StatusCode.ToString());
        }
    }


    //Responsible for Refreshing a token incase its missing or Expired
    private async Task EnsureValidTokenAsync()
    {
        // Execute the retry policy to ensure the token is valid.
        await _retryPolicy.ExecuteAsync(async () =>
        {
            if (IsTokenExpiredOrMissing())
            {
                await RefreshTokenAsync(); // Refresh the token if it's expired or missing.
            }

            return new HttpResponseMessage(HttpStatusCode.OK); // Return a successful response.
        });
    }

    private bool IsTokenExpiredOrMissing()
    {
        // Check if the token is either missing or has expired, used margin to refresh before it expired 
        return string.IsNullOrEmpty(_accessToken) ||
               _tokenStopwatch.Elapsed > (_tokenExpiresIn - _tokenRefreshMargin);
    }

    /// <summary>
    /// Logs HTTP response details for debugging purposes.
    /// </summary>
    private static void LogResponse(HttpResponseMessage response, string responseContent, string expectedType)
    {
        try
        {
            var logDir = Path.Combine(Path.GetTempPath(), "sbt-debug");
            Directory.CreateDirectory(logDir);
            var timestamp = DateTime.UtcNow.ToString("yyyyMMdd-HHmmss-fff");
            var statusCode = (int)response.StatusCode;
            var logFile = Path.Combine(logDir, $"{timestamp}_{statusCode}_{expectedType}.json");
            
            // Pretty print the JSON for readability
            string prettyJson;
            try
            {
                var jsonDoc = JsonDocument.Parse(responseContent);
                prettyJson = JsonSerializer.Serialize(jsonDoc, new JsonSerializerOptions { WriteIndented = true });
            }
            catch
            {
                // If not valid JSON, save as-is
                prettyJson = responseContent;
            }
            
            File.WriteAllText(logFile, prettyJson);
            Console.WriteLine($"[SBT Debug] Response logged to: {logFile}");
            Console.WriteLine($"[SBT Debug] Status: {response.StatusCode}, Type: {expectedType}");
            Console.WriteLine($"[SBT Debug] Request URI: {response.RequestMessage?.RequestUri}");
            
            // Also log first 500 chars to console for immediate visibility
            var preview = responseContent.Length > 500 ? responseContent.Substring(0, 500) + "..." : responseContent;
            Console.WriteLine($"[SBT Debug] Response preview: {preview}");
        }
        catch (Exception logEx)
        {
            Console.WriteLine($"[SBT Debug] Failed to log response: {logEx.Message}");
        }
    }

    private async Task RefreshTokenAsync()
    {
        try
        {
            await ObtainBearerTokenAsync(); // Obtain a new bearer token.
            Console.WriteLine("Token refreshed successfully.");
        }
        catch (ApiException ex)
        {
            Console.WriteLine($"Failed to refresh token: {ex.Message}");
            throw;
        }
    }
}