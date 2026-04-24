using System.Globalization;
using Microsoft.EntityFrameworkCore;

namespace PA8ItemApp
{
    public class Item
    {
        public int Id { get; set; }
        public string ItemNum { get; set; } = "";
        public string Description { get; set; } = "";
        public int OnHand { get; set; }
        public string Category { get; set; } = "";
        public int Storehouse { get; set; }
        public decimal Price { get; set; }

        public override string ToString()
        {
            return $"{ItemNum,-8} {Description,-32} {OnHand,6} {Category,-6} {Storehouse,10} {Price,10:C}";
        }
    }

    internal class ItemDbContext : DbContext
    {
        public DbSet<Item> Items => Set<Item>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=LAPTOP-ASVRGMFS\SQLEXPRESS01;Database=PA8ItemDb;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>()
                .HasIndex(i => i.ItemNum)
                .IsUnique();

            modelBuilder.Entity<Item>()
                .Property(i => i.ItemNum)
                .HasMaxLength(10)
                .IsRequired();

            modelBuilder.Entity<Item>()
                .Property(i => i.Description)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Item>()
                .Property(i => i.Category)
                .HasMaxLength(10)
                .IsRequired();

            modelBuilder.Entity<Item>()
                .Property(i => i.Price)
                .HasColumnType("decimal(10,2)");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            using (ItemDbContext context = new ItemDbContext())
            {
                AddItems(context);

                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("Main Menu");
                    Console.WriteLine("S. Show the Records");
                    Console.WriteLine("A. Add New Record");
                    Console.WriteLine("U. Update a Record");
                    Console.WriteLine("D. Delete a Record");
                    Console.WriteLine("R. Remove All Records");
                    Console.WriteLine("Q. Quit");
                    Console.Write("\nEnter choice: ");

                    string choice = (Console.ReadLine() ?? "").Trim().ToUpper();

                    switch (choice)
                    {
                        case "S":
                            ShowRecords(context);
                            break;
                        case "A":
                            AddNewRecord(context);
                            break;
                        case "U":
                            UpdateRecord(context);
                            break;
                        case "D":
                            DeleteRecord(context);
                            break;
                        case "R":
                            RemoveAllRecords(context);
                            break;
                        case "Q":
                            return;
                        default:
                            Console.WriteLine("Invalid choice.");
                            Pause();
                            break;
                    }
                }
            }
        }

        static void AddItems(ItemDbContext context)
        {
            if (context.Items.Any())
                return;

            List<Item> items = new List<Item>
            {
                new Item { Id = 0, ItemNum = "AH74", Description = "Patience", OnHand = 9, Category = "GME", Storehouse = 3, Price = 22.99m },
                new Item { Id = 0, ItemNum = "BR23", Description = "Skittles", OnHand = 21, Category = "GME", Storehouse = 2, Price = 29.99m },
                new Item { Id = 0, ItemNum = "CD33", Description = "Wood Block Set (48 piece)", OnHand = 36, Category = "TOY", Storehouse = 1, Price = 89.49m },
                new Item { Id = 0, ItemNum = "DL51", Description = "Classic Railway Set", OnHand = 12, Category = "TOY", Storehouse = 3, Price = 107.95m },
                new Item { Id = 0, ItemNum = "DR67", Description = "Giant Star Brain Teaser", OnHand = 24, Category = "PZL", Storehouse = 2, Price = 31.95m },
                new Item { Id = 0, ItemNum = "DW23", Description = "Mancala", OnHand = 40, Category = "GME", Storehouse = 3, Price = 50.00m },
                new Item { Id = 0, ItemNum = "FD11", Description = "Rocking Horse", OnHand = 8, Category = "TOY", Storehouse = 3, Price = 124.95m },
                new Item { Id = 0, ItemNum = "FH24", Description = "Puzzle Gift Set", OnHand = 65, Category = "PZL", Storehouse = 1, Price = 38.95m },
                new Item { Id = 0, ItemNum = "KA12", Description = "Cribbage Set", OnHand = 56, Category = "GME", Storehouse = 3, Price = 75.00m },
                new Item { Id = 0, ItemNum = "KD34", Description = "Pentominoes Brain Teaser", OnHand = 60, Category = "PZL", Storehouse = 2, Price = 14.95m },
                new Item { Id = 0, ItemNum = "KL78", Description = "Pick Up Sticks", OnHand = 110, Category = "GME", Storehouse = 1, Price = 10.95m },
                new Item { Id = 0, ItemNum = "MT03", Description = "Zauberkasten Brain Teaser", OnHand = 45, Category = "PZL", Storehouse = 1, Price = 45.79m },
                new Item { Id = 0, ItemNum = "NL89", Description = "Wood Block Set (62 piece)", OnHand = 32, Category = "TOY", Storehouse = 3, Price = 119.75m },
                new Item { Id = 0, ItemNum = "TR40", Description = "Tic Tac Toe", OnHand = 75, Category = "GME", Storehouse = 2, Price = 13.99m },
                new Item { Id = 0, ItemNum = "TW35", Description = "Fire Engine", OnHand = 30, Category = "TOY", Storehouse = 2, Price = 118.95m }
            };

            context.Items.AddRange(items);
            context.SaveChanges();
        }

        static void ShowRecords(ItemDbContext context)
        {
            Console.Clear();
            Console.WriteLine("CURRENT RECORDS\n");
            Console.WriteLine($"{"ItemNum",-8} {"Description",-32} {"OnHand",6} {"Cat",-6} {"Storehouse",10} {"Price",10}");
            Console.WriteLine(new string('-', 80));

            List<Item> items = context.Items
                .OrderBy(i => i.ItemNum)
                .ToList();

            if (items.Count == 0)
            {
                Console.WriteLine("No records found.");
            }
            else
            {
                foreach (Item item in items)
                {
                    Console.WriteLine(item);
                }
            }

            Pause();
        }

        static void AddNewRecord(ItemDbContext context)
        {
            Console.Clear();
            Console.WriteLine("ADD NEW RECORD\n");

            string itemNum = ReadRequiredString("Enter ItemNum: ").ToUpper();

            bool exists = context.Items.Any(i => i.ItemNum.ToUpper() == itemNum);
            if (exists)
            {
                Console.WriteLine("That item already exists. No action taken.");
                Pause();
                return;
            }

            string description = ReadRequiredString("Enter Description: ");
            int onHand = ReadInt("Enter OnHand: ");
            string category = ReadRequiredString("Enter Category: ").ToUpper();
            int storehouse = ReadInt("Enter Storehouse: ");
            decimal price = ReadDecimal("Enter Price: ");

            Item item = new Item
            {
                Id = 0,
                ItemNum = itemNum,
                Description = description,
                OnHand = onHand,
                Category = category,
                Storehouse = storehouse,
                Price = price
            };

            Console.WriteLine("\nNew Record:");
            Console.WriteLine(item);

            if (Confirm("Add this record"))
            {
                context.Items.Add(item);
                context.SaveChanges();
                Console.WriteLine("Record added.");
            }
            else
            {
                Console.WriteLine("Add cancelled.");
            }

            Pause();
        }

        static void UpdateRecord(ItemDbContext context)
        {
            Console.Clear();
            Console.WriteLine("UPDATE A RECORD\n");

            string itemNum = ReadRequiredString("Enter ItemNum to update: ").ToUpper();

            Item? item = context.Items.FirstOrDefault(i => i.ItemNum.ToUpper() == itemNum);

            if (item == null)
            {
                Console.WriteLine("Item not found.");
                Pause();
                return;
            }

            Console.WriteLine("\nCurrent Record:");
            Console.WriteLine(item);
            Console.WriteLine("\nUpdate Sub-Menu:");
            Console.WriteLine("D. Description");
            Console.WriteLine("O. OnHand");
            Console.WriteLine("C. Category");
            Console.WriteLine("S. Storehouse");
            Console.WriteLine("P. Price");
            Console.WriteLine("E. Exit");
            Console.Write("\nEnter choice: ");

            string choice = (Console.ReadLine() ?? "").Trim().ToUpper();

            switch (choice)
            {
                case "D":
                    item.Description = ReadRequiredString("Enter new Description: ");
                    context.SaveChanges();
                    Console.WriteLine("Description updated.");
                    break;

                case "O":
                    item.OnHand = ReadInt("Enter new OnHand: ");
                    context.SaveChanges();
                    Console.WriteLine("OnHand updated.");
                    break;

                case "C":
                    item.Category = ReadRequiredString("Enter new Category: ").ToUpper();
                    context.SaveChanges();
                    Console.WriteLine("Category updated.");
                    break;

                case "S":
                    item.Storehouse = ReadInt("Enter new Storehouse: ");
                    context.SaveChanges();
                    Console.WriteLine("Storehouse updated.");
                    break;

                case "P":
                    item.Price = ReadDecimal("Enter new Price: ");
                    context.SaveChanges();
                    Console.WriteLine("Price updated.");
                    break;

                case "E":
                    Console.WriteLine("Update cancelled.");
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }

            Pause();
        }

        static void DeleteRecord(ItemDbContext context)
        {
            Console.Clear();
            Console.WriteLine("DELETE A RECORD\n");

            string itemNum = ReadRequiredString("Enter ItemNum to delete: ").ToUpper();

            Item? item = context.Items.FirstOrDefault(i => i.ItemNum.ToUpper() == itemNum);

            if (item == null)
            {
                Console.WriteLine("Item not found. No action taken.");
                Pause();
                return;
            }

            Console.WriteLine("\nRecord to delete:");
            Console.WriteLine(item);

            if (Confirm("Delete this record"))
            {
                context.Items.Remove(item);
                context.SaveChanges();
                Console.WriteLine("Record deleted.");
            }
            else
            {
                Console.WriteLine("Delete cancelled.");
            }

            Pause();
        }

        static void RemoveAllRecords(ItemDbContext context)
        {
            Console.Clear();
            Console.WriteLine("REMOVE ALL RECORDS\n");

            List<Item> items = context.Items
                .OrderBy(i => i.ItemNum)
                .ToList();

            if (items.Count == 0)
            {
                Console.WriteLine("No records found.");
                Pause();
                return;
            }

            Console.WriteLine($"{"ItemNum",-8} {"Description",-32} {"OnHand",6} {"Cat",-6} {"Storehouse",10} {"Price",10}");
            Console.WriteLine(new string('-', 80));

            foreach (Item item in items)
            {
                Console.WriteLine(item);
            }

            if (Confirm("\nRemove all records"))
            {
                context.Items.RemoveRange(items);
                context.SaveChanges();
                Console.WriteLine("All records removed.");
            }
            else
            {
                Console.WriteLine("Remove all cancelled.");
            }

            Pause();
        }

        static string ReadRequiredString(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string value = (Console.ReadLine() ?? "").Trim();

                if (!string.IsNullOrWhiteSpace(value))
                    return value;

                Console.WriteLine("Value cannot be blank.");
            }
        }

        static int ReadInt(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = (Console.ReadLine() ?? "").Trim();

                if (int.TryParse(input, out int value))
                    return value;

                Console.WriteLine("Please enter a valid integer.");
            }
        }

        static decimal ReadDecimal(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = (Console.ReadLine() ?? "").Trim();

                if (decimal.TryParse(input, NumberStyles.Currency, CultureInfo.CurrentCulture, out decimal value))
                    return value;

                if (decimal.TryParse(input, NumberStyles.Currency, CultureInfo.InvariantCulture, out value))
                    return value;

                Console.WriteLine("Please enter a valid price.");
            }
        }

        static bool Confirm(string message)
        {
            Console.Write($"{message}? (Y/N): ");
            string answer = (Console.ReadLine() ?? "").Trim().ToUpper();
            return answer == "Y";
        }

        static void Pause()
        {
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}