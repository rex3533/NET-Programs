namespace PA10BillingApp;

internal static class Program
{
    [STAThread]
    private static void Main()
    {
        ApplicationConfiguration.Initialize();

        using (SplashForm splashForm = new SplashForm())
        {
            splashForm.Show();
            Application.DoEvents();
            Thread.Sleep(1500);
            splashForm.Close();
        }

        Application.Run(new BillingForm());
    }
}
