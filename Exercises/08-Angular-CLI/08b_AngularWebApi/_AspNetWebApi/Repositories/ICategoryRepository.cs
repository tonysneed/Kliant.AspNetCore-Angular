using System.Collections.Generic;
using System.Threading.Tasks;
using HelloWebApi.Models;

namespace HelloWebApi.Repositories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetCategories();
        Task<Category> GetCategory(int id);
    }
}