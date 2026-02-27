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

