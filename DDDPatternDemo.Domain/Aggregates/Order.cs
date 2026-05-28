using DDDPatternDemo.Domain.Exceptions;
using DDDPatternDemo.Domain.ValueObjects;

namespace DDDPatternDemo.Domain.Aggregates
{
    /// <summary>
    /// Aggregate Root - Complete Order
    /// </summary>
    public class Order
    {
        public Guid Id { get; private set; }
        public string OrderNumber { get; private set; } = string.Empty;
        public DateTime OrderDate { get; private set; }
        public Money TotalAmount { get; private set; } = Money.Create(0);
        public Email CustomerEmail { get; private set; } = Email.Create("temp@example.com");
        public Address? ShippingAddress { get; private set; }
        public string Status { get; private set; } = "Pending";

        private readonly List<OrderItem> _items = new();
        public IReadOnlyList<OrderItem> Items => _items.AsReadOnly();

        private Order() { }

        public static Order Create(string orderNumber, Email customerEmail, Address? shippingAddress = null)
        {
            if (string.IsNullOrWhiteSpace(orderNumber))
                throw new DomainValidationException("Order number is required.");

            return new Order
            {
                Id = Guid.NewGuid(),
                OrderNumber = orderNumber.Trim(),
                OrderDate = DateTime.UtcNow,
                CustomerEmail = customerEmail,
                ShippingAddress = shippingAddress,
                TotalAmount = Money.Create(0)
            };
        }

        public void AddItem(OrderItem item)
        {
            _items.Add(item);
            RecalculateTotal();
        }

        public void RemoveItem(Guid itemId)
        {
            var item = _items.FirstOrDefault(i => i.Id == itemId);
            if (item != null)
            {
                _items.Remove(item);
                RecalculateTotal();
            }
        }

        private void RecalculateTotal()
        {
            decimal total = _items.Sum(i => i.GetTotalPrice().Amount);
            TotalAmount = Money.Create(total, TotalAmount.Currency);
        }

        public void Confirm()
        {
            if (Status != "Pending")
                throw new InvalidOperationException("Only orders with Pending status can be confirmed.");

            if (_items.Count == 0)
                throw new DomainValidationException("An order without items cannot be confirmed.");

            if (TotalAmount.Amount <= 0)
                throw new DomainValidationException("The total order amount must be positive.");

            Status = "Confirmed";
        }

        // Business Invariant: TotalAmount must always equal the sum of all item totals
    }
}