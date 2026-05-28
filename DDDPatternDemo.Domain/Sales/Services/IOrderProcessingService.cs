using DDDPatternDemo.Domain.Sales.Aggregates;

namespace DDDPatternDemo.Domain.Sales.Services
{
    public interface IOrderProcessingService
    {
        Task ProcessNewOrderAsync(Order order);
        Task ConfirmOrderAsync(Guid orderId);
    }
}