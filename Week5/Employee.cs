// Glaycon Cezarotto 3/6/2026
using System;

public class Employee
{
    private int id_num;
    private string first_name;
    private string last_name;

    // Default constructor
    public Employee()
    {
        id_num = 0;
        first_name = "No Name";
        last_name = "No Name";
    }

    // Set-all constructor
    public Employee(int id, string first, string last)
    {
        id_num = id;
        first_name = first;
        last_name = last;
    }

    // setData
    public void setData(int id = 0, string first = "No Name", string last = "No Name")
    {
        id_num = id;
        first_name = first;
        last_name = last;
    }

    // Setters
    public void setId(int id)
    {
        id_num = id;
    }

    public void setFirstName(string first)
    {
        first_name = first;
    }

    public void setLastName(string last)
    {
        last_name = last;
    }

    // Getters
    public int getId()
    {
        return id_num;
    }

    public string getFirstName()
    {
        return first_name;
    }

    public string getLastName()
    {
        return last_name;
    }

    // Virtual displayData
    public virtual string displayData()
    {
        return $"{id_num,-8}{first_name,-15}{last_name,-15}";
    }

    // Virtual earnings
    public virtual string earnings()
    {
        return $"{"Employee",-18}{id_num,-8}{first_name,-15}{last_name,-15}{"0.00",10}";
    }
}