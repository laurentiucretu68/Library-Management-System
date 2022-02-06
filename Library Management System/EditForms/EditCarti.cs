using System;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace Library_Management_System.EditForms
{
    public partial class EditCarti : Form
    {
        public bool buttonWasClicked = false;
        bool draggable;
        int mouseX;
        int mouseY;
        public EditCarti()
        {
            InitializeComponent();
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(titlu_carte.Text.ToString()) && !string.IsNullOrEmpty(id_categorie.Text.ToString()) && !string.IsNullOrEmpty(id_editura.Text.ToString()))
            {
                using (OracleConnection connection = new OracleConnection(StartApp.connectionString))
                {
                    try
                    {
                        connection.Open();

                        String commandString = String.Format(@"select id_categorie from categorii where id_categorie='{0}'", id_categorie.Text.ToString());
                        var cmd = new OracleCommand(commandString, connection);
                        var dr = cmd.ExecuteReader();
                        dr.Read();
                        if (!dr.HasRows)
                        {
                            MessageBox.Show("Id-ul categoriei nu exista in baza de date!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            commandString = String.Format(@"select id_editura from edituri where id_editura='{0}'", id_editura.Text.ToString());
                            cmd = new OracleCommand(commandString, connection);
                            dr = cmd.ExecuteReader();
                            dr.Read();
                            if (!dr.HasRows)
                            {
                                MessageBox.Show("Id-ul editurii nu exista in baza de date!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                if (!string.IsNullOrEmpty(id_furnizor.Text.ToString()))
                                {
                                    commandString = String.Format(@"select id_furnizor from furnizori where id_furnizor='{0}'", id_furnizor.Text.ToString());
                                    cmd = new OracleCommand(commandString, connection);
                                    dr = cmd.ExecuteReader();
                                    dr.Read();
                                    if (!dr.HasRows)
                                    {
                                        MessageBox.Show("Id-ul furnizorului nu exista in baza de date!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                    else
                                    {
                                        String dataPublicare = data_publicare.Value.ToString("dd-MM-yyyy");
                                        if (DateTime.Parse(data_publicare.Value.ToString()).ToString("dd-MM-yyyy") != DateTime.Now.ToString("dd-MM-yyyy"))
                                            commandString = String.Format(@"update books_user_panel set titlu='{0}', data_publicare=to_date('{1}','dd-mm-yyyy'), id_editura={2}, id_categorie={3}, id_furnizor={4} where id_carte='{5}'", titlu_carte.Text.ToString(), dataPublicare, id_editura.Text.ToString(), id_categorie.Text.ToString(), id_furnizor.Text.ToString(), id_carte.Text.ToString());
                                        else
                                            commandString = String.Format(@"update books_user_panel set titlu='{0}', data_publicare=null, id_editura={1}, id_categorie={2}, id_furnizor={3} where id_carte='{4}'", titlu_carte.Text.ToString(), id_editura.Text.ToString(), id_categorie.Text.ToString(), id_furnizor.Text.ToString(), id_carte.Text.ToString());
                                        cmd = new OracleCommand(commandString, connection);
                                        cmd.ExecuteNonQuery();
                                        cmd.Dispose();

                                        if (nr_pagini.Text.ToString() != "")
                                            commandString = String.Format(@"update books_user_panel set numar_pagini='{0}' where id_carte='{1}'", nr_pagini.Text.ToString(), id_carte.Text.ToString());
                                        else
                                            commandString = String.Format(@"update books_user_panel set numar_pagini=null where id_carte='{0}'", id_carte.Text.ToString());
                                        cmd = new OracleCommand(commandString, connection);
                                        cmd.ExecuteNonQuery();
                                        cmd.Dispose();

                                        connection.Close();
                                        buttonWasClicked = true;
                                        MessageBox.Show("Modificare salvata cu succes!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        this.Close();
                                    }
                                }
                                else
                                {
                                    String dataPublicare = data_publicare.Value.ToString("dd-MM-yyyy");
                                    if (DateTime.Parse(data_publicare.Value.ToString()).ToString("dd-MM-yyyy") != DateTime.Now.ToString("dd-MM-yyyy"))
                                        commandString = String.Format(@"update books_user_panel set titlu='{0}', data_publicare=to_date('{1}','dd-mm-yyyy'), 
                                                                id_editura={2}, id_categorie={3}, id_furnizor=null where id_carte='{4}'", 
                                                                titlu_carte.Text.ToString(), dataPublicare, id_editura.Text.ToString(), 
                                                                id_categorie.Text.ToString(), id_carte.Text.ToString());
                                    else
                                        commandString = String.Format(@"update books_user_panel set titlu='{0}', data_publicare=null, id_editura={1}, 
                                                                id_categorie={2}, id_furnizor=null where id_carte='{3}'", titlu_carte.Text.ToString(), 
                                                                id_editura.Text.ToString(), id_categorie.Text.ToString(), id_carte.Text.ToString());
                                    cmd = new OracleCommand(commandString, connection);
                                    cmd.ExecuteNonQuery();
                                    cmd.Dispose();

                                    if (nr_pagini.Text.ToString() != "")
                                        commandString = String.Format(@"update books_user_panel set numar_pagini='{0}' where id_carte='{1}'", nr_pagini.Text.ToString(), id_carte.Text.ToString());
                                    else
                                        commandString = String.Format(@"update books_user_panel set numar_pagini=null where id_carte='{0}'", id_carte.Text.ToString());
                                    cmd = new OracleCommand(commandString, connection);
                                    cmd.ExecuteNonQuery();
                                    cmd.Dispose();

                                    connection.Close();
                                    buttonWasClicked = true;
                                    MessageBox.Show("Modificare salvata cu succes!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.Close();
                                }
                            }
                        }
                    }
                    catch (OracleException ex)
                    {
                        MessageBox.Show("Eroare(" + ex.ToString() + ")!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Application.Restart();
                    }
                }
            }
            else
            {
                MessageBox.Show("Completati toate campurile!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
