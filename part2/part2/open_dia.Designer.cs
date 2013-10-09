namespace part2
{
    partial class open_dia
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.folderTb = new System.Windows.Forms.TextBox();
            this.openFolderBt = new System.Windows.Forms.Button();
            this.errorTb = new System.Windows.Forms.TextBox();
            this.debitTb = new System.Windows.Forms.TextBox();
            this.creditTb = new System.Windows.Forms.TextBox();
            this.errorBt = new System.Windows.Forms.Button();
            this.debitBt = new System.Windows.Forms.Button();
            this.creditBt = new System.Windows.Forms.Button();
            this.openBt = new System.Windows.Forms.Button();
            this.cancleBt = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Location = new System.Drawing.Point(12, 25);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.folderTb);
            this.splitContainer1.Panel1.Controls.Add(this.openFolderBt);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.errorTb);
            this.splitContainer1.Panel2.Controls.Add(this.debitTb);
            this.splitContainer1.Panel2.Controls.Add(this.creditTb);
            this.splitContainer1.Panel2.Controls.Add(this.errorBt);
            this.splitContainer1.Panel2.Controls.Add(this.debitBt);
            this.splitContainer1.Panel2.Controls.Add(this.creditBt);
            this.splitContainer1.Size = new System.Drawing.Size(385, 267);
            this.splitContainer1.SplitterDistance = 61;
            this.splitContainer1.TabIndex = 0;
            // 
            // folderTb
            // 
            this.folderTb.Location = new System.Drawing.Point(115, 17);
            this.folderTb.Name = "folderTb";
            this.folderTb.Size = new System.Drawing.Size(249, 20);
            this.folderTb.TabIndex = 1;
            this.folderTb.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // openFolderBt
            // 
            this.openFolderBt.Location = new System.Drawing.Point(13, 15);
            this.openFolderBt.Name = "openFolderBt";
            this.openFolderBt.Size = new System.Drawing.Size(85, 23);
            this.openFolderBt.TabIndex = 0;
            this.openFolderBt.Text = "open folder";
            this.openFolderBt.UseVisualStyleBackColor = true;
            this.openFolderBt.Click += new System.EventHandler(this.openFolderBt_Click);
            // 
            // errorTb
            // 
            this.errorTb.Location = new System.Drawing.Point(115, 138);
            this.errorTb.Name = "errorTb";
            this.errorTb.Size = new System.Drawing.Size(249, 20);
            this.errorTb.TabIndex = 5;
            this.errorTb.TextChanged += new System.EventHandler(this.errorTb_TextChanged);
            // 
            // debitTb
            // 
            this.debitTb.Location = new System.Drawing.Point(115, 85);
            this.debitTb.Name = "debitTb";
            this.debitTb.Size = new System.Drawing.Size(249, 20);
            this.debitTb.TabIndex = 4;
            this.debitTb.TextChanged += new System.EventHandler(this.debitTb_TextChanged);
            // 
            // creditTb
            // 
            this.creditTb.Location = new System.Drawing.Point(115, 26);
            this.creditTb.Name = "creditTb";
            this.creditTb.Size = new System.Drawing.Size(249, 20);
            this.creditTb.TabIndex = 3;
            this.creditTb.TextChanged += new System.EventHandler(this.creditTb_TextChanged);
            // 
            // errorBt
            // 
            this.errorBt.Location = new System.Drawing.Point(13, 138);
            this.errorBt.Name = "errorBt";
            this.errorBt.Size = new System.Drawing.Size(85, 23);
            this.errorBt.TabIndex = 2;
            this.errorBt.Text = "open errorFile";
            this.errorBt.UseVisualStyleBackColor = true;
            this.errorBt.Click += new System.EventHandler(this.button4_Click);
            // 
            // debitBt
            // 
            this.debitBt.Location = new System.Drawing.Point(13, 82);
            this.debitBt.Name = "debitBt";
            this.debitBt.Size = new System.Drawing.Size(85, 23);
            this.debitBt.TabIndex = 1;
            this.debitBt.Text = "open debitFile";
            this.debitBt.UseVisualStyleBackColor = true;
            // 
            // creditBt
            // 
            this.creditBt.Location = new System.Drawing.Point(13, 26);
            this.creditBt.Name = "creditBt";
            this.creditBt.Size = new System.Drawing.Size(85, 23);
            this.creditBt.TabIndex = 0;
            this.creditBt.Text = "open creditFile";
            this.creditBt.UseVisualStyleBackColor = true;
            this.creditBt.Click += new System.EventHandler(this.creditBt_Click);
            // 
            // openBt
            // 
            this.openBt.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.openBt.Location = new System.Drawing.Point(26, 331);
            this.openBt.Name = "openBt";
            this.openBt.Size = new System.Drawing.Size(114, 32);
            this.openBt.TabIndex = 1;
            this.openBt.Text = "open";
            this.openBt.UseVisualStyleBackColor = true;
            this.openBt.Click += new System.EventHandler(this.openBt_Click);
            // 
            // cancleBt
            // 
            this.cancleBt.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancleBt.Location = new System.Drawing.Point(268, 331);
            this.cancleBt.Name = "cancleBt";
            this.cancleBt.Size = new System.Drawing.Size(109, 32);
            this.cancleBt.TabIndex = 2;
            this.cancleBt.Text = "cancle";
            this.cancleBt.UseVisualStyleBackColor = true;
            this.cancleBt.Click += new System.EventHandler(this.cancleBt_Click);
            // 
            // open_dia
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 375);
            this.Controls.Add(this.cancleBt);
            this.Controls.Add(this.openBt);
            this.Controls.Add(this.splitContainer1);
            this.Name = "open_dia";
            this.Text = "open file dialog";
            this.Load += new System.EventHandler(this.open_dia_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox folderTb;
        private System.Windows.Forms.Button openFolderBt;
        private System.Windows.Forms.Button errorBt;
        private System.Windows.Forms.Button debitBt;
        private System.Windows.Forms.Button creditBt;
        private System.Windows.Forms.Button openBt;
        private System.Windows.Forms.Button cancleBt;
        private System.Windows.Forms.TextBox errorTb;
        private System.Windows.Forms.TextBox debitTb;
        private System.Windows.Forms.TextBox creditTb;

    }
}