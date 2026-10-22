# IronCore Gym Management System

An ASP.NET Core MVC starter project using C#, Entity Framework Core and SQLite. It is designed to run locally on Windows without installing or configuring a separate database server.

## Features
- Dashboard with member, trainer, plan and payment totals
- Member CRUD, search, active/inactive status and membership-plan assignment
- Trainer CRUD with specialty and salary details
- Membership-plan CRUD with duration and price
- Payment recording and payment history
- Model validation and duplicate member-email checks
- Responsive Bootstrap interface with a custom gym-themed design
- SQLite database created automatically on first run

## Requirements
- .NET 8 SDK
- Visual Studio 2022 with the **ASP.NET and web development** workload, or the .NET CLI
- Internet access on first run if NuGet packages or Bootstrap/CDN assets need to be downloaded

## Run in Visual Studio
1. Extract the ZIP.
2. Open `GymManagementSystem.csproj` in Visual Studio 2022.
3. Allow NuGet packages to restore.
4. Press **Ctrl + F5** to run.
5. The browser should open the dashboard. The `gym_management.db` file is created in the app's working directory.

## Run from a terminal
Open a terminal in the extracted project folder and run:

```powershell
dotnet restore
dotnet run
```

Open the local URL printed in the terminal.

## Database
The app uses SQLite with this connection string in `appsettings.json`:

`Data Source=gym_management.db`

This avoids needing MySQL or SQL Server for the starter version. To reset your local demo database, stop the app and delete `gym_management.db`; it will be recreated on next run. This deletes your saved demo data.

## Suggested demo workflow
1. Create a few membership plans (for example, Monthly, Quarterly, Annual).
2. Add members and assign a plan.
3. Add trainers and their specialties.
4. Record payments for members.
5. Return to the dashboard to see updated totals.

## Important notes
- This is a starter/educational project, not a production-ready gym billing system.
- It has no authentication/roles yet; add authentication before using real member information.
- It records payments but does not process online payments.
- The app uses `EnsureCreated()` for simple first-run database setup. If you later change the model schema, use EF Core migrations or recreate the demo database.
- The Bootstrap and validation scripts are loaded from CDNs, so those assets require internet access. The app itself runs locally.
