using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace exoConnect
{
    public partial class Frm_menu : Form
    {
        string role;
        public Frm_menu()
        {
            InitializeComponent();
        }
        public Frm_menu(string role)
        {
            InitializeComponent();
            this.role = role;
        }
        void fillMain(Form f)
        {
            pnl_main.Controls.Clear();
            f.FormBorderStyle = FormBorderStyle.None;
            f.TopLevel = false;
            f.AutoScroll = true;
            pnl_main.Controls.Add(f);
            f.Show();
        }

        private void btn_miseajour_Click(object sender, EventArgs e)
        {
            Frm_miseajour f = new Frm_miseajour(role);
            fillMain(f);
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_recherche_Click(object sender, EventArgs e)
        {
            Frm_recherche f = new Frm_recherche();
            fillMain(f);
        }

        private void btn_reporting_Click(object sender, EventArgs e)
        {
            Frm_reporting f = new Frm_reporting();
            fillMain(f);
        }
    }
}
