using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionsByText.NET.Models.Responses.Enums
{
    /// <summary>
    /// Represents the various error codes that can be returned by the API,
    /// providing descriptive messages for each code.
    /// </summary>
    public enum ErrorCode
    {
        /// <summary>
        /// Indicates a downstream server error.
        /// </summary>
        [Description("Downstream server error")]
        DownstreamServerError = -1,

        /// <summary>
        /// Indicates that the BrandId is required.
        /// </summary>
        [Description("BrandId is required")]
        BrandIdRequired = 1001,

        /// <summary>
        /// Indicates an invalid BrandId.
        /// </summary>
        [Description("Invalid BrandId")]
        InvalidBrandId = 1002,

        /// <summary>
        /// Indicates that the consent category is not associated with the brand.
        /// </summary>
        [Description("Consent category is not associated to brand")]
        ConsentCategoryNotAssociated = 1003,

        /// <summary>
        /// Indicates that brand level opt-in is not enabled for this brand.
        /// </summary>
        [Description("Brand level optin is not enabled for this brand. Please contact the support team.")]
        BrandLevelOptinNotEnabled = 1005,

        /// <summary>
        /// Indicates that the brand is configured incorrectly.
        /// </summary>
        [Description("Brand configured incorrectly")]
        BrandConfiguredIncorrectly = 1006,

        /// <summary>
        /// Indicates that the 'To Date' must be greater than the 'From Date'.
        /// </summary>
        [Description("To Date must be greater than From Date")]
        InvalidDateRange = 1001,

        /// <summary>
        /// Indicates that the current date must be greater than the 'To Date'.
        /// </summary>
        [Description("Current Date must be greater than To Date")]
        InvalidCurrentDate = 1002,

        /// <summary>
        /// Indicates an invalid event type.
        /// </summary>
        [Description("Invalid Event Type")]
        InvalidEventType = 1003,

        /// <summary>
        /// Indicates an unsupported country code.
        /// </summary>
        [Description("Unsupported CountryCode")]
        UnsupportedCountryCode = 1004,

        /// <summary>
        /// Indicates that an event type is required.
        /// </summary>
        [Description("Event type required")]
        EventTypeRequired = 1005,

        /// <summary>
        /// Indicates a successful request.
        /// </summary>
        [Description("Request successful")]
        RequestSuccessful = 1200,

        /// <summary>
        /// Indicates that the request is unauthorized.
        /// </summary>
        [Description("Unauthorized")]
        Unauthorized = 1401,

        /// <summary>
        /// Indicates that access to the resource is forbidden.
        /// </summary>
        [Description("Access forbidden")]
        AccessForbidden = 1403,

        /// <summary>
        /// Indicates that the requested resource was not found.
        /// </summary>
        [Description("Resource not found")]
        ResourceNotFound = 1404,

        /// <summary>
        /// Indicates that a precondition for the request failed.
        /// </summary>
        [Description("Precondition Failed")]
        PreconditionFailed = 1412,

        /// <summary>
        /// Indicates an internal error.
        /// </summary>
        [Description("Internal Error")]
        InternalError = 1500
    }
}