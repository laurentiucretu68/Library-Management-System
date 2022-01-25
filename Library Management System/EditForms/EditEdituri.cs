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
    public partial class EditEdituri : Form
    {
        string emailInitial;
        public bool buttonWasClicked = false;
        bool draggable;
        int mouseX;
        int mouseY;
        public EditEdituri()
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

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (draggable)
            {
                Top = Cursor.Position.Y - mouseY;
                Left = Cursor.Position.X - mouseX;
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            draggable = false;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            draggable = true;
            mouseX = Cursor.Position.X - Left;
            mouseY = Cursor.Position.Y - Top;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(nume_editura.Text.ToString()) && !string.IsNullOrEmpty(email_editura.Text.ToString()))
            {
                using (OracleConnection connection = new OracleConnection(StartApp.connectionString))
                {
                    try
                    {
                        connection.Open();

                        String commandString = String.Format(@"select email_editura from edituri where email_editura='{0}'", email_editura.Text.ToString());
                        var cmd = new OracleCommand(commandString, connection);
                        var dr = cmd.ExecuteReader();
                        dr.Read();
                        if (dr.HasRows && dr.GetString(0) != emailInitial)
                        {
                            MessageBox.Show("E-mail deja existent!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            email_editura.Clear();
                        }
                        else
                        {
                            commandString = String.Format(@"update edituri set nume_editura='{0}', email_editura='{1}' where id_editura='{2}'", nume_editura.Text.ToString(), email_editura.Text.ToString(), id_editura.Text.ToString());
                            cmd = new OracleCommand(commandString, connection);
                            cmd.ExecuteNonQuery();

                            cmd.Dispose();
                            connection.Close();
                            buttonWasClicked = true;
                            MessageBox.Show("Modificare salvata cu succes!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
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

        private void EditEdituri_Load(object sender, EventArgs e)
        {
            emailInitial = email_editura.Text.ToString();
        }
    }
}
