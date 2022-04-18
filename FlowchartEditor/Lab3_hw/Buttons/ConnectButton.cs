using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;


namespace Lab3_hw
{
    class ConnectButton : System.Windows.Forms.Button
    {
        public ConnectButton()
        {
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ConnectButton_Paint);
        }
        private void ConnectButton_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            Icon icon = Properties.Resources.Chain;

            Rectangle rc = new Rectangle(e.ClipRectangle.X + 5, e.ClipRectangle.Y + 5,
                e.ClipRectangle.Width - 10, e.ClipRectangle.Height - 10);

            e.Graphics.DrawIcon(icon, rc);


        }
    }
}
