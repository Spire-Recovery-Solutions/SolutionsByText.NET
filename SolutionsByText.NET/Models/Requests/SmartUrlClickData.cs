using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SolutionsByText.NET.Models.Requests
{
    public class SmartUrlClickData
    {
        [JsonPropertyName("Domain")]
        public string Domain { get; set; }

        [JsonPropertyName("LongUrl")]
        public string LongUrl { get; set; }

        [JsonPropertyName("SmartUrl")]
        public string SmartUrl { get; set; }

        [JsonPropertyName("BrandId")]
        public string BrandId { get; set; }

        [JsonPropertyName("AccountId")]
        public string AccountId { get; set; }

        [JsonPropertyName("ClickedDateTime")]
        public DateTime ClickedDateTime { get; set; }

        [JsonPropertyName("RemoteIpAddress")]
        public string RemoteIpAddress { get; set; }

        [JsonPropertyName("Referer")]
        public string Referer { get; set; }

        [JsonPropertyName("Origin")]
        public string Origin { get; set; }

        [JsonPropertyName("IsPreviewClick")]
        public bool IsPreviewClick { get; set; }

        [JsonPropertyName("IPAddressData")]
        public string IPAddressData { get; set; }

        [JsonPropertyName("UserAgentDetails")]
        public string UserAgentDetails { get; set; }

        [JsonPropertyName("UserAgentFamily")]
        public string UserAgentFamily { get; set; }

        [JsonPropertyName("UserAgentMajor")]
        public string UserAgentMajor { get; set; }

        [JsonPropertyName("UserAgentMinor")]
        public string UserAgentMinor { get; set; }

        [JsonPropertyName("OSFamily")]
        public string OSFamily { get; set; }

        [JsonPropertyName("OSMajor")]
        public string OSMajor { get; set; }

        [JsonPropertyName("OSMinor")]
        public string OSMinor { get; set; }

        [JsonPropertyName("DeviceFamily")]
        public string DeviceFamily { get; set; }

        [JsonPropertyName("AdditionalInfo")]
        public string AdditionalInfo { get; set; }
    }
}
