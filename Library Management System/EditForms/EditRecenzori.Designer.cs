﻿
namespace Library_Management_System.EditForms
{
    partial class EditRecenzori
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
            this.components = new System.ComponentModel.Container();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.titleTop = new System.Windows.Forms.Label();
            this.id_recenzor = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.bunifuElipse1 = new ns1.BunifuElipse(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.prenume_recenzor = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.nume_recenzor = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.email_recenzor = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Image = global::Library_Management_System.Properties.Resources.macos_minimize_30px;
            this.pictureBox3.Location = new System.Drawing.Point(722, 7);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(30, 30);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 3;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = global::Library_Management_System.Properties.Resources.macos_close_30px;
            this.pictureBox2.Location = new System.Drawing.Point(758, 7);
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
            // id_recenzor
            // 
            this.id_recenzor.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.id_recenzor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(42)))), ((int)(((byte)(109)))));
            this.id_recenzor.Location = new System.Drawing.Point(168, 334);
            this.id_recenzor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.id_recenzor.Name = "id_recenzor";
            this.id_recenzor.ReadOnly = true;
            this.id_recenzor.Size = new System.Drawing.Size(449, 32);
            this.id_recenzor.TabIndex = 39;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(42)))), ((int)(((byte)(109)))));
            this.label1.Location = new System.Drawing.Point(165, 301);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 23);
            this.label1.TabIndex = 38;
            this.label1.Text = "Id";
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
            this.panel1.TabIndex = 27;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
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
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 7.8F);
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(42)))), ((int)(((byte)(109)))));
            this.label7.Location = new System.Drawing.Point(12, 827);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(410, 19);
            this.label7.TabIndex = 35;
            this.label7.Text = "Copyrights © 2021. All right Reserved by LAWRENCIUM DEV.";
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 10;
            this.bunifuElipse1.TargetControl = this;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(42)))), ((int)(((byte)(109)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(167, 670);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(449, 55);
            this.button1.TabIndex = 34;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // prenume_recenzor
            // 
            this.prenume_recenzor.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.prenume_recenzor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(42)))), ((int)(((byte)(109)))));
            this.prenume_recenzor.Location = new System.Drawing.Point(167, 503);
            this.prenume_recenzor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.prenume_recenzor.Name = "prenume_recenzor";
            this.prenume_recenzor.Size = new System.Drawing.Size(449, 32);
            this.prenume_recenzor.TabIndex = 33;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(42)))), ((int)(((byte)(109)))));
            this.label4.Location = new System.Drawing.Point(164, 473);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 23);
            this.label4.TabIndex = 32;
            this.label4.Text = "Prenume";
            // 
            // nume_recenzor
            // 
            this.nume_recenzor.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.nume_recenzor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(42)))), ((int)(((byte)(109)))));
            this.nume_recenzor.Location = new System.Drawing.Point(167, 422);
            this.nume_recenzor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nume_recenzor.Name = "nume_recenzor";
            this.nume_recenzor.Size = new System.Drawing.Size(449, 32);
            this.nume_recenzor.TabIndex = 31;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(42)))), ((int)(((byte)(109)))));
            this.label3.Location = new System.Drawing.Point(164, 389);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 23);
            this.label3.TabIndex = 30;
            this.label3.Text = "Nume";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 19.8F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(42)))), ((int)(((byte)(109)))));
            this.label2.Location = new System.Drawing.Point(246, 222);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(298, 39);
            this.label2.TabIndex = 29;
            this.label2.Text = "Tabelul Recenzori";
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::Library_Management_System.Properties.Resources.book_reading_120px;
            this.pictureBox4.Location = new System.Drawing.Point(332, 95);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(120, 120);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox4.TabIndex = 28;
            this.pictureBox4.TabStop = false;
            // 
            // email_recenzor
            // 
            this.email_recenzor.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.email_recenzor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(42)))), ((int)(((byte)(109)))));
            this.email_recenzor.Location = new System.Drawing.Point(167, 586);
            this.email_recenzor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.email_recenzor.Name = "email_recenzor";
            this.email_recenzor.Size = new System.Drawing.Size(449, 32);
            this.email_recenzor.TabIndex = 41;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(42)))), ((int)(((byte)(109)))));
            this.label5.Location = new System.Drawing.Point(164, 556);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 23);
            this.label5.TabIndex = 40;
            this.label5.Text = "E-mail";
            // 
            // EditRecenzori
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 850);
            this.Controls.Add(this.email_recenzor);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.id_recenzor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.prenume_recenzor);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.nume_recenzor);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "EditRecenzori";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EditRecenzori";
            this.Load += new System.EventHandler(this.EditRecenzori_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        public System.Windows.Forms.Label titleTop;
        public System.Windows.Forms.TextBox id_recenzor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label7;
        private ns1.BunifuElipse bunifuElipse1;
        public System.Windows.Forms.TextBox email_recenzor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.TextBox prenume_recenzor;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox nume_recenzor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox4;
    }
}