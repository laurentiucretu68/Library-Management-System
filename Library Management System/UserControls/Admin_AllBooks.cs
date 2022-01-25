using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using Library_Management_System.EditForms;

namespace Library_Management_System.UserControls
{
    public partial class Admin_AllBooks : UserControl
    {
        void updateData(String commandString)
        {
            using (OracleConnection connection = new OracleConnection(StartApp.connectionString))
            {
                try
                {
                    connection.Open();
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

                    connection.Close();
                }
                catch (OracleException ex)
                {
                    MessageBox.Show("Eroare(" + ex.ToString() + ")!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Restart();
                }
            }
        }

        public Admin_AllBooks()
        {
            InitializeComponent();
            using (OracleConnection connection = new OracleConnection(StartApp.connectionString))
            {
                try
                {
                    connection.Open();
                    String commandString = String.Format(@"create or replace view books_user_panel as
                                                        select id_carte, titlu, numar_pagini, data_publicare, car.id_editura, 
                                                        nume_editura, car.id_categorie, nume_categorie,
                                                        car.id_furnizor, nume_furnizor
                                                        from carti car left join categorii cat on car.ID_CATEGORIE = cat.ID_CATEGORIE 
                                                        left join edituri edit on car.ID_EDITURA = edit.ID_EDITURA
                                                        left join furnizori fur on car.ID_FURNIZOR = fur.ID_FURNIZOR");

                    var cmd = new OracleCommand(commandString, connection);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    connection.Close();

                    commandString = String.Format(@"select id_carte, titlu, numar_pagini, data_publicare, 
                                                        id_editura, id_categorie, id_furnizor from books_user_panel order by 1");
                    updateData(commandString);
                }
                catch (OracleException ex)
                {
                    MessageBox.Show("Eroare(" + ex.ToString() + ")!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Restart();
                }
            }
        }

        private void searchBook_TextChanged(object sender, EventArgs e)
        {
            String commandString;
            if (!string.IsNullOrEmpty(searchBook.Text.ToString()))
            {
                commandString = String.Format(@"select id_carte, titlu, numar_pagini, data_publicare, 
                                                id_editura, id_categorie, id_furnizor from books_user_panel where trim(lower(titlu)) like '%{0}%'
                                                or trim(lower(nume_editura)) like '%{0}%' 
                                                or trim(lower(nume_categorie)) like '%{0}%' order by 1", searchBook.Text.ToLower().ToString());
            }
            else
            {
                commandString = String.Format(@"select id_carte, titlu, numar_pagini, data_publicare, 
                                                        id_editura, id_categorie, id_furnizor from books_user_panel order by 1");
            }
            updateData(commandString);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddBook form = new AddBook();
            form.ShowDialog();

            if (form.buttonWasClicked)
            {
                String commandString = String.Format(@"select id_carte, titlu, numar_pagini, data_publicare, 
                                                        id_editura, id_categorie, id_furnizor from books_user_panel order by 1");
                updateData(commandString);
            }
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
                            String commandString = String.Format(@"delete from books_user_panel 
                                                    where id_carte='{0}'", continutTab.Rows[e.RowIndex].Cells[2].Value.ToString());
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
                    else
                        continutTab.Rows[e.RowIndex].Cells[4].Value = DBNull.Value;
                    if (DateTime.Parse(form.data_publicare.Value.ToString()) != DateTime.Now)
                        continutTab.Rows[e.RowIndex].Cells[5].Value = form.data_publicare.Value;
                    continutTab.Rows[e.RowIndex].Cells[6].Value = form.id_editura.Text;
                    continutTab.Rows[e.RowIndex].Cells[7].Value = form.id_categorie.Text;
                    if (!string.IsNullOrEmpty(form.id_furnizor.Text.ToString()))
                        continutTab.Rows[e.RowIndex].Cells[8].Value = form.id_furnizor.Text;
                    else
                        continutTab.Rows[e.RowIndex].Cells[8].Value = DBNull.Value;
                }
            }
        }
    }
}
