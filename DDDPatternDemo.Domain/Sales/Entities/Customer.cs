using System;
using System.Collections.Generic;
using System.Text;
using DDDPatternDemo.Domain.Sales.Exceptions;

namespace DDDPatternDemo.Domain.Sales.Entities
{
    /// <summary>
    /// Customer – a classic Entity with persistent identity
    /// </summary>
    public class Customer
    {
        public Guid Id { get; private set; }
        public string FirstName { get; private set; } = string.Empty;
        public string LastName { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;
        public DateTime RegistrationDate { get; private set; }
        public bool IsActive { get; private set; }

        // Private constructor – use Factory only
        private Customer() { }

        /// <summary>
        /// Factory Method – creates a valid instance
        /// </summary>
        public static Customer Create(string firstName, string lastName, string email)
        {
            if (string.IsNullOrWhiteSpace(firstName))
                throw new DomainValidationException("First name is required.");

            if (string.IsNullOrWhiteSpace(lastName))
                throw new DomainValidationException("Last name is required.");

            if (string.IsNullOrWhiteSpace(email) || !email.Contains("@"))
                throw new DomainValidationException("Please enter a valid email address.");

            return new Customer
            {
                Id = Guid.NewGuid(),
                FirstName = firstName.Trim(),
                LastName = lastName.Trim(),
                Email = email.Trim().ToLowerInvariant(),
                RegistrationDate = DateTime.UtcNow,
                IsActive = true
            };
        }

        // Domain behaviors (Business methods)
        public void UpdateName(string firstName, string lastName)
        {
            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName))
                throw new DomainValidationException("First name and last name cannot be empty.");

            FirstName = firstName.Trim();
            LastName = lastName.Trim();
        }

        public void Deactivate()
        {
            if (!IsActive)
                return; // idempotent

            IsActive = false;
        }

        public void Activate()
        {
            if (IsActive)
                return;

            IsActive = true;
        }

        // Entity comparison – usually only Id matters
        public override bool Equals(object? obj)
        {
            if (obj is not Customer other)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            return Id == other.Id;
        }

        public override int GetHashCode() => Id.GetHashCode();

        public static bool operator ==(Customer? left, Customer? right)
            => left is not null && left.Equals(right);

        public static bool operator !=(Customer? left, Customer? right)
            => !(left == right);
    }
}
