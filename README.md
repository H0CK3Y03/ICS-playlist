# Vued — Movie & Series Tracker

**Vued** is a cross-platform application for tracking and managing movies and series. It allows users to:

- Create personalized playlists
- Rate watched content
- Apply filters for easier navigation
- Attach custom descriptions to entries

---

## ⚠️ IMPORTANT: Running the UI on Windows Only

> **Note**: The UI **does not run on WSL or Linux**.  
> You **must build and run it on Windows**.  
> While you can build it on Linux/WSL (with proper `.bashrc` aliases or via VM/emulator), you **cannot run the resulting `.exe` or `.dll` files**, even if moved to Windows afterward.

### Required on Windows

To successfully build and run the UI app, ensure you have installed:

- [Windows App SDK Runtime](https://github.com/microsoft/WindowsAppSDK) version 1.5+ (tested with 1.7)
- [WinUI 3](https://learn.microsoft.com/en-us/windows/apps/winui/winui3/)
- [.NET MAUI](https://dotnet.microsoft.com/en-us/apps/maui)

> The `.csproj` and `launchSettings.json` were modified based on:  
> - [This StackOverflow thread](https://stackoverflow.com/questions/78440201/when-i-run-a-default-maui-blazor-app-it-not-showing-output-whats-the-reason-for)  
> - [This official .NET MAUI GitHub issue](https://github.com/dotnet/maui/issues/12080)

---

## How to Build and Run the UI (PowerShell)

```powershell
git clone https://github.com/H0CK3Y03/ICS-playlist
cd .\ICS-playlist\src\Vued\Vued.App\
dotnet clean
dotnet build -c Release -f net8.0-windows10.0.19041.0
cd .\bin\Release\net8.0-windows10.0.19041.0\win10-x64
.\Vued.App.exe
```

> **Note**: If you're using **Rider** or **Visual Studio**, build/run may still fail.  
> The `Vued.App` was developed and tested **outside of IDEs**.

---

## Features

- **Tracking** – Add movies and series to personalized playlists.
- **Rating** – Assign scores for watched entries.
- **Filtering** – Sort and search via custom filters.
- **Descriptions** – Add notes or summaries to entries.

---

## Change Log

### v0.2 – 2025-04-13

#### Feedback Addressed

- Adopted recommended architecture (moved away from Clean Architecture).
- Fixed inconsistencies in ER diagram (`docs/ER diagram.png`).
- Cleaned up non-compliant code comments in `src/DAL/Entities`.

#### Implemented

- Developed `src/BL/` with facades and business logic models.
- Added unit tests under `BL.Tests/`.
- Configured `azure-pipelines.yml` to build and test `src/BL/` and `src/DAL/`.

#### Known Issues

- Full solution build via `project.sln` not yet supported (awaiting UI integration).
- Azure Pipelines not yet running due to missing parallelism access.

---

### v0.1 – 2025-03-09

#### Implemented

- Initialized `src/DAL/` with EF Core, SQLite DB, entities, and migrations.
- Added unit tests in `DAL.Tests/`.
- Set up `docs/` folder with ER diagram and UI wireframes.

#### Known Issues

- ERD in `docs/ER diagram.png` contained inconsistencies (resolved in v0.2).

---

## Project Structure

```plaintext
├── src/Vued                # Source code
│   ├── Vued.BL/            # Business logic layer
│   │   ├── Facades/        # Facade interfaces and implementations
│   │   ├── Mappers/        # Model-to-entity mappers
│   │   ├── Models/         # Business logic models
│   │   ├── Services/       # Business services
│   ├── Vued.DAL/           # Data access layer
│   │   ├── Entities/       # Database entities
│   │   ├── Factories/      # DB context factories
│   │   ├── Migrations/     # EF Core migrations
│   │   ├── Seeds/          # Seed data
│   ├── Vued.DAL.Tests/     # DAL unit tests
│   ├── Vued.BL.Tests/      # BL unit tests
├── docs/                   # Documentation & design
│   ├── wireframe/          # UI mockups and wireframes
```

### Directory Overview

- `src/Vued/Vued.BL/`: Business logic (facades, models, mappers).
- `src/Vued/Vued.DAL/`: Data access with EF Core.
- `src/Vued/Vued.BL.Tests/`: Unit tests for business logic.
- `src/Vued/Vued.DAL.Tests/`: Unit tests for data access.
- `docs/`: Design assets (ERD, wireframes, notes).

---

## Build & Test

### Build Individually

```bash
dotnet build src/Vued/Vued.DAL
dotnet build src/Vued/Vued.BL
```

### Run Tests

```bash
dotnet test src/Vued/Vued.BL.Tests
dotnet test src/Vued/Vued.DAL.Tests
```

### Build & Test Entire Solution

```bash
dotnet restore Vued.sln
dotnet build Vued.sln
dotnet test Vued.sln
```
