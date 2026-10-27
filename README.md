# AdoPet

AdoPet is a study project built with C# and .NET to practice and reinforce good programming practices, architecture, refactoring, testing, and software design.

It was created as the foundation for Alura's "Best Practices in C#" learning path, with a focus on turning a simple project into a cleaner, more readable, and more maintainable solution aligned with professional development principles.

## Project goals

This repository serves as a hands-on lab for studying and applying:

- Clean Code and code readability
- Refactoring to improve structure and maintainability
- SOLID principles
- Design patterns
- Automated testing and testing best practices
- Code organization and separation of concerns
- Working with APIs and command-line clients

The idea is to evolve the code continuously, improving its quality without losing sight of hands-on learning.

## Course goals summary

The goal of this learning path is to learn how to apply best practices and refactoring techniques, understand what design patterns are, and write automated tests. The aim is to improve code readability, identify good opportunities for refactoring, and build more concise, robust, and maintainable solutions.

We also explore fundamental concepts such as:

- Clean code and easier maintenance
- The importance of tests as a safeguard against regressions
- SOLID principles as the foundation for flexible and scalable systems
- Design patterns as tools for solving common problems with proven solutions
- Best practices for organizing, configuring, and evolving software

## Solution overview

The project has two main parts:

1. An ASP.NET Core API for registering and listing pets
2. A console client for importing pet data from files

This architecture makes it possible to practice building services as well as consuming APIs and creating batch import workflows.

## Features

### Web API

The API provides endpoints for managing pets:

- `GET /pet/list` — lists registered pets
- `POST /pet/add` — registers a new pet

The application uses:

- ASP.NET Core
- Entity Framework Core with an in-memory database
- Swagger for API documentation
- Serilog for logging

### Console client

The console project lets you interact with the API through commands:

- `import` — imports pets from a file
- `list` — displays the pets registered in the API
- `show` — shows the contents of an input file
- `help` — displays help for the available commands

## How to run

### 1. Run the API

From the `Alura.Adopet.API` project directory, run:

```bash
dotnet run
```

The API will be available at:

- http://localhost:5057
- https://localhost:7136

While the application is running, Swagger is available at the root URL.

### 2. Run the console client

With the API running, use the following commands from the `Alura.Adopet.Console` project directory:

```bash
dotnet run import lista.csv
```
```bash
dotnet run list
```
```bash
dotnet run show lista.csv
```
```bash
dotnet run help
```

### 3. Run the tests

From the solution root, run:

```bash
dotnet test
```

## Project structure

- `Alura.Adopet.API` — web application with controllers, domain, repositories, services, and logging configuration
- `Alura.Adopet.Console` — command-line application for importing and querying data
- `Alura.Adopet.Tests` — automated tests for the console client, written with xUnit and Moq

## Important notes

- The project uses an in-memory database, so all data is lost when the application shuts down.
- The main focus is not just delivering features, but evolving the code with quality and continuous learning.
- This repository is ideal for practicing refactoring, design improvement, and applying best practices in a realistic scenario.