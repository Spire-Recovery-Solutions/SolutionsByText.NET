﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SolutionsByText.NET.Models.Requests.Enums
{
    /// <summary>
    /// Defines the types of messages that can be sent through the Solutions By Text system.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum MessageType
    {
        /// <summary>
        /// A message sent to all subscribers in a group.
        /// </summary>
        BroadcastMessage,

        /// <summary>
        /// A message sent to a single subscriber.
        /// </summary>
        Unicast,

        /// <summary>
        /// A message sent to multiple, but not all, subscribers in a group.
        /// </summary>
        Multicast
    }
}
