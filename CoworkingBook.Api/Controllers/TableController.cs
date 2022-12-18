using Application.Dto;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace CoworkingBook.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TableController : ControllerBase
    {
        private readonly IGenericCRUDService<TableResponseDto, TableRegisterDto> _genericService;

        public TableController(IGenericCRUDService<TableResponseDto,TableRegisterDto> genericCRUDService)
        {
            _genericService = genericCRUDService;
        }
        // GET: api/<Controller>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _genericService.GetAll());
        }

        // GET api/<TableController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _genericService.GetById(id));
        }

        // POST api/<TableController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TableRegisterDto value)
        {
            var createTable = await _genericService.Create(value);
            var routeValues = new { id = createTable.Id };
            return CreatedAtRoute(routeValues, createTable);
        }

        // PUT api/<TableController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] TableRegisterDto branch)
        {
            var updatedTable = await _genericService.Update(id, branch);
            return Ok(updatedTable);
        }

        // DELETE api/<TableController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool deletedTable = await _genericService.Delete(id);

            if (deletedTable)
            {
                return Ok();
            }
            else
            {
                return NotFound("There is no table in that Id");
            }
        }
    }
}
