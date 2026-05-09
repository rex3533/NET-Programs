using System.Drawing.Drawing2D;

namespace PA10BillingApp;

public partial class AboutBox : Form
{
    public AboutBox()
    {
        InitializeComponent();
    }

    private void LogoPanel_Paint(object? sender, PaintEventArgs e)
    {
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        e.Graphics.Clear(Color.White);

        using Pen widePen = new Pen(Color.LightGray, 18);
        using Pen darkPen = new Pen(Color.DimGray, 4);

        e.Graphics.DrawEllipse(widePen, 18, 18, 110, 110);
        e.Graphics.DrawEllipse(widePen, 66, 34, 110, 110);
        e.Graphics.DrawEllipse(widePen, 38, 88, 110, 110);

        e.Graphics.DrawEllipse(darkPen, 18, 18, 110, 110);
        e.Graphics.DrawEllipse(darkPen, 66, 34, 110, 110);
        e.Graphics.DrawEllipse(darkPen, 38, 88, 110, 110);
    }

    private void OkButton_Click(object? sender, EventArgs e)
    {
        Close();
    }
}
