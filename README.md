

<div align="center">
   
# Project Management System API :construction_worker:
</div>
<hr>

![GitHub Logo](./image/pms.jpeg)
<div align="center">

## Overview :bulb:

This project is a Project Management System API built using ASP.NET Core Web API. It provides endpoints for managing institutions, their stages, statuses, counties, participants, levels, projects, project statuses, testimonials, donors, project reportings, programs, helpers, helper types, trainings, training levels, training categories, training types, budgets, funding types, partnerships, partner types, feedback, and users. This API allows CRUD operations on the following entities:
</div>

- AwardCenter
- Award Stages
- Award Statuses
- Counties /sub counties
- Participants
- Participants Levels
- Participants Status
- Participant Projects
- Levels
- Projects
- Project Statuses
- Testimonials
- Donors
- Project Reportings
- Programs
- Helpers
- Helper Types
- Trainings
- Training Levels
- Training Categories
- Training Types
- Budgets
- Funding Types
- Partnerships
- Partner Types
- Feedback
- Users

## Prerequisites :monocle_face:

Before you begin, ensure you have the following installed:
- **Visual Studio 2019/2022** (or later)
- **.NET 7.0 SDK** (or later)
- **SQL Server** (for database)

## Getting Started :rocket:

### Clone the Repository

```bash
git clone https://github.com/nickssilver/ProjectManagementAPIB.git
cd ProjectManagementAPIB
```

### Setting up the Project :alembic:

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

   dotnet ef migrations add <NameOfYourMigration>

   dotnet ef database update

   ```
#### Bonus
Incase of an error in migrations you can use this command to clear all tables in SQLServer and re-run

```
-- Step 1: Drop all foreign key constraints
EXEC sp_msforeachtable @command1='ALTER TABLE ? NOCHECK CONSTRAINT ALL'

-- Step 2: Drop all tables
EXEC sp_msforeachtable @command1='DROP TABLE ?'
```

### Running the Application :truck:

Press `F5` or click on the `Start` button in Visual Studio to run the application. The API will be hosted at `https://localhost:5001` or `http://localhost:5000`.

### API Endpoints :card_file_box:

<details>
  <summary>AwardCenter</summary>

- **GET /api/AwardCenter**: Retrieve all institutions
- **GET /api/AwardCenter/{id}**: Retrieve a specific award by ID
- **POST /api/AwardCenter**: Create a new award
- **PUT /api/AwardCenter/{id}**: Update an existing award by ID
- **DELETE /api/AwardCenter/{id}**: Delete an award by ID
</details>

<details>
  <summary>Award Stages</summary>

- **GET /api/AwardCenterStages**: Retrieve all award stages
- **GET /api/AwardCenterStages/{id}**: Retrieve a specific award stage by ID
- **POST /api/AwardCenterStages**: Create a new award stage
- **PUT /api/AwardCenterStages/{id}**: Update an existing award stage by ID
- **DELETE /api/AwardCenterStages/{id}**: Delete an award stage by ID
</details>
<details>
  <summary>Award Statuses</summary>

- **GET /api/AwardCenterStatus**: Retrieve all award statuses
- **GET /api/AwardCenterStatus/{id}**: Retrieve a specific award status by ID
- **POST /api/AwardCenterStatus**: Create a new award status
- **PUT /api/AwardCenterStatus/{id}**: Update an existing award status by ID
- **DELETE /api/AwardCenterStatus/{id}**: Delete an award status by ID
</details>
<details>
  <summary>Counties</summary>

- **GetCounties**: Retrieves a list of all counties.
- **GetCounty**: Retrieves a specific county by its ID.
- **GetSubCountiesByCountyId**: Retrieves all subcounties under a specific county.
- **PostCounty**: Adds a new county.
- **PutCounty**: Updates an existing county.
- **DeleteCounty**: Deletes a county by its ID.
- **CountyExists**: Checks if a county exists by its ID.
</details>
<details>
  <summary>Participants</summary>

- **GET /api/Participants**: Retrieve all participants
- **GET /api/Participants/{id}**: Retrieve a specific participant by ID
- **POST /api/Participants**: Create a new participant
- **PUT /api/Participants/{id}**: Update an existing participant by ID
- **DELETE /api/Participants/{id}**: Delete a participant by ID
</details>

<details>
  <summary>ParticipantAward </summary>

- GetParticipantAwards: Retrieves all participant awards.
- GetParticipantAward: Retrieves a participant award by its AwardID.
- PostParticipantAward: Creates a new participant award.
- PutParticipantAward: Updates an existing participant award by its AwardID.
- DeleteParticipantAward: Deletes a participant award by its AwardID.

  </details>

