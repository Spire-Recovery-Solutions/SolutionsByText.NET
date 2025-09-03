using System.Text.Json.Serialization;

namespace SolutionsByText.NET.Models.Responses.Reports
{
    /// <summary>
    /// Represents individual subscriber data within the paginated response.
    /// </summary>
    public class SubscriberData
    {
        /// <summary>
        /// Internal subscriber ID number (if set by the SBT customer).
        /// </summary>
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        /// <summary>
        /// First name of the subscriber.
        /// </summary>
        [JsonPropertyName("firstName")]
        public string? FirstName { get; set; }

        /// <summary>
        /// Last name of the subscriber.
        /// </summary>
        [JsonPropertyName("lastName")]
        public string? LastName { get; set; }

        /// <summary>
        /// Middle name of the subscriber.
        /// </summary>
        [JsonPropertyName("middleName")]
        public string? MiddleName { get; set; }

        /// <summary>
        /// Mobile number with dialing code. Eleven digits with no plus sign (12345678902).
        /// </summary>
        [JsonPropertyName("msisdn")]
        public string? Msisdn { get; set; }

        /// <summary>
        /// Subscription status: *Active*, *InActive*, *Not a Subscriber*, or *UnderVerification*.
        /// </summary>
        [JsonPropertyName("status")]
        public string? Status { get; set; }

        /// <summary>
        /// Landline number.
        /// </summary>
        [JsonPropertyName("landLineNo")]
        public string? LandLineNo { get; set; }

        /// <summary>
        /// URL of the subscriber's image.
        /// </summary>
        [JsonPropertyName("imageUrl")]
        public string? ImageUrl { get; set; }

        /// <summary>
        /// Email address of the subscriber.
        /// </summary>
        [JsonPropertyName("email")]
        public string? Email { get; set; }

        /// <summary>
        /// Gender of the subscriber.
        /// </summary>
        [JsonPropertyName("gender")]
        public string? Gender { get; set; }

        /// <summary>
        /// Age of the subscriber.
        /// </summary>
        [JsonPropertyName("age")]
        public int? Age { get; set; }

        /// <summary>
        /// Address information for the subscriber.
        /// </summary>
        [JsonPropertyName("address")]
        public AddressForGetAllSubcriberInGroup? Address { get; set; }

        /// <summary>
        /// List of relations associated with the subscriber.
        /// </summary>
        [JsonPropertyName("relations")]
        public List<RelationForGetAllSubcriberInGroup>? Relations { get; set; }

        /// <summary>
        /// List of properties associated with the subscriber.
        /// </summary>
        [JsonPropertyName("properties")]
        public List<PropertiesForGetAllSubcriberInGroup>? Properties { get; set; }

        /// <summary>
        /// The wireless provider name for the subscriber's carrier.
        /// </summary>
        [JsonPropertyName("carrierName")]
        public string? CarrierName { get; set; }

        /// <summary>
        /// The wireless provider ID for the subscriber's carrier.
        /// </summary>
        [JsonPropertyName("carrierId")]
        public string? CarrierId { get; set; }

        /// <summary>
        /// First Date the subscriber was opted into messaging.
        /// </summary>
        [JsonPropertyName("firstOptInDate")]
        public string? FirstOptInDate { get; set; }

        /// <summary>
        /// Last Date the subscriber was opted into messaging.
        /// </summary>
        [JsonPropertyName("lastOptinDate")]
        public string? LastOptinDate { get; set; }

        /// <summary>
        /// Date of the subscriber was opted out of the company.
        /// </summary>
        [JsonPropertyName("lastOptoutDate")]
        public string? LastOptoutDate { get; set; }

        /// <summary>
        /// Method by which the subscriber was opted into messaging.
        /// </summary>
        [JsonPropertyName("optinType")]
        public string? OptinType { get; set; }

        /// <summary>
        /// Method by which the subscriber was opted out of messaging. Will show the keyword if that method was used.
        /// </summary>
        [JsonPropertyName("optoutType")]
        public string? OptoutType { get; set; }
    }
}