using System;
using System.Collections.Generic;
using System.Text;

namespace DDDPatternDemo.Domain.Exceptions
{
    public class DomainValidationException : Exception
    {
        public DomainValidationException(string message) : base(message) { }
    }
}
