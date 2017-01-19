using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using HelloWebApi.Contexts;
using HelloWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace HelloWebApi.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ProductsDbContext _context;

        public CategoryRepository(ProductsDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            var categories = await (from c in _context.Categories
                orderby c.CategoryName
                select c).ToListAsync();
            return categories;
        }

        public async Task<Category> GetCategory(int id)
        {
            var category = await _context.Categories
                .SingleOrDefaultAsync(c => c.CategoryId == id);
            return category;
        }
    }
}