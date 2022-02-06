using System;
using System.Windows.Forms;

namespace Library_Management_System
{
    public partial class StartApp : Form
    {
        public const string connectionString = @"DATA SOURCE = localhost:1521/orcl; PERSIST SECURITY INFO=True; USER ID = biblioteca; password=bibliotecapa55; Pooling = False;";
        ///public const string connectionString = @"DATA SOURCE = 193.226.51.37:1521/o11g; PERSIST SECURITY INFO=True; USER ID = laurentiucretu; password=laurentiu#15; Pooling = False;";
        public StartApp()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            panel2.Width += 3;
            if (panel2.Width >= 700)
            {
                timer1.Stop();
                this.Hide();
                Login form2 = new Login();
                form2.Closed += (s, args) => this.Close();
                form2.Show();
            }
        }
    }
}
