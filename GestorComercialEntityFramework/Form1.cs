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
    public partial class Form1 : Form
    {
        public Form1()
        {
        
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'managerDataSet1.invoice' table. You can move, or remove it, as needed.
            this.invoiceTableAdapter.Fill(this.managerDataSet.invoice);
            // TODO: This line of code loads data into the 'managerDataSet.products' table. You can move, or remove it, as needed.
            this.productsTableAdapter.FillByFilter(this.managerDataSet.products,txtBNomProducte.Text, "%"+txtBNomProducte.Text+"%");
            this.costumersTableAdapter.FillByFilter(this.managerDataSet.customers,  txtBNomClient.Text, "%" +  txtBNomClient.Text + "%",
             txtBCognomsClient.Text, "%" + txtBCognomsClient.Text + "%", txtBCiutatClient.Text, "%" + txtBCiutatClient.Text + "%");
            dataGridViewProductesFactura.DataSource = productsTableAdapter.Fill(this.managerDataSet.products);
            //ByFilter txtBNomClient.Text,txtBCognomsClient.Text,txtBCiutatClient.Text);
        }

        private void btEliminar_Click(object sender, EventArgs e)
        {

            int selectedRowCount = dataGridViewProducts.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                var confirmEliminar = MessageBox.Show("Segur que vols eliminar les files seleccionades?",
                    "Confirmació d'Eliminació!",
                    MessageBoxButtons.YesNo);
                if (confirmEliminar == DialogResult.Yes)
                {
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                                      for (int i = 0; i < selectedRowCount; i++)
                    {

                        try
                        {
                            int ProductId = 0;
                            Int32.TryParse(dataGridViewProducts.SelectedRows[0].Cells[0].Value.ToString(),out ProductId);
                            this.productsTableAdapter.DeleteQuery(ProductId);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }

                        this.productsTableAdapter.Fill(this.managerDataSet.products);

                    }
                }

            }
        }
        private void formAfegirClient_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.costumersTableAdapter.FillByFilter(this.managerDataSet.customers,  txtBNomClient.Text, "%" +  txtBNomClient.Text + "%",
             txtBCognomsClient.Text, "%" + txtBCognomsClient.Text + "%", txtBCiutatClient.Text, "%" + txtBCiutatClient.Text + "%");
            }
        private void btAfegirClient_Click(object sender, EventArgs e)
        {
            FormAfegirClient formAfegirClient = new FormAfegirClient();

            formAfegirClient.FormClosed += new System.Windows.Forms.FormClosedEventHandler(formAfegirClient_FormClosed);

            formAfegirClient.Show();
        }

        private void fillToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.costumersTableAdapter.Fill(this.managerDataSet.customers);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void fillByFilterToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.costumersTableAdapter.FillByFilter(this.managerDataSet.customers,  txtBNomClient.Text, "%" +  txtBNomClient.Text + "%",
               txtBCognomsClient.Text, "%" + txtBCognomsClient.Text + "%", txtBCiutatClient.Text, "%" + txtBCiutatClient.Text + "%");
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void txtBNomClient_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.costumersTableAdapter.FillByFilter(this.managerDataSet.customers,  txtBNomClient.Text, "%" +  txtBNomClient.Text + "%",
                            txtBCognomsClient.Text, "%" + txtBCognomsClient.Text + "%", txtBCiutatClient.Text, "%" + txtBCiutatClient.Text + "%");
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txtBCognomsClient_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.costumersTableAdapter.FillByFilter(this.managerDataSet.customers, txtBNomClient.Text, "%" + txtBNomClient.Text + "%",
              txtBCognomsClient.Text, "%" + txtBCognomsClient.Text + "%", txtBCiutatClient.Text, "%" + txtBCiutatClient.Text + "%");
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void txtBCiutatClient_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.costumersTableAdapter.FillByFilter(this.managerDataSet.customers,  txtBNomClient.Text, "%" +  txtBNomClient.Text + "%",
               txtBCognomsClient.Text, "%" + txtBCognomsClient.Text + "%", txtBCiutatClient.Text, "%" + txtBCiutatClient.Text + "%");
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void btEliminarClient_Click(object sender, EventArgs e)
        {

            int selectedRowCount = dataGridViewCustumers.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                var confirmEliminar = MessageBox.Show("Segur que vols eliminar les files seleccionades?",
                    "Confirmació d'Eliminació!",
                    MessageBoxButtons.YesNo);
                if (confirmEliminar == DialogResult.Yes)
                {
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    for (int i = 0; i < selectedRowCount; i++)
                    {

                        try
                        {
                            int Id = 0;
                            Int32.TryParse(dataGridViewCustumers.SelectedRows[0].Cells[0].Value.ToString(), out Id);
                            this.costumersTableAdapter.DeleteQuery(Id);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }

                        this.costumersTableAdapter.FillByFilter(this.managerDataSet.customers, txtBNomClient.Text, "%" + txtBNomClient.Text + "%",
                           txtBCognomsClient.Text, "%" + txtBCognomsClient.Text + "%", txtBCiutatClient.Text, "%" + txtBCiutatClient.Text + "%");

                    }
                }

            }
        }

        private void txtBNomProducte_TextChanged(object sender, EventArgs e)
        {
            this.productsTableAdapter.FillByFilter(this.managerDataSet.products, txtBNomProducte.Text, "%" + txtBNomProducte.Text + "%");
        }
    }
}
