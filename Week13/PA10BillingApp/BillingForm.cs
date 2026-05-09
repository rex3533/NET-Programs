namespace PA10BillingApp;

public partial class BillingForm : Form
{
    // Module-level variables for the current customer and the summary form.
    private decimal subtotalDecimal;
    private decimal taxDecimal;
    private decimal totalDecimal;
    private decimal grandTotalDecimal;
    private int customerCountInteger;

    internal decimal GrandTotalDecimal => grandTotalDecimal;
    internal int CustomerCountInteger => customerCountInteger;
    internal decimal AverageDecimal { get; private set; }

    private const decimal TaxRateDecimal = 0.08m;
    private const decimal CappuccinoPriceDecimal = 2.00m;
    private const decimal EspressoPriceDecimal = 2.25m;
    private const decimal LattePriceDecimal = 1.75m;
    private const decimal IcedPriceDecimal = 2.50m;

    public BillingForm()
    {
        InitializeComponent();
    }

    private void CalculateButton_Click(object? sender, EventArgs e)
    {
        if (!int.TryParse(QuantityTextBox.Text.Trim(), out int quantityInteger))
        {
            MessageBox.Show("Quantity must be numeric.", "Data Entry Error",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            QuantityTextBox.Focus();
            QuantityTextBox.SelectAll();
            return;
        }

        if (quantityInteger <= 0)
        {
            MessageBox.Show("Quantity must be greater than zero.", "Data Entry Error",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            QuantityTextBox.Focus();
            QuantityTextBox.SelectAll();
            return;
        }

        decimal priceDecimal = GetSelectedCoffeePrice();
        decimal itemAmountDecimal = priceDecimal * quantityInteger;
        subtotalDecimal += itemAmountDecimal;

        taxDecimal = TaxCheckBox.Checked ? FindTax(subtotalDecimal) : 0m;
        totalDecimal = subtotalDecimal + taxDecimal;

        ItemAmountTextBox.Text = itemAmountDecimal.ToString("C");
        SubTotalTextBox.Text = subtotalDecimal.ToString("N2");
        TaxTextBox.Text = taxDecimal.ToString("N2");
        TotalTextBox.Text = totalDecimal.ToString("C");

        TaxCheckBox.Enabled = false;
        ClearButton.Enabled = true;
        ClearItemToolStripMenuItem.Enabled = true;
        NewOrderToolStripMenuItem.Enabled = true;
    }

    private decimal GetSelectedCoffeePrice()
    {
        if (EspressoRadioButton.Checked)
        {
            return EspressoPriceDecimal;
        }

        if (LatteRadioButton.Checked)
        {
            return LattePriceDecimal;
        }

        if (IcedLatteRadioButton.Checked || IcedCappuccinoRadioButton.Checked)
        {
            return IcedPriceDecimal;
        }

        return CappuccinoPriceDecimal;
    }

    private decimal FindTax(decimal amountDecimal)
    {
        return amountDecimal * TaxRateDecimal;
    }

    private void ClearButton_Click(object? sender, EventArgs e)
    {
        ClearCurrentItem();
    }

    private void ClearCurrentItem()
    {
        CappuccinoRadioButton.Checked = true;
        ItemAmountTextBox.Clear();
        QuantityTextBox.Clear();
        QuantityTextBox.Focus();
    }

    private void NewOrderToolStripMenuItem_Click(object? sender, EventArgs e)
    {
        FinalizeCurrentOrder(true);
    }

    private bool FinalizeCurrentOrder(bool askBeforeClearing)
    {
        if (subtotalDecimal == 0m)
        {
            ResetCurrentCustomerFields();
            return false;
        }

        if (askBeforeClearing)
        {
            DialogResult responseDialogResult = MessageBox.Show(
                "Clear the current order figures?",
                "Clear Order",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);

            if (responseDialogResult != DialogResult.Yes)
            {
                return false;
            }
        }

        grandTotalDecimal += totalDecimal;
        customerCountInteger += 1;
        ResetCurrentCustomerFields();
        return true;
    }

    private void ResetCurrentCustomerFields()
    {
        subtotalDecimal = 0m;
        taxDecimal = 0m;
        totalDecimal = 0m;

        ClearCurrentItem();
        SubTotalTextBox.Clear();
        TaxTextBox.Clear();
        TotalTextBox.Clear();

        TaxCheckBox.Enabled = true;
        TaxCheckBox.Checked = false;

        ClearButton.Enabled = false;
        ClearItemToolStripMenuItem.Enabled = false;
        NewOrderToolStripMenuItem.Enabled = false;
    }

    private void SummaryToolStripMenuItem_Click(object? sender, EventArgs e)
    {
        // Count the current order before opening the summary form.
        if (subtotalDecimal != 0m)
        {
            FinalizeCurrentOrder(false);
        }

        if (customerCountInteger == 0)
        {
            MessageBox.Show("No sales data to summarize.", "Coffee Sales Summary",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        AverageDecimal = grandTotalDecimal / customerCountInteger;

        using SummaryForm summaryForm = new SummaryForm(this);
        summaryForm.ShowDialog(this);
    }

    private void ExitToolStripMenuItem_Click(object? sender, EventArgs e)
    {
        Close();
    }

    private void AboutToolStripMenuItem_Click(object? sender, EventArgs e)
    {
        using AboutBox aboutBox = new AboutBox();
        aboutBox.ShowDialog(this);
    }

    private void CalculateSelectionToolStripMenuItem_Click(object? sender, EventArgs e)
    {
        CalculateButton.PerformClick();
    }

    private void ClearItemToolStripMenuItem_Click(object? sender, EventArgs e)
    {
        ClearButton.PerformClick();
    }

    private void FontToolStripMenuItem_Click(object? sender, EventArgs e)
    {
        FontDialog1.Font = SubTotalTextBox.Font;

        if (FontDialog1.ShowDialog(this) == DialogResult.OK)
        {
            SubTotalTextBox.Font = FontDialog1.Font;
            TaxTextBox.Font = FontDialog1.Font;
            TotalTextBox.Font = FontDialog1.Font;
        }
    }

    private void ColorToolStripMenuItem_Click(object? sender, EventArgs e)
    {
        ColorDialog1.Color = SubTotalTextBox.ForeColor;

        if (ColorDialog1.ShowDialog(this) == DialogResult.OK)
        {
            SubTotalTextBox.ForeColor = ColorDialog1.Color;
            TaxTextBox.ForeColor = ColorDialog1.Color;
            TotalTextBox.ForeColor = ColorDialog1.Color;
        }
    }
}
