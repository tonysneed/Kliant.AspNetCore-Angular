using System;
using System.Threading.Tasks;
using HelloWebApi.Contexts;
using HelloWebApi.Repositories;

namespace HelloWebApi.UnitsOfWork
{
    public class UnitOfWork: IUnitOfWork, IDisposable
    {
        private bool _disposed;
        private readonly ICategoryRepository _categoryRepo;
        private readonly IProductRepository _productRepo;
        private readonly ProductsDbContext _context;

        public UnitOfWork(
            ICategoryRepository categoryRepo,
            IProductRepository productRepo,
            ProductsDbContext context)
        {
            _categoryRepo = categoryRepo;
            _productRepo = productRepo;
            _context = context;
        }

        public ICategoryRepository CategoryRepository
        {
            get { return _categoryRepo; }
        }

        public IProductRepository ProductRepository
        {
            get { return _productRepo; }
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            if (_disposed) return;
            var disposable = _context as IDisposable;
            if (disposable != null) disposable.Dispose();
            _disposed = true;
        }
    }
}