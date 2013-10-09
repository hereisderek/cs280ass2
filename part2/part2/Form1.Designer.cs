namespace part2
{
    partial class Form1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.openToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.creditTabControl = new System.Windows.Forms.TabControl();
            this.creditTp = new System.Windows.Forms.TabPage();
            this.creditDataGridView = new System.Windows.Forms.DataGridView();
            this.debitTp = new System.Windows.Forms.TabPage();
            this.debitDataGridView = new System.Windows.Forms.DataGridView();
            this.errorTp = new System.Windows.Forms.TabPage();
            this.errorDataGridView = new System.Windows.Forms.DataGridView();
            this.correctBt = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.creditTabControl.SuspendLayout();
            this.creditTp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.creditDataGridView)).BeginInit();
            this.debitTp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.debitDataGridView)).BeginInit();
            this.errorTp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem1,
            this.saveToolStripMenuItem1,
            this.saveAllToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.exitToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(736, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // openToolStripMenuItem1
            // 
            this.openToolStripMenuItem1.Name = "openToolStripMenuItem1";
            this.openToolStripMenuItem1.Size = new System.Drawing.Size(48, 20);
            this.openToolStripMenuItem1.Text = "Open";
            this.openToolStripMenuItem1.Click += new System.EventHandler(this.openToolStripMenuItem1_Click);
            // 
            // saveToolStripMenuItem1
            // 
            this.saveToolStripMenuItem1.Enabled = false;
            this.saveToolStripMenuItem1.Name = "saveToolStripMenuItem1";
            this.saveToolStripMenuItem1.Size = new System.Drawing.Size(43, 20);
            this.saveToolStripMenuItem1.Text = "Save";
            // 
            // saveAllToolStripMenuItem
            // 
            this.saveAllToolStripMenuItem.Name = "saveAllToolStripMenuItem";
            this.saveAllToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.saveAllToolStripMenuItem.Text = "Save all";
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.saveAsToolStripMenuItem.Text = "Save as..";
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            this.exitToolStripMenuItem1.Size = new System.Drawing.Size(37, 20);
            this.exitToolStripMenuItem1.Text = "Exit";
            this.exitToolStripMenuItem1.Click += new System.EventHandler(this.exitToolStripMenuItem1_Click);
            // 
            // creditTabControl
            // 
            this.creditTabControl.Controls.Add(this.creditTp);
            this.creditTabControl.Controls.Add(this.debitTp);
            this.creditTabControl.Controls.Add(this.errorTp);
            this.creditTabControl.Cursor = System.Windows.Forms.Cursors.Default;
            this.creditTabControl.Location = new System.Drawing.Point(12, 27);
            this.creditTabControl.Name = "creditTabControl";
            this.creditTabControl.SelectedIndex = 0;
            this.creditTabControl.Size = new System.Drawing.Size(708, 364);
            this.creditTabControl.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.creditTabControl.TabIndex = 1;
            this.creditTabControl.Tag = "";
            // 
            // creditTp
            // 
            this.creditTp.Controls.Add(this.creditDataGridView);
            this.creditTp.Location = new System.Drawing.Point(4, 22);
            this.creditTp.Name = "creditTp";
            this.creditTp.Padding = new System.Windows.Forms.Padding(3);
            this.creditTp.Size = new System.Drawing.Size(700, 338);
            this.creditTp.TabIndex = 0;
            this.creditTp.Text = "Credit";
            this.creditTp.UseVisualStyleBackColor = true;
            // 
            // creditDataGridView
            // 
            this.creditDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.creditDataGridView.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            this.creditDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.creditDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.creditDataGridView.Location = new System.Drawing.Point(3, 3);
            this.creditDataGridView.MultiSelect = false;
            this.creditDataGridView.Name = "creditDataGridView";
            this.creditDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.creditDataGridView.Size = new System.Drawing.Size(694, 332);
            this.creditDataGridView.TabIndex = 0;
            // 
            // debitTp
            // 
            this.debitTp.Controls.Add(this.debitDataGridView);
            this.debitTp.Location = new System.Drawing.Point(4, 22);
            this.debitTp.Name = "debitTp";
            this.debitTp.Padding = new System.Windows.Forms.Padding(3);
            this.debitTp.Size = new System.Drawing.Size(700, 338);
            this.debitTp.TabIndex = 1;
            this.debitTp.Text = "Debit";
            this.debitTp.UseVisualStyleBackColor = true;
            // 
            // debitDataGridView
            // 
            this.debitDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.debitDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.debitDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.debitDataGridView.Location = new System.Drawing.Point(3, 3);
            this.debitDataGridView.MultiSelect = false;
            this.debitDataGridView.Name = "debitDataGridView";
            this.debitDataGridView.Size = new System.Drawing.Size(694, 332);
            this.debitDataGridView.TabIndex = 0;
            // 
            // errorTp
            // 
            this.errorTp.Controls.Add(this.errorDataGridView);
            this.errorTp.Location = new System.Drawing.Point(4, 22);
            this.errorTp.Name = "errorTp";
            this.errorTp.Padding = new System.Windows.Forms.Padding(3);
            this.errorTp.Size = new System.Drawing.Size(700, 338);
            this.errorTp.TabIndex = 2;
            this.errorTp.Text = "Error";
            this.errorTp.UseVisualStyleBackColor = true;
            // 
            // errorDataGridView
            // 
            this.errorDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.errorDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.errorDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.errorDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.errorDataGridView.Location = new System.Drawing.Point(3, 3);
            this.errorDataGridView.MultiSelect = false;
            this.errorDataGridView.Name = "errorDataGridView";
            this.errorDataGridView.Size = new System.Drawing.Size(694, 332);
            this.errorDataGridView.TabIndex = 0;
            // 
            // correctBt
            // 
            this.correctBt.Location = new System.Drawing.Point(276, 409);
            this.correctBt.Name = "correctBt";
            this.correctBt.Size = new System.Drawing.Size(439, 61);
            this.correctBt.TabIndex = 2;
            this.correctBt.Text = "Correct";
            this.correctBt.UseVisualStyleBackColor = true;
            this.correctBt.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 494);
            this.Controls.Add(this.correctBt);
            this.Controls.Add(this.creditTabControl);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.creditTabControl.ResumeLayout(false);
            this.creditTp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.creditDataGridView)).EndInit();
            this.debitTp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.debitDataGridView)).EndInit();
            this.errorTp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem saveAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.TabControl creditTabControl;
        private System.Windows.Forms.TabPage creditTp;
        private System.Windows.Forms.DataGridView creditDataGridView;
        private System.Windows.Forms.TabPage debitTp;
        private System.Windows.Forms.DataGridView debitDataGridView;
        private System.Windows.Forms.TabPage errorTp;
        private System.Windows.Forms.DataGridView errorDataGridView;
        private System.Windows.Forms.Button correctBt;
    }
}

