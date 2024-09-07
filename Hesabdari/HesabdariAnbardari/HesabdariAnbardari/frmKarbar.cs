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
    public partial class frmKarbar : Form
    {
        public frmKarbar()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data source=(local);initial catalog=Hesabdaridb;integrated security=true");
        SqlCommand cmd = new SqlCommand();

        void Display()
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from karbar";
            adp.Fill(ds, "karbar");
            dgvKarbar.DataSource = ds;
            dgvKarbar.DataMember = "karbar";
        }

        private void frmKarbar_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
            cmd.Connection = con;
            cmd.Parameters.Clear();
            cmd.CommandText = "insert into Karbar (UserName,Password)values(@a,@b)";
            cmd.Parameters.AddWithValue("@a",txtUserName.Text);
            cmd.Parameters.AddWithValue("@b",txtPassword.Text);
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

        private void dgvKarbar_MouseUp(object sender, MouseEventArgs e)
        {
            txtId.Text = dgvKarbar[0, dgvKarbar.CurrentRow.Index].Value.ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
            cmd.Connection = con;
            cmd.Parameters.Clear();
            cmd.CommandText = "Delete from karbar where IdKarbar = @N";
            cmd.Parameters.AddWithValue("@N",txtId.Text);
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
            int x = Convert.ToInt32(dgvKarbar.SelectedCells[0].Value);
      
        }
    }
}
