# Exercise: Angular CLI

## Prerequisites

Install Angular CLI from admin commnd prompt: `npm install -g angular-cli`

## Part A: Scaffold New App wth Angular CLI

1. Open a command prompt at the Before directory.
    - Scaffold a new app

    ```
    ng new hello-angular
    ```

    - Run the new app

    ```
    cd hello-angular
    ng serve
    ```

    - Browse to: localhost:4200
        + Should see text: **app works!**
    - Press CTRL + C to stop the app.

2. Add styling with Angular support for Bootstrap.
    - Open the app in VS Code: `code .`
    - Set `title` in app.component.ts to: `"Hello Angular CLI!"`
    - Install bootsrap and related libraries

    ```
    npm install ng2-bootstrap bootstrap jquery --save
    ```

    - Open angular-cli.json and insert a new entry into the styles array:

    ```json
    "styles": [
            "styles.css",
            "../node_modules/bootstrap/dist/css/bootstrap.min.css"
    ],
    ```

    - Insert the following entries into the scripts array:

    ```json
    "scripts": [
    "../node_modules/jquery/dist/jquery.js",
    "../node_modules/bootstrap/dist/js/bootstrap.js"
    ],
    ```

    - Open app.component.html and surround `<h1>` with a `<div>`

    ```html
    <div class="container">
    <h1>
        {{title}}
    </h1>
    </div>
    ```

    - Add special styling in app.component.css

    ```css
    h1 {
        color: #369;
        font-family: Arial, Helvetica, sans-serif;
        font-size: 250%;
    }
    ```

    - Launch the app by running: `ng serve`
        + Browse to localhost:4200 to observe the new styles

3. Add models and components using Angular CLI.
    - Create  shared/models directories beneath app.
    - Run Angular CLI to generate a product models

    ```
    ng generate class shared/models/product
    ```

    - Open the new product.ts file and add some properties.

    ```js
    export class Product {
        constructor(
            public productId: number,
            public productName: string,
            public unitPrice: number) { }
    }
    ```

    - Add a products component.
        + You can use `g` as a shortcut for `generate`
        + It will create css, html, ts and spec.ts files
        + It will also update app.module.ts

    ```
    ng g component products
    ```

    - Open products.component.ts and import Product.
        + Then add a title property set to ‘Products’ and a 
          products property that is an array of Product.
        + The final result will look like the following:

    ```js
    import { Component, OnInit } from '@angular/core';
    import { Product } from '../shared/models/product';
 
    @Component({
      selector: 'app-products',
      templateUrl: './products.component.html',
      styleUrls: ['./products.component.css']
    })
    export class ProductsComponent implements OnInit {
 
      title: string = 'Products';
      products: Product[];
      error: any;
 
      constructor() { }
 
      ngOnInit() {
        this.products = [
                new Product(1, 'Product 1', 10),
                new Product(2, 'Product 2', 20),
            ];
      }
    }
    ```

4. Create a template for the products component.
    - Add a title
    - Create a table using *ngIf and *ngFor directives

    ```html
    <div class='panel panel-primary'>
    <div class='panel-heading'>
        {{title}}
    </div>
    <div class='panel-body'>
        <div class='table-responsive'>
        <table class='table' *ngIf="products && products.length">
            <thead>
            <tr>
                <th>Product Name</th>
                <th>Unit Price</th>
            </tr>
            </thead>
            <tbody>
            <tr *ngFor="let product of products">
                <td>{{ product.productId }}</td>
                <td>{{ product.productName }}</td>
                <td>{{ product.unitPrice }}</td>
            </tr>
            </tbody>
        </table>
        </div>
        <div class="alert alert-danger" *ngIf="error">
        <strong>Error!</strong> {{error}}
        </div>
    </div>
    </div>
    ```

    -  Edit app.component.html to include the 'app-products' selector from products.component.ts

    ```html
    <div class="container">
      <h1>
        {{title}}
      </h1>
      <app-products></app-products>
    </div>
    ```

    - Refresh the browser to see the products table
        + If you've ended the app just run: `ng serve` or `npm start`

