using DDDPatternDemo.Domain.Aggregates;
using DDDPatternDemo.Domain.Exceptions;
using DDDPatternDemo.Domain.Interfaces;
using DDDPatternDemo.Domain.ValueObjects;

namespace DDDPatternDemo.Domain.Services
{
    public class OrderProcessingService : IOrderProcessingService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IUnitOfWork _unitOfWork;

        public OrderProcessingService(IOrderRepository orderRepository, IUnitOfWork unitOfWork)
        {
            _orderRepository = orderRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task ProcessNewOrderAsync(Order order)
        {
            // Complex domain logic
            if (order.Items.Count == 0)
                throw new DomainValidationException("The order must contain at least one item.");

            // Discount calculation (example domain logic)
            if (order.TotalAmount.Amount > 5000000)
            {
                // Apply a 5% discount for orders above 5 million
                // In a real-world scenario, a DiscountService might be used
                Console.WriteLine("Special discount applied for large orders.");
            }

            await _orderRepository.AddAsync(order);
            await _unitOfWork.SaveChangesAsync();

            Console.WriteLine($"Order {order.OrderNumber} was processed successfully.");
        }

        public async Task ConfirmOrderAsync(Guid orderId)
        {
            var order = await _orderRepository.GetByIdAsync(orderId);

            if (order == null)
                throw new DomainValidationException("The requested order was not found.");

            order.Confirm(); // Call Aggregate Root behavior

            await _orderRepository.UpdateAsync(order);
            await _unitOfWork.SaveChangesAsync();

            Console.WriteLine($"Order {order.OrderNumber} has been confirmed.");
        }
    }
}