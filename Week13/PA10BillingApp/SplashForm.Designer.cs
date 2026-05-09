namespace PA10BillingApp;

partial class SplashForm
{
    private System.ComponentModel.IContainer? components = null;

    private TableLayoutPanel MainTableLayoutPanel = null!;
    private Panel LogoPanel = null!;
    private Label TitleLabel = null!;
    private Label VersionLabel = null!;
    private Label CopyrightLabel = null!;

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
        MainTableLayoutPanel = new TableLayoutPanel();
        LogoPanel = new Panel();
        TitleLabel = new Label();
        VersionLabel = new Label();
        CopyrightLabel = new Label();
        MainTableLayoutPanel.SuspendLayout();
        SuspendLayout();
        // 
        // MainTableLayoutPanel
        // 
        MainTableLayoutPanel.ColumnCount = 2;
        MainTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 246F));
        MainTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        MainTableLayoutPanel.Controls.Add(LogoPanel, 0, 0);
        MainTableLayoutPanel.Controls.Add(TitleLabel, 1, 0);
        MainTableLayoutPanel.Controls.Add(VersionLabel, 1, 1);
        MainTableLayoutPanel.Controls.Add(CopyrightLabel, 1, 2);
        MainTableLayoutPanel.Dock = DockStyle.Fill;
        MainTableLayoutPanel.Location = new Point(0, 0);
        MainTableLayoutPanel.Name = "MainTableLayoutPanel";
        MainTableLayoutPanel.RowCount = 3;
        MainTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 59F));
        MainTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 18F));
        MainTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 23F));
        MainTableLayoutPanel.Size = new Size(616, 260);
        MainTableLayoutPanel.TabIndex = 0;
        // 
        // LogoPanel
        // 
        LogoPanel.BackColor = Color.White;
        LogoPanel.Dock = DockStyle.Fill;
        LogoPanel.Location = new Point(3, 3);
        LogoPanel.Name = "LogoPanel";
        MainTableLayoutPanel.SetRowSpan(LogoPanel, 3);
        LogoPanel.Size = new Size(240, 254);
        LogoPanel.TabIndex = 0;
        LogoPanel.Paint += LogoPanel_Paint;
        // 
        // TitleLabel
        // 
        TitleLabel.Dock = DockStyle.Fill;
        TitleLabel.Font = new Font("Segoe UI", 17F, FontStyle.Bold, GraphicsUnit.Point);
        TitleLabel.Location = new Point(249, 0);
        TitleLabel.Name = "TitleLabel";
        TitleLabel.Size = new Size(364, 153);
        TitleLabel.TabIndex = 1;
        TitleLabel.Text = "R 'n R for Reading\nand Refreshment";
        TitleLabel.TextAlign = ContentAlignment.BottomLeft;
        // 
        // VersionLabel
        // 
        VersionLabel.Dock = DockStyle.Fill;
        VersionLabel.Location = new Point(249, 153);
        VersionLabel.Name = "VersionLabel";
        VersionLabel.Size = new Size(364, 46);
        VersionLabel.TabIndex = 2;
        VersionLabel.Text = "Version 1.0.0";
        VersionLabel.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // CopyrightLabel
        // 
        CopyrightLabel.Dock = DockStyle.Fill;
        CopyrightLabel.Location = new Point(249, 199);
        CopyrightLabel.Name = "CopyrightLabel";
        CopyrightLabel.Size = new Size(364, 61);
        CopyrightLabel.TabIndex = 3;
        CopyrightLabel.Text = "Copyright 2026";
        CopyrightLabel.TextAlign = ContentAlignment.TopLeft;
        // 
        // SplashForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.White;
        ClientSize = new Size(616, 260);
        Controls.Add(MainTableLayoutPanel);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "SplashForm";
        ShowIcon = false;
        ShowInTaskbar = false;
        StartPosition = FormStartPosition.CenterScreen;
        Text = "R 'n R for Reading and Refreshment";
        MainTableLayoutPanel.ResumeLayout(false);
        ResumeLayout(false);
    }
}
