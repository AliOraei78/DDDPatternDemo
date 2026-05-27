using DDDPatternDemo.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDDPatternDemo.Domain.ValueObjects
{
    public record Money : IEquatable<Money>
    {
        public decimal Amount { get; init; }
        public string Currency { get; init; } = "IRR";

        private Money() { } // For serialization and EF Core

        public static Money Create(decimal amount, string currency = "IRR")
        {
            if (amount < 0)
                throw new DomainValidationException("Amount cannot be negative.");

            if (string.IsNullOrWhiteSpace(currency))
                throw new DomainValidationException("Currency is required.");

            return new Money
            {
                Amount = amount,
                Currency = currency.ToUpperInvariant()
            };
        }

        public Money Add(Money other)
        {
            if (Currency != other.Currency)
                throw new InvalidOperationException("Cannot add amounts with different currencies.");

            return new Money
            {
                Amount = Amount + other.Amount,
                Currency = Currency
            };
        }

        public override string ToString() => $"{Amount:N0} {Currency}";
    }
}
