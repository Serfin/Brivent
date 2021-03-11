using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Brivent.BuildingBlocks.Application;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Brivent.API.Configuration.Validation
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        private readonly IHostEnvironment _hostEnvirontment;

        public ExceptionHandlingMiddleware(
            RequestDelegate next,
            ILoggerFactory loggerFactory,
            IHostEnvironment hostEnvirontment)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger("Middleware");
            _hostEnvirontment = hostEnvirontment;
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

                var responseExceptionDetails = new ResponseExceptionDetails
                {
                    Title = "Internal server error",
                    Code = StatusCodes.Status500InternalServerError,
                    Errors = _hostEnvirontment.IsDevelopment()
                        ? new List<string> { exception.Message, exception.StackTrace }
                        : null
                };

                await context.Response.WriteAsJsonAsync(responseExceptionDetails);
            }
        }
    }
}
