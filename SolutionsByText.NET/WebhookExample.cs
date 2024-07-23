using System.Text.Json;
using SolutionsByText.NET.Models.Requests;

namespace SolutionsByText.NET
{
    public class WebhookExample
    {
        public string ProcessWebhook(JsonElement body)
        {
            var webhookType = body.GetProperty("Type").GetString();

            switch (webhookType)
            {
                case "Outbound":
                    var outboundPayload = JsonSerializer.Deserialize<OutboundMessageStatusRequest>(body.GetRawText(), SolutionsByTextJsonContext.Default.OutboundMessageStatusRequest);
                    // Process outbound message status
                    return "Outbound message status processed";

                case "Inbound":
                    var inboundPayload = JsonSerializer.Deserialize<InboundMessageRequest>(body.GetRawText(), SolutionsByTextJsonContext.Default.InboundMessageRequest);
                    // Process inbound message
                    return "Inbound message processed";

                case "Inbound MMS":
                    var inboundMMSPayload = JsonSerializer.Deserialize<InboundMMSRequest>(body.GetRawText(), SolutionsByTextJsonContext.Default.InboundMMSRequest);
                    // Process inbound MMS
                    return "Inbound MMS processed";

                case "SmartURL":
                    var smartUrlPayload = JsonSerializer.Deserialize<SmartUrlClickRequest>(body.GetRawText(), SolutionsByTextJsonContext.Default.SmartUrlClickRequest);
                    // Process SmartURL click
                    return "SmartURL click processed";

                default:
                    return "Unknown webhook type";
            }
        }
    }
}