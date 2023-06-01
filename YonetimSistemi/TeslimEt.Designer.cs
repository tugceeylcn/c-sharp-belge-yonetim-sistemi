namespace YonetimSistemi
{
    partial class TeslimEt
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
            panel2 = new Panel();
            label5 = new Label();
            label4 = new Label();
            comboBox1 = new ComboBox();
            Ara = new Button();
            textBox4 = new TextBox();
            dataGridView1 = new DataGridView();
            panel1 = new Panel();
            button1 = new Button();
            button6 = new Button();
            textBox3 = new TextBox();
            label3 = new Label();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            label2 = new Label();
            label1 = new Label();
            label6 = new Label();
            label7 = new Label();
            panel3 = new Panel();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(label5);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(comboBox1);
            panel2.Controls.Add(Ara);
            panel2.Controls.Add(textBox4);
            panel2.Controls.Add(dataGridView1);
            panel2.Location = new Point(13, 237);
            panel2.Name = "panel2";
            panel2.Size = new Size(1208, 412);
            panel2.TabIndex = 4;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(21, 22);
            label5.Name = "label5";
            label5.Size = new Size(56, 20);
            label5.TabIndex = 5;
            label5.Text = "Kısım :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(252, 22);
            label4.Name = "label4";
            label4.Size = new Size(64, 20);
            label4.TabIndex = 4;
            label4.Text = "Arama :";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(83, 15);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(151, 28);
            comboBox1.TabIndex = 3;
            // 
            // Ara
            // 
            Ara.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            Ara.Location = new Point(458, 13);
            Ara.Name = "Ara";
            Ara.Size = new Size(118, 29);
            Ara.TabIndex = 2;
            Ara.Text = "Bul";
            Ara.UseVisualStyleBackColor = true;
            Ara.Click += button1_Click;
            // 
            // textBox4
            // 
            textBox4.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            textBox4.Location = new Point(327, 15);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(125, 27);
            textBox4.TabIndex = 1;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(3, 51);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(1200, 357);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(button1);
            panel1.Controls.Add(button6);
            panel1.Controls.Add(textBox3);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(textBox2);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(298, 15);
            panel1.Name = "panel1";
            panel1.Size = new Size(608, 204);
            panel1.TabIndex = 5;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            button1.Location = new Point(408, 150);
            button1.Name = "button1";
            button1.Size = new Size(170, 46);
            button1.TabIndex = 16;
            button1.Text = "Menü";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // button6
            // 
            button6.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            button6.Location = new Point(225, 150);
            button6.Name = "button6";
            button6.Size = new Size(170, 46);
            button6.TabIndex = 15;
            button6.Text = "Emanet Et";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(210, 110);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(351, 27);
            textBox3.TabIndex = 14;
            textBox3.KeyPress += textBox3_KeyPress;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(42, 113);
            label3.Name = "label3";
            label3.Size = new Size(162, 20);
            label3.TabIndex = 13;
            label3.Text = "Emanet Alan İletişim :";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(210, 70);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(351, 27);
            textBox2.TabIndex = 12;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(210, 37);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(351, 27);
            textBox1.TabIndex = 11;
            textBox1.KeyPress += textBox1_KeyPress;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(28, 73);
            label2.Name = "label2";
            label2.Size = new Size(176, 20);
            label2.TabIndex = 10;
            label2.Text = "Emanet Alan Ad Soyad :";
            label2.Click += label2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(129, 37);
            label1.Name = "label1";
            label1.Size = new Size(75, 20);
            label1.TabIndex = 9;
            label1.Text = "Evrak ID :";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label6.Location = new Point(311, 7);
            label6.Name = "label6";
            label6.Size = new Size(122, 20);
            label6.TabIndex = 6;
            label6.Text = "Evrak Emanet Et";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label7.Location = new Point(27, 230);
            label7.Name = "label7";
            label7.Size = new Size(95, 20);
            label7.TabIndex = 7;
            label7.Text = "Evrak Listesi";
            // 
            // panel3
            // 
            panel3.Controls.Add(label6);
            panel3.Controls.Add(panel1);
            panel3.Controls.Add(label7);
            panel3.Controls.Add(panel2);
            panel3.Location = new Point(3, 2);
            panel3.Name = "panel3";
            panel3.Size = new Size(1227, 650);
            panel3.TabIndex = 8;
            // 
            // TeslimEt
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1232, 653);
            Controls.Add(panel3);
            Name = "TeslimEt";
            Text = "TeslimEt";
            FormClosing += TeslimEt_FormClosing;
            Load += TeslimEt_Load;
            Resize += TeslimEt_Resize;
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel2;
        private DataGridView dataGridView1;
        private Panel panel1;
        private Button button6;
        private TextBox textBox3;
        private Label label3;
        private TextBox textBox2;
        private TextBox textBox1;
        private Label label2;
        private Label label1;
        private Button Ara;
        private TextBox textBox4;
        private ComboBox comboBox1;
        private Label label4;
        private Label label5;
        private Button button1;
        private Label label6;
        private Label label7;
        private Panel panel3;
    }
}