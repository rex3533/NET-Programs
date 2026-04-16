using System;
using System.Globalization;
using System.IO;
using Microsoft.Data.SqlClient;

namespace SalesCompApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString =
                "Server=LAPTOP-ASVRGMFS\\SQLEXPRESS01;Database=SalesComp;Trusted_Connection=True;TrustServerCertificate=True;";

            string reportsFolder = Path.Combine(Environment.CurrentDirectory, "Reports");
            Directory.CreateDirectory(reportsFolder);

            try
            {
                using SqlConnection conn = new SqlConnection(connectionString);
                conn.Open();

                CreateReport1(conn, Path.Combine(reportsFolder, "Report1.txt"));
                CreateReport2(conn, Path.Combine(reportsFolder, "Report2.txt"));
                CreateReport3(conn, Path.Combine(reportsFolder, "Report3.txt"));
                CreateReport4(conn, Path.Combine(reportsFolder, "Report4.txt"));
                CreateReport5(conn, Path.Combine(reportsFolder, "Report5.txt"));

                Console.WriteLine("All reports were created successfully.");
                Console.WriteLine("Folder: " + reportsFolder);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error:");
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        static void CreateReport1(SqlConnection conn, string filePath)
        {
            string query = @"
SELECT
    c.CustCode,
    c.CustFName,
    c.CustLName,
    i.InvNumber,
    SUM(l.LineUnits * l.LinePrice) AS InvoiceTotal
FROM Customer c
INNER JOIN Invoice i ON c.CustCode = i.CustCode
INNER JOIN Line l ON i.InvNumber = l.InvNumber
GROUP BY c.CustCode, c.CustFName, c.CustLName, i.InvNumber
ORDER BY c.CustCode, i.InvNumber;";

            using SqlCommand cmd = new SqlCommand(query, conn);
            using SqlDataReader reader = cmd.ExecuteReader();
            using StreamWriter writer = new StreamWriter(filePath);

            decimal grandTotal = 0m;

            writer.WriteLine("INVOICE TOTALS PER INVOICE AND CUSTOMER");
            writer.WriteLine();
            writer.WriteLine($"{"Code",-10}{"First Name",-15}{"Last Name",-15}{"Invoice",-12}{"Total",12}");
            writer.WriteLine(new string('-', 64));

            while (reader.Read())
            {
                int custCode = Convert.ToInt32(reader["CustCode"]);
                string firstName = reader["CustFName"]?.ToString() ?? "";
                string lastName = reader["CustLName"]?.ToString() ?? "";
                int invNumber = Convert.ToInt32(reader["InvNumber"]);
                decimal invoiceTotal = Convert.ToDecimal(reader["InvoiceTotal"]);

                grandTotal += invoiceTotal;

                writer.WriteLine($"{custCode,-10}{firstName,-15}{lastName,-15}{invNumber,-12}{invoiceTotal,12:F2}");
            }

            writer.WriteLine(new string('-', 64));
            writer.WriteLine($"{"TOTALS",-52}{grandTotal,12:F2}");
        }

        static void CreateReport2(SqlConnection conn, string filePath)
        {
            string query = @"
SELECT
    i.InvNumber,
    l.LineNumber,
    p.ProdCode,
    p.ProdDescript,
    l.LineUnits,
    l.LinePrice,
    (l.LineUnits * l.LinePrice) AS LineTotal
FROM Invoice i
INNER JOIN Line l ON i.InvNumber = l.InvNumber
INNER JOIN Product p ON l.ProdCode = p.ProdCode
WHERE i.CustCode = 10011
ORDER BY i.InvNumber, l.LineNumber;";

            using SqlCommand cmd = new SqlCommand(query, conn);
            using SqlDataReader reader = cmd.ExecuteReader();
            using StreamWriter writer = new StreamWriter(filePath);

            int totalUnits = 0;
            decimal totalPrice = 0m;
            decimal totalAmount = 0m;

            writer.WriteLine("INVOICES BELONGING TO CUSTOMER WITH CODE: 10011");
            writer.WriteLine();
            writer.WriteLine($"{"Invoice",-10}{"Line",-8}{"Code",-15}{"Description",-40}{"Units",8}{"Price",10}{"Total",12}");
            writer.WriteLine(new string('-', 103));

            while (reader.Read())
            {
                int invNumber = Convert.ToInt32(reader["InvNumber"]);
                int lineNumber = Convert.ToInt32(reader["LineNumber"]);
                string prodCode = reader["ProdCode"]?.ToString() ?? "";
                string prodDesc = reader["ProdDescript"]?.ToString() ?? "";
                int lineUnits = Convert.ToInt32(reader["LineUnits"]);
                decimal linePrice = Convert.ToDecimal(reader["LinePrice"]);
                decimal lineTotal = Convert.ToDecimal(reader["LineTotal"]);

                totalUnits += lineUnits;
                totalPrice += linePrice;
                totalAmount += lineTotal;

                writer.WriteLine($"{invNumber,-10}{lineNumber,-8}{prodCode,-15}{prodDesc,-40}{lineUnits,8}{linePrice,10:F2}{lineTotal,12:F2}");
            }

            writer.WriteLine(new string('-', 103));
            writer.WriteLine($"{"TOTALS",-73}{totalUnits,8}{totalPrice,10:F2}{totalAmount,12:F2}");
        }

        static void CreateReport3(SqlConnection conn, string filePath)
        {
            string query = @"
SELECT
    VendCode,
    VendName,
    VendContact,
    VendPhone,
    VendState
FROM Vendor
WHERE VendAreaCode = '615' OR VendState = 'TN'
ORDER BY VendCode;";

            using SqlCommand cmd = new SqlCommand(query, conn);
            using SqlDataReader reader = cmd.ExecuteReader();
            using StreamWriter writer = new StreamWriter(filePath);

            writer.WriteLine("VENDORS LOCATED IN THE STATE OF TENNESSEE OR WITH AREA CODE: 615");
            writer.WriteLine();
            writer.WriteLine($"{"Vend Code",-12}{"Vend Name",-22}{"Vend Contact",-18}{"Vend Phone",-15}{"Vend State",-10}");
            writer.WriteLine(new string('-', 77));

            while (reader.Read())
            {
                int vendCode = Convert.ToInt32(reader["VendCode"]);
                string vendName = reader["VendName"]?.ToString() ?? "";
                string vendContact = reader["VendContact"]?.ToString() ?? "";
                string vendPhone = reader["VendPhone"]?.ToString() ?? "";
                string vendState = reader["VendState"]?.ToString() ?? "";

                writer.WriteLine($"{vendCode,-12}{vendName,-22}{vendContact,-18}{vendPhone,-15}{vendState,-10}");
            }
        }

        static void CreateReport4(SqlConnection conn, string filePath)
        {
            string query = @"
SELECT
    ProdCode,
    ProdDescript,
    ProdInDate,
    ProdQOH,
    ProdMin
FROM Product
WHERE ProdQOH BETWEEN ProdMin AND (ProdMin + 5)
ORDER BY ProdCode;";

            using SqlCommand cmd = new SqlCommand(query, conn);
            using SqlDataReader reader = cmd.ExecuteReader();
            using StreamWriter writer = new StreamWriter(filePath);

            writer.WriteLine("PRODUCTS WITH FIVE ITEMS OR LESS HIGHER THAN THEIR MINIMUM LEVEL");
            writer.WriteLine();
            writer.WriteLine($"{"Prod Code",-15}{"Prod Description",-40}{"Prod In Date",-15}{"Prod QOH",-12}{"Prod Min",-10}");
            writer.WriteLine(new string('-', 92));

            while (reader.Read())
            {
                string prodCode = reader["ProdCode"]?.ToString() ?? "";
                string prodDesc = reader["ProdDescript"]?.ToString() ?? "";
                string prodDate = FormatDate(reader["ProdInDate"]);
                int prodQOH = Convert.ToInt32(reader["ProdQOH"]);
                int prodMin = Convert.ToInt32(reader["ProdMin"]);

                writer.WriteLine($"{prodCode,-15}{prodDesc,-40}{prodDate,-15}{prodQOH,-12}{prodMin,-10}");
            }
        }

        static void CreateReport5(SqlConnection conn, string filePath)
        {
            string query = @"
SELECT
    p.ProdCode,
    p.ProdDescript,
    p.ProdInDate,
    p.ProdQOH
FROM Product p
WHERE NOT EXISTS
(
    SELECT 1
    FROM Line l
    WHERE l.ProdCode = p.ProdCode
)
ORDER BY p.ProdDescript;";

            using SqlCommand cmd = new SqlCommand(query, conn);
            using SqlDataReader reader = cmd.ExecuteReader();
            using StreamWriter writer = new StreamWriter(filePath);

            writer.WriteLine("PRODUCTS IN STOCK WITHOUT A PLACED ORDER");
            writer.WriteLine();
            writer.WriteLine($"{"Prod Code",-15}{"Prod Description",-40}{"Prod In Date",-15}{"Prod QOH",-10}");
            writer.WriteLine(new string('-', 80));

            while (reader.Read())
            {
                string prodCode = reader["ProdCode"]?.ToString() ?? "";
                string prodDesc = reader["ProdDescript"]?.ToString() ?? "";
                string prodDate = FormatDate(reader["ProdInDate"]);
                int prodQOH = Convert.ToInt32(reader["ProdQOH"]);

                writer.WriteLine($"{prodCode,-15}{prodDesc,-40}{prodDate,-15}{prodQOH,-10}");
            }
        }

        static string FormatDate(object dbValue)
        {
            if (dbValue == DBNull.Value)
                return "";

            DateTime date = Convert.ToDateTime(dbValue, CultureInfo.InvariantCulture);
            return date.ToString("dd-MMM-yy");
        }
    }
}