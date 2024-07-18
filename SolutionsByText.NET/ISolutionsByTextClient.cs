using SolutionsByText.NET.Models.Exceptions;
using SolutionsByText.NET.Models.Requests;
using SolutionsByText.NET.Models.Responses;

namespace SolutionsByText.NET;

/// <summary>
/// Defines the contract for interacting with the Solutions By Text API.
/// </summary>
public interface ISolutionsByTextClient
{
    #region Subscription Management

    /// <summary>
    /// Retrieves the status of one or more subscribers in a group.
    /// </summary>
    /// <param name="request">The request containing group ID and list of phone numbers.</param>
    /// <returns>A response containing the status of the requested subscribers.</returns>
    Task<GetSubscriberStatusResponse?> GetSubscriberStatusAsync(GetSubscriberStatusRequest request);

    /// <summary>
    /// Adds a new subscriber to a specified group.
    /// </summary>
    /// <param name="request">The request containing subscriber details and group information.</param>
    /// <returns>A response indicating the success or failure of the operation.</returns>
    Task<AddSubscriberResponse?> AddSubscriberAsync(AddSubscriberRequest request);

    /// <summary>
    /// Confirms a subscriber's opt-in using a PIN.
    /// </summary>
    /// <param name="request">The request containing the subscriber's phone number, group ID, and PIN.</param>
    /// <returns>A response indicating whether the confirmation was successful.</returns>
    Task<ConfirmSubscriberResponse?> ConfirmSubscriberAsync(ConfirmSubscriberRequest request);

    /// <summary>
    /// Removes a subscriber from a specified group.
    /// </summary>
    /// <param name="request">The request containing the subscriber's phone number and group ID.</param>
    /// <returns>A response indicating the success or failure of the operation.</returns>
    Task<DeleteSubscriberResponse?> DeleteSubscriberAsync(DeleteSubscriberRequest request);

    #endregion

    #region Messaging

    /// <summary>
    /// Sends a message to one or more subscribers in a group.
    /// </summary>
    /// <param name="request">The request containing the message details and recipient information.</param>
    /// <returns>A response containing the message ID and delivery status.</returns>
    /// <exception cref="ApiException">Thrown when the API returns an error.</exception>
    Task<SendMessageResponse?> SendMessageAsync(SendMessageRequest request);

    /// <summary>
    /// Sends a template message to one or more subscribers in a group.
    /// </summary>
    /// <param name="request">The request containing the template ID, variables, and recipient information.</param>
    /// <returns>A response containing the message ID and delivery status.</returns>
    Task<SendTemplateMessageResponse?> SendTemplateMessageAsync(SendTemplateMessageRequest request);

    /// <summary>
    /// Schedules a message to be sent at a future time.
    /// </summary>
    /// <param name="request">The request containing the message details, recipient information, and scheduled time.</param>
    /// <returns>A response containing the scheduled message ID.</returns>
    Task<ScheduleMessageResponse?> ScheduleMessageAsync(ScheduleMessageRequest request);

    /// <summary>
    /// Schedules a template message to be sent at a future time.
    /// </summary>
    /// <param name="request">The request containing the template ID, variables, recipient information, and scheduled time.</param>
    /// <returns>A response containing the scheduled message ID.</returns>
    Task<ScheduleTemplateMessageResponse?> ScheduleTemplateMessageAsync(ScheduleTemplateMessageRequest request);

    #endregion

    #region Group Management

    /// <summary>
    /// Retrieves information about a specific group.
    /// </summary>
    /// <param name="request">The request containing the group ID.</param>
    /// <returns>A response containing detailed information about the group.</returns>
    Task<GetGroupResponse?> GetGroupAsync(GetGroupRequest request);

    /// <summary>
    /// Updates the information of a specific group.
    /// </summary>
    /// <param name="request">The request containing the group ID and updated information.</param>
    /// <returns>A response indicating the success or failure of the update operation.</returns>
    Task<UpdateGroupResponse?> UpdateGroupAsync(UpdateGroupRequest request);

    #endregion

    #region Reporting

    /// <summary>
    /// Retrieves details of outbound messages for a specific group.
    /// </summary>
    /// <param name="request">The request containing the group ID and optional filters.</param>
    /// <returns>A response containing a list of outbound message details.</returns>
    Task<GetOutboundMessagesResponse?> GetOutboundMessagesAsync(GetOutboundMessagesRequest request);

    /// <summary>
    /// Retrieves details of inbound messages for a specific group.
    /// </summary>
    /// <param name="request">The request containing the group ID and optional filters.</param>
    /// <returns>A response containing a list of inbound message details.</returns>
    Task<GetInboundMessagesResponse?> GetInboundMessagesAsync(GetInboundMessagesRequest request);

    /// <summary>
    /// Retrieves deactivation events for an account.
    /// </summary>
    /// <param name="request">The request containing the account ID and optional filters.</param>
    /// <returns>A response containing a list of deactivation events.</returns>
    Task<GetDeactivationEventsResponse?> GetDeactivationEventsAsync(GetDeactivationEventsRequest request);

    #endregion

