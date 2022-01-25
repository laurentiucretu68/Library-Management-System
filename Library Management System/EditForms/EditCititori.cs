using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace Library_Management_System.EditForms
{
    public partial class EditCititori : Form
    {
        public bool buttonWasClicked = false;
        string telefonInitial, emailInitial;
        bool draggable;
        int mouseX;
        int mouseY;
        public EditCititori()
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

        private void EditCititori_Load(object sender, EventArgs e)
        {
            telefonInitial = telefon_cititor.Text.ToString();
            emailInitial = email_cititor.Text.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(nume_cititor.Text.ToString()) && !string.IsNullOrEmpty(prenume_cititor.Text.ToString()) && !string.IsNullOrEmpty(telefon_cititor.Text.ToString()))
            {
                using (OracleConnection connection = new OracleConnection(StartApp.connectionString))
                {
                    try
                    {
                        connection.Open();

                        String commandString = String.Format(@"select email_cititor from cititori where email_cititor='{0}' and email_cititor is not null", email_cititor.Text.ToString());
                        var cmd = new OracleCommand(commandString, connection);
                        var dr = cmd.ExecuteReader();
                        dr.Read();
                        if (dr.HasRows && dr.GetString(0) != emailInitial)
                        {
                            MessageBox.Show("E-mail deja existent!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            email_cititor.Clear();
                        }
                        else
                        {
                            commandString = String.Format(@"select telefon_cititor from cititori where telefon_cititor ='{0}'", telefon_cititor.Text.ToString());
                            cmd = new OracleCommand(commandString, connection);
                            dr = cmd.ExecuteReader();
                            dr.Read();
                            if (dr.HasRows && dr.GetString(0) != telefonInitial)
                            {
                                MessageBox.Show("Numar de telefon deja existent!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                telefon_cititor.Clear();
                            }
                            else
                            {
                                String dataNas = data_nasterii.Value.ToString("dd-MM-yyyy");

                                if (email_cititor.Text.ToString() != "")
                                    commandString = String.Format(@"update cititori set nume_cititor='{0}', prenume_cititor='{1}', telefon_cititor='{2}', email_cititor='{3}', data_nasterii=to_date('{4}','dd-mm-yyyy') where id_cititor='{5}'", nume_cititor.Text.ToString(), prenume_cititor.Text.ToString(), telefon_cititor.Text.ToString(), email_cititor.Text.ToString(), dataNas, id_cititor.Text.ToString());
                                else
                                    commandString = String.Format(@"update cititori set nume_cititor='{0}', prenume_cititor='{1}', telefon_cititor='{2}', email_cititor=null, data_nasterii=to_date('{3}','dd-mm-yyyy') where id_cititor='{4}'", nume_cititor.Text.ToString(), prenume_cititor.Text.ToString(), telefon_cititor.Text.ToString(), dataNas, id_cititor.Text.ToString());
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
