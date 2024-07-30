using SolutionsByText.NET.Models.Requests;
using SolutionsByText.NET.Models.Requests.Enums;

namespace SolutionsByText.NET.Service
{
    public class SolutionsByTextService
    {
        private readonly SolutionsByTextClient _client;

        public SolutionsByTextService(string apiUrl, string apiKey)
        {
            _client = new SolutionsByTextClient(apiUrl, apiKey);
        }

        // Sends a unicast message to a specific subscriber
        public async Task SendMessageAsync()
        {
            var response = await _client.SendMessageAsync(new SendMessageRequest
            {
                GroupId = "your-group-id",
                Message = "Hello, World!",
                MessageType = MessageType.Unicast,
                Subscribers = new List<Subscriber>
                {
                    new Subscriber { Msisdn = "1234567890" }
                }
            });
            Console.WriteLine($"Message sent. Message ID: {response?.Data.MessageId}");
        }

        // Sends a template message to a group
        public async Task SendTemplateMessageAsync()
        {
            var response = await _client.SendTemplateMessageAsync(new SendTemplateMessageRequest
            {
                GroupId = "your-group-id",
                TemplateId = "your-template-id",
                MessageType = MessageType.Multicast
            });
            Console.WriteLine($"Template message sent. Message ID: {response?.MessageId}");
        }

        // Schedules a message to be sent later
        public async Task ScheduleMessageAsync()
        {
            var response = await _client.ScheduleMessageAsync(new ScheduleMessageRequest
            {
                GroupId = "your-group-id",
                Message = "Scheduled Message"
            });
            Console.WriteLine($"Message scheduled. Scheduled Message ID: {response}");
        }

        // Retrieves the status of a subscriber
        public async Task GetSubscriberStatusAsync()
        {
            var response = await _client.GetSubscriberStatusAsync(new GetSubscriberStatusRequest
            {
                GroupId = "your-group-id",
                Msisdn = new List<string> { "1234567890" }
            });
            Console.WriteLine($"Subscriber status retrieved. Status: {response}");
        }

        // Adds a new subscriber to a group
        public async Task AddGroupSubscriberAsync()
        {
            var response = await _client.AddGroupSubscriberAsync(new AddGroupSubscriberRequest
            {
                GroupId = "your-group-id",
                Msisdn = "1234567890"
            });
            Console.WriteLine($"Subscriber added. Response: {response}");
        }

        // Confirms a subscriber's registration using a PIN
        public async Task ConfirmSubscriberAsync()
        {
            var response = await _client.ConfirmSubscriberAsync(new ConfirmSubscriberRequest
            {
                GroupId = "your-group-id",
                Msisdn = "1234567890",
                Pin = "1234"
            });
            Console.WriteLine($"Subscriber confirmation status: {response}");
        }

        // Deletes a subscriber from a group
        public async Task DeleteSubscriberAsync()
        {
            var response = await _client.DeleteSubscriberAsync(new DeleteSubscriberRequest
            {
                GroupId = "your-group-id",
                Msisdn = "1234567890"
            });
            Console.WriteLine($"Subscriber deleted. Response: {response}");
        }

        // Retrieves information about a specific group
        public async Task GetGroupInfoAsync()
        {
            var response = await _client.GetGroupAsync(new GetGroupRequest
            {
                GroupId = "your-group-id"
            });
            Console.WriteLine($"Group information retrieved. Group Name: {response.Name}");
        }

        // Retrieves outbound messages for a group
        public async Task GetOutboundMessagesAsync()
        {
            var response = await _client.GetOutboundMessagesAsync(new GetOutboundMessagesRequest
            {
                GroupId = "your-group-id"
            });
            Console.WriteLine($"Outbound Message retrieved. Total Count : {response.Data.TotalCount}");
        }

        // Retrieves inbound messages for a group
        public async Task GetInboundMessagesAsync()
        {
            var response = await _client.GetInboundMessagesAsync(new GetInboundMessagesRequest
            {
                GroupId = "your-group-id"
            });
            Console.WriteLine($"Inbound Message retrieved. Total Count : {response.Data.TotalCount}");
        }

