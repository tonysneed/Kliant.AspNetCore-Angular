# Exercise: Design Patterns and Unit Testing

## Part A: Design Patterns

1. Open a command prompt at 03a_DesignPatterns/Before/DesignPatterns.
    - Restore packages.
    - Launch the app.

    ```
    dotnet restore
    dotnet run
    ```

2. Open a browser to use the values controller
    - Browse to: http://localhost:5000/api/values
    - You should see: ["value1","value2"]

3. Open the app folder in VS Code.

    ```
    code .
    ```

4. Add a Repositories folder to the project.
    - Add a IValuesRepository.cs file to the Repositories folder.
    - Add a namespace: HelloWebApi.Repositories
    - Add a public interface: IValuesRepository
    - Add the following imports:

    ```csharp
    using System.Collections.Generic;
    using System.Threading.Tasks;
    ```

    - Add the following methods:

    ```csharp
    Task<IEnumerable<string>> GetValues();

    Task<string> GetValue(int id);

    Task CreateValue(int id, string value);

    Task UpdateValue(int id, string value);

    Task DeleteValue(int id);
    ```

5. Add a ValuesRepository class to the Repositories folder.
    - Add the namespace: HelloWebApi.Repositories
    - Add a private Latency const with a value of 500.
    - Add a field of type Dictionary<int, string>, 
      then initialize it to 5 values in the class ctor
    - Implement IValuesRepository, marking methods as async 
      and awaiting Task.Delay(Latency).

6. Refactor ValuesController to accept an IValuesRepository in 
   its constructor and use it to retrieve and update values.
    - Methods should return Tasks, be marked async, and await 
     repository calls.
    - Add an int id parameter where needed
    - Modify the HttpPost attribute with an id template

7. If you run the app and browse to api/values, you'll see an 
   exception: Unable to resolve service for type 'HelloWebApi.Repositories.IValuesRepository'.
   - This is because ASP.NET Core is unable to create IValuesRepository.
   - You need to register IValuesRepository in Startup.ConfigureServices.
   - The error should then go away and you should see: 
     ["value1","value2","value3","value4","value5"]

   ```csharp
   services.AddSingleton<IValuesRepository, ValuesRepository>();
   ```

8. Using Postman, you can test the other methods.
    - GET: http://localhost:5000/api/values/3
    - POST: http://localhost:5000/api/values/6
        + Headers: Content-Type application/json
        + Body: "value6"
    - PUT: http://localhost:5000/api/values/6
        + Headers: Content-Type application/json
        + Body: "value6a"
    - DELETE: http://localhost:5000/api/values/6

## Part B: Unit Testing

1. Open the 03b_UnitTesting/Before folder in VS Code.
    - Notice the global.json file and the src and test directories

2. Open a command prompt in the test directory.
    - Create a HelloWebApi.Tests directory and change to it.

    ```
    mkdir HelloWebApi.Tests
    cd HelloWebApi.Tests
    ```

3. Use DotNet CLI to create a new test project.

    ```
    dotnet new -t xunittest
    ```

4. Change to the newly created application directory, 
   then restore packages.
   - Run the test command.

   ```
   cd HelloWebApi.Tests
   dotnet restore
   dotnet test
   ```

5. Add a dependency to the web project.
    - Add to the dependencies section of project.json.

    ```json
    "Microsoft.DotNet.InternalAbstractions": "1.0.0",
    "HelloWebApi":{
        "target": "project"
    }
    ```

6. Open a browser to http://localhost:5000.
    - You should see "Hello World!" displayed.
    - Press Ctlr+C to terminate the app.

7. Open the app in VS Code to inspect the files.
    - Inspect program.cs and startup.cs.

    ```
    code .
    ```

8. Change the Test.cs file name to ValuesControllerTests.cs.
    - Change the namespace to HelloWebApi.Tests.
    - Change the class name to ValuesControllerTests
    - Replace the Test method with async GetShouldReturnValues.

    ```csharp
    public async void GetShouldReturnValues() 
    {
        var repository = new ValuesRepository();
        var controller = new ValuesController(repository);
        var result = await controller.Get();
        var values = result.ToArray();
        string[] expected = { "value1", "value2", "value3", "value4", "value5" };
        Assert.Collection(values, 
            value1 => Assert.Equal(expected[0], value1),
            value2 => Assert.Equal(expected[1], value2),
            value3 => Assert.Equal(expected[2], value3),
            value4 => Assert.Equal(expected[3], value4),
            value5 => Assert.Equal(expected[4], value5)
            );
    }
    ```

9. Replace new ValuesRepository with a mock implmentation.
    - Add dependency to moq (latest alpha) in project.json
    - Create mock values repo
    - Set up GetValues method

    ```csharp
    string[] expected = { "value1", "value2", "value3", "value4", "value5" };
    var valuesRepoMock = new Mock<IValuesRepository>();
    valuesRepoMock.Setup(x => x.GetValues())
        .ReturnsAsync(expected);
    // var repository = new ValuesRepository();
    var repository = valuesRepoMock.Object;
    ```

10. Optional: Try debugging the unit test.
    - Set a breakpoint in the test method.
    - Click the debug test link above the test method

11. Optional: Define a test Task in tasks.json

    ```json
        {
        "taskName": "test",
        "args": [
            "${workspaceRoot}\\test\\HelloWebApi.Tests"
        ],
        "isTestCommand": true
    }
    ```

    - You can define a keyboard shortcut for running tests

    ```json
        {
        "key": "ctrl+shift+t",
        "command": "workbench.action.tasks.test"
    }
    ```
    