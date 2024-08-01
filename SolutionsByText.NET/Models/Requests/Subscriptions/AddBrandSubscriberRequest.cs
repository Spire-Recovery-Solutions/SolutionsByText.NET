using SolutionsByText.NET.Models.Requests.Enums;
using System.Text.Json.Serialization;

namespace SolutionsByText.NET.Models.Requests.Subscription
{
    /// <summary>
    /// Represents a request to add a new subscriber to a brand.
    /// </summary>
    public class AddBrandSubscriberRequest
    {
        /// <summary>
        /// Gets or sets the unique identifier of the brand.
        /// </summary>
        [JsonPropertyName("brandId")]
        public string BrandId { get; set; }

        /// <summary>
        /// Gets or sets the phone number of the subscriber.
        /// </summary>
        [JsonPropertyName("msisdn")]
        public string Msisdn { get; set; }

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
        /// Gets or sets the landline number of the subscriber.
        /// </summary>
        [JsonPropertyName("landLineNo")]
        public string? LandLineNo { get; set; }

        /// <summary>
        /// Gets or sets the image URL of the subscriber if applicable.
        /// </summary>
        [JsonPropertyName("imageUrl")]
        public string? ImageUrl { get; set; }

        /// <summary>
        /// Gets or sets the email of the subscriber.
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
        /// Gets or sets the address of the subscriber.
        /// </summary>
        [JsonPropertyName("address")]
        public Address? Address { get; set; }

        /// <summary>
        /// Gets or sets the relations of the subscriber.
        /// </summary>
        [JsonPropertyName("relations")]
        public List<Relation>? Relations { get; set; }

        /// <summary>
        /// Gets or sets the properties of the subscriber.
        /// </summary>
        [JsonPropertyName("properties")]
        public List<Property>? Properties { get; set; }

        /// <summary>
        /// Gets or sets the age of the subscriber.
        /// </summary>
        [JsonPropertyName("age")]
        public int? Age { get; set; }

        /// <summary>
        /// Gets or sets the reference ID for tracking purposes.
        /// </summary>
        [JsonPropertyName("referenceId")]
        public string? ReferenceId { get; set; }

        /// <summary>
        /// Gets or sets the verification details.
        /// </summary>
        [JsonPropertyName("verification")]
        public VerificationType? Verification { get; set; }

        /// <summary>
        /// Gets or sets the variables associated with the subscriber.
        /// </summary>
        [JsonPropertyName("variables")]
        public List<Variable>? Variables { get; set; }

    }
}
