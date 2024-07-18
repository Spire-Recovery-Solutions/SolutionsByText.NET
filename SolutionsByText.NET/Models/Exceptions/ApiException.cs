namespace SolutionsByText.NET.Models.Exceptions;

/// <summary>
/// Represents errors that occur during API operations in the Solutions By Text system.
/// </summary>
public class ApiException : Exception
{
    /// <summary>
    /// Gets the HTTP status code associated with the API error.
    /// </summary>
    public int StatusCode { get; }

    /// <summary>
    /// Initializes a new instance of the ApiException class with a specified error message and HTTP status code.
    /// </summary>
    /// <param name="statusCode">The HTTP status code of the error response.</param>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    public ApiException(int statusCode, string message) : base(message)
    {
        StatusCode = statusCode;
    }
}