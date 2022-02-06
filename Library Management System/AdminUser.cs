using Library_Management_System.UserControls;
using System;
using System.Windows.Forms;

namespace Library_Management_System
{
    public partial class AdminUser : Form
    {
        int PanelWidth;
        bool isCollapsed;
        bool draggable;
        int mouseX;
        int mouseY;
        User_Home a;

        public AdminUser(int userId)
        {
            InitializeComponent();
            timerTime.Start();
            PanelWidth = panelLeft.Width;
            isCollapsed = false;
            a = new User_Home(userId);
            AddControlsToPanel(a);
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isCollapsed)
            {
                panelLeft.Width += 10;
                if (panelLeft.Width >= PanelWidth)
                {
                    timer1.Stop();
                    isCollapsed = false;
                    this.Refresh();
                }
            }
            else
            {
                panelLeft.Width -= 10;
                if (panelLeft.Width <= 59)
                {
                    timer1.Stop();
                    isCollapsed = true;
                    this.Refresh();
                }
            }
        }
        private void moveSidePanel(Control btn)
        {
            panelSide.Top = btn.Top;
            panelSide.Height = btn.Height;
        }

        private void AddControlsToPanel(Control c)
        {
            c.Dock = DockStyle.Fill;
            panelControl.Controls.Clear();
            panelControl.Controls.Add(c);
        }

        private void timerTime_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            labelTime.Text = dt.ToString("MM.dd.yyyy, HH:mm:ss");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login form = new Login();
            form.Closed += (s, args) => this.Close();
            form.Show();
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
            moveSidePanel(button1);
            AddControlsToPanel(a);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            moveSidePanel(button2);
            User_BorrowedBooks ad_us = new User_BorrowedBooks(Int32.Parse(idCititor.Text.ToString()));
            AddControlsToPanel(ad_us);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            moveSidePanel(button4);
            User_AllBooks ad_us = new User_AllBooks();
            AddControlsToPanel(ad_us);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            moveSidePanel(button3);
            Admin_Settings ad_us = new Admin_Settings(Int32.Parse(idCititor.Text.ToString()));
            AddControlsToPanel(ad_us);
        }
    }
}
