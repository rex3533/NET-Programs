using System;
using System.Collections.Generic;

namespace BuildingHierarchyAssignment
{
    public abstract class Building
    {
        protected int setdef = -3;

        private int squareFootage;
        private int floors;
        private double location;
        private decimal cost;

        protected Building()
        {
        }

        protected Building(int squareFootage, int floors, double location)
        {
            SetSquareFootage(squareFootage);
            SetFloors(floors);
            SetLocation(location);
        }

        public virtual void SetSquareFootage(int squareFootage)
        {
            this.squareFootage = squareFootage;
        }

        public virtual void SetFloors(int floors)
        {
            this.floors = floors;
        }

        public virtual void SetLocation(double location)
        {
            this.location = location;
        }

        protected void SetCost(decimal cost)
        {
            this.cost = cost;
        }

        public int GetSquareFootage()
        {
            return squareFootage;
        }

        public int GetFloors()
        {
            return floors;
        }

        public double GetLocation()
        {
            return location;
        }

        public decimal GetCost()
        {
            return cost;
        }

        protected static int CeilingHundreds(int amount)
        {
            if (amount <= 0)
            {
                return 0;
            }

            return (int)Math.Ceiling(amount / 100.0);
        }

        public abstract decimal CalculateCost();

        public override string ToString()
        {
            return "The cost of the ";
        }
    }

    public abstract class Home : Building
    {
        private int bedrooms;
        private int bathrooms;
        private int garage;

        protected Home()
        {
        }

        protected Home(
            int squareFootage,
            int floors,
            double location,
            int bedrooms,
            int bathrooms,
            int garage) : base(squareFootage, floors, location)
        {
            SetBedrooms(bedrooms);
            SetBathrooms(bathrooms);
            SetGarage(garage);
        }

        public virtual void SetBedrooms(int bedrooms)
        {
            this.bedrooms = bedrooms;
        }

        public virtual void SetBathrooms(int bathrooms)
        {
            this.bathrooms = bathrooms;
        }

        public virtual void SetGarage(int garage)
        {
            this.garage = garage;
        }

        public int GetBedrooms()
        {
            return bedrooms;
        }

        public int GetBathrooms()
        {
            return bathrooms;
        }

        public int GetGarage()
        {
            return garage;
        }
    }

    public class Apartment : Home
    {
        private const int DefaultSquareFootage = 1500;
        private const int DefaultBedrooms = 2;
        private const int DefaultBathrooms = 1;
        private const int DefaultFloors = 1;
        private const double DefaultLocation = 15.0;
        private const int DefaultGarage = 0;

        private const decimal BaseRent = 400m;
        private const decimal EachHundredSquareFeet = 50m;

        public Apartment()
        {
            Initialize();
        }

        /// <summary>
        /// squareFootage, bedrooms, bathrooms, floors, location, garage
        /// </summary>
        public Apartment(int squareFootage, int bedrooms, int bathrooms, int floors, double location, int garage)
        {
            SetSquareFootage(squareFootage);
            SetBedrooms(bedrooms);
            SetBathrooms(bathrooms);
            SetFloors(floors);
            SetLocation(location);
            SetGarage(garage);
        }

        private void Initialize()
        {
            SetSquareFootage(DefaultSquareFootage);
            SetBedrooms(DefaultBedrooms);
            SetBathrooms(DefaultBathrooms);
            SetFloors(DefaultFloors);
            SetLocation(DefaultLocation);
            SetGarage(DefaultGarage);
        }

        public override void SetSquareFootage(int squareFootage)
        {
            base.SetSquareFootage(squareFootage >= 1000 && squareFootage <= 3600 ? squareFootage : DefaultSquareFootage);
        }

        public override void SetBedrooms(int bedrooms)
        {
            base.SetBedrooms(bedrooms >= 1 && bedrooms <= 3 ? bedrooms : DefaultBedrooms);
        }

        public override void SetBathrooms(int bathrooms)
        {
            base.SetBathrooms(bathrooms >= 1 && bathrooms <= 3 ? bathrooms : DefaultBathrooms);
        }

        public override void SetFloors(int floors)
        {
            base.SetFloors(floors == 1 || floors == 2 ? floors : DefaultFloors);
        }

        public override void SetLocation(double location)
        {
            base.SetLocation(location >= 0.0 ? location : DefaultLocation);
        }

        public override void SetGarage(int garage)
        {
            base.SetGarage(garage >= 0 && garage <= 2 ? garage : DefaultGarage);
        }

        private decimal AdditionalFloorCharge(decimal subtotal)
        {
            return GetFloors() == 2 ? subtotal * 0.30m : 0m;
        }

        private decimal LocationAdjustment(decimal total)
        {
            if (GetLocation() >= 0.0 && GetLocation() <= 5.0)
            {
                return total * 0.40m;
            }

            if (GetLocation() > 45.0)
            {
                return total * -0.25m;
            }

            return 0m;
        }

