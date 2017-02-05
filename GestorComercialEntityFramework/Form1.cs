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
            mANAGERDataSetNou.EnforceConstraints = false;
            // TODO: This line of code loads data into the 'mANAGERDataSetNou.customers' table. You can move, or remove it, as needed.
            this.customersTableAdapter2.FillByFilter2(this.mANAGERDataSetNou.customers, txtBNomClient2.Text, txtBCognomsClient2.Text, txtBTelefonClient2.Text, "%" + txtBCognomsClient2.Text + "%",
             "%" + txtBNomClient2.Text + "%", "%" + txtBTelefonClient2.Text + "%");
            // TODO: This line of code loads data into the 'mANAGERDataSetNou.products' table. You can move, or remove it, as needed.
            this.productsTableAdapter2.FillByFilter(this.mANAGERDataSetNou.products, txtBNomProducte2.Text, "%" + txtBNomProducte2.Text + "%");
            // TODO: This line of code loads data into the 'managerDataSet1.invoice' table. You can move, or remove it, as needed.
            this.invoiceTableAdapter.Fill(this.managerDataSet.invoice);
            // TODO: This line of code loads data into the 'managerDataSet.products' table. You can move, or remove it, as needed.
            this.productsTableAdapter.FillByFilter(this.managerDataSet.products, txtBNomProducte.Text, "%" + txtBNomProducte.Text + "%");
            this.costumersTableAdapter.FillByFilter(this.managerDataSet.customers, txtBNomClient.Text, "%" + txtBNomClient.Text + "%",
             txtBCognomsClient.Text, "%" + txtBCognomsClient.Text + "%", txtBTelefonClient.Text, "%" + txtBTelefonClient.Text + "%");
            //   dataGridViewProductesFactura.DataSource = productsTableAdapter.Fill(this.managerDataSet.products);
            //ByFilter txtBNomClient.Text,txtBCognomsClient.Text,txtBCiutatClient.Text);

            foreach (DataGridViewColumn col in dataGridViewProductesFactura.Columns)
            {
                dataGridViewProductesFacturaAfegits.Columns.Add((DataGridViewColumn)col.Clone());

            }
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
             txtBCognomsClient.Text, "%" + txtBCognomsClient.Text + "%", txtBTelefonClient.Text, "%" + txtBTelefonClient.Text + "%");
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
               txtBCognomsClient.Text, "%" + txtBCognomsClient.Text + "%", txtBTelefonClient.Text, "%" + txtBTelefonClient.Text + "%");
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
                            txtBCognomsClient.Text, "%" + txtBCognomsClient.Text + "%", txtBTelefonClient.Text, "%" + txtBTelefonClient.Text + "%");
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
              txtBCognomsClient.Text, "%" + txtBCognomsClient.Text + "%", txtBTelefonClient.Text, "%" + txtBTelefonClient.Text + "%");
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
               txtBCognomsClient.Text, "%" + txtBCognomsClient.Text + "%", txtBTelefonClient.Text, "%" + txtBTelefonClient.Text + "%");
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
                           txtBCognomsClient.Text, "%" + txtBCognomsClient.Text + "%", txtBTelefonClient.Text, "%" + txtBTelefonClient.Text + "%");

                    }
                }

            }
        }

        private void txtBNomProducte_TextChanged(object sender, EventArgs e)
        {
            this.productsTableAdapter.FillByFilter(this.managerDataSet.products, txtBNomProducte.Text, "%" + txtBNomProducte.Text + "%");
        }

       

        private void btAfegir_Click_1(object sender, EventArgs e)
        {
            var rows = dataGridViewProductesFactura.SelectedRows;
            int count = rows.Count; MessageBox.Show(count.ToString());
            if (count > 0)
                for (int i = 0; i < count; i++)
                {

                    dataGridViewProductesFacturaAfegits.Rows.Add(rows[i].Clone());
                }
        }

        private void txtBNomProducte2_TextChanged(object sender, EventArgs e)
        {
            this.productsTableAdapter2.FillByFilter(this.mANAGERDataSetNou.products, txtBNomProducte2.Text, "%" + txtBNomProducte2.Text + "%");
        }

        private void mainTabs_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btModificar_Click(object sender, EventArgs e)
        {

        }

        private void txtBNomClient2_TextChanged(object sender, EventArgs e)
        {
            this.customersTableAdapter2.FillByFilter2(this.mANAGERDataSetNou.customers, txtBNomClient2.Text, txtBCognomsClient2.Text, txtBTelefonClient2.Text, "%" + txtBCognomsClient2.Text + "%",
             "%" + txtBNomClient2.Text + "%",     "%" + txtBTelefonClient2.Text + "%");
        }

        private void txtBCognomsClient2_TextChanged(object sender, EventArgs e)
        {
            this.customersTableAdapter2.FillByFilter2(this.mANAGERDataSetNou.customers, txtBNomClient2.Text, txtBCognomsClient2.Text, txtBTelefonClient2.Text, "%" + txtBCognomsClient2.Text + "%",
              "%" + txtBNomClient2.Text + "%", "%" + txtBTelefonClient2.Text + "%");
        }

        private void txtBTelefonClient2_TextChanged(object sender, EventArgs e)
        {
            this.customersTableAdapter2.FillByFilter2(this.mANAGERDataSetNou.customers, txtBNomClient2.Text, txtBCognomsClient2.Text, txtBTelefonClient2.Text, "%" + txtBCognomsClient2.Text + "%",
            "%" + txtBNomClient2.Text + "%", "%" + txtBTelefonClient2.Text + "%");
        }

        private void dataGridViewProductesFactura_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void formAfegirProducte_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.productsTableAdapter.FillByFilter(this.managerDataSet.products, txtBNomProducte.Text, "%" + txtBNomProducte.Text + "%");
        }
        private void button6_Click(object sender, EventArgs e)
        {
           AfegirProducteForm formAfegirProducte = new AfegirProducteForm();

            formAfegirProducte.FormClosed += new System.Windows.Forms.FormClosedEventHandler(formAfegirProducte_FormClosed);

            formAfegirProducte.Show();
        }
    }
}
