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
    public partial class Admin_Settings : UserControl
    {
        string telefonInitial, emailInitial;
        public Admin_Settings(int userId)
        {
            InitializeComponent();
            idCititor.Text = userId.ToString();
            using (OracleConnection connection = new OracleConnection(StartApp.connectionString))
            {
                try
                {
                    connection.Open();
                    String commandString = String.Format(@"select *from cititori where id_cititor='{0}'", userId);
                    var cmd = new OracleCommand(commandString, connection);
                    var dr = cmd.ExecuteReader();
                    dr.Read();
                    if (dr.HasRows)
                    {
                        nume.Text = dr.GetString(1);
                        prenume.Text = dr.GetString(2);
                        telefon.Text = dr.GetString(3);
                        email.Text = dr.GetString(4);
                        data_nasterii.Value = DateTime.Parse(dr.GetString(5));
                    }

                    dr.Dispose();
                    cmd.Dispose();
                    connection.Dispose();
                    connection.Close();

                    telefonInitial = telefon.Text.ToString();
                    emailInitial = email.Text.ToString();
                }
                catch (OracleException ex)
                {
                    MessageBox.Show("Eroare(" + ex.ToString() + ")!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Restart();
                }
            }
        }

        private void Admin_Settings_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(nume.Text.ToString()) && !string.IsNullOrEmpty(prenume.Text.ToString()) && !string.IsNullOrEmpty(telefon.Text.ToString()) && !string.IsNullOrEmpty(email.Text.ToString()))
            {
                using (OracleConnection connection = new OracleConnection(StartApp.connectionString))
                {
                    try
                    {
                        connection.Open();

                        String commandString = String.Format(@"select email_cititor from cititori where email_cititor='{0}'", email.Text.ToString());
                        var cmd = new OracleCommand(commandString, connection);
                        var dr = cmd.ExecuteReader();
                        dr.Read();
                        if (dr.HasRows && dr.GetString(0) != emailInitial)
                        {
                            MessageBox.Show("E-mail deja existent!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            email.Clear();
                        }
                        else
                        {
                            commandString = String.Format(@"select telefon_cititor from cititori where telefon_cititor ='{0}'", telefon.Text.ToString());
                            cmd = new OracleCommand(commandString, connection);
                            dr = cmd.ExecuteReader();
                            dr.Read();
                            if (dr.HasRows && dr.GetString(0) != telefonInitial)
                            {
                                MessageBox.Show("Numar de telefon deja existent!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                telefon.Clear();
                            }
                            else
                            {
                                String dataNas = data_nasterii.Value.ToString("dd-MM-yyyy");

                                commandString = String.Format(@"update cititori set nume_cititor='{0}', prenume_cititor='{1}', telefon_cititor='{2}', email_cititor='{3}', data_nasterii=to_date('{4}','dd-mm-yyyy') where id_cititor='{5}'", nume.Text.ToString(), prenume.Text.ToString(), telefon.Text.ToString(), email.Text.ToString(), dataNas, idCititor.Text.ToString());
                                cmd = new OracleCommand(commandString, connection);
                                cmd.ExecuteNonQuery();

                                cmd.Dispose();
                                dr.Dispose();
                                connection.Close();
                                MessageBox.Show("Modificare salvata cu succes!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
