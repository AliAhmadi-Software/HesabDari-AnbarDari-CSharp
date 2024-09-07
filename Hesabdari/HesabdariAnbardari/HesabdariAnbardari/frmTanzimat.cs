using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace HesabdariAnbardari
{
    public partial class frmTanzimat : Form
    {
        public frmTanzimat()
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
            adp.SelectCommand.CommandText="select * from tanzimat";
            adp.Fill(ds,"tanzimat");
            dgvTanzimat.DataSource = ds;
            dgvTanzimat.DataMember = "tanzimat";
        }
        private void frmTanzimat_Load(object sender, EventArgs e)
        {
            Display();
            dgvTanzimat.Columns[0].HeaderText = "کد تنظیمات";
            dgvTanzimat.Columns[1].HeaderText = "نام فروشگاه";
            dgvTanzimat.Columns[2].HeaderText = "تلفن ثابت";
            dgvTanzimat.Columns[3].HeaderText = "تلفن همراه";
            dgvTanzimat.Columns[4].HeaderText = "آدرس";
            dgvTanzimat.Columns[5].HeaderText = "توضیحات";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            cmd.Connection = con;
            cmd.Parameters.Clear();
            cmd.CommandText = "insert into Tanzimat (NameFroshgah,Tel,Mobile,Address,Tozih)values(@a,@b,@c,@d,@e)";
            cmd.Parameters.AddWithValue("@a",txtNameFroshgah.Text);
            cmd.Parameters.AddWithValue("@b",txtTel.Text);
            cmd.Parameters.AddWithValue("@c", txtMobile.Text);
            cmd.Parameters.AddWithValue("@d", txtAddress.Text);
            cmd.Parameters.AddWithValue("@e", txtTozih.Text);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("اطلاعات با موفقیت ثبت شد");
            Display();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(dgvTanzimat.SelectedCells[0].Value);
            cmd.Parameters.Clear();
            cmd.Connection = con;
            cmd.CommandText = "delete from tanzimat where IdTanzimat=@N";
            cmd.Parameters.AddWithValue("@N", txtId.Text);
           con.Open();
           cmd.ExecuteNonQuery();
           con.Close();
           MessageBox.Show("اطلاعات با موفقیت حذف شد");
           Display();

        }

        private void dgvTanzimat_MouseUp(object sender, MouseEventArgs e)
        {
            txtId.Text = dgvTanzimat[0, dgvTanzimat.CurrentRow.Index].Value.ToString();
            txtNameFroshgah.Text = dgvTanzimat[1, dgvTanzimat.CurrentRow.Index].Value.ToString();
            txtTel.Text = dgvTanzimat[2, dgvTanzimat.CurrentRow.Index].Value.ToString();
            txtMobile.Text = dgvTanzimat[3, dgvTanzimat.CurrentRow.Index].Value.ToString();
            txtAddress.Text = dgvTanzimat[4, dgvTanzimat.CurrentRow.Index].Value.ToString();
            txtTozih.Text = dgvTanzimat[5, dgvTanzimat.CurrentRow.Index].Value.ToString();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            cmd.Connection = con;
            cmd.Parameters.Clear();
            cmd.CommandText = "update Tanzimat set NameFroshgah='" + txtNameFroshgah.Text + "',Tel='" + txtTel.Text + "',Mobile='" + txtMobile.Text + "',Address='" + txtAddress.Text + "',Tozih='" + txtTozih.Text + "' where IdTanzimat= " + txtId.Text;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("اطلاعات ویرایش شد");
            Display();
        }
    }
}
