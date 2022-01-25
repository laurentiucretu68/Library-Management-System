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
    public partial class Admin_BorrowedBooks : UserControl
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

                    connection.Close();
                }
                catch (OracleException ex)
                {
                    MessageBox.Show("Eroare(" + ex.ToString() + ")!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Restart();
                }
            }
        }

        public Admin_BorrowedBooks()
        {
            InitializeComponent();
            String commandString = String.Format(@"select car.id_carte, titlu, numar_pagini, data_publicare, nume_editura, nume_categorie, 
                                                            nume_furnizor, nume_autor || ' ' || prenume_autor as autor
                                                            from carti car join categorii cat on car.id_categorie = cat.id_categorie
                                                            join edituri ed on car.id_editura=ed.id_editura
                                                            left join furnizori fur on car.id_furnizor = fur.id_furnizor
                                                            join scrie scr on car.id_carte = scr.id_carte
                                                            join autori aut on scr.id_autor = aut.id_autor
                                                            where data_publicare > to_date('31-12-1999', 'dd-mm-yyyy')
                                                            and trim(lower(nume_categorie)) = 'romane'
                                                            order by data_publicare");
            updateData(commandString);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            String commandString;
            if (!string.IsNullOrEmpty(textBox1.Text.ToString()))
            {
                commandString = String.Format(@"select car.id_carte, titlu, numar_pagini, data_publicare, nume_editura, nume_categorie, 
                                                            nume_furnizor, nume_autor || ' ' || prenume_autor as autor
                                                            from carti car join categorii cat on car.id_categorie = cat.id_categorie
                                                            join edituri ed on car.id_editura=ed.id_editura
                                                            left join furnizori fur on car.id_furnizor = fur.id_furnizor
                                                            join scrie scr on car.id_carte = scr.id_carte
                                                            join autori aut on scr.id_autor = aut.id_autor
                                                            where (data_publicare > to_date('31-12-1999', 'dd-mm-yyyy')
                                                            and trim(lower(nume_categorie)) = 'romane')
                                                            and (trim(lower(titlu)) like '%{0}%'
                                                            or trim(lower(nume_editura)) like '%{0}%'
                                                            or trim(lower(nume_furnizor)) like '%{0}%'
                                                            or trim(lower(nume_autor)) like '%{0}%')
                                                            order by data_publicare", textBox1.Text.ToLower().ToString());
            }
            else
            {
                commandString = String.Format(@"select car.id_carte, titlu, numar_pagini, data_publicare, nume_editura, nume_categorie, 
                                                            nume_furnizor, nume_autor || ' ' || prenume_autor as autor
                                                            from carti car join categorii cat on car.id_categorie = cat.id_categorie
                                                            join edituri ed on car.id_editura=ed.id_editura
                                                            left join furnizori fur on car.id_furnizor = fur.id_furnizor
                                                            join scrie scr on car.id_carte = scr.id_carte
                                                            join autori aut on scr.id_autor = aut.id_autor
                                                            where data_publicare > to_date('31-12-1999', 'dd-mm-yyyy')
                                                            and trim(lower(nume_categorie)) = 'romane'
                                                            order by data_publicare");
            }
            updateData(commandString);
        }
    }
}
