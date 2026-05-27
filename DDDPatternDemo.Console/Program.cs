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
*/

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