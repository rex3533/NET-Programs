// Glaycon Cezarotto 2/13/2026
using System;
using System.Globalization;

class Program
{
    const decimal MIN_LOAN = 5000.00m;
    const decimal MAX_LOAN = 500000.00m;

    static void Main()
    {
        Console.WriteLine("CPSC 23000 Homework 3: Loan Repayment Schedule");
        Console.WriteLine();

        decimal loanAmount = ReadDecimalTryCatch($"Loan Amount ({MIN_LOAN:C} to {MAX_LOAN:C}): $", MIN_LOAN, MAX_LOAN);

        // User enters percent like 5.6, then convert to 0.056 as described in the assignment 
        decimal yearlyRatePercent = ReadDecimalTryCatch("Yearly Interest Rate (example 5.6 for 5.6%): ", 0m, 100m);
        decimal yearlyRateDecimal = yearlyRatePercent / 100m;

        int years = ReadIntTryCatch("Years (to payback loan): ", 1, 100);
        int paymentsPerYear = ReadIntTryCatch("Payments per year (use 12 for monthly): ", 1, 365); // assignment suggests 12 

        int totalPayments = years * paymentsPerYear; 
        decimal periodicRate = yearlyRateDecimal / paymentsPerYear; 

        decimal regularPayment = CalculatePMT(loanAmount, periodicRate, totalPayments);
        regularPayment = Round2(regularPayment);

        Console.WriteLine();
        Console.WriteLine("Input Items to Generate Loan Repayment Schedule:");
        Console.WriteLine($"Loan Amount:           {loanAmount:C}");
        Console.WriteLine($"Yearly Interest Rate:  {yearlyRatePercent}% ({yearlyRateDecimal})");
        Console.WriteLine($"Years:                 {years}");
        Console.WriteLine($"Payments per year:     {paymentsPerYear}");
        Console.WriteLine();
        Console.WriteLine($"Total Payments:        {totalPayments}");
        Console.WriteLine($"Periodic Payment:      {regularPayment:C}");
        Console.WriteLine();

        Console.WriteLine("Loan Repayment Schedule");
        Console.WriteLine();
        Console.WriteLine($"{"Payment Num",11}  {"Date",10}  {"Payment",12}  {"Interest",12}  {"Principal",12}  {"Balance",14}");

        decimal balance = loanAmount; // running balance 
        decimal totalPaid = 0m;
        decimal totalInterestPaid = 0m;

        // Date handling: start today, then advance each period before printing each payment line 
        DateTime startDate = DateTime.Today;

        // Line 0 like the example shows $0 and full balance 
        PrintLine(0, startDate, 0m, 0m, 0m, balance);

        DateTime payDate = startDate;

        for (int paymentNum = 1; paymentNum <= totalPayments; paymentNum++)
        {
            payDate = AddOnePeriod(payDate, paymentsPerYear);

            // Interest = balance * (yearlyRate / paymentsPerYear) 
            decimal interest = Round2(balance * periodicRate);

            // Principal = payment - interest 
            decimal payment = regularPayment;
            decimal principal = Round2(payment - interest);

            // Adjust last payment if rounding would overpay and make balance negative
            if (principal > balance)
            {
                principal = balance;
                payment = Round2(interest + principal);
            }

            // Update balance = balance - principal 
            balance = Round2(balance - principal);

            totalPaid += payment;
            totalInterestPaid += interest;

            PrintLine(paymentNum, payDate, payment, interest, principal, balance);

            if (balance <= 0m)
                break;
        }

        Console.WriteLine();
        Console.WriteLine($"Total Payment:  {totalPaid:C}");     // print totals at bottom 
        Console.WriteLine($"Total Interest: {totalInterestPaid:C}");
    }

    // PMT function from the assignment formula 
    static decimal CalculatePMT(decimal pv, decimal r, int n)
    {
        if (n <= 0) return 0m;

        if (r == 0m)
        {
            return pv / n;
        }

        double pvD = (double)pv;
        double rD = (double)r;
        double nD = n;

        // P = (Pv * R) / [1 - (1 + R)^(-n)]
        double denom = 1.0 - Math.Pow(1.0 + rD, -nD);
        double pmt = (pvD * rD) / denom;

        return (decimal)pmt;
    }

    static DateTime AddOnePeriod(DateTime current, int paymentsPerYear)
    {
        // Best for monthly or quarterly etc
        if (12 % paymentsPerYear == 0)
        {
            int monthsPerPayment = 12 / paymentsPerYear; // ex 12 -> 1 month
            return current.AddMonths(monthsPerPayment);
        }

        // Fallback for odd frequencies
        double daysPerPayment = 365.0 / paymentsPerYear;
        return current.AddDays(daysPerPayment);
    }

    static void PrintLine(int num, DateTime date, decimal payment, decimal interest, decimal principal, decimal balance)
    {
        Console.WriteLine($"{num,11}  {date,10:MM/dd/yyyy}  {payment,12:C}  {interest,12:C}  {principal,12:C}  {balance,14:C}");
    }

    static decimal Round2(decimal value) => Math.Round(value, 2, MidpointRounding.AwayFromZero);

    static int ReadIntTryCatch(string prompt, int min, int max)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine() ?? "";

            try
            {
                int value = int.Parse(input, NumberStyles.Integer, CultureInfo.CurrentCulture);
                if (value < min || value > max)
                {
                    Console.WriteLine($"Please enter a whole number from {min} to {max}.");
                    continue;
                }
                return value;
            }
            catch
            {
                Console.WriteLine("Invalid input. Please enter a whole number.");
            }
        }
    }

    static decimal ReadDecimalTryCatch(string prompt, decimal min, decimal max)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine() ?? "";

            try
            {
                decimal value = decimal.Parse(input, NumberStyles.Number | NumberStyles.AllowCurrencySymbol, CultureInfo.CurrentCulture);
                if (value < min || value > max)
                {
                    Console.WriteLine($"Please enter a value from {min} to {max}.");
                    continue;
                }
                return value;
            }
            catch
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }
    }
}
