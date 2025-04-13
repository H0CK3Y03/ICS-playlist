# Introduction
The ICS-Playlist is an application designed for tracking and managing movies and series. It allows users to create personalized playlists, rate their watched content, apply filters for easy navigation, and attach custom descriptions to entries.

# Features
- **Tracking:** Add movies and series to a user-specific playlist.
- **Rating:** Assign scores to entries for personal evaluation.
- **Filtering:** Sort and search content using customizable filters.
- **Descriptions:** Attach notes or summaries to each entry.

# Change Log
This section highlights updates to the project focusing on feedback, implemented features, and known issues.

### 0.2 - 2025-04-13
- **Feedback Addressed**:
  - Adopted recommended architecture over clean architecture, per PR review.
  - Fixed inconsistencies in the ERD (`docs/ER diagram.png`), ensuring accurate database design.
  - Removed non-compliant code comments across `src/DAL/Entities` to adhere to clean code principles, as suggested in PR.
- **Implemented**:
  - Developed `src/BL/` with facades and models to handle business logic.
  - Added unit tests in `BL.Tests/` to validate facades.
  - Updated `azure-pipelines.yml` to automate builds and tests for `src/BL/` and `src/DAL/`.
- **Known Issues**:
  - Full solution build (`project.sln`) not supported yet, awaiting UI integration.
  - Automated builds in Azure Pipelines not enabled, as we’re still waiting for parallelism access.

### 0.1 - 2025-03-9
- **Feedback Addressed**:
  - None, as this was the initial version.
- **Implemented**:
  - Initialized `src/DAL/` with SQLite database, Entity Framework Core, entities, and migrations.
  - Created `DAL.Tests/` with unit tests to verify database operations.
  - Set up `docs/` with ER diagram and UI wireframes (`docs/wireframe/`).
- **Known Issues**:
  - ERD in `docs/ER diagram.png` had inconsistencies, addressed in version 0.2.

# Project Structure
The project is organized into directories for business logic, data access, tests, and documentation. Below is an overview of the key folders:
```
├── BL.Tests/           # Business logic unit tests
├── DAL.Tests/          # Data access layer unit tests
├── src/                # Source code
│   ├── BL/             # Business logic layer
│   │   ├── Facades/    # Facade interfaces and implementations
│   │   ├── Mappers/    # Model-to-entity mappers
│   │   ├── Models/     # Business logic models
│   │   ├── Services/   # Business services
│   ├── DAL/            # Data access layer
│   │   ├── Entities/   # Database entities
│   │   ├── Factories/  # Database context factories
│   │   ├── Migrations/ # EF Core migrations
│   │   ├── Seeds/      # Seed data
├── docs/               # Documentation and design assets
│   ├── wireframe/      # UI wireframes
```
## Directory Overview
- **`BL.Tests/`**: Contains unit tests for business logic, validating facades and services.
- **`DAL.Tests/`**: Includes unit tests for data access, ensuring database operations work correctly.
- **`src/BL/`**: Implements business logic, including facades, models, and mappers.
- **`src/DAL/`**: Manages data access with Entity Framework Core, including entities and migrations.
- **`docs/`**: Stores design assets, such as ER diagrams and UI wireframes.

# Build and Test
To compile the project components individually:

```bash
# Build the data access layer
dotnet build src/DAL

# Build the business logic layer
dotnet build src/BL
```
To run unit tests for each component:
```shell
# Test the business logic layer
dotnet test BL.Tests

# Test the data access layer
dotnet test DAL.Tests
```
