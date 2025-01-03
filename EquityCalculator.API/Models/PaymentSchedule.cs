namespace EquityCalculator.API.Models;

public class PaymentSchedule 
{
    public decimal Balance { get; set; }
    public DateTime DueDate { get; set; }
    public int Term { get; set; }
    public PaymentInfo PaymentDetails { get; set; } = default!;
}