## Part B: Connect to ASP.NET Core Web API

### Prerequisites

1. Installed SQL Express.
2. Created the NorthwindSlim database in SSMS.
3. Download scripts from http://bit.ly/northwindlim.
4. Populate tables in the database by running NorthwindSlim.sql in SSMS.

### Steps

1. Open a command prompt in the _AspNetWebApi directory.

    *NOTE: Cross-origin requests have been enabled in Startup.cs, so that the Angular app 
     running from port 4200 can submit requests to the Web API running on port 5000.*

    - Restore, compile and run the Web API

    ```
    dotnet restore
    dotnet build
    dotnet run
    ```

    - Make sure the service runs and can retrieve data.
        + Navigate to: http://localhost:5000/api/category
        + Navigate to: http://localhost:5000/api/product

2. Continue where you left off in Part A, or open 08b_AngularWebApi/Before/hello-angular in VS Code.
    - Add a contsants.ts file to the shared folder.

    ```ts
    export class Urls {
        static readonly BaseUrl = 'http://localhost:5000/';
    }
    ```
    - Create a services directory under app/shared.
    - Use Angular CLI to generate a shared service.
        + A product.service.ts file will be added.

    ```
    ng g service shared/services/products
    ```

    - Add a private parameter to the constructor to inject the Angular Http client into the products service.
    - Add a getProducts function that calls this._http.get and converts it to a promise.
        + Handle success by calling `.then`, or failure by calling `.catch`

    ```js
    import { Injectable } from '@angular/core';
    import { Http } from '@angular/http';
    import 'rxjs/add/operator/toPromise';

    import { Product } from '../models/product';
    import { Urls } from '../constants';

    @Injectable()
    export class ProductsService {

      private _productsUrl = Urls.BaseUrl + 'api/products';

      constructor(private _http: Http) { }

      getProducts(): Promise<Product[]> {
        return this._http.get(this._productsUrl)
        .toPromise()
        .then(resp => resp.json() as Product[])
        .catch(this.handleError);
      }

      private handleError(error: any): Promise<any> {
        console.error('An error occurred', error);
        return Promise.reject(error.message || error);
      }
    }
    ```

3. In order to use ProductsService, you’ll need to add it as a provider to @NgModule in app.module.ts.

    ```js
    import { ProductsService } from './shared/services/products.service';
    // @NgModule decorator:
    providers: [ProductsService],
    ```

4. Refactor ProductsComponent to use ProductsService.
    - Import ProductsService

    ```js
    import { ProductsService } from '../shared/services/products.service';
    ```

    - Add a private parameter to the constructor to initialize the service.

    ```js
    constructor(private _productService: ProductsService) { }
    ```

    - Then call getProducts to set the products property if successful or the error property if unsuccessful

    ```ts
    this._productService.getProducts()
      .then(products => this.products = products)
      .catch(error => this.error = error);
    ```

5. Run the Angular app: `ng serve`
    - You should see products from the NorthwindSlim shown in the browser.

### Optional: Use Async / Await

1. Update NPM packages

    ```
    npm install --save-dev webpack@2.2.0 typescript@latest
    ```

2. Refactor products.component.ts to use async / await.
    - Precede `ngOnInit` with `async`
    - Replace code that uses .then and .catch with try / catch and await

    ```js
    try {
      this.products = await this._productService.getProducts();
    } catch (error) {
      this.error = error;
    }
    ```

3. Refactor products.service.ts to use async / await.
    - Replace getProducts with the following:

    ```js
    async getProducts(): Promise<Product[]> {
      try {
        return (await this._http.get(this._productsUrl)
          .toPromise()).json() as Product[];
      } catch (error) {
        throw error.message || error;
      }
    }
    ```

    - The application should run normally as before.    
