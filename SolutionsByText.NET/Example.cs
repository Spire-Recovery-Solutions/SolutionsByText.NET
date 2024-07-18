using SolutionsByText.NET;
using SolutionsByText.NET.Models.Exceptions;
using SolutionsByText.NET.Models.Requests;

var client = new SolutionsByTextClient("https://api.solutionsbytext.com", "your-api-key");

var request = new SendMessageRequest
{
    GroupId = "your-group-id",
    Message = "Hello, World!",
    MessageType = MessageType.Unicast,
    Subscribers = new List<Subscriber>
    {
        new Subscriber { Msisdn = "1234567890" }
    }
};

try
{
    var response = await client.SendMessageAsync(request);
    Console.WriteLine($"Message sent successfully. Message ID: {response.MessageId}");
}
catch (ApiException ex)
{
    Console.WriteLine($"API error {ex.StatusCode}: {ex.Message}");
}
catch (Exception ex)
{
    Console.WriteLine($"An error occurred: {ex.Message}");
}