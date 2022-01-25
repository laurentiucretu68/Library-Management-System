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
    public partial class EditImprumut : Form
    {
        public bool buttonWasClicked = false;
        bool draggable;
        int mouseX;
        int mouseY;
        public EditImprumut()
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
            if (!string.IsNullOrEmpty(id_cititor.Text.ToString()) && !string.IsNullOrEmpty(id_carte.Text.ToString()) && !string.IsNullOrEmpty(data_imprumut.Value.ToString()))
            {
                using (OracleConnection connection = new OracleConnection(StartApp.connectionString))
                {
                    try
                    {
                        connection.Open();

                        String commandString = String.Format(@"select id_cititor from cititori where id_cititor='{0}'", id_cititor.Text.ToString());
                        var cmd = new OracleCommand(commandString, connection);
                        var dr = cmd.ExecuteReader();
                        dr.Read();
                        if (!dr.HasRows)
                        {
                            MessageBox.Show("Cititorul cu acest id nu exista in baza de date!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                                String dataImprumut = data_imprumut.Value.ToString("dd-MM-yyyy");
                                String dataReturnare = data_returnare.Value.ToString("dd-MM-yyyy");

                                if (data_returnare.Value.ToString("dd-MM-yyyy") != "01-01-1900")
                                {
                                    if (data_imprumut.Value <= data_returnare.Value)
                                    {
                                        commandString = String.Format(@"update imprumuta set id_cititor='{0}', id_carte='{1}', data_imprumut=to_date('{2}','dd-mm-yyyy'), data_returnare=to_date('{3}','dd-mm-yyyy') where id_carte='{4}'", id_cititor.Text.ToString(), id_carte.Text.ToString(), dataImprumut, dataReturnare, id_imrpumut.Text.ToString());
                                        cmd = new OracleCommand(commandString, connection);
                                        cmd.ExecuteNonQuery();

                                        cmd.Dispose();
                                        connection.Close();

                                        MessageBox.Show("Modificare salvata cu succes!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        this.Close();
                                    }
                                    else
                                        MessageBox.Show("Date alese necorespunzator!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else
                                {
                                    commandString = String.Format(@"update imprumuta set id_cititor='{0}', id_carte='{1}', data_imprumut=to_date('{2}','dd-mm-yyyy'), data_returnare=null where id_carte='{3}'", id_cititor.Text.ToString(), id_carte.Text.ToString(), dataImprumut, id_imrpumut.Text.ToString());
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

        private void EditImprumut_Load(object sender, EventArgs e)
        {

        }
    }
}
