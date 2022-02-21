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
    public partial class Frm_miseajour : Form
    {
        string role="";
        public Frm_miseajour()
        {
            InitializeComponent();
        }
        public Frm_miseajour(string role)
        {
            InitializeComponent();
            this.role = role;
        }
        bool isAdd = false;
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
        void activate(bool b) {
            pnl_lst.Enabled = b;
            pnl_details.Enabled = !b;
            pnl_save.Visible = !b;
            pnl_miseajour.Visible = b;
        }
        SqlConnection getsc()
        {
            StreamReader sr = new StreamReader("config.fig");
            string cs = sr.ReadToEnd();
            config c = JsonConvert.DeserializeObject<config>(cs);

            return new SqlConnection(DecryptSym(Convert.FromBase64String(c.cs), cle, iv));
        }
        void updateEmp(string f)
        {
            SqlConnection sc = getsc();
            sc.Open();
            SqlCommand com;
            if (f == "")
                com = new SqlCommand(string.Format("select * from Employe where Num_serv ={0}", Convert.ToInt32(combo_service.SelectedValue)), sc);
            else
                com = new SqlCommand(string.Format("select * from Employe where Num_serv ={0} and nom like '%{1}%'", Convert.ToInt32(combo_service.SelectedValue),f), sc);

            SqlDataReader dr = com.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(dr);
            lst.DisplayMember = "nom";
            lst.ValueMember = "Matricule";
            lst.DataSource = table;
            sc.Close();
            dr.Close();
            dr = null;
        }
        void updateEmpV2()
        {
            txt_matricule.Text = "";
            txt_nom.Text = "";
            txt_prenom.Text = "";
            txt_date.Text = "";
            txt_adresse.Text = "";
            txt_salaire.Text = "";
            txt_grade.Text = "";
            SqlConnection sc = getsc();
            sc.Open();
            SqlCommand com = new SqlCommand(string.Format("select * from Employe where Matricule ={0}", Convert.ToInt32(lst.SelectedValue)), sc);
            SqlDataReader dr = com.ExecuteReader();
            while (dr.Read())
            {
                txt_matricule.Text = dr["Matricule"].ToString();
                txt_nom.Text = dr["nom"].ToString();
                txt_prenom.Text = dr["prenom"].ToString();
                txt_date.Text = dr["DateNaissance"].ToString();
                txt_adresse.Text = dr["adresse"].ToString();
                txt_salaire.Text = dr["salaire"].ToString();
                txt_grade.Text = dr["grade"].ToString();
            }
            dr.Close();
            sc.Close();
        }
        private void Frm_miseajour_Load(object sender, EventArgs e)
        {
            activate(true);
            SqlConnection sc = getsc();
            sc.Open();
            SqlCommand com = new SqlCommand("select * from service", sc);
            SqlDataReader dr = com.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(dr);
            combo_service.DisplayMember = "Nom_serv";
            combo_service.ValueMember = "Num_serv";
            combo_service.DataSource = table;
            sc.Close();
            dr.Close();
            dr = null;
            updateEmp("");



            if (role != "admin")
                pnl_miseajour.Visible = pnl_save.Visible = false;
        }

        private void combo_service_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateEmp("");
            updateEmpV2();
        }

        private void lst_SelectedValueChanged(object sender, EventArgs e)
        {
            updateEmpV2();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_first_Click(object sender, EventArgs e)
        {
            lst.SelectedIndex = 0;
        }

        private void btn_last_Click(object sender, EventArgs e)
        {
            lst.SelectedIndex = lst.Items.Count - 1;
        }

        private void btn_prev_Click(object sender, EventArgs e)
        {
            if (lst.SelectedIndex == 0)
                lst.SelectedIndex = lst.Items.Count - 1;
            else
                lst.SelectedIndex--;
        }

        private void btn_next_Click(object sender, EventArgs e)
        {
            if (lst.SelectedIndex == lst.Items.Count - 1)
                lst.SelectedIndex = 0;
            else
                lst.SelectedIndex++;
        }

        private void btn_find_Click(object sender, EventArgs e)
        {
            updateEmp(txt_find.Text);
        }

        private void btn_ajouter_Click(object sender, EventArgs e)
        {
            txt_matricule.Text = "";
            txt_nom.Text = "";
            txt_prenom.Text = "";
            txt_date.Text = "";
            txt_adresse.Text = "";
            txt_salaire.Text = "";
            txt_grade.Text = "";
            txt_nom.Focus();
            isAdd = true;
            activate(false);

        }

        private void btn_modifier_Click(object sender, EventArgs e)
        {
            isAdd = false;
            txt_nom.Focus();
            activate(false);
        }

        private void btn_annuler_Click(object sender, EventArgs e)
        {
            updateEmp("");
            updateEmpV2();
            isAdd = false;
            activate(true);

        }

        private void btn_valider_Click(object sender, EventArgs e)
        {
            SqlConnection sc = getsc();
            sc.Open();
            SqlCommand com = new SqlCommand();
            com.Connection = sc;
            if (isAdd)
                com.CommandText = string.Format("insert into employe values ('{0}','{1}','{2}','{3}',{4},'{5}',{6})", txt_nom.Text, txt_prenom.Text, txt_date.Text, txt_adresse.Text, Convert.ToDouble(txt_salaire.Text), txt_grade.Text,combo_service.SelectedValue);
            else
                com.CommandText = string.Format("update employe set nom='{0}',prenom='{1}',DateNaissance='{2}',adresse='{3}',salaire={4},grade='{5}' where Matricule={6}", txt_nom.Text, txt_prenom.Text, txt_date.Text, txt_adresse.Text, Convert.ToDouble(txt_salaire.Text), txt_grade.Text,lst.SelectedValue);
            com.ExecuteNonQuery();
            sc.Close();
            updateEmp("");
            activate(true);

        }

        private void btn_supprimer_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you ok about deleting this item ?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                SqlConnection sc = getsc();
                sc.Open();
                SqlCommand com = new SqlCommand(string.Format("delete from employe where Matricule ={0}", lst.SelectedValue), sc);
                com.ExecuteNonQuery();
                updateEmp("");
            }
        }
    }
}
