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
        public bool[] modified = { false, false, false};
        public bool[] fileOpened = { false, false, false};
        public string binPath = Path.GetDirectoryName(Application.ExecutablePath);
        public string creditFilePath, debitFilePath, errorFilePath;
        public DirectoryInfo defaultFolder;
        public List<string> creditList = new List<string>();
        public List<string> debitList = new List<string>();
        public List<string> errorList = new List<string>();
        //public int currentTabPageIndex = 0;
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


        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void openToolStripMenuItem1_Click(object sender, EventArgs e)
        {
//            if (!Form1_FormClosing(sender, null)) return;
            if (this.modified[0] || this.modified[1] || this.modified[2])
            {
                DialogResult dr = MessageBox.Show("file modified, do You Want to Save Data?", "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                Console.WriteLine("DialogResult: " + dr);
                if (dr == DialogResult.Yes)
                {
                    saveAllToolStripMenuItem_Click(sender, null);
                }
                else if (dr == DialogResult.Cancel)
                {
                    if (sender == openToolStripMenuItem1) { return; }
                }
            }

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
            saveAsToolStripMenuItem.Enabled = true;
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
            creditList = new List<string>();
            debitList = new List<string>();
            errorList = new List<string>();
            // read credit file
            StreamReader sr = new StreamReader(creditFilePath);;
            try
            {
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
            finally
            {
                sr.Close();
            }
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void creditTabControl_Selected(object sender, TabControlEventArgs e)
        {
            correctBt.Visible = e.TabPageIndex == 2;
        }

        private void errorDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //DataGridViewCellEventArgs arg = new DataGridViewCellEventArgs(e.ColumnIndex, e.RowIndex);
            //dataGridView_CellValueChanged(sender, arg);
        }

        private void dataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            Console.WriteLine("dataGridView_CellValueChanged");
            modified[creditTabControl.SelectedIndex] = true;
            saveToolStripMenuItem.Enabled = modified[creditTabControl.SelectedIndex];
            saveAllToolStripMenuItem.Enabled = (modified[0] || modified[1] || modified[2]);

            if (!creditTabControl.SelectedTab.Text.Substring(creditTabControl.SelectedTab.Text.Length-1).Contains('*'))
                creditTabControl.SelectedTab.Text += "*";
            
            DataGridViewCell dgvc = errorDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];
            colorCells(dgvc, e.ColumnIndex);
        }
        private void colorCells(DataGridViewCell dgvc, int columnIndex)
        {
            try
            {
                validateCell(dgvc, columnIndex);   
                dgvc.Style.ForeColor = Color.Black;
                dgvc.ErrorText = "";
                dgvc.Style.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                if (dgvc.Value.ToString().Equals("")) dgvc.Style.BackColor = Color.LightPink;
                dgvc.Style.ForeColor = Color.Red;
                dgvc.ErrorText = ex.Message;
            }
        }
        private void errorDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView view = (DataGridView)sender;
            correctBt.Enabled = true;
        }
        private void errorDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView view = (DataGridView)sender;
            DataGridViewRow dgvr = view.Rows[e.RowIndex];
            CellEditor ce = new CellEditor(dgvr, e.ColumnIndex);
            if (ce.ShowDialog() == DialogResult.OK)
            {

            }
        }
        public static void validateCell(DataGridViewCell dgvc, int columnIndex)
        {
            string dgvcStr = dgvc.Value.ToString().Trim();
            switch (columnIndex)
            {
                case 0:
                    Console.WriteLine("validate client number: " + dgvcStr + " : " + validateluhn(dgvcStr));
                    if (dgvcStr.Equals("")) throw new Exception("Missing Client Number");
                    int clientNumber;
                    if (!int.TryParse(dgvcStr, out clientNumber))
                    {
                        throw new Exception("Invalid Client Number");
                    }
                    if (!validateluhn("" + clientNumber))
                    {
                        throw new Exception("Client Number Invalid check digit");
                    }
                    break;

                case 1:
                    if (dgvcStr.Equals("")) throw new Exception("Missing type code");
                    if (!(dgvcStr.Equals("Cr") || dgvcStr.Equals("Dr"))) throw new Exception("Invalid type code");
                    break;

                case 2:
                    if (dgvcStr.Equals("")) throw new Exception("Missing Transaction Date");
                    DateTime tempDateTime;
                    if (!DateTime.TryParseExact(dgvcStr, new string[] { "d/MM/yyyy", "dd/M/yyyy" }, CultureInfo.InvariantCulture, DateTimeStyles.None, out tempDateTime)) 
                        throw new Exception("Invalid Transaction Date");
                    if (tempDateTime < new DateTime(2011, 1, 1) || tempDateTime > new DateTime(2012, 12, 31))
                        throw new Exception("Transaction Date Out of range");
                    break;

                case 3:
                    if (dgvcStr.Equals("")) throw new Exception("Missing Transaction Amount");
                    double amount;
                    if (!double.TryParse(dgvcStr, out amount))
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
                    break;
                default:
                    throw new Exception("Errrrrror");

            }
        }

        private void correctBt_Click(object sender, EventArgs e)
        {
            CellEditor ce = new CellEditor(errorDataGridView.SelectedCells[0]);
            if (ce.ShowDialog() == DialogResult.OK)
            {

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveToFile(creditTabControl.SelectedIndex, null);
            modified[creditTabControl.SelectedIndex] = false;
            saveToolStripMenuItem.Enabled = false;
            if (creditTabControl.SelectedTab.Text[creditTabControl.SelectedTab.Text.Length - 1].Equals('*'))
                creditTabControl.SelectedTab.Text = creditTabControl.SelectedTab.Text.Substring(0, creditTabControl.SelectedTab.Text.Length - 1);
        }

        private bool saveToFile(int index, string path)
        {
            //if (path == null) path = creditFilePath;
            DataGridView view = new DataGridView();
            switch (index) {
                case 0: view = creditDataGridView; if (path == null) path = creditFilePath; break;
                case 1: view = debitDataGridView; if (path == null) path = debitFilePath; break;
                case 2: view = errorDataGridView; if (path == null) path = errorFilePath; break;
                default: break;
            }
            StreamWriter sw = new StreamWriter(path);
            string line = "";
            try
            {
                foreach (DataGridViewRow row in view.Rows)
                {
                    line = row.Cells[0].Value.ToString() + ", " +
                        row.Cells[1].Value.ToString() + ", " +
                        row.Cells[2].Value.ToString() + ", " +
                        row.Cells[3].Value.ToString();
                    sw.WriteLine(line);
                    //Console.WriteLine("writing line: " + line);
                }
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);
            }
            finally
            {
                sw.Flush();
                sw.Close();
            }

            saveAllToolStripMenuItem.Enabled = (modified[0] || modified[1] || modified[2]);

            return true;
        }

        private void creditTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            saveToolStripMenuItem.Enabled = modified[creditTabControl.SelectedIndex];
        }

        private void errorDataGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                DataGridView view = (DataGridView)sender; 
                DataGridViewCell dgvc = view.Rows[e.RowIndex].Cells[e.ColumnIndex];
                colorCells(dgvc, e.ColumnIndex);
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            String defaultPath;
            switch (creditTabControl.SelectedIndex)
            {
                case 0:
                    defaultPath = creditFilePath; break;
                case 1:
                    defaultPath = debitFilePath; break;
                case 2:
                    defaultPath = errorFilePath; break;
                default:
                    defaultPath = null;
                    break;
            }
            saveFileDialog.InitialDirectory = defaultPath;
            saveFileDialog.Title = "Save " + creditTabControl.SelectedTab.Text + " as";
            saveFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                saveToFile(creditTabControl.SelectedIndex, defaultPath = saveFileDialog.FileName);
            }

            
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.modified[0] || this.modified[1] || this.modified[2])
            {
                DialogResult dr = MessageBox.Show("file modified, do You Want to Save Data?", "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {
                    saveAllToolStripMenuItem_Click(sender, null);
                }
                else if (dr == DialogResult.Cancel)
                {
                    if (sender == openToolStripMenuItem1) { } 
                    else e.Cancel = true;
                }
            }
        }

        private void saveAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            for (int i = 0; i < 3; i++)
            {
                if (modified[i]) saveToFile(i, null);
                modified[i] = false;
                if (creditTabControl.TabPages[i].Text[creditTabControl.TabPages[i].Text.Length - 1].Equals('*'))
                    creditTabControl.TabPages[i].Text = creditTabControl.TabPages[i].Text.Substring(0, creditTabControl.SelectedTab.Text.Length - 1);
            }
            
            saveToolStripMenuItem.Enabled = false;
            saveAllToolStripMenuItem.Enabled = false;
            
        }
    }
}
