using System.Text.Json.Serialization;

namespace SolutionsByText.NET.Models.Requests.Webhooks
{
    /// <summary>
    /// Represents the data associated with a click on a smart URL, including user and device information.
    /// </summary>
    public class SmartUrlClickData
    {
        /// <summary>
        /// Gets or sets the domain of the smart URL.
        /// </summary>
        [JsonPropertyName("Domain")]
        public string? Domain { get; set; }

        /// <summary>
        /// Gets or sets the original long URL before it was shortened.
        /// </summary>
        [JsonPropertyName("LongUrl")]
        public string? LongUrl { get; set; }

        /// <summary>
        /// Gets or sets the smart URL that was clicked.
        /// </summary>
        [JsonPropertyName("SmartUrl")]
        public string? SmartUrl { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the brand associated with the smart URL.
        /// </summary>
        [JsonPropertyName("BrandId")]
        public string? BrandId { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the account associated with the smart URL.
        /// </summary>
        [JsonPropertyName("AccountId")]
        public string? AccountId { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the smart URL was clicked.
        /// </summary>
        [JsonPropertyName("ClickedDateTime")]
        public DateTime ClickedDateTime { get; set; }

        /// <summary>
        /// Gets or sets the remote IP address of the user who clicked the smart URL.
        /// </summary>
        [JsonPropertyName("RemoteIpAddress")]
        public string? RemoteIpAddress { get; set; }

        /// <summary>
        /// Gets or sets the referer URL from which the click originated.
        /// </summary>
        [JsonPropertyName("Referer")]
        public string? Referer { get; set; }

        /// <summary>
        /// Gets or sets the origin of the request for the click.
        /// </summary>
        [JsonPropertyName("Origin")]
        public string? Origin { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the click was a preview click.
        /// </summary>
        [JsonPropertyName("IsPreviewClick")]
        public bool IsPreviewClick { get; set; }

        /// <summary>
        /// Gets or sets additional data related to the IP address of the user.
        /// </summary>
        [JsonPropertyName("IPAddressData")]
        public string? IPAddressData { get; set; }

        /// <summary>
        /// Gets or sets the user agent details of the device that clicked the smart URL.
        /// </summary>
        [JsonPropertyName("UserAgentDetails")]
        public string? UserAgentDetails { get; set; }

        /// <summary>
        /// Gets or sets the family of the user agent (e.g., browser family).
        /// </summary>
        [JsonPropertyName("UserAgentFamily")]
        public string? UserAgentFamily { get; set; }

        /// <summary>
        /// Gets or sets the major version of the user agent.
        /// </summary>
        [JsonPropertyName("UserAgentMajor")]
        public string? UserAgentMajor { get; set; }

        /// <summary>
        /// Gets or sets the minor version of the user agent.
        /// </summary>
        [JsonPropertyName("UserAgentMinor")]
        public string? UserAgentMinor { get; set; }

        /// <summary>
        /// Gets or sets the family of the operating system used by the device.
        /// </summary>
        [JsonPropertyName("OSFamily")]
        public string? OSFamily { get; set; }

        /// <summary>
        /// Gets or sets the major version of the operating system.
        /// </summary>
        [JsonPropertyName("OSMajor")]
        public string? OSMajor { get; set; }

        /// <summary>
        /// Gets or sets the minor version of the operating system.
        /// </summary>
        [JsonPropertyName("OSMinor")]
        public string? OSMinor { get; set; }

        /// <summary>
        /// Gets or sets the family of the device (e.g., mobile, desktop).
        /// </summary>
        [JsonPropertyName("DeviceFamily")]
        public string? DeviceFamily { get; set; }

        /// <summary>
        /// Gets or sets any additional information related to the click.
        /// </summary>
        [JsonPropertyName("AdditionalInfo")]
        public string? AdditionalInfo { get; set; }
    }
}