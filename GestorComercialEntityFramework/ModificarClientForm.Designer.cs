namespace GestorComercialEntityFramework
{
    partial class ModificarClientForm
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
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.txtBTelefon = new System.Windows.Forms.TextBox();
            this.txtBProvinicia = new System.Windows.Forms.TextBox();
            this.txtBEmail = new System.Windows.Forms.TextBox();
            this.txtBFax = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtBCiutat = new System.Windows.Forms.TextBox();
            this.txtBCodiPostal = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBAdreça = new System.Windows.Forms.TextBox();
            this.txtBCognom2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtBCognom1 = new System.Windows.Forms.TextBox();
            this.txBNom = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.customersTableAdapter1 = new GestorComercialEntityFramework.MANAGERDataSetNouTableAdapters.customersTableAdapter();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(385, 222);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 44;
            this.button2.Text = "Anul·lar";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(279, 222);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 43;
            this.button1.Text = "Modificar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtBTelefon
            // 
            this.txtBTelefon.Location = new System.Drawing.Point(478, 119);
            this.txtBTelefon.MaxLength = 16;
            this.txtBTelefon.Name = "txtBTelefon";
            this.txtBTelefon.Size = new System.Drawing.Size(100, 20);
            this.txtBTelefon.TabIndex = 42;
            // 
            // txtBProvinicia
            // 
            this.txtBProvinicia.Location = new System.Drawing.Point(318, 119);
            this.txtBProvinicia.MaxLength = 50;
            this.txtBProvinicia.Name = "txtBProvinicia";
            this.txtBProvinicia.Size = new System.Drawing.Size(100, 20);
            this.txtBProvinicia.TabIndex = 41;
            // 
            // txtBEmail
            // 
            this.txtBEmail.Location = new System.Drawing.Point(332, 160);
            this.txtBEmail.MaxLength = 50;
            this.txtBEmail.Name = "txtBEmail";
            this.txtBEmail.Size = new System.Drawing.Size(100, 20);
            this.txtBEmail.TabIndex = 40;
            // 
            // txtBFax
            // 
            this.txtBFax.Location = new System.Drawing.Point(145, 160);
            this.txtBFax.MaxLength = 16;
            this.txtBFax.Name = "txtBFax";
            this.txtBFax.Size = new System.Drawing.Size(100, 20);
            this.txtBFax.TabIndex = 39;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(285, 163);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 13);
            this.label10.TabIndex = 38;
            this.label10.Text = "Email:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(112, 163);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(27, 13);
            this.label9.TabIndex = 37;
            this.label9.Text = "Fax:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(426, 122);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 13);
            this.label8.TabIndex = 36;
            this.label8.Text = "Telèfon:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(255, 122);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 13);
            this.label7.TabIndex = 35;
            this.label7.Text = "Provinicia:";
            // 
            // txtBCiutat
            // 
            this.txtBCiutat.Location = new System.Drawing.Point(143, 119);
            this.txtBCiutat.MaxLength = 50;
            this.txtBCiutat.Name = "txtBCiutat";
            this.txtBCiutat.Size = new System.Drawing.Size(100, 20);
            this.txtBCiutat.TabIndex = 34;
            // 
            // txtBCodiPostal
            // 
            this.txtBCodiPostal.Location = new System.Drawing.Point(438, 79);
            this.txtBCodiPostal.MaxLength = 8;
            this.txtBCodiPostal.Name = "txtBCodiPostal";
            this.txtBCodiPostal.Size = new System.Drawing.Size(48, 20);
            this.txtBCodiPostal.TabIndex = 33;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(361, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 32;
            this.label4.Text = "Codi postal:";
            // 
            // txtBAdreça
            // 
            this.txtBAdreça.Location = new System.Drawing.Point(182, 79);
            this.txtBAdreça.Name = "txtBAdreça";
            this.txtBAdreça.Size = new System.Drawing.Size(173, 20);
            this.txtBAdreça.TabIndex = 31;
            // 
            // txtBCognom2
            // 
            this.txtBCognom2.Location = new System.Drawing.Point(486, 39);
            this.txtBCognom2.MaxLength = 50;
            this.txtBCognom2.Name = "txtBCognom2";
            this.txtBCognom2.Size = new System.Drawing.Size(100, 20);
            this.txtBCognom2.TabIndex = 30;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(100, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 13);
            this.label5.TabIndex = 29;
            this.label5.Text = "Adreça Postal:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(403, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 13);
            this.label6.TabIndex = 28;
            this.label6.Text = "Segon Cognom:";
            // 
            // txtBCognom1
            // 
            this.txtBCognom1.Location = new System.Drawing.Point(297, 39);
            this.txtBCognom1.MaxLength = 50;
            this.txtBCognom1.Name = "txtBCognom1";
            this.txtBCognom1.Size = new System.Drawing.Size(100, 20);
            this.txtBCognom1.TabIndex = 27;
            // 
            // txBNom
            // 
            this.txBNom.Location = new System.Drawing.Point(103, 39);
            this.txBNom.MaxLength = 50;
            this.txBNom.Name = "txBNom";
            this.txBNom.Size = new System.Drawing.Size(100, 20);
            this.txBNom.TabIndex = 26;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(100, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "Ciutat:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(209, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Primer Cognom:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(62, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Nom:";
            // 
            // customersTableAdapter1
            // 
            this.customersTableAdapter1.ClearBeforeFill = true;
            // 
            // ModificarClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 284);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtBTelefon);
            this.Controls.Add(this.txtBProvinicia);
            this.Controls.Add(this.txtBEmail);
            this.Controls.Add(this.txtBFax);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtBCiutat);
            this.Controls.Add(this.txtBCodiPostal);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtBAdreça);
            this.Controls.Add(this.txtBCognom2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtBCognom1);
            this.Controls.Add(this.txBNom);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ModificarClientForm";
            this.Text = "Modificar";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtBTelefon;
        private System.Windows.Forms.TextBox txtBProvinicia;
        private System.Windows.Forms.TextBox txtBEmail;
        private System.Windows.Forms.TextBox txtBFax;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtBCiutat;
        private System.Windows.Forms.TextBox txtBCodiPostal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBAdreça;
        private System.Windows.Forms.TextBox txtBCognom2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtBCognom1;
        private System.Windows.Forms.TextBox txBNom;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private MANAGERDataSetNouTableAdapters.customersTableAdapter customersTableAdapter1;
    }
}