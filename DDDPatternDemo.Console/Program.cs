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