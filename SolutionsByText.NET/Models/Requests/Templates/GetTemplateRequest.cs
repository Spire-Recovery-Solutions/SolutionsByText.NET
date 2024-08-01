using System.Text.Json.Serialization;

namespace SolutionsByText.NET.Models.Requests.Templates
{
    public class GetTemplateRequest
    {
        /// <summary>
        /// The unique identifier for the group.
        /// </summary>
        [JsonPropertyName("groupId")]
        public string GroupId { get; set; }

        /// <summary>
        /// The unique identifier for the template.
        /// </summary>
        [JsonPropertyName("templateId")]
        public string TemplateId { get; set; }
    }
}
