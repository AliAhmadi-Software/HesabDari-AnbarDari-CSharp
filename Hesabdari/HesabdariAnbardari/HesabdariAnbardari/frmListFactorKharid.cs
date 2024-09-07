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
    public partial class frmListFactorKharid : Form
    {
        public frmListFactorKharid()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data source=(local);initial catalog=Hesabdaridb;integrated security=true");
        SqlCommand cmd = new SqlCommand();

        void Display()
        {
            SqlDataAdapter da = new SqlDataAdapter(" SELECT DISTINCT CodeFactor,TarikhFactor,NameMoshtari,JameFactor From FactorKharid where TarikhFactor  between '" + mskTarikh1.Text + "' And '" + mskTarikh2.Text + "'", con);
            DataSet ds = new DataSet();
            da.Fill(ds, "FactorKharid");
            dgvFactor.DataSource = ds.Tables["FactorKharid"].DefaultView;
            con.Close();
        }
        private void frmListFactorKharid_Load(object sender, EventArgs e)
        {
            System.Globalization.PersianCalendar p = new System.Globalization.PersianCalendar();
            mskTarikh1.Text = p.GetYear(DateTime.Now).ToString() + p.GetMonth(DateTime.Now).ToString("0#") + p.GetDayOfYear(DateTime.Now).ToString("0#");
            mskTarikh2.Text = p.GetYear(DateTime.Now).ToString() + p.GetMonth(DateTime.Now).ToString("0#") + p.GetDayOfYear(DateTime.Now).ToString("0#");

            Display();

            dgvFactor.Columns[0].HeaderText = "شماره فاکتور";
            dgvFactor.Columns[1].HeaderText = "تاریخ ثبت";
            dgvFactor.Columns[2].HeaderText = "نام مشتری";
            dgvFactor.Columns[3].HeaderText = "مبلغ فاکتور";


            dgvFactor.Columns[2].Width = 250;
            dgvFactor.Columns[3].Width = 150;

        }

        private void mskTarikh1_TextChanged(object sender, EventArgs e)
        {
            Display();
        }

        private void mskTarikh2_TextChanged(object sender, EventArgs e)
        {
            Display();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int x = Convert.ToInt32(dgvFactor.CurrentRow.Cells[1]);
                cmd.Connection = con;
                cmd.Parameters.Clear();
                cmd.CommandText = "delete from FactorKharid where CodeFactor =@s";
                cmd.Parameters.AddWithValue("@s", x);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBoxFarsi.Show("عملیات با موفقیت انجام شد", "پیغام", MessageBoxFarsiButtons.OK, MessageBoxFarsiIcon.Information, MessageBoxFarsiDefaultButton.Button1);
            }
            catch (Exception)
            {
                MessageBoxFarsi.Show("مشکلی پیش آمده است", "پیغام", MessageBoxFarsiButtons.OK, MessageBoxFarsiIcon.Information, MessageBoxFarsiDefaultButton.Button1);

            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            StiReport Report = new StiReport();
            Report.Load("Report/rptListKharid.mrt");
            Report.Compile();
         //   Report["CodeFactor"] = Convert.ToInt32(txtCodeFactor.Text);
            Report["strTarikh1"] = mskTarikh1.Text;
            Report["strTarikh2"] = mskTarikh2.Text;
            Report.ShowWithRibbonGUI();
        }
    }
}
