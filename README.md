# Solutions By Text .NET SDK

<p align="center">
    <a href="https://solutionsbytext.com/"><img src="https://solutionsbytext.com/wp-content/uploads/sbt-logo-1.svg" alt="Solutions By Text Logo" width="200"/></a>
</p>

<p align="center">
  <a href="https://www.nuget.org/packages/SolutionsByText.NET"><img src="https://img.shields.io/nuget/v/SolutionsByText.NET.svg" alt="NuGet"></a>
</p>

## 📱 About

The Solutions By Text .NET SDK provides a robust and easy-to-use interface for integrating with the Solutions By Text FinText™ Platform API (T2C 2.0). This comprehensive SDK enables developers to seamlessly incorporate SMS/MMS messaging, subscriber management, and reporting capabilities into their .NET applications.

## 🚀 Features

- 📨 **Messaging**: Send SMS/MMS, schedule messages, template messaging, ODM (On-Demand Messaging)
- 👥 **Subscriber Management**: Add, confirm, delete, reactivate, and manage subscribers at group and brand levels
- 📊 **Reporting & Analytics**: Comprehensive reports for messages, deactivation events, VBT messages, and usage analytics
- 🔗 **SmartURL Management**: Create, update, and track shortened URLs with detailed click analytics
- 📞 **Phone Number Services**: Carrier lookup, phone number validation, and deactivation event tracking
- 📋 **Template & Keyword Management**: Manage message templates and retrieve keywords
- 🎯 **Webhook Support**: Real-time event processing for message status, inbound messages, MMS, and URL clicks
- 🔒 **OAuth2 Authentication**: Secure API communication with automatic token refresh
- ⚡ **High Performance**: AOT compilation support with source-generated JSON serialization
- 🔄 **Resilience**: Built-in retry policies using Polly with exponential backoff

## 📦 Installation

Install the Solutions By Text SDK via NuGet:

```bash
dotnet add package SolutionsByText.NET
```

Or via the NuGet Package Manager Console:

```bash
Install-Package SolutionsByText.NET
```

## 🏗 Quick Start

Here's a simple example to get you started:

```csharp
using SolutionsByText.NET;
using SolutionsByText.NET.Models.Requests.Messages;
using SolutionsByText.NET.Models.Requests.Enums;
using SolutionsByText.NET.Models.Requests;
using SolutionsByText.NET.Models.Exceptions;

// Initialize the client with OAuth2 credentials
var client = new SolutionsByTextClient(
    baseUrl: "https://t2c-api.solutionsbytext.com",                    // Production
    tokenUrl: "https://login.solutionsbytext.com/connect/token",
    clientId: "your-client-id",
    clientSecret: "your-client-secret"
);

// For staging/development, use:
// baseUrl: "https://t2c-api-stage.solutionsbytext.com"
// tokenUrl: "https://login-stage.solutionsbytext.com/connect/token"

var request = new SendMessageRequest
{
    GroupId = "your-group-id",
    From = "YourBrand",
    Message = "Hello from Solutions By Text!",
    MessageType = MessageType.Unicast,
    Subscribers = new List<Subscriber>
    {
        new Subscriber { Msisdn = "12345678901" }  // 11-digit format
    },
    ReferenceId = Guid.NewGuid().ToString()
};

try
{
    var response = await client.SendMessageAsync(request);
    if (response != null)
    {
        Console.WriteLine($"Message sent successfully!");
    }
}
catch (ApiException ex)
{
    Console.WriteLine($"API Error {ex.AppCode}: {ex.Message}");
}
```

## 📋 API Workflow Examples

The Solutions By Text API follows a specific workflow for proper messaging implementation. Following this procedure ensures correct API usage and avoids common problems, pitfalls, and gotchas.

**⚠️ Follow this procedure for every phone number, every time.**

### 🔑 Token Management

The SDK automatically handles OAuth2 token management for you:
- Tokens are cached and automatically refreshed 5 minutes before expiry
- No manual token handling required - just initialize the client once
- The SDK uses event-based token refresh on 401 Unauthorized responses

