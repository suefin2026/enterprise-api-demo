# Enterprise API Demo

A production-oriented enterprise backend built with .NET 10 and Clean Architecture.

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
                         