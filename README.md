# DDD Pattern Demo

Educational sample project demonstrating **Domain-Driven Design (DDD)** patterns in .NET 8.

## Day 1: Initial project structure setup and introductory overview of DDD concepts.

- Created a new .NET 10 solution and added references to necessary sub-projects.

## Day 2 – Bounded Context

* The concept of **Bounded Context** and the importance of clearly defining domain model boundaries
* Separation using **Namespaces** within the Domain project
* Real-world example: two completely different models with the same name `Order`

  * `Sales.Order` → focused on sales and payment
  * `Shipping.Order` → focused on shipping and shipment tracking
* Simple illustration of a **Context Map** (relationship between the two contexts)

## Day 3 – Entity

* Definition of an Entity and its difference from a Value Object
* Implementing an Entity with identity (`Guid Id`)
* Using a Factory Method to create a valid instance
* Applying invariants and throwing Domain Exceptions
* Behavioral methods instead of public setters
* Implementing `Equals` and `GetHashCode` based on Identity
* Example: `Customer` class

## Day 4 – Value Object

* Definition of a Value Object and its fundamental difference from an Entity
* Implementation using `record` for natural immutability
* Applying business rules in the Factory Method
* Value Object composition (example: `Address`)
* Implementing equality based on values
* Practical examples: `Money`, `Email`, `Address`

## Day 5 – Aggregate and Aggregate Root

- Definition of Aggregate and Aggregate Root
- Designing Consistency Boundaries and Business Invariants
- Complete example: Order Aggregate including OrderItem and Value Objects
- Enforcing business rules inside the Aggregate Root (RecalculateTotal, Confirm)
- Preventing direct access to internal Entities

## Day 6 – Basic Repository and Unit of Work

- Defining the Repository Interface in the Domain layer
- Implementing an In-Memory Repository in the Infrastructure layer
- Introducing Unit of Work for transaction management
- Complete separation of the Domain from persistence technology
- Practical example using the Order Aggregate

## Day 7 – Domain Service

- Definition of a Domain Service as a stateless service
- Injecting Repository and UnitOfWork
- Implementing complex domain logic that spans multiple Aggregates
- Example: `OrderProcessingService` for processing and confirming orders
- Separating business logic from the Aggregate Root

## Day 8 – Full Sample Implementation (Bounded Context: Sales)

**Complete Order Management System sample** using all DDD patterns:

### Implemented concepts:

* **Bounded Context**: Sales
* **Value Objects**: Money, Email, Address
* **Entity**: Customer (extensible)
* **Aggregate + Aggregate Root**: Order + OrderItem
* **Repository**: IOrderRepository + InMemory Implementation
* **Unit of Work**: Transaction management
* **Domain Service**: OrderProcessingService

### Full flow:

1. Creation of Value Objects
2. Building the Aggregate (Order)
3. Adding items + automatic TotalAmount calculation
4. Processing via Domain Service
5. Order confirmation with Business Invariants enforced
6. Saving and retrieving through Repository

This project is ready to showcase on LinkedIn and GitHub.
