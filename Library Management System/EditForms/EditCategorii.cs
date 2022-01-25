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
    public partial class EditCategorii : Form
    {
        public bool buttonWasClicked = false;
        bool draggable;
        int mouseX;
        int mouseY;
        public EditCategorii()
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(nume_categorie.Text.ToString()) && !string.IsNullOrEmpty(varsta_categorie.Text.ToString()))
            {
                int val = Convert.ToInt32(varsta_categorie.Text.ToString());
                if (val >=1 && val<100)
                {
                    using (OracleConnection connection = new OracleConnection(StartApp.connectionString))
                    {
                        try
                        {
                            connection.Open();
                            String commandString;
                            if (varsta_categorie.Text.ToString() != "")
                                commandString = String.Format(@"update categorii set nume_categorie='{0}', varsta_minima_recomandata='{1}' where id_categorie='{2}'", nume_categorie.Text.ToString(), varsta_categorie.Text.ToString(), id_categorie.Text.ToString());
                            else
                                commandString = String.Format(@"update categorii set nume_categorie='{0}', varsta_minima_recomandata=null where id_categorie='{1}'", nume_categorie.Text.ToString(), id_categorie.Text.ToString());
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
                    MessageBox.Show("Varsta aleasa necorespunzator!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                MessageBox.Show("Completati toate campurile!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
