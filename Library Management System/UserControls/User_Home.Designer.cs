
namespace Library_Management_System.UserControls
{
    partial class User_Home
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.graficImprumuturi = new LiveCharts.WinForms.CartesianChart();
            this.bunifuDataViz2 = new Bunifu.DataViz.BunifuDataViz();
            this.label8 = new System.Windows.Forms.Label();
            this.imprumuturi_active = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.imprumuturi_total = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.Image = global::Library_Management_System.Properties.Resources.borrow_book_100px1;
            this.pictureBox1.Location = new System.Drawing.Point(248, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(75, 75);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // graficImprumuturi
            // 
            this.graficImprumuturi.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.graficImprumuturi.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.graficImprumuturi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(55)))), ((int)(((byte)(100)))));
            this.graficImprumuturi.Location = new System.Drawing.Point(61, 161);
            this.graficImprumuturi.Name = "graficImprumuturi";
            this.graficImprumuturi.Size = new System.Drawing.Size(714, 402);
            this.graficImprumuturi.TabIndex = 31;
            this.graficImprumuturi.Text = "Imprumuturi:";
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
            this.bunifuDataViz2.Location = new System.Drawing.Point(2532, 1621);
            this.bunifuDataViz2.Margin = new System.Windows.Forms.Padding(32, 27, 32, 27);
            this.bunifuDataViz2.Name = "bunifuDataViz2";
            this.bunifuDataViz2.Size = new System.Drawing.Size(40, 39);
            this.bunifuDataViz2.TabIndex = 30;
            this.bunifuDataViz2.Theme = Bunifu.DataViz.BunifuDataViz._theme.theme1;
            this.bunifuDataViz2.Title = "";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(42)))), ((int)(((byte)(109)))));
            this.label8.Location = new System.Drawing.Point(57, 114);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(350, 23);
            this.label8.TabIndex = 29;
            this.label8.Text = "Raport imprumuturi anul precedent";
            // 
            // imprumuturi_active
            // 
            this.imprumuturi_active.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.imprumuturi_active.AutoSize = true;
            this.imprumuturi_active.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.imprumuturi_active.Location = new System.Drawing.Point(100, 66);
            this.imprumuturi_active.Name = "imprumuturi_active";
            this.imprumuturi_active.Size = new System.Drawing.Size(60, 23);
            this.imprumuturi_active.TabIndex = 1;
            this.imprumuturi_active.Text = "9 843";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(194, 23);
            this.label4.TabIndex = 0;
            this.label4.Text = "Imprumuturi active";
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(42)))), ((int)(((byte)(109)))));
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Controls.Add(this.imprumuturi_active);
            this.panel2.Controls.Add(this.label4);
            this.panel2.ForeColor = System.Drawing.Color.White;
            this.panel2.Location = new System.Drawing.Point(858, 210);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(352, 125);
            this.panel2.TabIndex = 28;
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
            // imprumuturi_total
            // 
            this.imprumuturi_total.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.imprumuturi_total.AutoSize = true;
            this.imprumuturi_total.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.imprumuturi_total.Location = new System.Drawing.Point(95, 66);
            this.imprumuturi_total.Name = "imprumuturi_total";
            this.imprumuturi_total.Size = new System.Drawing.Size(71, 23);
            this.imprumuturi_total.TabIndex = 1;
            this.imprumuturi_total.Text = "10 935";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Total imprumuturi";
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(42)))), ((int)(((byte)(109)))));
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.imprumuturi_total);
            this.panel1.Controls.Add(this.label1);
            this.panel1.ForeColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(858, 364);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(352, 126);
            this.panel1.TabIndex = 26;
            // 
            // User_Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.graficImprumuturi);
            this.Controls.Add(this.bunifuDataViz2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "User_Home";
            this.Size = new System.Drawing.Size(1270, 760);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private LiveCharts.WinForms.CartesianChart graficImprumuturi;
        private Bunifu.DataViz.BunifuDataViz bunifuDataViz2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label imprumuturi_active;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label imprumuturi_total;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
    }
}
