using System.ComponentModel;

namespace SolutionsByText.NET.Models.Responses.Enums
{
    /// <summary>
    /// Represents the various status codes that can be returned by the API,
    /// providing descriptive messages for each code related to message delivery.
    /// </summary>
    public enum StatusCode
    {
        /// <summary>
        /// Indicates an unknown carrier.
        /// </summary>
        [Description("Unknown Carrier")]
        UnknownCarrier = -1,

        /// <summary>
        /// Indicates that the message has been queued in the platform.
        /// </summary>
        [Description("Your message has been queued in the Platform")]
        MessageQueued = 99,

        /// <summary>
        /// Indicates that the message was successfully delivered.
        /// </summary>
        [Description("Message was successfully delivered")]
        Delivered = 100,

        /// <summary>
        /// Indicates that the message was successfully delivered to the carrier.
        /// </summary>
        [Description("Message was successfully delivered to the carrier")]
        SentToCarrier = 101,

        /// <summary>
        /// Indicates that the message has been queued for delivery to the carrier.
        /// </summary>
        [Description("The message has been queued for delivery to the carrier")]
        QueuedToCarrier = 102,

        /// <summary>
        /// Indicates a stop failure due to the subscriber not being present.
        /// </summary>
        [Description("Stopfail - Not a Subscriber")]
        StopfailNotSubscriber = 110,

        /// <summary>
        /// Indicates a stop failure due to the subscriber being inactive.
        /// </summary>
        [Description("Stopfail - Inactive Subscriber")]
        StopfailInactiveSubscriber = 111,

        /// <summary>
        /// Indicates a stop failure due to the subscriber being blocked.
        /// </summary>
        [Description("Stopfail - Blocked Subscriber")]
        StopfailBlockedSubscriber = 112,

        /// <summary>
        /// Indicates a stop failure due to the carrier not being supported.
        /// </summary>
        [Description("StopFail - Carrier Not Supported")]
        StopfailCarrierNotSupported = 113,

        /// <summary>
        /// Indicates a stop failure due to an invalid number.
        /// </summary>
        [Description("StopFail - Invalid Number")]
        StopfailInvalidNumber = 114,

        /// <summary>
        /// Indicates a stop failure due to a landline number.
        /// </summary>
        [Description("StopFail - Landline Number")]
        StopfailLandlineNumber = 115,

        /// <summary>
        /// Indicates a stop failure due to VBT being in process.
        /// </summary>
        [Description("StopFail - VBT In Process")]
        StopfailVBTInProcess = 116,

        /// <summary>
        /// Indicates a stop failure due to a non-FTEU carrier.
        /// </summary>
        [Description("StopFail – Non-FTEU Carrier")]
        StopfailNonFTEUCarrier = 120,

        /// <summary>
        /// Indicates that the message was undeliverable without an explanation from the carrier.
        /// </summary>
        [Description("The message was undeliverable and no explanation was provided from the carrier")]
        Undeliverable = 200,

        /// <summary>
        /// Indicates that the carrier has blocked SMS traffic to the handset.
        /// </summary>
        [Description("The carrier has blocked SMS traffic to the handset")]
        BlockedNumber = 201,

        /// <summary>
        /// Indicates that the phone number is no longer in service.
        /// </summary>
        [Description("The phone number is no longer in service")]
        DeactivatedNumber = 203,

        /// <summary>
        /// Indicates that no message content was provided, or the message was too long, or contained invalid characters.
        /// </summary>
        [Description("No message content provided, message was too long, or message contained invalid characters")]
        InvalidContent = 204,

        /// <summary>
        /// Indicates that the phone number belongs to a country that is not supported.
        /// </summary>
        [Description("The phone number belongs to a country that is not supported")]
        UnsupportedCountry = 205,

        /// <summary>
        /// Indicates that the carrier was unable to forward the message to the handset.
        /// </summary>
        [Description("The carrier was unable to forward the message to the handset")]
        UnableToForward = 206,

        /// <summary>
        /// Indicates that the carrier ID provided was invalid.
        /// </summary>
        [Description("The carrier ID provided was invalid")]
        InvalidCarrier = 208,

        /// <summary>
        /// Indicates that the carrier was not found.
        /// </summary>
        [Description("Carrier Not Found")]
        CarrierNotFound = 209,

        /// <summary>
        /// Indicates that the subscriber has insufficient credits.
        /// </summary>
        [Description("Subscriber insufficient credits")]
        InsufficientCredits = 210,

        /// <summary>
        /// Indicates that the destination address is invalid.
        /// </summary>
        [Description("Invalid destination address")]
        InvalidDestinationAddress = 211,

        /// <summary>
        /// Indicates that the message content was blocked.
        /// </summary>
        [Description("Message content blocked")]
        ContentBlocked = 212,

        /// <summary>
        /// Indicates that the message was blocked due to an unsubscribe request.
        /// </summary>
        [Description("Message blocked, unsubscribe")]
        BlockedUnsubscribe = 213,

        /// <summary>
        /// Indicates that the message was blocked due to multiple identical or similar messages sent within an hour to the same subscriber.
        /// </summary>
        [Description("Blocked due multiple identical or similar messages within an hour to the same subscriber")]
        FloodFilter = 214,

        /// <summary>
        /// Indicates a system error.
        /// </summary>
        [Description("System Error")]
        SystemError = 404,

        /// <summary>
        /// Indicates that a provided parameter was invalid.
        /// </summary>
        [Description("A provided parameter was invalid")]
        InvalidParameter = 408,

        /// <summary>
        /// Indicates that an account misconfiguration was detected.
        /// </summary>
        [Description("Account misconfiguration detected")]
        ConfigError = 409,

        /// <summary>
        /// Indicates that the carrier is not supported by the aggregator or no delivery route is defined for the carrier.
        /// </summary>
        [Description("Carrier not supported by aggregator / No delivery route defined for carrier")]
        InvalidRoute = 410,

        /// <summary>
        /// Indicates that the carrier's TPS rate has been exceeded.
        /// </summary>
        [Description("Carrier TPS Rate Exceeded")]
        CarrierTPSRateExceeded = 411,

        /// <summary>
        /// Indicates that the carrier's daily volume has been exceeded.
        /// </summary>
        [Description("Carrier Daily Volume Exceeded")]
        CarrierDailyVolumeExceeded = 412,

        /// <summary>
        /// Indicates that campaign information is not provisioned for this carrier or is not active.
        /// </summary>
        [Description("Campaign information is not provisioned for this carrier or is not active")]
        CampaignNotProvisioned = 572,

        /// <summary>
        /// Indicates that the message is undeliverable due to a restriction in the communication code used.
        /// </summary>
        [Description("Message undeliverable due to restriction in communication code used")]
        LCReplaced = 800
    }
}