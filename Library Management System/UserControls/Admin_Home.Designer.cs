
namespace Library_Management_System.UserControls
{
    partial class Admin_Home
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.titluStatistica = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.imprumuturi = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.nereturnate = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.cititori = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.bunifuDataViz2 = new Bunifu.DataViz.BunifuDataViz();
            this.graficImprumuturi = new LiveCharts.WinForms.CartesianChart();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.totalCarti = new CircularProgressBar.CircularProgressBar();
            this.cartiDonate = new CircularProgressBar.CircularProgressBar();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // titluStatistica
            // 
            this.titluStatistica.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.titluStatistica.AutoSize = true;
            this.titluStatistica.BackColor = System.Drawing.Color.Transparent;
            this.titluStatistica.Font = new System.Drawing.Font("Century Gothic", 14F, System.Drawing.FontStyle.Bold);
            this.titluStatistica.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(42)))), ((int)(((byte)(109)))));
            this.titluStatistica.Location = new System.Drawing.Point(481, 27);
            this.titluStatistica.Name = "titluStatistica";
            this.titluStatistica.Size = new System.Drawing.Size(298, 28);
            this.titluStatistica.TabIndex = 7;
            this.titluStatistica.Text = "Statistici luna decembrie";
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(42)))), ((int)(((byte)(109)))));
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.imprumuturi);
            this.panel1.Controls.Add(this.label1);
            this.panel1.ForeColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(82, 91);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(280, 125);
            this.panel1.TabIndex = 8;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.Image = global::Library_Management_System.Properties.Resources.borrow_book_100px1;
            this.pictureBox1.Location = new System.Drawing.Point(173, 23);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(75, 75);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // imprumuturi
            // 
            this.imprumuturi.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.imprumuturi.AutoSize = true;
            this.imprumuturi.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.imprumuturi.Location = new System.Drawing.Point(59, 65);
            this.imprumuturi.Name = "imprumuturi";
            this.imprumuturi.Size = new System.Drawing.Size(71, 23);
            this.imprumuturi.TabIndex = 1;
            this.imprumuturi.Text = "10 935";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Imprumuturi";
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(42)))), ((int)(((byte)(109)))));
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Controls.Add(this.nereturnate);
            this.panel2.Controls.Add(this.label4);
            this.panel2.ForeColor = System.Drawing.Color.White;
            this.panel2.Location = new System.Drawing.Point(455, 91);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(352, 125);
            this.panel2.TabIndex = 9;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox2.Image = global::Library_Management_System.Properties.Resources.book_75px;
            this.pictureBox2.Location = new System.Drawing.Point(248, 21);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(75, 75);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // nereturnate
            // 
            this.nereturnate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.nereturnate.AutoSize = true;
            this.nereturnate.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.nereturnate.Location = new System.Drawing.Point(100, 66);
            this.nereturnate.Name = "nereturnate";
            this.nereturnate.Size = new System.Drawing.Size(60, 23);
            this.nereturnate.TabIndex = 1;
            this.nereturnate.Text = "9 843";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(39, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(177, 23);
            this.label4.TabIndex = 0;
            this.label4.Text = "Carti nereturnate";
            // 
            // panel3
            // 
            this.panel3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(42)))), ((int)(((byte)(109)))));
            this.panel3.Controls.Add(this.pictureBox3);
            this.panel3.Controls.Add(this.cititori);
            this.panel3.Controls.Add(this.label6);
            this.panel3.ForeColor = System.Drawing.Color.White;
            this.panel3.Location = new System.Drawing.Point(901, 91);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(280, 125);
            this.panel3.TabIndex = 9;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox3.Image = global::Library_Management_System.Properties.Resources.user_75px;
            this.pictureBox3.Location = new System.Drawing.Point(173, 21);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(75, 75);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            // 
            // cititori
            // 
            this.cititori.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cititori.AutoSize = true;
            this.cititori.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.cititori.Location = new System.Drawing.Point(74, 65);
            this.cititori.Name = "cititori";
            this.cititori.Size = new System.Drawing.Size(43, 23);
            this.cititori.TabIndex = 1;
            this.cititori.Text = "546";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(38, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 23);
            this.label6.TabIndex = 0;
            this.label6.Text = "Cititori noi";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(42)))), ((int)(((byte)(109)))));
            this.label8.Location = new System.Drawing.Point(78, 256);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(350, 23);
            this.label8.TabIndex = 10;
            this.label8.Text = "Raport imprumuturi anul precedent";
            // 
            // bunifuDataViz2
            // 
            this.bunifuDataViz2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bunifuDataViz2.animationEnabled = false;
            this.bunifuDataViz2.AxisLineColor = System.Drawing.Color.LightGray;
            this.bunifuDataViz2.AxisXFontColor = System.Drawing.Color.Gray;
            this.bunifuDataViz2.AxisXGridColor = System.Drawing.Color.Gray;
            this.bunifuDataViz2.AxisXGridThickness = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.bunifuDataViz2.AxisYFontColor = System.Drawing.Color.Gray;
            this.bunifuDataViz2.AxisYGridColor = System.Drawing.Color.Gray;
            this.bunifuDataViz2.AxisYGridThickness = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.bunifuDataViz2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuDataViz2.Location = new System.Drawing.Point(1122, 746);
            this.bunifuDataViz2.Margin = new System.Windows.Forms.Padding(14, 13, 14, 13);
            this.bunifuDataViz2.Name = "bunifuDataViz2";
            this.bunifuDataViz2.Size = new System.Drawing.Size(18, 19);
            this.bunifuDataViz2.TabIndex = 12;
            this.bunifuDataViz2.Theme = Bunifu.DataViz.BunifuDataViz._theme.theme1;
            this.bunifuDataViz2.Title = "";
            // 
            // graficImprumuturi
            // 
            this.graficImprumuturi.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.graficImprumuturi.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.graficImprumuturi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(55)))), ((int)(((byte)(100)))));
            this.graficImprumuturi.Location = new System.Drawing.Point(82, 298);
            this.graficImprumuturi.Name = "graficImprumuturi";
            this.graficImprumuturi.Size = new System.Drawing.Size(783, 402);
            this.graficImprumuturi.TabIndex = 17;
            this.graficImprumuturi.Text = "Imprumuturi:";
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(42)))), ((int)(((byte)(109)))));
            this.label9.Location = new System.Drawing.Point(1016, 441);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(104, 23);
            this.label9.TabIndex = 20;
            this.label9.Text = "Total carti";
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(42)))), ((int)(((byte)(109)))));
            this.label10.Location = new System.Drawing.Point(1008, 621);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(132, 23);
            this.label10.TabIndex = 22;
            this.label10.Text = "Carti donate";
            // 
            // totalCarti
            // 
            this.totalCarti.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.totalCarti.AnimationFunction = WinFormAnimation.KnownAnimationFunctions.Liner;
            this.totalCarti.AnimationSpeed = 500;
            this.totalCarti.BackColor = System.Drawing.Color.Transparent;
            this.totalCarti.Font = new System.Drawing.Font("Century Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalCarti.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(42)))), ((int)(((byte)(109)))));
            this.totalCarti.InnerColor = System.Drawing.Color.White;
            this.totalCarti.InnerMargin = 2;
            this.totalCarti.InnerWidth = -1;
            this.totalCarti.Location = new System.Drawing.Point(1001, 310);
            this.totalCarti.MarqueeAnimationSpeed = 2000;
            this.totalCarti.Name = "totalCarti";
            this.totalCarti.OuterColor = System.Drawing.Color.Gainsboro;
            this.totalCarti.OuterMargin = -25;
            this.totalCarti.OuterWidth = 26;
            this.totalCarti.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(42)))), ((int)(((byte)(109)))));
            this.totalCarti.ProgressWidth = 5;
            this.totalCarti.SecondaryFont = new System.Drawing.Font("Microsoft Sans Serif", 36F);
            this.totalCarti.Size = new System.Drawing.Size(128, 128);
            this.totalCarti.StartAngle = 270;
            this.totalCarti.SubscriptColor = System.Drawing.Color.White;
            this.totalCarti.SubscriptMargin = new System.Windows.Forms.Padding(10, -35, 0, 0);
            this.totalCarti.SubscriptText = "";
            this.totalCarti.SuperscriptColor = System.Drawing.Color.White;
            this.totalCarti.SuperscriptMargin = new System.Windows.Forms.Padding(10, 35, 0, 0);
            this.totalCarti.SuperscriptText = "";
            this.totalCarti.TabIndex = 23;
            this.totalCarti.TextMargin = new System.Windows.Forms.Padding(0);
            this.totalCarti.Value = 68;
            // 
            // cartiDonate
            // 
            this.cartiDonate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cartiDonate.AnimationFunction = WinFormAnimation.KnownAnimationFunctions.Liner;
            this.cartiDonate.AnimationSpeed = 500;
            this.cartiDonate.BackColor = System.Drawing.Color.Transparent;
            this.cartiDonate.Font = new System.Drawing.Font("Century Gothic", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cartiDonate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(42)))), ((int)(((byte)(109)))));
            this.cartiDonate.InnerColor = System.Drawing.Color.White;
            this.cartiDonate.InnerMargin = 2;
            this.cartiDonate.InnerWidth = -1;
            this.cartiDonate.Location = new System.Drawing.Point(1001, 490);
            this.cartiDonate.MarqueeAnimationSpeed = 2000;
            this.cartiDonate.Name = "cartiDonate";
            this.cartiDonate.OuterColor = System.Drawing.Color.Gainsboro;
            this.cartiDonate.OuterMargin = -25;
            this.cartiDonate.OuterWidth = 26;
            this.cartiDonate.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(42)))), ((int)(((byte)(109)))));
            this.cartiDonate.ProgressWidth = 5;
            this.cartiDonate.SecondaryFont = new System.Drawing.Font("Microsoft Sans Serif", 36F);
            this.cartiDonate.Size = new System.Drawing.Size(128, 128);
            this.cartiDonate.StartAngle = 270;
            this.cartiDonate.SubscriptColor = System.Drawing.Color.Transparent;
            this.cartiDonate.SubscriptMargin = new System.Windows.Forms.Padding(10, -35, 0, 0);
            this.cartiDonate.SubscriptText = "";
            this.cartiDonate.SuperscriptColor = System.Drawing.Color.Transparent;
            this.cartiDonate.SuperscriptMargin = new System.Windows.Forms.Padding(10, 35, 0, 0);
            this.cartiDonate.SuperscriptText = "";
            this.cartiDonate.TabIndex = 24;
            this.cartiDonate.TextMargin = new System.Windows.Forms.Padding(0);
            this.cartiDonate.Value = 68;
            // 
            // Admin_Home
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.cartiDonate);
            this.Controls.Add(this.totalCarti);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.graficImprumuturi);
            this.Controls.Add(this.bunifuDataViz2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.titluStatistica);
            this.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.Name = "Admin_Home";
            this.Size = new System.Drawing.Size(1270, 760);
            this.Load += new System.EventHandler(this.Admin_Home_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label titluStatistica;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label imprumuturi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label nereturnate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label cititori;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private Bunifu.DataViz.BunifuDataViz bunifuDataViz2;
        private LiveCharts.WinForms.CartesianChart graficImprumuturi;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private CircularProgressBar.CircularProgressBar cartiDonate;
        private CircularProgressBar.CircularProgressBar totalCarti;
    }
}
