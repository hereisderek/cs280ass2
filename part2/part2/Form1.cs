using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace part2
{

    public partial class Form1 : Form
    {
        public bool fileModified = false;
        public bool fileOpened = false;
        public string binPath = Path.GetDirectoryName(Application.ExecutablePath);
        public string creditFilePath, debitFilePath, errorFilePath;
        public DirectoryInfo defaultFolder;
        public List<string> creditList = new List<string>();
        public List<string> debitList = new List<string>();
        public List<string> errorList = new List<string>();
        public Form1()
        {
            defaultFolder = Directory.GetParent(binPath).Parent.Parent.Parent;
            creditFilePath = defaultFolder.FullName + "\\CreditFile.txt";
            debitFilePath = defaultFolder.FullName + "\\DebitFile.txt";
            errorFilePath = defaultFolder.FullName + "\\ErrorFile.txt";
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void openToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            open_dia op = new open_dia(this);
            DialogResult result = op.ShowDialog();
            //saveToolStripMenuItem1.Enabled = this.fileOpened;
            //System.Windows.Forms.MessageBox.Show(this.creditFilePath);
            if (result == DialogResult.OK)
            {
                openFile();
                creditDataGridView.DataSource = GetTable(creditList);
                debitDataGridView.DataSource = GetTable(debitList);
                errorDataGridView.DataSource = GetTable(errorList);
            }
        }
        private DataTable GetTable(List<string> list)
        {
            DataTable table = new DataTable();
            table.Columns.Add("Client Number");
            table.Columns.Add("Transaction Type");
            table.Columns.Add("Transaction Date");
            table.Columns.Add("Transaction Amount");

            foreach (string line in list)
            {
                string[] splits = line.Split(new Char[] { ',' }); // , ' '
                int size = splits.Length;
                DataRow newRow = table.NewRow();
                newRow["Client Number"] = size >= 1 ? splits[0] : null;
                newRow["Transaction Type"] = size >= 2 ? splits[1] : null;
                newRow["Transaction Date"] = size >= 3 ? splits[2] : null;
                newRow["Transaction Amount"] = size >= 4 ? splits[3] : null;
                table.Rows.Add(newRow);
            }
            return table;
        }
        public static bool validateluhn(String cardNumber)
        {
            int[] digits = new int[cardNumber.Length];
            for (int len = 0; len < cardNumber.Length; len++)
            {
                digits[len] = Int32.Parse(cardNumber.Substring(len, 1));
            }
            int sum = 0;
            bool alt = false;
            for (int i = digits.Length - 1; i >= 0; i--)
            {
                int currentDigit = digits[i];
                if (alt)
                {
                    currentDigit *= 2;
                    if (currentDigit > 9)
                    {
                        currentDigit -= 9;
                    }
                }
                sum += currentDigit;
                alt = !alt;
            }
            //If Mod 10 equals 0, the number is good and this will return true
            return sum % 10 == 0;
        }
        private void openFile()
        {
            // read credit file

            try
            {
                StreamReader sr = new StreamReader(creditFilePath);
                string str;
                while ((str = sr.ReadLine()) != null)
                {
                    creditList.Add(str);
                }
                sr = new StreamReader(debitFilePath);
                while ((str = sr.ReadLine()) != null)
                {
                    debitList.Add(str);
                }
                sr = new StreamReader(errorFilePath);
                while ((str = sr.ReadLine()) != null)
                {
                    errorList.Add(str);
                }
            }
            catch (Exception ex)
            { 
                
            }
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
