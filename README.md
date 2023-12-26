# ASP.NET6 Core MVC Project:Company-Dashboard
## Table of Contents

- [Project Overview](#project-overview)
- [Project Structure](3-Tier)
- [Contact Information](Waleedhammad770@gmail.com)

## Project Overview
 The project is structured following the 3-Tier pattern,Used technologies: 
   -ASP.NET Core MVC
   -ASP.NET Core Identity
   -Entity Framework Core
   -SQL Server
   -Unit Of Work Design Pattern 
   -Generic Design Pattern
   -Repository Pattern
   -Email Sign in / Register Service 

## Project Structure

The project structure follows the standard ASP.NET Core 3-Tier conventions:
#Presentation Layer (PL)
  - **Controllers**: Contains controllers responsible for handling user requests.
  - **Views**: Consists of the Razor views that define the user interface.
  - **View Models**: Includes the data models used by the application.
  - **wwwroot**: Houses static files such as stylesheets, JavaScript, and images.
#Data Access Layer (DAL)
  - **Models**: Contains Classes that represent Entities
  - **Context** contains Classes that represent DataBases
#Business Logic Layer (BLL)
  -**Interfaces**: Contains Interfaces Of Repositories
  -**Repositories**:Contains the implementations of interfaces' methods

## Prerequisites

Before running this project, ensure you have the following prerequisites installed:

- [.NET SDK](https://dotnet.microsoft.com/download)

- ## Features
- 


## Configuration

The project requires no additional configuration out of the box. However, you can customize settings in the `appsettings.json` file if needed.

