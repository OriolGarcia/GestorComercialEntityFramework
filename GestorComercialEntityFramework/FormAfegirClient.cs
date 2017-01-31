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
        private void checkonlynumber(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                 (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
     

        private void txtBTelefon_KeyPress(object sender, KeyPressEventArgs e)
        {
            checkonlynumber(sender, e);
        }

        private void txtBFax_KeyPress(object sender, KeyPressEventArgs e)
        {
            checkonlynumber(sender, e);
        }

        private void txtBCodiPostal_KeyPress(object sender, KeyPressEventArgs e)
        {
            checkonlynumber(sender, e);
        }
    }
}
