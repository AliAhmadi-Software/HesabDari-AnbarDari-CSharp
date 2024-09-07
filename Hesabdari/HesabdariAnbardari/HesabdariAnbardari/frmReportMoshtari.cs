using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Stimulsoft.Report;

namespace HesabdariAnbardari
{
    public partial class frmReportMoshtari : Form
    {
        public frmReportMoshtari()
        {
            InitializeComponent();
        }

        private void frmReportMoshtari_Load(object sender, EventArgs e)
        {
  
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            StiReport Report = new StiReport();
            Report.Load("Report/rptPardakhtimoshtariha.mrt");
            Report.Compile();
            //   Report["CodeFactor"] = Convert.ToInt32(txtCodeFactor.Text);
            Report["NameMoshtari"] = txtNameMoshtari1.Text;
            Report.ShowWithRibbonGUI();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            StiReport Report = new StiReport();
            Report.Load("Report/rptDaryaftiMoshtari.mrt");
            Report.Compile();
            //   Report["CodeFactor"] = Convert.ToInt32(txtCodeFactor.Text);
            Report["NameMoshtari"] = txtNameMoshtari2.Text;
            Report.ShowWithRibbonGUI();
        }
    }
}
