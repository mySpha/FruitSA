# FruitSA API Setup

## 1. Build and Resolve NuGet Packages

Before running the application, ensure that you have the required dependencies by building and restoring NuGet packages. Open your solution in Visual Studio and follow these steps:

- Right-click on the solution in Solution Explorer.
- Select "Restore NuGet Packages."

This will download and install the necessary packages specified in your `*.csproj` files.

## 2. Update Connection String in appsettings

Navigate to the `appsettings.json` file in your startup project (`FruitSA.API`). Locate the `"ConnectionStrings"` section and update the connection string with your database details:

Example `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=FruitSADb;User Id=your_username;Password=your_password;"
  },
  // other settings...
}
```
## 3. Add Migration
To add a migration, follow these steps in Visual Studio:
Open the "Package Manager Console" (View -> Other Windows -> Package Manager Console).
Set the default project to your data project (`FruitSA.Data`):
```powershell
    PM> ADD-Migration YourMigrationName -ProjectName FruitSA.Data
```
Replace `YourMigrationName` with a meaningful name for your migration.

## 4. Database Update
After adding a migration, apply the changes to the database:
```powershell
PM> Update-Database -ProjectName FruitSA.Data
```
This command will apply the pending migrations and update your database schema.
Now, your FruitSA application should be set up with the necessary NuGet packages, connection string, and database schema.

## JWT Configuration

Configure JSON Web Token (JWT) settings in the `appsettings.json` file for securing your application.

Example `appsettings.json`:

```json
{
  "JwtSettings": {
    "Secret": "mydDMYgb1yv6W3v8kHT6LtAznxPdXpcOine3yfIr0Tg=",
    "ValidIssuer": "https://localhost:7264/",
    "ExpiresInMinutes": 30
  },
  // other settings...
}
```
### JWT Settings Configuration Details
##### Secret:
The secret key used for signing and verifying the JWT tokens. Replace
`mydDMYgb1yv6W3v8kHT6LtAznxPdXpcOine3yfIr0Tg=` with your secure secret key.
##### ValidIssuer: 
The issuer (or authority) of the JWT token. Replace `https://localhost:7264/` with the appropriate URL.
##### ExpiresInMinutes: 
The expiration time of the JWT token in minutes. Adjust the value based on your application's requirements.

