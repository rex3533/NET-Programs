//Glaycon Cezarotto 2/27/26
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

class Program
{
    // Record data structure (struct)
    public struct CarRecord
    {
        public int Id;               // Primary key
        public string Name;          // String field (sort ascending)
        public double Mpg;           // Numeric field #1 (sum)
        public int Cylinders;
        public int Displacement;
        public int Horsepower;       // Numeric field #2 (find largest)
        public int Weight;           // Numeric field (sort descending)
        public double Acceleration;
        public int ModelYear;
        public string Origin;

        public CarRecord(int id, string name, double mpg, int cylinders, int displacement,
            int horsepower, int weight, double acceleration, int modelYear, string origin)
        {
            Id = id;
            Name = name;
            Mpg = mpg;
            Cylinders = cylinders;
            Displacement = displacement;
            Horsepower = horsepower;
            Weight = weight;
            Acceleration = acceleration;
            ModelYear = modelYear;
            Origin = origin;
        }
    }

    static void Main()
    {
        Console.WriteLine("Programming Assignment 3");
        Console.WriteLine("Loading records from data file...\n");

        string dataPath = @"D:\NetPrograms\NET-Programs\Week4\data.txt";
        if (dataPath == null)
        {
            Console.WriteLine("ERROR: Could not find data.txt.");
            Console.WriteLine("Fix: Put data.txt in the project folder OR in the build output folder (bin/Debug/...)\n");
            return;
        }

        List<CarRecord> table = LoadRecords(dataPath);
        Console.WriteLine($"Loaded {table.Count} records from: {dataPath}\n");

        // Menu loop (execute methods or quit)
        while (true)
        {
            PrintMenu();
            int choice = ReadInt("Choose an option: ");

            Console.WriteLine();

            switch (choice)
            {
                case 0:
                    Console.WriteLine("Goodbye.");
                    return;

                case 1:
                    DeleteFirstRecord(table);
                    break;

                case 2:
                    double mpgSum = SumField_Mpg(table);
                    Console.WriteLine($"Sum of MPG (first numeric field chosen): {mpgSum:F2}");
                    break;

                case 3:
                    int loc = FindLargestHorsepowerLocation(table);
                    if (loc == -1)
                    {
                        Console.WriteLine("No records in table.");
                    }
                    else
                    {
                        Console.WriteLine("Largest Horsepower Record (location returned to Main):");
                        PrintHeader();
                        PrintRecord(table[loc]);
                    }
                    break;

                case 4:
                    SortByNameAscending(table);
                    Console.WriteLine("Sorted by Name (ascending).");
                    break;

                case 5:
                    SortByWeightDescending(table);
                    Console.WriteLine("Sorted by Weight (descending).");
                    break;

                case 6:
                    WriteReportFile(table, "report.txt");
                    Console.WriteLine("Report written to report.txt");
                    break;

                case 7:
                    DeleteUsingKey(table);
                    break;

                case 8:
                    AddNewRecord(table);
                    break;

                case 9:
                    DisplayAllRecords(table);
                    break;

                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }

            Console.WriteLine();
        }
    }

    // ---------------- MENU ----------------

    static void PrintMenu()
    {
        Console.WriteLine("Menu");
        Console.WriteLine("1) Delete first record");
        Console.WriteLine("2) Sum MPG (numeric field)");
        Console.WriteLine("3) Find largest Horsepower and print record");
        Console.WriteLine("4) Sort by Name ascending");
        Console.WriteLine("5) Sort by Weight descending");
        Console.WriteLine("6) Print report file (report.txt)");
        Console.WriteLine("7) Delete record using primary key");
        Console.WriteLine("8) Add new record using primary key");
        Console.WriteLine("9) Display all records");
        Console.WriteLine("0) Quit");
    }

    // ---------------- FILE LOAD ----------------

    static string FindDataFilePath(string fileName)
    {
        // Try current directory
        string p1 = Path.Combine(Directory.GetCurrentDirectory(), fileName);
        if (File.Exists(p1)) return p1;

        // Try app base directory (bin/Debug/netX.Y)
        string p2 = Path.Combine(AppContext.BaseDirectory, fileName);
        if (File.Exists(p2)) return p2;

        return null;
    }

