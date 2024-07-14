# Microservices Architecture with ASP.NET Core

This project demonstrates the implementation of a microservices architecture using various technologies and best practices. The microservices are developed using ASP.NET Core, with different databases and communication patterns. Each microservice is containerized using Docker.

## Architectures, Patterns, Libraries, and Best Practices

### Architectures
- Layered Architecture
- Vertical Slice Architecture
- Domain-Driven Design (DDD)
- Clean Architecture

### Patterns & Principles
- SOLID, Dependency Injection (DI)
- Command Query Responsibility Segregation (CQRS)
- Mediator, Proxy, Decorator, Options Pattern
- Publish/Subscribe, Caching
- API Gateway

### Databases
- Transactional Document DB
- PostgreSQL
- Redis
- SQLite
- SQL Server

### Libraries
- Carter
- Marten
- MediatR
- Mapster
- MassTransit
- FluentValidation
- EF Core, Refit

### Containerization and Orchestration
- Dockerfiles and Docker Compose for containerization and orchestration

### API Gateway and Client
- Yarp API Gateway reverse proxy for gateway routing
- Shopping Web consuming APIs using the Refit library

### Communications
- Sync: gRPC
- Async: Publish/Subscribe pattern with MassTransit and RabbitMQ

## Microservices Implementation

### 1. Developing Catalog.API with MongoDB
- Setup and configuration of MongoDB
- Implementation of a simple CRUD microservice using ASP.NET Core and MongoDB
- Docker containerization of Catalog microservice

### 2. Developing Basket.API with Redis
- Introduction to Redis
- Implementing CRUD operations in Basket API using Redis
- Docker containerization of Basket microservice

### 3. Developing Discount.API with PostgreSQL
- PostgreSQL setup and integration
- Building CRUD microservices with ASP.NET Core and PostgreSQL
- Docker containerization of Discount microservice

### 4. Developing Discount.Grpc
- Understanding gRPC communication in microservices
- Implementing synchronous communication with gRPC

### 5. Consuming Discount Grpc Service from Basket Microservice
- Integrating Discount gRPC service into Basket microservice for price calculation

### 6. Developing Ordering Microservices
- Implementing Domain Driven Design (DDD) and CQRS
- Building a clean architecture for ordering microservices with SOLID principles

### 7. Microservices Async Communication with RabbitMQ
- Overview of RabbitMQ and MassTransit for event-driven architecture
- Implementing asynchronous communication between microservices

### 8. Building API Gateways with Yarp Reverse Proxy
- Introduction to API Gateway pattern
- Implementing routing and aggregation using Ocelot

### 9. API Gateway - Requests Aggregation Pattern
- Developing Shopping.Aggregator service for efficient backend system communication

### 10. Cross-Cutting Concerns - Observability and Resilience
- Implementing distributed logging, health monitoring, and fault tolerance with Polly

