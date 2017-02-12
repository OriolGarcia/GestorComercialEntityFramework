namespace GestorComercialEntityFramework
{
    partial class AfegirProducteForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.btInserir = new System.Windows.Forms.Button();
            this.btAnular = new System.Windows.Forms.Button();
            this.productsTableAdapter1 = new GestorComercialEntityFramework.managerDataSetTableAdapters.productsTableAdapter();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBImatge = new System.Windows.Forms.TextBox();
            this.btExaminar = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(89, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nom producte: ";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(92, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Preu:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(175, 45);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(90, 20);
            this.textBox1.TabIndex = 2;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(175, 102);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(90, 20);
            this.textBox2.TabIndex = 3;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            this.textBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox2_KeyPress);
            // 
            // btInserir
            // 
            this.btInserir.Location = new System.Drawing.Point(175, 186);
            this.btInserir.Name = "btInserir";
            this.btInserir.Size = new System.Drawing.Size(65, 23);
            this.btInserir.TabIndex = 4;
            this.btInserir.Text = "Inserir Producte";
            this.btInserir.UseVisualStyleBackColor = true;
            this.btInserir.Click += new System.EventHandler(this.btInserir_Click);
            // 
            // btAnular
            // 
            this.btAnular.Location = new System.Drawing.Point(273, 186);
            this.btAnular.Name = "btAnular";
            this.btAnular.Size = new System.Drawing.Size(65, 23);
            this.btAnular.TabIndex = 5;
            this.btAnular.Text = "Anul·lar";
            this.btAnular.UseVisualStyleBackColor = true;
            this.btAnular.Click += new System.EventHandler(this.btAnular_Click);
            // 
            // productsTableAdapter1
            // 
            this.productsTableAdapter1.ClearBeforeFill = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(73, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Foto producte:";
            // 
            // txtBImatge
            // 
            this.txtBImatge.Location = new System.Drawing.Point(165, 139);
            this.txtBImatge.Name = "txtBImatge";
            this.txtBImatge.Size = new System.Drawing.Size(100, 20);
            this.txtBImatge.TabIndex = 7;
            // 
            // btExaminar
            // 
            this.btExaminar.Location = new System.Drawing.Point(282, 139);
            this.btExaminar.Name = "btExaminar";
            this.btExaminar.Size = new System.Drawing.Size(75, 23);
            this.btExaminar.TabIndex = 8;
            this.btExaminar.Text = "Examinar";
            this.btExaminar.UseVisualStyleBackColor = true;
            this.btExaminar.Click += new System.EventHandler(this.btExaminar_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(304, 34);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(128, 99);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // AfegirProducteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 257);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btExaminar);
            this.Controls.Add(this.txtBImatge);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btAnular);
            this.Controls.Add(this.btInserir);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AfegirProducteForm";
            this.Text = "Afegir Producte";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button btInserir;
        private System.Windows.Forms.Button btAnular;
        private managerDataSetTableAdapters.productsTableAdapter productsTableAdapter1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBImatge;
        private System.Windows.Forms.Button btExaminar;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}