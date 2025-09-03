using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SolutionsByText.NET.Models.Responses.Reports
{
    public class AllSubscriberGroup
    {
        /// <summary>
        /// Gets or sets the unique identifier for the data item.
        /// </summary>
        [JsonPropertyName("id")]
        public string? Id { get; set; }
        
        /// <summary>
        /// Gets or sets the first name of the individual.
        /// </summary>
        [JsonPropertyName("firstName")]
        public string? FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name of the individual.
        /// </summary>
        [JsonPropertyName("lastName")]
        public string? LastName { get; set; }

        /// <summary>
        /// Gets or sets the middle name of the individual.
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
        /// Gets or sets the landline number.
        /// </summary>
        [JsonPropertyName("landLineNo")]
        public string? LandLineNo { get; set; }

        /// <summary>
        /// Gets or sets the URL of the individual's image.
        /// </summary>
        [JsonPropertyName("imageUrl")]
        public string? ImageUrl { get; set; }

        /// <summary>
        /// Gets or sets the email address of the individual.
        /// </summary>
        [JsonPropertyName("email")]
        public string? Email { get; set; }

        /// <summary>
        /// Gets or sets the gender of the individual.
        /// </summary>
        [JsonPropertyName("gender")]
        public string? Gender { get; set; }

        /// <summary>
        /// Gets or sets the age of the individual.
        /// </summary>
        [JsonPropertyName("age")]
        public int? Age { get; set; }

        /// <summary>
        /// Gets or sets the address of the individual.
        /// </summary>
        [JsonPropertyName("address")]
        public Address? Address { get; set; }

        /// <summary>
        /// Gets or sets the list of relations associated with the individual.
        /// </summary>
        [JsonPropertyName("relations")]
        public List<Relation>? Relations { get; set; }

        /// <summary>
        /// Gets or sets the list of properties associated with the individual.
        /// </summary>
        [JsonPropertyName("properties")]
        public List<Property>? Properties { get; set; }

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
