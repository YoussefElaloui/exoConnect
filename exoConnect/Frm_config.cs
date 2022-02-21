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
    public partial class Frm_config : Form
    {
        public Frm_config()
        {
            InitializeComponent();
        }

        public byte[] cle = System.Convert.FromBase64String("12UCgcnHy8LHoN/VodosrUVgv+r+kQ5e");
        public byte[] iv = System.Convert.FromBase64String("AsJNO9N/4dM=");
        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        static public byte[] EncryptSym(string text, byte[] key, byte[] iv)
        {
            byte[] textAsByte = Encoding.Default.GetBytes(text);
            TripleDESCryptoServiceProvider TDES = new TripleDESCryptoServiceProvider();
            // Cet objet est utilisé pour chiffrer les données.
            // Il reçoit en entrée les données en clair sous la forme d'un tableau de bytes.
            // Les données chiffrées sont également retournées sous la forme d'un tableau de bytes
            var encryptor = TDES.CreateEncryptor(key, iv);

            byte[] cryptedTextAsByte = encryptor.TransformFinalBlock(textAsByte, 0, textAsByte.Length);

            return cryptedTextAsByte;
        }
        private void btn_ok_Click(object sender, EventArgs e)
        {
            string cs = string.Format(@"Data Source={0};Initial Catalog={1};User ID={2};Password={3}",txt_server.Text,txt_database.Text,txt_user.Text,txt_pass.Text);
            cs= Convert.ToBase64String(EncryptSym(cs, cle, iv));
            config c = new config(cs);
            StreamWriter sw = new StreamWriter("config.fig");
            sw.Write(JsonConvert.SerializeObject(c));
            sw.Close();
            this.Close();
        }
    }
}
