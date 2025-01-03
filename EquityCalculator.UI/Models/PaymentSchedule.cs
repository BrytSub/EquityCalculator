namespace EquityCalculator.UI.Models;

public class PaymentSchedule
{
    public decimal Balance { get; set; }
    public DateTime DueDate { get; set; }
    public int Term { get; set; }
    public PaymentDetails PaymentDetails { get; set; } = default!;
}
