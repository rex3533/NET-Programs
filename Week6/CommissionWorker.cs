// Glaycon Cezarotto 3/6/2026
using System;

public class CommissionWorker : Employee
{
    private float salary;
    private float comm_rate;
    private float sales;

    // Default constructor
    public CommissionWorker() : base()
    {
        salary = 0.0f;
        comm_rate = 0.0f;
        sales = 0.0f;
    }

    // Set-all constructor
    public CommissionWorker(int id, string first, string last, float sal, float rate, float weeklySales) : base(id, first, last)
    {
        salary = sal;
        comm_rate = rate;
        sales = weeklySales;
    }

    // setData
    public void setData(int id = 0, string first = "No Name", string last = "No Name",
                        float sal = 0.0f, float rate = 0.0f, float weeklySales = 0.0f)
    {
        base.setData(id, first, last);
        salary = sal;
        comm_rate = rate;
        sales = weeklySales;
    }

    // Setters
    public void setSalary(float sal)
    {
        salary = sal;
    }

    public void setCommRate(float rate)
    {
        comm_rate = rate;
    }

    public void setSales(float weeklySales)
    {
        sales = weeklySales;
    }

    // Getters
    public float getSalary()
    {
        return salary;
    }

    public float getCommRate()
    {
        return comm_rate;
    }

    public float getSales()
    {
        return sales;
    }

    // Override displayData
    public override string displayData()
    {
        return $"{base.displayData()}{salary,12:F2}{comm_rate,12:F3}{sales,15:F2}";
    }

    // Override earnings
    public override string earnings()
    {
        float weeklyPay = (salary / 52.0f) + (sales * comm_rate);
        return $"{"CommissionWorker",-18}{getId(),-8}{getFirstName(),-15}{getLastName(),-15}{weeklyPay,12:F2}";
    }
}