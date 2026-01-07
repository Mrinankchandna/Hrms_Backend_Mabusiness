# HRMS Backend - Microservices Architecture

Enterprise-grade Human Resource Management System built with .NET 8 microservices architecture.

## 🏗️ Architecture Overview

```
Hrms/
├── Hrms.ApiGateway/          # Ocelot API Gateway (Port: 7000)
├── Hrms.AuthService/         # JWT Authentication (Port: 7001)
├── Hrms.EmployeeService/     # Employee Management (Port: 7002)
├── Hrms.EmployerService/     # Employer Management (Port: 7003)
├── Hrms.AttendanceService/   # Attendance Tracking (Port: 7004)
├── Hrms.PayrollService/      # Payroll Processing (Port: 7005)
├── Hrms.SharedKernel/        # Common Components
└── docker-compose.yml        # Container Orchestration
```

## ✅ Features Implemented

### 🔐 Authentication & Authorization
- JWT token-based authentication
- Role-based access control (Admin, Employer, Employee)
- Centralized auth service

### 🏛️ Clean Architecture
- **Domain Layer**: Entities, Value Objects
- **Application Layer**: DTOs, Interfaces, Services
- **Infrastructure Layer**: DbContext, Repositories
- **API Layer**: Controllers, Middleware

### 🌐 API Gateway
- Centralized routing with Ocelot
- Load balancing and service discovery
- CORS configuration

### 📦 Shared Components
- Common exceptions and responses
- Base entities with audit fields
- Authorization constants

## 🚀 Quick Start

### Prerequisites
- .NET 8 SDK
- Docker Desktop
- SQL Server (or use Docker)

### 1. Clone & Build
```bash
git clone https://github.com/Mrinankchandna/Hrms_Backend_Mabusiness.git
cd Hrms_Backend_Mabusiness
dotnet restore
dotnet build
```

### 2. Run with Docker
```bash
docker-compose up -d
```

### 3. Access Services
- **API Gateway**: https://localhost:7000
- **Auth Service**: https://localhost:7001
- **Employee Service**: https://localhost:7002
- **Employer Service**: https://localhost:7003
- **Attendance Service**: https://localhost:7004
- **Payroll Service**: https://localhost:7005

## 📋 API Endpoints

### Authentication
```
POST /api/auth/login
POST /api/auth/register
GET  /api/auth/validate
```

### Employees (via Gateway)
```
GET    /api/employees
POST   /api/employees
PUT    /api/employees/{id}
DELETE /api/employees/{id}
```

### Attendance (via Gateway)
```
GET    /api/attendance/employee/{employeeId}
POST   /api/attendance
PUT    /api/attendance/{id}
DELETE /api/attendance/{id}
```

## 🔧 Configuration

### JWT Settings (appsettings.json)
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

### Database Connection
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=Hrms{ServiceName};Trusted_Connection=true;TrustServerCertificate=true"
  }
}
```

## 🏢 Business Logic

### User Roles
- **Admin**: Full system access
- **Employer**: Manage employees, view reports
- **Employee**: View own data, mark attendance

### Attendance Flow
1. Employee checks in → Creates attendance record
2. Employee checks out → Updates record with checkout time
3. System calculates working hours automatically
4. Employer can view attendance reports

## 🧪 Testing

### Run Unit Tests
```bash
dotnet test
```

### API Testing
Use the provided `.http` files in each service for testing endpoints.

## 📊 Database Schema

Each microservice has its own database:
- **HrmsAuth**: Users, Roles
- **HrmsEmployee**: Employee profiles, departments
- **HrmsEmployer**: Company information, employer profiles
- **HrmsAttendance**: Check-in/out records, working hours
- **HrmsPayroll**: Salary calculations, pay slips

## 🔄 Development Workflow

1. **Add New Feature**: Create in appropriate service
2. **Update Shared Logic**: Modify SharedKernel
3. **API Changes**: Update Gateway routing if needed
4. **Database Changes**: Add migrations to specific service
5. **Testing**: Update integration tests

## 🚀 Deployment

### Production Deployment
1. Build Docker images
2. Push to container registry
3. Deploy to Kubernetes/Azure Container Apps
4. Configure environment variables
5. Set up monitoring and logging

### Environment Variables
```bash
ASPNETCORE_ENVIRONMENT=Production
ConnectionStrings__DefaultConnection=<production-db>
JwtSettings__SecretKey=<secure-key>
```

## 📈 Monitoring & Logging

- Structured logging with Serilog
- Health checks for each service
- Application Insights integration
- Distributed tracing support

## 🤝 Contributing

1. Fork the repository
2. Create feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit changes (`git commit -m 'Add AmazingFeature'`)
4. Push to branch (`git push origin feature/AmazingFeature`)
5. Open Pull Request

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 👥 Team

- **Lead Developer**: Mrinank Chandna
- **Architecture**: Microservices with Clean Architecture
- **Technology Stack**: .NET 8, Entity Framework Core, JWT, Ocelot, Docker