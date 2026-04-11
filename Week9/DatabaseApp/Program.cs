using System;
using Microsoft.Data.SqlClient;

namespace ComputerSoftwareDatabaseApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString =
                "Server=LAPTOP-ASVRGMFS\\SQLEXPRESS01;Database=Computer_Software;Trusted_Connection=True;TrustServerCertificate=True;";

            try
            {
                using SqlConnection conn = new SqlConnection(connectionString);
                conn.Open();

                Console.WriteLine("Connected to Computer_Software database.");
                Console.WriteLine();

                DisplayTable(conn, "Computer", "SELECT * FROM Computer");
                DisplayTable(conn, "Employee", "SELECT * FROM Employee");
                DisplayTable(conn, "PC", "SELECT * FROM PC");
                DisplayTable(conn, "Package", "SELECT * FROM [Package]");
                DisplayTable(conn, "Software", "SELECT * FROM Software");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error connecting to database.");
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

static void DisplayTable(SqlConnection conn, string tableName, string query)
{
    Console.WriteLine("========================================");
    Console.WriteLine(tableName.ToUpper());
    Console.WriteLine("========================================");

    using SqlCommand cmd = new SqlCommand(query, conn);
    using SqlDataReader reader = cmd.ExecuteReader();

    if (!reader.HasRows)
    {
        Console.WriteLine("No data found.");
        Console.WriteLine();
        return;
    }

    int columnWidth = 20;

    for (int i = 0; i < reader.FieldCount; i++)
    {
        Console.Write(reader.GetName(i).PadRight(columnWidth));
    }
    Console.WriteLine();

    Console.WriteLine(new string('-', reader.FieldCount * columnWidth));

    while (reader.Read())
    {
        for (int i = 0; i < reader.FieldCount; i++)
        {
            string value;

            if (reader[i] == DBNull.Value)
            {
                value = "";
            }
            else if (reader[i] is DateTime dateValue)
            {
                value = dateValue.ToShortDateString();
            }
            else
            {
                value = reader[i]?.ToString() ?? "";
            }

            Console.Write(value.PadRight(columnWidth));
        }
        Console.WriteLine();
    }

    Console.WriteLine();
        }
    }
}