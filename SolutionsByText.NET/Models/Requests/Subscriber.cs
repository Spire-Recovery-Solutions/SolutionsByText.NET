using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SolutionsByText.NET.Models.Requests
{
    /// <summary>
    /// Represents a subscriber in the system.
    /// This class contains the subscriber's MSISDN (mobile number) and a list of variables associated with the subscriber.
    /// </summary>
    public class Subscriber
    {
        /// <summary>
        /// The MSISDN (mobile number) of the subscriber.
        /// </summary>
        [JsonPropertyName("msisdn")]
        public string Msisdn { get; set; }

        /// <summary>
        /// The list of variables associated with the subscriber.
        /// </summary>
        [JsonPropertyName("variables")]
        public List<Variable> Variables { get; set; }
    }
}