using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using Library_Management_System.EditForms;

namespace Library_Management_System.UserControls
{
    public partial class Admin_Users : UserControl
    {
        public Admin_Users()
        {
            InitializeComponent();
            using (OracleConnection connection = new OracleConnection(StartApp.connectionString))
            {
                try
                {
                    connection.Open();
                    String commandString = "SELECT table_name FROM user_tables order by 1";
                    var cmd = new OracleCommand(commandString, connection);
                    var dr = cmd.ExecuteReader();
                    dr.Read();
                    comboTabele.Items.Add("AUTORI");
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                            comboTabele.Items.Add(dr.GetString(0));
                    }
                    comboTabele.SelectedItem = "AUTORI";

                    cmd.Dispose();
                    dr.Dispose();
                    connection.Close();
                }
                catch (OracleException ex)
                {
                    MessageBox.Show("Eroare(" + ex.ToString() + ")!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Restart();
                }
            }
        }

        private void comboTabele_SelectedValueChanged(object sender, EventArgs e)
        {
            using (OracleConnection connection = new OracleConnection(StartApp.connectionString))
            {
                try
                {
                    connection.Open();
                    sorteaza.SelectedItem = "Crescator dupa id";

                    string tableName = comboTabele.SelectedItem.ToString();
                    if (tableName.ToLower() == "scrie" || tableName.ToLower() == "recenzie" || tableName.ToLower() == "imprumuta")
                    {
                        var tipuriSortari = new[]
                        {
                            "Crescator dupa id",
                            "Descrescator dupa id"
                        };
                        sorteaza.DataSource = null;
                        sorteaza.DataSource = tipuriSortari;
                    }
                    else
                    {
                        var tipuriSortari = new[]
                        {
                            "Crescator dupa id",
                            "Descrescator dupa id",
                            "Crescator dupa nume",
                            "Descrescator dupa nume"
                        };
                        sorteaza.DataSource = null;
                        sorteaza.DataSource = tipuriSortari;
                    }
                    if (sorteaza.SelectedIndex != -1)
                        sorteaza.SelectedItem = "Crescator dupa id";


                    String commandString = String.Format(@"select *from {0}", tableName);
                    OracleDataAdapter datAd = new OracleDataAdapter(commandString, connection);
                    DataTable dt = new DataTable();
                    datAd.Fill(dt);
                    continutTab.DataSource = dt;

                    DataGridViewButtonColumn editButton = new DataGridViewButtonColumn();
                    editButton.Name = "Editare";
                    editButton.Text = "Edit";
                    editButton.UseColumnTextForButtonValue = true;
                    editButton.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    editButton.FlatStyle = FlatStyle.Standard;
                    editButton.CellTemplate.Style.BackColor = Color.Honeydew;

                    int columnIndex = 0;
                    if (continutTab.Columns["Editare"] == null)
                        continutTab.Columns.Insert(columnIndex, editButton);

                    DataGridViewButtonColumn deleteButton = new DataGridViewButtonColumn();
                    deleteButton.Name = "Stergere";
                    deleteButton.Text = "Delete";
                    deleteButton.UseColumnTextForButtonValue = true;
                    deleteButton.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    deleteButton.FlatStyle = FlatStyle.Standard;
                    deleteButton.CellTemplate.Style.BackColor = Color.Honeydew;

                    columnIndex = 1;
                    if (continutTab.Columns["Stergere"] == null)
                        continutTab.Columns.Insert(columnIndex, deleteButton);

                    continutTab.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                    continutTab.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                    datAd.Dispose();
                    dt.Dispose();
                    connection.Close();
                }
                catch (OracleException ex)
                {
                    MessageBox.Show("Eroare(" + ex.ToString() + ")!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Restart();
                }
            }
        }

        private void sorteaza_SelectedValueChanged(object sender, EventArgs e)
        {
            if (continutTab.Rows.Count > 0 && sorteaza.SelectedIndex != -1)
            {
                string sortMode = sorteaza.SelectedItem.ToString();
                if (sortMode == "Crescator dupa id")
                    continutTab.Sort(continutTab.Columns[2], ListSortDirection.Ascending);
                if (sortMode == "Descrescator dupa id")
                    continutTab.Sort(continutTab.Columns[2], ListSortDirection.Descending);
                if (sortMode == "Crescator dupa nume")
                    continutTab.Sort(continutTab.Columns[3], ListSortDirection.Ascending);
                if (sortMode == "Descrescator dupa nume")
                    continutTab.Sort(continutTab.Columns[3], ListSortDirection.Descending);
            }
        }

        private void continutTabele_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void continutTab_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (e.ColumnIndex == 1)
            {
                var r = MessageBox.Show("Sunteti sigur ca doriti sa stergeti inregistrarea?", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (r == DialogResult.Yes)
                {
                    using (OracleConnection connection = new OracleConnection(StartApp.connectionString))
                    {
                        try
                        {
                            connection.Open();

                            string tableName = comboTabele.SelectedItem.ToString();
                            string idName = null;
                            if (comboTabele.SelectedItem.ToString().ToLower() == "autori")
                                idName = "id_autor";
                            if (comboTabele.SelectedItem.ToString().ToLower() == "carti")
                                idName = "id_carte";
                            if (comboTabele.SelectedItem.ToString().ToLower() == "categorii")
                                idName = "id_categorie";
                            if (comboTabele.SelectedItem.ToString().ToLower() == "cititori")
                                idName = "id_cititor";
                            if (comboTabele.SelectedItem.ToString().ToLower() == "edituri")
                                idName = "id_editura";
                            if (comboTabele.SelectedItem.ToString().ToLower() == "furnizori")
                                idName = "id_furnizor";
                            if (comboTabele.SelectedItem.ToString().ToLower() == "imprumuta")
                                idName = "id_imprumut";
                            if (comboTabele.SelectedItem.ToString().ToLower() == "recenzie")
                                idName = "id_recenzie";
                            if (comboTabele.SelectedItem.ToString().ToLower() == "recenzori")
                                idName = "id_recenzor";

                            String commandString;
                            if (comboTabele.SelectedItem.ToString().ToLower() == "scrie")
                            {
                                commandString = String.Format(@"delete from {0} where id_autor={1} and id_carte={2}", tableName, continutTab.Rows[e.RowIndex].Cells[2].Value.ToString(), continutTab.Rows[e.RowIndex].Cells[3].Value.ToString());
                            }
                            else
                                commandString = String.Format(@"delete from {0} where {1}='{2}'", tableName, idName, continutTab.Rows[e.RowIndex].Cells[2].Value.ToString());


                            OracleCommand cmd = new OracleCommand(commandString, connection);
                            cmd.ExecuteNonQuery();

                            continutTab.Rows.RemoveAt(e.RowIndex);
                            cmd.Dispose();
                            connection.Close();
                        }
                        catch (OracleException ex)
                        {
                            MessageBox.Show("Eroare(" + ex.ToString() + ")!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Application.Restart();
                        }
                    }
                }
            }

            if (e.ColumnIndex == 0)
            {
                if (comboTabele.SelectedItem.ToString().ToLower() == "autori")
                {
                    string idAutor = continutTab.Rows[e.RowIndex].Cells[2].Value.ToString();
                    string numeAutor = continutTab.Rows[e.RowIndex].Cells[3].Value.ToString();
                    string prenumeAutor = continutTab.Rows[e.RowIndex].Cells[4].Value.ToString();
                    DateTime dataAutor = DateTime.Now;
                    if (continutTab.Rows[e.RowIndex].Cells[5].Value.ToString() != "")
                        dataAutor = DateTime.Parse(continutTab.Rows[e.RowIndex].Cells[5].Value.ToString());


                    EditAutori form = new EditAutori();
                    form.titleTop.Text = "Editare autor - " + numeAutor + " " + prenumeAutor;
                    form.id_autor.Text = idAutor;
                    form.nume_autor.Text = numeAutor;
                    form.prenume_autor.Text = prenumeAutor;
                    form.data_nasterii.Value = dataAutor;
                    form.ShowDialog();

                    if (form.buttonWasClicked)
                    {
                        continutTab.Rows[e.RowIndex].Cells[3].Value = form.nume_autor.Text.ToLower();
                        continutTab.Rows[e.RowIndex].Cells[4].Value = form.prenume_autor.Text.ToLower();
                        if (DateTime.Parse(form.data_nasterii.Value.ToString()) != DateTime.Now)
                            continutTab.Rows[e.RowIndex].Cells[5].Value = form.data_nasterii.Value;
                    }
                }

                if (comboTabele.SelectedItem.ToString().ToLower() == "cititori")
                {
                    string idCititor = continutTab.Rows[e.RowIndex].Cells[2].Value.ToString();
                    string numeCititor = continutTab.Rows[e.RowIndex].Cells[3].Value.ToString();
                    string prenumeCititor = continutTab.Rows[e.RowIndex].Cells[4].Value.ToString();
                    string telefonCititor = continutTab.Rows[e.RowIndex].Cells[5].Value.ToString();
                    string emailCititor = continutTab.Rows[e.RowIndex].Cells[6].Value.ToString();
                    DateTime dataCititor = DateTime.Parse(continutTab.Rows[e.RowIndex].Cells[7].Value.ToString());

                    EditCititori form = new EditCititori();
                    form.titleTop.Text = "Editare cititor - " + numeCititor + " " + prenumeCititor;
                    form.id_cititor.Text = idCititor;
                    form.nume_cititor.Text = numeCititor;
                    form.prenume_cititor.Text = prenumeCititor;
                    form.data_nasterii.Value = dataCititor;
                    form.telefon_cititor.Text = telefonCititor;
                    form.email_cititor.Text = emailCititor;
                    form.ShowDialog();

                    if (form.buttonWasClicked)
                    {
                        continutTab.Rows[e.RowIndex].Cells[3].Value = form.nume_cititor.Text.ToLower();
                        continutTab.Rows[e.RowIndex].Cells[4].Value = form.prenume_cititor.Text.ToLower();
                        continutTab.Rows[e.RowIndex].Cells[5].Value = form.telefon_cititor.Text.ToLower();
                        if (!string.IsNullOrEmpty(form.email_cititor.Text.ToString()))
                            continutTab.Rows[e.RowIndex].Cells[6].Value = form.email_cititor.Text.ToLower();
                        continutTab.Rows[e.RowIndex].Cells[7].Value = form.data_nasterii.Text;
                    }
                }

                if (comboTabele.SelectedItem.ToString().ToLower() == "recenzori")
                {
                    string idRecenzor = continutTab.Rows[e.RowIndex].Cells[2].Value.ToString();
                    string numeRecenzor = continutTab.Rows[e.RowIndex].Cells[3].Value.ToString();
                    string prenumeRecenzor = continutTab.Rows[e.RowIndex].Cells[4].Value.ToString();
                    string emailRecenzor = continutTab.Rows[e.RowIndex].Cells[5].Value.ToString();

                    EditRecenzori form = new EditRecenzori();
                    form.titleTop.Text = "Editare recenzor - " + numeRecenzor + " " + prenumeRecenzor;
                    form.id_recenzor.Text = idRecenzor;
                    form.nume_recenzor.Text = numeRecenzor;
                    form.prenume_recenzor.Text = prenumeRecenzor;
                    form.email_recenzor.Text = emailRecenzor;
                    form.ShowDialog();

                    if (form.buttonWasClicked)
                    {
                        continutTab.Rows[e.RowIndex].Cells[3].Value = form.nume_recenzor.Text.ToLower();
                        continutTab.Rows[e.RowIndex].Cells[4].Value = form.prenume_recenzor.Text.ToLower();
                        if (!string.IsNullOrEmpty(form.email_recenzor.Text.ToString()))
                            continutTab.Rows[e.RowIndex].Cells[5].Value = form.email_recenzor.Text.ToLower();
                    }
                }

                if (comboTabele.SelectedItem.ToString().ToLower() == "furnizori")
                {
                    string idFurnizor = continutTab.Rows[e.RowIndex].Cells[2].Value.ToString();
                    string numeFurnizor = continutTab.Rows[e.RowIndex].Cells[3].Value.ToString();
                    string telefonFurnizor = continutTab.Rows[e.RowIndex].Cells[4].Value.ToString();
                    string emailFurnizor = continutTab.Rows[e.RowIndex].Cells[5].Value.ToString();

                    EditFurnizori form = new EditFurnizori();
                    form.titleTop.Text = "Editare furnizor - " + numeFurnizor;
                    form.id_furnizor.Text = idFurnizor;
                    form.nume_furnizor.Text = numeFurnizor;
                    form.telefon_furnizor.Text = telefonFurnizor;
                    form.email_furnizor.Text = emailFurnizor;
                    form.ShowDialog();

                    if (form.buttonWasClicked)
                    {
                        continutTab.Rows[e.RowIndex].Cells[3].Value = form.nume_furnizor.Text.ToLower();
                        continutTab.Rows[e.RowIndex].Cells[4].Value = form.telefon_furnizor.Text;
                        continutTab.Rows[e.RowIndex].Cells[5].Value = form.email_furnizor.Text.ToLower();
                    }
                }

                if (comboTabele.SelectedItem.ToString().ToLower() == "categorii")
                {
                    string idCategorie = continutTab.Rows[e.RowIndex].Cells[2].Value.ToString();
                    string numeCategorie = continutTab.Rows[e.RowIndex].Cells[3].Value.ToString();
                    string varstaCategorie = continutTab.Rows[e.RowIndex].Cells[4].Value.ToString();

                    EditCategorii form = new EditCategorii();
                    form.titleTop.Text = "Editare categorie - " + numeCategorie;
                    form.id_categorie.Text = idCategorie;
                    form.nume_categorie.Text = numeCategorie;
                    form.varsta_categorie.Text = varstaCategorie;
                    form.ShowDialog();

                    if (form.buttonWasClicked)
                    {
                        continutTab.Rows[e.RowIndex].Cells[3].Value = form.nume_categorie.Text.ToLower();
                        if (!string.IsNullOrEmpty(form.varsta_categorie.Text.ToString()))
                            continutTab.Rows[e.RowIndex].Cells[4].Value = form.varsta_categorie.Text.ToLower();
                    }
                }

                if (comboTabele.SelectedItem.ToString().ToLower() == "edituri")
                {
                    string idEditura = continutTab.Rows[e.RowIndex].Cells[2].Value.ToString();
                    string numeEditura = continutTab.Rows[e.RowIndex].Cells[3].Value.ToString();
                    string emailEditura = continutTab.Rows[e.RowIndex].Cells[4].Value.ToString();

                    EditEdituri form = new EditEdituri();
                    form.titleTop.Text = "Editare editura - " + numeEditura;
                    form.id_editura.Text = idEditura;
                    form.nume_editura.Text = numeEditura;
                    form.email_editura.Text = emailEditura;
                    form.ShowDialog();

                    if (form.buttonWasClicked)
                    {
                        continutTab.Rows[e.RowIndex].Cells[3].Value = form.nume_editura.Text.ToLower();
                        continutTab.Rows[e.RowIndex].Cells[4].Value = form.email_editura.Text.ToLower();
                    }
                }

                if (comboTabele.SelectedItem.ToString().ToLower() == "carti")
                {
                    string idCarte = continutTab.Rows[e.RowIndex].Cells[2].Value.ToString();
                    string titluCarte = continutTab.Rows[e.RowIndex].Cells[3].Value.ToString();
                    string numarPagini = continutTab.Rows[e.RowIndex].Cells[4].Value.ToString();
                    DateTime dataPublicare = DateTime.Now;
                    if (continutTab.Rows[e.RowIndex].Cells[5].Value.ToString() != "")
                        dataPublicare = DateTime.Parse(continutTab.Rows[e.RowIndex].Cells[5].Value.ToString());
                    string idEditura = continutTab.Rows[e.RowIndex].Cells[6].Value.ToString();
                    string idCategorie = continutTab.Rows[e.RowIndex].Cells[7].Value.ToString();
                    string idFurnizor = continutTab.Rows[e.RowIndex].Cells[8].Value.ToString();


                    EditCarti form = new EditCarti();
                    form.titleTop.Text = "Editare carte - " + titluCarte;
                    form.id_carte.Text = idCarte;
                    form.titlu_carte.Text = titluCarte;
                    form.nr_pagini.Text = numarPagini;
                    form.id_editura.Text = idEditura;
                    form.id_categorie.Text = idCategorie;
                    form.id_furnizor.Text = idFurnizor;
                    form.data_publicare.Value = dataPublicare;


                    form.ShowDialog();

                    if (form.buttonWasClicked)
                    {
                        continutTab.Rows[e.RowIndex].Cells[3].Value = form.titlu_carte.Text.ToLower();
                        if (!string.IsNullOrEmpty(form.nr_pagini.Text.ToString()))
                            continutTab.Rows[e.RowIndex].Cells[4].Value = form.nr_pagini.Text;
                        if (DateTime.Parse(form.data_publicare.Value.ToString()) != DateTime.Now)
                            continutTab.Rows[e.RowIndex].Cells[5].Value = form.data_publicare.Value;
                        continutTab.Rows[e.RowIndex].Cells[6].Value = form.id_editura.Text;
                        continutTab.Rows[e.RowIndex].Cells[7].Value = form.id_categorie.Text;
                        if (!string.IsNullOrEmpty(form.id_furnizor.Text.ToString()))
                            continutTab.Rows[e.RowIndex].Cells[8].Value = form.id_furnizor.Text;
                    }
                }

                if (comboTabele.SelectedItem.ToString().ToLower() == "imprumuta")
                {
                    string idImprumut = continutTab.Rows[e.RowIndex].Cells[2].Value.ToString();
                    string idCititor = continutTab.Rows[e.RowIndex].Cells[3].Value.ToString();
                    string idCarte = continutTab.Rows[e.RowIndex].Cells[4].Value.ToString();
                    DateTime dataImprumut = DateTime.Parse(continutTab.Rows[e.RowIndex].Cells[5].Value.ToString());
                    DateTime dataReturnare = DateTime.Parse("01-01-1900");
                    if (!string.IsNullOrEmpty(continutTab.Rows[e.RowIndex].Cells[6].Value.ToString()))
                        dataReturnare = DateTime.Parse(continutTab.Rows[e.RowIndex].Cells[6].Value.ToString());


                    EditImprumut form = new EditImprumut();
                    form.titleTop.Text = "Editare imprumut id " + idImprumut;
                    form.id_imrpumut.Text = idImprumut;
                    form.id_cititor.Text = idCititor;
                    form.id_carte.Text = idCarte;
                    form.data_imprumut.Value = dataImprumut;
                    form.data_returnare.Value = dataReturnare;

                    form.ShowDialog();

                    if (form.buttonWasClicked)
                    {
                        continutTab.Rows[e.RowIndex].Cells[3].Value = form.id_cititor.Text;
                        continutTab.Rows[e.RowIndex].Cells[4].Value = form.id_carte.Text;
                        continutTab.Rows[e.RowIndex].Cells[5].Value = form.data_imprumut.Value;
                        if (form.data_returnare.Value.ToString("dd-MM-yyyy") != "01-01-1900")
                            continutTab.Rows[e.RowIndex].Cells[6].Value = form.data_returnare.Value;
                    }
                }

                if (comboTabele.SelectedItem.ToString().ToLower() == "recenzie")
                {
                    string idRecenzie = continutTab.Rows[e.RowIndex].Cells[2].Value.ToString();
                    string idRecenzor = continutTab.Rows[e.RowIndex].Cells[3].Value.ToString();
                    string idCarte = continutTab.Rows[e.RowIndex].Cells[4].Value.ToString();
                    DateTime dataRecenzie = DateTime.Parse(continutTab.Rows[e.RowIndex].Cells[5].Value.ToString());
                    string notaRecenzie = continutTab.Rows[e.RowIndex].Cells[6].Value.ToString();



                    EditRecenzie form = new EditRecenzie();
                    form.titleTop.Text = "Editare recenzie id " + idRecenzie;
                    form.id_recenzie.Text = idRecenzie;
                    form.id_recenzor.Text = idRecenzor;
                    form.id_carte.Text = idCarte;
                    form.nota_recenzie.Text = notaRecenzie;
                    form.data_recenzie.Value = dataRecenzie;

                    form.ShowDialog();

                    if (form.buttonWasClicked)
                    {
                        continutTab.Rows[e.RowIndex].Cells[3].Value = form.id_recenzor.Text;
                        continutTab.Rows[e.RowIndex].Cells[4].Value = form.id_carte.Text;
                        continutTab.Rows[e.RowIndex].Cells[5].Value = form.data_recenzie.Value;
                        continutTab.Rows[e.RowIndex].Cells[6].Value = form.nota_recenzie.Text;
                    }
                }

                if (comboTabele.SelectedItem.ToString().ToLower() == "scrie")
                {
                    string idAutor = continutTab.Rows[e.RowIndex].Cells[2].Value.ToString();
                    string idCarte = continutTab.Rows[e.RowIndex].Cells[3].Value.ToString();

                    EditScrie form = new EditScrie();
                    form.titleTop.Text = "Editare scriere carte";
                    form.id_autor.Text = idAutor;
                    form.id_carte.Text = idCarte;

                    form.ShowDialog();

                    if (form.buttonWasClicked)
                    {
                        continutTab.Rows[e.RowIndex].Cells[2].Value = form.id_autor.Text;
                        continutTab.Rows[e.RowIndex].Cells[3].Value = form.id_carte.Text;
                    }
                }
            }
        }
    }
}
