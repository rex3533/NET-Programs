using System;
using System.Collections.Generic;
using System.Globalization;

class Program
{
    // Illinois flat income tax
    private const decimal IL_TAX_RATE = 0.0495m;

    static void Main()
    {
        Console.WriteLine("=== Payroll Processor (Illinois 4.95% Tax) ===");
        Console.WriteLine("Enter employees one by one. Press ENTER on name to finish.\n");

        var employees = new List<Employee>();

        while (true)
        {
            string name = ReadNonNullString("Employee name (blank to finish): ").Trim();
            if (string.IsNullOrWhiteSpace(name))
                break;

            decimal payRate = ReadDecimal("Pay rate: $", minValue: 0m);
            decimal hours = ReadDecimal("Hours worked: ", minValue: 0m);

            decimal gross = payRate * hours;
            decimal taxes = gross * IL_TAX_RATE;
            decimal net = gross - taxes;

            employees.Add(new Employee(name, payRate, hours, gross, taxes, net));

            Console.WriteLine("\nEmployee Pay Summary");
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Gross Pay: {gross.ToString("C", CultureInfo.CurrentCulture)}");
            Console.WriteLine($"Taxes Withheld (4.95%): {taxes.ToString("C", CultureInfo.CurrentCulture)}");
            Console.WriteLine($"Net Pay: {net.ToString("C", CultureInfo.CurrentCulture)}");
            Console.WriteLine("----------------------------------------------\n");
        }

        // Totals
        decimal totalGross = 0m, totalTaxes = 0m, totalNet = 0m;
        foreach (var e in employees)
        {
            totalGross += e.Gross;
            totalTaxes += e.Taxes;
            totalNet += e.Net;
        }

        Console.WriteLine("\n=== Payroll Disbursement Report ===");
        if (employees.Count == 0)
        {
            Console.WriteLine("No employees entered.");
            return;
        }

        Console.WriteLine(new string('-', 70));
        Console.WriteLine($"{ "Employee",-25}{ "Gross",15}{ "Taxes",15}{ "Net",15}");
        Console.WriteLine(new string('-', 70));

        foreach (var e in employees)
        {
            Console.WriteLine($"{ e.Name,-25}{ e.Gross,15:C}{ e.Taxes,15:C}{ e.Net,15:C}");
        }

        Console.WriteLine(new string('-', 70));
        Console.WriteLine($"{ "TOTALS",-25}{ totalGross,15:C}{ totalTaxes,15:C}{ totalNet,15:C}");
        Console.WriteLine(new string('-', 70));
    }

    static string ReadNonNullString(string prompt)
    {
        Console.Write(prompt);
        return Console.ReadLine() ?? "";
    }

    static decimal ReadDecimal(string prompt, decimal? minValue = null)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine() ?? "";

            // Allow things like $3.50 too
            if (decimal.TryParse(input, NumberStyles.Currency, CultureInfo.CurrentCulture, out decimal value))
            {
                if (minValue.HasValue && value < minValue.Value)
                {
                    Console.WriteLine($"Please enter a number >= {minValue.Value}.");
                    continue;
                }
                return value;
            }

            Console.WriteLine("Invalid number. Try again.");
        }
    }

    record Employee(string Name, decimal PayRate, decimal Hours, decimal Gross, decimal Taxes, decimal Net);
}
