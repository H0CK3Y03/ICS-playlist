# TODO
- [ ] DAL
    - [x] Remove Media, Series entities
    - [x] Create connection with Watchlists-Media
    - [x] Create connection with Media-Genre
    - [x] Generate db with new data
    - [ ] Test it?
- [ ] BL
    - [ ]  Fix mappers to match new db
    - [ ]  Fix facades to match new db
    - [ ]  Fix/add function for fetching ids for genres and watchlists (need for ui)
    - [ ]  Test it with app? (should work if the names of the functions, return data types and parameters are the same)
- [ ] APP
    - [ ] Fix media fetching from watchlists (need the function for fetching all movie id's to load them)
    - [ ] Add search bar (probably done)
    - [ ] Add function for adding movies to playlists

# Vued — Movie & Series Tracker

**Vued** is a cross-platform application for tracking and managing your movies and series. With Vued, you can create personalized playlists, rate watched content, apply filters for easy navigation, and add custom descriptions to entries.

## Features

- **Tracking**: Build personalized playlists for movies and series.
- **Rating**: Assign scores to watched entries.
- **Filtering**: Sort and search using custom filters.
- **Descriptions**: Add notes or summaries to entries.

## Requirements

### For UI Development (Windows Only)
The UI is only supported on Windows and **cannot be run on WSL or Linux**. While building is possible on Linux/WSL (with proper `.bashrc` aliases or a VM/emulator), the resulting `.exe` or `.dll` files will not run, even if transferred to Windows.

**Required Software**:
- [Windows App SDK Runtime](https://github.com/microsoft/WindowsAppSDK) (v1.5+, tested with v1.7)
- [WinUI 3](https://learn.microsoft.com/en-us/windows/apps/winui/winui3/)
- [.NET MAUI](https://dotnet.microsoft.com/en-us/apps/maui)

> **Note**: The `.csproj` and `launchSettings.json` files were adjusted based on:
> - [StackOverflow thread](https://stackoverflow.com/questions/78440201/when-i-run-a-default-maui-blazor-app-it-not-showing-output-whats-the-reason-for)
> - [.NET MAUI GitHub issue](https://github.com/dotnet/maui/issues/12080)

## Project Structure
```plaintext
├── src/Vued                # Source code
│   ├── Vued.App/           # UI and binding logic
│   │   ├── Views/          # UI components
│   │   ├── ViewModels/     # UI logic
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
├── docs/                   # Documentation and design
│   ├── wireframe/          # UI mockups and wireframes
```

### Directory Overview
- `src/Vued.App/`: UI components and logic.
- `src/Vued.BL/`: Business logic (facades, models, mappers).
- `src/Vued.DAL/`: Data access layer with EF Core and SQLite.
- `src/Vued.BL.Tests/`: Unit tests for business logic.
- `src/Vued.DAL.Tests/`: Unit tests for data access.
- `docs/`: Design assets, including ER diagram and UI wireframes.

## Setup and Build
### Clone the Repository
```shell
git clone https://github.com/H0CK3Y03/ICS-playlist
cd .\ICS-playlist\src\Vued\Vued.App\
```

### Build the UI (Windows Only)
Use PowerShell and replace `windows10.0.19041.0` with your platform if needed:
```powershell
dotnet clean
dotnet build -c Release -f net8.0-windows10.0.19041.0
dotnet run -c Debug -f net8.0-windows10.0.19041.0
```
> **Note**: Building/running in **Rider** or **Visual Studio** may fail. The `Vued.App` was developed and tested outside of IDEs.

### Build Individual Components
```bash
dotnet build src/Vued/Vued.DAL
dotnet build src/Vued/Vued.BL
```

### Run Tests
```bash
dotnet test src/Vued/Vued.BL.Tests
dotnet test src/Vued/Vued.DAL.Tests
```

### Build & Test the Entire Solution

```bash
dotnet restore Vued.sln
dotnet build Vued.sln
dotnet test Vued.sln
```

## Known Limitations
- The UI is only supported on Windows (not WSL or Linux).

## Contributing
Contributions are welcome! Please check the [Changelog](CHANGELOG.md) for known issues and submit pull requests via the [GitHub repository](https://github.com/H0CK3Y03/ICS-playlist).
