//Glaycon Cezarotto 2/5/2026
using System;
using System.Globalization;

class Program
{
    static void Main()
    {
        Console.WriteLine("Credit Card Limit Calculator");
        Console.WriteLine();

        int age = ReadIntTryCatch("Enter Age: ", min: 0);
        decimal yearsAddress = ReadDecimalTryCatch("Enter years at current address: ", min: 0m);
        decimal income = ReadDecimalTryCatch("Enter Annual Income: ", min: 0m);
        decimal yearsJob = ReadDecimalTryCatch("Enter years at current Job: ", min: 0m);

        int points = 0;
        points += AgePoints(age);
        points += AddressPoints(yearsAddress);
        points += IncomePoints(income);
        points += JobPoints(yearsJob);

        Console.WriteLine();
        Console.WriteLine(CreditDecision(points));
    }

    static int AgePoints(int age)
    {
        if (age <= 20) return -10;
        if (age <= 30) return 0;
        if (age <= 50) return 20;
        return 25;
    }

    static int AddressPoints(decimal years)
    {
        if (years < 1m) return -5;
        if (years <= 3m) return 5;
        if (years <= 8m) return 12;
        return 20;
    }

    static int IncomePoints(decimal income)
    {
        if (income <= 15000m) return 0;
        if (income <= 25000m) return 12;
        if (income <= 40000m) return 24;
        return 30;
    }

    static int JobPoints(decimal years)
    {
        if (years < 2m) return -4;
        if (years <= 4m) return 8;
        return 15;
    }

    static string CreditDecision(int points)
    {
        if (points <= 20) return "No Card issued";
        if (points <= 35) return "Card issued with $500 credit limit";
        if (points <= 60) return "Card issued with $2000 credit limit";
        return "Card issued with $5000 credit limit";
    }

    static int ReadIntTryCatch(string prompt, int min)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine() ?? "";

            try
            {
                int value = int.Parse(input, NumberStyles.Integer, CultureInfo.CurrentCulture);
                if (value < min)
                {
                    Console.WriteLine($"Please enter a value that is at least {min}.");
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

    static decimal ReadDecimalTryCatch(string prompt, decimal min)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine() ?? "";

            try
            {
                decimal value = decimal.Parse(input, NumberStyles.Number | NumberStyles.AllowCurrencySymbol, CultureInfo.CurrentCulture);
                if (value < min)
                {
                    Console.WriteLine($"Please enter a value that is at least {min}.");
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
