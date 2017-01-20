# Exercise: Angular 2 Architecture

## Part A: Angular from Scratch

1. Open a command prompt at the Before/angular-scratch directory.
    - Scaffold a new TypeScript app with Yeoman
    - Accept the suggested app name

    ```
    yo tonysneed-hello-typescript
    ```

2. Add Angular dependencies.
    - Install NPM packages from the command line.

    ```
    npm install --save @angular/common @angular/compiler @angular/core @angular/forms @angular/http @angular/platform-browser @angular/platform-browser-dynamic @angular/router @angular/upgrade core-js reflect-metadata rxjs systemjs zone.js
    ```

3. Open the project in VS Code: `code .`
    - Open src/tsconfig.json
    - Add the following:

    ```json
    "moduleResolution": "node",
    "emitDecoratorMetadata": true,
    "experimentalDecorators": true,
    "lib": [
        "es2015",
        "es5",
        "dom",
        "scripthost" 
    ],
    "rootDir": ".",
    "outDir": "../../dist/app"
    ```

4. Add the file systemjs.config.js to the src folder.
    - Paste the following content:

    ```js
    /**
    * System configuration for Angular samples
    * Adjust as necessary for your application needs.
    */
    (function (global) {
    System.config({
        paths: {
        // paths serve as alias
        'npm:': '../node_modules/'
        },
        // map tells the System loader where to look for things
        map: {
        // our app is within the app folder
        app: 'app',

        // angular bundles
        '@angular/core': 'npm:@angular/core/bundles/core.umd.js',
        '@angular/common': 'npm:@angular/common/bundles/common.umd.js',
        '@angular/compiler': 'npm:@angular/compiler/bundles/compiler.umd.js',
        '@angular/platform-browser': 'npm:@angular/platform-browser/bundles/platform-browser.umd.js',
        '@angular/platform-browser-dynamic': 'npm:@angular/platform-browser-dynamic/bundles/platform-browser-dynamic.umd.js',
        '@angular/http': 'npm:@angular/http/bundles/http.umd.js',
        '@angular/router': 'npm:@angular/router/bundles/router.umd.js',
        '@angular/forms': 'npm:@angular/forms/bundles/forms.umd.js',
        '@angular/upgrade': 'npm:@angular/upgrade/bundles/upgrade.umd.js',

        // other libraries
        'rxjs':                      'npm:rxjs',
        'angular-in-memory-web-api': 'npm:angular-in-memory-web-api',
        },
        // packages tells the System loader how to load when no filename and/or no extension
        packages: {
        app: {
            main: './main.js',
            defaultExtension: 'js'
        },
        rxjs: {
            defaultExtension: 'js'
        },
        'angular-in-memory-web-api': {
            main: './index.js',
            defaultExtension: 'js'
        }
        }
    });
    })(this);
    ```

5. Add an app folder to src and create an index.html file there.
    - Add the following content:

    ```html
    <!DOCTYPE html>
    <html>

    <head>
        <title>Angular Lab</title>
        <meta charset="UTF-8">
        <meta name="viewport" content="width=device-width, initial-scale=1">

        <!-- Polyfill(s) for older browsers -->
        <script src="node_modules/core-js/client/shim.min.js"></script>

        <script src="node_modules/zone.js/dist/zone.js"></script>
        <script src="node_modules/reflect-metadata/Reflect.js"></script>
        <script src="node_modules/systemjs/dist/system.src.js"></script>

        <script src="systemjs.config.js"></script>
        <script>
        System.import('app').catch(function(err){ console.error(err); });
        </script>
    </head>

    <body>
        <my-app><h3>Loading App ...</h3></my-app>
    </body>

    </html>
    ```

6. Create an app.component.ts file in the app folder.

    ```js
    import { Component } from "@angular/core";

    @Component({
        selector: "my-app",
        templateUrl: "app.component.html"
    })
    export class AppComponent {
        title = "Angular Lab";
    }
    ```

7. Add an app.component.html file to the app folder.

    ```html
    <h1>{{title}}</h1>
    ```

8. Add an app.module.ts file to the app folder.

    ```js
    import { NgModule } from "@angular/core";
    import { BrowserModule  } from "@angular/platform-browser";
    import { HttpModule } from "@angular/http";

    import { AppComponent } from "./app.component";

    @NgModule({
        imports: [
            BrowserModule,
            HttpModule,
        ],
        declarations: [
            AppComponent
        ],
        providers: [/* TODO: Providers go here */],
        bootstrap: [AppComponent],
    })
    export class AppModule { }
    ```

9. Add a main.ts to the app folder.

    ```js
    import { platformBrowserDynamic } from "@angular/platform-browser-dynamic";

    import { AppModule } from "./app.module";

    platformBrowserDynamic().bootstrapModule(AppModule);
    ```

10. Install gulp for copying files to the output directory.

    ```
    npm install --save-dev gulp
    ```

    - Add a gulpfile.js to the src folder.

    ```js
    var gulp = require('gulp');

    gulp.task('copy', function () {
        return gulp.src(['./src/**/*.{js,html,css,ico}'])
            .pipe(gulp.dest('./dist'));
    });
    ```

11. Remove the dist directory, then run gulp to copy files.

    ```
    gulp copy
    ```

    - Recompile the project by pressing CTRL + B.
        + The dist folder should now contain all the copied and compiled files.

12. Next you'll use a lightweight web server called lite-server to run the app.
    - Install lite-server: `npm install --save-dev lite-server`
    - Update package.json by adding the following to the "scripts" section:

    ```json
    "start": "lite-server"
    ```

    - Add a bs-config.json file to the root directory with the following content:

    ```json
    {
    "files": ["./src/dist/**/*.{html,htm,css,js}"],
    "server": { "baseDir": ["./", "./dist", "./dist/app"] }
    }
    ```

    - Run the web app

    ```
    npm start
    ```

    - You should see a web browser open to localhost:3000
    - The following text will be shown: **Angular from Scratch**

    