<details>
  <summary>ParticipantActivity</summary>

- GetParticipantProjects: Retrieves all participant projects.
- GetParticipantProject: Retrieves a participant project by its ParticipantID.
- PostParticipantProject: Creates a new participant project.
- PutParticipantProject: Updates an existing participant project by its ParticipantID.
- DeleteParticipantProject: Deletes a participant project by its ParticipantID.
  </details>

  
<details>
  <summary>ParticipantStatuses</summary>

- GetParticipantStatuses: Retrieves all participant statuses.
- GetParticipantStatus: Retrieves a participant status by its StatusID.
- PostParticipantStatus: Creates a new participant status.
- PutParticipantStatus: Updates an existing participant status by its StatusID.
- DeleteParticipantStatus: Deletes a participant status by its StatusID.
  </details>

<details>
  <summary>ParticipantLevels</summary>

- **GET /api/Levels**: Retrieve all levels
- **GET /api/Levels/{id}**: Retrieve a specific level by ID
- **POST /api/Levels**: Create a new level
- **PUT /api/Levels/{id}**: Update an existing level by ID
- **DELETE /api/Levels/{id}**: Delete a level by ID
</details>
<details>
  <summary>Projects</summary>

- **GET /api/Projects**: Retrieve all projects
- **GET /api/Projects/{id}**: Retrieve a specific project by ID
- **POST /api/Projects**: Create a new project
- **PUT /api/Projects/{id}**: Update an existing project by ID
- **DELETE /api/Projects/{id}**: Delete a project by ID
</details>
<details>
  <summary>Project Statuses</summary>

- **GET /api/ProjectStatuses**: Retrieve all project statuses
- **GET /api/ProjectStatuses/{id}**: Retrieve a specific project status by ID
- **POST /api/ProjectStatuses**: Create a new project status
- **PUT /api/ProjectStatuses/{id}**: Update an existing project status by ID
- **DELETE /api/ProjectStatuses/{id}**: Delete a project status by ID
</details>
<details>
  <summary>Testimonials</summary>

- **GET /api/Testimonials**: Retrieve all testimonials
- **GET /api/Testimonials/{id}**: Retrieve a specific testimonial by ID
- **POST /api/Testimonials**: Create a new testimonial
- **PUT /api/Testimonials/{id}**: Update an existing testimonial by ID
- **DELETE /api/Testimonials/{id}**: Delete a testimonial by ID
</details>
<details>
  <summary>Donors</summary>

- **GET /api/Donors**: Retrieve all donors
- **GET /api/Donors/{id}**: Retrieve a specific donor by ID
- **POST /api/Donors**: Create a new donor
- **PUT /api/Donors/{id}**: Update an existing donor by ID
- **DELETE /api/Donors/{id}**: Delete a donor by ID
</details>
<details>
  <summary>Project Reportings</summary>

- **GET /api/ProjectReportings**: Retrieve all project reportings
- **GET /api/ProjectReportings/{id}**: Retrieve a specific project reporting by ID
- **POST /api/ProjectReportings**: Create a new project reporting
- **PUT /api/ProjectReportings/{id}**: Update an existing project reporting by ID
- **DELETE /api/ProjectReportings/{id}**: Delete a project reporting by ID
</details>
<details>
  <summary>Programs</summary>

- **GET /api/Programs**: Retrieve all programs
- **GET /api/Programs/{id}**: Retrieve a specific program by ID
- **POST /api/Programs**: Create a new program
- **PUT /api/Programs/{id}**: Update an existing program by ID
- **DELETE /api/Programs/{id}**: Delete a program by ID
</details>
<details>
  <summary>Helpers</summary>

- **GET /api/Helpers**: Retrieve all helpers
- **GET /api/Helpers/{id}**: Retrieve a specific helper by ID
- **POST /api/Helpers**: Create a new helper
- **PUT /api/Helpers/{id}**: Update an existing helper by ID
- **DELETE /api/Helpers/{id}**: Delete a helper by ID
</details>
<details>
  <summary>Helper Types</summary>

- **GET /api/HelperTypes**: Retrieve all helper types
- **GET /api/HelperTypes/{id}**: Retrieve a specific helper type by ID
- **POST /api/HelperTypes**: Create a new helper type
- **PUT /api/HelperTypes/{id}**: Update an existing helper type by ID
- **DELETE /api/HelperTypes/{id}**: Delete a helper type by ID
</details>
<details>
  <summary>Trainings</summary>

