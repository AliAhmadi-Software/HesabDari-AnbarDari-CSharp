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
    public partial class frmChekDaryafti : Form
    {
        public frmChekDaryafti()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data source=(local);initial catalog=Hesabdaridb;integrated security=true");
        SqlCommand cmd = new SqlCommand();

        private void frmChekDaryafti_Load(object sender, EventArgs e)
        {
            System.Globalization.PersianCalendar p = new System.Globalization.PersianCalendar();
            mskTarikh.Text = p.GetYear(DateTime.Now).ToString() + p.GetMonth(DateTime.Now).ToString("0#") + p.GetDayOfYear(DateTime.Now).ToString("0#");
            mskSarResid.Text = p.GetYear(DateTime.Now).ToString() + p.GetMonth(DateTime.Now).ToString("0#") + p.GetDayOfYear(DateTime.Now).ToString("0#");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
            cmd.Connection = con;
            cmd.Parameters.Clear();
            cmd.CommandText = "insert into ChekDaryafti(ShomareHesab,NameHesab,ShomareSanad,Mablagh,TarikhSabt,SarResid,NameMoshtari,Vaziyat,Tozih)Values (@a,@b,@c,@d,@e,@f,@g,@h,@i)";
            cmd.Parameters.AddWithValue("@a",txtShomareHesab.Text);
            cmd.Parameters.AddWithValue("@b", txtNameHesab.Text);
            cmd.Parameters.AddWithValue("@c", txtShomareSanad.Text);
            cmd.Parameters.AddWithValue("@d", txtMablagh.Text);
            cmd.Parameters.AddWithValue("@e", mskTarikh.Text);
            cmd.Parameters.AddWithValue("@f", mskSarResid.Text);
            cmd.Parameters.AddWithValue("@g", txtMoshtari.Text);
            cmd.Parameters.AddWithValue("@h", cmbVaziyat.Text);
            cmd.Parameters.AddWithValue("@i", txtTozih.Text);
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

        private void buttonX1_Click(object sender, EventArgs e)
        {
            new frmListChekDaryafti().ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            //try
            //{
                cmd.Connection = con;
                cmd.Parameters.Clear();
                cmd.CommandText = "Update ChekDaryafti set ShomareHesab='" + txtShomareHesab.Text + "',NameHesab='" + txtNameHesab.Text + "',ShomareSanad='" + txtShomareSanad.Text + "',Mablagh='" + txtMablagh.Text + "',TarikhSabt='" + mskTarikh.Text + "',SarResid='" + mskSarResid.Text + "',NameMoshtari='" + txtMoshtari.Text + "',Vaziyat='" + cmbVaziyat.Text + "',Tozih='" + txtTozih.Text + "' where IdChekD=" + txtIdSanad.Text;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBoxFarsi.Show("عملیات با موفقیت انجام شد", "پیغام", MessageBoxFarsiButtons.OK, MessageBoxFarsiIcon.Information, MessageBoxFarsiDefaultButton.Button1);
            //}
            //catch (Exception)
            //{
            //    MessageBoxFarsi.Show("مشکلی پیش آمده است", "پیغام", MessageBoxFarsiButtons.OK, MessageBoxFarsiIcon.Information, MessageBoxFarsiDefaultButton.Button1);

            //}
        }
    }
}
