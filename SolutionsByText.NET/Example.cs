using SolutionsByText.NET.Models.Exceptions;
using SolutionsByText.NET.Service;

class Program
{
    static async Task Main(string[] args)
    {
        var service = new SolutionsByTextService("https://api.solutionsbytext.com", "https://login-stage.solutionsbytext.com","enter client Id", "enter client secret");

        try
        {
            await service.AddGroupSubscriberAsync();
            await service.GetSubscriberStatusAsync();
            await service.SendMessageAsync();
            await service.SendTemplateMessageAsync();
            await service.ScheduleMessageAsync();
            await service.AddBrandSubscriberAsync();
            await service.ConfirmSubscriberAsync();
            await service.DeleteSubscriberAsync();
            await service.GetGroupInfoAsync();
            await service.GetOutboundMessagesAsync();
            await service.GetInboundMessagesAsync();
            await service.GetDeactivationEventsAsync();
            await service.CreateSmartURLAsync();
            await service.GetPhoneNumberDataAsync();
            await service.ConfirmBrandSubscriberAsync();
            await service.ScheduleTemplateMessageAsync();
            await service.UpdateSmartURLAsync();
            await service.AddKeywordAsync();
            await service.GetKeywordsAsync();
            await service.RetrieveMMSKeywordAsync();
            await service.DeleteMMSKeywordAsync();
            await service.GetBrandSubscriberStatusAsync();
            await service.GetTemplatesAsync();
            await service.GetTemplateByIdAsync();
            await service.UpdateSubscribersBrandAsync();
            await service.GetNumberDeactivateEventsAsync();
            await service.GetAllSmartUrl();
            await service.GetSmartUrlClickReportAsync();
            await service.GetSmartUrlDetailClickReportAsync();
            await service.GetBrandVbtOutboundMessagesAsync();
            await service.GetBrandVbtInboundMessagesAsync();

        }
        catch (ApiException ex)
        {
            Console.WriteLine($"API error {ex.AppCode}: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}