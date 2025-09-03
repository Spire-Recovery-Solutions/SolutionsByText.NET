using System.Text.Json.Serialization;
namespace SolutionsByText.NET.Models.Responses.Subscriptions
{
    /// <summary>
    /// Represents the response received after requesting subscriber status.
    /// The API returns an array of subscriber statuses, one for each queried number.
    /// </summary>
    public class GetGroupSubscriberStatusResponse : ApiResponse<List<SubscriberStatus>>
    {
    }

}