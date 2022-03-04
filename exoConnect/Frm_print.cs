using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;

namespace exoConnect
{
    public partial class Frm_print : Form
    {
        ReportClass cr;
        string filter;
        public Frm_print(ReportClass cr,string filter)
        {
            InitializeComponent();
            this.cr = cr;
            this.filter = filter;
        }

        private void Frm_print_Load(object sender, EventArgs e)
        {
            crv.ReportSource = cr;
            crv.SelectionFormula = filter;
        }
    }
}
