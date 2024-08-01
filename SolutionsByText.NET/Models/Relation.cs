using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SolutionsByText.NET.Models
{
    /// <summary>
    /// Represents a relationship with a name and type of relationship.
    /// </summary>
    public class Relation
    {
        /// <summary>
        /// Gets or sets the name associated with the relationship.
        /// </summary>
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the type of relationship.
        /// </summary>
        [JsonPropertyName("relationship")]
        public string? Relationship { get; set; }
    }

}
