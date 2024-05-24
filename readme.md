# Authentication .NET 8 Template

## Prerequisites

- dotnet tool install --global dotnet-ef --version 8.*

## Packages 

### Built

- Microsoft.AspNetCore.Identity

### To Install

- Microsoft.AspNetCore.Identity.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.Sqlite
- Microsoft.EntityFrameworkCore.Design

## Commands
### Add a new nuget package
- dotnet add package {{ Name of the Package }}
### Create a new Migration
- dotnet ef migrations add {{Name of the migration}
### Update Database 
- dotnet ef database update
### Sqlite the database
- sqlite3 {{name of the file}}
- .tables
- .schema main.*
