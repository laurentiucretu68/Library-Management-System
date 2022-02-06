using System;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace Library_Management_System.EditForms
{
    public partial class EditRecenzori : Form
    {
        public bool buttonWasClicked = false;
        string emailInitial;
        bool draggable;
        int mouseX;
        int mouseY;
        public EditRecenzori()
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
            if (!string.IsNullOrEmpty(nume_recenzor.Text.ToString()) && !string.IsNullOrEmpty(prenume_recenzor.Text.ToString()))
            {
                using (OracleConnection connection = new OracleConnection(StartApp.connectionString))
                {
                    try
                    {
                        connection.Open();

                        String commandString = String.Format(@"select email_recenzor from recenzori where email_recenzor='{0}' and email_recenzor is not null", email_recenzor.Text.ToString());
                        var cmd = new OracleCommand(commandString, connection);
                        var dr = cmd.ExecuteReader();
                        dr.Read();
                        if (dr.HasRows && dr.GetString(0) != emailInitial)
                        {
                            MessageBox.Show("E-mail deja existent!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            email_recenzor.Clear();
                        }
                        else
                        {
                            if (email_recenzor.Text.ToString() != "")
                                commandString = String.Format(@"update recenzori set nume_recenzor='{0}', prenume_recenzor='{1}', email_recenzor='{2}' where id_recenzor='{3}'", nume_recenzor.Text.ToString(), prenume_recenzor.Text.ToString(), email_recenzor.Text.ToString(), id_recenzor.Text.ToString());
                            else
                                commandString = String.Format(@"update recenzori set nume_recenzor='{0}', prenume_recenzor='{1}', email_recenzor=null where id_recenzor='{2}'", nume_recenzor.Text.ToString(), prenume_recenzor.Text.ToString(), id_recenzor.Text.ToString());
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

        private void EditRecenzori_Load(object sender, EventArgs e)
        {
            emailInitial = email_recenzor.Text.ToString();
        }
    }
}
