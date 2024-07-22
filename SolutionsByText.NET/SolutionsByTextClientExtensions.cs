using SolutionsByText.NET.Models.Requests;
using SolutionsByText.NET.Models.Responses;
using System.Text;

namespace SolutionsByText.NET
{
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

        public static string ConstructEndpointWithQueryParams(this ISolutionsByTextClient client, string baseUrl, string path, Dictionary<string, string?> queryParams)
        {
            var sb = new StringBuilder(baseUrl);
            sb.Append(path);

            if (queryParams != null && queryParams.Any())
            {
                sb.Append('?');
                sb.Append(string.Join("&", queryParams
                    .Where(v => !string.IsNullOrEmpty(v.Value))
                    .Select(v => $"{v.Key}={Uri.EscapeDataString(v.Value!)}")));
            }

            return sb.ToString();
        }
    }
}