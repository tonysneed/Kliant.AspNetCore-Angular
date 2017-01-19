# Exercise: Entity Framework Core

## Prerequisites

1. Install VS Code Extension: Yo
2. Install [Postman](https://www.getpostman.com/).

## Part A: EF Migrations

1. Open the 04a_EF-Migrations/Before/EF-Migrations folder in VS Code.

2. Add EF dependencies to project.json

    ```json
    "Microsoft.EntityFrameworkCore.SqlServer":"1.1.0",
    "Microsoft.EntityFrameworkCore.SqlServer.Design": "1.1.0",
    "Microsoft.EntityFrameworkCore.Design": {
        "type": "build", "version": "1.1.0"
    }
    ```

3. Add EF tools to project.json
    - Restore packages: `dotnet restore`

    ```json
    "Microsoft.EntityFrameworkCore.Tools.DotNet": "1.1.0-preview4-final"
    ```

4. Create Category and Product classes.
    - Add to the Models folder
    - Place inside namespace: `HelloWebApi.Models`
    - Make sure to add CategoryId and Category properties to Product.

    ```csharp
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
    ```

    ```csharp
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
    ```

5. Create ProductsDbContext class.
    - Add to the Contexts folder
    - Place inside namespace: `HelloWebApi.Contexts`
    - Derive from DbContext
    - Add a ctor accepting DbContextOptions that calls the base ctor
    - Add Categories and Products properties of type DbSet<T>

    ```csharp
    public class ProductsDbContext: DbContext
    {
        public ProductsDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
    ```

6. Add a ConnectionStrings section to appsettings.json
    - Include a connection string to the ProductsDb database

    ```json
    "ConnectionStrings": {
    "ProductsDbConnection": "Data Source=.\\sqlexpress;Initial Catalog=ProductsDb;Integrated Security=True;MultipleActiveResultSets=True"
    }
    ```

7. Add a `DbContext` to `ConfigureServices` in `Startup`.
    - Add using directive for `Microsoft.EntityFrameworkCore`

    ```csharp
    services.AddDbContext<ProductsDbContext>(options =>
        options.UseSqlServer(Configuration.GetConnectionString("ProductsDbConnection")));
    ```

8. Add initial migration and apply to database.
    - Open command prompt in app directory
    - Open SQL Server Management Studio to verify 
      ProductsDb database and tables

    ```
    dotnet ef add initial
    dotnet ef database update
    ```

9. Populate database tables.
    - Open Data/ProductsDb-Data.sql in SSMS and run it
    - Categories and Products tables should be populated with data

## Part B: Repository with Queries

1. Continue where you left off in Part A, or open the 
   04b_Repository-Queries/Before/Repository-Queries folder in VS Code.

2. Add an ICategoryRepository.cs file to the Repositories folder.
    - Add a HelloWebApi.Repositories namespace
    - Add an ICategoryRepository interface

    ```csharp
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetCategories();
        Task<Category> GetCategory(int id);
    }
    ```

3. Add a CategoryRepository class that implements ICategoryRepository.
    - Add ctor that accepts ProductsDbContext
    - Use async / await for IO-bound async with 
      ToListAsync and SingleOrDefaultAsync

4. Use Yo extension to add CategoryController.cs file to 
   the Controllers folder.
    - Press Ctrl+Shift+P to open the command palette, 
        then enter: yo, aspnet, webapicontroller
    - Move file to Controllers folder
    - Add .Controllers to namespace
    - Add ctor to initialize ProductsDbContext
    - Remove methods other than the two Get methods
    - Use async / await for IO-bound async
    - Each method should return Task<IActionResult> and return a 
      call to OK, passing the result of the repository GetXxx method.

5. Update Startup.ConfigureServices to add repository.

    ```csharp
    services.AddScoped<ICategoryRepository, CategoryRepository>();
    ```

6. Build and run the app.

    ```
    dotnet build
    dotnet run
    ```

7. Browse to: http://localhost/api/category
    - You should see categories
    - Then add /5 to see selected category

## Part C: Unit of Work with Updates

1. Continue where you left off in Part B, or open the 
   04c_UnitOfWork-Updates/Before/UnitOfWork-Updates folder in VS Code.

2. Add an IproductRepository.cs file to the Repositories folder.
    - Add a HelloWebApi.Repositories namespace
    - Add an IProductRepository interface

    ```csharp
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetProduct(int id);
        void CreateProduct(Product product);
        void UpdateProduct(Product product);
        Task DeleteProduct(int id);
        Task LoadCategory(Product product);
    }
    ```

3. Add a ProductRepository class that implements IProductRepository.
    - Add ctor that accepts ProductsDbContext
    - Use async / await for IO-bound async
    - Include Category property in query for products

    ```csharp
    public async Task<IEnumerable<Product>> GetProducts()
    {
        return await _context.Products
            .Include(p => p.Category)
            .OrderBy(p => p.ProductName)
            .ToListAsync();
    }

    public async Task<Product> GetProduct(int id)
    {
        return await _context.Products
            .Include(p => p.Category)
            .SingleOrDefaultAsync(p => p.ProductId == id);
    }
    ```

    - For the Delete method you need to retreive the product 
      by id in order to pass it to the repository Remove method.

    ```csharp
    public async Task DeleteProduct(int id)
    {
        var product = await _context.Products.FindAsync(id);
        _context.Products.Remove(product);
    }
    ```

    - For the LoadCategory method you need to call LoadAsync 
      on the Reference of the product entry.

    ```csharp
    public async Task LoadCategory(Product product)
    {
        await _context.Entry(product)
            .Reference(p => p.Category)
            .LoadAsync();
    }
    ```

4. Add an IUnitOfWork.cs file to the UnitsOfWork folder.
    - Write an IUnitOfWork interface with read only properties 
      for each repository.
    - Include a SaveChangesAsync method returning Task<int>

    ```chsarp
    public interface IUnitOfWork
    {
        ICategoryRepository CategoryRepository { get; }
        IProductRepository ProductRepository { get; }
        Task<int> SaveChangesAsync();
    }
    ```

5. Add a UnitOfWork file to the UnitsOfWork folder.
    - Write a UnitOfWork class that implements IUnitOfWork
    - Add a ctor that accepts ICategoryRepository, IProductRepository 
      and ProductsDbContext
    - Implement IDisposable by calling Dispose on ProductsDbContext

    ```csharp
    public void Dispose()
    {
        if (_disposed) return;
        var disposable = _context as IDisposable;
        if (disposable != null) disposable.Dispose();
        _disposed = true;
    }
    ```

6. Use Yo extension to add ProductController.cs file to 
   the Controllers folder.
    - Press Ctrl+Shift+P to open the command palette, 
        then enter: yo, aspnet, webapicontroller
    - Move file to Controllers folder
    - Add .Controllers to namespace
    - Add ctor that accepts an IUnitOfWork
    - Use async / await for IO-bound async
    - In Post, Put and Delete first await the repository method, 
      then await _unitOfWork.SaveChangesAsync.
    - Each method should return Task<IActionResult> and return a 
      call to OK, passing the result of the repository GetXxx method
    - Post and Put need [FromBody] on the Product parameter
    - Post and Put should both call ProductRepository.LoadCategory
    - Delete should return NoContent
    - Post should return CreatedAtAction

    ```chsarp
    return CreatedAtAction("Get", new { id = product.ProductId }, product);
    ```

7. Update Startup.ConfigureServices to add product repository and unit of work.

    ```csharp
    services.AddScoped<IProductRepository, ProductRepository>();
    services.AddScoped<IUnitOfWork, UnitOfWork>();
    ```

8. Run the web app.

    ```
    dotnet run
    ```

9. Browse to http://localhost:5000/api/product/1.
    - Note that the Category property has been populated.

    ```json
    {
    "productId": 1,
    "productName": "Chai",
    "unitPrice": 23,
    "categoryId": 1,
    "category": {
        "categoryId": 1,
        "categoryName": "Beverages"
      }
    }
    ```

10. Use Postman to call Post on the Products controller.

    *NOTE: Replace the id 80 below with the id returned by POST.*

    - Method: POST
    - URL: http://localhost:5000/api/product
    - Header: Content-Type application/json
    - Body:

    ```json
    {
      "productName": "Chocolato",
      "unitPrice": 10,
      "categoryId": 1
    }
    ```

    - Result:
        + Status: 201 Created
        + Location Header: http://localhost:5000/api/Product/id (id = new product id)
        + Body:

    ```json
    {
      "productId": 80,
      "productName": "Chocolato",
      "unitPrice": 10,
      "categoryId": 1,
      "category": {
        "categoryId": 1,
        "categoryName": "Beverages"
      }
    }
    ```

11. Use Postman to call Put on the Products controller.
    - Method: PUT
    - URL: http://localhost:5000/api/product
    - Header: Content-Type application/json
    - Body:

    ```json
    {
      "productId": 80,
      "productName": "Chocolato",
      "unitPrice": 11,
      "categoryId": 1
    }
    ```

    - Result:
        + Status: 200 OK
        + Body:

    ```json
    {
      "productId": 80,
      "productName": "Chocolato",
      "unitPrice": 11,
      "categoryId": 1,
      "category": {
        "categoryId": 1,
        "categoryName": "Beverages"
      }
    }
    ```

12. Use Postman to call Delete on the Products controller.
    - Method: DELETE
    - URL: http://localhost:5000/api/product/80

    - Result:
        + Status: 204 No Content

## Part D: Database First with Scaffolding (optional)

### Prerequisites for Part D:

1. Install SQL Express and SQL Server Management Studio
2. Download NorthwindSlim: http://bit.ly/northwindslim
3. Create NorthwindSlim database in SSMS
5. Run Northwindslim.sql in SSMS

### Steps for Part D:

1. Continue where you left off in Part B, or open the 
   04d_EF-Scaffolding/Before/EF-Scaffolding folder in VS Code.
    - Restore packages: `dotnet restore`

2. Scaffold context and model classes from an existing database.

    ```
    dotnet ef dbcontext scaffold "Server=(local)\sqlexpress;Database=NorthwindSlim;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -o Models -f
    ```

4. Open the Models folder.
    - You should see context and model classes.

5. Add code to Program.Main that displays customers.

    ```chsarp
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Press Enter for Customers");
            Console.ReadLine();

            using(var context = new NorthwindSlimContext())
            {
                var customers = context.Customer.OrderBy(c => c.CompanyName).ToList();
                foreach (var c in customers)
                {
                    Console.WriteLine($"{c.CompanyName} {c.City}");
                }
            }
        }
    }
    ```

6. Run the program to retrieve and display customers.

    ```
    dotnet run
    ```


