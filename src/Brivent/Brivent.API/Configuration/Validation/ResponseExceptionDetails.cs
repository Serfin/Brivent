using System.Collections.Generic;
using Brivent.BuildingBlocks.Application;
using Microsoft.AspNetCore.Http;

namespace Brivent.API.Configuration.Validation
{
    public class ResponseExceptionDetails
    {
        public string Title { get; set; }
        public int Status { get; set; }
        public List<string> Errors { get; set; }

        public ResponseExceptionDetails(
            string title,
            int status,
            List<string> errors)
        {
            Title = title;
            Status = status;
            Errors = errors;
        }
    }
}
