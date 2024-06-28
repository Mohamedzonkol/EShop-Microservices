using BuildingBlocks.Exception;
using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BuildingBlocks.Exceptions.Handler
{
    public class CustomExceptionHandler(ILogger<CustomExceptionHandler> logger) : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, System.Exception exception,
            CancellationToken cancellationToken)
        {
            logger.LogError(
                "Error Message: {exceptionMessage}, Time of occurrence {time}",
                exception.Message, DateTime.Now);
            (string Detail, string Title, int StatusCode) details = exception switch
            {
                BadRequestException badRequestException => (badRequestException.Message, "Bad Request",
                    StatusCodes.Status400BadRequest),
                NotFoundException notFoundException => (notFoundException.Message, "Not Found",
                    StatusCodes.Status404NotFound),
                InternalServerException internalServerException => (internalServerException.Message,
                    "Internal Server Error", StatusCodes.Status500InternalServerError),
                _ => (exception.Message, exception.GetType().Name, StatusCodes.Status500InternalServerError)
            };
            var problemDetails = new ProblemDetails
            {
                Title = details.Title,
                Detail = details.Detail,
                Status = details.StatusCode,
                Instance = httpContext.Request.Path
            };
            problemDetails.Extensions.Add("traceId", httpContext.TraceIdentifier);

            if (exception is ValidationException validationException)
            {
                problemDetails.Extensions.Add("ValidationErrors", validationException.Errors);
            }

            await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken: cancellationToken);
            return true;
        }
    }
}
