using Polly;
using Polly.Retry;
using SolutionsByText.NET.Models.Exceptions;
using SolutionsByText.NET.Models.Requests;
using SolutionsByText.NET.Models.Responses;
using System.Diagnostics;
using System.Net;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Serialization.Metadata;

namespace SolutionsByText.NET;

public class SolutionsByTextClient : ISolutionsByTextClient
{
    private readonly HttpClient _httpClient;
    private readonly string _baseUrl;
    private readonly string _clientId;
    private readonly string _clientSecret;
    private readonly AsyncRetryPolicy<HttpResponseMessage> _retryPolicy;
    private string _accessToken;
    private int _tokenExpiresIn;
    private readonly Stopwatch _tokenStopwatch;
    private readonly int _tokenRefreshMargin;

    public SolutionsByTextClient(string baseUrl, string clientId, string clientSecret)
    {
        _baseUrl = baseUrl;
        _clientId = clientId;
        _clientSecret = clientSecret;
        _httpClient = new HttpClient();
        _tokenStopwatch = new Stopwatch();
        _tokenRefreshMargin = 300;
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

    /// <inheritdoc />
    public async Task<SendMessageResponse?> SendMessageAsync(SendMessageRequest request)
    {
        var endpoint = $"{_baseUrl}/groups/{request.GroupId}/messages";
        return await SendRequestAsync<SendMessageRequest, SendMessageResponse?>(HttpMethod.Post, endpoint, request);
    }

    /// <inheritdoc />
    public async Task<SendTemplateMessageResponse?> SendTemplateMessageAsync(SendTemplateMessageRequest request)
    {
        var endpoint = $"{_baseUrl}/groups/{request.GroupId}/template-messages";
        return await SendRequestAsync<SendTemplateMessageRequest, SendTemplateMessageResponse?>(HttpMethod.Post,
            endpoint, request);
    }

    /// <inheritdoc />
    public async Task<ScheduleMessageResponse?> ScheduleMessageAsync(ScheduleMessageRequest request)
    {
        var endpoint = $"{_baseUrl}/groups/{request.GroupId}/schedule-messages";
        return await SendRequestAsync<ScheduleMessageRequest, ScheduleMessageResponse?>(HttpMethod.Post, endpoint,
            request);
    }

    /// <inheritdoc />
    public async Task<GetSubscriberStatusResponse?> GetSubscriberStatusAsync(GetSubscriberStatusRequest request)
    {
        var queryParams = new Dictionary<string, string?>
        {
            { "msisdn", string.Join(",", request.Msisdn) }
        };
        var endpoint =
            this.ConstructEndpointWithQueryParams(_baseUrl, $"/groups/{request.GroupId}/subscribers/status",
                queryParams);
        return await SendRequestAsync<GetSubscriberStatusRequest, GetSubscriberStatusResponse?>(HttpMethod.Get,
            endpoint);
    }

    /// <inheritdoc />
    public async Task<AddSubscriberResponse?> AddGroupSubscriberAsync(AddGroupSubscriberRequest request)
    {
        var endpoint = $"{_baseUrl}/groups/{request.GroupId}/subscribers";
        return await SendRequestAsync<AddGroupSubscriberRequest, AddSubscriberResponse?>(HttpMethod.Post, endpoint,
            request);
    }

    /// <inheritdoc />
    public async Task<ConfirmSubscriberResponse?> ConfirmSubscriberAsync(ConfirmSubscriberRequest request)
    {
        var endpoint = $"{_baseUrl}/groups/{request.GroupId}/subscribers/{request.Msisdn}/verification";
        return await SendRequestAsync<ConfirmSubscriberRequest, ConfirmSubscriberResponse?>(HttpMethod.Post, endpoint,
            request);
    }

    /// <inheritdoc />
    public async Task<DeleteSubscriberResponse?> DeleteSubscriberAsync(DeleteSubscriberRequest request)
    {
        var endpoint = $"{_baseUrl}/groups/{request.GroupId}/subscribers/{request.Msisdn}";
        return await SendRequestAsync<DeleteSubscriberRequest, DeleteSubscriberResponse?>(HttpMethod.Delete, endpoint);
    }

    /// <inheritdoc />
    public async Task<GetGroupResponse?> GetGroupAsync(GetGroupRequest request)
    {
        var endpoint = $"{_baseUrl}/groups/{request.GroupId}";
        return await SendRequestAsync<GetGroupRequest, GetGroupResponse?>(HttpMethod.Get, endpoint);
    }

    /// <inheritdoc />
    public async Task<GetOutboundMessagesResponse?> GetOutboundMessagesAsync(GetOutboundMessagesRequest request)
    {
        var endpoint = $"{_baseUrl}/groups/{request.GroupId}/outbound-messages";
        return await SendRequestAsync<GetOutboundMessagesRequest, GetOutboundMessagesResponse?>(HttpMethod.Get,
            endpoint);
    }

    /// <inheritdoc />
    public async Task<GetInboundMessagesResponse?> GetInboundMessagesAsync(GetInboundMessagesRequest request)
    {
        var endpoint = $"{_baseUrl}/groups/{request.GroupId}/inbound-messages";
        return await SendRequestAsync<GetInboundMessagesRequest, GetInboundMessagesResponse?>(HttpMethod.Get, endpoint);
    }

    /// <inheritdoc />
    public async Task<CreateSmartURLResponse?> CreateSmartURLAsync(CreateSmartURLRequest request)
    {
        var endpoint = $"{_baseUrl}/groups/{request.GroupId}/shortUrls";
        return await SendRequestAsync<CreateSmartURLRequest, CreateSmartURLResponse?>(HttpMethod.Post, endpoint,
            request);
    }

    /// <inheritdoc />
    public async Task<GetPhoneNumberDataResponse?> GetPhoneNumberDataAsync(GetPhoneNumberDataRequest request)
    {
        var queryParams = new Dictionary<string, string?>
        {
            { "msisdn", string.Join(",", request.Msisdn) }
        };
        var endpoint = this.ConstructEndpointWithQueryParams(_baseUrl, "/phonenumbers-data", queryParams);
        return await SendRequestAsync<GetPhoneNumberDataRequest, GetPhoneNumberDataResponse?>(HttpMethod.Get, endpoint);
    }

    /// <inheritdoc />
    public async Task<AddSubscriberResponse?> AddBrandSubscriberAsync(AddBrandSubscriberRequest request)
    {
        var endpoint = $"{_baseUrl}/brands/{request.BrandId}/subscribers";
        return await SendRequestAsync<AddBrandSubscriberRequest, AddSubscriberResponse?>(HttpMethod.Post, endpoint,
            request);
    }

    /// <inheritdoc />
    public async Task<ConfirmBrandSubscriberResponse?> ConfirmBrandSubscriberAsync(
        ConfirmBrandSubscriberRequest request)
    {
        var endpoint = $"{_baseUrl}/brands/{request.BrandId}/subscribers/{request.Msisdn}/verification";
        return await SendRequestAsync<ConfirmBrandSubscriberRequest, ConfirmBrandSubscriberResponse?>(HttpMethod.Post,
            endpoint, request);
    }

    /// <inheritdoc />
    public async Task<ScheduleTemplateMessageResponse?> ScheduleTemplateMessageAsync(
        ScheduleTemplateMessageRequest request)
    {
        var endpoint = $"{_baseUrl}/groups/{request.GroupId}/schedule-template-messages";
        return await SendRequestAsync<ScheduleTemplateMessageRequest, ScheduleTemplateMessageResponse?>(HttpMethod.Post,
            endpoint, request);
    }

    /// <inheritdoc />
    public async Task<GetDeactivationEventsResponse?> GetDeactivationEventsAsync(GetDeactivationEventsRequest request)
    {
        var queryParams = new Dictionary<string, string?>
        {
            { "EventDate", request.EventDate.ToString() },
            { "EventType", request.EventType },
            { "CountryCode", request.CountryCode },
            { "pageNumber", request.PageNumber?.ToString() },
            { "pageSize", request.PageSize?.ToString() }
        };
        var endpoint = this.ConstructEndpointWithQueryParams(_baseUrl, "/accounts/deactevents", queryParams);
        return await SendRequestAsync<GetDeactivationEventsRequest, GetDeactivationEventsResponse?>(HttpMethod.Get,
            endpoint);
    }

    /// <inheritdoc />
    public async Task<UpdateSmartURLResponse?> UpdateSmartURLAsync(UpdateSmartURLRequest request)
    {
        var endpoint =
            $"{_baseUrl}/groups/{request.GroupId}/shortUrls/{request.ShortUrl}";

        return await SendRequestAsync<UpdateSmartURLRequest, UpdateSmartURLResponse?>(HttpMethod.Patch,
            endpoint, request);
    }

    /// <inheritdoc />
    public async Task<AddKeywordResponse?> AddKeywordAsync(AddKeywordRequest request)
    {
        var endpoint = $"{_baseUrl}/groups/{request.GroupId}/keywords";

        return await SendRequestAsync<AddKeywordRequest, AddKeywordResponse?>(HttpMethod.Post,
            endpoint, request);
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
        return await SendRequestAsync<GetKeywordsRequest, GetKeywordsResponse?>(HttpMethod.Get, endpoint, request);
    }

    /// <inheritdoc />
    public async Task<RetrieveMMSResponse?> RetrieveMMSAsync(RetrieveMMSRequest request)
    {
        var endpoint = $"{_baseUrl}/groups/{request.GroupId}/media-messages/{request.MessageId}/file/{request.FileId}";

        return await SendRequestAsync<RetrieveMMSRequest, RetrieveMMSResponse?>(HttpMethod.Get,
            endpoint);
    }

    /// <inheritdoc />
    public async Task<DeleteMMSResponse?> DeleteMMSAsync(DeleteMMSRequest request)
    {
        var endpoint = $"{_baseUrl}/groups/{request.GroupId}/media-messages/{request.MessageId}/file/{request.FileId}";

        return await SendRequestAsync<DeleteMMSRequest, DeleteMMSResponse?>(HttpMethod.Delete,
            endpoint);
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
        return await SendRequestAsync<GetBrandSubscriberStatusRequest, GetBrandSubscriberStatusResponse?>(
            HttpMethod.Get, endpoint);
    }

    /// <inheritdoc />
    public async Task<UpdateSubscribersBrandResponse?> UpdateSubscribersBrand(UpdateSubscribersBrandRequest request)
    {
        var endpoint =
            $"{_baseUrl}/groups/{request.GroupId}/subscribers";

        return await SendRequestAsync<UpdateSubscribersBrandRequest?, UpdateSubscribersBrandResponse?>(HttpMethod.Patch,
            endpoint, request);
    }

    /// <inheritdoc />
    public async Task<GetNumberDeactivateEventsResponse?> GetNumberDeactivationEventsAsync(
        GetNumberDeactivateEventsRequest request)
    {
        var queryParams = new Dictionary<string, string?>
        {
            { "CountryCode", request.CountryCode },
            { "fromDate", request.FromDate?.ToString() },
            { "toDate", request.ToDate?.ToString() },
            { "pageNumber", request.PageNumber?.ToString() },
            { "pageSize", request.PageSize?.ToString() }
        };
        var endpoint = this.ConstructEndpointWithQueryParams(_baseUrl,
            $"/groups/{request.GroupId}/phonenumbers/{request.Msisdn}/events", queryParams);

        return await SendRequestAsync<GetNumberDeactivateEventsRequest, GetNumberDeactivateEventsResponse?>(
            HttpMethod.Get, endpoint);
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
        return await SendRequestAsync<GetTemplatesRequest, GetTemplatesResponse?>(HttpMethod.Get, endpoint);
    }

    /// <inheritdoc />
    public async Task<GetTemplateResponse?> GetTemplateAsync(GetTemplateRequest request)
    {
        var endpoint = $"{_baseUrl}/groups/{request.GroupId}/templates/{request.TemplateId}";
        return await SendRequestAsync<GetTemplateRequest, GetTemplateResponse?>(HttpMethod.Get, endpoint);
    }


    /// <inheritdoc />
    public async Task<GetAllSmartUrlResponse?> GetAllSmartUrlsAync(GetAllSmartUrlRequest request)
    {
        var queryParams = new Dictionary<string, string?>
        {
            { "fromDate", request.FromDate.ToString() },
            { "toDate", request.ToDate?.ToString() },
            { "search", request.Search },
            { "shortUrl", request.ShortUrl },
            { "pageNumber", request.PageNumber?.ToString() },
            { "pageSize", request.PageSize?.ToString() }
        };
        var endpoint =
            this.ConstructEndpointWithQueryParams(_baseUrl, $"/groups/{request.GroupId}/shorturls",
                queryParams);

        return await SendRequestAsync<GetAllSmartUrlRequest, GetAllSmartUrlResponse?>(HttpMethod.Get, endpoint);
    }

    /// <inheritdoc />
    public async Task<GetSmartUrlClickReportResponse?> GetSmartUrlClickReportAync(GetSmartUrlReportRequest request)
    {
        var queryParams = new Dictionary<string, string?>
        {
            { "fromDate", request.FromDate.ToString() },
            { "toDate", request.ToDate?.ToString() },
            { "isCustomSuffix", request.IsCustomSuffix?.ToString() },
            { "timeZoneOffset", request.TimeZoneOffset },
            { "shortUrl", request.ShortUrl },
            { "pageNumber", request.PageNumber?.ToString() },
            { "pageSize", request.PageSize?.ToString() }
        };
        var endpoint =
            this.ConstructEndpointWithQueryParams(_baseUrl, $"/brands/{request.BrandId}/shorturl-clicks",
                queryParams);

        return await SendRequestAsync<GetSmartUrlReportRequest, GetSmartUrlClickReportResponse?>(HttpMethod.Get,
            endpoint);
    }

    /// <inheritdoc />
    public async Task<GetSmartUrlDetailClickReportResponse?> GetSmartUrlDetailedClickReportAync(
        GetSmartUrlReportRequest request)
    {
        var queryParams = new Dictionary<string, string?>
        {
            { "fromDate", request.FromDate.ToString() },
            { "toDate", request.ToDate?.ToString() },
            { "isCustomSuffix", request.IsCustomSuffix?.ToString() },
            { "timeZoneOffset", request.TimeZoneOffset },
            { "shortUrl", request.ShortUrl },
            { "pageNumber", request.PageNumber?.ToString() },
            { "pageSize", request.PageSize?.ToString() }
        };
        var endpoint =
            this.ConstructEndpointWithQueryParams(_baseUrl, $"/brands/{request.BrandId}/shorturl-clicks",
                queryParams);

        return await SendRequestAsync<GetSmartUrlReportRequest, GetSmartUrlDetailClickReportResponse?>(HttpMethod.Get,
            endpoint);
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
            { "fromDate", request.FromDate?.ToString() },
            { "toDate", request.ToDate?.ToString() },
            { "type", request.Type?.ToString() },
            { "timeZoneOffset", request.TimeZoneOffset },
            { "pageNumber", request.PageNumber?.ToString() },
            { "pageSize", request.PageSize?.ToString() }
        };
        var endpoint =
            this.ConstructEndpointWithQueryParams(_baseUrl, "/brand-vbt-outbound-messages",
                queryParams);

        return await SendRequestAsync<GetBrandVbtOutboundMessageRequest, GetBrandVbtMessageResponse?>(HttpMethod.Get,
            endpoint);
    }

