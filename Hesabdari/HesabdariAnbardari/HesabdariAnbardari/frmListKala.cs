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
    public partial class frmListKala : Form
    {
        public frmListKala()
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
            adp.SelectCommand.CommandText = "select * from Kala ";
            adp.Fill(ds, "Kala");
            dgvKala.DataSource = ds;
            dgvKala.DataMember = "Kala";
        }

        private void frmListKala_Load(object sender, EventArgs e)
        {
            Display();
            dgvKala.Columns[0].HeaderText = "کد کالا";
            dgvKala.Columns[1].HeaderText = "گروه کالا";
            dgvKala.Columns[2].HeaderText = "نام کالا";
            dgvKala.Columns[3].HeaderText = "قیمت خرید";
            dgvKala.Columns[4].HeaderText = "قیمت فروش";
            dgvKala.Columns[5].HeaderText = "تعداد";
            dgvKala.Columns[6].HeaderText = "واحد";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {      
                int x = Convert.ToInt32(dgvKala.SelectedCells[0].Value);
            cmd.Parameters.Clear();
            cmd.Connection = con;
            cmd.CommandText = "delete from kala where IdKala=@N";
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

        private void txtnameKala_TextChanged(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from Kala where NameKala Like '%' + @S +'%'";
            adp.SelectCommand.Parameters.AddWithValue("@S",txtnameKala.Text+ "%");
            adp.Fill(ds,"Kala");
            dgvKala.DataSource = ds;
            dgvKala.DataMember = "Kala";
        }

        private void txtNameGrooh_TextChanged(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from Kala where NameGrooh Like '%' + @S +'%'";
            adp.SelectCommand.Parameters.AddWithValue("@S", txtNameGrooh.Text + "%");
            adp.Fill(ds, "Kala");
            dgvKala.DataSource = ds;
            dgvKala.DataMember = "Kala";
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
            frmKala frm = new frmKala();
            frm.txtIdKala.Text = dgvKala[0, dgvKala.CurrentRow.Index].Value.ToString();
            frm.cmbGrooh.Text = dgvKala[1, dgvKala.CurrentRow.Index].Value.ToString();
            frm.txtNameKala.Text = dgvKala[2, dgvKala.CurrentRow.Index].Value.ToString();
            frm.txtGeymatKharid.Text = dgvKala[3, dgvKala.CurrentRow.Index].Value.ToString();
            frm.txtGeymatFroosh.Text = dgvKala[4, dgvKala.CurrentRow.Index].Value.ToString();
            frm.txtTedad.Text = dgvKala[5, dgvKala.CurrentRow.Index].Value.ToString();
            frm.txtVahed.Text = dgvKala[6, dgvKala.CurrentRow.Index].Value.ToString();
            frm.ShowDialog();
                MessageBoxFarsi.Show("عملیات با موفقیت انجام شد", "پیغام", MessageBoxFarsiButtons.OK, MessageBoxFarsiIcon.Information, MessageBoxFarsiDefaultButton.Button1);
            }
            catch (Exception)
            {
                MessageBoxFarsi.Show("مشکلی پیش آمده است", "پیغام", MessageBoxFarsiButtons.OK, MessageBoxFarsiIcon.Information, MessageBoxFarsiDefaultButton.Button1);

            }
 
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            Display();
        }

        private void dgvKala_MouseUp(object sender, MouseEventArgs e)
        {
 
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            StiReport Report = new StiReport();
            Report.Load("Report/rptKala.mrt");
            Report.Compile();
            Report.ShowWithRibbonGUI();
        }


    }
}
