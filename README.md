Asp.Net Core Clean Architecture

# Prerequistes
1. .Net Core 3
2. EntityFramework Core 3
2. SQL Server

# Configuration
1. Configure database connection string in appsetting.json

# Run locally
1. dotnet restore
2. dotnet watch run

# Migrations
1. dotnet ef migrations add "Inital State"
2. dotnet ef database update

# Testing
1. Go to [Swagger UI] (https://localhost:5001/swagger/index.html)
