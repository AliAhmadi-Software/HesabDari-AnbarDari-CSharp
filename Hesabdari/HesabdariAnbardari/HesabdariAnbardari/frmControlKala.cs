using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using BehComponents;

namespace HesabdariAnbardari
{
    public partial class frmControlKala : Form
    {
        public frmControlKala()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data source=(local);initial catalog=Hesabdaridb;integrated security=true");
        SqlCommand cmd = new SqlCommand();

        void Display()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from Kala where Tedad between '" + txtTedad1.Text + "' And '" + txtTedad2.Text + "'", con);
            DataSet ds = new DataSet();
            da.Fill(ds, "Kala");
            dgvKala.DataSource = ds.Tables["Kala"].DefaultView;
            con.Close();
        }

        void Display1()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from Kala where Tedad = '" + 0 + "' ", con);
            DataSet ds = new DataSet();
            da.Fill(ds, "Kala");
            dgvKala.DataSource = ds.Tables["Kala"].DefaultView;
            con.Close();
        }

        private void frmControlKala_Load(object sender, EventArgs e)
        {
            Display1();
            dgvKala.Columns[0].HeaderText = "کد کالا";
            dgvKala.Columns[1].HeaderText = "گروه کالا";
            dgvKala.Columns[2].HeaderText = "نام کالا";
            dgvKala.Columns[3].HeaderText = "قیمت خرید";
            dgvKala.Columns[4].HeaderText = "قیمت فروش";
            dgvKala.Columns[5].HeaderText = "تعداد";
            dgvKala.Columns[6].HeaderText = "واحد";
        }

        private void btnControl_Click(object sender, EventArgs e)
        {
            Display();
        }
    }
}
