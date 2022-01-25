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

namespace Library_Management_System
{
    public partial class StartApp : Form
    {
        public const string connectionString = @"DATA SOURCE = localhost:1521/orcl; PERSIST SECURITY INFO=True; USER ID = biblioteca; password=bibliotecapa55; Pooling = False;";
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
