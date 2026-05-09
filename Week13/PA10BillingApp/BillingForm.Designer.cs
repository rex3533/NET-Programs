namespace PA10BillingApp;

partial class BillingForm
{
    private System.ComponentModel.IContainer? components = null;

    private MenuStrip MenuStrip1 = null!;
    private ToolStripMenuItem FileToolStripMenuItem = null!;
    private ToolStripMenuItem NewOrderToolStripMenuItem = null!;
    private ToolStripMenuItem SummaryToolStripMenuItem = null!;
    private ToolStripMenuItem ExitToolStripMenuItem = null!;
    private ToolStripMenuItem EditToolStripMenuItem = null!;
    private ToolStripMenuItem CalculateSelectionToolStripMenuItem = null!;
    private ToolStripMenuItem ClearItemToolStripMenuItem = null!;
    private ToolStripMenuItem FontToolStripMenuItem = null!;
    private ToolStripMenuItem ColorToolStripMenuItem = null!;
    private ToolStripMenuItem HelpToolStripMenuItem = null!;
    private ToolStripMenuItem AboutToolStripMenuItem = null!;
    private GroupBox OrderInformationGroupBox = null!;
    private GroupBox CoffeeSelectionsGroupBox = null!;
    private GroupBox TotalsGroupBox = null!;
    private Label QuantityLabel = null!;
    private Label ItemAmountLabel = null!;
    private Label SubTotalLabel = null!;
    private Label TaxLabel = null!;
    private Label TotalLabel = null!;
    private TextBox QuantityTextBox = null!;
    private TextBox ItemAmountTextBox = null!;
    private TextBox SubTotalTextBox = null!;
    private TextBox TaxTextBox = null!;
    private TextBox TotalTextBox = null!;
    private CheckBox TaxCheckBox = null!;
    private Button CalculateButton = null!;
    private Button ClearButton = null!;
    private RadioButton CappuccinoRadioButton = null!;
    private RadioButton EspressoRadioButton = null!;
    private RadioButton LatteRadioButton = null!;
    private RadioButton IcedLatteRadioButton = null!;
    private RadioButton IcedCappuccinoRadioButton = null!;
    private FontDialog FontDialog1 = null!;
    private ColorDialog ColorDialog1 = null!;

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
        components = new System.ComponentModel.Container();
        MenuStrip1 = new MenuStrip();
        FileToolStripMenuItem = new ToolStripMenuItem();
        NewOrderToolStripMenuItem = new ToolStripMenuItem();
        SummaryToolStripMenuItem = new ToolStripMenuItem();
        ExitToolStripMenuItem = new ToolStripMenuItem();
        EditToolStripMenuItem = new ToolStripMenuItem();
        CalculateSelectionToolStripMenuItem = new ToolStripMenuItem();
        ClearItemToolStripMenuItem = new ToolStripMenuItem();
        FontToolStripMenuItem = new ToolStripMenuItem();
        ColorToolStripMenuItem = new ToolStripMenuItem();
        HelpToolStripMenuItem = new ToolStripMenuItem();
        AboutToolStripMenuItem = new ToolStripMenuItem();
        OrderInformationGroupBox = new GroupBox();
        QuantityLabel = new Label();
        QuantityTextBox = new TextBox();
        TaxCheckBox = new CheckBox();
        CalculateButton = new Button();
        ClearButton = new Button();
        ItemAmountLabel = new Label();
        ItemAmountTextBox = new TextBox();
        CoffeeSelectionsGroupBox = new GroupBox();
        CappuccinoRadioButton = new RadioButton();
        EspressoRadioButton = new RadioButton();
        LatteRadioButton = new RadioButton();
        IcedLatteRadioButton = new RadioButton();
        IcedCappuccinoRadioButton = new RadioButton();
        TotalsGroupBox = new GroupBox();
        SubTotalLabel = new Label();
        SubTotalTextBox = new TextBox();
        TaxLabel = new Label();
        TaxTextBox = new TextBox();
        TotalLabel = new Label();
        TotalTextBox = new TextBox();
        FontDialog1 = new FontDialog();
        ColorDialog1 = new ColorDialog();
        MenuStrip1.SuspendLayout();
        OrderInformationGroupBox.SuspendLayout();
        CoffeeSelectionsGroupBox.SuspendLayout();
        TotalsGroupBox.SuspendLayout();
        SuspendLayout();
        // 
        // MenuStrip1
        // 
        MenuStrip1.Items.AddRange(new ToolStripItem[]
        {
            FileToolStripMenuItem,
            EditToolStripMenuItem,
            HelpToolStripMenuItem
        });
        MenuStrip1.Location = new Point(0, 0);
        MenuStrip1.Name = "MenuStrip1";
        MenuStrip1.Size = new Size(667, 24);
        MenuStrip1.TabIndex = 0;
        // 
        // FileToolStripMenuItem
        // 
        FileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[]
        {
            NewOrderToolStripMenuItem,
            SummaryToolStripMenuItem,
            new ToolStripSeparator(),
            ExitToolStripMenuItem
        });
        FileToolStripMenuItem.Name = "FileToolStripMenuItem";
        FileToolStripMenuItem.Size = new Size(37, 20);
        FileToolStripMenuItem.Text = "&File";
        // 
        // NewOrderToolStripMenuItem
        // 
        NewOrderToolStripMenuItem.Enabled = false;
        NewOrderToolStripMenuItem.Name = "NewOrderToolStripMenuItem";
        NewOrderToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.N;
        NewOrderToolStripMenuItem.Size = new Size(177, 22);
        NewOrderToolStripMenuItem.Text = "&New Order";
        NewOrderToolStripMenuItem.Click += NewOrderToolStripMenuItem_Click;
        // 
        // SummaryToolStripMenuItem
        // 
        SummaryToolStripMenuItem.Name = "SummaryToolStripMenuItem";
        SummaryToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.S;
        SummaryToolStripMenuItem.Size = new Size(177, 22);
        SummaryToolStripMenuItem.Text = "&Summary";
        SummaryToolStripMenuItem.Click += SummaryToolStripMenuItem_Click;
        // 
        // ExitToolStripMenuItem
        // 
        ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
        ExitToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.F4;
        ExitToolStripMenuItem.Size = new Size(177, 22);
        ExitToolStripMenuItem.Text = "E&xit";
        ExitToolStripMenuItem.Click += ExitToolStripMenuItem_Click;
        // 
        // EditToolStripMenuItem
        // 
        EditToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[]
        {
            CalculateSelectionToolStripMenuItem,
            ClearItemToolStripMenuItem,
            new ToolStripSeparator(),
            FontToolStripMenuItem,
            ColorToolStripMenuItem
        });
        EditToolStripMenuItem.Name = "EditToolStripMenuItem";
        EditToolStripMenuItem.Size = new Size(39, 20);
        EditToolStripMenuItem.Text = "&Edit";
        // 
        // CalculateSelectionToolStripMenuItem
        // 
        CalculateSelectionToolStripMenuItem.Name = "CalculateSelectionToolStripMenuItem";
        CalculateSelectionToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.C;
        CalculateSelectionToolStripMenuItem.Size = new Size(219, 22);
        CalculateSelectionToolStripMenuItem.Text = "&Calculate Selection";
        CalculateSelectionToolStripMenuItem.Click += CalculateSelectionToolStripMenuItem_Click;
        // 
        // ClearItemToolStripMenuItem
        // 
        ClearItemToolStripMenuItem.Enabled = false;
        ClearItemToolStripMenuItem.Name = "ClearItemToolStripMenuItem";
        ClearItemToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.L;
        ClearItemToolStripMenuItem.Size = new Size(219, 22);
        ClearItemToolStripMenuItem.Text = "C&lear Item";
        ClearItemToolStripMenuItem.Click += ClearItemToolStripMenuItem_Click;
        // 
        // FontToolStripMenuItem
        // 
        FontToolStripMenuItem.Name = "FontToolStripMenuItem";
        FontToolStripMenuItem.Size = new Size(219, 22);
        FontToolStripMenuItem.Text = "&Font...";
        FontToolStripMenuItem.Click += FontToolStripMenuItem_Click;
        // 
        // ColorToolStripMenuItem
        // 
        ColorToolStripMenuItem.Name = "ColorToolStripMenuItem";
        ColorToolStripMenuItem.Size = new Size(219, 22);
        ColorToolStripMenuItem.Text = "&Color...";
        ColorToolStripMenuItem.Click += ColorToolStripMenuItem_Click;
        // 
        // HelpToolStripMenuItem
        // 
        HelpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[]
        {
            AboutToolStripMenuItem
        });
        HelpToolStripMenuItem.Name = "HelpToolStripMenuItem";
        HelpToolStripMenuItem.Size = new Size(44, 20);
        HelpToolStripMenuItem.Text = "&Help";
        // 
        // AboutToolStripMenuItem
        // 
        AboutToolStripMenuItem.Name = "AboutToolStripMenuItem";
        AboutToolStripMenuItem.Size = new Size(107, 22);
        AboutToolStripMenuItem.Text = "&About";
        AboutToolStripMenuItem.Click += AboutToolStripMenuItem_Click;
        // 
        // OrderInformationGroupBox
        // 
        OrderInformationGroupBox.Controls.Add(QuantityLabel);
        OrderInformationGroupBox.Controls.Add(QuantityTextBox);
        OrderInformationGroupBox.Controls.Add(TaxCheckBox);
        OrderInformationGroupBox.Controls.Add(CalculateButton);
        OrderInformationGroupBox.Controls.Add(ClearButton);
        OrderInformationGroupBox.Controls.Add(ItemAmountLabel);
        OrderInformationGroupBox.Controls.Add(ItemAmountTextBox);
        OrderInformationGroupBox.Location = new Point(24, 47);
        OrderInformationGroupBox.Name = "OrderInformationGroupBox";
        OrderInformationGroupBox.Size = new Size(283, 244);
        OrderInformationGroupBox.TabIndex = 1;
        OrderInformationGroupBox.TabStop = false;
        OrderInformationGroupBox.Text = "Order Information";
        // 
        // QuantityLabel
        // 
        QuantityLabel.AutoSize = true;
        QuantityLabel.Location = new Point(25, 39);
        QuantityLabel.Name = "QuantityLabel";
        QuantityLabel.Size = new Size(53, 15);
        QuantityLabel.TabIndex = 0;
        QuantityLabel.Text = "Quantity";
        // 
        // QuantityTextBox
        // 
        QuantityTextBox.Location = new Point(107, 36);
        QuantityTextBox.Name = "QuantityTextBox";
        QuantityTextBox.Size = new Size(72, 23);
        QuantityTextBox.TabIndex = 1;
        QuantityTextBox.TextAlign = HorizontalAlignment.Right;
        // 
        // TaxCheckBox
        // 
        TaxCheckBox.AutoSize = true;
        TaxCheckBox.Location = new Point(25, 82);
        TaxCheckBox.Name = "TaxCheckBox";
        TaxCheckBox.Size = new Size(75, 19);
        TaxCheckBox.TabIndex = 2;
        TaxCheckBox.Text = "Takeout?";
        TaxCheckBox.UseVisualStyleBackColor = true;
        // 
        // CalculateButton
        // 
        CalculateButton.Location = new Point(25, 125);
        CalculateButton.Name = "CalculateButton";
        CalculateButton.Size = new Size(93, 58);
        CalculateButton.TabIndex = 3;
        CalculateButton.Text = "Calculate\r\nSelection";
        CalculateButton.UseVisualStyleBackColor = true;
        CalculateButton.Click += CalculateButton_Click;
        // 
        // ClearButton
        // 
        ClearButton.Enabled = false;
        ClearButton.Location = new Point(143, 125);
        ClearButton.Name = "ClearButton";
        ClearButton.Size = new Size(93, 58);
        ClearButton.TabIndex = 4;
        ClearButton.Text = "Clear for\r\nNext Item";
        ClearButton.UseVisualStyleBackColor = true;
        ClearButton.Click += ClearButton_Click;
        // 
        // ItemAmountLabel
        // 
        ItemAmountLabel.AutoSize = true;
        ItemAmountLabel.Location = new Point(25, 210);
        ItemAmountLabel.Name = "ItemAmountLabel";
        ItemAmountLabel.Size = new Size(78, 15);
        ItemAmountLabel.TabIndex = 5;
        ItemAmountLabel.Text = "Item Amount";
        // 
        // ItemAmountTextBox
        // 
        ItemAmountTextBox.Location = new Point(134, 207);
        ItemAmountTextBox.Name = "ItemAmountTextBox";
        ItemAmountTextBox.ReadOnly = true;
        ItemAmountTextBox.Size = new Size(102, 23);
        ItemAmountTextBox.TabIndex = 6;
        ItemAmountTextBox.TabStop = false;
        ItemAmountTextBox.TextAlign = HorizontalAlignment.Right;
        // 
        // CoffeeSelectionsGroupBox
        // 
        CoffeeSelectionsGroupBox.Controls.Add(CappuccinoRadioButton);
        CoffeeSelectionsGroupBox.Controls.Add(EspressoRadioButton);
        CoffeeSelectionsGroupBox.Controls.Add(LatteRadioButton);
        CoffeeSelectionsGroupBox.Controls.Add(IcedLatteRadioButton);
        CoffeeSelectionsGroupBox.Controls.Add(IcedCappuccinoRadioButton);
        CoffeeSelectionsGroupBox.Location = new Point(345, 47);
        CoffeeSelectionsGroupBox.Name = "CoffeeSelectionsGroupBox";
        CoffeeSelectionsGroupBox.Size = new Size(283, 244);
        CoffeeSelectionsGroupBox.TabIndex = 2;
        CoffeeSelectionsGroupBox.TabStop = false;
        CoffeeSelectionsGroupBox.Text = "Coffee Selections";
        // 
        // CappuccinoRadioButton
        // 
        CappuccinoRadioButton.AutoSize = true;
        CappuccinoRadioButton.Checked = true;
        CappuccinoRadioButton.Location = new Point(36, 37);
        CappuccinoRadioButton.Name = "CappuccinoRadioButton";
        CappuccinoRadioButton.Size = new Size(89, 19);
        CappuccinoRadioButton.TabIndex = 0;
        CappuccinoRadioButton.TabStop = true;
        CappuccinoRadioButton.Text = "Cappuccino";
        CappuccinoRadioButton.UseVisualStyleBackColor = true;
        // 
        // EspressoRadioButton
        // 
        EspressoRadioButton.AutoSize = true;
        EspressoRadioButton.Location = new Point(36, 76);
        EspressoRadioButton.Name = "EspressoRadioButton";
        EspressoRadioButton.Size = new Size(70, 19);
        EspressoRadioButton.TabIndex = 1;
        EspressoRadioButton.Text = "Espresso";
        EspressoRadioButton.UseVisualStyleBackColor = true;
        // 
        // LatteRadioButton
        // 
        LatteRadioButton.AutoSize = true;
        LatteRadioButton.Location = new Point(36, 115);
        LatteRadioButton.Name = "LatteRadioButton";
        LatteRadioButton.Size = new Size(51, 19);
        LatteRadioButton.TabIndex = 2;
        LatteRadioButton.Text = "Latte";
        LatteRadioButton.UseVisualStyleBackColor = true;
        // 
        // IcedLatteRadioButton
        // 
        IcedLatteRadioButton.AutoSize = true;
        IcedLatteRadioButton.Location = new Point(36, 154);
        IcedLatteRadioButton.Name = "IcedLatteRadioButton";
        IcedLatteRadioButton.Size = new Size(78, 19);
        IcedLatteRadioButton.TabIndex = 3;
        IcedLatteRadioButton.Text = "Iced Latte";
        IcedLatteRadioButton.UseVisualStyleBackColor = true;
        // 
        // IcedCappuccinoRadioButton
        // 
        IcedCappuccinoRadioButton.AutoSize = true;
        IcedCappuccinoRadioButton.Location = new Point(36, 193);
        IcedCappuccinoRadioButton.Name = "IcedCappuccinoRadioButton";
        IcedCappuccinoRadioButton.Size = new Size(117, 19);
        IcedCappuccinoRadioButton.TabIndex = 4;
        IcedCappuccinoRadioButton.Text = "Iced Cappuccino";
        IcedCappuccinoRadioButton.UseVisualStyleBackColor = true;
        // 
        // TotalsGroupBox
        // 
        TotalsGroupBox.Controls.Add(SubTotalLabel);
        TotalsGroupBox.Controls.Add(SubTotalTextBox);
        TotalsGroupBox.Controls.Add(TaxLabel);
        TotalsGroupBox.Controls.Add(TaxTextBox);
        TotalsGroupBox.Controls.Add(TotalLabel);
        TotalsGroupBox.Controls.Add(TotalTextBox);
        TotalsGroupBox.Location = new Point(24, 324);
        TotalsGroupBox.Name = "TotalsGroupBox";
        TotalsGroupBox.Size = new Size(604, 137);
        TotalsGroupBox.TabIndex = 3;
        TotalsGroupBox.TabStop = false;
        // 
        // SubTotalLabel
        // 
        SubTotalLabel.Location = new Point(110, 30);
        SubTotalLabel.Name = "SubTotalLabel";
        SubTotalLabel.Size = new Size(94, 20);
        SubTotalLabel.TabIndex = 0;
        SubTotalLabel.Text = "SubTotal";
        SubTotalLabel.TextAlign = ContentAlignment.MiddleRight;
        // 
        // SubTotalTextBox
        // 
        SubTotalTextBox.Location = new Point(232, 29);
        SubTotalTextBox.Name = "SubTotalTextBox";
        SubTotalTextBox.ReadOnly = true;
        SubTotalTextBox.Size = new Size(100, 23);
        SubTotalTextBox.TabIndex = 1;
        SubTotalTextBox.TabStop = false;
        SubTotalTextBox.TextAlign = HorizontalAlignment.Right;
        // 
        // TaxLabel
        // 
        TaxLabel.Location = new Point(110, 66);
        TaxLabel.Name = "TaxLabel";
        TaxLabel.Size = new Size(94, 20);
        TaxLabel.TabIndex = 2;
        TaxLabel.Text = "Tax (if Takeout)";
        TaxLabel.TextAlign = ContentAlignment.MiddleRight;
        // 
        // TaxTextBox
        // 
        TaxTextBox.Location = new Point(232, 65);
        TaxTextBox.Name = "TaxTextBox";
        TaxTextBox.ReadOnly = true;
        TaxTextBox.Size = new Size(100, 23);
        TaxTextBox.TabIndex = 3;
        TaxTextBox.TabStop = false;
        TaxTextBox.TextAlign = HorizontalAlignment.Right;
        // 
        // TotalLabel
        // 
        TotalLabel.Location = new Point(110, 101);
        TotalLabel.Name = "TotalLabel";
        TotalLabel.Size = new Size(94, 20);
        TotalLabel.TabIndex = 4;
        TotalLabel.Text = "Total Due";
        TotalLabel.TextAlign = ContentAlignment.MiddleRight;
        // 
        // TotalTextBox
        // 
        TotalTextBox.Location = new Point(232, 100);
        TotalTextBox.Name = "TotalTextBox";
        TotalTextBox.ReadOnly = true;
        TotalTextBox.Size = new Size(100, 23);
        TotalTextBox.TabIndex = 5;
        TotalTextBox.TabStop = false;
        TotalTextBox.TextAlign = HorizontalAlignment.Right;
        // 
        // BillingForm
        // 
        AcceptButton = CalculateButton;
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(667, 489);
        Controls.Add(TotalsGroupBox);
        Controls.Add(CoffeeSelectionsGroupBox);
        Controls.Add(OrderInformationGroupBox);
        Controls.Add(MenuStrip1);
        MainMenuStrip = MenuStrip1;
        MinimumSize = new Size(683, 528);
        Name = "BillingForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "R 'n R for Reading and Refreshment";
        MenuStrip1.ResumeLayout(false);
        MenuStrip1.PerformLayout();
        OrderInformationGroupBox.ResumeLayout(false);
        OrderInformationGroupBox.PerformLayout();
        CoffeeSelectionsGroupBox.ResumeLayout(false);
        CoffeeSelectionsGroupBox.PerformLayout();
        TotalsGroupBox.ResumeLayout(false);
        TotalsGroupBox.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }
}
