using System.Collections.Generic;
using System.Threading.Tasks;
using HelloWebApi.Repositories;
using HelloWebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace HelloWebApi.Controllers
{
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepo;

        public CategoryController(ICategoryRepository categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        // GET api/values
        [HttpGet]
        public async Task<IEnumerable<Category>> Get()
        {
            return await _categoryRepo.GetCategories();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<Category> Get(int id)
        {
            return await _categoryRepo.GetCategory(id);
        }
    }
}
