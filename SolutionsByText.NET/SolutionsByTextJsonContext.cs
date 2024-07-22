﻿using System.Text.Json.Serialization;
using SolutionsByText.NET.Models;
using SolutionsByText.NET.Models.Requests;
using SolutionsByText.NET.Models.Requests.Enums;
using SolutionsByText.NET.Models.Responses;
using SolutionsByText.NET.Models.Responses.Enums;

namespace SolutionsByText.NET;


[JsonSerializable(typeof(SendMessageRequest))]
[JsonSerializable(typeof(SendTemplateMessageRequest))]
[JsonSerializable(typeof(ScheduleMessageRequest))]
[JsonSerializable(typeof(GetSubscriberStatusRequest))]
[JsonSerializable(typeof(AddSubscriberRequest))]
[JsonSerializable(typeof(ConfirmSubscriberRequest))]
[JsonSerializable(typeof(DeleteSubscriberRequest))]
[JsonSerializable(typeof(GetGroupRequest))]
[JsonSerializable(typeof(GetOutboundMessagesRequest))]
[JsonSerializable(typeof(GetInboundMessagesRequest))]
[JsonSerializable(typeof(CreateSmartURLRequest))]
[JsonSerializable(typeof(GetPhoneNumberDataRequest))]
[JsonSerializable(typeof(AddBrandSubscriberRequest))]
[JsonSerializable(typeof(ConfirmBrandSubscriberRequest))]
[JsonSerializable(typeof(OutboundMessageStatusRequest))]
[JsonSerializable(typeof(InboundMessageRequest))]
[JsonSerializable(typeof(InboundMMSRequest))]
[JsonSerializable(typeof(SmartUrlClickRequest))]
[JsonSerializable(typeof(AddKeywordRequest))]
[JsonSerializable(typeof(DeleteMMSRequest))]
[JsonSerializable(typeof(GetBrandSubscriberStatusRequest))]
[JsonSerializable(typeof(GetDeactivationEventsRequest))]
[JsonSerializable(typeof(GetKeywordsRequest))]
[JsonSerializable(typeof(GetTemplateRequest))]
[JsonSerializable(typeof(GetTemplatesRequest))]
[JsonSerializable(typeof(InboundMessageData))]
[JsonSerializable(typeof(MediaFile))]
[JsonSerializable(typeof(OutboundMessageStatusData))]
[JsonSerializable(typeof(RetrieveMMSRequest))]
[JsonSerializable(typeof(ScheduleTemplateMessageRequest))]
[JsonSerializable(typeof(SmartUrlClickData))]
[JsonSerializable(typeof(Subscriber))]
[JsonSerializable(typeof(UpdateSmartURLRequest))]
[JsonSerializable(typeof(Variable))]
[JsonSerializable(typeof(WebhookPayload))]
[JsonSerializable(typeof(Property))]
[JsonSerializable(typeof(MessageType))]
[JsonSerializable(typeof(VerificationType))]
[JsonSerializable(typeof(DeactivationEventType))]
[JsonSerializable(typeof(MessageReportType))]

[JsonSerializable(typeof(SendMessageResponse))]
[JsonSerializable(typeof(SendTemplateMessageResponse))]
[JsonSerializable(typeof(ScheduleMessageResponse))]
[JsonSerializable(typeof(GetSubscriberStatusResponse))]
[JsonSerializable(typeof(AddSubscriberResponse))]
[JsonSerializable(typeof(ConfirmSubscriberResponse))]
[JsonSerializable(typeof(DeleteSubscriberResponse))]
[JsonSerializable(typeof(GetGroupResponse))]
[JsonSerializable(typeof(GetInboundMessagesResponse))]
[JsonSerializable(typeof(CreateSmartURLResponse))]
[JsonSerializable(typeof(GetPhoneNumberDataResponse))]
[JsonSerializable(typeof(AddBrandSubscriberResponse))]
[JsonSerializable(typeof(ConfirmBrandSubscriberResponse))]
[JsonSerializable(typeof(AddKeywordResponse))]
[JsonSerializable(typeof(ConsentItem))]
[JsonSerializable(typeof(CarrierInfo))]
[JsonSerializable(typeof(CustomParam))]
[JsonSerializable(typeof(DeleteMMSResponse))]
[JsonSerializable(typeof(EventData))]
[JsonSerializable(typeof(GetDeactivationEventsResponse))]
[JsonSerializable(typeof(GetKeywordsResponse))]
[JsonSerializable(typeof(GetOutboundMessagesResponse))]
[JsonSerializable(typeof(GetTemplateResponse))]
[JsonSerializable(typeof(GetTemplatesResponse))]
[JsonSerializable(typeof(InboundMessage))]
[JsonSerializable(typeof(KeywordItem))]
[JsonSerializable(typeof(KeywordPaginatedData))]
[JsonSerializable(typeof(OutboundMessage))]
[JsonSerializable(typeof(PaginationData))]
[JsonSerializable(typeof(PhoneNumberData))]
[JsonSerializable(typeof(RetrieveMMSResponse))]
[JsonSerializable(typeof(ScheduleTemplateMessageResponse))]
[JsonSerializable(typeof(SubscriberStatus))]
[JsonSerializable(typeof(TemplateItem))]
[JsonSerializable(typeof(UpdateSmartURLResponse))]
[JsonSerializable(typeof(MessageStatus))]
[JsonSerializable(typeof(ScheduleStatus))]
[JsonSerializable(typeof(SubscriptionStatus))]
[JsonSerializable(typeof(OperationStatus))]
[JsonSerializable(typeof(CarrierType))]
[JsonSerializable(typeof(ErrorCode))]
[JsonSerializable(typeof(StatusCode))]

[JsonSerializable(typeof(ApiResponse<List<ConsentItem>>))]
[JsonSerializable(typeof(ApiResponse<AddKeywordResponse>))]
[JsonSerializable(typeof(ApiResponse<GetDeactivationEventsResponse>))]
[JsonSerializable(typeof(ApiResponse<GetKeywordsResponse>))]
[JsonSerializable(typeof(ApiResponse<GetTemplateResponse>))]
[JsonSerializable(typeof(ApiResponse<UpdateSmartURLResponse>))]
[JsonSerializable(typeof(ApiResponse<SendMessageResponse>))]
[JsonSerializable(typeof(ErrorResponse))]

[JsonSourceGenerationOptions(
    PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase,
    WriteIndented = true,
    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull)]
public partial class SolutionsByTextJsonContext : JsonSerializerContext
{
}

