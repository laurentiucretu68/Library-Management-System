using System;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace Library_Management_System.AddForms
{
    public partial class AddFurnizor : Form
    {
        public bool buttonWasClicked = false;
        bool draggable;
        int mouseX;
        int mouseY;
        public AddFurnizor()
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
            if (!string.IsNullOrEmpty(nume_furnizor.Text.ToString()) && !string.IsNullOrEmpty(email_furnizor.Text.ToString()) && !string.IsNullOrEmpty(telefon_furnizor.Text.ToString()))
            {
                using (OracleConnection connection = new OracleConnection(StartApp.connectionString))
                {
                    try
                    {
                        connection.Open();

                        String commandString = String.Format(@"select telefon_furnizor from furnizori where telefon_furnizor='{0}'", telefon_furnizor.Text.ToString());
                        var cmd = new OracleCommand(commandString, connection);
                        var dr = cmd.ExecuteReader();
                        dr.Read();
                        if (dr.HasRows)
                        {
                            MessageBox.Show("Telefon deja existent!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            telefon_furnizor.Clear();
                        }
                        else
                        {
                            commandString = String.Format(@"select email_furnizor from furnizori where email_furnizor='{0}'", email_furnizor.Text.ToString());
                            cmd = new OracleCommand(commandString, connection);
                            dr = cmd.ExecuteReader();
                            dr.Read();
                            if (dr.HasRows)
                            {
                                MessageBox.Show("E-mail deja existent!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                telefon_furnizor.Clear();
                            }
                            else
                            {
                                commandString = String.Format(@"SELECT id_furnizor FROM furnizori WHERE ROWNUM = 1 order by id_furnizor desc");
                                cmd = new OracleCommand(commandString, connection);
                                dr = cmd.ExecuteReader();
                                dr.Read();
                                int id_furnizor = 0;
                                if (dr.HasRows)
                                    id_furnizor = Int32.Parse(dr.GetString(0)) + 1;

                                commandString = String.Format(@"insert into furnizori values('{0}', '{1}', '{2}')", id_furnizor, telefon_furnizor.Text.ToString(), email_furnizor.Text.ToString());
                                cmd = new OracleCommand(commandString, connection);
                                cmd.ExecuteNonQuery();

                                cmd.Dispose();
                                connection.Close();
                                buttonWasClicked = true;
                                MessageBox.Show("Furnizor adaugat cu succes!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
