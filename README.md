# README
## Animal Monitoring System
This project represents an interactive dashboard for viewing zoo activity, including Animal and Habitat information. It is a web application built on the ASP.NET Core framework using Blazor and Entity Framework Core.

## Prerequisites
* .NET SDK version 7.0 [[Download](https://dotnet.microsoft.com/en-us/download)]
* Docker [[Download](https://docs.docker.com/get-docker/)]
* (optional) Azure Data Studio [[Download](https://learn.microsoft.com/en-us/sql/azure-data-studio/download-azure-data-studio?view=sql-server-ver16)]
* (optional) Visual Studio 2022 [[Download](https://visualstudio.microsoft.com/downloads/)]

## Instructions
Extract the archive into any location. It should contain one solution, along with four project files located within each subfolder:

* MonitoringSystemBlazorServer.sln (Solution)
* MonitoringSystemBlazorServerApi.csproj (REST API)
* MonitoringSystemBlazorServer.csproj (Web Client)
* MonitoringSystemBlazorServerShared.csproj (Shared Library)
* MonitoringSystemBlazorServerTest.csproj (Unit Tests)

### 1. Setting up the SQL Server
1. Open a terminal and run the following commands:
2. `docker pull mcr.microsoft.com/azure-sql-edge `
3. `docker run -e “ACCEPT_EULA=1” -e “MSSQL_SA_PASSWORD=Password123” -e “MSSQL_PID=Developer” -e “MSSQL_USER=SA” -p 1433:1433 -d —name=sql mcr.microsoft.com/azure-sql-edge`

_Connecting to the Server :_
These commands will fetch and set up the latest Azure SQL Edge instance version, which will interface with the API Server program. You can use Docker Desktop to verify that this container is running. You can also use Azure Data Studio or Visual Studio to demonstrate the ability to connect to the Server via `localhost` with username `SA` and Password `Password123`. 

### 2. Running the REST API
1. Before running the API project, we need to perform an initial seed and migration of our data repositories. This requires the .NET Entity Framework Core tools, which you can download by running the command `dotnet tool install —global dotnet-ef`.
2. After installing the tools, update the database using the command `dotnet ef database update`.
3. From here, you can run the Server from the command line using `dotnet run` on the project, which provides access to a Swagger page that you can use to test and verify the API can communicate with the SQL server.

### 3. Running the Web Client
1. Open a new Terminal/Command Prompt session
2. Run the command `dotnet watch` to launch the application

### 4. Running Unit Tests
1. Navigate to the MonitoringSystemBlazorServerTest folder and run `dotnet test` 

## Visual Studio - Default Startup
By default, The Visual Studio solution will run both the API and the Blazor application together. If you wish to run them separately, change the project defaults or use the terminal.

## Navigating the Web Client
The Blazor Application (MonitoringSystemBlazorServer) includes the ability to navigate and manage a list of Animals and Habitats by adding new records, editing existing Animals/Habitats, or removing data. Overview information can be accessed from the left-side navigation menu, while detailed information can be viewed when selecting an individual Animal or Habitat.

## Troubleshooting Notes
Sometimes issues can occur with the build output, and the project files may need to be corrected using `dotnet clean` and `dotnet restore`. In addition, clearing your browser's cache before running `dotnet watch` can help correct display issues.

Other issues might include connectivity problems with either the SQL server or API, and the following are a few examples of troubleshooting areas to check first:

* Verify that the docker container is running
* Ensure that you can connect to the SQL server by reviewing the connection settings (localhost / user: SA / password: Password123)
* If the database cannot be found, then run the SQL query located in the API/SQL folder, followed by `dotnet ef database update`.
* Verify that the API program is running (via `dotnet run` or Visual Studio)
* Ensure that the Blazor application is running

## Credits
[How to install SQL Server on Mac](https://setapp.com/how-to/install-sql-server)
[How to Build and Secure Web Applications with Blazor](https://auth0.com/blog/what-is-blazor-tutorial-on-building-webapp-with-authentication/)
[GitHub - GillCleeren/BethanysPieShop: Sample code for Pluralsight course Building an Enterprise ASP.NET Core MVC app](https://github.com/GillCleeren/BethanysPieShop)