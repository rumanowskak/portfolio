using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3_hw
{

    public partial class New_schema : Form
    {
        public decimal new_height;
        public decimal new_width;
        public New_schema()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ok_button_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            new_height = height.Value;
            new_width = width.Value;
            this.Close();
        }

        private void height_ValueChanged(object sender, EventArgs e)
        {

        }

        private void new_schema_Load(object sender, EventArgs e)
        {

        }

        private void width_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
