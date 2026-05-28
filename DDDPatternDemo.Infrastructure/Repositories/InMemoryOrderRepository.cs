using DDDPatternDemo.Domain.Aggregates;
using DDDPatternDemo.Domain.Interfaces;

namespace DDDPatternDemo.Infrastructure.Repositories
{
    public class InMemoryOrderRepository : IOrderRepository
    {
        private readonly List<Order> _orders = new();

        public Task<Order?> GetByIdAsync(Guid id)
        {
            var order = _orders.FirstOrDefault(o => o.Id == id);
            return Task.FromResult(order);
        }

        public Task AddAsync(Order order)
        {
            _orders.Add(order);
            return Task.CompletedTask;
        }

        public Task UpdateAsync(Order order)
        {
            var existing = _orders.FirstOrDefault(o => o.Id == order.Id);

            if (existing != null)
            {
                _orders.Remove(existing);

                // In a real-world scenario, updates are usually performed in place
                _orders.Add(order);
            }

            return Task.CompletedTask;
        }

        public Task DeleteAsync(Guid id)
        {
            var order = _orders.FirstOrDefault(o => o.Id == id);

            if (order != null)
                _orders.Remove(order);

            return Task.CompletedTask;
        }

        public Task<List<Order>> GetAllAsync()
        {
            return Task.FromResult(_orders.ToList());
        }
    }
}
