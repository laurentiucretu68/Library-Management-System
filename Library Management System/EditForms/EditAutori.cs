using System;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;


namespace Library_Management_System.EditForms
{
    public partial class EditAutori : Form
    {
        public bool buttonWasClicked = false;
        bool draggable;
        int mouseX;
        int mouseY;
        public EditAutori()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(nume_autor.Text.ToString()) && !string.IsNullOrEmpty(prenume_autor.Text.ToString()))
            {
                using (OracleConnection connection = new OracleConnection(StartApp.connectionString))
                {
                    try
                    {
                        connection.Open();

                        String dataNas = data_nasterii.Value.ToString("dd-MM-yyyy");
                        String commandString;
                        if (data_nasterii.Value.ToString("dd-MM-yyyy") != DateTime.Now.ToString("dd-MM-yyyy"))
                            commandString = String.Format(@"update autori set nume_autor='{0}', prenume_autor='{1}', data_nasterii=to_date('{2}','dd-mm-yyyy') where id_autor='{3}'", nume_autor.Text.ToString(), prenume_autor.Text.ToString(), dataNas, id_autor.Text.ToString());
                        else
                            commandString = String.Format(@"update autori set nume_autor='{0}', prenume_autor='{1}', data_nasterii=null where id_autor='{2}'", nume_autor.Text.ToString(), prenume_autor.Text.ToString(), id_autor.Text.ToString());
                        var cmd = new OracleCommand(commandString, connection);
                        cmd.ExecuteNonQuery();

                        cmd.Dispose();
                        connection.Close();
                        buttonWasClicked = true;
                        MessageBox.Show("Modificare salvata cu succes!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            {
                MessageBox.Show("Completati toate campurile!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