        public override decimal CalculateCost()
        {
            decimal squareFootageCost = BaseRent;

            if (GetSquareFootage() > DefaultSquareFootage)
            {
                int blocks = CeilingHundreds(GetSquareFootage() - DefaultSquareFootage);
                squareFootageCost += blocks * EachHundredSquareFeet;
            }

            decimal bedroomCost = GetBedrooms() * 200m;
            decimal bathroomCost = GetBathrooms() * 100m;

            decimal total = squareFootageCost + bedroomCost + bathroomCost;
            total += AdditionalFloorCharge(total);
            total += GetGarage() * 100m;
            total += LocationAdjustment(total);

            SetCost(total);
            return total;
        }

        public override string ToString()
        {
            return base.ToString() + $"apartment is {CalculateCost():C} per month";
        }
    }

    public class Condo : Home
    {
        private const int DefaultSquareFootage = 3000;
        private const int DefaultBedrooms = 2;
        private const int DefaultBathrooms = 2;
        private const int DefaultFloors = 1;
        private const double DefaultLocation = 15.0;
        private const int DefaultGarage = 0;

        private const int BaseSquareFootage = 2000;
        private const decimal BaseCost = 180000m;
        private const decimal PlusEachHundred = 2800m;
        private const decimal MinusEachHundred = 1500m;

        public Condo()
        {
            Initialize();
        }

        /// <summary>
        /// squareFootage, bedrooms, bathrooms, floors, location, garage
        /// </summary>
        public Condo(int squareFootage, int bedrooms, int bathrooms, int floors, double location, int garage)
        {
            SetSquareFootage(squareFootage);
            SetBedrooms(bedrooms);
            SetBathrooms(bathrooms);
            SetFloors(floors);
            SetLocation(location);
            SetGarage(garage);
        }

        private void Initialize()
        {
            SetSquareFootage(DefaultSquareFootage);
            SetBedrooms(DefaultBedrooms);
            SetBathrooms(DefaultBathrooms);
            SetFloors(DefaultFloors);
            SetLocation(DefaultLocation);
            SetGarage(DefaultGarage);
        }

        public override void SetSquareFootage(int squareFootage)
        {
            base.SetSquareFootage(squareFootage >= 2500 && squareFootage <= 5500 ? squareFootage : DefaultSquareFootage);
        }

        public override void SetBedrooms(int bedrooms)
        {
            base.SetBedrooms(bedrooms >= 1 && bedrooms <= 4 ? bedrooms : DefaultBedrooms);
        }

        public override void SetBathrooms(int bathrooms)
        {
            base.SetBathrooms(bathrooms >= 1 && bathrooms <= 3 ? bathrooms : DefaultBathrooms);
        }

        public override void SetFloors(int floors)
        {
            base.SetFloors(floors == 1 || floors == 2 ? floors : DefaultFloors);
        }

        public override void SetLocation(double location)
        {
            base.SetLocation(location >= 0.0 ? location : DefaultLocation);
        }

        public override void SetGarage(int garage)
        {
            base.SetGarage(garage >= 0 && garage <= 2 ? garage : DefaultGarage);
        }

        private decimal Additional()
        {
            if (GetSquareFootage() > BaseSquareFootage)
            {
                int blocks = CeilingHundreds(GetSquareFootage() - BaseSquareFootage);
                return blocks * PlusEachHundred;
            }

            if (GetSquareFootage() < BaseSquareFootage)
            {
                int blocks = CeilingHundreds(BaseSquareFootage - GetSquareFootage());
                return -(blocks * MinusEachHundred);
            }

            return 0m;
        }

        private decimal LocationAdjustment(decimal total)
        {
            if (GetLocation() >= 0.0 && GetLocation() <= 5.0)
            {
                return total * 0.60m;
            }

            if (GetLocation() > 20.0 && GetLocation() <= 45.0)
            {
                return total * -0.10m;
            }

            if (GetLocation() > 45.0)
            {
                return total * -0.25m;
            }

            return 0m;
        }

        public override decimal CalculateCost()
        {
            decimal squareFootageCost = BaseCost + Additional();
            decimal bedroomCost = GetBedrooms() * 3400m;
            decimal bathroomCost = GetBathrooms() * 1500m;

            decimal total = squareFootageCost + bedroomCost + bathroomCost;

            if (GetFloors() == 2)
            {
                total += total * 0.40m;
            }

            total += GetGarage() * 1500m;
            total += LocationAdjustment(total);

            SetCost(total);
            return total;
        }

        public override string ToString()
        {
            return base.ToString() + $"condominium is {CalculateCost():C}";
        }
    }

