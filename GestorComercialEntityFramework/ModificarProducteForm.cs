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
    public partial class ModificarProducteForm : Form
    {

        private int  ID;
        public ModificarProducteForm(string id, string producte, string preu)
        {

           ID = 0;
           int.TryParse(id, out ID);
           

            InitializeComponent();
          
            textBox1.Text = producte;
            textBox2.Text = preu.ToString();
        }

    

        private void btModificar_Click(object sender, EventArgs e)
        {
            Decimal preu = 0;
            Decimal.TryParse(textBox2.Text, out preu);
            productsTableAdapter1.UpdateQuery(textBox1.Text, preu,ID);
            Close();
        }
    }
}
