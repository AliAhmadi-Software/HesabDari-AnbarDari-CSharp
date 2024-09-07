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
    public partial class frmHesabha : Form
    {
        public frmHesabha()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data source=(local);initial catalog=Hesabdaridb;integrated security=true");
        SqlCommand cmd = new SqlCommand();

        private void frmHesabha_Load(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception)
            {
                MessageBoxFarsi.Show("مشکلی پیش آمده است", "پیغام", MessageBoxFarsiButtons.OK, MessageBoxFarsiIcon.Information, MessageBoxFarsiDefaultButton.Button1);

            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                cmd.Connection = con;
                cmd.Parameters.Clear();
                cmd.CommandText = "insert into Hesabha (Sahebhesab,NameHesab,ShomareHesab,NameBank,Mablagh,Tozih)values (@a,@b,@c,@d,@e,@f)";
                cmd.Parameters.AddWithValue("@a",txtSahebHesab.Text);
                cmd.Parameters.AddWithValue("@b",txtNameHesab.Text);
                cmd.Parameters.AddWithValue("@c", txtShomareHesab.Text);
                cmd.Parameters.AddWithValue("@d", txtNameBank.Text);
                cmd.Parameters.AddWithValue("@e", txtMablagh.Text);
                cmd.Parameters.AddWithValue("@f", txtTozih.Text);
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

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
            cmd.Connection = con;
            cmd.Parameters.Clear();
            cmd.CommandText = "Update Hesabha set SahebHesab='"+txtSahebHesab.Text+"',NameHesab='"+txtNameHesab.Text+"',ShomareHesab='"+txtShomareHesab.Text+"',NameBank='"+txtNameBank.Text+"',Mablagh='"+txtMablagh.Text+"',Tozih='"+txtTozih.Text+"' where IdHesab="+txtIdHesab.Text;
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

        private void btnList_Click(object sender, EventArgs e)
        {
            new frmListHesabha().ShowDialog();
        }
    }
}
