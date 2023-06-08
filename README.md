# Suite Career API and Analytics App

## Description

The Suite Career Web API and Analytics App is a web application built using ASP.NET Core MVC, EF Framework Core, and Bootstrap 5 and is designed to provide the owners of Suite Career, a recruitment service and interview practice app, with a comprehensive platform for data analysis and user insights as well as a REST API for the mobile app. The analytics app provides live analytics about interview sessions, questions, and app users, while the web API allows the mobile team to add, retrieve, update, and delete user, session, interview, and question data from the database. 

### Dependencies

* Microsoft SQL Server (Windows) OR SQLite (Mac)
* Entity Framework Core

### Executing Program

* After cloning the repository, create a new working branch based on develop
* Download and install dependencies
* Before building the application, make sure to uncomment the correct database connection string in the Program.cs file for your system (SQL Server for Windows, SQLite for Mac)
* The app is currently using dummy data from a local database until the Suite Career app has generated enough actual user data. To interact with the admin app and api using this data, please create an initial migration and update the database:
`Dotnet-ef migrations add initial`
`Dotnet-ef database update`

## Project Wiki

Review the wiki for additional [Project Details](https://github.com/Cascadia-Connections/suite-career-web-api/wiki)
