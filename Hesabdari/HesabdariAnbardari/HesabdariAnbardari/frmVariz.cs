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
    public partial class frmVariz : Form
    {
        public frmVariz()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data source=(local);initial catalog=Hesabdaridb;integrated security=true");
        SqlCommand cmd = new SqlCommand();

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
            cmd.Connection = con;
            cmd.Parameters.Clear();
            cmd.CommandText = "insert into VarizBeHesab (ShomareHesab,NameHesab,NameMoshtari,Mablagh,TarikhVariz,Tozih)values (@a,@b,@c,@d,@e,@f)";
            cmd.Parameters.AddWithValue("@a",txtShomareHesab.Text);
            cmd.Parameters.AddWithValue("@b", txtNameHesab.Text);
            cmd.Parameters.AddWithValue("@c", txtNameMoshtari.Text);
            cmd.Parameters.AddWithValue("@d", txtMablagh.Text);
            cmd.Parameters.AddWithValue("@e", mskTarikh.Text);
            cmd.Parameters.AddWithValue("@f", txtTozih.Text);
            con.Open();
            cmd.ExecuteNonQuery();

            string str;
            int str1;
            SqlCommand sqlcmd = new SqlCommand("select Mablagh from Hesabha where ShomareHesab='"+txtShomareHesab.Text+"'",con);
            str = Convert.ToString((int)sqlcmd.ExecuteScalar());
            str1 = Convert.ToInt32(txtMablagh.Text);
            int b = Int32.Parse(str) + str1;

            string updatequery = "update Hesabha set Mablagh ='" + b + "' where ShomareHesab='" + txtShomareHesab.Text + "'";
            SqlCommand com = new SqlCommand(updatequery,con);
            com.ExecuteNonQuery();
            con.Close();
              MessageBoxFarsi.Show("عملیات با موفقیت انجام شد", "پیغام", MessageBoxFarsiButtons.OK, MessageBoxFarsiIcon.Information, MessageBoxFarsiDefaultButton.Button1);
            }
            catch (Exception)
            {
                MessageBoxFarsi.Show("مشکلی پیش آمده است", "پیغام", MessageBoxFarsiButtons.OK, MessageBoxFarsiIcon.Information, MessageBoxFarsiDefaultButton.Button1);

            }
        }

        private void txtMablagh_ValueChanged(object sender, EventArgs e)
        {

        }

        private void frmVariz_Load(object sender, EventArgs e)
        {

        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            new frmReportMoshtari().ShowDialog();
        }

    }
}
