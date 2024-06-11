

# Project Management System API

## Overview

This project is a Project Management System API built using ASP.NET Core Web API. It provides endpoints for managing institutions, their stages, statuses, and counties. This API allows CRUD operations on the following entities:
- Institutions
- Institution Stages
- Institution Statuses
- Counties

## Prerequisites

Before you begin, ensure you have the following installed:
- **Visual Studio 2019/2022** (or later)
- **.NET 6.0 SDK** (or later)
- **SQL Server** (for database)

## Getting Started

### Clone the Repository

```bash
git clone https://github.com/nickssilver/ProjectManagementAPIB.git
cd ProjectManagementSystem
```

### Setting up the Project

1. **Open the Project in Visual Studio**

   Open Visual Studio and select `Open a project or solution`, then navigate to the folder where you cloned the repository and open the `ProjectManagementSystem.sln` file.

2. **Configure the Database Connection**

   Open the `appsettings.json` file in the project and configure the connection string for your SQL Server instance:

   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=ProjectManagementDB;Trusted_Connection=True;MultipleActiveResultSets=true"
     },
     "Logging": {
       "LogLevel": {
         "Default": "Information",
         "Microsoft": "Warning",
         "Microsoft.Hosting.Lifetime": "Information"
       }
     },
     "AllowedHosts": "*"
   }
   ```

3. **Apply Migrations**

   Open the **Package Manager Console** (Tools > NuGet Package Manager > Package Manager Console) and run the following commands to apply migrations and create the database:

   ```bash
   Add-Migration InitialCreate
   Update-Database
   ```

### Running the Application

Press `F5` or click on the `Start` button in Visual Studio to run the application. The API will be hosted at `https://localhost:5001` or `http://localhost:5000`.

### API Endpoints

#### Institutions

- **GET /api/Institutions**: Retrieve all institutions
- **GET /api/Institutions/{id}**: Retrieve a specific institution by ID
- **POST /api/Institutions**: Create a new institution
- **PUT /api/Institutions/{id}**: Update an existing institution by ID
- **DELETE /api/Institutions/{id}**: Delete an institution by ID

#### Institution Stages

- **GET /api/InstitutionStages**: Retrieve all institution stages
- **GET /api/InstitutionStages/{id}**: Retrieve a specific institution stage by ID
- **POST /api/InstitutionStages**: Create a new institution stage
- **PUT /api/InstitutionStages/{id}**: Update an existing institution stage by ID
- **DELETE /api/InstitutionStages/{id}**: Delete an institution stage by ID

#### Institution Statuses

- **GET /api/InstitutionStatuses**: Retrieve all institution statuses
- **GET /api/InstitutionStatuses/{id}**: Retrieve a specific institution status by ID
- **POST /api/InstitutionStatuses**: Create a new institution status
- **PUT /api/InstitutionStatuses/{id}**: Update an existing institution status by ID
- **DELETE /api/InstitutionStatuses/{id}**: Delete an institution status by ID

#### Counties

- **GET /api/Counties**: Retrieve all counties
- **GET /api/Counties/{id}**: Retrieve a specific county by ID
- **POST /api/Counties**: Create a new county
- **PUT /api/Counties/{id}**: Update an existing county by ID
- **DELETE /api/Counties/{id}**: Delete a county by ID

### Using Swagger

The API comes with Swagger integrated for easy testing and documentation. Once the application is running, navigate to `https://localhost:5001/swagger` or `http://localhost:5000/swagger` to access the Swagger UI.

## Additional Notes

- Ensure your SQL Server instance is running and accessible.
- You can modify the database connection settings in `appsettings.json` as per your setup.
- The migrations folder contains the initial migration for setting up the database schema.

## Contributing

If you want to contribute to this project, please fork the repository and submit a pull request.

## License

This project is licensed under the MIT License.

---

