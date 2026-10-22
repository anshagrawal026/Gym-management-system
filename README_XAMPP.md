# IronCore Gym Pro — XAMPP MySQL

1. Extract this ZIP into a NEW empty directory (do not combine with the old SQLite project).
2. Start MySQL in XAMPP. Verify phpMyAdmin at http://localhost/phpmyadmin.
3. Edit `appsettings.json` to match your MySQL port (3306 or 3307) and password.
4. Open a terminal in the folder containing `GymManagementSystem.csproj`.
5. Run `dotnet restore`, then `dotnet run`.
6. Register an account and log in. The database and tables are created on first launch when the MySQL account has CREATE privileges.

Features: members, trainers, plans, payments, attendance, equipment, expenses, workout plans, fitness assessments, classes, leads and announcements.

Note: This is a local academic demonstration, not a production multi-tenant gym service. No old SQLite records are imported. Database auto-create is for a new database; it does not migrate existing schemas. Back up any existing database before upgrading.
