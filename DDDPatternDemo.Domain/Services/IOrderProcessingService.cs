using DDDPatternDemo.Domain.Aggregates;
using DDDPatternDemo.Domain.ValueObjects;

namespace DDDPatternDemo.Domain.Services
{
    public interface IOrderProcessingService
    {
        Task ProcessNewOrderAsync(Order order);
        Task ConfirmOrderAsync(Guid orderId);
    }
}