### 📱 Required API Flow

Here are examples for each step in the required workflow:

### 1. Get Subscriber Status (Required First Step)

**Call this API first, every time.** Based on the status received, follow these rules:

```csharp
using SolutionsByText.NET.Models.Requests.Subscriptions;

var statusRequest = new GetGroupSubscriberStatusRequest
{
    GroupId = "your-group-id",
    Msisdn = new List<string> { "12345678901" }
};

var statusResponse = await client.GetGroupSubscriberStatusAsync(statusRequest);
var status = statusResponse?.Data?.FirstOrDefault()?.Status;

switch (status)
{
    case "Active":
        // ✅ Send messages to this number
        Console.WriteLine("Subscriber is active - ready for messaging");
        break;
    case "Inactive":  
        // ❌ Do not send messages to this number
        Console.WriteLine("Subscriber is inactive - do not message");
        break;
    case "UnderVerification":
        // ⏳ Wait for subscriber to respond with keyword or PIN
        Console.WriteLine("Subscriber is under verification - wait for PIN response");
        break;
    case null:
        // 👤 Not a Subscriber - proceed to step 2 (Get Phone Numbers Data)
        Console.WriteLine("Not a subscriber - check if mobile number");
        break;
}
```

### 2. Get Phone Numbers Data (Only for "Not a Subscriber")

**This API determines if a number is mobile or landline.** Only call this for numbers that are "Not a Subscriber":

```csharp
using SolutionsByText.NET.Models.Requests.PhoneNumbers;

var phoneRequest = new GetPhoneNumberDataRequest
{
    Msisdn = new List<string> { "12345678901" }
};

var phoneResponse = await client.GetPhoneNumberDataAsync(phoneRequest);
var phoneData = phoneResponse?.Data?.FirstOrDefault();

if (phoneData?.Type == "Mobile")
{
    // ✅ Use Add Subscriber to Group or Brand APIs to opt in the subscriber  
    Console.WriteLine("Number is mobile - can proceed with opt-in");
    // Proceed to step 3
}
else
{
    // ❌ Landline number - DO NOT attempt to add or message
    Console.WriteLine("Number is not mobile - cannot message");
    // ⚠️ Messaging will result in StopFail and may cost usage credits
    // Update records to mark as non-mobile and not eligible for messaging
}
```

### 3. Add Subscriber to Group (Only for Mobile Numbers)

**Only for mobile numbers that aren't subscribers.** Opts in subscriber to Marketing OR Non-Marketing messages:

```csharp
using SolutionsByText.NET.Models.Requests.Subscriptions;
using SolutionsByText.NET.Models.Requests.Enums;

var addRequest = new AddGroupSubscriberRequest
{
    GroupId = "your-group-id",
    Msisdn = "12345678901",
    FirstName = "John",
    LastName = "Doe",
    VerificationType = VerificationType.Pin // or ReservedWord, SilentOptin, Optin
};

var addResponse = await client.AddGroupSubscriberAsync(addRequest);
if (addResponse != null && !addResponse.IsError)
{
    Console.WriteLine("Subscriber added successfully");
}
```

### 4. Add Subscriber to Brand (Alternative Option)

**Alternative to step 3.** Opts in subscriber to BOTH Marketing AND Non-Marketing messages:

```csharp
using SolutionsByText.NET.Models.Requests.Subscriptions;
using SolutionsByText.NET.Models.Requests.Enums;

var brandRequest = new AddBrandSubscriberRequest
{
    BrandId = "your-brand-id",
    Msisdn = "12345678901",
    FirstName = "John",
    LastName = "Doe",
    VerificationType = VerificationType.Pin // or ReservedWord, SilentOptin, Optin
};

var brandResponse = await client.AddBrandSubscriberAsync(brandRequest);
if (brandResponse != null && !brandResponse.IsError)
{
    Console.WriteLine("Subscriber added to brand successfully");
}
```

### 5. Send Messages (Only to "Active" Subscribers)

**Only send messages to subscribers with "Active" status** from step 1:

