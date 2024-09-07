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
    public partial class frmKala : Form
    {
        public frmKala()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data source=(local);initial catalog=Hesabdaridb;integrated security=true");
        SqlCommand cmd = new SqlCommand();


        private void frmKala_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DataBase db = new DataBase();
            dt = db.MySelect("select * from Grooh");
            cmbGrooh.DataSource = dt;
            cmbGrooh.DisplayMember = "NameGrooh";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
             cmd.Connection = con;
            cmd.Parameters.Clear();
            cmd.CommandText = "insert into Kala(NameGrooh,NameKala,GeymatKharid,GeymatFroosh,Tedad,Vahed)values(@a,@b,@c,@d,@e,@f)";
            cmd.Parameters.AddWithValue("@a",cmbGrooh.Text);
            cmd.Parameters.AddWithValue("@b",txtNameKala.Text);
            cmd.Parameters.AddWithValue("@c",txtGeymatKharid.Text);
            cmd.Parameters.AddWithValue("@d",txtGeymatFroosh.Text);
            cmd.Parameters.AddWithValue("@e",txtTedad.Text);
            cmd.Parameters.AddWithValue("@f",txtVahed.Text);
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
            new frmListKala().ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
           cmd.Connection = con;
            cmd.Parameters.Clear();
            cmd.CommandText = "update Kala set NameGrooh='" + cmbGrooh.Text + "',NameKala='" + txtNameKala.Text + "',GeymatKharid='" + txtGeymatKharid.Text + "',GeymatFroosh='" + txtGeymatFroosh.Text + "',Tedad='" + txtTedad.Text + "',Vahed='" + txtVahed.Text + "' where IdKala = " +txtIdKala.Text;
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

        private void buttonX2_Click(object sender, EventArgs e)
        {
            new frmControlKala().ShowDialog();
        }
    }
}
