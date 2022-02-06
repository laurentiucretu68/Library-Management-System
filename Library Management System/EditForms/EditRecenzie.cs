using System;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace Library_Management_System.EditForms
{
    public partial class EditRecenzie : Form
    {
        public bool buttonWasClicked = false;
        bool draggable;
        int mouseX;
        int mouseY;
        public EditRecenzie()
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
            if (!string.IsNullOrEmpty(id_recenzor.Text.ToString()) && !string.IsNullOrEmpty(id_carte.Text.ToString()) && !string.IsNullOrEmpty(nota_recenzie.Text.ToString()) && !string.IsNullOrEmpty(data_recenzie.Value.ToString()))
            {
                using (OracleConnection connection = new OracleConnection(StartApp.connectionString))
                {
                    try
                    {
                        connection.Open();

                        String commandString = String.Format(@"select id_recenzor from recenzori where id_recenzor='{0}'", id_recenzor.Text.ToString());
                        var cmd = new OracleCommand(commandString, connection);
                        var dr = cmd.ExecuteReader();
                        dr.Read();
                        if (!dr.HasRows)
                        {
                            MessageBox.Show("Recenzorul cu acest id nu exista in baza de date!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                                String dataRecenzie = data_recenzie.Value.ToString("dd-MM-yyyy");
                                double val = Convert.ToDouble(nota_recenzie.Text.ToString());

                                if (val>=1 && val<=10)
                                {
                                    commandString = String.Format(@"update recenzie set id_recenzor='{0}', id_carte='{1}', data=to_date('{2}','dd-mm-yyyy'), nota_recenzie='{3}' where id_carte='{4}'", id_recenzor.Text.ToString(), id_carte.Text.ToString(), dataRecenzie, nota_recenzie.Text.ToString(), id_recenzor.Text.ToString());
                                    cmd = new OracleCommand(commandString, connection);
                                    cmd.ExecuteNonQuery();

                                    cmd.Dispose();
                                    connection.Close();
                                    buttonWasClicked = true;
                                    MessageBox.Show("Modificare salvata cu succes!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.Close();
                                }
                                else
                                    MessageBox.Show("Nota trebuie sa fie cuprinsa intre 1 si 10!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
