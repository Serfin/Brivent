using System;
using System.Threading.Tasks;
using Brivent.BuildingBlocks.Application;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Brivent.API.Configuration.Validation
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public ExceptionHandlingMiddleware(
            RequestDelegate next,
            ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger("Middleware");
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (CommandValidationException exception) 
            {
                _logger.LogError(exception, "Command processing resulted with validation error");
                await context.Response.WriteAsJsonAsync(new ResponseExceptionDetails(
                    "Command validation error", StatusCodes.Status400BadRequest, exception.ValidationErrors));
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "Command processing resulted with unhandled exception");
                await context.Response.WriteAsJsonAsync(new ResponseExceptionDetails(
                    "Internal server error", StatusCodes.Status500InternalServerError, null));
            }
        }
    }
}
