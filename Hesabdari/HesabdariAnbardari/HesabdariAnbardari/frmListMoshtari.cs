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
    public partial class frmListMoshtari : Form
    {
        public frmListMoshtari()
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
            adp.SelectCommand.CommandText = "select * from Moshtari";
            adp.Fill(ds,"Moshtari");
            dgvMoshtari.DataSource = ds;
            dgvMoshtari.DataMember = "Moshtari";

        }
        private void frmListMoshtari_Load(object sender, EventArgs e)
        {
            try
            {
                Display();
                dgvMoshtari.Columns[0].HeaderText = "کد مشتری";
                dgvMoshtari.Columns[1].HeaderText = "نام مشتری";
                dgvMoshtari.Columns[2].HeaderText = "نوع مشتری";
                dgvMoshtari.Columns[3].HeaderText = "تلفن ثابت";
                dgvMoshtari.Columns[4].HeaderText = "موبایل";
                dgvMoshtari.Columns[5].HeaderText = "بدهکار";
                dgvMoshtari.Columns[6].HeaderText = "بستانکار";
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
            int x = Convert.ToInt32(dgvMoshtari.SelectedCells[0].Value);
            cmd.Parameters.Clear();
            cmd.Connection = con;
            cmd.CommandText = "delete from Moshtari where idMoshtari=@N";
            cmd.Parameters.AddWithValue("@N",x);
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

        private void txtNameMoshtari_TextChanged(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from Moshtari where NameMoshtari Like '%' + @S +'%'";
            adp.SelectCommand.Parameters.AddWithValue("@S",txtNameMoshtari.Text +"%");
            adp.Fill(ds,"Moshtari");
            dgvMoshtari.DataSource = ds;
            dgvMoshtari.DataMember = "Moshtari";
        }

        private void txtNooMoshtari_TextChanged(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from Moshtari where NooMoshtari Like '%' + @S +'%'";
            adp.SelectCommand.Parameters.AddWithValue("@S", txtNooMoshtari.Text + "%");
            adp.Fill(ds, "Moshtari");
            dgvMoshtari.DataSource = ds;
            dgvMoshtari.DataMember = "Moshtari";
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            frmMoshtari frm = new frmMoshtari();
            frm.txtIdMoshtari.Text = dgvMoshtari[0, dgvMoshtari.CurrentRow.Index].Value.ToString();
            frm.txtNameMoshtari.Text = dgvMoshtari[1, dgvMoshtari.CurrentRow.Index].Value.ToString();
            frm.txtNooMoshtari.Text = dgvMoshtari[2, dgvMoshtari.CurrentRow.Index].Value.ToString();
            frm.txtTel.Text = dgvMoshtari[3, dgvMoshtari.CurrentRow.Index].Value.ToString();
            frm.txtMobile.Text = dgvMoshtari[4, dgvMoshtari.CurrentRow.Index].Value.ToString();
            frm.txtBedehkar.Text = dgvMoshtari[5, dgvMoshtari.CurrentRow.Index].Value.ToString();
            frm.txtBestankar.Text = dgvMoshtari[6, dgvMoshtari.CurrentRow.Index].Value.ToString();
            frm.ShowDialog();
        }
    }
}
