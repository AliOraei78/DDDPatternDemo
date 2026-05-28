using DDDPatternDemo.Domain.Sales.Exceptions;
using DDDPatternDemo.Domain.Sales.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDDPatternDemo.Domain.Sales.Aggregates
{
    public class OrderItem
    {
        public Guid Id { get; private set; }
        public Guid ProductId { get; private set; }
        public string ProductName { get; private set; } = string.Empty;
        public int Quantity { get; private set; }
        public Money UnitPrice { get; private set; } = Money.Create(0);

        private OrderItem() { }

        public static OrderItem Create(Guid productId, string productName, int quantity, Money unitPrice)
        {
            if (quantity <= 0)
                throw new DomainValidationException("Quantity must be greater than zero.");

            if (unitPrice.Amount <= 0)
                throw new DomainValidationException("Unit price must be positive.");

            return new OrderItem
            {
                Id = Guid.NewGuid(),
                ProductId = productId,
                ProductName = productName.Trim(),
                Quantity = quantity,
                UnitPrice = unitPrice
            };
        }

        public Money GetTotalPrice() => Money.Create(UnitPrice.Amount * Quantity, UnitPrice.Currency);
    }
}
