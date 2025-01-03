namespace EquityCalculator.API.Models;

public class PaymentRequest
{
    public decimal SellingPrice { get; set; }
    public DateTime ReservationDate { get; set; }
    public int EquityTerm { get; set; }
}