    /// <inheritdoc />
    public async Task<GetBrandVbtMessageResponse?> GetBrandVbtInboundMessageAsync(
        GetBrandVbtInboundMessageRequest request)
    {
        var queryParams = new Dictionary<string, string?>
        {
            { "brandId", request.BrandId },
            { "referenceId", request.ReferenceId },
            { "fromDate", request.FromDate?.ToString() },
            { "toDate", request.ToDate?.ToString() },
            { "type", request.Type?.ToString() },
            { "timeZoneOffset", request.TimeZoneOffset },
            { "pageNumber", request.PageNumber?.ToString() },
            { "pageSize", request.PageSize?.ToString() }
        };
        var endpoint =
            this.ConstructEndpointWithQueryParams(_baseUrl, "/brand-vbt-inbound-messages",
                queryParams);

        return await SendRequestAsync<GetBrandVbtOutboundMessageRequest, GetBrandVbtMessageResponse?>(HttpMethod.Get,
            endpoint);
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
        await EnsureValidTokenAsync();

        var requestInfo = SolutionsByTextJsonContext.Default.GetTypeInfo(typeof(TRequest)) as JsonTypeInfo<TRequest>;

        var responseInfo = SolutionsByTextJsonContext.Default.GetTypeInfo(typeof(ApiResponse<TResponse?>))
            as JsonTypeInfo<ApiResponse<TResponse?>>;

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
            else if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                await RefreshTokenAsync();
                return await SendRequestAsync<TRequest, TResponse>(method, endpoint, request);
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

    private async Task ObtainBearerTokenAsync()
    {
        var tokenEndpoint = "https://login-stage.solutionsbytext.com/connect/token";
        var content = new FormUrlEncodedContent(new[]
        {
            new KeyValuePair<string, string>("client_id", _clientId),
            new KeyValuePair<string, string>("client_secret", _clientSecret),
            new KeyValuePair<string, string>("grant_type", "client_credentials")
        });

        var response = await _httpClient.PostAsync(tokenEndpoint, content);
        if (response.IsSuccessStatusCode)
        {
            var jsonResponse = await response.Content.ReadAsStringAsync();
            var tokenResponse = JsonSerializer.Deserialize<TokenResponse>(jsonResponse);

            if (tokenResponse != null)
            {
                _accessToken = tokenResponse.AccessToken;
                _tokenExpiresIn = tokenResponse.ExpiresIn;
                _httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue(tokenResponse.TokenType, _accessToken);
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

    private async Task EnsureValidTokenAsync()
    {
        await _retryPolicy.ExecuteAsync(async () =>
        {
            if (IsTokenExpiredOrMissing())
            {
                await RefreshTokenAsync();
            }

            return new HttpResponseMessage(HttpStatusCode.OK);
        });
    }

    private bool IsTokenExpiredOrMissing()
    {
        return string.IsNullOrEmpty(_accessToken) ||
               _tokenStopwatch.Elapsed.TotalSeconds > (_tokenExpiresIn - _tokenRefreshMargin);
    }

    private async Task RefreshTokenAsync()
    {
        try
        {
            await ObtainBearerTokenAsync();
            Console.WriteLine("Token refreshed successfully.");
        }
        catch (ApiException ex)
        {
            Console.WriteLine($"Failed to refresh token: {ex.Message}");
            throw;
        }
    }
}