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
    public partial class frmDarAmad : Form
    {
        public frmDarAmad()
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
            cmd.CommandText = "insert into DarAmad (NamedarAmad,ShomareHesab,NameHesab,tarikhSabt,Mablagh,Tozih)values(@a,@b,@c,@d,@e,@f)";
            cmd.Parameters.AddWithValue("@a",txtNameDarAmad.Text);
            cmd.Parameters.AddWithValue("@b", txtShomareHesab.Text);
            cmd.Parameters.AddWithValue("@c", txtNameHesab.Text);
            cmd.Parameters.AddWithValue("@d", mskTarikh.Text);
            cmd.Parameters.AddWithValue("@e", txtMablagh.Text);
            cmd.Parameters.AddWithValue("@f", txtTozih.Text);
            con.Open();
            cmd.ExecuteNonQuery();


            string str;
            int str1;
            SqlCommand sqlcmd = new SqlCommand("select Mablagh from Hesabha where ShomareHesab='" + txtShomareHesab.Text + "'", con);
            str = Convert.ToString((int)sqlcmd.ExecuteScalar());
            str1 = Convert.ToInt32(txtMablagh.Text);
            int b = Int32.Parse(str) + str1;

            string updatequery = "update Hesabha set Mablagh ='" + b + "' where ShomareHesab='" + txtShomareHesab.Text + "'";
            SqlCommand com = new SqlCommand(updatequery, con);
            com.ExecuteNonQuery();
            con.Close();

            MessageBoxFarsi.Show("عملیات با موفقیت انجام شد", "پیغام", MessageBoxFarsiButtons.OK, MessageBoxFarsiIcon.Information, MessageBoxFarsiDefaultButton.Button1);
            }
            catch (Exception)
            {
                MessageBoxFarsi.Show("مشکلی پیش آمده است", "پیغام", MessageBoxFarsiButtons.OK, MessageBoxFarsiIcon.Information, MessageBoxFarsiDefaultButton.Button1);

            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                cmd.Connection = con;
                cmd.Parameters.Clear();
                cmd.CommandText = "Update DarAmad set NameDarAmad='" + txtNameDarAmad.Text + "',ShomareHesab='" + txtShomareHesab.Text + "',NameHesab='" + txtNameHesab.Text + "',Tarikhsabt='" + mskTarikh.Text + "',Mablagh='" + txtMablagh.Text + "',Tozih='" + txtTozih.Text + "' where IdDarAmad=" + txtIdDarAmad.Text;
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
            new frmListDarAmad().ShowDialog();
        }

        private void frmDarAmad_Load(object sender, EventArgs e)
        {

        }
    }
}
