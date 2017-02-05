using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestorComercialEntityFramework
{
    public partial class ModificarClientForm : Form
    {

        private int ID;
        public ModificarClientForm(string id, string nom, string cognom1, string cognom2,string postaladress, string postal,
        string ciutat, string provincia, string telefon, string fax, string email )
        {

            ID = 0;
            int.TryParse(id, out ID);
        
            
            InitializeComponent();
            txBNom.Text = nom;
            txtBCognom1.Text = cognom1;
            txtBCognom2.Text = cognom2;
            txtBAdreça.Text = postaladress;
            txtBCodiPostal.Text = postal;
            txtBCiutat.Text = ciutat;
            txtBProvinicia.Text = provincia;
            txtBTelefon.Text = telefon;
            txtBFax.Text = fax;
            txtBEmail.Text = email;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int codipostal = 0;
            Int32.TryParse(txtBCodiPostal.Text, out codipostal);

            int telefon = 0;
            Int32.TryParse(txtBTelefon.Text, out telefon);
            int fax = 0;
            Int32.TryParse(txtBFax.Text, out fax);
            customersTableAdapter1.UpdateQuery(txBNom.Text, txtBCognom1.Text, txtBCognom2.Text, txtBAdreça.Text, codipostal,
            txtBCiutat.Text, txtBProvinicia.Text, telefon, fax, txtBEmail.Text,ID);
            Close();
        }
    }
}
