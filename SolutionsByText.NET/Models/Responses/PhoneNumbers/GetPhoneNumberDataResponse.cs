using System.Text.Json.Serialization;

namespace SolutionsByText.NET.Models.Responses.PhoneNumbers
{

    /// <summary>
    /// Represents the response received after requesting phone number data.
    /// </summary>
    public class GetPhoneNumberDataResponse : ApiResponse<List<PhoneNumberData>>
    {
    }
}
