namespace PA10BillingApp;

partial class SummaryForm
{
    private System.ComponentModel.IContainer? components = null;

    private Label TitleLabel = null!;
    private Label TotalSalesLabel = null!;
    private Label AverageSalesLabel = null!;
    private Label NumberCustomersLabel = null!;
    private TextBox TotalSalesTextBox = null!;
    private TextBox AverageSalesTextBox = null!;
    private TextBox NumberCustomersTextBox = null!;
    private Button CloseButton = null!;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null)
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        TitleLabel = new Label();
        TotalSalesLabel = new Label();
        AverageSalesLabel = new Label();
        NumberCustomersLabel = new Label();
        TotalSalesTextBox = new TextBox();
        AverageSalesTextBox = new TextBox();
        NumberCustomersTextBox = new TextBox();
        CloseButton = new Button();
        SuspendLayout();
        // 
        // TitleLabel
        // 
        TitleLabel.Font = new Font("Segoe UI", 11F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
        TitleLabel.Location = new Point(43, 27);
        TitleLabel.Name = "TitleLabel";
        TitleLabel.Size = new Size(363, 32);
        TitleLabel.TabIndex = 0;
        TitleLabel.Text = "R 'n R for Reading and Refreshment";
        TitleLabel.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // TotalSalesLabel
        // 
        TotalSalesLabel.Location = new Point(99, 88);
        TotalSalesLabel.Name = "TotalSalesLabel";
        TotalSalesLabel.Size = new Size(136, 23);
        TotalSalesLabel.TabIndex = 1;
        TotalSalesLabel.Text = "Total Sales";
        TotalSalesLabel.TextAlign = ContentAlignment.MiddleRight;
        // 
        // AverageSalesLabel
        // 
        AverageSalesLabel.Location = new Point(99, 128);
        AverageSalesLabel.Name = "AverageSalesLabel";
        AverageSalesLabel.Size = new Size(136, 23);
        AverageSalesLabel.TabIndex = 3;
        AverageSalesLabel.Text = "Average Sales";
        AverageSalesLabel.TextAlign = ContentAlignment.MiddleRight;
        // 
        // NumberCustomersLabel
        // 
        NumberCustomersLabel.Location = new Point(99, 168);
        NumberCustomersLabel.Name = "NumberCustomersLabel";
        NumberCustomersLabel.Size = new Size(136, 23);
        NumberCustomersLabel.TabIndex = 5;
        NumberCustomersLabel.Text = "Number of Customers";
        NumberCustomersLabel.TextAlign = ContentAlignment.MiddleRight;
        // 
        // TotalSalesTextBox
        // 
        TotalSalesTextBox.Location = new Point(254, 88);
        TotalSalesTextBox.Name = "TotalSalesTextBox";
        TotalSalesTextBox.ReadOnly = true;
        TotalSalesTextBox.Size = new Size(100, 23);
        TotalSalesTextBox.TabIndex = 2;
        TotalSalesTextBox.TabStop = false;
        TotalSalesTextBox.TextAlign = HorizontalAlignment.Right;
        // 
        // AverageSalesTextBox
        // 
        AverageSalesTextBox.Location = new Point(254, 128);
        AverageSalesTextBox.Name = "AverageSalesTextBox";
        AverageSalesTextBox.ReadOnly = true;
        AverageSalesTextBox.Size = new Size(100, 23);
        AverageSalesTextBox.TabIndex = 4;
        AverageSalesTextBox.TabStop = false;
        AverageSalesTextBox.TextAlign = HorizontalAlignment.Right;
        // 
        // NumberCustomersTextBox
        // 
        NumberCustomersTextBox.Location = new Point(254, 168);
        NumberCustomersTextBox.Name = "NumberCustomersTextBox";
        NumberCustomersTextBox.ReadOnly = true;
        NumberCustomersTextBox.Size = new Size(100, 23);
        NumberCustomersTextBox.TabIndex = 6;
        NumberCustomersTextBox.TabStop = false;
        NumberCustomersTextBox.TextAlign = HorizontalAlignment.Right;
        // 
        // CloseButton
        // 
        CloseButton.DialogResult = DialogResult.Cancel;
        CloseButton.Location = new Point(188, 231);
        CloseButton.Name = "CloseButton";
        CloseButton.Size = new Size(75, 30);
        CloseButton.TabIndex = 7;
        CloseButton.Text = "&Close";
        CloseButton.UseVisualStyleBackColor = true;
        CloseButton.Click += CloseButton_Click;
        // 
        // SummaryForm
        // 
        AcceptButton = CloseButton;
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        CancelButton = CloseButton;
        ClientSize = new Size(449, 294);
        Controls.Add(CloseButton);
        Controls.Add(NumberCustomersTextBox);
        Controls.Add(NumberCustomersLabel);
        Controls.Add(AverageSalesTextBox);
        Controls.Add(AverageSalesLabel);
        Controls.Add(TotalSalesTextBox);
        Controls.Add(TotalSalesLabel);
        Controls.Add(TitleLabel);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "SummaryForm";
        StartPosition = FormStartPosition.CenterParent;
        Text = "R 'n R Billing Summary";
        Activated += SummaryForm_Activated;
        ResumeLayout(false);
        PerformLayout();
    }
}
