namespace EquityCalculator.API.Services;

public class PaymentService : IPaymentService
{
    public PaymentResponse CalculatePayment(PaymentRequest request)
    {
        var response = new PaymentResponse();
        var monthlyAmount = request.SellingPrice / request.EquityTerm;
        var balance = request.SellingPrice;
        var dueDate = request.ReservationDate.AddMonths(1);

        for (int term = 1; term <= request.EquityTerm; term++)
        {
            balance -= monthlyAmount; 

            if (balance < 0)
                balance = 0;

            var interest = 0.05m * balance; //5% of balance
            var insurance = 0.01m * monthlyAmount; //1% of Amount
            var total = monthlyAmount + interest + insurance;

            response.Schedules.Add(new PaymentSchedule
            {
                Balance = balance,
                DueDate = dueDate,
                Term = term,
                PaymentDetails = new PaymentInfo
                {
                    Amount = monthlyAmount,
                    Interest = interest,
                    Insurance = insurance,
                    Total = total
                }
            });

            dueDate = dueDate.AddMonths(1); //Increment due date by 1 month
        }

        return response;
    }
}
