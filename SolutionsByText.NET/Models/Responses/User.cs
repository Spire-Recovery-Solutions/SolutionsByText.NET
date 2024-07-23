using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SolutionsByText.NET.Models.Responses
{
      /// Represents user information.
    /// </summary>
    public class User
    {
        [JsonPropertyName("lastName")]
        public string LastName { get; set; }

        [JsonPropertyName("firstName")]
        public string FirstName { get; set; }

        [JsonPropertyName("userId")]
        public string UserId { get; set; }
    }
}
