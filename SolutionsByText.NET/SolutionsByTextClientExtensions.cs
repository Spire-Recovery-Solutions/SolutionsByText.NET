using SolutionsByText.NET.Models.Requests;
using SolutionsByText.NET.Models.Responses;

namespace SolutionsByText.NET;

public static class SolutionsByTextClientExtensions
{
    public static async Task<GetSubscriberStatusResponse?> GetSubscriberStatusAsync(
        this ISolutionsByTextClient client, 
        string groupId, 
        List<string> msisdns)
    {
        return await client.GetSubscriberStatusAsync(new GetSubscriberStatusRequest
        {
            GroupId = groupId,
            Msisdn = msisdns
        });
    }

    // ... other extension methods for convenience
}