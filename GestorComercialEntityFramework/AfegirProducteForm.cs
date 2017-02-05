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
    public partial class AfegirProducteForm : Form
    {
        public AfegirProducteForm()
        {
            InitializeComponent();
        }

        private void btInserir_Click(object sender, EventArgs e)
        {
           Decimal preu=0;
            Decimal.TryParse(textBox2.Text, out preu);
            productsTableAdapter1.InsertQuery(textBox1.Text, preu);
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
    }
}
