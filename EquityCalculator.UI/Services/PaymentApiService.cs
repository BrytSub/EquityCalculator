using EquityCalculator.UI.Models;
using System.Net.Http;

namespace EquityCalculator.UI.Services;

public class PaymentApiService : IPaymentApiService
{
    private readonly HttpClient _httpClient;

    public PaymentApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task<List<PaymentSchedule>> CalculatePaymentSchedulesAsync(PaymentRequest request)
    {
        var query = $"sellingPrice={request.SellingPrice}&reservationDate={request.ReservationDate:yyyy-MM-dd}&equityTerm={request.EquityTerm}";
        var response = await _httpClient.GetAsync($"api/payment/calculate?{query}");

        if (response.IsSuccessStatusCode)
        {
            var result = await response.Content.ReadFromJsonAsync<PaymentResponse>();
            return result.Schedules;
        }

        return null;
    }
}
