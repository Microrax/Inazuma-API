# Inazuma API

**Inazuma API** is a backend application built with **.NET Core** and **C#**, designed to manage player data for an Inazuma-themed application. It provides full **CRUD** (Create, Read, Update, Delete) functionality and connects to a **SQL database** for data persistence.

## ⚙️ Technologies Used

- **.NET Core** (C#)
- **MYSQL**
- **Domain-Driven Design (DDD)**
- **CQRS (Command Query Responsibility Segregation)**
- **Input Validation & SQL Injection Filtering**

## ⚽ Features

- ➕ Add new players
- ✏️ Edit existing players
- ❌ Delete players
- 📋 View all players
- 🔍 Search player by ID or name
- 📊 Sort players by specific stats

## 📌 API Endpoints

| Method | Endpoint         | Description                     |
|--------|------------------|---------------------------------|
| GET    | `/item/{id}`     | Retrieve a player by ID         |
| GET    | `/items`         | Retrieve all players (sortable) |
| POST   | `/item`          | Add a new player                |
| PUT    | `/item/{id}`     | Update an existing player       |
| DELETE | `/item/{id}`     | Delete a player by ID           |

> Note: Endpoint names use "item" but represent "players" and id is "player name".

## 💾 Database

This API uses a **SQL-based database** to store all player data. The `DbContext` is configured to ensure proper mapping and validations.

## 🔐 Security

- Parameter sanitization to prevent SQL injection
- DTO validation for input safety
