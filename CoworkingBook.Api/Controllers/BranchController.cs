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
        private readonly IGenericCRUDService<BranchResponseDto, BranchRegisterDto> _branchSvc;
        public BranchController(IGenericCRUDService<BranchResponseDto, BranchRegisterDto> genericCRUDService)
        {
            _branchSvc = genericCRUDService;
        }

        // GET: api/<BranchController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _branchSvc.GetAll());
        }

        // GET api/<BranchController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _branchSvc.GetById(id));
        }

        // POST api/<BranchController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BranchRegisterDto value)
        {
            var createEmployee = await _branchSvc.Create(value);
            var routeValues = new { id = createEmployee.Id };
            return CreatedAtRoute(routeValues, createEmployee);
        }

        // PUT api/<BranchController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] BranchRegisterDto branch)
        {
            var updatedBranch = await _branchSvc.Update(id, branch);
            return Ok(updatedBranch);
        }

        // DELETE api/<BranchController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool deletedEmployee = await _branchSvc.Delete(id);

            if (deletedEmployee)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
