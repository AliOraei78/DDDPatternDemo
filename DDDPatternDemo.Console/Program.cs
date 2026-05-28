/*
using DDDPatternDemo.Domain.Entities;

Console.WriteLine("Day 3 - Entity Demo");

try
{
    var customer = Customer.Create("Ali", "Rezaei", "ali.rezaei@example.com");

    Console.WriteLine($"Customer created: {customer.FirstName} {customer.LastName} - {customer.Email}");
    Console.WriteLine($"ID: {customer.Id}");
    Console.WriteLine($"Registration Date: {customer.RegistrationDate:yyyy-MM-dd HH:mm}");

    customer.UpdateName("Alireza", "Mohammadi");

    Console.WriteLine($"Updated Name: {customer.FirstName} {customer.LastName}");

    customer.Deactivate();

    Console.WriteLine($"Active Status: {customer.IsActive}");
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}

using DDDPatternDemo.Domain.Entities;
using DDDPatternDemo.Domain.ValueObjects;

Console.WriteLine("=== Day 4 - Value Object Demo ===\n");

var money1 = Money.Create(1250000, "IRR");
var money2 = Money.Create(750000, "IRR");
var total = money1.Add(money2);

Console.WriteLine($"Amount 1: {money1}");
Console.WriteLine($"Amount 2: {money2}");
Console.WriteLine($"Total: {total}");

var email = Email.Create("info@example.com");
Console.WriteLine($"Email: {email}");

var address = Address.Create("Enghelab Street", "Tehran", "1234567890");
Console.WriteLine($"Address: {address.Street}, {address.City}");

// Immutability and equality test
var moneyA = Money.Create(1000);
var moneyB = Money.Create(1000);

Console.WriteLine($"Are two Money objects with the same values equal? {moneyA.Equals(moneyB)}");

using DDDPatternDemo.Domain.Aggregates;
using DDDPatternDemo.Domain.ValueObjects;
using DDDPatternDemo.Domain.Entities;

Console.WriteLine("=== Day 5 - Aggregate & Aggregate Root Demo ===\n");

var customerEmail = Email.Create("customer@example.com");
var address = Address.Create("Enghelab Street", "Tehran", "12345");

var order = Order.Create("ORD-2026001", customerEmail, address);

var item1 = OrderItem.Create(Guid.NewGuid(), "Laptop", 1, Money.Create(25000000));
var item2 = OrderItem.Create(Guid.NewGuid(), "Mouse", 2, Money.Create(450000));

order.AddItem(item1);
order.AddItem(item2);

Console.WriteLine($"Order Number: {order.OrderNumber}");
Console.WriteLine($"Number of Items: {order.Items.Count}");
Console.WriteLine($"Total Amount: {order.TotalAmount}");
Console.WriteLine($"Status: {order.Status}");

order.Confirm();
Console.WriteLine($"After Confirmation - Status: {order.Status}");

using DDDPatternDemo.Domain.Aggregates;
using DDDPatternDemo.Domain.Interfaces;
using DDDPatternDemo.Domain.ValueObjects;
using DDDPatternDemo.Infrastructure.Repositories;

Console.WriteLine("=== Day 6 - Repository & Unit of Work Demo ===\n");

// Create Repository and UnitOfWork
IOrderRepository repository = new InMemoryOrderRepository();
IUnitOfWork unitOfWork = new InMemoryUnitOfWork(repository);

var email = Email.Create("test@example.com");
var order = Order.Create("ORD-2026006", email);

var item = OrderItem.Create(Guid.NewGuid(), "Headphones", 1, Money.Create(1250000));

order.AddItem(item);
order.Confirm();

await repository.AddAsync(order);
await unitOfWork.SaveChangesAsync();

Console.WriteLine($"Order with ID {order.Id} was successfully saved.");
Console.WriteLine($"Total Orders Count: {(await repository.GetAllAsync()).Count}");

using DDDPatternDemo.Domain.Aggregates;
using DDDPatternDemo.Domain.Interfaces;
using DDDPatternDemo.Domain.Services;
using DDDPatternDemo.Domain.ValueObjects;
using DDDPatternDemo.Infrastructure.Repositories;

Console.WriteLine("=== Day 7 - Domain Service Demo ===\n");

// Create dependencies
IOrderRepository repository = new InMemoryOrderRepository();
IUnitOfWork unitOfWork = new InMemoryUnitOfWork(repository);
IOrderProcessingService orderService = new OrderProcessingService(repository, unitOfWork);

// Create order
var email = Email.Create("customer@example.com");
var order = Order.Create("ORD-2026007", email);

var item1 = OrderItem.Create(Guid.NewGuid(), "Dell Laptop", 1, Money.Create(32000000));
order.AddItem(item1);

Console.WriteLine($"Total amount before processing: {order.TotalAmount}");

// Use Domain Service
await orderService.ProcessNewOrderAsync(order);

// Confirm order through the Service
await orderService.ConfirmOrderAsync(order.Id);

Console.WriteLine("Processing completed.");
*/

using DDDPatternDemo.Domain.Sales.Aggregates;
using DDDPatternDemo.Domain.Sales.Interfaces;
using DDDPatternDemo.Domain.Sales.Services;
using DDDPatternDemo.Domain.Sales.ValueObjects;
using DDDPatternDemo.Infrastructure.Repositories;

Console.WriteLine("=== Day 8 - Full DDD Implementation (Bounded Context: Sales) ===\n");

// Configure dependencies
IOrderRepository repository = new InMemoryOrderRepository();
IUnitOfWork unitOfWork = new InMemoryUnitOfWork(repository);
IOrderProcessingService orderService = new OrderProcessingService(repository, unitOfWork);

// Step 1: Create customer and address
var customerEmail = Email.Create("customer@example.com");
var shippingAddress = Address.Create("Valiasr Street", "Tehran", "1598765432");

// Step 2: Create Order Aggregate
var order = Order.Create("ORD-2026008", customerEmail, shippingAddress);

order.AddItem(OrderItem.Create(Guid.NewGuid(), "Lenovo Laptop", 1, Money.Create(28500000)));
order.AddItem(OrderItem.Create(Guid.NewGuid(), "Wireless Mouse", 2, Money.Create(650000)));

// Step 3: Process order via Domain Service
await orderService.ProcessNewOrderAsync(order);

// Step 4: Confirm order
await orderService.ConfirmOrderAsync(order.Id);

// Step 5: Retrieve order from Repository
var retrievedOrder = await repository.GetByIdAsync(order.Id);

Console.WriteLine("\n--- Retrieved Order ---");
Console.WriteLine($"Order Number: {retrievedOrder?.OrderNumber}");
Console.WriteLine($"Total Amount: {retrievedOrder?.TotalAmount}");
Console.WriteLine($"Number of Items: {retrievedOrder?.Items.Count}");
Console.WriteLine($"Status: {retrievedOrder?.Status}");

Console.WriteLine("\n✅ All DDD concepts successfully implemented and tested!");