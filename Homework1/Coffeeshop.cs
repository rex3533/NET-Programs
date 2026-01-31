using System;
using System.Collections.Generic;
using System.Globalization;

class Program
{
    private const decimal SALES_TAX_RATE = 0.08m;

    static void Main()
    {
        Console.WriteLine("Welcome to the Coffee Shop!\n");

        int itemCount = ReadInt("How many different items are in the order? ", minValue: 1);

        var items = new List<LineItem>();

        for (int i = 1; i <= itemCount; i++)
        {
            string name = ReadRequiredString($"Enter the name of item #{i}: ");
            decimal price = ReadDecimal($"Enter the price of the {name}: $", minValue: 0m);
            int qty = ReadInt($"Enter the quantity of the {name}: ", minValue: 0);

            items.Add(new LineItem(name, price, qty));
            Console.WriteLine();
        }

        decimal subtotal = 0m;
        foreach (var item in items)
            subtotal += item.Total;

        decimal tax = subtotal * SALES_TAX_RATE;
        decimal finalTotal = subtotal + tax;

        // Print Receipt
        Console.WriteLine("Receipt:");
        Console.WriteLine(new string('-', 50));
        Console.WriteLine($"{ "Item",-18}{ "Quantity",10}{ "Price",10}{ "Total",12}");
        Console.WriteLine(new string('-', 50));

        foreach (var item in items)
        {
            Console.WriteLine($"{ Truncate(item.Name, 18),-18}{ item.Quantity,10}{ item.Price,10:C}{ item.Total,12:C}");
        }

        Console.WriteLine(new string('-', 50));
        Console.WriteLine($"{ "Subtotal:",-38}{ subtotal,12:C}");
        Console.WriteLine($"{ $"Sales Tax ({SALES_TAX_RATE:P0}):",-38}{ tax,12:C}");
        Console.WriteLine($"{ "Final Total:",-38}{ finalTotal,12:C}");
        Console.WriteLine(new string('-', 50));
    }

    static string ReadRequiredString(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string s = (Console.ReadLine() ?? "").Trim();
            if (!string.IsNullOrWhiteSpace(s)) return s;
            Console.WriteLine("Please enter a non-empty value.");
        }
    }

    static int ReadInt(string prompt, int? minValue = null)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine() ?? "";

            if (int.TryParse(input, out int value))
            {
                if (minValue.HasValue && value < minValue.Value)
                {
                    Console.WriteLine($"Please enter a whole number >= {minValue.Value}.");
                    continue;
                }
                return value;
            }

            Console.WriteLine("Invalid whole number. Try again.");
        }
    }

    static decimal ReadDecimal(string prompt, decimal? minValue = null)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine() ?? "";

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

    static string Truncate(string s, int maxLen)
    {
        if (s.Length <= maxLen) return s;
        return s.Substring(0, maxLen - 3) + "...";
    }

    record LineItem(string Name, decimal Price, int Quantity)
    {
        public decimal Total => Price * Quantity;
    }
}
