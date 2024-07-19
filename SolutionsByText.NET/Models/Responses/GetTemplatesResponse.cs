using System.Text.Json.Serialization;
namespace SolutionsByText.NET.Models.Responses
{
    public class GetTemplatesResponse : PaginationData
    {
        /// <summary>
        /// Gets or sets the collection of data items.
        /// </summary>
        [JsonPropertyName("data")]
        public List<TemplateItem> Data { get; set; }
    }
}
