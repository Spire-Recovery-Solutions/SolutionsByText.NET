using System.Text.Json.Serialization;

namespace SolutionsByText.NET.Models.Requests.Templates
{
    public class GetTemplateRequest
    {
        /// <summary>
        /// The unique identifier for the group.
        /// </summary>
        [JsonIgnore]
        public string GroupId { get; set; } = string.Empty;

        /// <summary>
        /// The unique identifier for the template.
        /// </summary>
        [JsonIgnore]
        public string TemplateId { get; set; } = string.Empty;
    }
}
