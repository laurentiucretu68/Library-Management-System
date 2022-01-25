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

namespace Library_Management_System.UserControls
{
    public partial class User_AllBooks : UserControl
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
        public User_AllBooks()
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
                                                        nume_editura, nume_categorie from books_user_panel order by 1");
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
                                                nume_editura, nume_categorie from books_user_panel where trim(lower(titlu)) like '%{0}%'
                                                or trim(lower(nume_editura)) like '%{0}%' 
                                                or trim(lower(nume_categorie)) like '%{0}%' order by 1", searchBook.Text.ToString());
            }
            else
            {
                commandString = String.Format(@"select id_carte, titlu, numar_pagini, data_publicare, 
                                                        nume_editura, nume_categorie from books_user_panel order by 1");
            }
            updateData(commandString);
        }
    }
}
