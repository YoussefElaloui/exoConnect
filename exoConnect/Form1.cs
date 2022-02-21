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
    public partial class Frm_login : Form
    {
        public Frm_login()
        {
            InitializeComponent();
        }
        public byte[] cle = System.Convert.FromBase64String("12UCgcnHy8LHoN/VodosrUVgv+r+kQ5e");
        public byte[] iv = System.Convert.FromBase64String("AsJNO9N/4dM=");


        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
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
        static public string hash(string chaine)
        {
            byte[] textAsByte = Encoding.Default.GetBytes(chaine);

            SHA512 sha512 = SHA512Cng.Create();

            byte[] hash = sha512.ComputeHash(textAsByte);

            return Convert.ToBase64String(hash);

        }
        private void btn_signin_Click(object sender, EventArgs e)
        {
            string role="";
            StreamReader sr = new StreamReader("config.fig");
            string cs = sr.ReadToEnd();
            config c = JsonConvert.DeserializeObject<config>(cs);

            SqlConnection sc = new SqlConnection(DecryptSym(Convert.FromBase64String(c.cs), cle, iv));
            sc.Open();
            SqlCommand com = new SqlCommand(string.Format("select * from Utilisateur where login ='{0}'",txt_login.Text), sc);
            SqlDataReader dr = com.ExecuteReader();
            while (dr.Read())
            {
                if (dr["Password"].ToString() == hash(txt_password.Text) && Convert.ToDateTime(dr["dateExipration"])>DateTime.Today)
                {
                    role = dr["role"].ToString();
                }
            }
            if (role != string.Empty)
            {
                this.Hide();
                Frm_menu f = new Frm_menu(role);
                f.ShowDialog();
                this.Show();
            }
            else
                MessageBox.Show("login or password is incorrect", "login error", MessageBoxButtons.OK, MessageBoxIcon.Information);

            sr.Close();
        }

        private void btn_config_Click(object sender, EventArgs e)
        {
            Frm_config f = new Frm_config();
            f.ShowDialog();
        }
    }
}
