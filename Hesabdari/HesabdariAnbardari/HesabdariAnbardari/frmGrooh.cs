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
    public partial class frmGrooh : Form
    {
        public frmGrooh()
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
            adp.SelectCommand.CommandText = "select * from Grooh";
            adp.Fill(ds, "Grooh");
            dgvGrooh.DataSource = ds;
            dgvGrooh.DataMember = "Grooh";
        }
        private void frmGrooh_Load(object sender, EventArgs e)
        {
            try
            {
             Display();
            dgvGrooh.Columns[0].HeaderText = "کد گروه کالا";
            dgvGrooh.Columns[1].HeaderText = "نام گروه کال";
               
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
            cmd.CommandText = "insert into Grooh (NameGrooh)values(@a)";
            cmd.Parameters.AddWithValue("@a", txtNameGrooh.Text);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            Display();
                MessageBoxFarsi.Show("عملیات با موفقیت انجام شد","پیغام",MessageBoxFarsiButtons.OK,MessageBoxFarsiIcon.Information,MessageBoxFarsiDefaultButton.Button1);
            }
            catch (Exception)
            {
                MessageBoxFarsi.Show("مشکلی پیش آمده است", "پیغام", MessageBoxFarsiButtons.OK, MessageBoxFarsiIcon.Information, MessageBoxFarsiDefaultButton.Button1);
            
            }

                
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {

            int x = Convert.ToInt32(dgvGrooh.SelectedCells[0].Value);
            cmd.Connection = con;
            cmd.Parameters.Clear();
            cmd.CommandText = "delete from Grooh where IdGrooh = @N";
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

        }

        private void dgvGrooh_MouseUp(object sender, MouseEventArgs e)
        {
            txtId.Text = dgvGrooh[0, dgvGrooh.CurrentRow.Index].Value.ToString();
            txtNameGrooh.Text = dgvGrooh[1, dgvGrooh.CurrentRow.Index].Value.ToString();
        }
    }
}
