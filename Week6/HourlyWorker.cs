// Glaycon Cezarotto 3/6/2026
using System;

public class HourlyWorker : Employee
{
    private float hoursworked;
    private float payrate;

    // Default constructor
    public HourlyWorker() : base()
    {
        hoursworked = 0.0f;
        payrate = 0.0f;
    }

    // Set-all constructor
    public HourlyWorker(int id, string first, string last, float hours, float rate) : base(id, first, last)
    {
        hoursworked = hours;
        payrate = rate;
    }

    // setData
    public void setData(int id = 0, string first = "No Name", string last = "No Name", float hours = 0.0f, float rate = 0.0f)
    {
        base.setData(id, first, last);
        hoursworked = hours;
        payrate = rate;
    }

    // Setters
    public void setHoursworked(float hours)
    {
        hoursworked = hours;
    }

    public void setPayrate(float rate)
    {
        payrate = rate;
    }

    // Getters
    public float getHoursworked()
    {
        return hoursworked;
    }

    public float getPayrate()
    {
        return payrate;
    }

    // Override displayData
    public override string displayData()
    {
        return $"{base.displayData()}{hoursworked,12:F2}{payrate,12:F2}";
    }

    // Override earnings
    public override string earnings()
    {
        float weeklyPay;

        if (hoursworked <= 40)
        {
            weeklyPay = hoursworked * payrate;
        }
        else
        {
            float regularPay = 40 * payrate;
            float overtimePay = (hoursworked - 40) * (payrate * 1.5f);
            weeklyPay = regularPay + overtimePay;
        }

        return $"{"HourlyWorker",-18}{getId(),-8}{getFirstName(),-15}{getLastName(),-15}{weeklyPay,12:F2}";
    }
}