        // Retrieves deactivation events for a specified date
        public async Task GetDeactivationEventsAsync()
        {
            var response = await _client.GetDeactivationEventsAsync(new GetDeactivationEventsRequest
            {
                EventDate = DateTime.UtcNow.AddDays(-1),
                EventType = "Opt-Out",
                CountryCode = "USA"
            });
            Console.WriteLine($"Deactivation events retrieved. response: {response}");
        }

        // Retrieves deactivation events for a specific phone number
        public async Task GetNumberDeactivateEventsAsync()
        {
            var response = await _client.GetNumberDeactivationEventsAsync(new GetNumberDeactivateEventsRequest
            {
                GroupId = "your-group-id",
                Msisdn = "1234567890",
                CountryCode = "USA"
            });
            Console.WriteLine($"Deactivation events retrieved for a number. response: {response}");
        }

        // Retrieves deactivation events for a specific phone number
        public async Task GetAllSmartUrl()
        {
            var response = await _client.GetAllSmartUrlsAync(new GetAllSmartUrlRequest
            {
                GroupId = "your-group-id"
            });
            Console.WriteLine($"Get All The Smart Urls. response: {response}");
        }


        // Retrieves Smart Url Click Report events for a specific brand
        public async Task GetSmartUrlClickReportAsync()
        {
            var response = await _client.GetSmartUrlClickReportAync(new GetSmartUrlReportRequest
            {
                BrandId = "your-brand-id",
            });
            Console.WriteLine($"Get Smart Urls Click Report. response: {response}");
        }

        // Retrieves Smart Url Detail Click Report events for a specific brand
        public async Task GetSmartUrlDetailClickReportAsync()
        {
            var response = await _client.GetSmartUrlDetailedClickReportAync(new GetSmartUrlReportRequest
            {
                BrandId = "your-brand-id",
            });
            Console.WriteLine($"Get Smart Urls Detail Click Report. response: {response}");
        }

        //  Generates a report of messages that were sent to subscribers during brand-level opt-ins.
        public async Task GetBrandVbtOutboundMessagesAsync()
        {
            var response = await _client.GetBrandVbtOutboundMessageAsync(new GetBrandVbtOutboundMessageRequest
            {
                BrandId = "your-brand-id",
            });
            Console.WriteLine(
                $"Generated a report of messages that were sent to subscribers during  vbt message outbound. response: {response}");
        }

        //  Generates a report of messages that were sent to subscribers during brand-level opt-ins.
        public async Task GetBrandVbtInboundMessagesAsync()
        {
            var response = await _client.GetBrandVbtInboundMessageAsync(new GetBrandVbtInboundMessageRequest
            {
                BrandId = "your-brand-id",
            });
            Console.WriteLine(
                $"Generated a report of messages that were sent to subscribers during  vbt message inbound. response: {response}");
        }

        // Creates a Smart URL for a group
        public async Task CreateSmartURLAsync()
        {
            var response = await _client.CreateSmartURLAsync(new CreateSmartURLRequest
            {
                GroupId = "your-group-id",
                LongUrl = "https://example.com"
            });
            Console.WriteLine($"SmartURL created. Smart URL: {response}");
        }

        // Retrieves data for a specific phone number
        public async Task GetPhoneNumberDataAsync()
        {
            var response = await _client.GetPhoneNumberDataAsync(new GetPhoneNumberDataRequest
            {
                Msisdn = new List<string> { "1234567890" }
            });
            Console.WriteLine($"PhoneNumber information retrieved. Phone Number : {response}");
        }

        // Adds a brand subscriber to a specified brand
        public async Task AddBrandSubscriberAsync()
        {
            var response = await _client.AddBrandSubscriberAsync(new AddBrandSubscriberRequest
            {
                BrandId = "your-brand-id",
                Msisdn = "1234567890"
            });
            Console.WriteLine($"Added Brand Subscriber. Response: {response}");
        }

