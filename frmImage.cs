using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Custom_ImageForm
{
    public partial class frmImage : Form
    {
        public frmImage()
        {
            InitializeComponent();
        }

        public bool Cancelled { get; private set; }

        private void button1_Click(object sender, EventArgs e)
        {
            Cancelled = false;
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Cancelled = true;
            Hide();
        }
    }
}
