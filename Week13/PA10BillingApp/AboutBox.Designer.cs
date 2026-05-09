namespace PA10BillingApp;

partial class AboutBox
{
    private System.ComponentModel.IContainer? components = null;

    private Panel LogoPanel = null!;
    private Label ProductNameLabel = null!;
    private Label VersionLabel = null!;
    private Label CopyrightLabel = null!;
    private TextBox DescriptionTextBox = null!;
    private Button OkButton = null!;

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
        LogoPanel = new Panel();
        ProductNameLabel = new Label();
        VersionLabel = new Label();
        CopyrightLabel = new Label();
        DescriptionTextBox = new TextBox();
        OkButton = new Button();
        SuspendLayout();
        // 
        // LogoPanel
        // 
        LogoPanel.BackColor = Color.White;
        LogoPanel.BorderStyle = BorderStyle.FixedSingle;
        LogoPanel.Location = new Point(13, 13);
        LogoPanel.Name = "LogoPanel";
        LogoPanel.Size = new Size(210, 237);
        LogoPanel.TabIndex = 0;
        LogoPanel.Paint += LogoPanel_Paint;
        // 
        // ProductNameLabel
        // 
        ProductNameLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
        ProductNameLabel.Location = new Point(243, 25);
        ProductNameLabel.Name = "ProductNameLabel";
        ProductNameLabel.Size = new Size(332, 23);
        ProductNameLabel.TabIndex = 1;
        ProductNameLabel.Text = "R 'n R for Reading and Refreshment";
        ProductNameLabel.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // VersionLabel
        // 
        VersionLabel.Location = new Point(243, 61);
        VersionLabel.Name = "VersionLabel";
        VersionLabel.Size = new Size(332, 23);
        VersionLabel.TabIndex = 2;
        VersionLabel.Text = "Version 1.0.0";
        VersionLabel.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // CopyrightLabel
        // 
        CopyrightLabel.Location = new Point(243, 97);
        CopyrightLabel.Name = "CopyrightLabel";
        CopyrightLabel.Size = new Size(332, 23);
        CopyrightLabel.TabIndex = 3;
        CopyrightLabel.Text = "Copyright 2026";
        CopyrightLabel.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // DescriptionTextBox
        // 
        DescriptionTextBox.Location = new Point(243, 141);
        DescriptionTextBox.Multiline = true;
        DescriptionTextBox.Name = "DescriptionTextBox";
        DescriptionTextBox.ReadOnly = true;
        DescriptionTextBox.ScrollBars = ScrollBars.Vertical;
        DescriptionTextBox.Size = new Size(332, 75);
        DescriptionTextBox.TabIndex = 4;
        DescriptionTextBox.TabStop = false;
        DescriptionTextBox.Text = "Calculates sales for R 'n R for Reading and Refreshment. Includes item totals, tax, order totals, customer count, total sales, and average sales.";
        // 
        // OkButton
        // 
        OkButton.DialogResult = DialogResult.Cancel;
        OkButton.Location = new Point(500, 227);
        OkButton.Name = "OkButton";
        OkButton.Size = new Size(75, 30);
        OkButton.TabIndex = 5;
        OkButton.Text = "OK";
        OkButton.UseVisualStyleBackColor = true;
        OkButton.Click += OkButton_Click;
        // 
        // AboutBox
        // 
        AcceptButton = OkButton;
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        CancelButton = OkButton;
        ClientSize = new Size(587, 269);
        Controls.Add(OkButton);
        Controls.Add(DescriptionTextBox);
        Controls.Add(CopyrightLabel);
        Controls.Add(VersionLabel);
        Controls.Add(ProductNameLabel);
        Controls.Add(LogoPanel);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "AboutBox";
        Padding = new Padding(10);
        ShowIcon = false;
        ShowInTaskbar = false;
        StartPosition = FormStartPosition.CenterParent;
        Text = "About R 'n R for Reading and Refreshment";
        ResumeLayout(false);
        PerformLayout();
    }
}
