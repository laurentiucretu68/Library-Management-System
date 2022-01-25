
namespace Library_Management_System.EditForms
{
    partial class EditCititori
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.titleTop = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.id_cititor = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.data_nasterii = new ns1.BunifuDatepicker();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.prenume_cititor = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.nume_cititor = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.telefon_cititor = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.email_cititor = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(42)))), ((int)(((byte)(109)))));
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.titleTop);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 46);
            this.panel1.TabIndex = 15;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Image = global::Library_Management_System.Properties.Resources.macos_minimize_30px;
            this.pictureBox3.Location = new System.Drawing.Point(725, 7);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(30, 30);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 3;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = global::Library_Management_System.Properties.Resources.macos_close_30px;
            this.pictureBox2.Location = new System.Drawing.Point(761, 7);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(30, 30);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // titleTop
            // 
            this.titleTop.AutoSize = true;
            this.titleTop.BackColor = System.Drawing.Color.Transparent;
            this.titleTop.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.titleTop.ForeColor = System.Drawing.Color.White;
            this.titleTop.Location = new System.Drawing.Point(60, 11);
            this.titleTop.Name = "titleTop";
            this.titleTop.Size = new System.Drawing.Size(287, 23);
            this.titleTop.TabIndex = 1;
            this.titleTop.Text = "Library Management System";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::Library_Management_System.Properties.Resources.book;
            this.pictureBox1.Location = new System.Drawing.Point(15, 7);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(35, 35);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // id_cititor
            // 
            this.id_cititor.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.id_cititor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(42)))), ((int)(((byte)(109)))));
            this.id_cititor.Location = new System.Drawing.Point(81, 337);
            this.id_cititor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.id_cititor.Name = "id_cititor";
            this.id_cititor.ReadOnly = true;
            this.id_cititor.Size = new System.Drawing.Size(300, 32);
            this.id_cititor.TabIndex = 38;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(42)))), ((int)(((byte)(109)))));
            this.label1.Location = new System.Drawing.Point(77, 303);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 23);
            this.label1.TabIndex = 37;
            this.label1.Text = "Id";
            // 
            // data_nasterii
            // 
            this.data_nasterii.BackColor = System.Drawing.SystemColors.Window;
            this.data_nasterii.BorderRadius = 0;
            this.data_nasterii.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.data_nasterii.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(42)))), ((int)(((byte)(109)))));
            this.data_nasterii.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.data_nasterii.FormatCustom = null;
            this.data_nasterii.Location = new System.Drawing.Point(412, 529);
            this.data_nasterii.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.data_nasterii.Name = "data_nasterii";
            this.data_nasterii.Size = new System.Drawing.Size(300, 51);
            this.data_nasterii.TabIndex = 36;
            this.data_nasterii.Value = new System.DateTime(2021, 12, 30, 16, 57, 8, 631);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(42)))), ((int)(((byte)(109)))));
            this.label8.Location = new System.Drawing.Point(408, 492);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(131, 23);
            this.label8.TabIndex = 35;
            this.label8.Text = "Data nasterii";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 7.8F);
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(42)))), ((int)(((byte)(109)))));
            this.label7.Location = new System.Drawing.Point(19, 810);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(410, 19);
            this.label7.TabIndex = 34;
            this.label7.Text = "Copyrights © 2021. All right Reserved by LAWRENCIUM DEV.";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(42)))), ((int)(((byte)(109)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(174, 653);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(449, 55);
            this.button1.TabIndex = 33;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // prenume_cititor
            // 
            this.prenume_cititor.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.prenume_cititor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(42)))), ((int)(((byte)(109)))));
            this.prenume_cititor.Location = new System.Drawing.Point(81, 431);
            this.prenume_cititor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.prenume_cititor.Name = "prenume_cititor";
            this.prenume_cititor.Size = new System.Drawing.Size(300, 32);
            this.prenume_cititor.TabIndex = 32;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(42)))), ((int)(((byte)(109)))));
            this.label4.Location = new System.Drawing.Point(78, 401);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 23);
            this.label4.TabIndex = 31;
            this.label4.Text = "Prenume";
            // 
            // nume_cititor
            // 
            this.nume_cititor.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.nume_cititor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(42)))), ((int)(((byte)(109)))));
            this.nume_cititor.Location = new System.Drawing.Point(412, 337);
            this.nume_cititor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nume_cititor.Name = "nume_cititor";
            this.nume_cititor.Size = new System.Drawing.Size(300, 32);
            this.nume_cititor.TabIndex = 30;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(42)))), ((int)(((byte)(109)))));
            this.label3.Location = new System.Drawing.Point(409, 304);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 23);
            this.label3.TabIndex = 29;
            this.label3.Text = "Nume";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 19.8F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(42)))), ((int)(((byte)(109)))));
            this.label2.Location = new System.Drawing.Point(281, 205);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(243, 39);
            this.label2.TabIndex = 28;
            this.label2.Text = "Tabelul Cititori";
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::Library_Management_System.Properties.Resources.book_reading_120px;
            this.pictureBox4.Location = new System.Drawing.Point(339, 75);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(120, 120);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox4.TabIndex = 27;
            this.pictureBox4.TabStop = false;
            // 
            // telefon_cititor
            // 
            this.telefon_cititor.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.telefon_cititor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(42)))), ((int)(((byte)(109)))));
            this.telefon_cititor.Location = new System.Drawing.Point(412, 431);
            this.telefon_cititor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.telefon_cititor.Name = "telefon_cititor";
            this.telefon_cititor.Size = new System.Drawing.Size(300, 32);
            this.telefon_cititor.TabIndex = 40;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(42)))), ((int)(((byte)(109)))));
            this.label5.Location = new System.Drawing.Point(409, 401);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 23);
            this.label5.TabIndex = 39;
            this.label5.Text = "Telefon";
            // 
            // email_cititor
            // 
            this.email_cititor.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.email_cititor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(42)))), ((int)(((byte)(109)))));
            this.email_cititor.Location = new System.Drawing.Point(82, 529);
            this.email_cititor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.email_cititor.Name = "email_cititor";
            this.email_cititor.Size = new System.Drawing.Size(300, 32);
            this.email_cititor.TabIndex = 42;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(38)))), ((int)(((byte)(113)))));
            this.label10.Location = new System.Drawing.Point(79, 499);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(70, 23);
            this.label10.TabIndex = 41;
            this.label10.Text = "E-mail";
            // 
            // EditCititori
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 850);
            this.Controls.Add(this.email_cititor);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.telefon_cititor);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.id_cititor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.data_nasterii);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.prenume_cititor);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.nume_cititor);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "EditCititori";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EditCititori";
            this.Load += new System.EventHandler(this.EditCititori_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        public System.Windows.Forms.Label titleTop;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.TextBox id_cititor;
        private System.Windows.Forms.Label label1;
        public ns1.BunifuDatepicker data_nasterii;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.TextBox prenume_cititor;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox nume_cititor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox4;
        public System.Windows.Forms.TextBox telefon_cititor;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox email_cititor;
        private System.Windows.Forms.Label label10;
    }
}