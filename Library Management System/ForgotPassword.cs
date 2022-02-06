using System;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using Oracle.ManagedDataAccess.Client;

namespace Library_Management_System
{
    public partial class ForgotPassword : Form
    {
        bool draggable;
        int mouseX;
        int mouseY;
        public ForgotPassword()
        {
            InitializeComponent();
        }

        static private void sendEmailsRequest(string id_cititor, string prenume, string email, string telefon)
        {
            string parolaCont = prenume.ToLower() + "." + id_cititor.ToString();

            SmtpClient client = new SmtpClient()
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential()
                {
                    UserName = "librarymanagementsystem7@gmail.com",
                    Password = "librarymanagemetsystem"
                }
            };

            MailAddress FromEmail = new MailAddress("admin@library.com", "Library Management System");
            MailAddress ToEmail = new MailAddress(email);
            MailMessage Message = new MailMessage()
            {
                From = FromEmail,
                Subject = "Credentiale Library Management System",
                Body = "Datele de conectare sunt: email(" + email + "); telefon(" + telefon + "); parola(" + parolaCont + ")"
            };
            Message.To.Add(ToEmail);

            try
            {
                client.Send(Message);
                MessageBox.Show("Cerere solicitata cu succes! Verificati e-mail-ul pentru datele de conectare", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login form2 = new Login();
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

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OracleConnection connection = new OracleConnection(StartApp.connectionString))
            {
                try
                {
                    if (!String.IsNullOrEmpty(email.Text.ToString()))
                    {
                        connection.Open();
                        String commandString = String.Format(@"select id_cititor, prenume_cititor, telefon_cititor, email_cititor from cititori where email_cititor='{0}'", email.Text.ToString());
                        var cmd = new OracleCommand(commandString, connection);
                        var dr = cmd.ExecuteReader();
                        dr.Read();
                        if (!dr.HasRows)
                        {
                            MessageBox.Show("E-mail nu exista in baza de date!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            email.Clear();
                        }
                        else
                        {
                            sendEmailsRequest(dr.GetString(0), dr.GetString(1), email.Text.ToString(), dr.GetString(2));
                            this.Hide();
                            Login form2 = new Login();
                            form2.Closed += (s, args) => this.Close();
                            form2.Show();
                        }
                        cmd.Dispose();
                        dr.Dispose();
                        connection.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Eroare(" + ex.ToString() + ")!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Restart();
                }
            }

        }
    }
}
