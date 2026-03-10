# CentroEntrenamientoFD

Full-stack web application for managing training routines, microcycles and exercises.

## Tech Stack

### Backend

- .NET 9
- Clean Architecture
- Entity Framework Core
- SQL Server
- JWT Authentication
- Google OAuth integration
- Swagger API documentation

### Frontend

- React
- TypeScript
- Vite
- React Router v6
- Context API
- Axios
- CSS Modules

---

## Project Structure

``` 
CentroEntrenamientoFD/
│
├── backend/
│   ├── CentroEntrenamientoFD.API
│   ├── CentroEntrenamientoFD.Application
│   ├── CentroEntrenamientoFD.Domain
│   ├── CentroEntrenamientoFD.Infrastructure
│   └── CentroEntrenamientoFD.sln
│
├── frontend/
│   └── centro-entrenamiento-fd
│
└── README.md
```
---

## Architecture

### Backend
The backend follows a Clean Architecture approach:

- Domain
Contains the core business model.
Entities include: 
    - User
    - ClientRoutine
    - RoutineDay
    - Exercise
    - MicroSlot
    - RoutineExecution
    - ExercisesExecution
    - MicroExecution    
- Application
Responsible for: 
    - Use cases
    - DTOs
    - Interfaces
    - Application services
- Infrastructure
Implements:
    - Entity Framework repositories
    - Database access
    - External services
- API
Responsible for: 
    - Controllers
    - Authentication
    - Dependency injection
    - Swagger configuration

## Domain Model
The system separates routine templates from training executions.

### Routine Template
Defines the structure of a training program.

ClientRoutine
 ├── RoutineDay
 │     └── Exercise
 │           └── MicroSlot
 │
 └── MobilityExercise

### Training Execution
Stores historical performance data.

RoutineExecution
 └── ExerciseExecution
      └── MicroExecution

This allows tracking athlete progression across multiple weeks.

---
## API Endpoints
### Routine

Create a routine template and initial execution.

POST /api/routine

Get routine details.

GET /api/routine/{id}

## Execution

Register a new training session.

POST /api/execution

---
## Authentication

Authentication is handled using:

- JWT tokens
- BCrypt password hashing
- Google OAuth login

All protected endpoints require a valid JWT token.

---
## Swagger Documentation

Swagger UI is available at:

/swagger

Swagger includes:

- Endpoint documentation
- Request examples
- JWT authentication support

---
## Database

The backend uses Entity Framework Core with SQL Server.

Run migrations:

   dotnet ef database update

Create new migration:

   dotnet ef migrations add MigrationName

---

### Frontend
The frontend is built using React with TypeScript and follows a component-based structure.

Main characteristics:
- Functional components
- Context-based authentication state
- Protected routes
- Token storage in localStorage
- Modular styling using CSS Modules

---

## Running the Project Locally

### Backend
 1. Open **CentroEntrenamientoFD.sln** in Visual Studio
 2. Set **CentroEntrenamientoFD.API** as Startup Project
 3. Run the application

Default URL:
```
https://localhost:5001
```

Swagger:
```
/swagger
```

### Frontend

```
cd frontend/centro-entrenamiento-fd
npm install
npm run dev
```

Default URL:
```
http://localhost:5173
```
---

## Current Features
- User registration
- Login with email and password
- Google login
- JWT-based authentication
- Protected routes
- Training routine creation
- Exercise structure management
- Training execution tracking
- Clean Architecture backend

---

## Roadmap

### Training Features

- Routine dashboard
- Create routines
- Execution history visualization
- Athlete progress tracking
- Exercise catalog
- Weight progression analytics

### Security

- Refresh token implementation
- Token expiration handling
- Role-based authorization
- Session management

### DevOps

- Docker support
- Production environment configuration
- CI/CD pipeline
- Cloud deployment

---

## Status
Actively under development.