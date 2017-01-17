using System.Collections.Generic;
using System.Threading.Tasks;
using HelloWebApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace HelloWebApi.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly IValuesRepository _valuesRepo;

        public ValuesController(IValuesRepository valuesRepo)
        {
            _valuesRepo = valuesRepo;
        }

        // GET api/values
        [HttpGet]
        public async Task<IEnumerable<string>> Get()
        {
            return await _valuesRepo.GetValues();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<string> Get(int id)
        {
            return await _valuesRepo.GetValue(id);
        }

        // POST api/values
        [HttpPost("{id}")]
        public async Task Post(int id, [FromBody]string value)
        {
            await _valuesRepo.CreateValue(id, value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody]string value)
        {
            await _valuesRepo.UpdateValue(id, value);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _valuesRepo.DeleteValue(id);
        }
    }
}
