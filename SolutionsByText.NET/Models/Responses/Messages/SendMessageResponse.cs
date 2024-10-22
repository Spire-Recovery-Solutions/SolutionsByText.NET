﻿using System.Text.Json.Serialization;

namespace SolutionsByText.NET.Models.Responses.Messages
{
    /// <summary>
    /// Represents the response received after sending a message, containing relevant details.
    /// </summary>
    public class SendMessageResponse : ApiResponse<MessageData>
    {
    }
}