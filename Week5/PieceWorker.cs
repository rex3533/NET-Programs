// Glaycon Cezarotto 3/6/2026
using System;

public class PieceWorker : Employee
{
    private float wage_per_piece;
    private int quantity;

    // Default constructor
    public PieceWorker() : base()
    {
        wage_per_piece = 0.0f;
        quantity = 0;
    }

    // Set-all constructor
    public PieceWorker(int id, string first, string last, float wage, int qty) : base(id, first, last)
    {
        wage_per_piece = wage;
        quantity = qty;
    }

    // setData
    public void setData(int id = 0, string first = "No Name", string last = "No Name",
                        float wage = 0.0f, int qty = 0)
    {
        base.setData(id, first, last);
        wage_per_piece = wage;
        quantity = qty;
    }

    // Setters
    public void setWagePerPiece(float wage)
    {
        wage_per_piece = wage;
    }

    public void setQuantity(int qty)
    {
        quantity = qty;
    }

    // Getters
    public float getWagePerPiece()
    {
        return wage_per_piece;
    }

    public int getQuantity()
    {
        return quantity;
    }

    // Override displayData
    public override string displayData()
    {
        return $"{base.displayData()}{wage_per_piece,15:F2}{quantity,10}";
    }

    // Override earnings
    public override string earnings()
    {
        float weeklyPay = wage_per_piece * quantity;
        return $"{"PieceWorker",-18}{getId(),-8}{getFirstName(),-15}{getLastName(),-15}{weeklyPay,12:F2}";
    }
}