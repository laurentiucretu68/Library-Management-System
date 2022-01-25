
namespace Library_Management_System.UserControls
{
    partial class Admin_Users
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.continutTab = new ns1.BunifuCustomDataGrid();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.comboTabele = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.sorteaza = new System.Windows.Forms.ComboBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.continutTab)).BeginInit();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1270, 20);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(1250, 20);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(20, 740);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 20);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(20, 720);
            this.panel3.TabIndex = 3;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.continutTab);
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(20, 20);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1230, 720);
            this.panel4.TabIndex = 4;
            // 
            // continutTab
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.continutTab.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.continutTab.BackgroundColor = System.Drawing.Color.White;
            this.continutTab.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.continutTab.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.continutTab.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.continutTab.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.continutTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.continutTab.DoubleBuffered = true;
            this.continutTab.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.continutTab.EnableHeadersVisualStyles = false;
            this.continutTab.GridColor = System.Drawing.Color.White;
            this.continutTab.HeaderBgColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.continutTab.HeaderForeColor = System.Drawing.Color.Black;
            this.continutTab.Location = new System.Drawing.Point(0, 82);
            this.continutTab.Name = "continutTab";
            this.continutTab.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.continutTab.RowHeadersWidth = 51;
            this.continutTab.RowTemplate.Height = 24;
            this.continutTab.Size = new System.Drawing.Size(1230, 638);
            this.continutTab.TabIndex = 13;
            this.continutTab.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.continutTab_CellContentClick);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(42)))), ((int)(((byte)(109)))));
            this.panel5.Controls.Add(this.label2);
            this.panel5.Controls.Add(this.comboTabele);
            this.panel5.Controls.Add(this.label3);
            this.panel5.Controls.Add(this.sorteaza);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1230, 82);
            this.panel5.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(38, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 23);
            this.label2.TabIndex = 11;
            this.label2.Text = "Tabel:";
            // 
            // comboTabele
            // 
            this.comboTabele.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboTabele.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.comboTabele.FormattingEnabled = true;
            this.comboTabele.Location = new System.Drawing.Point(112, 25);
            this.comboTabele.Name = "comboTabele";
            this.comboTabele.Size = new System.Drawing.Size(163, 29);
            this.comboTabele.TabIndex = 10;
            this.comboTabele.SelectedValueChanged += new System.EventHandler(this.comboTabele_SelectedValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(316, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 23);
            this.label3.TabIndex = 7;
            this.label3.Text = "Sorteaza:";
            // 
            // sorteaza
            // 
            this.sorteaza.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sorteaza.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.sorteaza.FormattingEnabled = true;
            this.sorteaza.Items.AddRange(new object[] {
            "Crescator dupa id",
            "Descrescator dupa id",
            "Crescator dupa nume",
            "Descrescator dupa nume"});
            this.sorteaza.Location = new System.Drawing.Point(414, 25);
            this.sorteaza.Name = "sorteaza";
            this.sorteaza.Size = new System.Drawing.Size(250, 29);
            this.sorteaza.TabIndex = 1;
            this.sorteaza.SelectedValueChanged += new System.EventHandler(this.sorteaza_SelectedValueChanged);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 740);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1250, 20);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // Admin_Users
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Admin_Users";
            this.Size = new System.Drawing.Size(1270, 760);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.continutTab)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox sorteaza;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboTabele;
        private ns1.BunifuCustomDataGrid continutTab;
    }
}
