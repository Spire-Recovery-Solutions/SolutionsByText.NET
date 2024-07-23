using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SolutionsByText.NET.Models.Requests
{
    public class Address
    {
         /// <summary>
            /// Gets or sets the first line of the address.
            /// </summary>
            [JsonPropertyName("address1")]
            public string? Address1 { get; set; }  

            /// <summary>
            /// Gets or sets the second line of the address.
            /// </summary>
            [JsonPropertyName("address2")]
            public string? Address2 { get; set; }  

            /// <summary>
            /// Gets or sets the city of the address.
            /// </summary>
            [JsonPropertyName("city")]
            public string? City { get; set; }  

            /// <summary>
            /// Gets or sets the state of the address.
            /// </summary>
            [JsonPropertyName("state")]
            public string? State { get; set; }  

            /// <summary>
            /// Gets or sets the postal code of the address.
            /// </summary>
            [JsonPropertyName("postalCode")]
            public string? PostalCode { get; set; }  

            /// <summary>
            /// Gets or sets the country code of the address.
            /// </summary>
            [JsonPropertyName("countryCode")]
            public string? CountryCode { get; set; }  
    }
}
