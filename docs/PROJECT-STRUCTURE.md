# HRMS Project Structure

## 📁 Professional Folder Organization

```
Hrms_Backend_Mabusiness/
├── 📁 src/                           # Source Code
│   ├── 📁 Gateway/                   # API Gateway
│   │   └── 📁 Hrms.ApiGateway/
│   ├── 📁 Services/                  # Microservices
│   │   ├── 📁 Hrms.AuthService/
│   │   ├── 📁 Hrms.EmployeeService/
│   │   ├── 📁 Hrms.EmployerService/
│   │   ├── 📁 Hrms.AttendanceService/
│   │   └── 📁 Hrms.PayrollService/
│   └── 📁 BuildingBlocks/            # Shared Components
│       └── 📁 Hrms.SharedKernel/
├── 📁 tests/                         # Test Projects
│   ├── 📁 Unit/                      # Unit Tests
│   ├── 📁 Integration/               # Integration Tests
│   └── 📁 E2E/                       # End-to-End Tests
├── 📁 docs/                          # Documentation
│   ├── 📁 api/                       # API Documentation
│   └── 📁 architecture/              # Architecture docs
├── 📄 Hrms.sln                       # Solution file
├── 📄 README.md                      # Project overview
├── 📄 DEVELOPMENT.md                 # Development guide
└── 📄 .gitignore                     # Git ignore rules
```

## 🏗️ Service Structure Template

Each microservice follows Clean Architecture:

```
Hrms.{ServiceName}/
├── 📁 Api/                           # Presentation Layer
│   ├── 📁 Controllers/               # REST Controllers
│   ├── 📁 Middleware/                # Custom middleware
│   └── 📁 Extensions/                # Service extensions
├── 📁 Application/                   # Application Layer
│   ├── 📁 DTOs/                      # Data Transfer Objects
│   ├── 📁 Interfaces/                # Service interfaces
│   ├── 📁 Services/                  # Business services
│   ├── 📁 Validators/                # Input validation
│   └── 📁 Mappings/                  # Object mappings
├── 📁 Domain/                        # Domain Layer
│   ├── 📁 Entities/                  # Domain entities
│   ├── 📁 Enums/                     # Enumerations
│   ├── 📁 ValueObjects/              # Value objects
│   └── 📁 Events/                    # Domain events
├── 📁 Infrastructure/                # Infrastructure Layer
│   ├── 📁 Data/                      # Database context
│   ├── 📁 Repositories/              # Data repositories
│   ├── 📁 Configurations/            # EF configurations
│   └── 📁 Services/                  # External services
├── 📁 Properties/                    # Project properties
├── 📄 appsettings.json               # Configuration
├── 📄 appsettings.Development.json   # Dev configuration
└── 📄 Program.cs                     # Application entry
```

## 🧱 Shared Kernel Structure

```
Hrms.SharedKernel/
├── 📁 Base/                          # Base classes
│   ├── 📄 BaseEntity.cs              # Base entity
│   └── 📄 AuditableEntity.cs         # Auditable entity
├── 📁 Exceptions/                    # Common exceptions
│   ├── 📄 NotFoundException.cs       # Not found exception
│   ├── 📄 BadRequestException.cs     # Bad request exception
│   └── 📄 BusinessException.cs       # Business exception
├── 📁 Responses/                     # API responses
│   └── 📄 ApiResponse.cs             # Standard response
├── 📁 Constants/                     # Application constants
│   ├── 📄 RoleConstants.cs           # User roles
│   └── 📄 PolicyConstants.cs         # Auth policies
└── 📁 Extensions/                    # Extension methods
    └── 📄 ServiceExtensions.cs       # Service extensions
```

## 🌐 API Gateway Structure

```
Hrms.ApiGateway/
├── 📁 Middleware/                    # Gateway middleware
│   ├── 📄 AuthenticationMiddleware.cs
│   └── 📄 LoggingMiddleware.cs
├── 📁 Configuration/                 # Gateway config
│   └── 📄 OcelotConfiguration.cs
├── 📄 ocelot.json                    # Ocelot routing
├── 📄 Program.cs                     # Gateway startup
└── 📄 Dockerfile                     # Container definition
```

## 🧪 Test Structure

```
tests/
├── 📁 Unit/                          # Unit Tests (70%)
│   ├── 📁 Hrms.AuthService.Tests/
│   │   ├── 📁 Services/
│   │   ├── 📁 Controllers/
│   │   └── 📁 Repositories/
│   └── 📁 Hrms.EmployeeService.Tests/
├── 📁 Integration/                   # Integration Tests (20%)
│   ├── 📁 Api.Tests/
│   └── 📁 Database.Tests/
└── 📁 E2E/                           # End-to-End Tests (10%)
    └── 📁 Scenarios/
```

## 🚀 Deployment Structure

```
# No deployment folder - using direct .NET deployment
# Services run independently using dotnet run
```

## 📚 Documentation Structure

```
docs/
├── 📁 api/                           # API Documentation
│   ├── 📄 auth-service.md            # Auth API docs
│   ├── 📄 employee-service.md        # Employee API docs
│   └── 📄 swagger.json               # OpenAPI spec
└── 📁 architecture/                  # Architecture docs
    ├── 📄 system-design.md           # System design
    ├── 📄 database-design.md         # Database design
    └── 📄 deployment-architecture.md # Deployment arch
```

## 🔧 Configuration Files

### Root Level Files
- `Hrms.sln` - Visual Studio solution
- `README.md` - Project overview and quick start
- `DEVELOPMENT.md` - Development and deployment guide
- `.gitignore` - Git ignore patterns
- `.editorconfig` - Code formatting rules
- `Directory.Build.props` - Common MSBuild properties

### Service Level Files
- `Program.cs` - Application entry point
- `appsettings.json` - Base configuration
- `appsettings.{Environment}.json` - Environment-specific config
- `{ServiceName}.csproj` - Project file

## 📋 Naming Conventions

### Projects
- `Hrms.{ServiceName}` - Microservices
- `Hrms.{ServiceName}.Tests` - Test projects
- `Hrms.SharedKernel` - Shared components

### Folders
- **PascalCase** for all folder names
- **Descriptive names** that indicate purpose
- **Consistent structure** across all services

### Files
- **PascalCase** for C# files
- **Descriptive names** that indicate functionality
- **Consistent suffixes** (Controller, Service, Repository, etc.)

## 🎯 Benefits of This Structure

### ✅ Professional Organization
- Clear separation of concerns
- Easy to navigate and understand
- Follows industry best practices

### ✅ Scalability
- Easy to add new services
- Consistent structure across services
- Shared components reduce duplication

### ✅ Maintainability
- Clean Architecture principles
- Testable code structure
- Clear dependencies

### ✅ Team Collaboration
- Standardized structure
- Clear ownership boundaries
- Easy onboarding for new developers

### ✅ DevOps Ready
- IIS deployment support
- Windows Service deployment
- CI/CD pipeline friendly

---

This structure provides a solid foundation for enterprise-grade microservices development and is ready for professional development teams.