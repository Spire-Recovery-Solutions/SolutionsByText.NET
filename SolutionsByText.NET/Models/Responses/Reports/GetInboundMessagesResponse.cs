using SolutionsByText.NET.Models.Requests;
using System.Text.Json.Serialization;

namespace SolutionsByText.NET.Models.Responses.Reports
{

    /// <summary>
    /// Represents the response received after requesting inbound messages.
    /// </summary>
    public class GetInboundMessagesResponse : ApiResponse<InboundOutboundMessagesData>
    {
    }
}
