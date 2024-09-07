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
using Stimulsoft.Report;

namespace HesabdariAnbardari
{
    public partial class frmListHesabha : Form
    {
        public frmListHesabha()
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
            adp.SelectCommand.CommandText = "select * from Hesabha";
            adp.Fill(ds,"Hesabha");
            dgvHesabha.DataSource = ds;
            dgvHesabha.DataMember = "Hesabha";
        }
        private void frmListHesabha_Load(object sender, EventArgs e)
        {
            try
            {
                Display();
                dgvHesabha.Columns[0].HeaderText = "کد حساب";
                dgvHesabha.Columns[1].HeaderText = "صاحب حساب";
                dgvHesabha.Columns[2].HeaderText = "نام حساب";
                dgvHesabha.Columns[3].HeaderText = "شماره حساب";
                dgvHesabha.Columns[4].HeaderText = "نام بانک";
                dgvHesabha.Columns[5].HeaderText = "موجودی";
                dgvHesabha.Columns[6].HeaderText = "توضیحات";
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
            int x = Convert.ToInt32(dgvHesabha.SelectedCells[0].Value);
            cmd.Parameters.Clear();
            cmd.Connection = con;
            cmd.CommandText = "delete from Hesabha where IdHesab=@N";
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

        private void txtNameHesab_TextChanged(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from Hesabha where NameHesab Like '%' + @S+ '%'";
            adp.SelectCommand.Parameters.AddWithValue("@S", txtNameHesab.Text + "%");
            adp.Fill(ds,"Hesabha");
            dgvHesabha.DataSource = ds;
            dgvHesabha.DataMember = "HesabHa";
        }

        private void txtShomareHesab_TextChanged(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from Hesabha where ShomareHesab Like '%' + @S+ '%'";
            adp.SelectCommand.Parameters.AddWithValue("@S", txtShomareHesab.Text + "%");
            adp.Fill(ds, "Hesabha");
            dgvHesabha.DataSource = ds;
            dgvHesabha.DataMember = "HesabHa";
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            frmHesabha frm = new frmHesabha();
            frm.txtIdHesab.Text = dgvHesabha[0, dgvHesabha.CurrentRow.Index].Value.ToString();
            frm.txtSahebHesab.Text = dgvHesabha[1, dgvHesabha.CurrentRow.Index].Value.ToString();
            frm.txtNameHesab.Text = dgvHesabha[2, dgvHesabha.CurrentRow.Index].Value.ToString();
            frm.txtShomareHesab.Text = dgvHesabha[3, dgvHesabha.CurrentRow.Index].Value.ToString();
            frm.txtNameBank.Text = dgvHesabha[4, dgvHesabha.CurrentRow.Index].Value.ToString();
            frm.txtMablagh.Text = dgvHesabha[5, dgvHesabha.CurrentRow.Index].Value.ToString();
            frm.txtTozih.Text = dgvHesabha[6, dgvHesabha.CurrentRow.Index].Value.ToString();
            frm.ShowDialog();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            Display();

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            StiReport Report = new StiReport();
            Report.Load("Report/rptHesab.mrt");
            Report.Compile();
            Report.ShowWithRibbonGUI();
        }
    }
}
