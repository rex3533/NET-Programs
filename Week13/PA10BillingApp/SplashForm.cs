using System.Drawing.Drawing2D;

namespace PA10BillingApp;

public partial class SplashForm : Form
{
    public SplashForm()
    {
        InitializeComponent();
    }

    private void LogoPanel_Paint(object? sender, PaintEventArgs e)
    {
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        e.Graphics.Clear(Color.White);

        using Pen widePen = new Pen(Color.LightGray, 20);
        using Pen darkPen = new Pen(Color.DimGray, 4);

        e.Graphics.DrawEllipse(widePen, 5, 10, 140, 140);
        e.Graphics.DrawEllipse(widePen, 70, 30, 140, 140);
        e.Graphics.DrawEllipse(widePen, 30, 90, 140, 140);

        e.Graphics.DrawEllipse(darkPen, 5, 10, 140, 140);
        e.Graphics.DrawEllipse(darkPen, 70, 30, 140, 140);
        e.Graphics.DrawEllipse(darkPen, 30, 90, 140, 140);
    }
}
