
namespace exoConnect
{
    partial class Frm_menu
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
            this.pnl_sideBar = new System.Windows.Forms.Panel();
            this.btn_exit = new System.Windows.Forms.Button();
            this.btn_recherche = new System.Windows.Forms.Button();
            this.btn_miseajour = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pnl_main = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.pnl_sideBar.SuspendLayout();
            this.pnl_main.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_sideBar
            // 
            this.pnl_sideBar.Controls.Add(this.btn_exit);
            this.pnl_sideBar.Controls.Add(this.btn_recherche);
            this.pnl_sideBar.Controls.Add(this.btn_miseajour);
            this.pnl_sideBar.Controls.Add(this.label1);
            this.pnl_sideBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnl_sideBar.Location = new System.Drawing.Point(0, 0);
            this.pnl_sideBar.Name = "pnl_sideBar";
            this.pnl_sideBar.Size = new System.Drawing.Size(203, 650);
            this.pnl_sideBar.TabIndex = 0;
            // 
            // btn_exit
            // 
            this.btn_exit.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btn_exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_exit.Location = new System.Drawing.Point(0, 596);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(203, 54);
            this.btn_exit.TabIndex = 3;
            this.btn_exit.Text = "Exit";
            this.btn_exit.UseVisualStyleBackColor = true;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // btn_recherche
            // 
            this.btn_recherche.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btn_recherche.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_recherche.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_recherche.Location = new System.Drawing.Point(0, 98);
            this.btn_recherche.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.btn_recherche.Name = "btn_recherche";
            this.btn_recherche.Size = new System.Drawing.Size(203, 54);
            this.btn_recherche.TabIndex = 2;
            this.btn_recherche.Text = "Recherche";
            this.btn_recherche.UseVisualStyleBackColor = false;
            this.btn_recherche.Click += new System.EventHandler(this.btn_recherche_Click);
            // 
            // btn_miseajour
            // 
            this.btn_miseajour.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btn_miseajour.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_miseajour.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_miseajour.Location = new System.Drawing.Point(0, 44);
            this.btn_miseajour.Name = "btn_miseajour";
            this.btn_miseajour.Size = new System.Drawing.Size(203, 54);
            this.btn_miseajour.TabIndex = 1;
            this.btn_miseajour.Text = "Mise A Jour";
            this.btn_miseajour.UseVisualStyleBackColor = false;
            this.btn_miseajour.Click += new System.EventHandler(this.btn_miseajour_Click);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Mistral", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(203, 44);
            this.label1.TabIndex = 1;
            this.label1.Text = "Gestion Projects";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnl_main
            // 
            this.pnl_main.Controls.Add(this.label2);
            this.pnl_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_main.Location = new System.Drawing.Point(203, 0);
            this.pnl_main.Name = "pnl_main";
            this.pnl_main.Size = new System.Drawing.Size(930, 650);
            this.pnl_main.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Mistral", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(930, 650);
            this.label2.TabIndex = 2;
            this.label2.Text = "Gestion Projects";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Frm_menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1133, 650);
            this.Controls.Add(this.pnl_main);
            this.Controls.Add(this.pnl_sideBar);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Frm_menu";
            this.Text = "Gestion Projects";
            this.pnl_sideBar.ResumeLayout(false);
            this.pnl_main.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_sideBar;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.Button btn_recherche;
        private System.Windows.Forms.Button btn_miseajour;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnl_main;
        private System.Windows.Forms.Label label2;
    }
}