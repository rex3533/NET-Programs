//Glaycon Cezarotto 2/20/26
using System;
using System.IO;

class Program
{
    const double GRAND_MEAN = 57.3;

    static void Main()
    {
        string filePath = @"Week3\trend.txt";

        string[] months;
        int[,] data;

        LoadData(filePath, out months, out data);

        double[] monthlyAvg = CalculateMonthlyAverages(data);              // 12 values (one per month)
        double[] monthlyDev = CalculateMonthlyDeviations(monthlyAvg);      // 12 values

        double[] yearlyAvg = CalculateYearlyAverages(data);                // 5 values (2020..2024)
        double[] yearlyDev = CalculateYearlyDeviations(yearlyAvg);         // 5 values

        double[] quarterlyDev = CalculateQuarterlyDeviations(monthlyAvg);  // 4 values (Q1..Q4)

        PrintReport(months, data, monthlyAvg, monthlyDev, quarterlyDev, yearlyAvg, yearlyDev);
    }

    // 1) Load months into 1D array, and numbers into 2D array
    static void LoadData(string filePath, out string[] months, out int[,] values)
    {
        string[] lines = File.ReadAllLines(filePath);

        months = new string[12];
        values = new int[12, 5]; // 12 months, 5 years (2020..2024)

        for (int r = 0; r < lines.Length; r++)
        {
            if (string.IsNullOrWhiteSpace(lines[r])) continue;

            string[] parts = lines[r].Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            months[r] = parts[0];

            for (int c = 0; c < 5; c++)
            {
                values[r, c] = int.Parse(parts[c + 1]);
            }
        }
    }

    // Monthly Average is the average across the 5 years for each month
    static double[] CalculateMonthlyAverages(int[,] data)
    {
        double[] avg = new double[12];

        for (int m = 0; m < 12; m++)
        {
            double sum = 0;
            for (int y = 0; y < 5; y++)
                sum += data[m, y];

            avg[m] = Math.Round(sum / 5.0, 1); // matches the sample formatting
        }

        return avg;
    }

    // Monthly Deviation = (Grand Mean - Monthly Average)^2
    static double[] CalculateMonthlyDeviations(double[] monthlyAvg)
    {
        double[] dev = new double[12];

        for (int m = 0; m < 12; m++)
        {
            double diff = GRAND_MEAN - monthlyAvg[m];
            dev[m] = Math.Round(diff * diff, 2);
        }

        return dev;
    }

    // Yearly Average is the average across the 12 months for each year column
    static double[] CalculateYearlyAverages(int[,] data)
    {
        double[] avg = new double[5];

        for (int y = 0; y < 5; y++)
        {
            double sum = 0;
            for (int m = 0; m < 12; m++)
                sum += data[m, y];

            avg[y] = Math.Round(sum / 12.0, 2); // matches the sample
        }

        return avg;
    }

    // Yearly Deviation = (Grand Mean - Yearly Average)^2
    static double[] CalculateYearlyDeviations(double[] yearlyAvg)
    {
        double[] dev = new double[5];

        for (int y = 0; y < 5; y++)
        {
            double diff = GRAND_MEAN - yearlyAvg[y];
            dev[y] = Math.Round(diff * diff, 2);
        }

        return dev;
    }

    // Quarterly Average uses the monthly averages:
    // Q1 = Jan+Feb+Mar, Q2 = Apr+May+Jun, Q3 = Jul+Aug+Sep, Q4 = Oct+Nov+Dec
    // Quarterly Deviation = (Grand Mean - Quarterly Average)^2
    static double[] CalculateQuarterlyDeviations(double[] monthlyAvg)
    {
        double[] qDev = new double[4];

        for (int q = 0; q < 4; q++)
        {
            int startMonth = q * 3;
            double qAvg = (monthlyAvg[startMonth] + monthlyAvg[startMonth + 1] + monthlyAvg[startMonth + 2]) / 3.0;
            qAvg = Math.Round(qAvg, 1);

            double diff = GRAND_MEAN - qAvg;
            qDev[q] = Math.Round(diff * diff, 2);
        }

        return qDev;
    }

    static void PrintReport(
        string[] months,
        int[,] data,
        double[] monthlyAvg,
        double[] monthlyDev,
        double[] quarterlyDev,
        double[] yearlyAvg,
        double[] yearlyDev)
    {
        Console.WriteLine("TREND-SEASONAL-NOISE ANALYSIS\n");

        Console.WriteLine(
            $"{"Month",-5}{"2020",6}{"2021",6}{"2022",6}{"2023",6}{"2024",6}" +
            $"{"Average",10}{"Deviation",12}{"Qtr Dev",10}"
        );

        for (int m = 0; m < 12; m++)
        {
            string qDevText = "";

            // show quarterly deviation only on the last month of each quarter (MAR, JUN, SEP, DEC)
            if (m == 2) qDevText = quarterlyDev[0].ToString("F2");
            if (m == 5) qDevText = quarterlyDev[1].ToString("F2");
            if (m == 8) qDevText = quarterlyDev[2].ToString("F2");
            if (m == 11) qDevText = quarterlyDev[3].ToString("F2");

            Console.WriteLine(
                $"{months[m],-5}" +
                $"{data[m, 0],6}{data[m, 1],6}{data[m, 2],6}{data[m, 3],6}{data[m, 4],6}" +
                $"{monthlyAvg[m],10:F1}{monthlyDev[m],12:F2}{qDevText,10}"
            );
        }

        Console.WriteLine("\nYearly");
        Console.WriteLine($"{"",6}{"2020",8}{"2021",8}{"2022",8}{"2023",8}{"2024",8}");
        Console.WriteLine($"{"Average",6}{yearlyAvg[0],8:F2}{yearlyAvg[1],8:F2}{yearlyAvg[2],8:F2}{yearlyAvg[3],8:F2}{yearlyAvg[4],8:F2}");
        Console.WriteLine($"{"Dev",6}{yearlyDev[0],8:F2}{yearlyDev[1],8:F2}{yearlyDev[2],8:F2}{yearlyDev[3],8:F2}{yearlyDev[4],8:F2}");
    }
}