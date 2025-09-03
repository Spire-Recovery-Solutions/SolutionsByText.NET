using SolutionsByText.NET.Models.Requests.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SolutionsByText.NET.Models.Requests.Reports
{
    public class GetBrandVbtInboundMessageRequest : PaginationData
    {
        /// <summary>
        /// The identifier of the brand being polled.
        /// </summary>
        [JsonIgnore] 
        public string BrandId { get; set; } = string.Empty;

        /// <summary>
        /// Customer-defined identifier for the message.
        /// </summary>
        [JsonIgnore]
        public string? ReferenceId { get; set; }

        /// <summary>
        /// Start date of query. Default is first of the current month.
        /// </summary>
        [JsonIgnore]
        public DateTime? FromDate { get; set; }

        /// <summary>
        /// End date of query. Default is the current date.
        /// </summary>
        [JsonIgnore]
        public DateTime? ToDate { get; set; }

        /// <summary>
        /// Optional offset from UTC.
        /// </summary>
        [JsonIgnore]
        public string? TimeZoneOffset { get; set; }

        /// <summary>
        /// Type of message sent.
        /// </summary>
        [JsonIgnore]
        public BrandVBTInboundMessages? Type { get; set; }
    }
}
