internal class Program
{
    private static void Main(string[] args)
    {
        CalculateMonthlyRepayment(30000, 5);
        CalculateMonthlyRepayment(95000, 5);
        CalculateLoanPeriodInYears(95000, 1750, (FixedInterestRatePerAnnumForLoanBetweenFiftyThousandAndOneToOneHundredThousand / 12));
        CalculateLoanAmountToBorrow(750, (FixedInterestRatePerAnnumForLoanBetweenFiftyThousandAndOneToOneHundredThousand / 12), 20);
    }

    public static double CalculateMonthlyRepayment(int loanAmount, int loanPeriodInYears)
    {
        int loanPeriodInMonths = loanPeriodInYears * 12;
        double monthlyInterestRate = 0;

        if (loanAmount >= 5000 && loanAmount <= 20000)
        {
            monthlyInterestRate = FixedInterestRatePerAnnumForLoanBetweenFiveThousandToTwentyThousand / 12;
        }
        else if (loanAmount >= 20001 && loanAmount <= 50000)
        {
            monthlyInterestRate = FixedInterestRatePerAnnumForLoanBetweenTwentyThousandAndOneToFiftyThousand / 12;
        }
        else if (loanAmount >= 50001 && loanAmount <= 100000)
        {
            monthlyInterestRate = FixedInterestRatePerAnnumForLoanBetweenFiftyThousandAndOneToOneHundredThousand / 12;
        }

        var monthlyInstallment = Math.Round((loanAmount * monthlyInterestRate * Math.Pow(1 + monthlyInterestRate, loanPeriodInMonths)) / (Math.Pow(1 + monthlyInterestRate, loanPeriodInMonths) - 1), 2);
        Console.WriteLine($"The monthly payment for a loan amount of RM{loanAmount} over a period of {loanPeriodInYears} years is RM{monthlyInstallment}");
        return monthlyInstallment;
    }

    public static double CalculateLoanPeriodInYears(int loanAmount, double monthlyInstallmentAmount, double interestRatePerMonth)
    {
        var loanPeriodInMonths = Math.Log(monthlyInstallmentAmount / (monthlyInstallmentAmount - (loanAmount * interestRatePerMonth))) / Math.Log(1 + interestRatePerMonth);
        var loanPeriodInYears = loanPeriodInMonths / 12;
        var loanPeriodInFullYear = (int)loanPeriodInMonths / 12;
        var loanPeriodLeftovers = Math.Ceiling(loanPeriodInMonths) % 12;
        Console.WriteLine($"The loan period for a loan amount of RM{loanAmount} with a monthly payment of RM{monthlyInstallmentAmount} is around:\n {Math.Ceiling(loanPeriodInMonths)} months\n or {loanPeriodInYears} years\n or {loanPeriodInFullYear} years and {loanPeriodLeftovers} months");

        return loanPeriodInYears;
    }

    public static double CalculateLoanAmountToBorrow(double monthlyInstallmentAmount, double interestRatePerMonth, int loanPeriodInYears)
    {
        var loanPeriodInMonths = loanPeriodInYears * 12;
        var loanAmountToBorrow = (monthlyInstallmentAmount * (Math.Pow(1 + interestRatePerMonth, loanPeriodInMonths) - 1)) / (interestRatePerMonth * (Math.Pow(1 + interestRatePerMonth, loanPeriodInMonths)));
        var roundedLoanAmountToBorrow = Math.Round(loanAmountToBorrow, 2);
        Console.WriteLine($"The loan amount to borrow for a monthly payment of RM{monthlyInstallmentAmount} over a period of {loanPeriodInYears} years is RM{roundedLoanAmountToBorrow}");

        return roundedLoanAmountToBorrow;
    }

    public const double FixedInterestRatePerAnnumForLoanBetweenFiveThousandToTwentyThousand = 0.08;
    public const double FixedInterestRatePerAnnumForLoanBetweenTwentyThousandAndOneToFiftyThousand = 0.07;
    public const double FixedInterestRatePerAnnumForLoanBetweenFiftyThousandAndOneToOneHundredThousand = 0.065;
}