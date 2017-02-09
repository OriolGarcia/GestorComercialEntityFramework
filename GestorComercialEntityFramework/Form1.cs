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
    public partial class Form1 : Form
    {

        private string pathimage =@"C:\GComercial_images";
        public Form1()
        {

            InitializeComponent();

            InsertColumns(dataGridViewProducts);
            
            
        }
        private void InsertColumns( DataGridView dataGridView)
        {
            DataGridViewImageColumn img = new DataGridViewImageColumn();
            img.Visible = true;
            img.HeaderText = "Image";
            img.Name = "Image";
            img.Width = 100;
            dataGridView.RowTemplate.Height =100;
            if (dataGridView.Columns["Image"] == null)
                dataGridView.Columns.Insert(0, img);


        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'managerDataSet1.invoice' table. You can move, or remove it, as needed.
            this.invoiceTableAdapter1.Fill(this.managerDataSet1.invoice);
            // TODO: This line of code loads data into the 'managerDataSet1.inv_detail' table. You can move, or remove it, as needed.
            this.inv_detailTableAdapter1.Fill(this.managerDataSet1.inv_detail);
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
            amagarIDs();
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
        private void formClient_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.costumersTableAdapter.FillByFilter(this.managerDataSet.customers,  txtBNomClient.Text, "%" +  txtBNomClient.Text + "%",
             txtBCognomsClient.Text, "%" + txtBCognomsClient.Text + "%", txtBTelefonClient.Text, "%" + txtBTelefonClient.Text + "%");
            this.customersTableAdapter2.FillByFilter2(this.mANAGERDataSetNou.customers, txtBNomClient2.Text, txtBCognomsClient2.Text, txtBTelefonClient2.Text, "%" + txtBCognomsClient2.Text + "%",
             "%" + txtBNomClient2.Text + "%", "%" + txtBTelefonClient2.Text + "%");

        }
        private void btAfegirClient_Click(object sender, EventArgs e)
        {
            FormAfegirClient formAfegirClient = new FormAfegirClient();

            formAfegirClient.FormClosed += new System.Windows.Forms.FormClosedEventHandler(formClient_FormClosed);

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

       private void btTreure_Click(object sender, EventArgs e)
        {
            var rows = dataGridViewProductesFacturaAfegits.SelectedRows;
            foreach(DataGridViewRow row in rows)
                dataGridViewProductesFacturaAfegits.Rows.RemoveAt(row.Index);
            dataGridViewProductesFacturaAfegits.Refresh();
        }

        private void btAfegir_Click_1(object sender, EventArgs e)
        {
            var rows = dataGridViewProductesFactura.SelectedRows;
            int count = rows.Count;
            DataGridViewRow row;
            if (count > 0)
                for (int i = 0; i < count; i++)
                {
                    int j = 0;
                    row = (DataGridViewRow) rows[i].Clone();
                    foreach (DataGridViewCell cell in rows[i].Cells)
                    {
                        row.Cells[j].Value = cell.Value;
                        Console.WriteLine("Cell Value: " + cell.Value);
                        j++;
                    }
                    dataGridViewProductesFacturaAfegits.Rows.Add(row);
                    dataGridViewProductesFacturaAfegits.Refresh();
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

            int selectedRowCount = dataGridViewCustumers.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                for (int i = 0; i < selectedRowCount; i++)
                {

                    try
                    {

                        string Id = dataGridViewCustumers.SelectedRows[i].Cells[0].Value.ToString();
                        string nom = dataGridViewCustumers.SelectedRows[i].Cells[1].Value.ToString();
                        string cognom1 = dataGridViewCustumers.SelectedRows[i].Cells[2].Value.ToString();
                        string cognom2 = dataGridViewCustumers.SelectedRows[i].Cells[3].Value.ToString();
                        string adress = dataGridViewCustumers.SelectedRows[i].Cells[4].Value.ToString();
                        string codipostal = dataGridViewCustumers.SelectedRows[i].Cells[5].Value.ToString();
                        string ciutat = dataGridViewCustumers.SelectedRows[i].Cells[6].Value.ToString();
                        string provincia = dataGridViewCustumers.SelectedRows[i].Cells[7].Value.ToString();
                        string telefon = dataGridViewCustumers.SelectedRows[i].Cells[8].Value.ToString();
                        string fax = dataGridViewCustumers.SelectedRows[i].Cells[9].Value.ToString();
                        string email = dataGridViewCustumers.SelectedRows[i].Cells[10].Value.ToString();
                       
                        ModificarClientForm formModificar = new ModificarClientForm(Id, nom,cognom1,cognom2,adress,codipostal,ciutat,
                            provincia,telefon,fax,email);
                  
                        formModificar.FormClosed += new System.Windows.Forms.FormClosedEventHandler(formClient_FormClosed);

                        formModificar.Show();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }



                }
            }
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
        private void formProducte_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.productsTableAdapter.FillByFilter(this.managerDataSet.products, txtBNomProducte.Text, "%" + txtBNomProducte.Text + "%");
        }
        private void button6_Click(object sender, EventArgs e)
        {
           AfegirProducteForm formAfegirProducte = new AfegirProducteForm(pathimage);

            formAfegirProducte.FormClosed += new System.Windows.Forms.FormClosedEventHandler(formProducte_FormClosed);

            formAfegirProducte.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {

            int selectedRowCount = dataGridViewProducts.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                for (int i = 0; i < selectedRowCount; i++)
                {

                    try
                    {
                       
                        string Id = dataGridViewProducts.SelectedRows[i].Cells[1].Value.ToString();
                        string Producte = dataGridViewProducts.SelectedRows[i].Cells[2].Value.ToString();
                       string preu= dataGridViewProducts.SelectedRows[i].Cells[3].Value.ToString();
                       string imagepath=  dataGridViewProducts.SelectedRows[i].Cells[4].Value.ToString();
                        ModificarProducteForm formModificar = new ModificarProducteForm(Id,Producte,preu, imagepath);

                        formModificar.FormClosed += new System.Windows.Forms.FormClosedEventHandler(formProducte_FormClosed);

                        formModificar.Show();
                        this.productsTableAdapter.FillByFilter(this.managerDataSet.products, txtBNomProducte.Text, "%" + txtBNomProducte.Text + "%");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }



                }
            }
            }

        private void amagarIDs() { 
             if(dataGridViewCustumers.ColumnCount>0)
                dataGridViewCustumers.Columns[0].Visible = false;
            if (dataGridViewInvoice.ColumnCount > 0)
                dataGridViewInvoice.Columns[0].Visible = false;
            if (dataGridViewProductesFacturaSelect.ColumnCount > 0)
                dataGridViewProductesFacturaSelect.Columns[0].Visible = false;
            if (dataGridViewClientsFactura.ColumnCount > 0)
                dataGridViewClientsFactura.Columns[0].Visible = false;
            if (dataGridViewProductesFactura.ColumnCount > 0)
                dataGridViewProductesFactura.Columns[0].Visible = false;
            if (dataGridViewProductesFacturaAfegits.ColumnCount > 0)
                dataGridViewProductesFacturaAfegits.Columns[0].Visible = false;
        }

        private void dataGridView4_SelectionChanged(object sender, EventArgs e)
        {
            dataGridViewProductesFacturaAfegits.Rows.Clear();
           
        }

        private void btComprar_Click(object sender, EventArgs e)
        {
            int IVA, descompte;
            if (!int.TryParse(tbIVA.Text, out IVA) || !int.TryParse(tbDescompte.Text, out descompte))
            {
                IVA = 21;
                descompte = 0;
            }
            if (dataGridViewClientsFactura.SelectedRows.Count == 0) MessageBox.Show("No s'ha seleccionat cap client.");
            else if (dataGridViewProductesFacturaAfegits.Rows.Count == 0) MessageBox.Show("No s'ha afegit cap producte.");
            else 
            {
            
                DataGridViewRow client = dataGridViewClientsFactura.SelectedRows[0];
                DataGridViewRowCollection productes = dataGridViewProductesFactura.Rows;
                if (invoiceTableAdapter.InsertQuery((int)client.Cells[0].Value, DateTime.Now, descompte, IVA) != 0)
                {
                    int invId = (int)invoiceTableAdapter.MaxIdQuery(),
                        prodId;
                    Console.WriteLine("Inserted invoice #" + invId);
                    Dictionary<int, int> productesDictionary = new Dictionary<int, int>();
                    string strOk = "Inserted producte ID: ", 
                        strErr = "Could not insert producte ID: ";
                    bool ok;
                    foreach (DataGridViewRow producte in productes)
                    {
                        prodId = (int) producte.Cells[0].Value;
                        if (productesDictionary.ContainsKey(prodId))
                            productesDictionary[prodId]++;
                        else productesDictionary.Add(prodId, 1);
                    }
                    foreach (KeyValuePair<int, int> producte in productesDictionary)
                    {
                        ok = inv_detailTableAdapter.InsertQuery(invId, producte.Key, producte.Value) > 0;
                        Console.WriteLine((ok ? strOk : strErr) + producte.Key);
                    }
                    invoiceTableAdapter.Fill(managerDataSet.invoice);
                    dataGridViewInvoice.Refresh();

                }
                else MessageBox.Show("Error al efectuar la compra.");
            }
        }

        private void dataGridViewProducts_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridViewProducts.Columns[e.ColumnIndex].Name == "Image")
            {
                string path = dataGridViewProducts.Rows[e.RowIndex].Cells["IMAGEPATH"].Value.ToString();
                // Your code would go here - below is just the code I used to test
                if (File.Exists(path))
                {
                    Image image = Image.FromFile(path);
                    var newImage = new Bitmap(dataGridViewProducts.Columns[e.ColumnIndex].Width, dataGridViewProducts.Rows[e.RowIndex].Height);
                    Graphics.FromImage(newImage).DrawImage(image, 0, 0, dataGridViewProducts.Columns[e.ColumnIndex].Width, dataGridViewProducts.Rows[e.RowIndex].Height);
                    e.Value = newImage;
                }
            }
        }

        private void dataGridViewProductesFactura_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridViewProductesFactura.Columns[e.ColumnIndex].Name == "Image"&&dataGridViewProductesFactura.Columns["IMAGEPATH"] != null)
            {
                string path = dataGridViewProductesFactura.Rows[e.RowIndex].Cells["IMAGEPATH"].Value.ToString();
                // Your code would go here - below is just the code I used to test
                if (File.Exists(path))
                {
                    Image image = Image.FromFile(path);
                    var newImage = new Bitmap(dataGridViewProductesFactura.Columns[e.ColumnIndex].Width, dataGridViewProductesFactura.Rows[e.RowIndex].Height);
                    Graphics.FromImage(newImage).DrawImage(image, 0, 0, dataGridViewProductesFactura.Columns[e.ColumnIndex].Width, dataGridViewProductesFactura.Rows[e.RowIndex].Height);
                    e.Value = newImage;
                }
                
            }
        }

        private void dataGridViewProductesFacturaAfegits_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            
            if (dataGridViewProductesFacturaAfegits.Columns[e.ColumnIndex].Name == "Image" && dataGridViewProductesFacturaAfegits.Columns["IMAGEPATH"] != null)
            {
                string path = dataGridViewProductesFacturaAfegits.Rows[e.RowIndex].Cells["IMAGEPATH"].Value.ToString();
                // Your code would go here - below is just the code I used to test
                if (File.Exists(path))
                {
                    Image image = Image.FromFile(path);
                    var newImage = new Bitmap(dataGridViewProductesFacturaAfegits.Columns[e.ColumnIndex].Width, dataGridViewProductesFacturaAfegits.Rows[e.RowIndex].Height);
                    Graphics.FromImage(newImage).DrawImage(image, 0, 0, dataGridViewProductesFacturaAfegits.Columns[e.ColumnIndex].Width, dataGridViewProductesFacturaAfegits.Rows[e.RowIndex].Height);
                    e.Value = newImage;
                }
            }
        }

        private void dataGridViewInvoice_RowStateChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewInvoice.SelectedRows.Count > 0)
            {
                DataGridViewRow invoice = dataGridViewInvoice.SelectedRows[0];
                //productsTableAdapter.FillByInvoice(managerDataSet)
            }
        }

        private void splitContainer2_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
