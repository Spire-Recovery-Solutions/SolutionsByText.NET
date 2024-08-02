using System.Text.Json.Serialization;

namespace SolutionsByText.NET.Models.Requests.Templates
{
    public class GetTemplateRequest
    {
        /// <summary>
        /// The unique identifier for the group.
        /// </summary>
        [JsonPropertyName("groupId")]
        public required string GroupId { get; set; }

        /// <summary>
        /// The unique identifier for the template.
        /// </summary>
        [JsonPropertyName("templateId")]
        public required string TemplateId { get; set; }
    }
}
