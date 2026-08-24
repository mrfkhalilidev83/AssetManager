# AssetManager

A simple asset management application built with **C#**, **.NET 10**, **Windows Forms**, **Entity Framework Core**, and **SQL Server**.

The application allows users to register and log in, manage their assets, perform deposits and withdrawals, view transaction history, and delete their accounts.

## Architecture

The project follows a layered architecture:

```text
┌──────────────────────────────┐
│        AssetManager.UI       │
│      Windows Forms UI        │
└──────────────┬───────────────┘
               │
               ▼
┌──────────────────────────────┐
│   AssetManager.Application   │
│ Services / DTOs / Interfaces │
└──────────────┬───────────────┘
               │
               ▼
┌──────────────────────────────┐
│      AssetManager.Domain     │
│    Entities / Enums / Core   │
└──────────────────────────────┘
               ▲
               │
┌──────────────────────────────┐
│ AssetManager.Infrastructure  │
│ EF Core / DB / Repositories  │
└──────────────────────────────┘
```

## Project Structure

```text
AssetManager
│
├── AssetManager.Domain
│   ├── Dependencies
│   ├── Entities
│   └── Enums
│
├── AssetManager.Application
│   ├── DTOs
│   ├── Repositories
│   └── Services
│
├── AssetManager.Infrastructure
│   ├── Dependencies
│   ├── Data
│   ├── Migrations
│   ├── Repositories
│   └── Security
│
└── AssetManager.UI
    ├── Dependencies
    ├── Forms
    ├── appsettings.json
    └── Program.cs
```

## Features

### Authentication

* User registration
* Login using username or phone number
* Password hashing
* Password visibility toggle
* Logout
* Account deletion
* Duplicate username validation
* Duplicate phone number validation

### Asset Management

The application supports three asset types:

```text
Gold
Silver
Toman
```

Users can:

* View their current balances
* Deposit assets
* Withdraw assets
* View total asset value

### Total Asset Value

The total value is calculated using the following formula:

```text
Total Value =
    (Gold × 20,000,000)
    +
    (Silver × 40,000)
    +
    Toman
```

## Transactions

Every deposit and withdrawal is recorded as an `AssetTransaction`.

Each transaction contains:

```text
Id
UserId
AssetType
TransactionType
Amount
CreatedAt
```

Transaction history is displayed through a `DataGridView`.

Transactions are ordered by creation date, with the newest transaction displayed first.

## Validation

### Login

* Username/Phone cannot be empty
* Password cannot be empty
* Invalid credentials are handled

### Register

* Username cannot be empty
* Phone number must contain exactly 11 digits
* Phone number must start with `09`
* Password must contain:

  * At least one uppercase English letter
  * At least one lowercase English letter
  * At least one digit
  * At least one special character
* Confirm Password must match Password

### Deposit

* Amount must be numeric
* Amount must be greater than zero
* Asset type must be selected

### Withdrawal

* Amount must be numeric
* Amount must be greater than zero
* Asset type must be selected
* User must have sufficient balance

## Error Handling

Application errors are handled using exception handling at the UI level.

Errors are displayed using `MessageBox` with appropriate messages.

Example:

```text
Deposit Failed
Withdrawal Failed
Login Failed
Registration Failed
Delete Failed
```

## Loading

Async operations use a loading state to prevent duplicate operations.

During loading:

* Action buttons are disabled
* Cancel/navigation buttons are disabled where appropriate
* Cursor changes to `WaitCursor`

Loading is implemented for:

```text
Login
Register
Deposit
Withdrawal
```

## Database

The application uses **Entity Framework Core** for database access.

Main entities:

```text
User
Asset
AssetTransaction
```

Relationship:

```text
User
 │
 ├── 1 : 1 ── Asset
 │
 └── 1 : N ── AssetTransaction
```

Deleting a user uses cascade delete for the related `Asset` and `AssetTransaction` records.

## Repository Pattern

Database operations are separated from business logic through repositories.

Examples:

```text
IUserRepository
IAssetRepository
IAssetTransactionRepository
```

Infrastructure contains their implementations.

## Service Layer

Business logic is handled through application services.

Main services include:

```text
IUserService
IAssetService
IDepositService
IWithdrawalService
ITransactionService
```

The UI communicates with services instead of accessing the database directly.

## Security

Passwords are stored as hashes rather than plain text.

The UI also provides password visibility toggles for:

```text
Password
Confirm Password
```

Passwords are hidden by default.

## User Flow

```text
Application Start
       │
       ▼
     Login
       │
       ├──────── Register
       │             │
       │             ▼
       │          Asset
       │
       ▼
     Asset
       │
       ├── Deposit
       │
       ├── Withdrawal
       │
       ├── Transaction History
       │
       ├── Delete Account
       │
       └── Logout
              │
              ▼
            Login
```

## Technologies

* C#
* .NET 10
* Windows Forms
* Entity Framework Core
* SQL Server
* Dependency Injection
* Repository Pattern
* Service Layer
* DTO Pattern
* Password Hashing

## How to Run

1. Clone the repository.
2. Open the solution in Visual Studio.
3. Configure the database connection in `appsettings.json`.
4. Apply Entity Framework migrations.
5. Build the solution.
6. Run `AssetManager.UI`.

## Project Status

The main application functionality has been implemented:

```text
Login                ✅
Register             ✅
Asset Management     ✅
Deposit              ✅
Withdrawal           ✅
Total Asset Value    ✅
Transaction History  ✅
Logout               ✅
Delete Account       ✅
Loading States       ✅
Validation           ✅
Error Handling       ✅
```
