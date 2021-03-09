using System;
using System.Collections.Generic;

namespace Brivent.BuildingBlocks.Application
{
    public class CommandValidationException : Exception
    {
        public List<string> ValidationErrors { get; set; }

        public CommandValidationException(List<string> errors)
        {
            ValidationErrors = errors;
        }
    }
}