        // Confirms a brand subscriber's with pin registration
        public async Task ConfirmBrandSubscriberAsync()
        {
            var response = await _client.ConfirmBrandSubscriberAsync(new ConfirmBrandSubscriberRequest
            {
                BrandId = "your-brand-id",
                Msisdn = "1234567890",
                Pin = "your-pin"
            });
            Console.WriteLine($"Confirmed Brand Subscriber. Response: {response}");
        }

        // Updates an existing Smart URL
        public async Task UpdateSmartURLAsync()
        {
            var response = await _client.UpdateSmartURLAsync(new UpdateSmartURLRequest
            {
                GroupId = "your-group-id",
                ShortUrl = "short-url-id",
                LongUrl = "long-url-id"
            });
            Console.WriteLine($"SmartURL updated. Response: {response?.Message}");
        }

        // Schedules a template message to be sent later
        public async Task ScheduleTemplateMessageAsync()
        {
            var response = await _client.ScheduleTemplateMessageAsync(new ScheduleTemplateMessageRequest
            {
                TemplateId = "your-template-id",
                GroupId = "your-group-id"
            });
            Console.WriteLine($"Scheduled Template Message. Response: {response}");
        }

        // Updates an existing Subscriber Brand
        public async Task UpdateSubscribersBrandAsync()
        {
            var response = await _client.UpdateSubscribersBrand(new UpdateSubscribersBrandRequest
            {
                GroupId = "your-group-id",
                Msisdn = "msi-id"
            });
            Console.WriteLine($"Subscriber Brand updated. Response: {response}");
        }

        // Adds a keyword to a specified group
        public async Task AddKeywordAsync()
        {
            var response = await _client.AddKeywordAsync(new AddKeywordRequest
            {
                GroupId = "your-group-id",
                Name = "Test Name",
                UserId = "12345"
            });
            Console.WriteLine($"Keyword Added. Response: {response?.Message}");
        }

        // Retrieves keywords for a specified group
        public async Task GetKeywordsAsync()
        {
            var response = await _client.GetKeywordsAsync(new GetKeywordsRequest
            {
                GroupId = "your-group-id",
                Filter = "keyword-filter"
            });
            Console.WriteLine($"Keywords retrieved. Number of keywords: {response}");
        }

        // Retrieves an MMS keyword for a specified message and file
        public async Task RetrieveMMSKeywordAsync()
        {
            var response = await _client.RetrieveMMSAsync(new RetrieveMMSRequest
            {
                GroupId = "your-group-id",
                MessageId = "12345",
                FileId = "test file Id"
            });
            Console.WriteLine($"MMS Keyword retrieved. Response: {response}");
        }

        // Deletes an MMS keyword for a specified message and file
        public async Task DeleteMMSKeywordAsync()
        {
            var response = await _client.DeleteMMSAsync(new DeleteMMSRequest
            {
                GroupId = "your-group-id",
                MessageId = "12345",
                FileId = "test file Id"
            });
            Console.WriteLine($"MMS Keyword deleted. Response: {response}");
        }

        // Retrieves the status of brand subscribers
        public async Task GetBrandSubscriberStatusAsync()
        {
            var response = await _client.GetBrandSubscriberStatusAsync(new GetBrandSubscriberStatusRequest
            {
                BrandId = "your-brand-id"
            });
            Console.WriteLine($"Brand Subscriber Status Retrieved. Response: {response}");
        }

        // Retrieves templates for a specified group
        public async Task GetTemplatesAsync()
        {
            var response = await _client.GetTemplatesAsync(new GetTemplatesRequest
            {
                GroupId = "your-group-id"
            });
            Console.WriteLine($"Templates Retrieved. Response: {response}");
        }

        // Retrieves a specific template by its ID
        public async Task GetTemplateByIdAsync()
        {
            var response = await _client.GetTemplateAsync(new GetTemplateRequest
            {
                GroupId = "your-group-id",
                TemplateId = "your-template-id"
            });
            Console.WriteLine($"Template Retrieved. Response: {response}");
        }
    }
}