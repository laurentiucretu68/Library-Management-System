using System;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using System.Net;
using System.Net.Mail;

namespace Library_Management_System
{
    public partial class Signup : Form
    {
        bool draggable;
        int mouseX;
        int mouseY;
        public Signup()
        {
            InitializeComponent();
        }

        static private void sendEmailsSingUp(string id_cititor, string prenume, string email, string telefon)
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
                Subject = "Cont nou Library Management System",
                Body = "Datele de conectare sunt: email(" + email + "); telefon(" + telefon + "); parola(" + parolaCont + ")"
            };
            Message.To.Add(ToEmail);

            try
            {
                client.Send(Message);
                MessageBox.Show("Cont creat cu succes! Verificati e-mail-ul pentru datele de conectare", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login form = new Login();
            form.Closed += (s, args) => this.Close();
            form.Show();
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
                try {
                    if (!String.IsNullOrEmpty(nume.Text) && !String.IsNullOrEmpty(prenume.Text) && !String.IsNullOrEmpty(email.Text) && !String.IsNullOrEmpty(telefon.Text))
                    {
                        connection.Open();
                        String commandString = String.Format(@"select *from cititori where email_cititor='{0}'", email.Text.ToString());
                        var cmd = new OracleCommand(commandString, connection);
                        var dr = cmd.ExecuteReader();
                        dr.Read();
                        if (dr.HasRows)
                        {
                            MessageBox.Show("E-mail deja existent!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            email.Clear();
                        }
                        else
                        {
                            commandString = String.Format(@"select *from cititori where telefon_cititor ='{0}'", telefon.Text.ToString());
                            cmd = new OracleCommand(commandString, connection);
                            dr = cmd.ExecuteReader();
                            dr.Read();
                            if (dr.HasRows)
                            {
                                MessageBox.Show("Numar de telefon deja existent!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                telefon.Clear();
                            }
                            else 
                            {
                                commandString = String.Format(@"SELECT id_cititor FROM cititori WHERE ROWNUM = 1 order by id_cititor desc");
                                cmd = new OracleCommand(commandString, connection);
                                dr = cmd.ExecuteReader();
                                dr.Read();
                                int id_cititor = 0;
                                if (dr.HasRows)
                                    id_cititor = Int32.Parse(dr.GetString(0)) + 1;


                                String dataNas = dataNasterii.Value.ToString("dd-MM-yyyy");
                                String dataIns = DateTime.Now.ToString("dd-MM-yyyy");    

                                commandString = String.Format(@"insert into cititori values({0}, '{1}', '{2}', '{3}', '{4}', to_date('{5}', 'dd-mm-yyyy'), to_date('{6}', 'dd-mm-yyyy') )", id_cititor, nume.Text.ToString(), prenume.Text.ToString(), telefon.Text.ToString(), email.Text.ToString(), dataNas.ToString(), dataIns.ToString());
                                cmd = new OracleCommand(commandString, connection);
                                int success = cmd.ExecuteNonQuery();

                                if (success == 1)
                                {
                                    sendEmailsSingUp(id_cititor.ToString(), prenume.Text.ToString(), email.Text.ToString(), telefon.Text.ToString());
                                    this.Hide();
                                    Login form2 = new Login();
                                    form2.Closed += (s, args) => this.Close();
                                    form2.Show();
                                }
                                else
                                    MessageBox.Show("Eroare la conexiunea cu baza de date!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        cmd.Dispose();
                        dr.Dispose();
                        connection.Close();
                    }
                    else
                    {
                        MessageBox.Show("Completati toate campurile!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
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
