# CSE325 Week 01 – Build .NET Applications with C#

This repository contains my work for Week 01 of CSE325: .NET Application Development with C#.

## Contents

* **ContosoPizza** – ASP.NET Core Web API created while completing the Microsoft Learn Web API module.
* **DotNetDebugging** – Work from the .NET debugging module.
* **DotNetDependencies** – Work from the .NET dependencies module.
* **mslearn-dotnet-files** – Work from the files and directories module, including a sales summary report.

## Web API

The ContosoPizza API was tested using the following requests:

| Operation       | Result         |
| --------------- | -------------- |
| GET All Pizzas  | 200 OK         |
| GET Pizza 1     | 200 OK         |
| POST Hawaii     | 201 Created    |
| PUT Hawaiian    | 204 No Content |
| GET Pizza 4     | 200 OK         |
| DELETE Hawaiian | 204 No Content |

An additional pizza was added to the initial `Pizzas` list:

```csharp
new Pizza { Id = 3, Name = "Pepperoni", IsGlutenFree = false }
```

The `nextId` value was updated to `4` so that newly created pizzas receive a unique ID.

## Sales Summary

The files/directories exercise was expanded to generate a `sales-summary.txt` report. The report includes the total sales across all sales files and the individual total for each sales file.

The report uses `StringBuilder` to construct the output and currency formatting to display the sales amounts.

## Microsoft Learn Modules

The repository contains work from the required Microsoft Learn modules:

1. Write your first C# code
2. Introduction to .NET
3. Create a new .NET project and work with dependencies
4. Interactively debug .NET apps with VS Code debugger
5. Work with files and directories in a .NET app
6. Create a web API with ASP.NET Core controllers
