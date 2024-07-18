namespace SolutionsByText.NET.Models.Exceptions;

 /// <summary>
    /// Represents errors that occur during API operations in the Solutions By Text system.
    /// </summary>
    public class ApiException : Exception
    {
        /// <summary>
        /// Gets the application-specific error code returned by the API.
        /// </summary>
        public string AppCode { get; }

        /// <summary>
        /// Gets a value indicating whether this is an error response from the API.
        /// </summary>
        public bool IsError { get; }

        /// <summary>
        /// Initializes a new instance of the ApiException class with a specified error message, application code, and error flag.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="appCode">The application-specific error code returned by the API.</param>
        /// <param name="isError">A flag indicating whether this is an error response from the API.</param>
        public ApiException(string message, string appCode, bool isError) 
            : base(message)
        {
            AppCode = appCode;
            IsError = isError;
        }

        /// <summary>
        /// Initializes a new instance of the ApiException class with a specified error message and application code.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="appCode">The application-specific error code returned by the API.</param>
        public ApiException(string message, string appCode) 
            : this(message, appCode, true)
        {
        }

        /// <summary>
        /// Initializes a new instance of the ApiException class with a specified error message.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        public ApiException(string message) 
            : this(message, string.Empty, true)
        {
        }

        /// <summary>
        /// Initializes a new instance of the ApiException class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception.</param>
        public ApiException(string message, Exception innerException) 
            : base(message, innerException)
        {
            AppCode = string.Empty;
            IsError = true;
        }
    }