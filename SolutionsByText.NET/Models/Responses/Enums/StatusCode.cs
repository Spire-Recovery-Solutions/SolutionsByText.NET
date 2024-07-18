using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionsByText.NET.Models.Responses.Enums
{
    public enum StatusCode
    {
        [Description("Unknown Carrier")]
        UnknownCarrier = -1,

        [Description("Your message has been queued in the Platform")]
        MessageQueued = 99,

        [Description("Message was successfully delivered")]
        Delivered = 100,

        [Description("Message was successfully delivered to the carrier")]
        SentToCarrier = 101,

        [Description("The message has been queued for delivery to the carrier")]
        QueuedToCarrier = 102,

        [Description("Stopfail - Not a Subscriber")]
        StopfailNotSubscriber = 110,

        [Description("Stopfail - Inactive Subscriber")]
        StopfailInactiveSubscriber = 111,

        [Description("Stopfail - Blocked Subscriber")]
        StopfailBlockedSubscriber = 112,

        [Description("StopFail - Carrier Not Supported")]
        StopfailCarrierNotSupported = 113,

        [Description("StopFail - Invalid Number")]
        StopfailInvalidNumber = 114,

        [Description("StopFail - Landline Number")]
        StopfailLandlineNumber = 115,

        [Description("StopFail - VBT In Process")]
        StopfailVBTInProcess = 116,

        [Description("StopFail – Non-FTEU Carrier")]
        StopfailNonFTEUCarrier = 120,

        [Description("The message was undeliverable and no explanation was provided from the carrier")]
        Undeliverable = 200,

        [Description("The carrier has blocked SMS traffic to the handset")]
        BlockedNumber = 201,

        [Description("The phone number is no longer in service")]
        DeactivatedNumber = 203,

        [Description("No message content provided, message was too long, or message contained invalid characters")]
        InvalidContent = 204,

        [Description("The phone number belongs to a country that is not supported")]
        UnsupportedCountry = 205,

        [Description("The carrier was unable to forward the message to the handset")]
        UnableToForward = 206,

        [Description("The carrier ID provided was invalid")]
        InvalidCarrier = 208,

        [Description("Carrier Not Found")]
        CarrierNotFound = 209,

        [Description("Subscriber insufficient credits")]
        InsufficientCredits = 210,

        [Description("Invalid destination address")]
        InvalidDestinationAddress = 211,

        [Description("Message content blocked")]
        ContentBlocked = 212,

        [Description("Message blocked, unsubscribe")]
        BlockedUnsubscribe = 213,

        [Description("Blocked due multiple identical or similar messages within an hour to the same subscriber")]
        FloodFilter = 214,

        [Description("System Error")]
        SystemError = 404,

        [Description("A provided parameter was invalid")]
        InvalidParameter = 408,

        [Description("Account misconfiguration detected")]
        ConfigError = 409,

        [Description("Carrier not supported by aggregator / No delivery route defined for carrier")]
        InvalidRoute = 410,

        [Description("Carrier TPS Rate Exceeded")]
        CarrierTPSRateExceeded = 411,

        [Description("Carrier Daily Volume Exceeded")]
        CarrierDailyVolumeExceeded = 412,

        [Description("Campaign information is not provisioned for this carrier or is not active")]
        CampaignNotProvisioned = 572,

        [Description("Message undeliverable due to restriction in communication code used")]
        LCReplaced = 800
    }
}
