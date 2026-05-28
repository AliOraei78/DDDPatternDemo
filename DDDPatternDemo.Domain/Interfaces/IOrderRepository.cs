using DDDPatternDemo.Domain.Aggregates;

namespace DDDPatternDemo.Domain.Interfaces
{
    /// <summary>
    /// Repository Interface for the Order Aggregate
    /// Defined only in the Domain layer
    /// </summary>
    public interface IOrderRepository
    {
        Task<Order?> GetByIdAsync(Guid id);
        Task AddAsync(Order order);
        Task UpdateAsync(Order order);
        Task DeleteAsync(Guid id);
        Task<List<Order>> GetAllAsync();

        // In the future, domain-specific query methods can be added
        // For example:
        // Task<List<Order>> GetPendingOrdersAsync();
    }
}