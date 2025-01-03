namespace EquityCalculator.API.Services;

public interface IPaymentService
{
    PaymentResponse CalculatePayment(PaymentRequest request);
}
