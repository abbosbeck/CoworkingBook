using Application.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoworkingBook.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookedTableController : ControllerBase
    {
        private readonly IGenericCRUDService<BookedTableResponseDto, BookedTableRegisterDto> _bookedTableSvc;
        public BookedTableController(IGenericCRUDService<BookedTableResponseDto, BookedTableRegisterDto> bookedTableSvc)
        {
            _bookedTableSvc = bookedTableSvc;
        }

        // GET: api/<BookedTableController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _bookedTableSvc.GetAll());
        }

        // GET api/<BookedTableController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _bookedTableSvc.GetById(id));
        }

        // POST api/<BookedTableController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BookedTableRegisterDto value)
        {
            var createBookedTable = await _bookedTableSvc.Create(value);
            var routeValues = new { id = createBookedTable.Id };
            return CreatedAtRoute(routeValues, createBookedTable);
        }

        // PUT api/<BookedTableController>/5
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Put(int id, [FromBody] BookedTableRegisterDto table)
        {
            var updatedBookedTable = await _bookedTableSvc.Update(id, table);
            return Ok(updatedBookedTable);
        }

        // DELETE api/<BookedTableController>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            bool deletedBookedTable = await _bookedTableSvc.Delete(id);

            if (deletedBookedTable)
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
