# CentroEntrenamientoFD

Full-stack web application for managing training routines, microcycles and exercises.

## Tech Stack

### Backend

- .NET 8+
- Clean Architecture
- Entity Framework (Infrastructure layer)
- JWT Authentication
- Google OAuth integration

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
    - Core Entities
    - Business Rules
- Application
    - Use cases
    - DTOs
    - Interfaces
- Infrastructure
    - Repository implementations
    - Database access
    - External services
- API
    - Controllers
    - Dependency injection
    - Authentication configuration

### Frontend
The frontend is built using React with TypeScript and follows a component-based structure.

Main characteristics:
- Functional components
- Context-based authentication state
- Protected routes
- Token storage in localStorage
- Modular styling using CSS Modules

### Authentication
- BCrypt password hashing
- JWT token generation and validation
- Google OAuth login
- Secure token validation on backend
- Audience validation for external tokens

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
- Clean Architecture backend structure

---

## Roadmap

### Training Management

- Create routines
- Add microcycles
- Add exercises per day
- Exercise categorization
- Routine dashboard view

### Security

- Refresh token implementation
- Token expiration handling
- Role-based authorization
- API rate limiting

### DevOps

- Docker support
- Production environment configuration
- Backend deployment
- Frontend deployment
- CI/CD pipeline

---

## Status
Actively under development.