using DDDPatternDemo.Domain.Sales.Exceptions;
using DDDPatternDemo.Domain.Sales.Aggregates;
using DDDPatternDemo.Domain.Sales.ValueObjects;
using Xunit;

namespace DDDPatternDemo.Tests.Sales
{
    public class OrderAggregateTests
    {
        [Fact]
        public void CreateOrder_ShouldInitializeWithValidData()
        {
            // Arrange
            var email = Email.Create("test@example.com");

            // Act
            var order = Order.Create("ORD-TEST-001", email);

            // Assert
            Assert.NotEqual(Guid.Empty, order.Id);
            Assert.Equal("ORD-TEST-001", order.OrderNumber);
            Assert.Equal("Pending", order.Status);
            Assert.Empty(order.Items);
        }

        [Fact]
        public void AddItem_ShouldRecalculateTotalAmount()
        {
            // Arrange
            var email = Email.Create("test@example.com");
            var order = Order.Create("ORD-TEST-002", email);
            var item = OrderItem.Create(Guid.NewGuid(), "Test Product", 2, Money.Create(500000));

            // Act
            order.AddItem(item);

            // Assert
            Assert.Single(order.Items);
            Assert.Equal(1000000, order.TotalAmount.Amount);
        }

        [Fact]
        public void ConfirmOrder_WithValidData_ShouldChangeStatus()
        {
            // Arrange
            var email = Email.Create("test@example.com");
            var order = Order.Create("ORD-TEST-003", email);
            var item = OrderItem.Create(Guid.NewGuid(), "Test Product", 1, Money.Create(1000000));
            order.AddItem(item);

            // Act
            order.Confirm();

            // Assert
            Assert.Equal("Confirmed", order.Status);
        }

        [Fact]
        public void ConfirmOrder_WithoutItems_ShouldThrowException()
        {
            // Arrange
            var email = Email.Create("test@example.com");
            var order = Order.Create("ORD-TEST-004", email);

            // Act & Assert
            Assert.Throws<DomainValidationException>(() => order.Confirm());
        }
    }
}