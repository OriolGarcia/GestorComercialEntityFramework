using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestorComercialEntityFramework
{
    public partial class AfegirProducteForm : Form
    {
        private string Origenimatge = null;
        private string pathdesti;
        public AfegirProducteForm( string pathdesti)
        {
            this.pathdesti = pathdesti;
            InitializeComponent();
        }

        private void btInserir_Click(object sender, EventArgs e)
        {
           Decimal preu=0;
            Decimal.TryParse(textBox2.Text, out preu);


            string destiImatge = null;

            if (Origenimatge != null)
            {
                destiImatge = Path.Combine(pathdesti, Path.GetFileName(Origenimatge));
                if (File.Exists(destiImatge))
                {
                    var confirm = MessageBox.Show("Ja existeix la fotografia al servidor.Vols sobreescriure-la?",
                                                "Confirmació Sobrescriptura!", MessageBoxButtons.YesNo);
                    if (confirm == DialogResult.Yes)
                        File.Delete(destiImatge);
                    else return;
                }

                File.Copy(Origenimatge, destiImatge);

            }
            productsTableAdapter1.InsertQuery(textBox1.Text, preu,destiImatge);
            Close();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utils.checkonlynumber(sender, e);
        }

        private void btAnular_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btExaminar_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();

            fileDialog.InitialDirectory = "C:\\";
            fileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg;  *.png";
            fileDialog.FilterIndex = 4;
            fileDialog.RestoreDirectory = true;

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                Origenimatge = fileDialog.FileName;
                txtBImatge.Text = fileDialog.FileName;
                pictureBox1.Image = Image.FromFile(fileDialog.FileName);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }

        }
    }
}
