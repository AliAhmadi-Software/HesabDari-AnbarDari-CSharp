using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HesabdariAnbardari
{
    public partial class FrmLoading : Form
    {
        public FrmLoading()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            cp.Value += 10;
            if (cp.Value == 100)
            {
                timer1.Stop();
                new frmLogin().ShowDialog();
                this.Close();
            }
        }
    }
}
