using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;
using System.Data.SqlClient;
using System.Security.Cryptography;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;

namespace exoConnect
{
    public partial class Frm_reporting : Form
    {
        public Frm_reporting()
        {
            InitializeComponent();
        }
        public byte[] cle = System.Convert.FromBase64String("12UCgcnHy8LHoN/VodosrUVgv+r+kQ5e");
        public byte[] iv = System.Convert.FromBase64String("AsJNO9N/4dM=");
        public string DecryptSym(byte[] cryptedTextAsByte, byte[] key, byte[] iv)
        {
            TripleDESCryptoServiceProvider TDES = new TripleDESCryptoServiceProvider();

            // Cet objet est utilisé pour déchiffrer les données.
            // Il reçoit les données chiffrées sous la forme d'un tableau de bytes.
            // Les données déchiffrées sont également retournées sous la forme d'un tableau de bytes
            var decryptor = TDES.CreateDecryptor(key, iv);

            byte[] decryptedTextAsByte = decryptor.TransformFinalBlock(cryptedTextAsByte, 0, cryptedTextAsByte.Length);

            return Encoding.Default.GetString(decryptedTextAsByte);
        }
        SqlConnection getsc()
        {
            StreamReader sr = new StreamReader("config.fig");
            string cs = sr.ReadToEnd();
            config c = JsonConvert.DeserializeObject<config>(cs);

            return new SqlConnection(DecryptSym(Convert.FromBase64String(c.cs), cle, iv));
        }
        String[] getLogon()
        {
            StreamReader sr = new StreamReader("config.fig");
            string cs = sr.ReadToEnd();
            config c = JsonConvert.DeserializeObject<config>(cs);
            c.cs = DecryptSym(Convert.FromBase64String(c.cs), cle, iv);
            String[] ls = c.cs.Split(';');
            string login = ls[2];
            login = login.Replace(" ", "");
            login = login.Substring(7);
            string pass = ls[3];
            pass = pass.Replace(" ", "");
            pass = pass.Substring(9);
            return new string[] { login, pass };


        } 
        void setCr(ReportClass cr,string filter="")
        {
            cr.SetDatabaseLogon(getLogon()[0], getLogon()[1]);
            Frm_print f = new Frm_print(cr,filter);
            f.Show();
        }

        private void btn_employees_Click(object sender, EventArgs e)
        {
            Cr_employees cr = new Cr_employees();
            setCr(cr);
            
        }

        private void btn_taches_Click(object sender, EventArgs e)
        {
            Cr_taches cr = new Cr_taches();
            setCr(cr);
        }

        private void btn_projets_Click(object sender, EventArgs e)
        {
            Cr_projects cr = new Cr_projects();
            setCr(cr);
        }

        private void btn_carteTravail_Click(object sender, EventArgs e)
        {
            Cr_carte cr = new Cr_carte();
            cr.SetParameterValue("path", Application.StartupPath + @"//photos//");
            string f;
            if (combo_employee.Text == "Tout les employes")
                f = "";
            else
                f = "{Employe.nom} like '*" + combo_employee.Text + "*'";
            setCr(cr,f);
        }

        private void Frm_reporting_Load(object sender, EventArgs e)
        {
            SqlConnection sc = getsc();
            sc.Open();
            SqlCommand com = new SqlCommand("select nom from employe",sc);
            SqlDataReader dr = com.ExecuteReader();
            while (dr.Read())
                combo_employee.Items.Add(dr[0].ToString());
        }

        private void btn_lstprojetes_Click(object sender, EventArgs e)
        {
            Cr_lstProjets cr = new Cr_lstProjets();
            setCr(cr);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cr_graphique cr = new Cr_graphique();
            setCr(cr);
        }
    }
}
