using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SolutionsByText.NET.Models.Responses.Enums
{
    
    /// <summary>
    /// Defines the possible statuses of an operation.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum OperationStatus
    {
        /// <summary>
        /// The operation was successful.
        /// </summary>
        Success,

        /// <summary>
        /// The operation failed.
        /// </summary>
        Failure
    }
}
