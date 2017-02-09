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
    public partial class ModificarProducteForm : Form
    {
       Boolean imatgecanviada = false;
       string         Origenimatge=null;
        string imagepath;
        private int  ID;
        public ModificarProducteForm(string id, string producte, string preu,string imagepath)
        {

           ID = 0;
           int.TryParse(id, out ID);
           

            InitializeComponent();
            if (File.Exists(imagepath))
            {
                this.imagepath = imagepath;
                pictureBox1.Image = pictureBox1.Image = Image.FromFile(imagepath);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }

            textBox4.Text = producte;
            textBox3.Text = preu.ToString();
          
            
        }

    

        private void btModificar_Click(object sender, EventArgs e)
        {
            Decimal preu = 0;
            Decimal.TryParse(textBox3.Text, out preu);
            productsTableAdapter1.UpdateQuery(textBox4.Text, preu,imagepath,ID);
            Close();
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
                imatgecanviada = true;
                Origenimatge = fileDialog.FileName;
                txtBImatge.Text = fileDialog.FileName;
                pictureBox1.Image = Image.FromFile(fileDialog.FileName);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                imagepath = fileDialog.FileName;
            }

        }
    }
}
