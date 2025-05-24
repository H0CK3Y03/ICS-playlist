# CHANGELOG

## v0.3 - 2025-05-25
### Feedback Addressed
- Refactore and cleaned up architecture to match Cookbook
- Fixed and rehauled BL Layer
- Added Repository
### Implemented
- Added Application Layer
- Designed UI Layout
### Known Issues
- BL Layer is inconsistent and does not work as intended (Migration and Mappers).
- DAL Layer does not support Genre and Watchlist connections (Cannot be directly referenced, must be connected using joint tables).
- UI Layer does not support Playlist Creation/Visualization.

---

## v0.2 – 2025-04-13
### Feedback Addressed
- Adopted recommended architecture (moved away from Clean Architecture).
- Fixed inconsistencies in ER diagram (docs/ER diagram.png).
- Cleaned up non-compliant code comments in src/DAL/Entities.
### Implemented
- Developed src/BL/ with facades and business logic models.
- Added unit tests under BL.Tests/.
- Configured azure-pipelines.yml to build and test src/BL/ and src/DAL/.
### Known Issues
- Full solution build via project.sln not yet supported (awaiting UI integration).
- Azure Pipelines not yet running due to missing parallelism access.

---

## v0.1 – 2025-03-09
### Implemented
- Initialized src/DAL/ with EF Core, SQLite DB, entities, and migrations.
- Added unit tests in DAL.Tests/.
- Set up docs/ folder with ER diagram and UI wireframes.
### Known Issues
- ERD in docs/ER diagram.png contained inconsistencies (resolved in v0.2).
