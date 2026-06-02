using GymAppV2.Core.DTOs;
using GymAppV2.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GymAppV2.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class GymProgramsController : ControllerBase
    {
        private readonly IGymProgramService _gymProgramService;

        public GymProgramsController(IGymProgramService gymProgramService)
        {
            _gymProgramService = gymProgramService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GymProgramDto>>> GetAll()
        {
            var programs = await _gymProgramService.GetAllAsync();
            return Ok(programs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GymProgramDto>> GetById(int id)
        {
            var program = await _gymProgramService.GetByIdAsync(id);
            if (program is null) return NotFound();
            return Ok(program);
        }

        [HttpPost]
        public async Task<ActionResult<GymProgramDto>> Create([FromBody] CreateGymProgramDto dto)
        {
            try
            {
                var program = await _gymProgramService.CreateAsync(dto);
                return CreatedAtAction(nameof(GetById), new { id = program.Id }, program);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<GymProgramDto>> Update(int id, [FromBody] UpdateGymProgramDto dto)
        {
            try
            {
                var program = await _gymProgramService.UpdateAsync(id, dto);
                return Ok(program);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _gymProgramService.DeleteAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
