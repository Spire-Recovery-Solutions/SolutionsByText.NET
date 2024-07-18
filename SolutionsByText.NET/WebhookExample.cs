using SolutionsByText.NET.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SolutionsByText.NET
{
    public class WebhookExample
    {
        public async Task<IActionResult> WebhookEndpoint([FromBody] JsonElement body)
        {
            var webhookType = body.GetProperty("Type").GetString();

            switch (webhookType)
            {
                case "Outbound":
                    var outboundPayload = JsonSerializer.Deserialize<OutboundMessageStatusRequest>(body.GetRawText(),
                        SolutionsByTextJsonContext.Default.OutboundMessageStatusRequest);
                    // Process outbound message status
                    break;
                case "Inbound":
                    var inboundPayload = JsonSerializer.Deserialize<InboundMessageRequest>(body.GetRawText(),
                        SolutionsByTextJsonContext.Default.InboundMessageRequest);
                    // Process inbound message
                    break;
                case "Inbound MMS":
                    var inboundMMSPayload = JsonSerializer.Deserialize<InboundMMSRequest>(body.GetRawText(),
                        SolutionsByTextJsonContext.Default.InboundMMSRequest);
                    // Process inbound MMS
                    break;
                case "SmartURL":
                    var smartUrlPayload = JsonSerializer.Deserialize<SmartUrlClickRequest>(body.GetRawText(),
                        SolutionsByTextJsonContext.Default.SmartUrlClickRequest);
                    // Process SmartURL click
                    break;
                default:
                    return BadRequest("Unknown webhook type");
            }

            return Ok();
        }

    }
}
