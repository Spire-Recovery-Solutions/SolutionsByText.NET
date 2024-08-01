using SolutionsByText.NET.Models.Requests.Subscriptions;
using SolutionsByText.NET.Models.Responses.Subscriptions;
using System.Text;

namespace SolutionsByText.NET
{
    public static class SolutionsByTextClientExtensions
    {
        /// <summary>
        /// Constructs a complete endpoint URL with the specified query parameters.
        /// </summaryGetSubscriberStatusAsync
        /// <param name="client">The ISolutionsByTextClient instance used to construct the URL.</param>
        /// <param name="baseUrl">The base URL of the API.</param>
        /// <param name="path">The specific path to append to the base URL.</param>
        /// <param name="queryParams">A dictionary of query parameters to include in the URL.</param>
        /// <returns>A string representing the complete endpoint URL with query parameters.</returns>
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
