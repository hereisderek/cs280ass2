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
                newRow["Client Number"] = size >= 1 ? splits[0].Trim() : null;
                newRow["Transaction Type"] = size >= 2 ? splits[1].Trim() : null;
                newRow["Transaction Date"] = size >= 3 ? splits[2].Trim() : null;
                newRow["Transaction Amount"] = size >= 4 ? splits[3].Trim() : null;
                //newRow.DefaultCellStyle.ForeColor = Color.Red;
                
                table.Rows.Add(newRow);
                //table.Rows.Add((splits[0] == null? null : splits[0]),(splits[1] == null? null : splits[1]),(splits[2] == null? null : splits[2]),(splits[3] == null? null : splits[3]));
                try
                {

                    if (splits.Length != 4) throw new Exception("Truncated record");

                    foreach (string str in splits)
                    {
                        if (str.Trim().Equals(""))
                        {
                            throw new Exception("Truncated record");
                        }
                    }

                    int clientNumber;
                    if (!int.TryParse(splits[0], out clientNumber))
                    {
                        throw new Exception("Invalid Client Number");
                    }
                    if (!validateluhn("" + clientNumber))
                    {
                        throw new Exception("Client Number Invalid check digit");
                    }

                    if (!(splits[1].Trim().Equals("Cr") || splits[1].Trim().Equals("Dr")))
                    {
                        throw new Exception("Invalid type code");
                    }

                    DateTime tempDateTime;
                    string[] dateFormats = { "d/MM/yyyy", "dd/M/yyyy" };
                    if (!DateTime.TryParseExact(splits[2].Trim(), dateFormats, CultureInfo.InvariantCulture, DateTimeStyles.None, out tempDateTime))
                    {
                        throw new Exception("Invalid Transaction Date");
                    }
                    if (tempDateTime < new DateTime(2011, 1, 1) || tempDateTime > new DateTime(2012, 12, 31))
                    {
                        throw new Exception("Transaction Date Out of range");
                    }

                    double amount;
                    if (!double.TryParse(splits[3].Trim(), out amount))
                    {
                        throw new Exception("Transaction Amount Non-numeric");
                    }
                    if (amount <= 0 || amount >= 5000)
                    {
                        string str = "";
                        if (amount < 0) { str = "Negative"; }
                        if (amount == 0) { str = "Zero"; }
                        if (amount >= 5000) { str = "larger than 5000"; }
                        throw new Exception("Transaction Amount " + str);
                    }

                }
                catch (Exception ex)
                {

                }
                finally
                {
                    
                }
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

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void creditDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void creditTabControl_Selected(object sender, TabControlEventArgs e)
        {
        }

        private void TabControl_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void TabControl_Selected(object sender, TabControlEventArgs e)
        {
            if (e.TabPageIndex == 2)
            {
                correctBt.Visible = true;
                validate(errorDataGridView);
            }
            else
            {
                correctBt.Visible = false;
            }
        }
        private void validate(DataGridView dgv)
        {
            foreach (DataGridViewRow dg in dgv.Rows)
            {
                if (dg.Cells.Count != 4)
                {
                    dg.DefaultCellStyle.BackColor = Color.LightPink;
                }
                else
                {
                    dg.DefaultCellStyle.BackColor = Color.White;
                }
                validateRow(dg);
                Console.WriteLine();
            }
        }
        private List<int> validateRow(DataGridViewRow dg)
        {
            List<int> list = new List<int>();

                for (int i = 0; i < dg.Cells.Count; i++)
                {
                    //Console.Write(dg.Cells[i].Value + "-");
                    if (i == 0)
                    { 
                        int clientNumber;
                        if (!int.TryParse(dg.Cells[i].Value.ToString(), out clientNumber)
                            || !validateluhn("" + clientNumber))
                        {
                            //throw new Exception("Invalid Client Number");
                            list.Add(i);
                        }
                    }
                    if (i == 1)
                    {
                        if (!(dg.Cells[i].Value.ToString().Trim().Equals("Cr") || dg.Cells[i].Value.ToString().Trim().Equals("Dr")))
                        {
                            //throw new Exception("Invalid type code");
                            list.Add(i);
                        }
                    }
                    if (i == 2)
                    { 
                        
                    }
                }
            return list;
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
