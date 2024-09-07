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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data source=(local);initial catalog=Hesabdaridb;integrated security=true");
        SqlCommand cmd = new SqlCommand();

        private void buttonX1_Click(object sender, EventArgs e)
        {
            try
            {
         int i = 0;
            cmd = new SqlCommand("select count(*) from karbar where UserName=@N And Password=@F",con);
            cmd.Parameters.AddWithValue("@N",txtUserName.Text);
            cmd.Parameters.AddWithValue("@F",txtPassword.Text);
            con.Open();
            i = (int)cmd.ExecuteScalar();
            con.Close();

            if (i>0)
            {
                new Form1().ShowDialog();
                this.Close();
            }
            else
            {
                MessageBoxFarsi.Show("عملیات با موفقیت انجام شد", "پیغام", MessageBoxFarsiButtons.OK, MessageBoxFarsiIcon.Information, MessageBoxFarsiDefaultButton.Button1);
            }
               
            }
            catch (Exception)
            {
                MessageBoxFarsi.Show("مشکلی پیش آمده است", "پیغام", MessageBoxFarsiButtons.OK, MessageBoxFarsiIcon.Information, MessageBoxFarsiDefaultButton.Button1);

            }

     
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
