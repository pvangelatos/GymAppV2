using GymAppV2.Core.DTOs;
using GymAppV2.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GymAppV2.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class SubscriptionsController : ControllerBase
    {
        private readonly ISubscriptionService _subscriptionService;

        public SubscriptionsController(ISubscriptionService subscriptionService)
        {
            _subscriptionService = subscriptionService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubscriptionDto>>> GetAll()
        {
            var subscriptions = await _subscriptionService.GetAllAsync();
            return Ok(subscriptions);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SubscriptionDto>> GetById(int id)
        {
            var subscription = await _subscriptionService.GetByIdAsync(id);
            if (subscription is null) return NotFound();
            return Ok(subscription);
        }

        [HttpGet("member/{memberId}")]
        public async Task<ActionResult<IEnumerable<SubscriptionDto>>> GetByMember(int memberId)
        {
            var subscriptions = await _subscriptionService.GetByMemberIdAsync(memberId);
            return Ok(subscriptions);
        }

        [HttpGet("member/{memberId}/active")]
        public async Task<ActionResult<SubscriptionDto>> GetActiveByMember(int memberId)
        {
            var subscription = await _subscriptionService.GetActiveByMemberIdAsync(memberId);
            if (subscription is null) return NotFound();
            return Ok(subscription);
        }

        [HttpPost]
        public async Task<ActionResult<SubscriptionDto>> Create([FromBody] CreateSubscriptionDto dto)
        {
            try
            {
                var subscription = await _subscriptionService.CreateAsync(dto);
                return CreatedAtAction(nameof(GetById), new { id = subscription.Id }, subscription);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpPut("{id}/cancel")]
        public async Task<IActionResult> Cancel(int id)
        {
            try
            {
                await _subscriptionService.CancelAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
