namespace EquityCalculator.API.Models;

public class PaymentResponse
{
    public List<PaymentSchedule> Schedules { get; set; } = new List<PaymentSchedule>();
}

