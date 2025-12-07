using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DEPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        #region Payment
        [HttpPost("sendPaymentEmail")]
        public async Task<IActionResult> SendPaymentEmail([FromBody] PaymentDTO paymentDTO)
        {
            try
            {
                await _paymentService.ProcessPaymentAsync(paymentDTO);
                return Ok(new { Message = "Payment email sent successfully" });
            }
            catch (KeyNotFoundException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
            catch (Exception)
            {
                return StatusCode(500, new { Message = "An unexpected error occurred" });
            }
        }
        #endregion

    }
}
