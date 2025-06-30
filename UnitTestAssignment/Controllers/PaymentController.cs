using Microsoft.AspNetCore.Mvc;
using UnitTestAssignment.Interface;
using UserOrderSystem.Models;

namespace UnitTestAssignment.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        // POST: api/payment/process
        [HttpPost("process")]
        public IActionResult ProcessPayment([FromBody] Order order)
        {
            if (order == null)
                return BadRequest("Order cannot be null.");

            try
            {
                _paymentService.ProcessPayment(order);
                return Ok("Payment processed successfully.");
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest($"Payment processing failed: {ex.Message}");
            }
        }
    }
}
