using SolutionsByText.NET.Models.Responses.Enums;
using System.Text.Json.Serialization;

namespace SolutionsByText.NET.Models.Responses.Messages
{
    /// <summary>
    /// Represents the response received after sending a template message.
    /// </summary>
    public class SendTemplateMessageResponse : ApiResponse<TemplateMessage>
    {
    }
}