    static List<CarRecord> LoadRecords(string path)
    {
        var list = new List<CarRecord>();
        foreach (string line in File.ReadAllLines(path))
        {
            if (string.IsNullOrWhiteSpace(line)) continue;

            // Split on whitespace (tabs or spaces)
            string[] parts = line.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            // Expected fields:
            // id name mpg cylinders displacement horsepower weight acceleration year origin
            if (parts.Length < 10) continue;

            int id = int.Parse(parts[0]);
            string name = parts[1];
            double mpg = double.Parse(parts[2], CultureInfo.InvariantCulture);
            int cylinders = int.Parse(parts[3]);
            int displacement = int.Parse(parts[4]);
            int horsepower = int.Parse(parts[5]);
            int weight = int.Parse(parts[6]);
            double acceleration = double.Parse(parts[7], CultureInfo.InvariantCulture);
            int year = int.Parse(parts[8]);
            string origin = parts[9];

            list.Add(new CarRecord(id, name, mpg, cylinders, displacement, horsepower, weight, acceleration, year, origin));
        }
        return list;
    }

    // ---------------- METHOD 6.1 ----------------

static void DeleteFirstRecord(List<CarRecord> table)
{
    if (table.Count == 0)
    {
        Console.WriteLine("Table is empty. Nothing to delete.");
        return;
    }

    Console.WriteLine("First record is:");
    PrintHeader();
    PrintRecord(table[0]);

    Console.Write("Are you sure you want to delete the first record? (Y/N): ");
    string ans = (Console.ReadLine() ?? "").Trim().ToUpperInvariant();

    if (ans == "Y")
    {
        var removed = table[0];
        table.RemoveAt(0);
        Console.WriteLine($"Deleted. (ID {removed.Id}, {removed.Name})");
    }
    else
    {
        Console.WriteLine("Delete cancelled.");
    }
}
    // ---------------- METHOD 6.2 ----------------

    static double SumField_Mpg(List<CarRecord> table)
    {
        double sum = 0;
        foreach (var r in table) sum += r.Mpg;
        return sum;
    }

    // ---------------- METHOD 6.3 ----------------

    static int FindLargestHorsepowerLocation(List<CarRecord> table)
    {
        if (table.Count == 0) return -1;

        int bestLoc = 0;
        int bestHp = table[0].Horsepower;

        for (int i = 1; i < table.Count; i++)
        {
            if (table[i].Horsepower > bestHp)
            {
                bestHp = table[i].Horsepower;
                bestLoc = i;
            }
        }

        return bestLoc;
    }

    // ---------------- METHOD 6.4 ----------------

    static void SortByNameAscending(List<CarRecord> table)
    {
        table.Sort((a, b) => string.Compare(a.Name, b.Name, StringComparison.OrdinalIgnoreCase));
    }

    // ---------------- METHOD 6.5 ----------------

    static void SortByWeightDescending(List<CarRecord> table)
    {
        table.Sort((a, b) => b.Weight.CompareTo(a.Weight));
    }

    // ---------------- METHOD 6.6 ----------------

    static void WriteReportFile(List<CarRecord> table, string reportFileName)
    {
        using var writer = new StreamWriter(reportFileName);

        WriteCenteredLine(writer, "PROGRAMMING ASSIGNMENT 3 REPORT", 100);
        writer.WriteLine();

        writer.WriteLine(
            $"{Pad("ID", 4)}" +
            $"{Pad("Name", 28)}" +
            $"{Pad("MPG", 8)}" +
            $"{Pad("Cyl", 6)}" +
            $"{Pad("Disp", 7)}" +
            $"{Pad("HP", 6)}" +
            $"{Pad("Weight", 8)}" +
            $"{Pad("Accel", 8)}" +
            $"{Pad("Year", 6)}" +
            $"{Pad("Origin", 10)}"
        );

        writer.WriteLine(new string('-', 95));

        foreach (var r in table)
        {
            writer.WriteLine(FormatRecord(r));
        }
    }

    static void WriteCenteredLine(StreamWriter writer, string text, int width)
    {
        if (text.Length >= width)
        {
            writer.WriteLine(text);
            return;
        }
        int left = (width - text.Length) / 2;
        writer.WriteLine(new string(' ', left) + text);
    }

    static string Pad(string s, int width) => s.PadRight(width);

    // ---------------- METHOD 6.7 ----------------

    static void DeleteUsingKey(List<CarRecord> table)
    {
        int key = ReadInt("Enter the primary key (ID) to delete: ");

        int loc = FindRecordUsingKey(table, key);

        if (loc == -1)
        {
            Console.WriteLine("Record not found. Nothing deleted.");
            return;
        }

        Console.WriteLine("Record found:");
        PrintHeader();
        PrintRecord(table[loc]);

        Console.Write("Are you sure you want to permanently delete this record? (Y/N): ");
        string ans = (Console.ReadLine() ?? "").Trim().ToUpperInvariant();

        if (ans == "Y")
        {
            DeleteRecordAtAddressLocation(table, loc);
            Console.WriteLine("Record deleted.");
        }
        else
        {
            Console.WriteLine("Delete cancelled.");
        }
    }

