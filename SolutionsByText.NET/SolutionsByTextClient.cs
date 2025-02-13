﻿using Polly;
using Polly.Retry;
using SolutionsByText.NET.Models.Exceptions;
using SolutionsByText.NET.Models.Requests;
using SolutionsByText.NET.Models.Requests.Keywords;
using SolutionsByText.NET.Models.Requests.Messages;
using SolutionsByText.NET.Models.Requests.PhoneNumbers;
using SolutionsByText.NET.Models.Requests.Reports;
using SolutionsByText.NET.Models.Requests.SmartUrl;
using SolutionsByText.NET.Models.Requests.Subscription;
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
        return await SendRequestAsync<GetGroupSubscriberStatusRequest, GetGroupSubscriberStatusResponse?>(
            HttpMethod.Get,
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
    public async Task<ConfirmGroupSubscriberResponse?> ConfirmSubscriberAsync(ConfirmGroupSubscriberRequest request)
    {
        var endpoint = $"{_baseUrl}/groups/{request.GroupId}/subscribers/{request.Msisdn}/verification";
        return await SendRequestAsync<ConfirmGroupSubscriberRequest, ConfirmGroupSubscriberResponse?>(HttpMethod.Post,
            endpoint,
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
            this.ConstructEndpointWithQueryParams(_baseUrl, $"/brands/{request.BrandId}/shorturl-clicks-details",
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

        return await SendRequestAsync<GetAllSubscribersGroupRequest, GetAllSubscribersGroupResponse?>(HttpMethod.Get,
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
    private async Task<TResponse> SendRequestAsync<TRequest, TResponse>(HttpMethod method, string endpoint,
        TRequest? request = default)
    {
        // Ensure that the access token is valid before making the request.
        await EnsureValidTokenAsync();

        // Get the type information for serialization/deserialization.
        var requestInfo = SolutionsByTextJsonContext.Default.GetTypeInfo(typeof(TRequest)) as JsonTypeInfo<TRequest>;
        var responseInfo = SolutionsByTextJsonContext.Default.GetTypeInfo(typeof(ApiResponse<TResponse>))
            as JsonTypeInfo<ApiResponse<TResponse>>;

        // Validate that the types are registered in the JSON context.
        if (requestInfo == null || responseInfo == null)
        {
            throw new InvalidOperationException(
                $"Type {typeof(TRequest)} or {typeof(ApiResponse<TResponse>)} is not registered in SolutionsByTextJsonContext.");
        }

        // Serialize the request body if it's provided.
        using var content = request != null
            ? new StringContent(JsonSerializer.Serialize(request, requestInfo), Encoding.UTF8, "application/json")
            : null;

        try
        {
            // Execute the HTTP request with retry and unauthorized policies combined.
            var response = await Policy.WrapAsync(_retryPolicy, _unauthorizedPolicy)
                .ExecuteAsync(async () =>
                {
                    return method switch
                    {
                        { } m when m == HttpMethod.Get => await _httpClient.GetAsync(endpoint),
                        { } m when m == HttpMethod.Post => await _httpClient.PostAsync(endpoint, content),
                        { } m when m == HttpMethod.Put => await _httpClient.PutAsync(endpoint, content),
                        { } m when m == HttpMethod.Delete => await _httpClient.DeleteAsync(endpoint),
                        _ => throw new NotSupportedException($"HTTP method {method} is not supported.")
                    };
                });

            var responseContent = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                // Deserialize the successful response
                var apiResponse = JsonSerializer.Deserialize(responseContent, responseInfo);
                if (apiResponse == null || apiResponse.Data == null)
                {
                    throw new ApiException("Failed to deserialize the response or response data is null.");
                }

                return apiResponse.Data;
            }

            // Handle error responses from the API
            var errorResponse = JsonSerializer.Deserialize(responseContent,
                SolutionsByTextJsonContext.Default.ErrorResponse);

            // Throw an ApiException with appropriate error details
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
        catch (ApiException)
        {
            // Re-throw ApiExceptions without wrapping
            throw;
        }
        catch (Exception ex)
        {
            // Wrap any other exceptions in an ApiException
            throw new ApiException("An unexpected error occurred", ex.Message);
        }
    }

    //Get the bearer token and start the stopwatch
    private async Task ObtainBearerTokenAsync()
    {
        var tokenEndpoint = $"{_tokenUrl}/connect/token";

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