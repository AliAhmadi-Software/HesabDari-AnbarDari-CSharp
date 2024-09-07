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
    public partial class frmListHazineh : Form
    {
        public frmListHazineh()
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
            adp.SelectCommand.CommandText = "select * from Hazineh";
            adp.Fill(ds,"hazineh");
            dgvHazineh.DataSource = ds;
            dgvHazineh.DataMember = "Hazineh";
        }

        private void frmListHazineh_Load(object sender, EventArgs e)
        {
            Display();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            frmHazineh frm = new frmHazineh();
            frm.txtIdHazineh.Text = dgvHazineh[0, dgvHazineh.CurrentRow.Index].Value.ToString();
            frm.txtNameHazineh.Text = dgvHazineh[1, dgvHazineh.CurrentRow.Index].Value.ToString();
            frm.txtShomareHesab.Text = dgvHazineh[2, dgvHazineh.CurrentRow.Index].Value.ToString();
            frm.txtNameHesab.Text = dgvHazineh[3, dgvHazineh.CurrentRow.Index].Value.ToString();
            frm.mskTarikh.Text = dgvHazineh[4, dgvHazineh.CurrentRow.Index].Value.ToString();
            frm.txtMablagh.Text = dgvHazineh[5, dgvHazineh.CurrentRow.Index].Value.ToString();
            frm.txtTozih.Text = dgvHazineh[6, dgvHazineh.CurrentRow.Index].Value.ToString();
            frm.ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
            int x = Convert.ToInt32(dgvHazineh.SelectedCells[0].Value);
            cmd.Connection = con;
            cmd.Parameters.Clear();
            cmd.CommandText = "Delete from Hazineh where IdHazineh=@N";
            cmd.Parameters.AddWithValue("@N",x);
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

        private void txtNameHazineh_TextChanged(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from Hazineh Where NameHazineh  Like '%' + @S + '%' ";
            adp.SelectCommand.Parameters.AddWithValue("@S",txtNameHazineh.Text + "%");
            adp.Fill(ds,"Hazineh");
            dgvHazineh.DataSource = ds;
            dgvHazineh.DataMember = "Hazineh";
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            Display();
        }
    }
}
