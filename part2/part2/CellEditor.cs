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

        private void UpdateFidles()
        {
            if (dgvr.Cells[0].ErrorText != null)
            {
                label5.Text = dgvr.Cells[0].ErrorText;
            }
            else
            {

            }
            label5.Visible = dgvr.Cells[0].ErrorText != null;

            if (dgvr.Cells[1].ErrorText != null)
            {
                label6.Text = dgvr.Cells[1].ErrorText;
            }
            else
            {

            }
            label6.Visible = dgvr.Cells[1].ErrorText != null;

            if (dgvr.Cells[2].ErrorText != null)
            {
                label7.Text = dgvr.Cells[2].ErrorText;
            }
            else
            {

            }
            label7.Visible = dgvr.Cells[2].ErrorText != null;

            if (dgvr.Cells[3].ErrorText != null)
            {
                label8.Text = dgvr.Cells[3].ErrorText;
            }
            else
            {

            }
            label8.Visible =  dgvr.Cells[3].ErrorText != null;

            textBox1.Text = dgvr.Cells[0].Value.ToString();
            textBox2.Text = dgvr.Cells[1].Value.ToString();
            textBox3.Text = dgvr.Cells[2].Value.ToString();
            textBox4.Text = dgvr.Cells[3].Value.ToString();

        }

        private void CellEditor_Load(object sender, EventArgs e)
        {
            UpdateFidles();
        }

        private void saveBt_Click(object sender, EventArgs e)
        {

        }
    }
}
