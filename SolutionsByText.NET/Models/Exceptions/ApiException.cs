namespace SolutionsByText.NET.Models.Exceptions;

public class ApiException(int statusCode, string message) : Exception(message)
{
    public int StatusCode { get; } = statusCode;
}