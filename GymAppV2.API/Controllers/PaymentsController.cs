using GymAppV2.Core.DTOs;
using GymAppV2.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GymAppV2.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentsController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpGet("subscription/{subscriptionId}")]
        public async Task<ActionResult<IEnumerable<PaymentDto>>> GetBySubscription(int subscriptionId)
        {
            var payments = await _paymentService.GetBySubscriptionIdAsync(subscriptionId);
            return Ok(payments);
        }

        [HttpPost]
        public async Task<ActionResult<PaymentDto>> Create([FromBody] CreatePaymentDto dto)
        {
            try
            {
                var payment = await _paymentService.CreateAsync(dto);
                return CreatedAtAction(nameof(GetBySubscription), new { subscriptionId = payment.SubscriptionId }, payment);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}
