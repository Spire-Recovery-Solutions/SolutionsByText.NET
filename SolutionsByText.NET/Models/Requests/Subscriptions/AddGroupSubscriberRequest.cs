using SolutionsByText.NET.Models.Requests.Enums;
using System.Net;
using System.Text.Json.Serialization;

namespace SolutionsByText.NET.Models.Requests.Subscription
{
    /// <summary>
    /// Represents a request to add a new subscriber to a group.
    /// </summary>
    public class AddGroupSubscriberRequest
    {
        /// <summary>
        /// Gets or sets the unique identifier of the group to add the subscriber to.
        /// </summary>
        [JsonPropertyName("groupId")]
        public required string GroupId { get; set; }

        /// <summary>
        /// Gets or sets the first name of the subscriber.
        /// </summary>
        [JsonPropertyName("firstName")]
        public string? FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name of the subscriber.
        /// </summary>
        [JsonPropertyName("lastName")]
        public string? LastName { get; set; }

        /// <summary>
        /// Gets or sets the middle name of the subscriber.
        /// </summary>
        [JsonPropertyName("middleName")]
        public string? MiddleName { get; set; }

        /// <summary>
        /// Gets or sets the phone number of the subscriber with dialing code.
        /// </summary>
        [JsonPropertyName("msisdn")]
        public required string Msisdn { get; set; }

        /// <summary>
        /// Gets or sets the landline number of the subscriber.
        /// </summary>
        [JsonPropertyName("landLineNo")]
        public string? LandLineNo { get; set; }

        /// <summary>
        /// Gets or sets the URL of the subscriber's image, if applicable.
        /// </summary>
        [JsonPropertyName("imageUrl")]
        public string? ImageUrl { get; set; }

        /// <summary>
        /// Gets or sets the email address of the subscriber.
        /// </summary>
        [JsonPropertyName("email")]
        public string? Email { get; set; }

        /// <summary>
        /// Gets or sets the gender of the subscriber.
        /// </summary>
        [JsonPropertyName("gender")]
        public string? Gender { get; set; }

        /// <summary>
        /// Gets or sets the birth date of the subscriber.
        /// </summary>
        [JsonPropertyName("birthDate")]
        public DateTime? BirthDate { get; set; }

        /// <summary>
        /// Gets or sets the address details of the subscriber.
        /// </summary>
        [JsonPropertyName("address")]
        public Address? Address { get; set; }

        /// <summary>
        /// Gets or sets the reference identifier for the subscriber.
        /// </summary>
        [JsonPropertyName("referenceId")]
        public string? ReferenceId { get; set; }

        /// <summary>
        /// Gets or sets the verification details for the subscriber.
        /// </summary>
        [JsonPropertyName("verification")]
        [JsonConverter(typeof(JsonStringEnumConverter<VerificationType>))]
        public VerificationType? Verification { get; set; }

        /// <summary>
        /// Gets or sets the custom-defined variables for the subscriber.
        /// </summary>
        [JsonPropertyName("variables")]
        public List<Variable>? Variables { get; set; }

    }
}
