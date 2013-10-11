using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace part2
{
    public partial class open_dia : Form
    {
        Form1 form1;
        DirectoryInfo defaultFolder;
        string creditFilePath, debitFilePath, errorFilePath;
        OpenFileDialog openFileDialog1 = new OpenFileDialog();
        public open_dia(Form1 form1)
        {
            this.form1 = form1;
            this.defaultFolder = form1.defaultFolder;
            this.creditFilePath = form1.creditFilePath;
            this.debitFilePath = form1.debitFilePath;
            this.errorFilePath = form1.errorFilePath;



            openFileDialog1.InitialDirectory = this.defaultFolder.FullName;
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            InitializeComponent();
            creditTb.Text = this.creditFilePath;
            debitTb.Text = this.debitFilePath;
            errorTb.Text = this.errorFilePath;
            folderTb.Text = this.defaultFolder.FullName;
        }

        private void open_dia_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void openFolderBt_Click(object sender, EventArgs e)
        {
            folderTb.Enabled = true;
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            //fbd.RootFolder = this.defaultFolder;
            fbd.SelectedPath = this.defaultFolder.FullName;
            fbd.Description = "select the folder which contains the three text files";
            DialogResult result = fbd.ShowDialog();

            //string[] files = Directory.GetFiles(fbd.SelectedPath);
            //System.Windows.Forms.MessageBox.Show("Files found: " + files.Length.ToString() , "Message");
            //System.Windows.Forms.MessageBox.Show("this.defaultFolder.FullName: " + this.defaultFolder.FullName, "Message");
            //string selectedPath = 
            folderTb.Text = fbd.SelectedPath;
            creditTb.Text = fbd.SelectedPath + "\\CreditFile.txt";
            debitTb.Text = fbd.SelectedPath + "\\DebitFile.txt";
            errorTb.Text = fbd.SelectedPath + "\\ErrorFile.txt";

            if (File.Exists(creditTb.Text))
            {
                creditTb.ForeColor = Color.Black;
            }
            else
            {
                creditTb.ForeColor = Color.Red;
            }
            if (File.Exists(debitTb.Text))
            {
                debitTb.ForeColor = Color.Black;
            }
            else
            {
                debitTb.ForeColor = Color.Red;
            }
            if (File.Exists(errorTb.Text))
            {
                errorTb.ForeColor = Color.Black;
            }
            else
            {
                errorTb.ForeColor = Color.Red;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            folderTb.ForeColor = Color.Black;
        }

        private void creditBt_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                creditTb.Text = openFileDialog1.FileName;
                folderTb.Enabled = false;
            }
        }

        private void creditTb_TextChanged(object sender, EventArgs e)
        {
            if (File.Exists(creditTb.Text))
            {
                creditTb.ForeColor = Color.Black;
            }
            else
            {
                creditTb.ForeColor = Color.Red;
            }
        }

        private void cancleBt_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void openBt_Click(object sender, EventArgs e)
        {
            if (File.Exists(creditTb.Text) && File.Exists(debitTb.Text) && File.Exists(errorTb.Text))
            {
                creditFilePath = creditTb.Text;
                debitFilePath = debitTb.Text;
                errorFilePath = errorTb.Text;
                //form1.fileOpened = { false, false, false };
                //foreach (bool bol in form1.fileOpened) bol = true;
                form1.fileOpened[0] = true;
                form1.fileOpened[1] = true;
                form1.fileOpened[2] = true;
                form1.creditFilePath = creditTb.Text;
                form1.debitFilePath = debitTb.Text;
                form1.errorFilePath = errorTb.Text;
                Close();
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("File path contains error, please fix first.", "Error");
            }
            if (File.Exists(creditTb.Text))
            {
                creditTb.ForeColor = Color.Black;
            }
            else
            {
                creditTb.ForeColor = Color.Red;
            }
            if (File.Exists(debitTb.Text))
            {
                debitTb.ForeColor = Color.Black;
            }
            else
            {
                debitTb.ForeColor = Color.Red;
            }
            if (File.Exists(errorTb.Text))
            {
                errorTb.ForeColor = Color.Black;
            }
            else
            {
                errorTb.ForeColor = Color.Red;
            }

        }

        private void debitTb_TextChanged(object sender, EventArgs e)
        {
            if (File.Exists(debitTb.Text))
            {
                debitTb.ForeColor = Color.Black;
            }
            else
            {
                debitTb.ForeColor = Color.Red;
            }
        }

        private void errorTb_TextChanged(object sender, EventArgs e)
        {
            if (File.Exists(errorTb.Text))
            {
                errorTb.ForeColor = Color.Black;
            }
            else
            {
                errorTb.ForeColor = Color.Red;
            }
        }
    }
}
