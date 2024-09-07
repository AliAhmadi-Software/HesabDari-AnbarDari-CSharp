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
    public partial class frmFactorFroosh : Form
    {
        public frmFactorFroosh()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data source=(local);initial catalog=Hesabdaridb;integrated security=true");
        SqlCommand cmd = new SqlCommand();


        void Display1()
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from Moshtari";
            adp.Fill(ds, "Moshtari");
            dgvMoshtari.DataSource = ds;
            dgvMoshtari.DataMember = "Moshtari";

        }

        void Display2()
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from Kala ";
            adp.Fill(ds, "Kala");
            dgvKala.DataSource = ds;
            dgvKala.DataMember = "Kala";
        }
        string Address;
        string Tel;

        private void frmFactorFroosh_Load(object sender, EventArgs e)
        {
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(System.Globalization.CultureInfo.CreateSpecificCulture("fa-IR"));

                Display1();
                dgvMoshtari.Columns[0].HeaderText = "کد مشتری";
                dgvMoshtari.Columns[1].HeaderText = "نام مشتری";
                dgvMoshtari.Columns[2].HeaderText = "نوع مشتری";
                dgvMoshtari.Columns[3].HeaderText = "تلفن ثابت";
                dgvMoshtari.Columns[4].HeaderText = "موبایل";
                dgvMoshtari.Columns[5].HeaderText = "بدهکار";
                dgvMoshtari.Columns[6].HeaderText = "بستانکار";

                Display2();
                dgvKala.Columns[0].HeaderText = "کد کالا";
                dgvKala.Columns[1].HeaderText = "گروه کالا";
                dgvKala.Columns[2].HeaderText = "نام کالا";
                dgvKala.Columns[3].HeaderText = "قیمت خرید";
                dgvKala.Columns[4].HeaderText = "قیمت فروش";
                dgvKala.Columns[5].HeaderText = "تعداد";
                dgvKala.Columns[6].HeaderText = "واحد";

                cmd.Connection = con;
                cmd.CommandText = "select MaliyatFroosh from Maliyat";
                SqlDataReader dr;
                con.Open();
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    dblFroosh.Text = dr["MaliyatFroosh"].ToString();
                }
                con.Close();

                cmd.CommandText = "select * from Tanzimat";
                SqlDataReader dr1;
                con.Open();
                dr1 = cmd.ExecuteReader();
                if (dr1.Read())
                {
                    Address = dr1["Address"].ToString();
                    Tel = dr1["Tel"].ToString();
                }
                con.Close();

                System.Globalization.PersianCalendar p = new System.Globalization.PersianCalendar();
                mskTarikh.Text = p.GetYear(DateTime.Now).ToString() + p.GetMonth(DateTime.Now).ToString("0#") + p.GetDayOfYear(DateTime.Now).ToString("0#");
        
            }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtTedad.Value > Convert.ToInt32(lblTedad.Text))
            {
                MessageBoxFarsi.Show("تعداد وارد شده برای فروش بیشتر از تعداد موجودی می باشد", "کنترل موجودی کالاها", MessageBoxFarsiButtons.OK, MessageBoxFarsiIcon.Information, MessageBoxFarsiDefaultButton.Button1);
            }
            else
            {

                dgvFactor.Rows.Add(txtIdKala.Text, txtNameKala.Text, txtGeymatFroosh.Text, txtGeymatKharid.Text, txtTedad.Text);

                txtIdKala.Text = "";
                txtNameKala.Text = "";
                txtGeymatFroosh.Text = "";
                txtGeymatKharid.Text = "";
                txtTedad.Text = "";

                int GeymatKolKharid;
                int GeymatKolFroosh;
                int JameKolfactor = 0;
                int JameKalaha = 0;
                int Maliyat = 0;

                for (int i = 0; i < dgvFactor.Rows.Count; i++)
                {
                    JameKalaha = JameKalaha + (Convert.ToInt32(dgvFactor.Rows[i].Cells[2].Value) * Convert.ToInt32(dgvFactor.Rows[i].Cells[4].Value));
                    // int GeymatKol;

                    GeymatKolFroosh = (Convert.ToInt32(dgvFactor.Rows[i].Cells[2].Value) * Convert.ToInt32(dgvFactor.Rows[i].Cells[4].Value));
                    dgvFactor.Rows[i].Cells[5].Value = GeymatKolFroosh;


                    GeymatKolKharid = (Convert.ToInt32(dgvFactor.Rows[i].Cells[3].Value) * Convert.ToInt32(dgvFactor.Rows[i].Cells[4].Value));
                    dgvFactor.Rows[i].Cells[6].Value = GeymatKolKharid;
                }
                txtJameFactor.Text = JameKalaha.ToString();

                Maliyat = Convert.ToInt32(JameKalaha * dblFroosh.Value);

                txtMaliyat.Value = Maliyat;

                JameKolfactor = (JameKalaha + Maliyat + txtHazineh.Value) - txtTakhfif.Value;
                txtJameKol.Value = JameKolfactor;
            }
        }

        private void txtFilterMoshtari_TextChanged(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from Moshtari where NameMoshtari Like '%' + @S +'%'";
            adp.SelectCommand.Parameters.AddWithValue("@S", txtFilterMoshtari.Text + "%");
            adp.Fill(ds, "Moshtari");
            dgvMoshtari.DataSource = ds;
            dgvMoshtari.DataMember = "Moshtari";
        }

        private void txtFilterKala_TextChanged(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from Kala where NameKala Like '%' + @S +'%'";
            adp.SelectCommand.Parameters.AddWithValue("@S", txtFilterKala.Text + "%");
            adp.Fill(ds, "Kala");
            dgvKala.DataSource = ds;
            dgvKala.DataMember = "Kala";
        }

        private void dgvMoshtari_MouseUp(object sender, MouseEventArgs e)
        {
            txtIdMoshtari.Text = dgvMoshtari[0, dgvMoshtari.CurrentRow.Index].Value.ToString();
            txtNameMoshtari.Text = dgvMoshtari[1, dgvMoshtari.CurrentRow.Index].Value.ToString();
            txtMobile.Text = dgvMoshtari[4, dgvMoshtari.CurrentRow.Index].Value.ToString();
        }

        private void dgvKala_MouseUp(object sender, MouseEventArgs e)
        {
            txtIdKala.Text = dgvKala[0, dgvKala.CurrentRow.Index].Value.ToString();
            txtNameKala.Text = dgvKala[2, dgvKala.CurrentRow.Index].Value.ToString();
            txtGeymatFroosh.Text = dgvKala[4, dgvKala.CurrentRow.Index].Value.ToString();
            txtGeymatKharid.Text = dgvKala[3, dgvKala.CurrentRow.Index].Value.ToString();
            lblTedad.Text = dgvKala[5, dgvKala.CurrentRow.Index].Value.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

            for (int i = 0; i < dgvFactor.Rows.Count; i++)
            {
                con.Close();
                cmd.Connection = con;
                cmd.Parameters.Clear();
                cmd.CommandText = "insert into FactorFroosh (CodeFactor,TarikhFactor,IdMoshtari,NameMoshtari,Mobile,IdKala,NameKala,GeymatKharid,GeymatKolKharid,GeymatFroosh,GeymatKolFroosh,Tedad,MablaghFactor,MaliyatFactor,HazinehFactor,TakhfifFactor,JameFactor,Tozih) values (@a,@b,@c,@d,@e,@f,@g,@h,@i,@j,@k,@l,@m,@n,@o,@p,@q,@r)";
                cmd.Parameters.AddWithValue("@a", txtCodeFactor.Text);
                cmd.Parameters.AddWithValue("@b", mskTarikh.Text);
                cmd.Parameters.AddWithValue("@c", txtIdMoshtari.Text);
                cmd.Parameters.AddWithValue("@d", txtNameMoshtari.Text);
                cmd.Parameters.AddWithValue("@e", txtMobile.Text);

                cmd.Parameters.AddWithValue("@f", Convert.ToInt32(dgvFactor.Rows[i].Cells[0].Value));
                cmd.Parameters.AddWithValue("@g", dgvFactor.Rows[i].Cells[1].Value);
                cmd.Parameters.AddWithValue("@h", Convert.ToInt32(dgvFactor.Rows[i].Cells[3].Value));
                cmd.Parameters.AddWithValue("@i", Convert.ToInt32(dgvFactor.Rows[i].Cells[6].Value));
                cmd.Parameters.AddWithValue("@j", Convert.ToInt32(dgvFactor.Rows[i].Cells[2].Value));
                cmd.Parameters.AddWithValue("@k", Convert.ToInt32(dgvFactor.Rows[i].Cells[5].Value));
                cmd.Parameters.AddWithValue("@l", Convert.ToInt32(dgvFactor.Rows[i].Cells[4].Value));

                cmd.Parameters.AddWithValue("@m", txtJameFactor.Text);
                cmd.Parameters.AddWithValue("@n", txtMaliyat.Text);
                cmd.Parameters.AddWithValue("@o", txtHazineh.Text);
                cmd.Parameters.AddWithValue("@p", txtTakhfif.Text);
                cmd.Parameters.AddWithValue("@q", txtJameKol.Text);
                cmd.Parameters.AddWithValue("@r", txtTozih.Text);
                con.Open();
                cmd.ExecuteNonQuery();
                //con.Close();

                string str;
                int str1;
                SqlCommand sqlcmd = new SqlCommand("select Tedad from Kala where IdKala='" + Convert.ToInt32(dgvFactor.Rows[i].Cells[0].Value) + "'", con);
                str = Convert.ToString((int)sqlcmd.ExecuteScalar());
                str1 = Convert.ToInt32(dgvFactor.Rows[i].Cells[4].Value);
                int b = Int32.Parse(str) - str1;

                string updatequery = "update Kala set Tedad ='" + b + "' where IdKala='" + Convert.ToInt32(dgvFactor.Rows[i].Cells[0].Value) + "'";
                SqlCommand com = new SqlCommand(updatequery, con);
                com.ExecuteNonQuery();
                Display2();

                con.Close();

                MessageBoxFarsi.Show("عملیات با موفقیت انجام شد", "پیغام", MessageBoxFarsiButtons.OK, MessageBoxFarsiIcon.Information, MessageBoxFarsiDefaultButton.Button1);
            }
                }
            catch (Exception)
            {
                //MessageBoxFarsi.Show("مشکلی پیش آمده است", "پیغام", MessageBoxFarsiButtons.OK, MessageBoxFarsiIcon.Information, MessageBoxFarsiDefaultButton.Button1);

            }
        }

        private void btnPardakht_Click(object sender, EventArgs e)
        {
            frmVariz frm = new frmVariz();
            frm.txtTozih.Text = "پرداخت نقد مبلغ فاکتور فروش به شماره فاکتور" + txtCodeFactor.Text;
            frm.txtNameMoshtari.Text = txtNameMoshtari.Text;
            frm.txtMablagh.Text = txtJameKol.Text;
            frm.mskTarikh.Text = mskTarikh.Text;
            frm.ShowDialog();
        }

        private void btnSanad_Click(object sender, EventArgs e)
        {
            frmChekDaryafti frm = new frmChekDaryafti();
            frm.txtTozih.Text = "پرداخت  مبلغ فاکتور فروش به صورت چک به شماره فاکتور" + txtCodeFactor.Text;
            frm.txtMoshtari.Text = txtNameMoshtari.Text;
            frm.txtMablagh.Text = txtJameKol.Text;
            frm.mskTarikh.Text = mskTarikh.Text;
            frm.ShowDialog();
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {

     
            int JameKolfactor = 0;
            int JameKalaha = 0;
            int Maliyat = 0;

            for (int i = 0; i < dgvFactor.Rows.Count; i++)
            {
                JameKalaha = JameKalaha + (Convert.ToInt32(dgvFactor.Rows[i].Cells[2].Value) * Convert.ToInt32(dgvFactor.Rows[i].Cells[4].Value));
            }
            txtJameFactor.Text = JameKalaha.ToString();

            Maliyat = Convert.ToInt32(JameKalaha * dblFroosh.Value);

            txtMaliyat.Value = Maliyat;

            JameKolfactor = (JameKalaha + Maliyat + txtHazineh.Value) - txtTakhfif.Value;
            txtJameKol.Value = JameKolfactor;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvFactor.Rows.Count == 0)
                {
                    MessageBox.Show("کالایی انتخاب نشده است");
                }
                else
                {
                    dgvFactor.Rows.RemoveAt(dgvFactor.CurrentRow.Index);
                }
            }
            catch (Exception)
            {


            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            StiReport Report = new StiReport();
            Report.Load("Report/rptFactorFroosh.mrt");
            Report.Compile();
            Report["CodeFactor"] = Convert.ToInt32(txtCodeFactor.Text);
            Report["Address"] = Address;
            Report["Tel"] = Tel;
            Report.ShowWithRibbonGUI();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            new frmListFactorFroosh().ShowDialog();
        }

        private void txtTedad_ValueChanged(object sender, EventArgs e)
        {
            txtTedad.MaxValue = Convert.ToInt32(lblTedad.Text);
        }


    }
}
