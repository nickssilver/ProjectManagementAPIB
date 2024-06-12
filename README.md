

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


#### ParticipantsController


- `GET /api/Participants`: Retrieve all participants.
- `GET /api/Participants/{id}`: Retrieve a specific participant by ID.
- `POST /api/Participants`: Create a new participant.
- `PUT /api/Participants/{id}`: Update an existing participant by ID.
- `DELETE /api/Participants/{id}`: Delete a participant by ID.

#### LevelsController


- `GET /api/Levels`: Retrieve all levels.
- `GET /api/Levels/{id}`: Retrieve a specific level by ID.
- `POST /api/Levels`: Create a new level.
- `PUT /api/Levels/{id}`: Update an existing level by ID.
- `DELETE /api/Levels/{id}`: Delete a level by ID.

#### ProjectsController
This `ProjectsController` includes the following endpoints:

- `GET /api/Projects`: Retrieve all projects.
- `GET /api/Projects/{id}`: Retrieve a specific project by ID.
- `POST /api/Projects`: Create a new project.
- `PUT /api/Projects/{id}`: Update an existing project by ID.
- `DELETE /api/Projects/{id}`: Delete a project by ID.

#### ProjectStatusesController
This `ProjectStatusesController` includes the following endpoints:

- `GET /api/ProjectStatuses`: Retrieve all project statuses.
- `GET /api/ProjectStatuses/{id}`: Retrieve a specific project status by ID.
- `POST /api/ProjectStatuses`: Create a new project status.
- `PUT /api/ProjectStatuses/{id}`: Update an existing project status by ID.
- `DELETE /api/ProjectStatuses/{id}`: Delete a project status by ID.

#### TestimonialsController
This `TestimonialsController` includes the following endpoints:

- `GET /api/Testimonials`: Retrieve all testimonials.
- `GET /api/Testimonials/{id}`: Retrieve a specific testimonial by ID.
- `POST /api/Testimonials`: Create a new testimonial.
- `PUT /api/Testimonials/{id}`: Update an existing testimonial by ID.
- `DELETE /api/Testimonials/{id}`: Delete a testimonial by ID.

#### DonorsController
This `DonorsController` includes the following endpoints:

- `GET /api/Donors`: Retrieve all donors.
- `GET /api/Donors/{id}`: Retrieve a specific donor by ID.
- `POST /api/Donors`: Create a new donor.
- `PUT /api/Donors/{id}`: Update an existing donor by ID.
- `DELETE /api/Donors/{id}`: Delete a donor by ID.

#### ProjectReportingsController


- `GET /api/ProjectReportings`: Retrieve all project reportings.
- `GET /api/ProjectReportings/{id}`: Retrieve a specific project reporting by ID.
- `POST /api/ProjectReportings`: Create a new project reporting.
- `PUT /api/ProjectReportings/{id}`: Update an existing project reporting by ID.
- `DELETE /api/ProjectReportings/{id}`: Delete a project reporting by ID.

### ProgramsController

- `GET /api/Programs`: Retrieve all programs.
- `GET /api/Programs/{id}`: Retrieve a specific program by ID.
- `POST /api/Programs`: Create a new program.
- `PUT /api/Programs/{id}`: Update an existing program by ID.
- `DELETE /api/Programs/{id}`: Delete a program by ID.

#### HelpersController

- **GET** `/api/Helpers`: Retrieve all helpers.
- **GET** `/api/Helpers/{id}`: Retrieve a helper by ID.
- **POST** `/api/Helpers`: Create a new helper.
- **PUT** `/api/Helpers/{id}`: Update a helper by ID.
- **DELETE** `/api/Helpers/{id}`: Delete a helper by ID.

#### HelperTypesController

- **GET** `/api/HelperTypes`: Retrieve all helper types.
- **GET** `/api/HelperTypes/{id}`: Retrieve a helper type by ID.
- **POST** `/api/HelperTypes`: Create a new helper type.
- **PUT** `/api/HelperTypes/{id}`: Update a helper type by ID.
- **DELETE** `/api/HelperTypes/{id}`: Delete a helper type by ID.

#### Training Controller Endpoints