    #region SmartURL

    /// <summary>
    /// Creates a new SmartURL (shortened URL) for a group.
    /// </summary>
    /// <param name="request">The request containing the long URL and group ID.</param>
    /// <returns>A response containing the created SmartURL.</returns>
    Task<CreateSmartURLResponse?> CreateSmartURLAsync(CreateSmartURLRequest request);

    /// <summary>
    /// Updates an existing SmartURL for a group.
    /// </summary>
    /// <param name="request">The request containing the SmartURL, new long URL, and group ID.</param>
    /// <returns>A response indicating the success or failure of the update operation.</returns>
    Task<UpdateSmartURLResponse?> UpdateSmartURLAsync(UpdateSmartURLRequest request);

    #endregion

    #region Phone Number Operations

    /// <summary>
    /// Retrieves carrier information for one or more phone numbers.
    /// </summary>
    /// <param name="request">The request containing the list of phone numbers to look up.</param>
    /// <returns>A response containing carrier information for each phone number.</returns>
    Task<GetPhoneNumberDataResponse?> GetPhoneNumberDataAsync(GetPhoneNumberDataRequest request);

    #endregion

    #region Keyword Management

    /// <summary>
    /// Adds a new keyword to a group.
    /// </summary>
    /// <param name="request">The request containing the keyword details and group ID.</param>
    /// <returns>A response indicating the success or failure of the operation.</returns>
    Task<AddKeywordResponse?> AddKeywordAsync(AddKeywordRequest request);

    /// <summary>
    /// Retrieves all keywords for a specific group.
    /// </summary>
    /// <param name="request">The request containing the group ID and optional filters.</param>
    /// <returns>A response containing a list of keywords for the group.</returns>
    Task<GetKeywordsResponse?> GetKeywordsAsync(GetKeywordsRequest request);

    #endregion

    #region Media Management

    /// <summary>
    /// Retrieves an MMS file.
    /// </summary>
    /// <param name="request">The request containing the group ID, message ID, and file ID.</param>
    /// <returns>A response containing the MMS file data.</returns>
    Task<RetrieveMMSResponse?> RetrieveMMSAsync(RetrieveMMSRequest request);

    /// <summary>
    /// Deletes an MMS file.
    /// </summary>
    /// <param name="request">The request containing the group ID, message ID, and file ID.</param>
    /// <returns>A response indicating the success or failure of the delete operation.</returns>
    Task<DeleteMMSResponse?> DeleteMMSAsync(DeleteMMSRequest request);

    #endregion

    #region Brand Operations

    /// <summary>
    /// Adds a new subscriber to a brand.
    /// </summary>
    /// <param name="request">The request containing subscriber details and brand information.</param>
    /// <returns>A response indicating the success or failure of the operation.</returns>
    Task<AddBrandSubscriberResponse?> AddBrandSubscriberAsync(AddBrandSubscriberRequest request);

    /// <summary>
    /// Confirms a subscriber's opt-in for a brand using a PIN.
    /// </summary>
    /// <param name="request">The request containing the subscriber's phone number, brand ID, and PIN.</param>
    /// <returns>A response indicating whether the confirmation was successful.</returns>
    Task<ConfirmBrandSubscriberResponse?> ConfirmBrandSubscriberAsync(ConfirmBrandSubscriberRequest request);

    /// <summary>
    /// Retrieves the status of a subscriber within a brand.
    /// </summary>
    /// <param name="request">The request containing the brand ID and subscriber's phone number.</param>
    /// <returns>A response containing the subscriber's status within the brand.</returns>
    Task<GetBrandSubscriberStatusResponse?> GetBrandSubscriberStatusAsync(GetBrandSubscriberStatusRequest request);

    #endregion

    #region Template Management

    /// <summary>
    /// Retrieves all templates for a specific group.
    /// </summary>
    /// <param name="request">The request containing the group ID and optional filters.</param>
    /// <returns>A response containing a list of templates for the group.</returns>
    Task<GetTemplatesResponse?> GetTemplatesAsync(GetTemplatesRequest request);

    /// <summary>
    /// Retrieves a specific template by its ID.
    /// </summary>
    /// <param name="request">The request containing the group ID and template ID.</param>
    /// <returns>A response containing the details of the requested template.</returns>
    Task<GetTemplateResponse?> GetTemplateAsync(GetTemplateRequest request);

    #endregion

    #region Webhook Management

    /// <summary>
    /// Registers a webhook for receiving specific event notifications.
    /// </summary>
    /// <param name="request">The request containing the webhook URL and event types to subscribe to.</param>
    /// <returns>A response indicating the success or failure of the webhook registration.</returns>
    Task<RegisterWebhookResponse?> RegisterWebhookAsync(RegisterWebhookRequest request);

    /// <summary>
    /// Updates an existing webhook registration.
    /// </summary>
    /// <param name="request">The request containing the webhook ID and updated information.</param>
    /// <returns>A response indicating the success or failure of the update operation.</returns>
    Task<UpdateWebhookResponse?> UpdateWebhookAsync(UpdateWebhookRequest request);

    #endregion
}