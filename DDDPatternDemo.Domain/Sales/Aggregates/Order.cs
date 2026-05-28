using DDDPatternDemo.Domain.Sales.Exceptions;
using DDDPatternDemo.Domain.Sales.ValueObjects;

namespace DDDPatternDemo.Domain.Sales.Aggregates
{
    public class Order
    {
        public Guid Id { get; private set; }
        public string OrderNumber { get; private set; } = string.Empty;
        public DateTime OrderDate { get; private set; }
        public Money TotalAmount { get; private set; } = Money.Create(0);
        public Email CustomerEmail { get; private set; }
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
                OrderNumber = orderNumber,
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
            var total = _items.Sum(i => i.GetTotalPrice().Amount);
            TotalAmount = Money.Create(total);
        }

        public void Confirm()
        {
            if (Status != "Pending")
                throw new InvalidOperationException("Only Pending orders can be confirmed.");

            if (_items.Count == 0)
                throw new DomainValidationException("An order without items cannot be confirmed.");

            if (TotalAmount.Amount <= 0)
                throw new DomainValidationException("Order total must be positive.");

            Status = "Confirmed";
        }
    }
}