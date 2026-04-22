# MyApp_03 (SuperMarket)

Small ASP.NET Core MVC application (Razor views) named `SuperMarket`.

## Overview

This project is an ASP.NET Core MVC web application using Razor views. It implements a simple supermarket blog-like system with `Post` and `Category` entities and basic CRUD operations exposed via controllers and views.

Key components
- Data: `Data/AppDbContext.cs`
- Models: `Models/Post.cs`, `Models/Category.cs`
- Services: `Services/PostService.cs`, `Services/CategoryService.cs`
- Controllers: `Controllers/PostsController.cs`, `Controllers/CategoriesController.cs`
- Views: `Views/Posts/*`, `Views/Categories/*`, shared layouts under `Views/Shared`
- Configuration: `Program.cs`, `appsettings.json`

## Requirements

- .NET 10 SDK
- Entity Framework Core tools (if you want to run migrations): `dotnet tool install --global dotnet-ef` or use the global EF tools already available in Visual Studio.
- Visual Studio 2022/2026 or `dotnet` CLI

## Setup

1. Restore packages:

   `dotnet restore`

2. Update the database connection string in `MyApp_03/appsettings.json` if needed (look for the `DefaultConnection` entry).

3. Apply EF Core migrations (if migrations are not included):

   `dotnet ef migrations add InitialCreate -p MyApp_03 -s MyApp_03`

   `dotnet ef database update -p MyApp_03 -s MyApp_03`

   Alternatively use Visual Studio Package Manager Console with the project set to `MyApp_03`.

## Run

- From command line (repo root):

  `dotnet run --project MyApp_03`

- Or open the `MyApp_03` project in Visual Studio and run (F5).

## Notes

- Controllers rely on service layer abstractions (`IPostService`, `ICategoryService`) implemented in `Services`.
- TempData is used to show success/error messages in several actions (e.g. create post).
- Views are Razor `.cshtml` templates located in `Views`.

## Contributing

- Create a branch, open a pull request and describe the changes.

## License

This repository does not include a license file. Add one if you intend to publish or share the project publicly.
