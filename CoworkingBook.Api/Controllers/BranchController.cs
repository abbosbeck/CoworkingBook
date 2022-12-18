using Application.Dto;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoworkingBook.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private readonly IGenericCRUDService<BranchResponseDto, BranchRegisterDto> _genericCRUDService;
        public BranchController(IGenericCRUDService<BranchResponseDto, BranchRegisterDto> genericCRUDService)
        {
            _genericCRUDService = genericCRUDService;
        }

        // GET: api/<BranchController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<BranchController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<BranchController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BranchRegisterDto value)
        {
            var createEmployee = await _genericCRUDService.Create(value);
            var routeValues = new { id = createEmployee.Id };
            return CreatedAtRoute(routeValues, createEmployee);
        }

        // PUT api/<BranchController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BranchController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
