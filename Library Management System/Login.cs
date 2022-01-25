using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace Library_Management_System
{
    public partial class Login : Form
    {
        bool draggable;
        int mouseX;
        int mouseY;
        public Login()
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Signup form = new Signup();
            form.Closed += (s, args) => this.Close();
            form.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            ForgotPassword form2 = new ForgotPassword();
            form2.Closed += (s, args) => this.Close();
            form2.Show();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            draggable = true;
            mouseX = Cursor.Position.X - Left;
            mouseY = Cursor.Position.Y - Top;
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

        private void button1_Click(object sender, EventArgs e)
        {
            using (OracleConnection connection = new OracleConnection(StartApp.connectionString))
            {
                try
                {
                    connection.Open();
                    
                    if (!String.IsNullOrEmpty(email.Text) && !String.IsNullOrEmpty(id.Text))
                    {
                        if (email.Text.ToString().ToLower() == "admin" && id.Text.ToString().ToLower() == "bibliotecapa55")
                        {
                            this.Hide();
                            AdminPanel ad = new AdminPanel();
                            ad.Closed += (s, args) => this.Close();
                            ad.Show();
                        }
                        else
                        {
                            string parola = id.Text.ToString();


                            String commandString = String.Format(@"select *from cititori where (email_cititor='{0}' or telefon_cititor='{0}')", email.Text.ToString().ToLower());
                            var cmd = new OracleCommand(commandString, connection);
                            var dr = cmd.ExecuteReader();
                            dr.Read();
                            if (dr.HasRows)
                            {
                                if (dr.GetString(2).ToLower()+"."+ dr.GetString(0) == parola)
                                {
                                    AdminUser ad = new AdminUser(Int32.Parse(dr.GetString(0)));
                                    ad.idCititor.Text = dr.GetString(0);
                                    ad.nume.Text = dr.GetString(1) + " " + dr.GetString(2);
                                    cmd.Dispose();
                                    dr.Dispose();
                                    connection.Close();
                                    this.Hide();

                                    ad.Closed += (s, args) => this.Close();
                                    ad.Show();
                                }
                                else
                                {
                                    MessageBox.Show("Parola gresita!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    id.Clear();
                                }
                                
                            }
                            else
                            {
                                MessageBox.Show("Date incorecte! Incercati din nou!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                email.Clear();
                                id.Clear();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Completati campurile!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    connection.Close();
                }
                catch (OracleException ex)
                {
                    MessageBox.Show("Eroare(" + ex.ToString() + ")!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Restart();
                }
            }
        }
    }
}
