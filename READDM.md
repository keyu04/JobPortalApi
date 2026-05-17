# Job Portal API – ASP.NET Core Backend System

A scalable RESTful backend system built using ASP.NET Core for managing job postings, applications, and user access in a job portal platform.

## Highlights

- Built using ASP.NET Core and Entity Framework Core
- Implements JWT Authentication & Role-based Authorization
- Uses Clean Architecture with Controller → Service → Repository pattern
- Supports Pagination, Filtering, and Search functionality
- Includes Global Exception Handling Middleware
- Uses Structured Logging for better monitoring and debugging

---

## Features

### Authentication & Authorization
- User Registration & Login
- JWT-based Authentication
- Role-based Authorization (Admin/User)

### Job Management
- Create, Update, Delete Job Posts
- View Job Listings
- Search and Filter Jobs
- Pagination Support

### Job Applications
- Apply for Jobs
- Track Applications
- Manage Application Status

### Validation & Error Handling
- Input Validation using Data Annotations
- Centralized Global Exception Middleware
- Proper API Response Handling

---

## Architecture

This project follows a clean layered architecture:

Controller → Service → Repository → Database

### Layer Responsibilities

- **Controllers**
  - Handle HTTP requests and responses

- **Services**
  - Contain business logic and validations

- **Repositories**
  - Manage database operations and queries

- **Entity Framework Core**
  - Handles ORM and database interactions

---

## Technology Stack

### Backend
- ASP.NET Core Web API
- C#
- Entity Framework Core

### Database
- SQL Server

### Security
- JWT Authentication
- Role-based Authorization

### Tools & Concepts
- Repository Pattern
- Dependency Injection
- Clean Architecture
- Logging
- Middleware

---

## API Endpoints

### Job
| Method | Endpoint | Description |
|--------|----------|-------------|
| POST | `/JobPortal/Job` | Create new job post |
| PUT | `/JobPortal/Job` | Update job post |
| DELETE | `/JobPortal/Job/{id}` | Delete job by ID |
| GET | `/JobPortal/Job/Details` | Get all job listings |
| GET | `/JobPortal/Job/{id}/Detail` | Get job detail by ID |
| POST | `/JobPortal/Job/JobApply` | Apply for a job |
| GET | `/JobPortal/Job/JobApplicate` | Get job applications |

### User
| Method | Endpoint | Description |
|--------|----------|-------------|
| POST | `/User/UserLogin` | User login |
| POST | `/User/UserRegister` | Register new user |

---

## Getting Started

### Prerequisites

- .NET SDK 8.0 or higher
- SQL Server
- Visual Studio 2022 / VS Code

---

## Installation

### 1. Clone Repository

```bash
git clone https://github.com/keyu04/JobPortalApi.git
cd JobPortalApi
```

### 2. Restore Dependencies

```bash
dotnet restore
```

### 3. Configure Database

Update your connection string inside:

```
appsettings.json
```

### 4. Apply Migrations

```bash
dotnet ef database update
```

### 5. Run Application

```bash
dotnet run
```

---

## Future Improvements

- Docker Containerization
- Unit Testing
- CI/CD Pipeline Integration
- Swagger API Documentation Enhancement
- Refresh Token Authentication

---

## Author

Developed by Keyur Halpati
GitHub: https://github.com/keyu04