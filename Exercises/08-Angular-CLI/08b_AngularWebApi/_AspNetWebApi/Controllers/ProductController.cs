using System.Threading.Tasks;
using HelloWebApi.Models;
using HelloWebApi.UnitsOfWork;
using Microsoft.AspNetCore.Mvc;

namespace HelloWebApi.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = await _unitOfWork.ProductRepository.GetProducts();
            return Ok(products);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var product = await _unitOfWork.ProductRepository.GetProduct(id);
            return Ok(product);
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Product product)
        {
            _unitOfWork.ProductRepository.CreateProduct(product);
            await _unitOfWork.SaveChangesAsync();
            await _unitOfWork.ProductRepository.LoadCategory(product);
            return CreatedAtAction("Get", new { id = product.ProductId }, product);
        }

        // PUT api/values
        [HttpPut]
        public async Task<IActionResult> Put([FromBody]Product product)
        {
            _unitOfWork.ProductRepository.UpdateProduct(product);
            await _unitOfWork.SaveChangesAsync();
            await _unitOfWork.ProductRepository.LoadCategory(product);
            return Ok(product);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _unitOfWork.ProductRepository.DeleteProduct(id);
            await _unitOfWork.SaveChangesAsync();
            return NoContent();
        }
    }
}
