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
            //Primer sinnsereixen les columnes o se'ls hipa mida
            InsertColumns(dataGridViewProducts);
           dataGridViewProductesFactura.Columns["ImageColumn"].Width = 100;
            dataGridViewProductesFactura.RowTemplate.Height = 100;
            dataGridViewProductesFacturaSelect.Columns["ImageColumn2"].Width = 100;
            dataGridViewProductesFacturaSelect.RowTemplate.Height = 100;

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
     

            try
            {

            //FEnt us de la sentència try catch s'inicialitzen les taules
                this.inv_detailTableAdapter1.Fill(this.managerDataSet1.inv_detail);
                managerDataSet.EnforceConstraints = false;
                managerDataSet1.EnforceConstraints = false;
                mANAGERDataSetNou.EnforceConstraints = false;
                // TODO: This line of code loads data into the 'mANAGERDataSetNou.customers' table. You can move, or remove it, as needed.
                this.customersTableAdapter2.FillByFilter2(this.mANAGERDataSetNou.customers, txtBNomClient2.Text, txtBCognomsClient2.Text, txtBTelefonClient2.Text, "%" + txtBCognomsClient2.Text + "%",
                 "%" + txtBNomClient2.Text + "%", "%" + txtBTelefonClient2.Text + "%");
                // TODO: This line of code loads data into the 'mANAGERDataSetNou.products' table. You can move, or remove it, as needed.
                this.productsTableAdapter2.FillByFilter(this.mANAGERDataSetNou.products, txtBNomProducte2.Text, "%" + txtBNomProducte2.Text + "%");
                // TODO: This line of code loads data into the 'managerDataSet1.invoice' table. You can move, or remove it, as needed.
                this.invoiceTableAdapter3.Fill(this.managerDataSet.invoice);
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
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void btEliminar_Click(object sender, EventArgs e)
        {

        //En cas de clicar la tecla eliminar a productes hi hagi més d'una fila seleccionada s'eliminen cadascun dels registres.
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

                        /// s'agafa el id del producte i s'elimina amb Entity Framework
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
        //En cas que una finestra del clien es tanqui s'actualitza la taula ja sigui despres de inserir o de modificar.
            this.costumersTableAdapter.FillByFilter(this.managerDataSet.customers,  txtBNomClient.Text, "%" +  txtBNomClient.Text + "%",
             txtBCognomsClient.Text, "%" + txtBCognomsClient.Text + "%", txtBTelefonClient.Text, "%" + txtBTelefonClient.Text + "%");
            this.customersTableAdapter2.FillByFilter2(this.mANAGERDataSetNou.customers, txtBNomClient2.Text, txtBCognomsClient2.Text, txtBTelefonClient2.Text, "%" + txtBCognomsClient2.Text + "%",
             "%" + txtBNomClient2.Text + "%", "%" + txtBTelefonClient2.Text + "%");

        }
        private void btAfegirClient_Click(object sender, EventArgs e)
        {

        //S'obre el formulari de afegir client.
            FormAfegirClient formAfegirClient = new FormAfegirClient();

            formAfegirClient.FormClosed += new System.Windows.Forms.FormClosedEventHandler(formClient_FormClosed);

            formAfegirClient.Show();
        }

        private void fillToolStripButton_Click(object sender, EventArgs e)
        {

        //s'omple la taula clients
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
        //En cas que el nom del clien canvi es torna a fer una cerca
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
        //en cas que els cognoms canviin es torna a fer la cerca
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
        //En cas que la ciutat canvii es torna a fer la cerca
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
                //Si es vol eliminar un client en cas que hi hagi una fila o mes seleccionada es pregunta.
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
                    //utilitzem try catch cada cop que volem eliminar un registre
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
        //En cas que el nom del producte canvii fem una nova cerca
        private void txtBNomProducte_TextChanged(object sender, EventArgs e)
        {
            this.productsTableAdapter.FillByFilter(this.managerDataSet.products, txtBNomProducte.Text, "%" + txtBNomProducte.Text + "%");
        }
        //Aquest botó és el botó per treure de la llista de productes comprats
        // Les files seleccionsades s'esborren
       private void btTreure_Click(object sender, EventArgs e)
        {
            var rows = dataGridViewProductesFacturaAfegits.SelectedRows;
            foreach(DataGridViewRow row in rows)
                dataGridViewProductesFacturaAfegits.Rows.RemoveAt(row.Index);
            dataGridViewProductesFacturaAfegits.Refresh();
        }
        //Aquest botó és el botó de afegir files
        // Es copien totes i cadacuna de les caselles de cada fila seleccionada
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
        //en cas que el nom del camp d cerca 2 canvii es torna a fer una cerca
        private void txtBNomProducte2_TextChanged(object sender, EventArgs e)
        {
            this.productsTableAdapter2.FillByFilter(this.mANAGERDataSetNou.products, txtBNomProducte2.Text, "%" + txtBNomProducte2.Text + "%");
        }

        private void mainTabs_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        //En cas que volguem fer una modificació d'un client es passa com a parametre el que hi ha i s'envia al formulari de modificació
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
            //En cas que es canvii el nom del client es fa una nova cerca
        private void txtBNomClient2_TextChanged(object sender, EventArgs e)
        {
            this.customersTableAdapter2.FillByFilter2(this.mANAGERDataSetNou.customers, txtBNomClient2.Text, txtBCognomsClient2.Text, txtBTelefonClient2.Text, "%" + txtBCognomsClient2.Text + "%",
             "%" + txtBNomClient2.Text + "%",     "%" + txtBTelefonClient2.Text + "%");
        }
        //idem amb els cognoms
        private void txtBCognomsClient2_TextChanged(object sender, EventArgs e)
        {
            this.customersTableAdapter2.FillByFilter2(this.mANAGERDataSetNou.customers, txtBNomClient2.Text, txtBCognomsClient2.Text, txtBTelefonClient2.Text, "%" + txtBCognomsClient2.Text + "%",
              "%" + txtBNomClient2.Text + "%", "%" + txtBTelefonClient2.Text + "%");
        }
        //idem amb el telefon
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
            this.productsTableAdapter2.FillByFilter(this.mANAGERDataSetNou.products, txtBNomProducte2.Text, "%" + txtBNomProducte2.Text + "%");


        }
        //En cas que volguem afegir un no producte s'obre el formulari del nou producte
        private void button6_Click(object sender, EventArgs e)
        {
           AfegirProducteForm formAfegirProducte = new AfegirProducteForm(pathimage);

            formAfegirProducte.FormClosed += new System.Windows.Forms.FormClosedEventHandler(formProducte_FormClosed);

            formAfegirProducte.Show();
        }
        //Aquest botó és el de Modificar producte.
        private void button7_Click(object sender, EventArgs e)
        {

            int selectedRowCount = dataGridViewProducts.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                for (int i = 0; i < selectedRowCount; i++)
                {

                    try
                    {

                    //Per cadascun dels items seleccionats s'obre una finestra de modificació i es passa com a parametre la informació que hi ha
                       
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
            //Aquest mètode serveix per amagar les ids dels datagridview
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
        //Al comprar  es passen totes les dades seleccionades a factura sempre que hi hagi un client seleccionat i productes afegits.
        private void btComprar_Click(object sender, EventArgs e)
        {
            int IVA, descompte;
            IVA =(int) numericUpDownIVA.Value; descompte = (int)numericUpDownDescompte.Value;
            if (dataGridViewClientsFactura.SelectedRows.Count == 0) MessageBox.Show("No s'ha seleccionat cap client.");
            else if (dataGridViewProductesFacturaAfegits.Rows.Count == 0) MessageBox.Show("No s'ha afegit cap producte.");
            else 
            {
            //Prmer s'insereix una nova factura
                DataGridViewRow client = dataGridViewClientsFactura.SelectedRows[0];
                DataGridViewRowCollection productes = dataGridViewProductesFacturaAfegits.Rows;
                if (invoiceTableAdapter3.InsertQuery((int)client.Cells[0].Value, DateTime.Now, descompte, IVA) != 0)
                {
                //despres s'agafa l'ultima id
                    int invId = (int)invoiceTableAdapter3.MaxIdQuery(),
                        prodId;
                    Console.WriteLine("Inserted invoice #" + invId);
                    Dictionary<int, int> productesDictionary = new Dictionary<int, int>();
                    string strOk = "Inserted producte ID: ", 
                        strErr = "Could not insert producte ID: ";
                    bool ok;
                    //Safageixen les ids det tots els productes afegits
                    //es comença amb un diccionari inicialitzat a 1 i després se li va sumant 1
                    foreach (DataGridViewRow producte in productes)
                    {
                        prodId = (int) producte.Cells[0].Value;
                        if (productesDictionary.ContainsKey(prodId))
                            productesDictionary[prodId]++;
                        else productesDictionary.Add(prodId, 1);
                    }
                    foreach (KeyValuePair<int, int> producte in productesDictionary)
                    {
                           //S'insereix els productes a factura detall en la última factura feta.
                        ok = inv_detailTableAdapter.InsertQuery(invId, producte.Key, producte.Value) > 0;
                        Console.WriteLine((ok ? strOk : strErr) + producte.Key);
                    }
                    ////s'ompla el datagridview de la factura
                    invoiceTableAdapter3.Fill(managerDataSet.invoice);
                    dataGridViewInvoice.Refresh();
                    MessageBox.Show("Compra efectuada.");
                    //Es buiden els productes dels afegits
                    dataGridViewProductesFacturaAfegits.Rows.Clear();
                }
                else MessageBox.Show("Error al efectuar la compra.");
            }
        }
        //AQUEST ME`TÒDE SERVEIX PER AFEGIR IMATGES A LA CASSELLA DE IMATGES DEL DATAGRIDVIEW
        private void dataGridViewProducts_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridViewProducts.Columns[e.ColumnIndex].Name == "Image")
            {
            //s'agafa la ruta de la imatge de un camp amagat del datagridview
                string path = dataGridViewProducts.Rows[e.RowIndex].Cells["IMAGEPATH"].Value.ToString();

                if (File.Exists(path))
                {
                //S'agafa la imatge i s'escala finalment a la cela se li dóna com a valor la imatge
                    Image image = Image.FromFile(path);
                    var newImage = new Bitmap(dataGridViewProducts.Columns[e.ColumnIndex].Width, dataGridViewProducts.Rows[e.RowIndex].Height);
                    Graphics.FromImage(newImage).DrawImage(image, 0, 0, dataGridViewProducts.Columns[e.ColumnIndex].Width, dataGridViewProducts.Rows[e.RowIndex].Height);
                    e.Value = newImage;
                }
            }
        }
        //AQUEST ME`TÒDE SERVEIX PER AFEGIR IMATGES A LA CASSELLA DE IMATGES DEL DATAGRIDVIEW
        private void dataGridViewProductesFactura_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
             if (dataGridViewProductesFactura.Columns[e.ColumnIndex].Name == "ImageColumn"&&dataGridViewProductesFactura.Columns["IMAGEPATH2"] != null)
            {
                //s'agafa la ruta de la imatge de un camp amagat del datagridview  
                string path = dataGridViewProductesFactura.Rows[e.RowIndex].Cells["IMAGEPATH2"].Value.ToString();
          
                if (File.Exists(path))
                {
                    //S'agafa la imatge i s'escala finalment a la cela se li dóna com a valor la imatge
                    Image image = Image.FromFile(path);
                    var newImage = new Bitmap(dataGridViewProductesFactura.Columns[e.ColumnIndex].Width, dataGridViewProductesFactura.Rows[e.RowIndex].Height);
                    Graphics.FromImage(newImage).DrawImage(image, 0, 0, dataGridViewProductesFactura.Columns[e.ColumnIndex].Width, dataGridViewProductesFactura.Rows[e.RowIndex].Height);
                    e.Value = newImage;
                }
               
            } 
        }
        //AQUEST ME`TÒDE SERVEIX PER AFEGIR IMATGES A LA CASSELLA DE IMATGES DEL DATAGRIDVIEW
        private void dataGridViewProductesFacturaAfegits_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            
            if (dataGridViewProductesFacturaAfegits.Columns[e.ColumnIndex].Name == "ImageColumn" && dataGridViewProductesFacturaAfegits.Columns["IMAGEPATH2"] != null)
            {
                //s'agafa la ruta de la imatge de un camp amagat del datagridview
                string path = dataGridViewProductesFacturaAfegits.Rows[e.RowIndex].Cells["IMAGEPATH2"].Value.ToString();
                
                if (File.Exists(path))
                {
                    //S'agafa la imatge i s'escala finalment a la cela se li dóna com a valor la imatge
                    Image image = Image.FromFile(path);
                    var newImage = new Bitmap(dataGridViewProductesFacturaAfegits.Columns[e.ColumnIndex].Width, dataGridViewProductesFacturaAfegits.Rows[e.RowIndex].Height);
                    Graphics.FromImage(newImage).DrawImage(image, 0, 0, dataGridViewProductesFacturaAfegits.Columns[e.ColumnIndex].Width, dataGridViewProductesFacturaAfegits.Rows[e.RowIndex].Height);
                    e.Value = newImage;
                }
                
            }
        }

        private void dataGridViewInvoice_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
          
        }
        //Al canviar la seleccio de la factura s'ompla de nou el data grid view factura detall amb la nova id   
        private void dataGridViewInvoice_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewInvoice.SelectedRows.Count > 0)
            {
                 DataGridViewRow invoice = dataGridViewInvoice.SelectedRows[0];
               
                 //s'ompla
             productsTableAdapter4.FillByInvoice(managerDataSet1.products, (int)invoice.Cells[0].Value);
                double Import;
                //Es suma l'import
             Double.TryParse((string)productsTableAdapter4.ImportSUMA((int)invoice.Cells[0].Value).ToString(),out Import );
            Import=  Math.Round(Import, 2, MidpointRounding.AwayFromZero);
            //es posa per escrit l'import
                label13.Text = "IMPORT : " + Import+" €";
                 // Es calcula el descompte total
                double Descomptepercent;
                Double.TryParse((string)invoice.Cells["DISCOUNT"].Value.ToString(), out Descomptepercent);
                double descompte = Import * ( Descomptepercent / 100);
                descompte= Math.Round(descompte, 2, MidpointRounding.AwayFromZero);
                //es posa per escrit
                label14.Text = "DESCOMPTE :" + descompte + " €";
                //ES calcula l'iva
                double IVApercent;
                Double.TryParse((string)invoice.Cells["VAT"].Value.ToString(), out IVApercent);
                double IVA = (Import - descompte) * ( IVApercent / 100);
                IVA=  Math.Round(IVA, 2, MidpointRounding.AwayFromZero);
                //Es posa per escrit
                label15.Text = "IVA :" + IVA + " €";
                //Es calcula quan s'ha de pagar
                double Totalapagar = (Import - descompte) + IVA;
               Totalapagar= Math.Round(Totalapagar, 2, MidpointRounding.AwayFromZero);
               //Es poa per escrit
                label16.Text = "TOTAL A PAGAR :" +Totalapagar+ " €";
                
                dataGridViewProductesFacturaSelect.Refresh();
            }
        }

        private void dataGridViewProductesFacturaSelect_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridViewProductesFacturaSelect_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
        //AQUEST ME`TÒDE SERVEIX PER AFEGIR IMATGES A LA CASSELLA DE IMATGES DEL DATAGRIDVIEW
        private void dataGridViewProductesFacturaSelect_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridViewProductesFacturaSelect.Columns[e.ColumnIndex].Name == "ImageColumn2")
            {
                         if (dataGridViewProductesFacturaSelect.Columns["IMAGEPATH3"] != null){
                    //s'agafa la ruta de la imatge de un camp amagat del datagridview   

                    string path = dataGridViewProductesFacturaSelect.Rows[e.RowIndex].Cells["IMAGEPATH3"].Value.ToString();
               
                if (File.Exists(path))
                {
                        //S'agafa la imatge i s'escala finalment a la cela se li dóna com a valor la imatge
                        Image image = Image.FromFile(path);
                    var newImage = new Bitmap(dataGridViewProductesFacturaSelect.Columns[e.ColumnIndex].Width, dataGridViewProductesFacturaSelect.Rows[e.RowIndex].Height);
                    Graphics.FromImage(newImage).DrawImage(image, 0, 0, dataGridViewProductesFacturaSelect.Columns[e.ColumnIndex].Width, dataGridViewProductesFacturaSelect.Rows[e.RowIndex].Height);
                    e.Value = newImage;
                }
            }
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }
    }
}
