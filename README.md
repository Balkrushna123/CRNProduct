# CRNProduct API

A RESTful Web API built using ASP.NET Core 8 following Clean Architecture principles.

## Project Overview

CRNProduct API is designed to manage Products and Items using a scalable Clean Architecture approach. The project includes authentication, validation, repository pattern, unit testing, logging, and Docker support.

## Technologies Used

- ASP.NET Core 8 Web API
- C#
- Entity Framework Core
- SQL Server
- Clean Architecture
- Repository Pattern
- Unit of Work
- AutoMapper
- FluentValidation
- JWT Authentication
- Serilog
- Swagger
- xUnit
- Docker

## Project Structure

```text
CRNProduct.API
CRNProduct.Application
CRNProduct.Domain
CRNProduct.Infrastructure
CRNProduct.API.Tests
CRNProduct.Application.Tests
CRNProduct.Infrastructure.Tests
```

## Features

- Product CRUD Operations
- Item CRUD Operations
- JWT Authentication
- Refresh Token
- Repository Pattern
- Unit of Work
- Pagination
- Global Exception Handling
- AutoMapper
- FluentValidation
- API Versioning
- Response Compression
- Security Headers
- CORS
- Serilog Logging
- Unit Testing
- Integration Testing

## API Documentation

Swagger UI is available after running the project.

```
https://localhost:5001/swagger
```

## Database

- SQL Server
- Entity Framework Core
- Code First Approach

## High Level Architecture

*(Architecture diagram will be available in the Architecture folder.)*

## Docker

```bash
docker compose build
docker compose up
```

## Future Improvements

- Redis Caching
- CI/CD Pipeline
- Azure Deployment

## Author

**Balkrushna Ramhari Shinde**