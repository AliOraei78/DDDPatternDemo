using DDDPatternDemo.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDDPatternDemo.Domain.ValueObjects
{
    public record Email
    {
        public string Value { get; init; } = string.Empty;

        private Email() { }

        public static Email Create(string email)
        {
            if (string.IsNullOrWhiteSpace(email) || !email.Contains("@"))
                throw new DomainValidationException("The entered email is not valid.");

            return new Email
            {
                Value = email.Trim().ToLowerInvariant()
            };
        }

        public override string ToString() => Value;
    }
}