- **GET /api/Training**: Retrieve all trainings
- **GET /api/Training/{id}**: Retrieve a specific training by ID
- **POST /api/Training**: Create a new training
- **PUT /api/Training/{id}**: Update an existing training by ID
- **DELETE /api/Training/{id}**: Delete a training by ID

#### Training Level Controller Endpoints

- **GET /api/TrainingLevel**: Retrieve all training levels
- **GET /api/TrainingLevel/{id}**: Retrieve a specific training level by ID
- **POST /api/TrainingLevel**: Create a new training level
- **PUT /api/TrainingLevel/{id}**: Update an existing training level by ID
- **DELETE /api/TrainingLevel/{id}**: Delete a training level by ID

#### Training Category Controller Endpoints

- **GET /api/TrainingCategory**: Retrieve all training categories
- **GET /api/TrainingCategory/{id}**: Retrieve a specific training category by ID
- **POST /api/TrainingCategory**: Create a new training category
- **PUT /api/TrainingCategory/{id}**: Update an existing training category by ID
- **DELETE /api/TrainingCategory/{id}**: Delete a training category by ID

#### Training Type Controller Endpoints

- **GET /api/TrainingType**: Retrieve all training types
- **GET /api/TrainingType/{id}**: Retrieve a specific training type by ID
- **POST /api/TrainingType**: Create a new training type
- **PUT /api/TrainingType/{id}**: Update an existing training type by ID
- **DELETE /api/TrainingType/{id}**: Delete a training type by ID

### Budget Controller Endpoints

- **GET /api/Budget**: Retrieve all budgets.
- **GET /api/Budget/{id}**: Retrieve a specific budget by ID.
- **POST /api/Budget**: Create a new budget.
- **PUT /api/Budget/{id}**: Update an existing budget by ID.
- **DELETE /api/Budget/{id}**: Delete a budget by ID.

### FundingType Controller Endpoints

- **GET /api/FundingType**: Retrieve all funding types.
- **GET /api/FundingType/{id}**: Retrieve a specific funding type by ID.
- **POST /api/FundingType**: Create a new funding type.
- **PUT /api/FundingType/{id}**: Update an existing funding type by ID.
- **DELETE /api/FundingType/{id}**: Delete a funding type by ID.

### Partnership Endpoints

- **GET /api/Partnerships**: Retrieves all partnerships.
- **GET /api/Partnerships/{id}**: Retrieves a specific partnership by ID.
- **POST /api/Partnerships**: Creates a new partnership.
- **PUT /api/Partnerships/{id}**: Updates an existing partnership.
- **DELETE /api/Partnerships/{id}**: Deletes a partnership.

### PartnerType Endpoints

- **GET /api/PartnerTypes**: Retrieves all partner types.
- **GET /api/PartnerTypes/{id}**: Retrieves a specific partner type by ID.
- **POST /api/PartnerTypes**: Creates a new partner type.
- **PUT /api/PartnerTypes/{id}**: Updates an existing partner type.
- **DELETE /api/PartnerTypes/{id}**: Deletes a partner type.


### Feedback Controller Endpoints
- GET /api/Feedback: Retrieves all feedback entries.
- GET /api/Feedback/{id}: Retrieves a specific feedback entry by ID.
- POST /api/Feedback: Creates a new feedback entry.
- PUT /api/Feedback/{id}: Updates an existing feedback entry by ID.
- DELETE /api/Feedback/{id}: Deletes a feedback entry by ID.

### User Controller Endpoints
- GET /api/User: Retrieves all user entries.
- GET /api/User/{username}: Retrieves a specific user entry by username.
- POST /api/User: Creates a new user entry.
- PUT /api/User/{username}: Updates an existing user entry by username.
- DELETE /api/User/{username}: Deletes a user entry by username.


### Using Swagger

The API comes with Swagger integrated for easy testing and documentation. Once the application is running, navigate to `https://localhost:5001/swagger` or `http://localhost:5000/swagger` to access the Swagger UI.

## Additional Notes

- Ensure your SQL Server instance is running and accessible.
- You can modify the database connection settings in `appsettings.json` as per your setup.
- The migrations folder contains the initial migration for setting up the database schema.

## Contributing

If you want to contribute to this project, please fork the repository and submit a pull request.

## License

This project is licensed under the ``Optimum Computer Systems``. Use of this project outside or elsewhere is prohibited unless with our consent.

---

