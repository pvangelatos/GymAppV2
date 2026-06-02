using GymAppV2.Core.DTOs;
using GymAppV2.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GymAppV2.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class TrainersController : ControllerBase
    {
        private readonly ITrainerService _trainerService;

        public TrainersController(ITrainerService trainerService)
        {
            _trainerService = trainerService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrainerDto>>> GetAll()
        {
            var trainers = await _trainerService.GetAllAsync();
            return Ok(trainers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TrainerDto>> GetById(int id)
        {
            var trainer = await _trainerService.GetByIdAsync(id);
            if (trainer is null) return NotFound();
            return Ok(trainer);
        }

        [HttpPost]
        public async Task<ActionResult<TrainerDto>> Create([FromBody] CreateTrainerDto dto)
        {
            try
            {
                var trainer = await _trainerService.CreateAsync(dto);
                return CreatedAtAction(nameof(GetById), new { id = trainer.Id }, trainer);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TrainerDto>> Update(int id, [FromBody] UpdateTrainerDto dto)
        {
            try
            {
                var trainer = await _trainerService.UpdateAsync(id, dto);
                return Ok(trainer);
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
                await _trainerService.DeleteAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
