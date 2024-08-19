The following files were created to show you the basic operation of Fluent Infrastructure

/Context
	-DbContextLocal.cs
/Controllers
	-ForumController.cs
/Mapper
	-ForumMap.cs
/Models
	-Forum.cs
/Views
	/Forum
		-AddReturn.cshtml
		-New.cshtml
	/Shared
		-Index.cshtml
		
These files can be deleted without prejudice to your system once you have understood how to operate the Fluent Infrastructure

**** If you do not have the Global.asax file in the project root ***

1. Open Solution Explorer.
2. Right-click on the project.
3. Add New Item.
4. VB or C#
5. Web.
6. General.
7. Global Application Class.
8. Add the initialization call in your Global.asax:

protected void Application_Start(object sender, EventArgs e)
{
    AreaRegistration.RegisterAllAreas();
    RouteConfig.RegisterRoutes(RouteTable.Routes);
}

See more in: https://github.com/dn32/Fluent.Infrastructure/wiki

# Bookstore Application

## Overview
This ASP.NET MVC web application manages a bookstore inventory with features including user authentication, authorization, advanced search, and an API endpoint for CRUD operations.

## Prerequisites
Before you begin, ensure you have the following installed:
- [.NET SDK 6.0 or later](https://dotnet.microsoft.com/download)
- [Visual Studio 2022 or later](https://visualstudio.microsoft.com/downloads/) (recommended) or [Visual Studio Code](https://code.visualstudio.com/) with the C# extension
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) or [SQL Server Express](https://www.microsoft.com/en-us/sql-server/sql-server-editions)

## Getting Started

### Clone the Repository
First, clone the repository to your local machine:
```bash
git clone https://github.com/yourusername/bookstore-app.git
cd bookstore-app
