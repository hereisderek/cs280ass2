using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace part2
{
    public partial class CellEditor : Form
    {
        DataGridViewRow dgvr;
        DataGridViewCell dgvc;
        DataGridViewRow newDgvr;
        public CellEditor(DataGridViewRow dgvr, int columeIndex)
        {
            this.dgvr = dgvr;
            this.dgvc = dgvr.Cells[columeIndex];

            InitializeComponent();
        }
        public CellEditor(DataGridViewCell dgvc)
        {
            this.dgvr = dgvc.OwningRow;
            this.dgvc = dgvc;

            InitializeComponent();
        }

        private bool updateFidles()
        {
            newDgvr = (DataGridViewRow)this.dgvr.Clone();
            newDgvr.Cells[0].Value = textBox1.Text;
            newDgvr.Cells[1].Value = textBox2.Text;
            newDgvr.Cells[2].Value = textBox3.Text;
            newDgvr.Cells[3].Value = textBox4.Text;

            textBox1.BackColor = Color.White;
            textBox2.BackColor = Color.White;
            textBox3.BackColor = Color.White;
            textBox4.BackColor = Color.White;
            string errorMessage = "";
            for (int i = 0; i < newDgvr.Cells.Count; i++)
            {
                newDgvr.Cells[i].ErrorText = "";
                try
                {
                    Form1.validateCell(newDgvr.Cells[i], i);
                }
                catch (Exception ex)
                {
                    newDgvr.Cells[i].ErrorText = ex.Message;
                    //if (!newDgvr.Cells[i].ErrorText.ToString().Equals("")) errorMessage += newDgvr.Cells[i].ErrorText + "\n";
                    errorMessage += ex.Message + "\n";
                    switch (i)
                    {
                        case 0:
                            textBox1.BackColor = Color.LightPink;
                            break;
                        case 1:
                            textBox2.BackColor = Color.LightPink;
                            break;
                        case 2:
                            textBox3.BackColor = Color.LightPink;
                            break;
                        case 3:
                            textBox4.BackColor = Color.LightPink;
                            break;
                    }

                }
            }

            if (label5.Visible = !errorMessage.Equals(""))
            {
                label5.Text = errorMessage;
                label5.ForeColor = Color.Red;
            }
            return true;
        }

        private void CellEditor_Load(object sender, EventArgs e)
        {
            textBox1.Text = dgvr.Cells[0].Value.ToString();
            textBox2.Text = dgvr.Cells[1].Value.ToString();
            textBox3.Text = dgvr.Cells[2].Value.ToString();
            textBox4.Text = dgvr.Cells[3].Value.ToString();
            updateFidles();
        }

        private void saveBt_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 4; i++)
            {
                this.dgvr.Cells[i].Value = newDgvr.Cells[i].Value;
            }
            //if (updateFidles())
            //{


            //}
            //else {
            //    return;
            //}
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            updateFidles();
            saveBt.Enabled = true;
        }
    }
}
