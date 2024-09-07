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
    public partial class frmContact : Form
    {
        public frmContact()
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
            adp.SelectCommand.CommandText = "select * from Contact";
            adp.Fill(ds, "Contact");
            dgvContact.DataSource = ds;
            dgvContact.DataMember = "Contact";
        }
        private void frmContact_Load(object sender, EventArgs e)
        {
            Display();
            dgvContact.Columns[0].HeaderText = "کد";
            dgvContact.Columns[1].HeaderText = "نام و نام خانوادگی";
            dgvContact.Columns[2].HeaderText = "تلفن ثابت";
            dgvContact.Columns[3].HeaderText = "تلفن همراه";
            dgvContact.Columns[4].HeaderText = "آدرس";
            dgvContact.Columns[4].Width = 250;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
            cmd.Connection = con;
            cmd.Parameters.Clear();
            cmd.CommandText = "insert into Contact(NameNameKh,Tel,Mobile,Address)values(@a,@b,@c,@d)";
            cmd.Parameters.AddWithValue("@a",txtName.Text);
            cmd.Parameters.AddWithValue("@b", txtTel.Text);
            cmd.Parameters.AddWithValue("@c", txtMobile.Text);
            cmd.Parameters.AddWithValue("@d", txtAddress.Text);
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

        private void txtFilterName_TextChanged(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from Contact where NameNameKh Like '%' + @S +'%'";
            adp.SelectCommand.Parameters.AddWithValue("@S", txtFilterName.Text + "%");
            adp.Fill(ds, "Contact");
            dgvContact.DataSource = ds;
            dgvContact.DataMember = "Contact";
        }

        private void txtFilterTel_TextChanged(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from Contact where Tel Like '%' + @S +'%'";
            adp.SelectCommand.Parameters.AddWithValue("@S", txtFilterTel.Text + "%");
            adp.Fill(ds, "Contact");
            dgvContact.DataSource = ds;
            dgvContact.DataMember = "Contact";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int x = Convert.ToInt32(dgvContact.SelectedCells[0].Value);
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "delete from Contact where Id=@N";
                cmd.Parameters.AddWithValue("@N", x);
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

        private void btnEdit_Click(object sender, EventArgs e)
        {
            cmd.Connection = con;
            cmd.Parameters.Clear();
            cmd.CommandText = "update Contact set NameNamekh='" + txtName.Text + "',Tel='" + txtTel.Text + "',Mobile='" + txtMobile.Text + "',Address='" + txtAddress.Text + "' where Id= " + txtId.Text;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("اطلاعات ویرایش شد");
            Display();
        }

        private void dgvContact_MouseUp(object sender, MouseEventArgs e)
        {
            txtId.Text = dgvContact[0, dgvContact.CurrentRow.Index].Value.ToString();
            txtName.Text = dgvContact[1, dgvContact.CurrentRow.Index].Value.ToString();
            txtTel.Text = dgvContact[2, dgvContact.CurrentRow.Index].Value.ToString();
            txtMobile.Text = dgvContact[3, dgvContact.CurrentRow.Index].Value.ToString();
            txtAddress.Text = dgvContact[4, dgvContact.CurrentRow.Index].Value.ToString();
        }


    }
}
