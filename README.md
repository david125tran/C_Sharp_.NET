# C_Sharp_.NET  
I am currently learning C# .NET Core 7 with MS SQL and Azure  
from the [Udemy Course](https://www.udemy.com/course/net-core-with-ms-sql-beginner-to-expert/)
  
### Section 02: C# Crash Course - Basics  
Here I go over variables, data structures, operators, conditionals, loops, methods, and scope.  
  
### Section 03: C# Crash Course - Intermediate  
Here I go over intermediate theory and connect to a SQL database in Azure Data Studios.  I start by creating a database schema in Azure Data Studios (Section03 - DotNetCourseDatabase.sql).
  
I make a Microsoft SQL database connection to write to the database and run queries using two different methods:  
1) The Dapper Method
2) The Microsoft Framework Entity Method

I also write SQL code to a text file (.txt).  
  
I then deal with JSON files (.json) using two different methods to serialize & deserialize:  
1) Newtonsofts Json.NET Method
2) Microsoft's System.Text.Json Method

I also deal with JSON files (.json) written in snakecase naming convention with two different methods:
1) Mapper Method
2) Tapping into JSON Property Attribute Method
  
Windows Powershell Terminal Package Install Requirements:  
1) dotnet add package Dapper
2) dotnet add package microsoft.data.sqlclient
3) dotnet add package microsoft.entityframeworkcore
4) dotnet add package microsoft.entityframeworkcore.sqlserver
5) dotnet add package microsoft.Extensions.Configuration
6) dotnet add package microsoft.Extensions.Json
7) dotnet restore
8) dotnet add package Newtonsoft.Json
9) dotnet add package Automapper



