# Inazuma API

This is an Inazuma API built using:

- **DDD Architecture (Domain-Driven Design)**
- **CQRS Design Pattern (Command Query Responsibility Segregation)**
- **SQL Injection Filtering and other validations**

## Endpoints

- **GET /item/{id}**  
  Retrieves a single item by ID (player name).

- **GET /items**  
  Retrieves all items sorted by a specific stat.

- **POST /item**  
  Adds a new item.

- **DELETE /item/{id}**  
  Deletes a single item by ID.

- **PUT /item/{id}**  
  Updates a single item by ID.

- **DELETE /item/{id}**  
  Deletes a single item by ID (Duplicate endpoint for emphasis).
