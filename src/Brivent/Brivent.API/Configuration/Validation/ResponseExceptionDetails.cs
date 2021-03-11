using System.Collections.Generic;

namespace Brivent.API.Configuration.Validation
{
    public class ResponseExceptionDetails
    {
        public string Title { get; set; }
        public int Code { get; set; }
        public List<string> Errors { get; set; }

        public ResponseExceptionDetails()
        {

        }

        public ResponseExceptionDetails(
            string title,
            int code,
            List<string> errors)
        {
            Title = title;
            Code = code;
            Errors = errors;
        }
    }
}
