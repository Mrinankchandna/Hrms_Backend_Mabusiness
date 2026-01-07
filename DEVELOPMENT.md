# HRMS Development & Deployment Guide

## 📋 Table of Contents
1. [Architecture Overview](#architecture-overview)
2. [Development Setup](#development-setup)
3. [Project Structure](#project-structure)
4. [Development Workflow](#development-workflow)
5. [Database Strategy](#database-strategy)
6. [API Design Standards](#api-design-standards)
7. [Authentication & Authorization](#authentication--authorization)
8. [Testing Strategy](#testing-strategy)
9. [Deployment Guide](#deployment-guide)
10. [Monitoring & Logging](#monitoring--logging)

## 🏗️ Architecture Overview

### Microservices Pattern
- **API Gateway**: Single entry point (Ocelot)
- **Auth Service**: JWT authentication & authorization
- **Employee Service**: Employee management
- **Employer Service**: Company & employer management
- **Attendance Service**: Time tracking & attendance
- **Payroll Service**: Salary calculations & payslips
- **Shared Kernel**: Common components

### Clean Architecture Layers
```
Service/
├── Api/                    # Controllers, Middleware
├── Application/            # DTOs, Interfaces, Services
├── Domain/                # Entities, Value Objects, Enums
└── Infrastructure/        # DbContext, Repositories, External APIs
```

## 🛠️ Development Setup

### Prerequisites
- .NET 8 SDK
- Visual Studio 2022 / VS Code
- SQL Server (LocalDB)
- Git

### Environment Setup
```bash
# Clone repository
git clone https://github.com/Mrinankchandna/Hrms_Backend_Mabusiness.git
cd Hrms_Backend_Mabusiness

# Restore packages
dotnet restore

# Build solution
dotnet build

# Run specific service
dotnet run --project Hrms.AuthService
```

## 📁 Project Structure

### Solution Level
```
Hrms_Backend_Mabusiness/
├── src/
│   ├── Gateway/
│   │   └── Hrms.ApiGateway/
│   ├── Services/
│   │   ├── Hrms.AuthService/
│   │   ├── Hrms.EmployeeService/
│   │   ├── Hrms.EmployerService/
│   │   ├── Hrms.AttendanceService/
│   │   └── Hrms.PayrollService/
│   └── BuildingBlocks/
│       └── Hrms.SharedKernel/
├── tests/
│   ├── Hrms.AuthService.Tests/
│   ├── Hrms.EmployeeService.Tests/
│   └── Integration.Tests/
├── docs/
│   ├── api/
│   └── architecture/
├── Hrms.sln
└── README.md
```

### Service Structure Template
```
Hrms.{ServiceName}/
├── Api/
│   ├── Controllers/
│   ├── Middleware/
│   └── Extensions/
├── Application/
│   ├── DTOs/
│   ├── Interfaces/
│   ├── Services/
│   ├── Validators/
│   └── Mappings/
├── Domain/
│   ├── Entities/
│   ├── Enums/
│   ├── ValueObjects/
│   └── Events/
├── Infrastructure/
│   ├── Data/
│   ├── Repositories/
│   ├── Configurations/
│   └── Services/
├── Properties/
├── appsettings.json
├── appsettings.Development.json
├── Program.cs

```

## 🔄 Development Workflow

### Branch Strategy
- `main`: Production-ready code
- `develop`: Integration branch
- `feature/*`: New features
- `hotfix/*`: Critical fixes
- `release/*`: Release preparation

### Coding Standards
- **Naming**: PascalCase for classes, camelCase for variables
- **Architecture**: Follow Clean Architecture principles
- **SOLID**: Apply SOLID principles
- **DRY**: Don't Repeat Yourself
- **KISS**: Keep It Simple, Stupid

### Code Review Process
1. Create feature branch
2. Implement feature with tests
3. Create pull request
4. Code review (minimum 1 approval)
5. Merge to develop
6. Deploy to staging
7. Merge to main for production

## 🗄️ Database Strategy

### Database Per Service
- **HrmsAuth**: Users, Roles, Permissions
- **HrmsEmployee**: Employee profiles, departments
- **HrmsEmployer**: Company info, employer profiles
- **HrmsAttendance**: Check-in/out records
- **HrmsPayroll**: Salary, deductions, payslips

### Migration Strategy
```bash
# Add migration
dotnet ef migrations add InitialCreate --project Hrms.{Service}

# Update database
dotnet ef database update --project Hrms.{Service}
```

### Connection Strings
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=Hrms{ServiceName};Trusted_Connection=true;MultipleActiveResultSets=true"
  }
}
```

## 🔌 API Design Standards

### RESTful Conventions
- `GET /api/employees` - Get all employees
- `GET /api/employees/{id}` - Get employee by ID
- `POST /api/employees` - Create employee
- `PUT /api/employees/{id}` - Update employee
- `DELETE /api/employees/{id}` - Delete employee

### Response Format
```json
{
  "success": true,
  "message": "Operation completed successfully",
  "data": { },
  "errors": []
}
```

### Status Codes
- `200 OK`: Success
- `201 Created`: Resource created
- `400 Bad Request`: Invalid request
- `401 Unauthorized`: Authentication required
- `403 Forbidden`: Access denied
- `404 Not Found`: Resource not found
- `500 Internal Server Error`: Server error

## 🔐 Authentication & Authorization

### JWT Configuration
```json
{
  "JwtSettings": {
    "SecretKey": "YourSuperSecretKeyHere123456789",
    "Issuer": "HrmsAuthService",
    "Audience": "HrmsClients",
    "ExpiryMinutes": 60
  }
}
```

### Role-Based Access
- **Admin**: Full system access
- **Employer**: Manage employees, view reports
- **Employee**: View own data, mark attendance

### Authorization Policies
```csharp
[Authorize(Roles = "Admin")]
[Authorize(Roles = "Admin,Employer")]
[Authorize(Policy = "EmployeeOrOwner")]
```

## 🧪 Testing Strategy

### Test Pyramid
- **Unit Tests**: 70% - Test individual components
- **Integration Tests**: 20% - Test service interactions
- **E2E Tests**: 10% - Test complete workflows

### Test Structure
```
Tests/
├── Unit/
│   ├── Services/
│   ├── Controllers/
│   └── Repositories/
├── Integration/
│   ├── Api/
│   └── Database/
└── E2E/
    └── Scenarios/
```

### Test Commands
```bash
# Run all tests
dotnet test

# Run specific test project
dotnet test Hrms.AuthService.Tests

# Generate coverage report
dotnet test --collect:"XPlat Code Coverage"
```

## 🚀 Deployment Guide

### Local Development
```bash
# Run API Gateway
dotnet run --project src/Gateway/Hrms.ApiGateway --urls "https://localhost:7000"

# Run Auth Service
dotnet run --project src/Services/Hrms.AuthService --urls "https://localhost:7001"

# Run Employee Service
dotnet run --project src/Services/Hrms.EmployeeService --urls "https://localhost:7002"
```

### Production Deployment
```bash
# Build solution
dotnet build --configuration Release

# Publish services
dotnet publish src/Gateway/Hrms.ApiGateway -c Release -o publish/gateway
dotnet publish src/Services/Hrms.AuthService -c Release -o publish/auth
```

### Environment Variables
```bash
# Development
ASPNETCORE_ENVIRONMENT=Development
ConnectionStrings__DefaultConnection=Server=(localdb)\\mssqllocaldb;Database=HrmsAuth;Trusted_Connection=true

# Production
ASPNETCORE_ENVIRONMENT=Production
ConnectionStrings__DefaultConnection=Server=prod-server;Database=HrmsAuth;User Id=hrms_user;Password=secure_password
JwtSettings__SecretKey=production_secret_key
```

## 📊 Monitoring & Logging

### Logging Strategy
- **Structured Logging**: Use Serilog
- **Log Levels**: Trace, Debug, Information, Warning, Error, Critical
- **Correlation IDs**: Track requests across services

### Health Checks
```csharp
builder.Services.AddHealthChecks()
    .AddDbContext<AuthDbContext>()
    .AddUrlGroup(new Uri("https://external-api.com/health"));
```

### Monitoring Tools
- **Application Insights**: Performance monitoring
- **Built-in Logging**: Console and file logging
- **Health Checks**: Service health monitoring

### Performance Metrics
- Response time
- Throughput (requests/second)
- Error rate
- Database connection pool usage
- Memory and CPU usage

## 🔧 Configuration Management

### appsettings.json Structure
```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information"
    }
  },
  "ConnectionStrings": {
    "DefaultConnection": "..."
  },
  "JwtSettings": {
    "SecretKey": "...",
    "Issuer": "...",
    "Audience": "...",
    "ExpiryMinutes": 60
  },
  "ExternalServices": {
    "EmailService": {
      "ApiKey": "...",
      "BaseUrl": "..."
    }
  }
}
```

### Environment-Specific Configuration
- `appsettings.json`: Base configuration
- `appsettings.Development.json`: Development overrides
- `appsettings.Staging.json`: Staging overrides
- `appsettings.Production.json`: Production overrides

## 📚 Documentation Standards

### Code Documentation
- XML comments for public APIs
- README.md for each service
- Architecture decision records (ADRs)
- API documentation with Swagger/OpenAPI

### API Documentation
```csharp
/// <summary>
/// Creates a new employee record
/// </summary>
/// <param name="dto">Employee creation data</param>
/// <returns>Created employee information</returns>
[HttpPost]
[ProducesResponseType(typeof(ApiResponse<EmployeeDto>), 201)]
[ProducesResponseType(typeof(ApiResponse<object>), 400)]
public async Task<IActionResult> CreateEmployee(CreateEmployeeDto dto)
```

## 🚨 Error Handling

### Global Exception Handling
- Custom middleware for exception handling
- Consistent error response format
- Logging of all exceptions
- User-friendly error messages

### Validation Strategy
- FluentValidation for complex validation
- Data annotations for simple validation
- Custom validators for business rules

## 🔄 CI/CD Pipeline

### GitHub Actions Workflow
```yaml
name: CI/CD Pipeline
on:
  push:
    branches: [main, develop]
  pull_request:
    branches: [main]

jobs:
  build-and-test:
    runs-on: ubuntu-latest
    steps:
      - uses: actions/checkout@v3
      - name: Setup .NET
        uses: actions/setup-dotnet@v3
        with:
          dotnet-version: '8.0.x'
      - name: Restore dependencies
        run: dotnet restore
      - name: Build
        run: dotnet build --no-restore
      - name: Test
        run: dotnet test --no-build --verbosity normal
```

## 📈 Performance Optimization

### Caching Strategy
- Redis for distributed caching
- In-memory caching for frequently accessed data
- Cache invalidation strategies

### Database Optimization
- Proper indexing
- Query optimization
- Connection pooling
- Read replicas for reporting

### API Optimization
- Response compression
- API versioning
- Rate limiting
- Pagination for large datasets

---

**Last Updated**: January 2025
**Version**: 1.0
**Maintainer**: Development Team