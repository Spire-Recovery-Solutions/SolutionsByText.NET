using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionsByText.NET.Models.Responses.Enums
{

    public enum ErrorCode
    {
        [Description("Downstream server error")]
        DownstreamServerError = -1,

        [Description("BrandId is required")]
        BrandIdRequired = 1001,

        [Description("Invalid BrandId")]
        InvalidBrandId = 1002,

        [Description("Consent category is not associated to brand")]
        ConsentCategoryNotAssociated = 1003,

        [Description("Brand level optin is not enabled for this brand. Please contact the support team.")]
        BrandLevelOptinNotEnabled = 1005,

        [Description("Brand configured incorrectly")]
        BrandConfiguredIncorrectly = 1006,

        [Description("To Date must be greater than From Date")]
        InvalidDateRange = 1001,

        [Description("Current Date must be greater than To Date")]
        InvalidCurrentDate = 1002,

        [Description("Invalid Event Type")]
        InvalidEventType = 1003,

        [Description("Unsupported CountryCode")]
        UnsupportedCountryCode = 1004,

        [Description("Event type required")]
        EventTypeRequired = 1005,

        [Description("Request successful")]
        RequestSuccessful = 1200,

        [Description("Unauthorized")]
        Unauthorized = 1401,

        [Description("Access forbidden")]
        AccessForbidden = 1403,

        [Description("Resource not found")]
        ResourceNotFound = 1404,

        [Description("Precondition Failed")]
        PreconditionFailed = 1412,

        [Description("Internal Error")]
        InternalError = 1500
    }
}
