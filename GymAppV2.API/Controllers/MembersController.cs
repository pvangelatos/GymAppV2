using GymAppV2.Core.DTOs;
using GymAppV2.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GymAppV2.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class MembersController : ControllerBase
    {
        private readonly IMemberService _memberService;

        public MembersController(IMemberService memberService)
        {
            _memberService = memberService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MemberDto>>> GetAll()
        {
            var members = await _memberService.GetAllAsync();
            return Ok(members);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MemberDto>> GetById(int id)
        {
            var member = await _memberService.GetByIdAsync(id);
            if (member is null) return NotFound();
            return Ok(member);
        }

        [HttpPost]
        public async Task<ActionResult<MemberDto>> Create([FromBody] CreateMemberDto dto)
        {
            var member = await _memberService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = member.Id }, member);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<MemberDto>> Update(int id, [FromBody] UpdateMemberDto dto)
        {
            try
            {
                var member = await _memberService.UpdateAsync(id, dto);
                return Ok(member);
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
                await _memberService.DeleteAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
