// Glaycon Cezarotto 3/6/2026
using System;

public class ProgramAssignment4
{
    public static void Main(string[] args)
    {
        // Create objects using the assignment data
        SalaryWorker emp1 = new SalaryWorker(123, "Martha", "Perez", 56785.59f);
        HourlyWorker emp2 = new HourlyWorker(435, "Joe", "Smith", 42.5f, 18.67f);
        CommissionWorker emp3 = new CommissionWorker(356, "Anthony", "Mendez", 30563.56f, 0.003f, 57864.53f);
        PieceWorker emp4 = new PieceWorker(452, "Jimmy", "James", 0.50f, 1201);

        Console.WriteLine("PROGRAMMING ASSIGNMENT 4A");
        Console.WriteLine("Employee Base Class and Subclasses");
        Console.WriteLine();

        // Show displayData() results
        Console.WriteLine("DISPLAYDATA OUTPUT");
        Console.WriteLine("--------------------------------------------------------------------------------");
        Console.WriteLine("SalaryWorker:");
        Console.WriteLine(emp1.displayData());
        Console.WriteLine();

        Console.WriteLine("HourlyWorker:");
        Console.WriteLine(emp2.displayData());
        Console.WriteLine();

        Console.WriteLine("CommissionWorker:");
        Console.WriteLine(emp3.displayData());
        Console.WriteLine();

        Console.WriteLine("PieceWorker:");
        Console.WriteLine(emp4.displayData());
        Console.WriteLine();

        // Polymorphism test
        Employee[] workers = new Employee[4];
        workers[0] = emp1;
        workers[1] = emp2;
        workers[2] = emp3;
        workers[3] = emp4;

        Console.WriteLine("EARNINGS OUTPUT USING POLYMORPHISM");
        Console.WriteLine("--------------------------------------------------------------------------------");
        Console.WriteLine($"{"Type",-18}{"ID",-8}{"First",-15}{"Last",-15}{"Weekly Pay",12}");
        Console.WriteLine("--------------------------------------------------------------------------------");

        foreach (Employee worker in workers)
        {
            Console.WriteLine(worker.earnings());
        }

        Console.WriteLine();
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}