```csharp
// Already shown in Quick Start example above
var messageRequest = new SendMessageRequest
{
    GroupId = "your-group-id",
    From = "YourBrand",
    Message = "Hello from Solutions By Text!",
    MessageType = MessageType.Unicast,
    Subscribers = new List<Subscriber>
    {
        new Subscriber { Msisdn = "12345678901" }
    },
    ReferenceId = Guid.NewGuid().ToString()
};

var response = await client.SendMessageAsync(messageRequest);
```

### 🎯 Five Important Takeaways

1. **🔑 Token Management**: SDK automatically handles OAuth2 tokens (1 hour lifetime, auto-refresh)
2. **📞 Always Check Status**: Use Get Subscriber Status for every number, every time
3. **📱 Phone Data Once**: Get Phone Numbers Data is only required once per number  
4. **🚫 No Landline Adds**: Do not use Add Subscriber APIs with non-mobile numbers
5. **⚠️ Status Before Messaging**: Do not attempt to send messages before checking subscriber status

**❌ Common Mistakes to Avoid:**
- Adding landline numbers (will fail and waste credits)
- Messaging inactive or unverified subscribers  
- Skipping subscriber status checks
- Using Add Subscriber APIs before attempting to send messages

## 🏛 Architecture & Design

### Core Components
- **SolutionsByTextClient**: Main client implementing all 36 API endpoints
- **Models**: Strongly-typed request/response DTOs organized by feature area
- **Authentication**: OAuth2 client credentials flow with automatic token management
- **Error Handling**: Custom `ApiException` with application-specific error codes
- **Serialization**: Source-generated JSON serialization for optimal performance

### Key Technical Features
- **Framework**: .NET 9.0 with AOT compilation support
- **Dependencies**: Polly for resilience and retry policies
- **Authentication**: Automatic OAuth2 token refresh (5 minutes before expiry)
- **Retry Logic**: 3 attempts with exponential backoff for transient failures
- **Performance**: Source-generated JSON serialization via `System.Text.Json`

## 🔧 API Coverage

The SDK implements the complete Solutions By Text T2C 2.0 API specification:

| Category | Features |
|----------|----------|
| **Messages** | Send, schedule, templates, ODM messaging |
| **Subscribers** | Add, confirm, delete, status, reactivation, cancellation |
| **Reporting** | Inbound/outbound messages, deactivation events, VBT reports |
| **Analytics** | Usage reports, brand breakdowns, phone number events |
| **Management** | Keywords, templates, SmartURLs, carrier lookup |

Total: **36 endpoints**, **323+ data models**, **4 webhook types**

## 🌐 API Environments

| Environment | API Base URL | Token URL |
|-------------|--------------|-----------|
| **Staging** | `https://t2c-api-stage.solutionsbytext.com` | `https://login-stage.solutionsbytext.com/connect/token` |
| **Production** | `https://t2c-api.solutionsbytext.com` | `https://login.solutionsbytext.com/connect/token` |

**Important**: Client secrets containing special characters (like `+`) must be URL encoded.

## 🛠 Development Tools

The repository includes Node.js-based tools for API analysis:

- **`tools/fetch-api-docs.js`** - Dynamically extracts complete API specification using browser automation
- **`tools/generate-api-tracker.js`** - Generates implementation coverage tracking

## 📊 Supported .NET Versions

- .NET 9.0+

## 🤝 Contributing

We welcome contributions! Please see our [Contributing Guide](CONTRIBUTING.md) for more details.

## 📄 License

This project is licensed under the GPL-3.0 license.

## 🆘 Support

If you encounter any issues or have questions:
- [Open an issue](https://github.com/Spire-Recovery-Solutions/SolutionsByText.NET/issues)
- Check the official API documentation: https://developers.solutionsbytext.com/docs/t2c2.0/

## 🔗 Links

- [Solutions By Text Website](https://solutionsbytext.com/)
- [Official API Documentation](https://developers.solutionsbytext.com/docs/t2c2.0/)
- [NuGet Package](https://www.nuget.org/packages/SolutionsByText.NET)