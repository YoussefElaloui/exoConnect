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
using System.CodeDom.Compiler;

namespace exoConnect
{
    public partial class Frm_recherche : Form
    {
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
        public Frm_recherche()
        {
            InitializeComponent();
        }
        void update()
        {
            lst_taches.Items.Clear();
            dgv_emps.Rows.Clear();
            SqlConnection sc = getsc();
            sc.Open();
            SqlCommand com1 = new SqlCommand("select * from tache where num_prj =" + combo_projects.SelectedValue.ToString(), sc);
            SqlCommand com2 = new SqlCommand(string.Format("select nom,SUM(Nombre_heure) as nb,(SUM(Nombre_heure)*100)/(select sum(Nombre_heure) from Projet p inner join Tache t on p.Num_prj=t.Num_prj inner join Travaille tr on tr.Num_tach=t.Num_tach where p.Num_prj={0})  as total from Employe e inner join Travaille t on e.Matricule=t.Matricule inner join Tache ta on ta.Num_tach=t.Num_tach inner join Projet p on p.Num_prj=ta.Num_prj where p.Num_prj={0} group by nom",combo_projects.SelectedValue.ToString()), sc);
            SqlCommand com3 = new SqlCommand(string.Format("select sum(Nombre_heure) from Projet p inner join Tache t on p.Num_prj=t.Num_prj inner join Travaille tr on tr.Num_tach=t.Num_tach where p.Num_prj={0}", combo_projects.SelectedValue.ToString()), sc);
            SqlDataReader dr = com1.ExecuteReader();
            while (dr.Read())
                lst_taches.Items.Add(dr["nom_tache"]);
            dr.Close();
            dr = com2.ExecuteReader();
            while (dr.Read())
                dgv_emps.Rows.Add(dr[0], dr[1], dr[2] +"%");
            dr.Close();
            double total = Convert.ToDouble(com3.ExecuteScalar());
            txt_total.Text = total.ToString();

        }
        private void Frm_recherche_Load(object sender, EventArgs e)
        {
            SqlConnection sc = getsc();
            sc.Open();
            SqlCommand com = new SqlCommand("select * from projet", sc);
            SqlDataReader dr = com.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(dr);
            combo_projects.DisplayMember = "nom_prj";
            combo_projects.ValueMember = "num_prj";
            combo_projects.DataSource = table;
            dr.Close();
            sc.Close();
            dr = null;
            sc = null;
        }

        private void combo_projects_SelectedIndexChanged(object sender, EventArgs e)
        {
            update();
        }
    }
}
