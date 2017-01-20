# Exercise: Using Visual Studio Code for TypeScript

## Part A: Navigation

*NOTE: If you get a TypeScript version mismatch warning in VS Code,  
follow these instructions to sync VS Code with global TypeScript version:  
[http://bit.ly/vs-code-ts-version](http://bit.ly/vs-code-ts-version)*

1. Launch Visual Studio Code.
    - From the File menu, select Open. 
      Then go to the Before/HelloVSCode directory and open placeholder.txt.
    - Notice, while you can view and edit the file contents, you will not be able to delete the file or add new files to the folder. 
      This is because you opened a file rather than a folder, as indicated in the Explorer pane. 
      If you click the Search, Git or Debug panes, you will see a similar message.

2. Select File menu and choose Open once again, but this time do not select a file. 
    - Clicking the Open button will now open the folder in which the file is contained. 
      The Explorer pane will now reveal the Before folder and its contents, 
      which include the placeholder.txt file
    - You may now right-click placeholder.txt in the Explorer pane to delete the file.

3. Close Visual Studio Code; then open a command prompt at the Before folder.
    - Enter `code`, followed by a space and a dot, which indicates the current directory. 
      Pressing ENTER will open Visual Studio Code at the current directory.

    ```
    code .
    ```

4. Press CTRL + ' to open the Integrated Terminal in VS Code.
    - Use NPM to initialize a new Node app. Add `-y` flag to bypass prompts.

    ```
    npm init -y
    ```

    - You will see a package.json file appear with the following content:

    ```json
    {
    "name": "HelloVSCode",
    "version": "1.0.0",
    "description": "",
    "main": "index.js",
    "scripts": {
        "test": "echo \"Error: no test specified\" && exit 1"
    },
    "keywords": [],
    "author": "",
    "license": "ISC"
    }
    ```

    - You'll see a warning for the project name, because it does not conform
      to the standard pattern.
      + Simply change it to lower case and insert hyphens in between each word: 
        `hello-vs-code`.

5. Add a src folder to the project, then add an index.ts file inside src.
    - Add some code to index.ts.

    ```js
    function hello(name: string): string {
        let message = `Hello ${name}`!;
        return message;
    }

    let message = hello("TypeScript");
    console.log(message);
    ```

    - Close all open files.

*NOTE: You may find it helpful to refer to slides titled “Navigation with Visual Studio Code,” 
which list various navigation commands and keyboard shortcuts.*
    
6. Press CMD + P (Mac), CTRL + P (Win/Linux); then type in, which should show the files beginning with “in”. 
    - The first item in the list should be index.ts, which you can open by pressing ENTER.

7. Press CMD + SHIFT + O (Mac), CTRL + SHIFT + O (Win/Linux) to show a list of symbols within index.ts.
    - Type a colon : in order to show the symbols by category.
    - Notice that, as you use the UP and DOWN arrows to select various items in the list, 
      VS Code will highlight the corresponding item in the editor.
    - You can also type a part of the symbol name to display matching items in the list.
    - Pressing ENTER selects a highlighted item and navigates you to the symbol.

8. Press CMD + G (Mac), CTRL + G (Win/Linux) to go to line 10 and place the cursor just before hello.
    - Press F12 to go to the hello function definition.
    - Then press CTRL + - (Mac), ALT +  (Win), CTRL + ALT + - (Linux) to go back to line 10.
    - Press SHIFT + CTRL + - (Mac), ALT +  (Win), CTRL + SHIFT + - (Linux) to go back to the hello function definition.
    - Then go back again to line 10.

9. Place the cursor just before or inside hello on line 10; then press SHIFT + F12 to find all definitions.
    - Note that the definitions window is actually “live,” which means you can edit code from the window. 
      The peek definition window, which you can display by pressing ALT + F12 (Mac/Win), 
      CTRL + SHIFT + F10 (Linux) operates in the same manner.
    - To demonstrate this, place the cursor somewhere in hello in the definitions window; 
      then press F2 to rename the method to greet.

## Part B: Intellisense

1. Open the HelloVSCode folder in the Before directory in VS Code.
    - In the src folder you will find an index.ts file that includes a skewer function. 
      + The purpose of the function is to accept an input string and return a value that is all 
        lowercase and inserts hyphens where each capital letter was located.
      + Currently the skewer function just returns the input text.

    ```js
    function skewer(input: string): string {
        return input;
    }
    ```

    - You can compile and run index.ts from the command line.

    ```js
    cd src
    tsc index.ts
    node index.js
    ```

    - You should see the following output:

    ```
    EnableJavacriptIntellisense
    ```

    - Rather than re-invent the wheel, we should instead leverage an open-source JavaScript library that provides 
      the functionality we want: lodash is one such library.

*NOTE: To find out more about lodash, check out the library home page: (http://lodash.com)[http://lodash.com].*

2. To use lodash in a JavaScript application, you will need to import it using Node Package Manager.
    - At the command line, enter the following:

    ```
    npm install lodash --save
    ```

    - Installing lodash will add a node_modules directory that will contain installed JavaScript libraries.
    - The --save option will add lodash as a dependency in the package.json file at the project root. 
    - The reason for this is so that the project may be checked into source control without including dependencies, 
      which can be installed locally by running: npm install. This reduces the size of the source code repository.

3.	At the top of index.ts add an import statement for lodash.

    ```js
    import * as _ from "lodash";
    ```

4. Add the following line of code to the skewer function:

    ```js
    let output = _.
    ```

    - When typing the dot following the underscore, you would like to get intellisense listing 
      all the available functions in lodash.
    - Pressing CTRL + SPACE is supposed to trigger intellisense, but it does not. 
      The reason for this is that TypeScript needs type declarations for lodash in order 
      to display function names and parameter help.

5. To enable intellisense for lodash, you need to add its type declarations package using NPM.
    - From the command line, run the following:

    ```
    npm install @types/lodash --save-dev
    ```

    - Backspace over the `.` in the previous line of code and press `.` again.
        + This time you should see all the available lodash functions.

6. After _. add a call to the kebabCase function.
    - Notice that you also get a description of the function and its parameters.
    - Pass input to the kebabCase function, and return output from the skewer function, 
      which should now resemble the following:

    ```js
    function skewer(input: string): string {
        let output = _.kebabCase(input);
        return output;
    }
    ```

7. Compile and run index.ts again from the command line.

    ```
    cd src
    tsc index.ts
    node index.js
    ```

    - You should now see the following output:

    ```
    enable-javacript-intellisense
    ```

## Part C: Compiling TypeScript Projects

1. Continue where you left off in Part B, or open HelloVSCode in the Before directory of Part C.
    - Press CMD + SHIFT + B (Mac), CTRL + SHIFT + B (Win/Linux).
        + You should see a message stating that no task runner has been configured and a 
          button allowing you to configure the task runner.

    - Click the Configure Task Runner button.
        + Then select the option for compiling a TypeScript project: TypeScript - tsconfig.json.

    - You should see a tasks.json file placed in a .vscode folder.
        + The contents of the file should resemble the following:

    ```json
    {
        // See https://go.microsoft.com/fwlink/?LinkId=733558
        // for the documentation about the tasks.json format
        "version": "0.1.0",
        "command": "tsc",
        "isShellCommand": true,
        "args": ["-p", "."],
        "showOutput": "silent",
        "problemMatcher": "$tsc"
    }
    ````

2. Change the second element of the "args" option from "." to "src", 
   which is the root folder of the application’s TypeScript files.
    - If you press CMD + SHIFT + B (Mac), CTRL + SHIFT + B (Win/Linux), you’ll get an error stating:

    ```
    Cannot find a tsconfig.json file at the specified directory: 'src'.
    ```

    - To add a tsconfig.json file to the src folder, you can execute the following from the command line at src.
        + Press CTRL + ` (Mac/Linux), CTRL + ' (Win) to open the integrated terminal window, then enter:

    ```
    cd src
    tsc --init
    ```

    - Delete index.js from the src folder.
    - Accept the defaults and press CMD + SHIFT + B (Mac), CTRL + SHIFT + B (Win/Linux).
        + You should see an index.js file appear in the src folder.
        + Type node index.js at the command line, and you’ll see the expected output printed to the console.

3. While it may be convenient to generate .js files in the same folder as .ts files, 
   you will most likely want to distribute the .js output by itself.
    - To facilitate this approach, you can add two more properties on compileOptions in tsconfig.json:

    ```json
    "rootDir": ".",
    "outDir": "../dist"
    ```

    - Feel free to delete index.js from the src folder.

4. Press CMD + SHIFT + B (Mac), CTRL + SHIFT + B (Win/Linux).
    - This time you should see index.js appear in a dist folder created at the project root.

5. In the command line window, change to the root directory; then run the app from there.

    ```
    cd ..
    node dist/index.js
    ```

## Part D: Debugging TypeScript in VS Code

1. Continue where you left off in Part C, or open HelloVSCode in the Before directory of Part D.
    - To debug TypeScript code, you will need to configure the compiler to generate source maps, 
      which link generated JavaScript back to their TypeScript source code files.

2. Open tsconfig.json in the src folder and change the sourceMap property from false to true.

    ```json
    "sourceMap": true
    ```

    - Then press CMD + SHIFT + B (Mac), CTRL + SHIFT + B (Win/Linux).
        + You should see an index.js.map appear in the dist folder.

3. Next you will need to create a debug configuration in a file called launch.json.
    - To create the file, simply press F5 and select Node.js for the environment.
        + A launch.json file will be added to the .vscode folder.

4. Locate the "program" property of the first configuration and change the value to "${file}".
    - This will enable you to debug the currently open file.

    ```json
    "program": "${file}"
    ```

5. Next edit the first configuration in launch.json.
    - Set the "sourceMaps" property to true
    - Set the "outFiles" property to [ "${workspaceRoot}/dist/**/*.js" ]
    - Feel free to remove the other launch configuration: "Attach to process".

6. Now you can open index.ts, go to line 8, and press F9 to set a breakpoint there.

7. Press F5 to start debugging.
    - You should hit the breakpoint you set.
    - Press F11 to step into the skewer function, 
      where you can inspect the call stack and local variables.

## Part E: Scaffolding TypeScript Projects with Yeoman

1. Open up an administrator command prompt in the Before/HelloYeomanTypesScript directory.
    - Install the Hello-TypeScript generator

    ```
    npm install -g generator-tonysneed-hello-typescript
    ```

2. Run the Hello-TypeScript generator.

    ```
    yo tonysneed-hello-typescript
    ```

    - Press Enter to accept the suggested project name
    - Wait until the npm packages are installed for the project

    - Open in VS Code by entering: `code .`

3. Open the Integrated Terminal in VS Code.
    - Compile the app:

    ```
    npm run compile
    ```

    - Run the app:

    ```
    npm start
    ```

    - You should see the following output: `        Hello TypeScript!`

4. Open src/index.ts, and set a breakpoint on line 8.
    - Press F5 to start debugging.
    - You should hit the breakpoint on line 8.



