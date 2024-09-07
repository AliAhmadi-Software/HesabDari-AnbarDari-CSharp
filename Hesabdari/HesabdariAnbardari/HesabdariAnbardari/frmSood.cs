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
using Stimulsoft.Report;

namespace HesabdariAnbardari
{
    public partial class frmSood : Form
    {
        public frmSood()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data source=(local);initial catalog=Hesabdaridb;integrated security=true");
        SqlCommand cmd = new SqlCommand();

        void Display()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from FactorFroosh where TarikhFactor between '" + mskTarikh1.Text + "' And '" + mskTarikh2.Text + "'", con);
            DataSet ds = new DataSet();
            da.Fill(ds, "FactorFroosh");
            dgvFactor.DataSource = ds.Tables["FactorFroosh"].DefaultView;
            con.Close();
        }

        private void frmSood_Load(object sender, EventArgs e)
        {
            System.Globalization.PersianCalendar p = new System.Globalization.PersianCalendar();
            mskTarikh1.Text = p.GetYear(DateTime.Now).ToString() + p.GetMonth(DateTime.Now).ToString("0#") + p.GetDayOfYear(DateTime.Now).ToString("0#");
            mskTarikh2.Text = p.GetYear(DateTime.Now).ToString() + p.GetMonth(DateTime.Now).ToString("0#") + p.GetDayOfYear(DateTime.Now).ToString("0#");

            Display();

            dgvFactor.Columns[0].Visible = false;
            dgvFactor.Columns[3].Visible = false;
            dgvFactor.Columns[5].Visible = false;
            dgvFactor.Columns[6].Visible = false;
            dgvFactor.Columns[7].Visible = false;
            dgvFactor.Columns[8].Visible = false;
            //dgvFactor.Columns[9].Visible = false;
            dgvFactor.Columns[10].Visible = false;
           // dgvFactor.Columns[11].Visible = false;
            dgvFactor.Columns[12].Visible = false;
            dgvFactor.Columns[13].Visible = false;
            dgvFactor.Columns[16].Visible = false;


            dgvFactor.Columns[1].HeaderText = "شماره فاکتور";
            dgvFactor.Columns[2].HeaderText = "تاریخ ثبت";
            dgvFactor.Columns[4].HeaderText = "نام مشتری";
            dgvFactor.Columns[17].HeaderText = "مبلغ فاکتور";
            dgvFactor.Columns[18].HeaderText = "توضیحات";

            dgvFactor.Columns[18].Width = 250;
        }

        private void btnSood_Click(object sender, EventArgs e)
        {
            Display();
            decimal Sum = 0, s = 0, Sum2 = 0;

            for (int i = 0; i < dgvFactor.Rows.Count; i++)
            {
                Sum += Convert.ToInt32(dgvFactor.Rows[i].Cells[11].Value);//کل فروش
                s += Convert.ToInt32(dgvFactor.Rows[i].Cells[9].Value);//کل خرید
            }
            Sum2 = Sum - s;

            if (Sum2>0)
            {
                lblSood.Text = Sum2.ToString("###,###,###,###");
            }
            else if(Sum2<0)
            {
                lblZiyan.Text = Sum2.ToString("###,###,###,###");
            }
        }

        private void mskTarikh1_TextChanged(object sender, EventArgs e)
        {
            Display();
        }

        private void mskTarikh2_TextChanged(object sender, EventArgs e)
        {
            Display();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            StiReport Report = new StiReport();
            Report.Load("Report/rptSood.mrt");
            Report.Compile();
            Report["Tarikh1"] = mskTarikh1.Text;
            Report["Tarikh2"] = mskTarikh2.Text;
            Report["Sood"] = lblSood.Text;
            Report["Ziyan"] = lblZiyan.Text;
            Report.ShowWithRibbonGUI();
        }
    }
}
