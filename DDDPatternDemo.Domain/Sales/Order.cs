using System;
using System.Collections.Generic;
using System.Text;

namespace DDDPatternDemo.Domain.Sales
{
    /// <summary>
    /// Order model in the Sales Bounded Context
    /// Contains only the information relevant to the sales process
    /// </summary>
    public class Order
    {
        public Guid Id { get; private set; }
        public string OrderNumber { get; private set; } = string.Empty;
        public decimal TotalAmount { get; private set; }
        public string CustomerEmail { get; private set; } = string.Empty;
        public string Status { get; private set; } = "Pending";

        // Private constructor → must be created via Factory
        private Order() { }

        public static Order Create(string orderNumber, decimal totalAmount, string customerEmail)
        {
            if (string.IsNullOrWhiteSpace(orderNumber))
                throw new ArgumentException("Order number is required.");

            if (totalAmount <= 0)
                throw new ArgumentException("Total amount must be positive.");

            return new Order
            {
                Id = Guid.NewGuid(),
                OrderNumber = orderNumber,
                TotalAmount = totalAmount,
                CustomerEmail = customerEmail,
                Status = "Pending"
            };
        }

        // Domain behavior methods (to be extended later)
        public void Confirm()
        {
            if (Status != "Pending")
                throw new InvalidOperationException("Only orders with Pending status can be confirmed.");

            Status = "Confirmed";
        }
    }
}
