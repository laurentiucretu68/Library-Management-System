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
using Library_Management_System.AddForms;

namespace Library_Management_System
{
    public partial class AddBook : Form
    {
        public bool buttonWasClicked = false;
        bool draggable;
        int mouseX;
        int mouseY;

        List<String> AddInDrop(String commandString)
        {
            using (OracleConnection connection = new OracleConnection(StartApp.connectionString))
            {
                try
                {
                    connection.Open();
                    var cmd = new OracleCommand(commandString, connection);
                    var dr = cmd.ExecuteReader();
                    dr.Read();

                    List<String> array = new List<String>();
                    while (dr.Read())
                    {
                        array.Add(dr.GetString(0));
                    }

                    connection.Close();
                    cmd.Dispose();
                    dr.Dispose();
                    return array;
                }
                catch (OracleException ex)
                {
                    MessageBox.Show("Eroare(" + ex.ToString() + ")!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Restart();
                }
            }
            return null;
        }
        public AddBook()
        {
            InitializeComponent();
            String commandString = String.Format(@"select nume_editura from edituri order by id_editura");
            edituri.Items = AddInDrop(commandString).ToArray();
            commandString = String.Format(@"select nume_categorie from categorii order by id_categorie");
            categorii.Items = AddInDrop(commandString).ToArray();
            commandString = String.Format(@"select nume_furnizor from furnizori order by id_furnizor");
            furnizori.Items = AddInDrop(commandString).ToArray();
            commandString = String.Format(@"select prenume_autor || ' ' || nume_autor from autori order by prenume_autor");

            String[] array = AddInDrop(commandString).ToArray();
            for (int i=0; i< array.Length; i++)
                autori.Items.Add(array[i], false);

            data_publicare.Value = DateTime.Now;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            draggable = false;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (draggable)
            {
                Top = Cursor.Position.Y - mouseY;
                Left = Cursor.Position.X - mouseX;
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            draggable = true;
            mouseX = Cursor.Position.X - Left;
            mouseY = Cursor.Position.Y - Top;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var form = new AddEditura();
            form.ShowDialog();

            if (form.buttonWasClicked)
            {
                edituri.AddItem(form.nume_editura.Text.ToString());
                edituri.selectedIndex = edituri.Items.Count();
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var form = new AddCategorie();
            form.ShowDialog();

            if (form.buttonWasClicked)
            {
                categorii.AddItem(form.nume_categorie.Text.ToString());
                categorii.selectedIndex = categorii.Items.Count();
            }
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var form = new AddFurnizor();
            form.ShowDialog();

            if (form.buttonWasClicked)
            {
                furnizori.AddItem(form.nume_furnizor.Text.ToString());
                furnizori.selectedIndex = furnizori.Items.Count();
            }
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var form = new AddAutor();
            form.data_nasterii.Value = DateTime.Now;
            form.ShowDialog();

            if (form.buttonWasClicked)
            {
                autori.Items.Add(form.prenume_autor.Text.ToString() + ' ' + form.nume_autor.Text.ToString());
                autori.SelectedIndex = autori.Items.Count;
            }
        }

        private void sign_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(titlu.Text.ToString()) && !string.IsNullOrEmpty(edituri.selectedValue.ToString()) && 
                !string.IsNullOrEmpty(categorii.selectedValue.ToString()) && !string.IsNullOrEmpty(furnizori.selectedValue.ToString()) 
                && autori.SelectedIndex != -1)
            {
                if (data_publicare.Value < DateTime.Now)
                {
                    using (OracleConnection connection = new OracleConnection(StartApp.connectionString))
                    {
                        try
                        {
                            connection.Open();

                            String commandString = String.Format(@"SELECT id_carte FROM carti WHERE ROWNUM = 1 order by id_carte desc");
                            var cmd = new OracleCommand(commandString, connection);
                            var dr = cmd.ExecuteReader();
                            dr.Read();
                            int id_carte = 0;
                            if (dr.HasRows)
                                id_carte = Int32.Parse(dr.GetString(0)) + 1;


                            string numarPagini = null;
                            string dataPublicare = null;
                            if (!string.IsNullOrEmpty(nr_pagini.Text.ToString()))
                                numarPagini = nr_pagini.Text.ToString();
                            if (data_publicare.Value.ToString("dd-MM-yyyy") != DateTime.Now.ToString("dd-MM-yyyy"))
                                dataPublicare = data_publicare.Value.ToString("dd-MM-yyyy");

                            if (dataPublicare != null)
                                commandString = String.Format(@"insert into books_user_panel(id_carte, titlu, data_publicare,
                                                                id_editura, id_categorie, id_furnizor) values(
                                                                    '{0}',
                                                                    '{1}',
                                                                    to_date('{2}', 'dd-mm-yyyy'),
                                                                    (select id_editura from edituri where nume_editura = '{3}'),
                                                                    (select id_categorie from categorii where nume_categorie = '{4}'),
                                                                    (select id_furnizor from furnizori where nume_furnizor = '{5}')
                                                                )", id_carte, titlu.Text.ToString(), dataPublicare, 
                                                                edituri.selectedValue.ToString(),
                                                                categorii.selectedValue.ToString(), furnizori.selectedValue.ToString());
                            else
                                commandString = String.Format(@"insert into books_user_panel(id_carte, titlu, numar_pagini, data_publicare,
                                                                id_editura, id_categorie, id_furnizor) values(
                                                                    '{0}',
                                                                    '{1}',
                                                                    null,
                                                                    (select id_editura from edituri where nume_editura = '{2}'),
                                                                    (select id_categorie from categorii where nume_categorie = '{3}'),
                                                                    (select id_furnizor from furnizori where nume_furnizor = '{4}')
                                                                )", id_carte, titlu.Text.ToString(), edituri.selectedValue.ToString(),
                                                                categorii.selectedValue.ToString(), furnizori.selectedValue.ToString());

                            cmd = new OracleCommand(commandString, connection);
                            cmd.ExecuteNonQuery();

                            if (numarPagini != null)
                            {
                                commandString = String.Format(@"update books_user_panel set numar_pagini='{0}' where id_carte='{1}' ", numarPagini, id_carte);
                                cmd = new OracleCommand(commandString, connection);
                                cmd.ExecuteNonQuery();
                            }

                            for (int x = 0; x < autori.CheckedItems.Count; x++)
                            {
                                string[] autorStrtok = autori.CheckedItems[x].ToString().Split(' ');
                                commandString = String.Format(@"insert into scrie values(
                                                                (select id_autor from autori where prenume_autor = '{0}' and nume_autor = '{1}' and ROWNUM = 1),
                                                                '{2}'
                                                            )", autorStrtok[0], autorStrtok[1], id_carte);
                                cmd = new OracleCommand(commandString, connection);
                                cmd.ExecuteNonQuery();
                            }

                            cmd.Dispose();
                            connection.Close();

                            MessageBox.Show("Carte adaugata cu succes!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            titlu.Text = "";
                            nr_pagini.Text = "";
                            data_publicare.Value = DateTime.Now;
                            edituri.Clear();
                            categorii.Clear();
                            furnizori.Clear();
                            for (int i = 0; i < autori.Items.Count; i++)
                                autori.SetItemChecked(i, false);
                        }
                        catch (OracleException ex)
                        {
                            MessageBox.Show("Eroare(" + ex.ToString() + ")!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Application.Restart();
                        }
                    }
                }
                else
                    MessageBox.Show("Data publicarii aleasa necorespunzator!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Completati toate campurile!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
