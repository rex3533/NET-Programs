namespace PA10BillingApp;

public partial class SummaryForm : Form
{
    private readonly BillingForm billingForm;

    public SummaryForm(BillingForm sourceBillingForm)
    {
        billingForm = sourceBillingForm;
        InitializeComponent();
    }

    private void SummaryForm_Activated(object? sender, EventArgs e)
    {
        TotalSalesTextBox.Text = billingForm.GrandTotalDecimal.ToString("C");
        AverageSalesTextBox.Text = billingForm.AverageDecimal.ToString("C");
        NumberCustomersTextBox.Text = billingForm.CustomerCountInteger.ToString();
    }

    private void CloseButton_Click(object? sender, EventArgs e)
    {
        Close();
    }
}
