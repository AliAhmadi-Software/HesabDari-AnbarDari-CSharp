using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HesabdariAnbardari
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnTanzimat_Click(object sender, EventArgs e)
        {
            new frmTanzimat().ShowDialog();
        }

        private void btnKarbar_Click(object sender, EventArgs e)
        {
            new frmKarbar().ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnAnbar_Click(object sender, EventArgs e)
        {
            new frmAnbar().ShowDialog();
        }

        private void btnGrooh_Click(object sender, EventArgs e)
        {
            new frmGrooh().ShowDialog();

        }

        private void btnKala_Click(object sender, EventArgs e)
        {
            new frmKala().ShowDialog();

        }

        private void btnMoshtari_Click(object sender, EventArgs e)
        {
            new frmMoshtari().ShowDialog();
        }

        private void btnHesabha_Click(object sender, EventArgs e)
        {
            new frmHesabha().ShowDialog();
        }

        private void btnVariz_Click(object sender, EventArgs e)
        {
            new frmVariz().ShowDialog();
        }

        private void btnPardakht_Click(object sender, EventArgs e)
        {
            new frmPardakht().ShowDialog();
        }

        private void btnChekP_Click(object sender, EventArgs e)
        {
            new frmChekPardakhti().ShowDialog();
        }

        private void btnChekD_Click(object sender, EventArgs e)
        {
            new frmChekDaryafti().ShowDialog();
        }

        private void btnKarbar_Click_1(object sender, EventArgs e)
        {
            new frmKarbar().ShowDialog();
        }

        private void btnHazineh_Click(object sender, EventArgs e)
        {
            new frmHazineh().ShowDialog();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            new frmDarAmad().ShowDialog();
        }

        private void btnMaliyat_Click(object sender, EventArgs e)
        {
            new frmMaliyat().ShowDialog ();
        }

        private void btnFactorKharid_Click(object sender, EventArgs e)
        {
            new frmFaktorkharid().ShowDialog();
        }

        private void btnFactorFroosh_Click(object sender, EventArgs e)
        {
            new frmFactorFroosh().ShowDialog();
        }

        private void btnSood_Click(object sender, EventArgs e)
        {
            new frmSood().ShowDialog();
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            new frmSarResid().ShowDialog();
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            new frmJabeJayeAnbar().ShowDialog();
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            new frmListJabeJaye().ShowDialog();
        }

        private void buttonX5_Click(object sender, EventArgs e)
        {
            new frmContact().ShowDialog();
        }

        private void buttonX6_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("calc.exe");
        }

        private void buttonX7_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("wordpad.exe");
        }
    }
}
