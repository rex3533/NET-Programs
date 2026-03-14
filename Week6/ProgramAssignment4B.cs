// Glaycon Cezarotto
// Programming Assignment 4B

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

public class ProgramAssignment4B
{
    public static void Main(string[] args)
    {
        string inputFile = "employee.txt";
        string outputFile = "grosspayreport.txt";

        List<Employee> employees = new List<Employee>();

        try
        {
            if (!File.Exists(inputFile))
            {
                Console.WriteLine("Input file not found: " + inputFile);
                return;
            }

            using (StreamReader sr = new StreamReader(inputFile))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    line = line.Trim();

                    if (line == "")
                        continue;

                    string[] parts = line.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

                    string empType = parts[0];

                    switch (empType)
                    {
                        case "S":
                            {
                                int id = int.Parse(parts[1]);
                                string first = parts[2];
                                string last = parts[3];
                                float yearlySalary = float.Parse(parts[4], CultureInfo.InvariantCulture);

                                employees.Add(new SalaryWorker(id, first, last, yearlySalary));
                                break;
                            }

                        case "H":
                            {
                                int id = int.Parse(parts[1]);
                                string first = parts[2];
                                string last = parts[3];
                                float hoursWorked = float.Parse(parts[4], CultureInfo.InvariantCulture);
                                float payRate = float.Parse(parts[5], CultureInfo.InvariantCulture);

                                employees.Add(new HourlyWorker(id, first, last, hoursWorked, payRate));
                                break;
                            }

                        case "C":
                            {
                                int id = int.Parse(parts[1]);
                                string first = parts[2];
                                string last = parts[3];
                                float yearlySalary = float.Parse(parts[4], CultureInfo.InvariantCulture);
                                float commRate = float.Parse(parts[5], CultureInfo.InvariantCulture);
                                float sales = float.Parse(parts[6], CultureInfo.InvariantCulture);

                                employees.Add(new CommissionWorker(id, first, last, yearlySalary, commRate, sales));
                                break;
                            }

                        case "P":
                            {
                                int id = int.Parse(parts[1]);
                                string first = parts[2];
                                string last = parts[3];
                                float wagePerPiece = float.Parse(parts[4], CultureInfo.InvariantCulture);
                                int quantity = int.Parse(parts[5]);

                                employees.Add(new PieceWorker(id, first, last, wagePerPiece, quantity));
                                break;
                            }

                        default:
                            Console.WriteLine("Invalid employee type found: " + empType);
                            break;
                    }
                }
            }

            using (StreamWriter sw = new StreamWriter(outputFile))
            {
                sw.WriteLine("Gross-pay salary report");
                sw.WriteLine();

                sw.WriteLine("{0,-20}{1,-12}{2,-15}{3,-15}{4,12}",
                    "Employee Type", "Number", "First Name", "Last Name", "Weekly Pay");

                sw.WriteLine(new string('-', 74));

                foreach (Employee emp in employees)
                {
                    sw.WriteLine(emp.earnings());
                }
            }

            Console.WriteLine("Report created successfully.");
            Console.WriteLine("Output file: " + outputFile);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}