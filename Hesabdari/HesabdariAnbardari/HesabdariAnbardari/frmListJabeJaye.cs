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
    public partial class frmListJabeJaye : Form
    {
        public frmListJabeJaye()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data source=(local);initial catalog=Hesabdaridb;integrated security=true");
        SqlCommand cmd = new SqlCommand();

        void Display()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from JabeJayeAnbar where Tarikh between '" + mskTarikh1.Text + "' And '" + mskTarikh2.Text + "'", con);
            DataSet ds = new DataSet();
            da.Fill(ds, "JabeJayeAnbar");
            dgvAnbar.DataSource = ds.Tables["JabeJayeAnbar"].DefaultView;
            con.Close();
        }

        void Display1()
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from JabeJayeAnbar ";
            adp.Fill(ds, "JabeJayeAnbar");
            dgvAnbar.DataSource = ds;
            dgvAnbar.DataMember = "JabeJayeAnbar";

            dgvAnbar.Columns[0].HeaderText = "کد";
            dgvAnbar.Columns[1].HeaderText = "نام کالا";
            dgvAnbar.Columns[2].HeaderText = "از انبار";
            dgvAnbar.Columns[3].HeaderText = "تعداد";
            dgvAnbar.Columns[4].HeaderText = "به انبار";
            dgvAnbar.Columns[5].HeaderText = "در تاریخ";
        }
        private void frmListJabeJaye_Load(object sender, EventArgs e)
        {

            System.Globalization.PersianCalendar p = new System.Globalization.PersianCalendar();
            mskTarikh1.Text = p.GetYear(DateTime.Now).ToString() + p.GetMonth(DateTime.Now).ToString("0#") + p.GetDayOfYear(DateTime.Now).ToString("0#");
            mskTarikh2.Text = p.GetYear(DateTime.Now).ToString() + p.GetMonth(DateTime.Now).ToString("0#") + p.GetDayOfYear(DateTime.Now).ToString("0#");

            dgvAnbar.Columns[0].HeaderText = "کد";
            dgvAnbar.Columns[1].HeaderText = "نام کالا";
            dgvAnbar.Columns[2].HeaderText = "از انبار";
            dgvAnbar.Columns[3].HeaderText = "تعداد";
            dgvAnbar.Columns[4].HeaderText = "به انبار";
            dgvAnbar.Columns[5].HeaderText = "در تاریخ";
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
                int x = Convert.ToInt32(dgvAnbar.SelectedCells[0].Value);
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "delete from JabeJayeAnbar where IdAnbar=@N";
                cmd.Parameters.AddWithValue("@N", x);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                Display();

                MessageBoxFarsi.Show("عملیات با موفقیت انجام شد", "پیغام", MessageBoxFarsiButtons.OK, MessageBoxFarsiIcon.Information, MessageBoxFarsiDefaultButton.Button1);
            }
            catch (Exception)
            {
                MessageBoxFarsi.Show("مشکلی پیش آمده است", "پیغام", MessageBoxFarsiButtons.OK, MessageBoxFarsiIcon.Information, MessageBoxFarsiDefaultButton.Button1);

            }
        }

        private void txtnameKala_TextChanged(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from JabeJayeAnbar where NameKala Like '%' + @S +'%'";
            adp.SelectCommand.Parameters.AddWithValue("@S", txtnameKala.Text + "%");
            adp.Fill(ds, "JabeJayeAnbar");
            dgvAnbar.DataSource = ds;
            dgvAnbar.DataMember = "JabeJayeAnbar";
        }

        private void txtNameAnbar_TextChanged(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from JabeJayeAnbar where NameAnbar Like '%' + @S +'%'";
            adp.SelectCommand.Parameters.AddWithValue("@S", txtNameAnbar.Text + "%");
            adp.Fill(ds, "JabeJayeAnbar");
            dgvAnbar.DataSource = ds;
            dgvAnbar.DataMember = "JabeJayeAnbar";
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            Display1();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            StiReport Report = new StiReport();
            Report.Load("Report/rptAnbar.mrt");
            Report.Compile();
            Report["Tarikh1"] = mskTarikh1.Text;
            Report["Tarikh2"] = mskTarikh2.Text;
            Report.ShowWithRibbonGUI();
        }
    }
}
