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
    public partial class frmListChekDaryafti : Form
    {
        public frmListChekDaryafti()
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

        private void frmListChekDaryafti_Load(object sender, EventArgs e)
        {
            System.Globalization.PersianCalendar p = new System.Globalization.PersianCalendar();
            mskSarResid1.Text = p.GetYear(DateTime.Now).ToString() + p.GetMonth(DateTime.Now).ToString("0#") + p.GetDayOfYear(DateTime.Now).ToString("0#");
            mskSarResid2.Text = p.GetYear(DateTime.Now).ToString() + p.GetMonth(DateTime.Now).ToString("0#") + p.GetDayOfYear(DateTime.Now).ToString("0#");

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
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            Display();
        }

        private void btnVsol_Click(object sender, EventArgs e)
        {
            try
            {
                string str;
                int str1;
                con.Open();
                SqlCommand sqlcmd = new SqlCommand("Select Mablagh from Hesabha where ShomareHesab ='" + Convert.ToInt32(dgvChekD.SelectedCells[1].Value) + "'", con);
                str = Convert.ToString((int)sqlcmd.ExecuteScalar());
                str1 = Convert.ToInt32(dgvChekD.SelectedCells[4].Value);

                    int b = Int32.Parse(str) + str1;
                    string updatequery = "update Hesabha set Mablagh='" + b + "' where ShomareHesab ='" + Convert.ToInt32(dgvChekD.SelectedCells[1].Value) + "'";
                    SqlCommand com = new SqlCommand(updatequery, con);
                    com.ExecuteNonQuery();

                    string updateVaziyat = "update ChekDaryafti set Vaziyat = '" + "وصول شده" + "' where ShomareSanad = '" + Convert.ToInt32(dgvChekD.SelectedCells[3].Value) + "'";
                    SqlCommand com1 = new SqlCommand(updateVaziyat, con);
                    com1.ExecuteNonQuery();
                    MessageBoxFarsi.Show("وصول انجام شد و مبلغ سند به حساب مورد نظر افزوده شده", "پیغام", MessageBoxFarsiButtons.OK, MessageBoxFarsiIcon.Information, MessageBoxFarsiDefaultButton.Button1);

            }
            catch (Exception)
            {
                MessageBoxFarsi.Show("مشکلی پیش آمده است", "پیغام", MessageBoxFarsiButtons.OK, MessageBoxFarsiIcon.Information, MessageBoxFarsiDefaultButton.Button1);

            }
        }

        private void mskSarResid1_TextChanged(object sender, EventArgs e)
        {
            Display();
        }

        private void mskSarResid2_TextChanged(object sender, EventArgs e)
        {
            Display();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int x = Convert.ToInt32(dgvChekD.SelectedCells[0].Value);
                cmd.Connection = con;
                cmd.Parameters.Clear();
                cmd.CommandText = "delete from ChekDaryafti Where IdChekD=@N";
                cmd.Parameters.AddWithValue("@N", x);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Display();
                MessageBoxFarsi.Show("حذف انجام انجام شد", "پیغام", MessageBoxFarsiButtons.OK, MessageBoxFarsiIcon.Information, MessageBoxFarsiDefaultButton.Button1);

            }
            catch (Exception)
            {
                MessageBoxFarsi.Show("مشکلی پیش آمده است", "پیغام", MessageBoxFarsiButtons.OK, MessageBoxFarsiIcon.Information, MessageBoxFarsiDefaultButton.Button1);

            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            frmChekDaryafti frm = new frmChekDaryafti();
            frm.txtIdSanad.Text = dgvChekD[0, dgvChekD.CurrentRow.Index].Value.ToString();
            frm.txtShomareHesab.Text = dgvChekD[1, dgvChekD.CurrentRow.Index].Value.ToString();
            frm.txtNameHesab.Text = dgvChekD[2, dgvChekD.CurrentRow.Index].Value.ToString();
            frm.txtShomareSanad.Text = dgvChekD[3, dgvChekD.CurrentRow.Index].Value.ToString();
            frm.txtMablagh.Text = dgvChekD[4, dgvChekD.CurrentRow.Index].Value.ToString();
            frm.mskTarikh.Text = dgvChekD[5, dgvChekD.CurrentRow.Index].Value.ToString();
            frm.mskSarResid.Text = dgvChekD[6, dgvChekD.CurrentRow.Index].Value.ToString();
            frm.txtMoshtari.Text = dgvChekD[7, dgvChekD.CurrentRow.Index].Value.ToString();
            frm.cmbVaziyat.Text = dgvChekD[8, dgvChekD.CurrentRow.Index].Value.ToString();
            frm.txtTozih.Text = dgvChekD[9, dgvChekD.CurrentRow.Index].Value.ToString();
            frm.ShowDialog();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            StiReport Report = new StiReport();
            Report.Load("Report/rptChekDaryafti.mrt");
            Report.Compile();
            //   Report["CodeFactor"] = Convert.ToInt32(txtCodeFactor.Text);
            Report["Tarikh1"] = mskSarResid1.Text;
            Report["Tarikh2"] = mskSarResid2.Text;
            Report.ShowWithRibbonGUI();
        }
    }
}
