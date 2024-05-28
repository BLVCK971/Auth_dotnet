# .NET 8 Tools

## ToDo

### V1

- Core Basis
    -  [x] Routing
    -  [ ] Custom Middleware
    -  [x] Filters and Attributes
- ORM
    -  [ ] Change Tracker API
    -  [ ] Lazy Loading, Eager Loading, Explicit Loading
- NoSql
    -  [ ] Azure Cosmos DB
    -  [ ] Redis
- Caching
    -  [ ] Output Caching
- Logging
    -  [ ] Microsoft Extensions Logging
    -  [ ] Serilog
- Messaging
    -  [ ] Azure Service Bus
    -  [ ] RabbitMQ
    -  [ ] MassTransit
- Testing
    -  [ ] xUnit
    - Mocking
        -  [ ] NSubstitute
        -  [ ] Moq
    - Assertion
        -  [ ] Fluent Assertions
    - Test Data Generators
        -  [ ] Bogus
    - Integration Testing
        -  [ ] WebApplication Factory
        -  [ ] Docker Testcontainers
    - Snapshot Testing
        -  [ ] Verify
    - Perfomance Testing
        -  [ ] K6
    - E2E Testing
        -  [ ] Playwright
- Streaming
    -  [ ] Kafka
- Real Time Communication
    -  [ ] SignalR
- API Documentation
    -  [x] Swagger
- API SDK Libraries
    -  [ ] Refit
    -  [ ] RestSharp
- Task Scheduling
    -  [ ] BackgroundService
    -  [ ] PeriodicTimer
- Monitoring and Telemetry
    -  [ ] Open Telemetry
    -  [ ] Prometheus
    -  [ ] Grafana
- Containerization
    -  [ ] Docker
- Orchestration
    -  [ ] Kubernetes
- Cloud
    -  [ ] Azure Functions
    -  [ ] Azure Storage
- CI CD
    -  [ ] GitHub Actions
- Others
    -  [ ] Polly
    -  [ ] Fluent Validation
    -  [ ] Humanizer Core
    -  [ ] Benchmark.NET
    -  [ ] Terraform

### V2
- Auth
    - Google, Apple, Facebook, Microsoft Auth
    - Custom Users
- A.I
    - H5 file loading
- Mapping
    - OpenStreetMap


## Prerequisites

- dotnet tool install --global dotnet-ef --version 8.*

## Packages 

### Built in

- Microsoft.AspNetCore.Identity

### To Install

- Microsoft.AspNetCore.Identity.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.Sqlite
- Microsoft.EntityFrameworkCore.Design

## Commands
### Add a new nuget package
- dotnet add package {{ Name of the Package }}
### Create a new Migration & Update Database
- dotnet ef migrations add {{Name of the migration}
- dotnet ef database update
### Sqlite the database
- sqlite3 {{name of the file}}
- .tables
- .schema main.*
