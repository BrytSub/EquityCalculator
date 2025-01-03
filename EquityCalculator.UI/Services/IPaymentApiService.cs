using EquityCalculator.UI.Models;

namespace EquityCalculator.UI.Services;

public interface IPaymentApiService
{
    Task<List<PaymentSchedule>> CalculatePaymentSchedulesAsync(PaymentRequest request);
}