- **GET /api/Trainings**: Retrieve all trainings
- **GET /api/Trainings/{id}**: Retrieve a specific training by ID
- **POST /api/Trainings**: Create a new training
- **PUT /api/Trainings/{id}**: Update an existing training by ID
- **DELETE /api/Trainings/{id}**: Delete a training by ID
</details>
<details>
  <summary>Training Levels</summary>

- **GET /api/TrainingLevels**: Retrieve all training levels
- **GET /api/TrainingLevels/{id}**: Retrieve a specific training level by ID
- **POST /api/TrainingLevels**: Create a new training level
- **PUT /api/TrainingLevels/{id}**: Update an existing training level by ID
- **DELETE /api/TrainingLevels/{id}**: Delete a training level by ID
</details>
<details>
  <summary>Training Categories</summary>

- **GET /api/TrainingCategories**: Retrieve all training categories
- **GET /api/TrainingCategories/{id}**: Retrieve a specific training category by ID
- **POST /api/TrainingCategories**: Create a new training category
- **PUT /api/TrainingCategories/{id}**: Update an existing training category by ID
- **DELETE /api/TrainingCategories/{id}**: Delete a training category by ID
</details>
<details>
  <summary>Training Types</summary>

- **GET /api/TrainingTypes**: Retrieve all training types
- **GET /api/TrainingTypes/{id}**: Retrieve a specific training type by ID
- **POST /api/TrainingTypes**: Create a new training type
- **PUT /api/TrainingTypes/{id}**: Update an existing training type by ID
- **DELETE /api/TrainingTypes/{id}**: Delete a training type by ID
</details>
<details>
  <summary>Budgets</summary>

- **GET /api/Budgets**: Retrieve all budgets
- **GET /api/Budgets/{id}**: Retrieve a specific budget by ID
- **POST /api/Budgets**: Create a new budget
- **PUT /api/Budgets/{id}**: Update an existing budget by ID
- **DELETE /api/Budgets/{id}**: Delete a budget by ID
</details>
<details>
  <summary>Funding Types</summary>

- **GET /api/FundingTypes**: Retrieve all funding types
- **GET /api/FundingTypes/{id}**: Retrieve a specific funding type by ID
- **POST /api/FundingTypes**: Create a new funding type
- **PUT /api/FundingTypes/{id}**: Update an existing funding type by ID
- **DELETE /api/FundingTypes/{id}**: Delete a funding type by ID
</details>
<details>
  <summary>Partnerships</summary>

- **GET /api/Partnerships**: Retrieve all partnerships
- **GET /api/Partnerships/{id}**: Retrieve a specific partnership by ID
- **POST /api/Partnerships**: Create a new partnership
- **PUT /api/Partnerships/{id}**: Update an existing partnership
- **DELETE /api/Partnerships/{id}**: Delete a partnership
</details>
<details>
  <summary>Partner Types</summary>

- **GET /api/PartnerTypes**: Retrieve all partner types
- **GET /api/PartnerTypes/{id}**: Retrieve a specific partner type by ID
- **POST /api/PartnerTypes**: Create a new partner type
- **PUT /api/PartnerTypes/{id}**: Update an existing partner type
- **DELETE /api/PartnerTypes/{id}**: Delete a partner type
</details>
<details>
  <summary>Feedback</summary>

- **GET /api/Feedback**: Retrieve all feedback entries
- **GET /api/Feedback/{id}**: Retrieve a specific feedback entry by ID
- **POST /api/Feedback**: Create a new feedback entry
- **PUT /api/Feedback/{id}**: Update an existing feedback entry by ID
- **DELETE /api/Feedback/{id}**: Delete a feedback entry by ID
</details>
<details>
  <summary>Users</summary>

- **GET /api/Users**: Retrieve all user entries
- **GET /api/Users/{username}**: Retrieve a specific user entry by username
- **POST /api/Users**: Create a new user entry
- **PUT /api/Users/{username}**: Update an existing user entry by username
- **DELETE /api/Users/{username}**: Delete a user entry by username
</details>



## Using Swagger :test_tube:

The API comes with Swagger integrated for easy testing and documentation. Once the application is running, navigate to `https://localhost:5001/swagger` or `http://localhost:5000/swagger` to access the Swagger UI.

## Additional Notes :memo:

- Ensure your SQL Server instance is running and accessible.
- You can modify the database connection settings in `appsettings.json` as per your setup.
- The migrations folder contains the initial migration for setting up the database schema.

## Contributing :busts_in_silhouette:

If you want to contribute to this project, please fork the repository and submit a pull request.

## License :page_facing_up:

This project is licensed under the [Optimum Computer Systems](https://optimumsystems.co.ke/). Use of this project outside or elsewhere is prohibited unless with our consent.

---


:: added endpoint::