
namespace exoConnect
{
    partial class Frm_recherche
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.combo_projects = new System.Windows.Forms.ComboBox();
            this.lst_taches = new System.Windows.Forms.ListBox();
            this.dgv_emps = new System.Windows.Forms.DataGridView();
            this.Nom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pourcentage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt_total = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_emps)).BeginInit();
            this.SuspendLayout();
            // 
            // combo_projects
            // 
            this.combo_projects.FormattingEnabled = true;
            this.combo_projects.Location = new System.Drawing.Point(12, 25);
            this.combo_projects.Name = "combo_projects";
            this.combo_projects.Size = new System.Drawing.Size(266, 28);
            this.combo_projects.TabIndex = 0;
            this.combo_projects.SelectedIndexChanged += new System.EventHandler(this.combo_projects_SelectedIndexChanged);
            // 
            // lst_taches
            // 
            this.lst_taches.FormattingEnabled = true;
            this.lst_taches.ItemHeight = 20;
            this.lst_taches.Location = new System.Drawing.Point(14, 67);
            this.lst_taches.Name = "lst_taches";
            this.lst_taches.Size = new System.Drawing.Size(263, 484);
            this.lst_taches.TabIndex = 1;
            // 
            // dgv_emps
            // 
            this.dgv_emps.AllowUserToAddRows = false;
            this.dgv_emps.AllowUserToDeleteRows = false;
            this.dgv_emps.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_emps.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nom,
            this.nb,
            this.pourcentage});
            this.dgv_emps.Location = new System.Drawing.Point(302, 67);
            this.dgv_emps.Name = "dgv_emps";
            this.dgv_emps.ReadOnly = true;
            this.dgv_emps.Size = new System.Drawing.Size(590, 483);
            this.dgv_emps.TabIndex = 2;
            // 
            // Nom
            // 
            this.Nom.HeaderText = "Nom";
            this.Nom.Name = "Nom";
            this.Nom.Width = 250;
            // 
            // nb
            // 
            this.nb.FillWeight = 150F;
            this.nb.HeaderText = "nombre des heures ";
            this.nb.Name = "nb";
            this.nb.Width = 170;
            // 
            // pourcentage
            // 
            this.pourcentage.FillWeight = 110F;
            this.pourcentage.HeaderText = "Pourcentage ";
            this.pourcentage.Name = "pourcentage";
            this.pourcentage.Width = 110;
            // 
            // txt_total
            // 
            this.txt_total.Location = new System.Drawing.Point(783, 563);
            this.txt_total.Name = "txt_total";
            this.txt_total.ReadOnly = true;
            this.txt_total.Size = new System.Drawing.Size(128, 26);
            this.txt_total.TabIndex = 3;
            // 
            // Frm_recherche
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 650);
            this.Controls.Add(this.txt_total);
            this.Controls.Add(this.dgv_emps);
            this.Controls.Add(this.lst_taches);
            this.Controls.Add(this.combo_projects);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Frm_recherche";
            this.Text = "Frm_recherche";
            this.Load += new System.EventHandler(this.Frm_recherche_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_emps)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox combo_projects;
        private System.Windows.Forms.ListBox lst_taches;
        private System.Windows.Forms.DataGridView dgv_emps;
        private System.Windows.Forms.TextBox txt_total;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nom;
        private System.Windows.Forms.DataGridViewTextBoxColumn nb;
        private System.Windows.Forms.DataGridViewTextBoxColumn pourcentage;
    }
}