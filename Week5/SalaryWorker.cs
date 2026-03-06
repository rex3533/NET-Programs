// Glaycon Cezarotto 3/6/2026
using System;

public class SalaryWorker : Employee
{
    private float salary;

    // Default constructor
    public SalaryWorker() : base()
    {
        salary = 0.0f;
    }

    // Set-all constructor
    public SalaryWorker(int id, string first, string last, float sal) : base(id, first, last)
    {
        salary = sal;
    }

    // setData
    public void setData(int id = 0, string first = "No Name", string last = "No Name", float sal = 0.0f)
    {
        base.setData(id, first, last);
        salary = sal;
    }

    // Setter
    public void setSalary(float sal)
    {
        salary = sal;
    }

    // Getter
    public float getSalary()
    {
        return salary;
    }

    // Override displayData
    public override string displayData()
    {
        return $"{base.displayData()}{salary,15:F2}";
    }

    // Override earnings
    public override string earnings()
    {
        float weeklyPay = salary / 52.0f;
        return $"{"SalaryWorker",-18}{getId(),-8}{getFirstName(),-15}{getLastName(),-15}{weeklyPay,12:F2}";
    }
}