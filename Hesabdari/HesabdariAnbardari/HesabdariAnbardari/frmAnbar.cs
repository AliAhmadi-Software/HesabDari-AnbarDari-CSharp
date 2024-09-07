﻿using System;
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
    public partial class frmAnbar : Form
    {
        public frmAnbar()
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
            adp.SelectCommand.CommandText = "select * from anbar";
            adp.Fill(ds, "anbar");
            dgvAnbar.DataSource = ds;
            dgvAnbar.DataMember = "anbar";
        }

        private void frmAnbar_Load(object sender, EventArgs e)
        {
            Display();
            dgvAnbar.Columns[0].HeaderText = "کد انبار";
            dgvAnbar.Columns[1].HeaderText = "نام انبار";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
            cmd.Connection = con;
            cmd.Parameters.Clear();
            cmd.CommandText = "insert into Anbar (NameAnbar)values(@a)";
            cmd.Parameters.AddWithValue("@a",txtNameAnbar.Text);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("ثبت با موفقیت انجام شد");
            Display();
                MessageBoxFarsi.Show("عملیات با موفقیت انجام شد", "پیغام", MessageBoxFarsiButtons.OK, MessageBoxFarsiIcon.Information, MessageBoxFarsiDefaultButton.Button1);
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
                int x = Convert.ToInt32(dgvAnbar.SelectedCells[0].Value);
            cmd.Parameters.Clear();
            cmd.CommandText = "Delete from Anbar where IdAnbar=@N";
            cmd.Parameters.AddWithValue("@n",txtId.Text);
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

        private void dgvAnbar_MouseUp(object sender, MouseEventArgs e)
        {
            txtId.Text = dgvAnbar[0, dgvAnbar.CurrentRow.Index].Value.ToString();
            txtNameAnbar.Text = dgvAnbar[1, dgvAnbar.CurrentRow.Index].Value.ToString();
        }
    }
}
