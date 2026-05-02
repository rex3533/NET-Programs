using System;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        // Declare module level variables for summary information
        private decimal subtotalDecimal, totalDecimal, grandTotalDecimal;
        private int customerCountInteger;

        // Declare Constants
        const decimal TAX_RATE_Decimal = 0.08m;
        const decimal CAPPUCCINO_PRICE_Decimal = 2.00m;
        const decimal ESPRESSO_PRICE_Decimal = 2.25m;
        const decimal LATTE_PRICE_Decimal = 1.75m;
        const decimal ICED_PRICE_Decimal = 2.50m;

        public Form1()
        {
            InitializeComponent();
        }

        private void CalculateButton_Click(object sender, EventArgs e)
        {
            decimal priceDecimal = 0, taxDecimal = 0, itemAmountDecimal = 0;
            int quantityInteger = 0;

            if (CappuccinoRadioButton.Checked)
                priceDecimal = CAPPUCCINO_PRICE_Decimal;
            else if (EspressoRadioButton.Checked)
                priceDecimal = ESPRESSO_PRICE_Decimal;
            else if (LatteRadioButton.Checked)
                priceDecimal = LATTE_PRICE_Decimal;
            else if (IcedCappuccinoRadioButton.Checked ||
                     IcedLatteRadioButton.Checked)
                priceDecimal = ICED_PRICE_Decimal;

            try
            {
                quantityInteger = int.Parse(QuantityTextBox.Text);
                itemAmountDecimal = priceDecimal * quantityInteger;
                subtotalDecimal += itemAmountDecimal;

                if (TaxCheckBox.Checked)
                    taxDecimal = FindTax(subtotalDecimal);
                else
                    taxDecimal = 0;

                totalDecimal = subtotalDecimal + taxDecimal;

                ItemAmountTextBox.Text = itemAmountDecimal.ToString("c");
                SubTotalTextBox.Text = subtotalDecimal.ToString("n");
                TaxTextBox.Text = taxDecimal.ToString("n");
                TotalTextBox.Text = totalDecimal.ToString("c");

                TaxCheckBox.Enabled = false;

                ClearButton.Enabled = true;
                ClearItemToolStripMenuItem.Enabled = true;
                NewOrderToolStripMenuItem.Enabled = true;
            }
            catch (FormatException)
            {
                MessageBox.Show("Quantity must be numeric.", "Data entry error",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                QuantityTextBox.Focus();
                QuantityTextBox.SelectAll();
            }
        }

        private decimal FindTax(decimal amountDecimal)
        {
            return amountDecimal * TAX_RATE_Decimal;
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            CappuccinoRadioButton.Checked = true;
            ItemAmountTextBox.Clear();
            QuantityTextBox.Clear();
            QuantityTextBox.Focus();
        }

        private void NewOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult responseDialogResult;
            string messageString;

            messageString = "Clear the current order figures?";
            responseDialogResult = MessageBox.Show(messageString, "Clear Order",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);

            if (responseDialogResult == DialogResult.Yes)
            {
                ClearButton_Click(sender, e);
                SubTotalTextBox.Text = "";
                TaxTextBox.Text = "";
                TotalTextBox.Text = "";

                if (subtotalDecimal != 0)
                {
                    grandTotalDecimal += totalDecimal;
                    customerCountInteger += 1;

                    subtotalDecimal = 0;
                    totalDecimal = 0;
                }

                TaxCheckBox.Enabled = true;
                TaxCheckBox.Checked = false;

                ClearButton.Enabled = false;
                ClearItemToolStripMenuItem.Enabled = false;
                NewOrderToolStripMenuItem.Enabled = false;
            }
        }

        private void SummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            decimal averageDecimal;
            string messageString;

            if (totalDecimal != 0)
                NewOrderToolStripMenuItem_Click(sender, e);

            if (customerCountInteger > 0)
            {
                averageDecimal = grandTotalDecimal / customerCountInteger;

                messageString = "Number of Orders: "
                    + customerCountInteger.ToString()
                    + Environment.NewLine + Environment.NewLine
                    + "Total Sales: " + grandTotalDecimal.ToString("c")
                    + Environment.NewLine + Environment.NewLine
                    + "Average Sales: " + averageDecimal.ToString("c");

                MessageBox.Show(messageString, "Coffee Sales Summary",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                messageString = "No sales data to summarize.";

                MessageBox.Show(messageString, "Coffee Sales Summary",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string messageString;

            messageString = "R and R Billing " + Environment.NewLine +
                Environment.NewLine
                + "Programmed by Bradley and Millspaugh";

            MessageBox.Show(messageString, "About R and R Billing",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void FontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog1.Font = SubTotalTextBox.Font;
            FontDialog1.ShowDialog();
            SubTotalTextBox.Font = FontDialog1.Font;
            TaxTextBox.Font = FontDialog1.Font;
            TotalTextBox.Font = FontDialog1.Font;
        }

        private void ColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog1.Color = SubTotalTextBox.ForeColor;
            ColorDialog1.ShowDialog();
            SubTotalTextBox.ForeColor = ColorDialog1.Color;
            TaxTextBox.ForeColor = ColorDialog1.Color;
            TotalTextBox.ForeColor = ColorDialog1.Color;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}