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

namespace Library_Management_System.AddForms
{
    public partial class AddAutor : Form
    {
        public bool buttonWasClicked = false;
        bool draggable;
        int mouseX;
        int mouseY;
        public AddAutor()
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
            if (!string.IsNullOrEmpty(nume_autor.Text.ToString()) && !string.IsNullOrEmpty(prenume_autor.Text.ToString()))
            {
                if (data_nasterii.Value != DateTime.Now)
                {
                    DateTime dataValidare = DateTime.Now.AddYears(-15);
                    if (data_nasterii.Value <= dataValidare)
                    {
                        using (OracleConnection connection = new OracleConnection(StartApp.connectionString))
                        {
                            try
                            {
                                connection.Open();

                                String commandString = String.Format(@"SELECT id_autor FROM autori WHERE ROWNUM = 1 order by id_autor desc");
                                var cmd = new OracleCommand(commandString, connection);
                                var dr = cmd.ExecuteReader();
                                dr.Read();
                                int id_autor = 0;
                                if (dr.HasRows)
                                    id_autor = Int32.Parse(dr.GetString(0)) + 1;

                                commandString = String.Format(@"insert into autori values('{0}', '{1}', '{2}', to_date('{3}','dd-mm-yyyy'))", id_autor, nume_autor.Text.ToString(), prenume_autor.Text.ToString(), data_nasterii.Value.ToString());
                                cmd = new OracleCommand(commandString, connection);
                                cmd.ExecuteNonQuery();

                                cmd.Dispose();
                                connection.Close();
                                buttonWasClicked = true;
                                MessageBox.Show("Autor adaugat cu succes!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                            }
                            catch (OracleException ex)
                            {
                                MessageBox.Show("Eroare(" + ex.ToString() + ")!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                Application.Restart();
                            }
                        }
                    }
                    else
                        MessageBox.Show("Data introdusa necorespunzator!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    using (OracleConnection connection = new OracleConnection(StartApp.connectionString))
                    {
                        try
                        {
                            connection.Open();

                            String commandString = String.Format(@"SELECT id_autor FROM autori WHERE ROWNUM = 1 order by id_autor desc");
                            var cmd = new OracleCommand(commandString, connection);
                            var dr = cmd.ExecuteReader();
                            dr.Read();
                            int id_autor = 0;
                            if (dr.HasRows)
                                id_autor = Int32.Parse(dr.GetString(0)) + 1;

                            commandString = String.Format(@"insert into autori values('{0}', '{1}', '{2}', null)", id_autor, nume_autor.Text.ToString(), prenume_autor.Text.ToString());
                            cmd = new OracleCommand(commandString, connection);
                            cmd.ExecuteNonQuery();

                            cmd.Dispose();
                            connection.Close();
                            buttonWasClicked = true;
                            MessageBox.Show("Autor adaugat cu succes!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        catch (OracleException ex)
                        {
                            MessageBox.Show("Eroare(" + ex.ToString() + ")!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Application.Restart();
                        }
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
