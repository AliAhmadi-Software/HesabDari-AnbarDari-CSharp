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
    public partial class frmSarResid : Form
    {
        public frmSarResid()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data source=(local);initial catalog=Hesabdaridb;integrated security=true");
        SqlCommand cmd = new SqlCommand();

        void Display()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from ChekDaryafti where SarResid between '" + mskSarResid1.Text + "' And '" + mskSarResid2.Text + "'", con);
            DataSet ds = new DataSet();
            da.Fill(ds, "ChekDaryafti");
            dgvChekD.DataSource = ds.Tables["ChekDaryafti"].DefaultView;
            con.Close();
        }

        void Display1()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from ChekPardakhti where SarResid between '" + mskTarikh3.Text + "' And '" + mskTarikh4.Text + "'", con);
            DataSet ds = new DataSet();
            da.Fill(ds, "ChekPardakhti");
            dgvChekP.DataSource = ds.Tables["ChekPardakhti"].DefaultView;
            con.Close();
        }

        private void frmSarResid_Load(object sender, EventArgs e)
        {
            System.Globalization.PersianCalendar p = new System.Globalization.PersianCalendar();
            mskSarResid1.Text = p.GetYear(DateTime.Now).ToString() + p.GetMonth(DateTime.Now).ToString("0#") + p.GetDayOfYear(DateTime.Now).ToString("0#");
            mskSarResid2.Text = p.GetYear(DateTime.Now).ToString() + p.GetMonth(DateTime.Now).ToString("0#") + p.GetDayOfYear(DateTime.Now).ToString("0#");
            mskTarikh3.Text = p.GetYear(DateTime.Now).ToString() + p.GetMonth(DateTime.Now).ToString("0#") + p.GetDayOfYear(DateTime.Now).ToString("0#");
            mskTarikh4.Text = p.GetYear(DateTime.Now).ToString() + p.GetMonth(DateTime.Now).ToString("0#") + p.GetDayOfYear(DateTime.Now).ToString("0#");


            Display();

            dgvChekD.Columns[0].HeaderText = "کد سند";
            dgvChekD.Columns[1].HeaderText = "شماره حساب";
            dgvChekD.Columns[2].HeaderText = "نام حساب";
            dgvChekD.Columns[3].HeaderText = "شماره سند";
            dgvChekD.Columns[4].HeaderText = "مبلغ";
            dgvChekD.Columns[5].HeaderText = "تاریخ ثبت";
            dgvChekD.Columns[6].HeaderText = "سررسید";
            dgvChekD.Columns[7].HeaderText = "نام مشتری";
            dgvChekD.Columns[8].HeaderText = "وضعیت";
            dgvChekD.Columns[9].HeaderText = "توضیحات";

            Display1();

            dgvChekP.Columns[0].HeaderText = "کد سند";
            dgvChekP.Columns[1].HeaderText = "شماره حساب";
            dgvChekP.Columns[2].HeaderText = "نام حساب";
            dgvChekP.Columns[3].HeaderText = "شماره سند";
            dgvChekP.Columns[4].HeaderText = "مبلغ";
            dgvChekP.Columns[5].HeaderText = "تاریخ ثبت";
            dgvChekP.Columns[6].HeaderText = "سررسید";
            dgvChekP.Columns[7].HeaderText = "نام پرداخت کننده";
            dgvChekP.Columns[8].HeaderText = "وضعیت";
            dgvChekP.Columns[9].HeaderText = "توضیحات";

        }

        private void mskTarikh3_TextChanged(object sender, EventArgs e)
        {
            Display1();
        }

        private void mskTarikh4_TextChanged(object sender, EventArgs e)
        {
            Display1();
        }

        private void mskSarResid1_TextChanged(object sender, EventArgs e)
        {
            Display();
        }

        private void mskSarResid2_TextChanged(object sender, EventArgs e)
        {
            Display();
        }
    }
}
