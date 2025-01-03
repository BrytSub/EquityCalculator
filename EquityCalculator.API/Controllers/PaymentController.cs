using Microsoft.AspNetCore.Mvc;

namespace EquityCalculator.API.Controllers
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

        [HttpGet("calculate")]
        public IActionResult Calculate([FromQuery] decimal sellingPrice, [FromQuery] DateTime reservationDate, [FromQuery] int equityTerm)
        {
            if (sellingPrice <= 0 || equityTerm <= 0)
            {
                return BadRequest("SellingPrice and EquityTerm must be greater than zero.");
            }

            var request = new PaymentRequest
            {
                SellingPrice = sellingPrice,
                ReservationDate = reservationDate,
                EquityTerm = equityTerm
            };

            var response = _paymentService.CalculatePayment(request);
            return Ok(response);
        }
    }
}
