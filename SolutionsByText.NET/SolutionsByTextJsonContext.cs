using System.Text.Json.Serialization;
using SolutionsByText.NET.Models.Requests;
using SolutionsByText.NET.Models.Responses;

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
[JsonSerializable(typeof(GetOutboundMessagesResponse))]
[JsonSerializable(typeof(GetInboundMessagesResponse))]
[JsonSerializable(typeof(CreateSmartURLResponse))]
[JsonSerializable(typeof(GetPhoneNumberDataResponse))]
[JsonSerializable(typeof(AddBrandSubscriberResponse))]
[JsonSerializable(typeof(ConfirmBrandSubscriberResponse))]
[JsonSerializable(typeof(MessageStatus))]
[JsonSerializable(typeof(ScheduleStatus))]
[JsonSerializable(typeof(SubscriptionStatus))]
[JsonSerializable(typeof(OperationStatus))]
[JsonSerializable(typeof(CarrierType))]

[JsonSourceGenerationOptions(
    PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase,
    WriteIndented = true,
    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull)]
public partial class SolutionsByTextJsonContext : JsonSerializerContext
{
}

