//Glaycon Cezarotto 2/5/2026
using System;
using System.Globalization;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Tax Payable Calculator ===");

        try
        {
            Console.Write("Enter taxable income: $");
            string input = Console.ReadLine();

            // Convert input to decimal (throws if invalid)
            decimal income = Convert.ToDecimal(input);

            if (income < 0)
            {
                Console.WriteLine("Error: Income cannot be negative.");
                return;
            }

            decimal tax = CalculateTax(income);

            Console.WriteLine($"Tax Payable: {tax.ToString("C", CultureInfo.CurrentCulture)}");
        }
        catch (FormatException)
        {
            Console.WriteLine("Error: Invalid input. Please enter a valid number (example: 25000 or 25000.50).");
        }
        catch (OverflowException)
        {
            Console.WriteLine("Error: The number entered is too large.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected error: {ex.Message}");
        }
    }

    static decimal CalculateTax(decimal income)
    {
        // Brackets:
        // 1.00 to 4461.99 => 0
        // 4462.00 to 17893.99 => 0 + 0.30 * (income - 4462.00)
        // 17894.00 to 29499.99 => 4119.00 + 0.35 * (income - 17894.00)
        // 29500.00 to 45787.99 => 8656.00 + 0.46 * (income - 29500.00)
        // 45788.00 and over => 11179.00 + 0.60 * (income - 45788.00)

        if (income < 1.00m)
        {
            // Not specified by the table, but safe handling
            return 0.00m;
        }
        else if (income <= 4461.99m)
        {
            return 0.00m;
        }
        else if (income <= 17893.99m)
        {
            return 0.00m + 0.30m * (income - 4462.00m);
        }
        else if (income <= 29499.99m)
        {
            return 4119.00m + 0.35m * (income - 17894.00m);
        }
        else if (income <= 45787.99m)
        {
            return 8656.00m + 0.46m * (income - 29500.00m);
        }
        else
        {
            return 11179.00m + 0.60m * (income - 45788.00m);
        }
    }
}
