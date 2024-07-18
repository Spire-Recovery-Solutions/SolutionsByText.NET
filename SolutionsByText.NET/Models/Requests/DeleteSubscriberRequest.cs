﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SolutionsByText.NET.Models.Requests
{
    /// <summary>
    /// Represents a request to delete a subscriber from a group.
    /// </summary>
    public class DeleteSubscriberRequest
    {
        /// <summary>
        /// Gets or sets the unique identifier of the group.
        /// </summary>
        [JsonPropertyName("groupId")]
        public string GroupId { get; set; }

        /// <summary>
        /// Gets or sets the phone number of the subscriber to delete.
        /// </summary>
        [JsonPropertyName("msisdn")]
        public string Msisdn { get; set; }
    }
}
