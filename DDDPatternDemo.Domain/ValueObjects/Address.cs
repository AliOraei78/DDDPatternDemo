using DDDPatternDemo.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDDPatternDemo.Domain.ValueObjects
{
    public record Address
    {
        public string Street { get; init; } = string.Empty;
        public string City { get; init; } = string.Empty;
        public string PostalCode { get; init; } = string.Empty;
        public string Country { get; init; } = "Iran";

        private Address() { }

        public static Address Create(
            string street,
            string city,
            string postalCode,
            string country = "Iran")
        {
            if (string.IsNullOrWhiteSpace(street))
                throw new DomainValidationException("Street address is required.");

            if (string.IsNullOrWhiteSpace(city))
                throw new DomainValidationException("City is required.");

            return new Address
            {
                Street = street.Trim(),
                City = city.Trim(),
                PostalCode = postalCode?.Trim() ?? string.Empty,
                Country = country.Trim()
            };
        }
    }
}
