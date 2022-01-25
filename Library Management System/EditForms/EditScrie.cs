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

namespace Library_Management_System.EditForms
{
    public partial class EditScrie : Form
    {
        public bool buttonWasClicked = false;
        string idAutorInitial, idCarteInitial;
        bool draggable;
        int mouseX;
        int mouseY;
        public EditScrie()
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

        private void EditScrie_Load(object sender, EventArgs e)
        {
            idAutorInitial = id_autor.Text.ToString();
            idCarteInitial = id_carte.Text.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(id_autor.Text.ToString()) && !string.IsNullOrEmpty(id_carte.Text.ToString()))
            {
                using (OracleConnection connection = new OracleConnection(StartApp.connectionString))
                {
                    try
                    {
                        connection.Open();

                        String commandString = String.Format(@"select id_autor from autori where id_autor='{0}'", id_autor.Text.ToString());
                        var cmd = new OracleCommand(commandString, connection);
                        var dr = cmd.ExecuteReader();
                        dr.Read();
                        if (!dr.HasRows)
                        {
                            MessageBox.Show("Autorul cu acest id nu exista in baza de date!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            commandString = String.Format(@"select id_carte from carti where id_carte='{0}'", id_carte.Text.ToString());
                            cmd = new OracleCommand(commandString, connection);
                            dr = cmd.ExecuteReader();
                            dr.Read();
                            if (!dr.HasRows)
                            {
                                MessageBox.Show("Cartea cu acest id nu exista in baza de date!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                commandString = String.Format(@"select *from scrie where id_autor='{0}' and id_carte='{1}'", id_autor.Text.ToString(), id_carte.Text.ToString());
                                cmd = new OracleCommand(commandString, connection);
                                dr = cmd.ExecuteReader();
                                dr.Read();
                                if (dr.HasRows && idAutorInitial!=dr.GetString(0) && idCarteInitial!=dr.GetString(1))
                                {
                                    MessageBox.Show("Autorul deja a scris aceasta carte!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else
                                {
                                    commandString = String.Format(@"update scrie set id_autor='{0}', id_carte='{1}' where id_autor='{2}' and id_carte='{3}'", id_autor.Text.ToString(), id_carte.Text.ToString(), idAutorInitial, idCarteInitial);
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
                MessageBox.Show("Completati ambele campuri!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
