using System.Threading.Tasks;
using HelloWebApi.Repositories;
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
        public async Task<IActionResult> Get()
        {
            var categories = await _categoryRepo.GetCategories();
            return Ok(categories);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var category = await _categoryRepo.GetCategory(id);
            return Ok(category);
        }
    }
}
