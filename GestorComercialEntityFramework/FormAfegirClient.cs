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
    public partial class FormAfegirClient : Form
    {
        public FormAfegirClient()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int codipostal, telefon, fax;

            Int32.TryParse(txtBCodiPostal.Text, out codipostal);
            Int32.TryParse(txtBTelefon.Text, out telefon);
            Int32.TryParse(txtBFax.Text, out fax);
            customersTableAdapter1.InsertQuery(txBNom.Text, txtBCognom1.Text, txtBCognom2.Text, txtBAdreça.Text, codipostal, txtBCiutat.Text, txtBProvinicia.Text,
            telefon, fax, txtBEmail.Text);
            Close();
        }
     

        private void txtBTelefon_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utils.checkonlynumber(sender, e);
        }

        private void txtBFax_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utils.checkonlynumber(sender, e);
        }

        private void txtBCodiPostal_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utils.checkonlynumber(sender, e);
        }
    }
}