    public class House : Home
    {
        private const int DefaultSquareFootage = 3200;
        private const int DefaultBedrooms = 3;
        private const int DefaultBathrooms = 2;
        private const int DefaultFloors = 1;
        private const int DefaultBasement = 2;
        private const double DefaultLocation = 15.0;
        private const int DefaultGarage = 2;
        private const double DefaultLotSize = 0.25;

        private const int BaseSquareFootage = 2400;
        private const decimal BaseCost = 160000m;
        private const decimal PlusEachHundred = 2800m;
        private const decimal MinusEachHundred = 1000m;

        private int basement;
        private double lotSize;

        public House()
        {
            Initialize();
        }

        /// <summary>
        /// squareFootage, bedrooms, bathrooms, floors, basement, location, garage, lotSize
        /// </summary>
        public House(
            int squareFootage,
            int bedrooms,
            int bathrooms,
            int floors,
            int basement,
            double location,
            int garage,
            double lotSize)
        {
            SetSquareFootage(squareFootage);
            SetBedrooms(bedrooms);
            SetBathrooms(bathrooms);
            SetFloors(floors);
            SetBasement(basement);
            SetLocation(location);
            SetGarage(garage);
            SetLotSize(lotSize);
        }

        private void Initialize()
        {
            SetSquareFootage(DefaultSquareFootage);
            SetBedrooms(DefaultBedrooms);
            SetBathrooms(DefaultBathrooms);
            SetFloors(DefaultFloors);
            SetBasement(DefaultBasement);
            SetLocation(DefaultLocation);
            SetGarage(DefaultGarage);
            SetLotSize(DefaultLotSize);
        }

        public override void SetSquareFootage(int squareFootage)
        {
            base.SetSquareFootage(squareFootage >= 2400 && squareFootage <= 6400 ? squareFootage : DefaultSquareFootage);
        }

        public override void SetBedrooms(int bedrooms)
        {
            base.SetBedrooms(bedrooms >= 1 && bedrooms <= 5 ? bedrooms : DefaultBedrooms);
        }

        public override void SetBathrooms(int bathrooms)
        {
            base.SetBathrooms(bathrooms >= 1 && bathrooms <= 4 ? bathrooms : DefaultBathrooms);
        }

        public override void SetFloors(int floors)
        {
            base.SetFloors(floors >= 1 && floors <= 3 ? floors : DefaultFloors);
        }

        public void SetBasement(int basement)
        {
            this.basement = basement >= 0 && basement <= 2 ? basement : DefaultBasement;
        }

        public override void SetLocation(double location)
        {
            bool valid = location > 5.0;
            base.SetLocation(valid ? location : DefaultLocation);
        }

        public override void SetGarage(int garage)
        {
            base.SetGarage(garage >= 1 && garage <= 3 ? garage : DefaultGarage);
        }

        public void SetLotSize(double lotSize)
        {
            this.lotSize = lotSize >= 0.25 && lotSize <= 5.00 ? lotSize : DefaultLotSize;
        }

        public int GetBasement()
        {
            return basement;
        }

        public double GetLotSize()
        {
            return lotSize;
        }

        private decimal Additional()
        {
            if (GetSquareFootage() > BaseSquareFootage)
            {
                int blocks = CeilingHundreds(GetSquareFootage() - BaseSquareFootage);
                return blocks * PlusEachHundred;
            }

            if (GetSquareFootage() < BaseSquareFootage)
            {
                int blocks = CeilingHundreds(BaseSquareFootage - GetSquareFootage());
                return -(blocks * MinusEachHundred);
            }

            return 0m;
        }

        private decimal AdditionalAcres()
        {
            if (GetLotSize() <= 0.25)
            {
                return 0m;
            }

            return (decimal)(GetLotSize() - 0.25) * 40000m;
        }

        private decimal LocationAdjustment(decimal total)
        {
            if (GetLocation() > 20.0 && GetLocation() <= 45.0)
            {
                return total * -0.05m;
            }

            if (GetLocation() > 45.0)
            {
                return total * -0.125m;
            }

            return 0m;
        }

        public override decimal CalculateCost()
        {
            decimal squareFootageCost = BaseCost + Additional();
            decimal bedroomCost = GetBedrooms() * 8200m;
            decimal bathroomCost = GetBathrooms() * 3600m;

            decimal total = squareFootageCost + bedroomCost + bathroomCost;

            if (GetBasement() == 2)
            {
                total += squareFootageCost * 0.136m;
            }
            else if (GetBasement() == 1)
            {
                total += squareFootageCost * 0.082m;
            }

            total += GetGarage() * 1750m;
            total += AdditionalAcres();
            total += LocationAdjustment(total);

            SetCost(total);
            return total;
        }

        public override string ToString()
        {
            return base.ToString() + $"house is {CalculateCost():C}";
        }
    }

    public static class Program
    {
        public static void Main()
        {
            RunApartmentTests();
            RunCondoTests();
            RunHouseTests();
        }

