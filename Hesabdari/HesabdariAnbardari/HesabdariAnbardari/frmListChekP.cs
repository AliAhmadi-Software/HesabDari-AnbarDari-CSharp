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
    public partial class frmListChekP : Form
    {
        public frmListChekP()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data source=(local);initial catalog=Hesabdaridb;integrated security=true");
        SqlCommand cmd = new SqlCommand();

        void Display()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from ChekPardakhti where SarResid between '"+mskSarResid1.Text+"' And '"+mskSarResid2.Text+"'",con);
            DataSet ds = new DataSet();
            da.Fill(ds,"ChekPardakhti");
            dgvChekP.DataSource = ds.Tables["ChekPardakhti"].DefaultView;
            con.Close();
        }
        private void frmListChekP_Load(object sender, EventArgs e)
        {
            System.Globalization.PersianCalendar p = new System.Globalization.PersianCalendar();
            mskSarResid1.Text = p.GetYear(DateTime.Now).ToString() + p.GetMonth(DateTime.Now).ToString("0#") + p.GetDayOfYear(DateTime.Now).ToString("0#");
            mskSarResid2.Text = p.GetYear(DateTime.Now).ToString() + p.GetMonth(DateTime.Now).ToString("0#") + p.GetDayOfYear(DateTime.Now).ToString("0#");

            Display();

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

        private void btnVsol_Click(object sender, EventArgs e)
        {
            try
            {
            string str;
            int str1;
            con.Open();
            SqlCommand sqlcmd = new SqlCommand("Select Mablagh from Hesabha where ShomareHesab ='"+Convert.ToInt32(dgvChekP.SelectedCells[1].Value)+"'",con);
            str = Convert.ToString((int)sqlcmd.ExecuteScalar());
            str1 = Convert.ToInt32(dgvChekP.SelectedCells[4].Value);
            if (str1 > Convert.ToInt32(str))
            {
                MessageBox.Show("موجودی حساب برای وصول این سند کافی نمی باشد");
            }
            else
            {
                int b = Int32.Parse(str) - str1;
                string updatequery = "update Hesabha set Mablagh='" + b + "' where ShomareHesab ='" + Convert.ToInt32(dgvChekP.SelectedCells[1].Value) + "'";
                SqlCommand com = new SqlCommand(updatequery,con);
                com.ExecuteNonQuery();

                string updateVaziyat = "update ChekPardakhti set Vaziyat = '" + "وصول شده" + "' where ShomareSanad = '" + Convert.ToInt32(dgvChekP.SelectedCells[3].Value) + "'";
                SqlCommand com1 = new SqlCommand(updateVaziyat,con);
                com1.ExecuteNonQuery();
                MessageBoxFarsi.Show("وصول انجام شد و مبلغ سند از حساب مورد نظر کم شد", "پیغام", MessageBoxFarsiButtons.OK, MessageBoxFarsiIcon.Information, MessageBoxFarsiDefaultButton.Button1);
            }
                 
            }
            catch (Exception)
            {
                MessageBoxFarsi.Show("مشکلی پیش آمده است", "پیغام", MessageBoxFarsiButtons.OK, MessageBoxFarsiIcon.Information, MessageBoxFarsiDefaultButton.Button1);

            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            frmChekPardakhti frm = new frmChekPardakhti();
            frm.txtIdSanad.Text = dgvChekP[0, dgvChekP.CurrentRow.Index].Value.ToString();
            frm.txtShomareHesab.Text = dgvChekP[1, dgvChekP.CurrentRow.Index].Value.ToString();
            frm.txtNameHesab.Text = dgvChekP[2, dgvChekP.CurrentRow.Index].Value.ToString();
            frm.txtShomareSanad.Text = dgvChekP[3, dgvChekP.CurrentRow.Index].Value.ToString();
            frm.txtMablagh.Text = dgvChekP[4, dgvChekP.CurrentRow.Index].Value.ToString();
            frm.mskTarikh.Text = dgvChekP[5, dgvChekP.CurrentRow.Index].Value.ToString();
            frm.mskSarResid.Text = dgvChekP[6, dgvChekP.CurrentRow.Index].Value.ToString();
            frm.txtMoshtari.Text = dgvChekP[7, dgvChekP.CurrentRow.Index].Value.ToString();
            frm.cmbVaziyat.Text = dgvChekP[8, dgvChekP.CurrentRow.Index].Value.ToString();
            frm.txtTozih.Text = dgvChekP[9, dgvChekP.CurrentRow.Index].Value.ToString();
            frm.ShowDialog();
        }

        private void mskSarResid1_TextChanged(object sender, EventArgs e)
        {
            Display();
        }

        private void mskSarResid2_TextChanged(object sender, EventArgs e)
        {
            Display();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            Display();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
            int x = Convert.ToInt32(dgvChekP.SelectedCells[0].Value);
            cmd.Connection = con;
            cmd.Parameters.Clear();
            cmd.CommandText = "delete from ChekPardakhti Where IdChekP=@N";
            cmd.Parameters.AddWithValue("@N",x);
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

        private void btnPrint_Click(object sender, EventArgs e)
        {
            StiReport Report = new StiReport();
            Report.Load("Report/rptChekPardakhti.mrt");
            Report.Compile();
            //   Report["CodeFactor"] = Convert.ToInt32(txtCodeFactor.Text);
            Report["Tarikh1"] = mskSarResid1.Text;
            Report["Tarikh2"] = mskSarResid2.Text;
            Report.ShowWithRibbonGUI();
        }
    }
}
