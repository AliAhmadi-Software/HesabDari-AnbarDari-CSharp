namespace HesabdariAnbardari
{
    partial class frmChekDaryafti
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChekDaryafti));
            this.mskSarResid = new DevComponents.DotNetBar.Controls.MaskedTextBoxAdv();
            this.mskTarikh = new DevComponents.DotNetBar.Controls.MaskedTextBoxAdv();
            this.cmbVaziyat = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem1 = new DevComponents.Editors.ComboItem();
            this.comboItem2 = new DevComponents.Editors.ComboItem();
            this.comboItem3 = new DevComponents.Editors.ComboItem();
            this.txtMablagh = new DevComponents.Editors.IntegerInput();
            this.txtShomareSanad = new DevComponents.Editors.IntegerInput();
            this.txtShomareHesab = new DevComponents.Editors.IntegerInput();
            this.txtMoshtari = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtNameHesab = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtTozih = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtIdSanad = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.groupPanel3 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.btnEdit = new DevComponents.DotNetBar.ButtonX();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.txtMablagh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtShomareSanad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtShomareHesab)).BeginInit();
            this.groupPanel1.SuspendLayout();
            this.groupPanel3.SuspendLayout();
            this.groupPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // mskSarResid
            // 
            // 
            // 
            // 
            this.mskSarResid.BackgroundStyle.Class = "TextBoxBorder";
            this.mskSarResid.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.mskSarResid.ButtonClear.Visible = true;
            this.mskSarResid.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals;
            this.mskSarResid.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Default;
            this.mskSarResid.Location = new System.Drawing.Point(3, 95);
            this.mskSarResid.Mask = "####/##/##";
            this.mskSarResid.Name = "mskSarResid";
            this.mskSarResid.Size = new System.Drawing.Size(180, 21);
            this.mskSarResid.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.mskSarResid.TabIndex = 6;
            this.mskSarResid.Text = "";
            this.mskSarResid.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.mskSarResid.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals;
            // 
            // mskTarikh
            // 
            // 
            // 
            // 
            this.mskTarikh.BackgroundStyle.Class = "TextBoxBorder";
            this.mskTarikh.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.mskTarikh.ButtonClear.Visible = true;
            this.mskTarikh.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals;
            this.mskTarikh.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Default;
            this.mskTarikh.Location = new System.Drawing.Point(273, 95);
            this.mskTarikh.Mask = "####/##/##";
            this.mskTarikh.Name = "mskTarikh";
            this.mskTarikh.Size = new System.Drawing.Size(200, 21);
            this.mskTarikh.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.mskTarikh.TabIndex = 5;
            this.mskTarikh.Text = "";
            this.mskTarikh.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.mskTarikh.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludeLiterals;
            // 
            // cmbVaziyat
            // 
            this.cmbVaziyat.DisplayMember = "Text";
            this.cmbVaziyat.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbVaziyat.FormattingEnabled = true;
            this.cmbVaziyat.ItemHeight = 16;
            this.cmbVaziyat.Items.AddRange(new object[] {
            this.comboItem1,
            this.comboItem2,
            this.comboItem3});
            this.cmbVaziyat.Location = new System.Drawing.Point(3, 122);
            this.cmbVaziyat.Name = "cmbVaziyat";
            this.cmbVaziyat.Size = new System.Drawing.Size(180, 22);
            this.cmbVaziyat.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbVaziyat.TabIndex = 8;
            // 
            // comboItem1
            // 
            this.comboItem1.Text = "عدم وصول";
            // 
            // comboItem2
            // 
            this.comboItem2.Text = "وصول شده";
            // 
            // comboItem3
            // 
            this.comboItem3.Text = "برگشت خورده";
            // 
            // txtMablagh
            // 
            // 
            // 
            // 
            this.txtMablagh.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtMablagh.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtMablagh.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtMablagh.Location = new System.Drawing.Point(3, 67);
            this.txtMablagh.Name = "txtMablagh";
            this.txtMablagh.Size = new System.Drawing.Size(180, 22);
            this.txtMablagh.TabIndex = 4;
            // 
            // txtShomareSanad
            // 
            // 
            // 
            // 
            this.txtShomareSanad.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtShomareSanad.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtShomareSanad.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtShomareSanad.Location = new System.Drawing.Point(273, 67);
            this.txtShomareSanad.Name = "txtShomareSanad";
            this.txtShomareSanad.Size = new System.Drawing.Size(200, 22);
            this.txtShomareSanad.TabIndex = 3;
            // 
            // txtShomareHesab
            // 
            // 
            // 
            // 
            this.txtShomareHesab.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtShomareHesab.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtShomareHesab.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtShomareHesab.Location = new System.Drawing.Point(273, 38);
            this.txtShomareHesab.Name = "txtShomareHesab";
            this.txtShomareHesab.Size = new System.Drawing.Size(200, 22);
            this.txtShomareHesab.TabIndex = 1;
            // 
            // txtMoshtari
            // 
            // 
            // 
            // 
            this.txtMoshtari.Border.Class = "TextBoxBorder";
            this.txtMoshtari.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtMoshtari.Location = new System.Drawing.Point(273, 122);
            this.txtMoshtari.Name = "txtMoshtari";
            this.txtMoshtari.PreventEnterBeep = true;
            this.txtMoshtari.Size = new System.Drawing.Size(200, 22);
            this.txtMoshtari.TabIndex = 7;
            // 
            // txtNameHesab
            // 
            // 
            // 
            // 
            this.txtNameHesab.Border.Class = "TextBoxBorder";
            this.txtNameHesab.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtNameHesab.Location = new System.Drawing.Point(3, 40);
            this.txtNameHesab.Name = "txtNameHesab";
            this.txtNameHesab.PreventEnterBeep = true;
            this.txtNameHesab.Size = new System.Drawing.Size(180, 22);
            this.txtNameHesab.TabIndex = 2;
            // 
            // txtTozih
            // 
            // 
            // 
            // 
            this.txtTozih.Border.Class = "TextBoxBorder";
            this.txtTozih.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTozih.Location = new System.Drawing.Point(3, 150);
            this.txtTozih.Multiline = true;
            this.txtTozih.Name = "txtTozih";
            this.txtTozih.PreventEnterBeep = true;
            this.txtTozih.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtTozih.Size = new System.Drawing.Size(470, 73);
            this.txtTozih.TabIndex = 9;
            // 
            // txtIdSanad
            // 
            // 
            // 
            // 
            this.txtIdSanad.Border.Class = "TextBoxBorder";
            this.txtIdSanad.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtIdSanad.Location = new System.Drawing.Point(336, 7);
            this.txtIdSanad.Name = "txtIdSanad";
            this.txtIdSanad.PreventEnterBeep = true;
            this.txtIdSanad.Size = new System.Drawing.Size(137, 22);
            this.txtIdSanad.TabIndex = 0;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Location = new System.Drawing.Point(480, 153);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(50, 14);
            this.label10.TabIndex = 0;
            this.label10.Text = "توضیحات";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Location = new System.Drawing.Point(189, 125);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(42, 14);
            this.label9.TabIndex = 0;
            this.label9.Text = "وضعیت";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(479, 125);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 14);
            this.label8.TabIndex = 0;
            this.label8.Text = "دریافت از";
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.groupPanel3);
            this.groupPanel1.Controls.Add(this.groupPanel2);
            this.groupPanel1.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel1.Location = new System.Drawing.Point(0, 0);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(586, 294);
            // 
            // 
            // 
            this.groupPanel1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel1.Style.BackColorGradientAngle = 90;
            this.groupPanel1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderBottomWidth = 1;
            this.groupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderLeftWidth = 1;
            this.groupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderRightWidth = 1;
            this.groupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderTopWidth = 1;
            this.groupPanel1.Style.CornerDiameter = 4;
            this.groupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel1.TabIndex = 1;
            // 
            // groupPanel3
            // 
            this.groupPanel3.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel3.Controls.Add(this.buttonX1);
            this.groupPanel3.Controls.Add(this.btnEdit);
            this.groupPanel3.Controls.Add(this.btnSave);
            this.groupPanel3.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel3.Location = new System.Drawing.Point(3, 241);
            this.groupPanel3.Name = "groupPanel3";
            this.groupPanel3.Size = new System.Drawing.Size(573, 43);
            // 
            // 
            // 
            this.groupPanel3.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel3.Style.BackColorGradientAngle = 90;
            this.groupPanel3.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel3.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderBottomWidth = 1;
            this.groupPanel3.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel3.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderLeftWidth = 1;
            this.groupPanel3.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderRightWidth = 1;
            this.groupPanel3.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderTopWidth = 1;
            this.groupPanel3.Style.CornerDiameter = 4;
            this.groupPanel3.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel3.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel3.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel3.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel3.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel3.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel3.TabIndex = 1;
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Image = ((System.Drawing.Image)(resources.GetObject("buttonX1.Image")));
            this.buttonX1.Location = new System.Drawing.Point(130, 0);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(8, 8, 2, 2);
            this.buttonX1.Size = new System.Drawing.Size(170, 37);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX1.TabIndex = 2;
            this.buttonX1.Text = "لیست اسناد دریافتی";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnEdit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.Location = new System.Drawing.Point(306, 0);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(7, 8, 2, 2);
            this.btnEdit.Size = new System.Drawing.Size(123, 37);
            this.btnEdit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "ویرایش";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.Location = new System.Drawing.Point(440, 0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(8, 8, 2, 2);
            this.btnSave.Size = new System.Drawing.Size(123, 37);
            this.btnSave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "ثبت";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupPanel2
            // 
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.mskSarResid);
            this.groupPanel2.Controls.Add(this.mskTarikh);
            this.groupPanel2.Controls.Add(this.cmbVaziyat);
            this.groupPanel2.Controls.Add(this.txtMablagh);
            this.groupPanel2.Controls.Add(this.txtShomareSanad);
            this.groupPanel2.Controls.Add(this.txtShomareHesab);
            this.groupPanel2.Controls.Add(this.txtMoshtari);
            this.groupPanel2.Controls.Add(this.txtNameHesab);
            this.groupPanel2.Controls.Add(this.txtTozih);
            this.groupPanel2.Controls.Add(this.txtIdSanad);
            this.groupPanel2.Controls.Add(this.label10);
            this.groupPanel2.Controls.Add(this.label9);
            this.groupPanel2.Controls.Add(this.label8);
            this.groupPanel2.Controls.Add(this.label7);
            this.groupPanel2.Controls.Add(this.label6);
            this.groupPanel2.Controls.Add(this.label5);
            this.groupPanel2.Controls.Add(this.label4);
            this.groupPanel2.Controls.Add(this.label3);
            this.groupPanel2.Controls.Add(this.label2);
            this.groupPanel2.Controls.Add(this.label1);
            this.groupPanel2.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel2.Location = new System.Drawing.Point(3, 3);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(573, 232);
            // 
            // 
            // 
            this.groupPanel2.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel2.Style.BackColorGradientAngle = 90;
            this.groupPanel2.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel2.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderBottomWidth = 1;
            this.groupPanel2.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel2.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderLeftWidth = 1;
            this.groupPanel2.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderRightWidth = 1;
            this.groupPanel2.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderTopWidth = 1;
            this.groupPanel2.Style.CornerDiameter = 4;
            this.groupPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel2.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel2.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel2.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel2.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(189, 102);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 14);
            this.label7.TabIndex = 0;
            this.label7.Text = "تاریخ سررسید";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(479, 102);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 14);
            this.label6.TabIndex = 0;
            this.label6.Text = "تاریخ ثبت";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(189, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 14);
            this.label5.TabIndex = 0;
            this.label5.Text = "مبلغ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(479, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 14);
            this.label4.TabIndex = 0;
            this.label4.Text = "شماره سند";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(189, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 14);
            this.label3.TabIndex = 0;
            this.label3.Text = "نام حساب";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(479, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 14);
            this.label2.TabIndex = 0;
            this.label2.Text = "شماره حساب";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(479, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "کد سند";
            // 
            // frmChekDaryafti
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(586, 294);
            this.Controls.Add(this.groupPanel1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Name = "frmChekDaryafti";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "اسناد دریافتی";
            this.Load += new System.EventHandler(this.frmChekDaryafti_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtMablagh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtShomareSanad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtShomareHesab)).EndInit();
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel3.ResumeLayout(false);
            this.groupPanel2.ResumeLayout(false);
            this.groupPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public DevComponents.DotNetBar.Controls.MaskedTextBoxAdv mskSarResid;
        public DevComponents.DotNetBar.Controls.MaskedTextBoxAdv mskTarikh;
        public DevComponents.DotNetBar.Controls.ComboBoxEx cmbVaziyat;
        private DevComponents.Editors.ComboItem comboItem1;
        private DevComponents.Editors.ComboItem comboItem2;
        private DevComponents.Editors.ComboItem comboItem3;
        public DevComponents.Editors.IntegerInput txtMablagh;
        public DevComponents.Editors.IntegerInput txtShomareSanad;
        public DevComponents.Editors.IntegerInput txtShomareHesab;
        public DevComponents.DotNetBar.Controls.TextBoxX txtMoshtari;
        public DevComponents.DotNetBar.Controls.TextBoxX txtNameHesab;
        public DevComponents.DotNetBar.Controls.TextBoxX txtTozih;
        public DevComponents.DotNetBar.Controls.TextBoxX txtIdSanad;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel3;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private DevComponents.DotNetBar.ButtonX btnEdit;
        private DevComponents.DotNetBar.ButtonX btnSave;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}