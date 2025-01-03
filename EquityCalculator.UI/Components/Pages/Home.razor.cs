using EquityCalculator.UI.Models;
using EquityCalculator.UI.Services;
using Microsoft.AspNetCore.Components;

namespace EquityCalculator.UI.Components.Pages;

public partial class Home
{
    [Inject]
    private IPaymentApiService PaymentApiService { get; set; }

    PaymentRequest PaymentRequest { get; set; } = new PaymentRequest();
    public List<PaymentSchedule> PaymentSchedules { get; private set; }

    private async Task CalculatePaymentSchedules()
    {
        if (PaymentRequest != null)
        {
            PaymentSchedules = await PaymentApiService.CalculatePaymentSchedulesAsync(PaymentRequest);
        }
    }
}