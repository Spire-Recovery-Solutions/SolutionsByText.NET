using System.Text.Json.Serialization;

namespace SolutionsByText.NET.Models.Responses.Templates
{
    public class TemplateItem
    {
        /// <summary>
        /// Gets or sets the ID of the item.
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the item.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the message associated with the item.
        /// </summary>
        [JsonPropertyName("message")]
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the description of the item.
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the status of the item.
        /// </summary>
        [JsonPropertyName("status")]
        public string Status { get; set; }
    }
}
