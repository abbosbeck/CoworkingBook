using Application.Dto;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoworkingBook.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FloorController : ControllerBase
    {
        private readonly IGenericCRUDService<FloorResponseDto, FloorRegisterDto> _floorSvc;
        public FloorController(IGenericCRUDService<FloorResponseDto, FloorRegisterDto> floorSvc)
        {
            _floorSvc = floorSvc;
        }

        // GET: api/<FloorController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _floorSvc.GetAll());
        }

        // GET api/<FloorController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _floorSvc.GetById(id));
        }

        // POST api/<FloorController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] FloorRegisterDto floor)
        {
            var createFloor = await _floorSvc.Create(floor);
            var routeValues = new { id = createFloor.Id };
            return CreatedAtRoute(routeValues, createFloor);
        }

        // PUT api/<FloorController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] FloorRegisterDto floor)
        {
            var updatedFloor = await _floorSvc.Update(id, floor);
            return Ok(updatedFloor);
        }

        // DELETE api/<FloorController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool deletedFloor = await _floorSvc.Delete(id);

            if (deletedFloor)
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
