# Full Stack Web Development with ASP.NET Core and Angular

## Description

In this intensive two-day workshop you'll get hands-on experience building a state-of-the-art 
interactive web application written in Angular 2 that communicates with a RESTful backend web 
service running on ASP.NET Core 1.

This allows you to leverage your C# skills to build a cross-platform Web API that can run on Linux 
inside a Docker container and deployed to Cloud services with a microservices architecture, 
while taking advantage of a modern web stack with support for integrated configuration and dependency 
injection systems. On the front end you'll use TypeScript to build a JavaScript using the latest 
features of ECMAScript 2015, as well as proposed future features such as decorators and async/await, 
while benefiting from static types, generics and interfaces to support features we've come to take 
for granted as developers, such as real-time syntax checking, code refactoring and intellisense.

## Course Outline

### Day 1: Building a RESTful Web API with ASP.NET Core 1 in C#

1. ASP.NET Core Architecture
	- The Cloud, containers, microservices
	- Bin-deployable runtimes
	- Modular base class libraries
	- Cross-platform, open-source
	- Middleware-based pipeline

2. Getting Started with ASP.NET Core
	- Hello World with .NET Core
	- Hosting with Kestrel
	- Dependency Injection
	- Configuration
	- Building a RESTful Web API

3. Design Patterns, Unit Testing
	- Repository pattern
	- Unit of Work pattern
	- Intro to xUnit, MOQ

4. Using Entity Framework Core
	- Choosing a provider
	- Code-based modeling
	- EF command-line tools
	- LINQ-based queries
	- Disconnected updates

### Day 2: Building a client front end with Angular 2 in TypeScript

1. Introduction to TypeScript
	- What TypeScript adds to JavaScript
	- Installing TypeScript
	- Linting and compiling TypeScript
	- Language Basics

2. TypeScript Development with Visual Studio Code
	- Folder-based projects
	- Navigation
	- Intellisense
	- Compiler options
	- Debugging

3. Angular 2 Architecture
	- Evolution of web application architectures
	- Model-View-ViewModel
	- Modules, templates, components
	- Services, metadata
	- Root module and component
	- Platform bootstrapper

4. Scaffolding Client Apps with Angular CLI
	- Adding styles with bootstrap.js
	- Generating models and components
	- Adding data binding to the template
	- Injecting services
	- Connecting to the Web API

## Machine Setup

*Students will be provided logins for remote labs, so there is no need to install software locally.  
However, the following instructions are provided in case you wish to use your own machine or  
would like to perform lab exercises after the class has concluded.*

1. Utilities
    - [Adobe Reader](https://get.adobe.com/reader/)
    - [Google Chrome Web Browser](https://www.google.com/chrome/)
    - [Postman Chrome Extension](https://www.getpostman.com/)
    - [Git for Windows](https://git-for-windows.github.io/)
    - [GitHub Desktop](https://desktop.github.com/)

2. [.NET Core 1.1 SDK](https://www.microsoft.com/net/download/core)
    - Current Version, 64 bit SDK

3. [Node.js](https://nodejs.org/en/)
    - Current Version

4. NPM global packages: `npm install -g`
    - typescript
    - gulp
    - yo
    - generator-aspnet
    - angular-cli

5. SQL Server
    - [SQL Server 2016 Express](https://www.microsoft.com/en-us/sql-server/sql-server-editions-express)
    - [SQL Server Management Studio](https://msdn.microsoft.com/en-us/library/mt238290.aspx)

6. NorthwindSlim database
    - Download and extract [zip file](http://bit.ly/northwindslim)
    - Use SSMS to create new database called NorthwindSlim
    - Run NorthwindSlim.sql in SSMS to create database objects with data

7. [Visual Studio Code](https://code.visualstudio.com/)
    - Install extensions: C#, TSLint, Angular 2 TypeScript Snippets (johnpapa)

8. Clone the [Setup Validation Repository](https://github.com/tonysneed/Setup.DotNetCore-EF-Angular)
    - For the .NET Core apps execute: `dotnet restore` followed by `dotnet run`
    - For the Angular-CLI app execute: `ng serve`