    static int FindRecordUsingKey(List<CarRecord> table, int key)
    {
        for (int i = 0; i < table.Count; i++)
        {
            if (table[i].Id == key) return i;
        }
        return -1;
    }

    static void DeleteRecordAtAddressLocation(List<CarRecord> table, int loc)
    {
        if (loc < 0 || loc >= table.Count) return;
        table.RemoveAt(loc);
    }

    // ---------------- METHOD 6.8 ----------------

    static void AddNewRecord(List<CarRecord> table)
    {
        while (true)
        {
            int newId = ReadInt("Enter new primary key (ID): ");
            if (FindRecordUsingKey(table, newId) != -1)
            {
                Console.WriteLine("That key is already in use. Try a new one or type 0 to cancel.");
                if (newId == 0) return;
                continue;
            }

            string name = ReadString("Enter Name (no spaces, use dashes like the file): ");
            double mpg = ReadDouble("Enter MPG: ");
            int cylinders = ReadInt("Enter Cylinders: ");
            int displacement = ReadInt("Enter Displacement: ");
            int horsepower = ReadInt("Enter Horsepower: ");
            int weight = ReadInt("Enter Weight: ");
            double acceleration = ReadDouble("Enter Acceleration: ");
            int year = ReadInt("Enter Model Year: ");
            string origin = ReadString("Enter Origin: ");

            // Basic validation
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(origin))
            {
                Console.WriteLine("Invalid string field. Cancelled.");
                return;
            }

            var newRec = new CarRecord(newId, name, mpg, cylinders, displacement, horsepower, weight, acceleration, year, origin);

            Console.WriteLine("\nNew Record Preview:");
            PrintHeader();
            PrintRecord(newRec);

            Console.Write("Add this record permanently? (Y/N): ");
            string ans = (Console.ReadLine() ?? "").Trim().ToUpperInvariant();

            if (ans == "Y")
            {
                table.Add(newRec);
                Console.WriteLine("Record added.");
            }
            else
            {
                Console.WriteLine("Add cancelled.");
            }

            return;
        }
    }

    // ---------------- METHOD 6.9 ----------------

    static void DisplayAllRecords(List<CarRecord> table)
    {
        if (table.Count == 0)
        {
            Console.WriteLine("No records to display.");
            return;
        }

        PrintHeader();
        foreach (var r in table)
        {
            PrintRecord(r);
        }
        Console.WriteLine($"\nTotal records: {table.Count}");
    }

    // ---------------- PRINTING ----------------

    static void PrintHeader()
    {
        Console.WriteLine(
            $"{ "ID",4}" +
            $"{ "Name",-28}" +
            $"{ "MPG",8}" +
            $"{ "Cyl",6}" +
            $"{ "Disp",7}" +
            $"{ "HP",6}" +
            $"{ "Weight",8}" +
            $"{ "Accel",8}" +
            $"{ "Year",6}" +
            $"{ "Origin",-10}"
        );
        Console.WriteLine(new string('-', 95));
    }

    static void PrintRecord(CarRecord r)
    {
        Console.WriteLine(FormatRecord(r));
    }

    static string FormatRecord(CarRecord r)
    {
        return
            $"{r.Id,4}" +
            $"{r.Name,-28}" +
            $"{r.Mpg,8:F1}" +
            $"{r.Cylinders,6}" +
            $"{r.Displacement,7}" +
            $"{r.Horsepower,6}" +
            $"{r.Weight,8}" +
            $"{r.Acceleration,8:F1}" +
            $"{r.ModelYear,6}" +
            $"{r.Origin,-10}";
    }

    // ---------------- INPUT HELPERS (try catch) ----------------

    static int ReadInt(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string s = Console.ReadLine() ?? "";
            try
            {
                return int.Parse(s, CultureInfo.CurrentCulture);
            }
            catch
            {
                Console.WriteLine("Invalid whole number. Try again.");
            }
        }
    }

    static double ReadDouble(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string s = Console.ReadLine() ?? "";
            try
            {
                // Accept both 22.4 format (Invariant) and local decimal style
                if (double.TryParse(s, NumberStyles.Float, CultureInfo.CurrentCulture, out double v1)) return v1;
                return double.Parse(s, NumberStyles.Float, CultureInfo.InvariantCulture);
            }
            catch
            {
                Console.WriteLine("Invalid number. Try again.");
            }
        }
    }

    static string ReadString(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string s = (Console.ReadLine() ?? "").Trim();
            if (!string.IsNullOrWhiteSpace(s)) return s;
            Console.WriteLine("Invalid text. Try again.");
        }
    }
}