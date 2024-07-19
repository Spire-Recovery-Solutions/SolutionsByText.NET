# Solutions By Text .NET SDK

<p align="center">
    <a href="https://solutionsbytext.com/"><img src="https://solutionsbytext.com/wp-content/uploads/sbt-logo-1.svg" alt="Solutions By Text Logo" width="200"/></a>
</p>

<p align="center">
  <a href="https://www.nuget.org/packages/SolutionsByText.NET"><img src="https://img.shields.io/nuget/v/SolutionsByText.NET.svg" alt="NuGet"></a>
</p>

## 📱 About

The Solutions By Text .NET SDK provides a robust and easy-to-use interface for integrating with the Solutions By Text API. This SDK enables developers to seamlessly incorporate text messaging capabilities into their .NET applications.

## 🚀 Features

- 📨 Send SMS and MMS messages
- 👥 Manage subscribers and groups
- 📊 Generate detailed reports
- 🔗 Create and manage SmartURLs
- 🔒 Secure API communication
- ⚡ High performance with AOT support and Source Generated JSON Serialization via System.Text.Json

## 📦 Installation

Install the Solutions By Text SDK via NuGet:

    dotnet add package SolutionsByText.NET

Or via the NuGet Package Manager Console:

    Install-Package SolutionsByText.NET

## 🏗 Quick Start

Here's a simple example to get you started:

    using SolutionsByText.NET;
    using SolutionsByText.NET.Models.Requests;

    var client = new SolutionsByTextClient("YOUR_API_KEY", "https://api.solutionsbytext.com");

    var request = new SendMessageRequest
    {
        GroupId = "your-group-id",
        Message = "Hello from Solutions By Text!",
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
        Console.WriteLine($"API Error: {ex.Message}");
    }

## 📘 Documentation

For detailed documentation, please visit our [GitHub Wiki](https://github.com/Spire-Recovery-Solutions/SolutionsByText.NET/wiki).

## 📊 Supported .NET Versions

- .NET 8.0+

## 🛠 Contributing

We welcome contributions! Please see our [Contributing Guide](CONTRIBUTING.md) for more details.

## 📄 License

This project is licensed under the GPL-3.0 license

## 🤝 Support

If you encounter any issues or have questions, please [open an issue](https://github.com/Spire-Recovery-Solutions/SolutionsByText.NET/issues)
