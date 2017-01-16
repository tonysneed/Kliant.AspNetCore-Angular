# Exercise: Getting Started with ASP.NET Core

## Prerequisites

*NOTE: These steps are listed so that you can conduct the exercises 
using your own hardware or after the course has concluded. You do not 
need to install these prerequisites if you are using the remote lab 
environment that has been provided.*

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

## Part A: Getting Started using .NET CLI

1. Open a command prompt at 02a_HelloDotNet/Before.

2. Create a directory, then change to the directory.

    ```
    mkdir HelloDotNet
    cd HelloDotNet
    ```

3. Use `dotnet` to initialize a new .NET Core console app.
    - Inspect the output.

    ```
    dotnet new
    ```

4. Restore NuGet packages.

    ```
    dotnet restore
    ```

5. Build the app, then inspect the output in bin/Debug.

    ```
    dotnet build
    ```

6. Run the app and inspect the output in the console.

    ```
    dotnet run
    ```

## Part B: Use Yeoman to create an empty web app

1. Open a command prompt at 02b_YeomanAspNet/Before.

2. Run the Yeoman AspNet generator.

    ```
    yo aspnet
    ```

3. Select **Empty Web Application**.
    - Enter **HelloAspNet** for the application name.
    - You will see a list of files created, followed by instructions 
      for restoring and running the application.

4. Change to the newly created application directory, 
   then restore packages.

   ```
   cd HelloAspNet
   dotnet restore
   ```

5. Run the application.
    - First the application will be built.

    ```
    dotnet run
    ```

6. Open a browser to http://localhost:5000.
    - You should see "Hello World!" displayed.
    - Press Ctlr+C to terminate the app.

7. Open the app in VS Code to inspect the files.
    - Inspect program.cs and startup.cs.

    ```
    code .
    ```

## Part C: Use Yeoman to create an empty web app

1. Open a command prompt at 02c_YeomanWebApi/Before.

2. Run the Yeoman AspNet generator.

    ```
    yo aspnet
    ```

3. Select **Web API Application**.
    - Enter **HelloWebApi** for the application name.
    - You will see a list of files created, followed by instructions 
      for restoring and running the application.

4. Change to the newly created application directory, 
   then restore packages.

   ```
   cd HelloWebApi
   dotnet restore
   ```

5. Run the application.
    - First the application will be built.

    ```
    dotnet run
    ```

6. Open a browser to http://localhost:5000/api/values.
    - You should see ["value1","value2"] displayed.
    - Press Ctlr+C to terminate the app.

7. Open the app in VS Code to inspect the files.
    - Inspect program.cs and startup.cs.

    ```
    code .
    ```

8. Have a look at the overload of `Get` that accepts an `id` parameter.
    - Notice that the `[HttpGet]` attribute has a template parameter with 
      a value of `"{id}"`
    - A request URI of http://localhost:5000/api/values/1 will map to this method.

9. Try debugging the app in VS Code.
    - Add the launch.json and task.json files when prompted.
    - Add "debugType": "portable" to "buildOptions" in project.json.
    - Run the app by entering `dotnet run` in the integrated terminal.
    - Set a breakpoint in the second Get method of ValuesController.
    - Select the Debug pane and the .NET Core Attach configuration.
    - Press Start and select the dotnet.exe process.
    - Browse to: http://localhost:5000/api/values/1
    - You shoud hit the breakpoint.  Press F5 to continue.
    - Select the integrated terminal and press Ctrl+C to end the process.
