using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using HelloWebApi.Contexts;
using HelloWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace HelloWebApi.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly NorthwindSlimContext _context;

        public ProductRepository(NorthwindSlimContext context)
        {
            _context = context;
        }

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

        public void CreateProduct(Product product)
        {
            _context.Products.Add(product);
        }

        public void UpdateProduct(Product product)
        {
            _context.Products.Update(product);
        }

        public async Task DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            _context.Products.Remove(product);
        }

        public async Task LoadCategory(Product product)
        {
            await _context.Entry(product)
                .Reference(p => p.Category)
                .LoadAsync();
        }
    }
}