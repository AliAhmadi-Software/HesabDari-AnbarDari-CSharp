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
    public partial class frmJabeJayeAnbar : Form
    {
        public frmJabeJayeAnbar()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data source=(local);initial catalog=Hesabdaridb;integrated security=true");
        SqlCommand cmd = new SqlCommand();

        private void frmJabeJayeAnbar_Load(object sender, EventArgs e)
        {

            System.Globalization.PersianCalendar p = new System.Globalization.PersianCalendar();
            mskTarikh.Text = p.GetYear(DateTime.Now).ToString() + p.GetMonth(DateTime.Now).ToString("0#") + p.GetDayOfYear(DateTime.Now).ToString("0#");

            DataTable dt = new DataTable();
            DataBase db = new DataBase();
            dt = db.MySelect("select * from Kala");
            cmbNameKala.DataSource = dt;
            cmbNameKala.DisplayMember = "NameKala";

            DataTable dt1 = new DataTable();
            DataBase db1 = new DataBase();
            dt1 = db1.MySelect("select * from Anbar");
            cmbNameAnbar1.DataSource = dt1;
            cmbNameAnbar1.DisplayMember = "NameAnbar";

            DataTable dt2 = new DataTable();
            DataBase db2 = new DataBase();
            dt2 = db2.MySelect("select * from Anbar");
            cmbNameAnbar2.DataSource = dt2;
            cmbNameAnbar2.DisplayMember = "NameAnbar";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
            cmd.Connection = con;
            cmd.Parameters.Clear();
            cmd.CommandText = "insert into JabeJayeAnbar(NameKala,Az,Tedad,NameAnbar,Tarikh) values(@a,@b,@c,@d,@e)";
            cmd.Parameters.AddWithValue("@a",cmbNameKala.Text);
            cmd.Parameters.AddWithValue("@b", cmbNameAnbar1.Text);
            cmd.Parameters.AddWithValue("@c", txtTedad.Text);
            cmd.Parameters.AddWithValue("@d", cmbNameAnbar2.Text);
            cmd.Parameters.AddWithValue("@e", mskTarikh.Text);
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
            new frmListJabeJaye().ShowDialog();
        }
    }
}
