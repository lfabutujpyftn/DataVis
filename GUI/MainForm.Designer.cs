﻿namespace GUI
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
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Multiline = true;
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(467, 296);
            this.tabControl.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.buttonPlotCT);
            this.tabPage1.Controls.Add(this.checkedListBoxTime);
            this.tabPage1.Controls.Add(this.checkedListBoxColoms);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(459, 270);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Const T";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // buttonPlotCT
            // 
            this.buttonPlotCT.Location = new System.Drawing.Point(378, 241);
            this.buttonPlotCT.Name = "buttonPlotCT";
            this.buttonPlotCT.Size = new System.Drawing.Size(75, 23);
            this.buttonPlotCT.TabIndex = 3;
            this.buttonPlotCT.Text = "Plot";
            this.buttonPlotCT.UseVisualStyleBackColor = true;
            this.buttonPlotCT.Click += new System.EventHandler(this.buttonPlotCT_Click);
            // 
            // checkedListBoxTime
            // 
            this.checkedListBoxTime.FormattingEnabled = true;
            this.checkedListBoxTime.Location = new System.Drawing.Point(6, 6);
            this.checkedListBoxTime.Name = "checkedListBoxTime";
            this.checkedListBoxTime.Size = new System.Drawing.Size(137, 259);
            this.checkedListBoxTime.TabIndex = 2;
            // 
            // checkedListBoxColoms
            // 
            this.checkedListBoxColoms.FormattingEnabled = true;
            this.checkedListBoxColoms.Location = new System.Drawing.Point(149, 6);
            this.checkedListBoxColoms.Name = "checkedListBoxColoms";
            this.checkedListBoxColoms.Size = new System.Drawing.Size(137, 259);
            this.checkedListBoxColoms.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(459, 270);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(362, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 320);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tabControl);
            this.Name = "MainForm";
            this.Text = "Program";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.CheckedListBox checkedListBoxColoms;
        private System.Windows.Forms.CheckedListBox checkedListBoxTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonPlotCT;
    }
}

