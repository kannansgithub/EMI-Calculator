// P*R*(1+R) power of N/(1+R) power of N
using static System.Net.Mime.MediaTypeNames;

//var p = 3000000.00;
//var n = 10.00;
//var r = 8.00;
Console.WriteLine("Enter the Loan Amount ");
var p=Console.ReadLine();
Console.WriteLine("Enter the Loan Periods in Year ");
var n = Console.ReadLine();
Console.WriteLine("Enter the interest rate ");
var r = Console.ReadLine();
double LoanAmount = 0;
double Payment = 0;
double InterestRate = 0;
int PaymentPeriods = 0;
try
{
    InterestRate = Convert.ToDouble(r);
    PaymentPeriods = Convert.ToInt16(Convert.ToDouble(n) * 12);
    LoanAmount = Convert.ToDouble(p);
    if (InterestRate > 1)
    {
        InterestRate = InterestRate / 100;
    }
    Payment = (LoanAmount * Math.Pow((InterestRate / 12) + 1,
        (PaymentPeriods)) * InterestRate / 12) / (Math.Pow
        (InterestRate / 12 + 1, (PaymentPeriods)) - 1);
    Console.WriteLine("Monthly Payment: " + Payment.ToString("N2"));
    Console.WriteLine(("======================================"));
    Console.WriteLine();
    Console.WriteLine("Month\t\t Principal \t\t Interest \t\t EMI \t\t Balance");
    var balanceAmount = LoanAmount;
    var totalInterest = 0.0;
    for (var i = 1; i <= PaymentPeriods; i++)
    {
        var interest =Math.Round(balanceAmount * (InterestRate / 12),2);
        var principal =Math.Round(Payment - interest, 2);
        balanceAmount -= principal;
        totalInterest += interest;
        Console.WriteLine($"  {i.ToString().PadLeft(3,'0')}\t\t {Math.Round(principal,2)} \t\t {Math.Round(interest,2)} \t\t {Math.Round(Payment,2)} \t\t {Math.Round(balanceAmount,2)}");
    }
    Console.WriteLine($"Total Interest to Pay {Math.Round(totalInterest,2)}");
}
catch
{
}
Console.ReadKey();
