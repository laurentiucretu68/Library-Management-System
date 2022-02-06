using System;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;


namespace Library_Management_System.AddForms
{
    public partial class AddCategorie : Form
    {
        public bool buttonWasClicked = false;
        bool draggable;
        int mouseX;
        int mouseY;
        public AddCategorie()
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
            if (!string.IsNullOrEmpty(nume_categorie.Text.ToString()))
            {
                int varstaMinima = Int32.Parse(varsta_minima.Text.ToString());
                if (!string.IsNullOrEmpty(varsta_minima.Text.ToString()))
                {
                    if ((varstaMinima > 0 && varstaMinima < 100))
                    {
                        using (OracleConnection connection = new OracleConnection(StartApp.connectionString))
                        {
                            try
                            {
                                connection.Open();

                                String commandString = String.Format(@"SELECT id_categorie FROM categorii WHERE ROWNUM = 1 order by id_categorie desc");
                                var cmd = new OracleCommand(commandString, connection);
                                var dr = cmd.ExecuteReader();
                                dr.Read();
                                int id_categorie = 0;
                                if (dr.HasRows)
                                    id_categorie = Int32.Parse(dr.GetString(0)) + 1;

                                commandString = String.Format(@"insert into categorii values('{0}', '{1}', '{2}')", id_categorie, nume_categorie.Text.ToString(), varsta_minima.Text.ToString());
                                cmd = new OracleCommand(commandString, connection);
                                cmd.ExecuteNonQuery();

                                cmd.Dispose();
                                connection.Close();
                                buttonWasClicked = true;
                                MessageBox.Show("Editura adaugata cu succes!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                        MessageBox.Show("Varsta minima necorespunzatoare!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    using (OracleConnection connection = new OracleConnection(StartApp.connectionString))
                    {
                        try
                        {
                            connection.Open();

                            String commandString = String.Format(@"SELECT id_categorie FROM categorii WHERE ROWNUM = 1 order by id_categorie desc");
                            var cmd = new OracleCommand(commandString, connection);
                            var dr = cmd.ExecuteReader();
                            dr.Read();
                            int id_categorie = 0;
                            if (dr.HasRows)
                                id_categorie = Int32.Parse(dr.GetString(0)) + 1;

                            commandString = String.Format(@"insert into categorii values('{0}', '{1}', null)", id_categorie, nume_categorie.Text.ToString());
                            cmd = new OracleCommand(commandString, connection);
                            cmd.ExecuteNonQuery();

                            cmd.Dispose();
                            connection.Close();
                            buttonWasClicked = true;
                            MessageBox.Show("Editura adaugata cu succes!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
