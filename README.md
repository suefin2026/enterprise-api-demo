# Enterprise API Demo
A production-oriented enterprise backend built with .NET 10 and Clean Architecture.

## Overview
Production-oriented enterprise backend demonstrating modern .NET 10 development using Clean Architecture, dependency injection, CQRS-style query handlers, REST APIs, automated testing, and AI-ready architecture.

This project is part of my professional engineering portfolio while expanding into modern cloud-native and AI application development.


## Technology Stack
- .NET 10
- C#
- ASP.NET Core Web API
- Clean Architecture
- Dependency Injection
- OpenAPI
- xUnit
- Git
- Docker (environment ready)
- Postman
- VS Code


## Solution Architecture

EnterpriseApi.Api
        |
        +----> EnterpriseApi.Application
        |                |
        |                +----> EnterpriseApi.Domain
        |
        +----> EnterpriseApi.Infrastructure
                         |
                         +----> EnterpriseApi.Application
                         +----> EnterpriseApi.Domain


## Current Features
- .NET 10 Clean Architecture solution
- Domain, Application, Infrastructure, API, and test projects
- Product domain entity
- CQRS-style query handlers
- Repository abstraction
- In-memory product repository
- Dependency injection
- `GET /api/products`
- `GET /api/products/{id}`
- Application result model
- OpenAPI document generation
- xUnit domain tests
- NuGet vulnerability auditing

## Getting Started

### Prerequisites

- .NET 10 SDK
- Visual Studio Code
- Docker Desktop (optional for future sprints)
- Postman (recommended for API testing)

### Build
dotnet restore
dotnet build
dotnet test

## API Endpoints

| Method        | Endpoint              | Description |
|---------------|----------             |-------------|
| GET           | /api/products         | Returns all products |
| GET           | /api/products/{id}    | Returns a single product |

## Roadmap
### Sprint 1 ✅

- Clean Architecture
- Product API
- Repository Pattern
- OpenAPI
- Domain Tests

### Sprint 2

- EF Core
- SQL Server
- CRUD

### Sprint 3

- Authentication
- Validation
- Exception Handling

### Sprint 4

- Docker
- CI/CD
- React

### Sprint 5

- Semantic Kernel
- AI Features

## Goals
This repository is being developed incrementally to demonstrate modern enterprise backend engineering practices.

Planned capabilities include:

- Entity Framework Core
- SQL Server / PostgreSQL
- FluentValidation
- JWT Authentication
- Global Exception Middleware
- Docker
- GitHub Actions CI/CD
- React frontend
- Semantic Kernel
- AI-assisted APIs

## Author
Built and maintained by Susan Tripp

Senior Software Engineer (.NET / C# / AI)

GitHub Portfolio Project 2026

## Current Features



## Architecture

```text
EnterpriseApi.Api
        |
        +----> EnterpriseApi.Application
        |                |
        |                +----> EnterpriseApi.Domain
        |
        +----> EnterpriseApi.Infrastructure
                         |
                         +----> EnterpriseApi.Application
                         +----> EnterpriseApi.Domain
                         