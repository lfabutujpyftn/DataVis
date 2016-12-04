namespace GUI
{
    partial class MainForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.buttonPlotCT = new System.Windows.Forms.Button();
            this.checkedListBoxTime = new System.Windows.Forms.CheckedListBox();
            this.checkedListBoxColoms = new System.Windows.Forms.CheckedListBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.checkedListBoxColAlongId = new System.Windows.Forms.CheckedListBox();
            this.buttonPlotAlongId = new System.Windows.Forms.Button();
            this.checkedListBoxAlongId = new System.Windows.Forms.CheckedListBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.buttonPlotXt = new System.Windows.Forms.Button();
            this.checkedListBoxXT = new System.Windows.Forms.CheckedListBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.parseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.legendToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sortingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lineTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rangeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoscaleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xrangeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yrangeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.videlitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.videlitallToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ochistitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBoxFind = new System.Windows.Forms.TextBox();
            this.buttonFind = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Controls.Add(this.tabPage3);
            this.tabControl.Location = new System.Drawing.Point(12, 27);
            this.tabControl.Multiline = true;
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(467, 281);
            this.tabControl.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.buttonFind);
            this.tabPage1.Controls.Add(this.textBoxFind);
            this.tabPage1.Controls.Add(this.buttonPlotCT);
            this.tabPage1.Controls.Add(this.checkedListBoxTime);
            this.tabPage1.Controls.Add(this.checkedListBoxColoms);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(459, 255);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Const T";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // buttonPlotCT
            // 
            this.buttonPlotCT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPlotCT.Location = new System.Drawing.Point(378, 226);
            this.buttonPlotCT.Name = "buttonPlotCT";
            this.buttonPlotCT.Size = new System.Drawing.Size(75, 23);
            this.buttonPlotCT.TabIndex = 3;
            this.buttonPlotCT.Text = "Plot";
            this.buttonPlotCT.UseVisualStyleBackColor = true;
            this.buttonPlotCT.Click += new System.EventHandler(this.buttonPlotCT_Click);
            // 
            // checkedListBoxTime
            // 
            this.checkedListBoxTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.checkedListBoxTime.FormattingEnabled = true;
            this.checkedListBoxTime.Location = new System.Drawing.Point(3, 5);
            this.checkedListBoxTime.Name = "checkedListBoxTime";
            this.checkedListBoxTime.Size = new System.Drawing.Size(199, 214);
            this.checkedListBoxTime.TabIndex = 2;
            // 
            // checkedListBoxColoms
            // 
            this.checkedListBoxColoms.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.checkedListBoxColoms.FormattingEnabled = true;
            this.checkedListBoxColoms.Location = new System.Drawing.Point(208, 5);
            this.checkedListBoxColoms.Name = "checkedListBoxColoms";
            this.checkedListBoxColoms.Size = new System.Drawing.Size(164, 244);
            this.checkedListBoxColoms.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.checkedListBoxColAlongId);
            this.tabPage2.Controls.Add(this.buttonPlotAlongId);
            this.tabPage2.Controls.Add(this.checkedListBoxAlongId);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(459, 255);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "AlongID";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // checkedListBoxColAlongId
            // 
            this.checkedListBoxColAlongId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.checkedListBoxColAlongId.FormattingEnabled = true;
            this.checkedListBoxColAlongId.Location = new System.Drawing.Point(208, 5);
            this.checkedListBoxColAlongId.Name = "checkedListBoxColAlongId";
            this.checkedListBoxColAlongId.Size = new System.Drawing.Size(164, 244);
            this.checkedListBoxColAlongId.TabIndex = 2;
            // 
            // buttonPlotAlongId
            // 
            this.buttonPlotAlongId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPlotAlongId.Location = new System.Drawing.Point(378, 226);
            this.buttonPlotAlongId.Name = "buttonPlotAlongId";
            this.buttonPlotAlongId.Size = new System.Drawing.Size(75, 23);
            this.buttonPlotAlongId.TabIndex = 1;
            this.buttonPlotAlongId.Text = "Plot";
            this.buttonPlotAlongId.UseVisualStyleBackColor = true;
            this.buttonPlotAlongId.Click += new System.EventHandler(this.buttonPlotAlongId_Click);
            // 
            // checkedListBoxAlongId
            // 
            this.checkedListBoxAlongId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.checkedListBoxAlongId.FormattingEnabled = true;
            this.checkedListBoxAlongId.Location = new System.Drawing.Point(6, 5);
            this.checkedListBoxAlongId.Name = "checkedListBoxAlongId";
            this.checkedListBoxAlongId.Size = new System.Drawing.Size(196, 244);
            this.checkedListBoxAlongId.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.buttonPlotXt);
            this.tabPage3.Controls.Add(this.checkedListBoxXT);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(459, 255);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "XT";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // buttonPlotXt
            // 
            this.buttonPlotXt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPlotXt.Location = new System.Drawing.Point(378, 226);
            this.buttonPlotXt.Name = "buttonPlotXt";
            this.buttonPlotXt.Size = new System.Drawing.Size(75, 23);
            this.buttonPlotXt.TabIndex = 1;
            this.buttonPlotXt.Text = "Plot";
            this.buttonPlotXt.UseVisualStyleBackColor = true;
            this.buttonPlotXt.Click += new System.EventHandler(this.buttonPlotXt_Click);
            // 
            // checkedListBoxXT
            // 
            this.checkedListBoxXT.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.checkedListBoxXT.FormattingEnabled = true;
            this.checkedListBoxXT.Location = new System.Drawing.Point(6, 6);
            this.checkedListBoxXT.Name = "checkedListBoxXT";
            this.checkedListBoxXT.Size = new System.Drawing.Size(366, 244);
            this.checkedListBoxXT.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.settingToolStripMenuItem,
            this.videlitToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(491, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.parseToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // parseToolStripMenuItem
            // 
            this.parseToolStripMenuItem.Name = "parseToolStripMenuItem";
            this.parseToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.parseToolStripMenuItem.Text = "Parse";
            this.parseToolStripMenuItem.Click += new System.EventHandler(this.parseToolStripMenuItem_Click);
            // 
            // settingToolStripMenuItem
            // 
            this.settingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.legendToolStripMenuItem,
            this.sortingToolStripMenuItem,
            this.rangeToolStripMenuItem});
            this.settingToolStripMenuItem.Name = "settingToolStripMenuItem";
            this.settingToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.settingToolStripMenuItem.Text = "Setting";
            // 
            // legendToolStripMenuItem
            // 
            this.legendToolStripMenuItem.Name = "legendToolStripMenuItem";
            this.legendToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.legendToolStripMenuItem.Text = "Legend";
            this.legendToolStripMenuItem.Click += new System.EventHandler(this.legendToolStripMenuItem_Click);
            // 
            // sortingToolStripMenuItem
            // 
            this.sortingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iDToolStripMenuItem,
            this.lineTypeToolStripMenuItem});
            this.sortingToolStripMenuItem.Name = "sortingToolStripMenuItem";
            this.sortingToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.sortingToolStripMenuItem.Text = "Sorting";
            // 
            // iDToolStripMenuItem
            // 
            this.iDToolStripMenuItem.Checked = true;
            this.iDToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.iDToolStripMenuItem.Name = "iDToolStripMenuItem";
            this.iDToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.iDToolStripMenuItem.Text = "ID";
            this.iDToolStripMenuItem.Click += new System.EventHandler(this.iDToolStripMenuItem_Click);
            // 
            // lineTypeToolStripMenuItem
            // 
            this.lineTypeToolStripMenuItem.Name = "lineTypeToolStripMenuItem";
            this.lineTypeToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.lineTypeToolStripMenuItem.Text = "Line type";
            this.lineTypeToolStripMenuItem.Click += new System.EventHandler(this.lineTypeToolStripMenuItem_Click);
            // 
            // rangeToolStripMenuItem
            // 
            this.rangeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.autoscaleToolStripMenuItem,
            this.xrangeToolStripMenuItem,
            this.yrangeToolStripMenuItem});
            this.rangeToolStripMenuItem.Name = "rangeToolStripMenuItem";
            this.rangeToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.rangeToolStripMenuItem.Text = "Range";
            // 
            // autoscaleToolStripMenuItem
            // 
            this.autoscaleToolStripMenuItem.Checked = true;
            this.autoscaleToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.autoscaleToolStripMenuItem.Name = "autoscaleToolStripMenuItem";
            this.autoscaleToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.autoscaleToolStripMenuItem.Text = "Autoscale";
            this.autoscaleToolStripMenuItem.Click += new System.EventHandler(this.autoscaleToolStripMenuItem_Click);
            // 
            // xrangeToolStripMenuItem
            // 
            this.xrangeToolStripMenuItem.Name = "xrangeToolStripMenuItem";
            this.xrangeToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.xrangeToolStripMenuItem.Text = "Xrange";
            this.xrangeToolStripMenuItem.Click += new System.EventHandler(this.xrangeToolStripMenuItem_Click);
            // 
            // yrangeToolStripMenuItem
            // 
            this.yrangeToolStripMenuItem.Name = "yrangeToolStripMenuItem";
            this.yrangeToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.yrangeToolStripMenuItem.Text = "Yrange";
            this.yrangeToolStripMenuItem.Click += new System.EventHandler(this.yrangeToolStripMenuItem_Click);
            // 
            // videlitToolStripMenuItem
            // 
            this.videlitToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.videlitallToolStripMenuItem,
            this.ochistitToolStripMenuItem});
            this.videlitToolStripMenuItem.Name = "videlitToolStripMenuItem";
            this.videlitToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.videlitToolStripMenuItem.Text = "Selecting";
            // 
            // videlitallToolStripMenuItem
            // 
            this.videlitallToolStripMenuItem.Name = "videlitallToolStripMenuItem";
            this.videlitallToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.videlitallToolStripMenuItem.Text = "Select all";
            this.videlitallToolStripMenuItem.Click += new System.EventHandler(this.videlitallToolStripMenuItem_Click);
            // 
            // ochistitToolStripMenuItem
            // 
            this.ochistitToolStripMenuItem.Name = "ochistitToolStripMenuItem";
            this.ochistitToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.ochistitToolStripMenuItem.Text = "Clean all";
            this.ochistitToolStripMenuItem.Click += new System.EventHandler(this.ochistitToolStripMenuItem_Click);
            // 
            // textBoxFind
            // 
            this.textBoxFind.Location = new System.Drawing.Point(3, 229);
            this.textBoxFind.Name = "textBoxFind";
            this.textBoxFind.Size = new System.Drawing.Size(118, 20);
            this.textBoxFind.TabIndex = 4;
            // 
            // buttonFind
            // 
            this.buttonFind.Location = new System.Drawing.Point(127, 227);
            this.buttonFind.Name = "buttonFind";
            this.buttonFind.Size = new System.Drawing.Size(75, 23);
            this.buttonFind.TabIndex = 5;
            this.buttonFind.Text = "Find";
            this.buttonFind.UseVisualStyleBackColor = true;
            this.buttonFind.Click += new System.EventHandler(this.buttonFind_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 320);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(507, 359);
            this.Name = "MainForm";
            this.Text = "Program";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.CheckedListBox checkedListBoxColoms;
        private System.Windows.Forms.CheckedListBox checkedListBoxTime;
        private System.Windows.Forms.Button buttonPlotCT;
        private System.Windows.Forms.CheckedListBox checkedListBoxAlongId;
        private System.Windows.Forms.Button buttonPlotAlongId;
        private System.Windows.Forms.CheckedListBox checkedListBoxColAlongId;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button buttonPlotXt;
        private System.Windows.Forms.CheckedListBox checkedListBoxXT;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem settingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem legendToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem videlitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem videlitallToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ochistitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sortingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lineTypeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem parseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rangeToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem autoscaleToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem xrangeToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem yrangeToolStripMenuItem;
        private System.Windows.Forms.Button buttonFind;
        private System.Windows.Forms.TextBox textBoxFind;
    }
}

