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
        DataGridViewCell dgvc;
        public CellEditor(DataGridViewCell dgvc)
        {
            this.dgvc = dgvc;
            InitializeComponent();
        }

        private void CellEditor_Load(object sender, EventArgs e)
        {

        }
    }
}
