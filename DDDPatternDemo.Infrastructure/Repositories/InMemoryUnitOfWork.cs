using DDDPatternDemo.Domain.Interfaces;

namespace DDDPatternDemo.Infrastructure.Repositories
{
    public class InMemoryUnitOfWork : IUnitOfWork
    {
        public IOrderRepository Orders { get; }

        public InMemoryUnitOfWork(IOrderRepository orderRepository)
        {
            Orders = orderRepository;
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return Task.FromResult(1);
        }

        public Task BeginTransactionAsync() => Task.CompletedTask;
        public Task CommitAsync() => Task.CompletedTask;
        public Task RollbackAsync() => Task.CompletedTask;

        public void Dispose() { }
    }
}