        private static void RunApartmentTests()
        {
            var tests = new List<(string Label, Apartment Item)>
            {
                ("Default", new Apartment()),
                ("Test 1", new Apartment(1200, 1, 1, 1, 46.0, 0)),
                ("Test 2", new Apartment(2301, 2, 2, 1, 1.0, 0)),
                ("Test 3", new Apartment(2699, 3, 2, 1, 15.0, 1)),
                ("Test 4", new Apartment(3600, 3, 3, 2, 2.0, 2)),
                ("Test 5", new Apartment(4300, 4, 4, 3, 15.0, 3))
            };

            Console.WriteLine("================ APARTMENT TESTS ================");
            foreach (var test in tests)
            {
                PrintApartment(test.Label, test.Item);
            }

            Console.WriteLine();
        }

        private static void RunCondoTests()
        {
            var tests = new List<(string Label, Condo Item)>
            {
                ("Default", new Condo()),
                ("Test 1", new Condo(2899, 3, 2, 1, 1.0, 0)),
                ("Test 2", new Condo(3801, 3, 2, 2, 44.9, 2)),
                ("Test 3", new Condo(2500, 1, 1, 1, 45.1, 1)),
                ("Test 4", new Condo(5500, 4, 3, 2, 3.0, 2)),
                ("Test 5", new Condo(2499, 0, 4, 3, 15.0, 3))
            };

            Console.WriteLine("================== CONDO TESTS ==================");
            foreach (var test in tests)
            {
                PrintCondo(test.Label, test.Item);
            }

            Console.WriteLine();
        }

        private static void RunHouseTests()
        {
            var tests = new List<(string Label, House Item)>
            {
                ("Default", new House()),
                ("Test 1", new House(2400, 1, 1, 1, 0, 15.0, 1, 0.25)),
                ("Test 2", new House(4100, 4, 3, 2, 1, 30.0, 3, 1.50)),
                ("Test 3", new House(6400, 5, 4, 3, 2, 50.1, 3, 5.00)),
                ("Test 4", new House(1000, 9, 9, 9, 9, 0.0, 0, 10.0))
            };

            Console.WriteLine("================== HOUSE TESTS ==================");
            foreach (var test in tests)
            {
                PrintHouse(test.Label, test.Item);
            }

            Console.WriteLine();
        }

        private static void PrintApartment(string label, Apartment apartment)
        {
            Console.WriteLine(label);
            Console.WriteLine($"  Square Footage: {apartment.GetSquareFootage()}");
            Console.WriteLine($"  Bedrooms:       {apartment.GetBedrooms()}");
            Console.WriteLine($"  Bathrooms:      {apartment.GetBathrooms()}");
            Console.WriteLine($"  Floors:         {apartment.GetFloors()}");
            Console.WriteLine($"  Location:       {apartment.GetLocation():0.0}");
            Console.WriteLine($"  Garages:        {apartment.GetGarage()}");
            Console.WriteLine($"  Cost:           {apartment.CalculateCost():C}");
            Console.WriteLine($"  ToString:       {apartment}");
            Console.WriteLine();
        }

        private static void PrintCondo(string label, Condo condo)
        {
            Console.WriteLine(label);
            Console.WriteLine($"  Square Footage: {condo.GetSquareFootage()}");
            Console.WriteLine($"  Bedrooms:       {condo.GetBedrooms()}");
            Console.WriteLine($"  Bathrooms:      {condo.GetBathrooms()}");
            Console.WriteLine($"  Floors:         {condo.GetFloors()}");
            Console.WriteLine($"  Location:       {condo.GetLocation():0.0}");
            Console.WriteLine($"  Garages:        {condo.GetGarage()}");
            Console.WriteLine($"  Cost:           {condo.CalculateCost():C}");
            Console.WriteLine($"  ToString:       {condo}");
            Console.WriteLine();
        }

        private static void PrintHouse(string label, House house)
        {
            Console.WriteLine(label);
            Console.WriteLine($"  Square Footage: {house.GetSquareFootage()}");
            Console.WriteLine($"  Bedrooms:       {house.GetBedrooms()}");
            Console.WriteLine($"  Bathrooms:      {house.GetBathrooms()}");
            Console.WriteLine($"  Floors:         {house.GetFloors()}");
            Console.WriteLine($"  Basement:       {house.GetBasement()}");
            Console.WriteLine($"  Location:       {house.GetLocation():0.0}");
            Console.WriteLine($"  Garages:        {house.GetGarage()}");
            Console.WriteLine($"  Lot Size:       {house.GetLotSize():0.00}");
            Console.WriteLine($"  Cost:           {house.CalculateCost():C}");
            Console.WriteLine($"  ToString:       {house}");
            Console.WriteLine();
        }
    }
}
