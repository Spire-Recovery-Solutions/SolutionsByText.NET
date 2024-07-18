using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SolutionsByText.NET.Models.Requests
{ 
    /// <summary>
/// Represents a request to get details of inbound messages for a specific group.
/// </summary>
public class GetInboundMessagesRequest
{
    /// <summary>
    /// Gets or sets the unique identifier of the group.
    /// </summary>
    [JsonPropertyName("groupId")]
    public string GroupId { get; set; }

    /// <summary>
    /// Gets or sets the start date for the report.
    /// </summary>
    [JsonPropertyName("fromDate")]
    public DateTime FromDate { get; set; }

    /// <summary>
    /// Gets or sets the end date for the report.
    /// </summary>
    [JsonPropertyName("toDate")]
    public DateTime ToDate { get; set; }
}
}
