namespace YonetimSistemi
{
    partial class EmanetListesi
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
            dataGridView1 = new DataGridView();
            panel2 = new Panel();
            label5 = new Label();
            label1 = new Label();
            comboBox1 = new ComboBox();
            Ara = new Button();
            textBox1 = new TextBox();
            button1 = new Button();
            panel1 = new Panel();
            textBox4 = new TextBox();
            label4 = new Label();
            button3 = new Button();
            label3 = new Label();
            label6 = new Label();
            panel3 = new Panel();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(3, 49);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(1200, 357);
            dataGridView1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(label5);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(comboBox1);
            panel2.Controls.Add(Ara);
            panel2.Controls.Add(textBox1);
            panel2.Controls.Add(dataGridView1);
            panel2.Location = new Point(3, 230);
            panel2.Name = "panel2";
            panel2.Size = new Size(1208, 412);
            panel2.TabIndex = 5;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(25, 19);
            label5.Name = "label5";
            label5.Size = new Size(56, 20);
            label5.TabIndex = 10;
            label5.Text = "Kısım :";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(245, 15);
            label1.Name = "label1";
            label1.Size = new Size(64, 20);
            label1.TabIndex = 9;
            label1.Text = "Arama :";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(87, 12);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(151, 28);
            comboBox1.TabIndex = 8;
            // 
            // Ara
            // 
            Ara.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            Ara.Location = new Point(461, 10);
            Ara.Name = "Ara";
            Ara.Size = new Size(118, 29);
            Ara.TabIndex = 7;
            Ara.Text = "Bul";
            Ara.UseVisualStyleBackColor = true;
            Ara.Click += Ara_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(315, 12);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 6;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            button1.Location = new Point(305, 132);
            button1.Name = "button1";
            button1.Size = new Size(170, 46);
            button1.TabIndex = 23;
            button1.Text = "Menü";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(button1);
            panel1.Controls.Add(textBox4);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(button3);
            panel1.Location = new Point(321, 15);
            panel1.Name = "panel1";
            panel1.Size = new Size(562, 204);
            panel1.TabIndex = 6;
            panel1.Paint += panel1_Paint;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(220, 67);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(226, 27);
            textBox4.TabIndex = 11;
            textBox4.KeyPress += textBox4_KeyPress;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(124, 70);
            label4.Name = "label4";
            label4.Size = new Size(90, 20);
            label4.TabIndex = 10;
            label4.Text = "Emanet ID :";
            label4.Click += label4_Click;
            // 
            // button3
            // 
            button3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            button3.Location = new Point(115, 132);
            button3.Name = "button3";
            button3.Size = new Size(170, 46);
            button3.TabIndex = 9;
            button3.Text = "Teslim Al";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click_2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(21, 220);
            label3.Name = "label3";
            label3.Size = new Size(110, 20);
            label3.TabIndex = 11;
            label3.Text = "Emanet Listesi";
            label3.Click += label3_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label6.Location = new Point(325, 6);
            label6.Name = "label6";
            label6.Size = new Size(130, 20);
            label6.TabIndex = 12;
            label6.Text = "Emanet Teslim Al";
            // 
            // panel3
            // 
            panel3.Controls.Add(label6);
            panel3.Controls.Add(label3);
            panel3.Controls.Add(panel1);
            panel3.Controls.Add(panel2);
            panel3.Location = new Point(4, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(1229, 645);
            panel3.TabIndex = 13;
            // 
            // EmanetListesi
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1232, 653);
            Controls.Add(panel3);
            Name = "EmanetListesi";
            Text = "EmanetListesi";
            FormClosing += EmanetListesi_FormClosing;
            Load += EmanetListesi_Load;
            Resize += EmanetListesi_Resize;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private DataGridView dataGridView1;
        private Panel panel2;
        private Button button1;
        private Panel panel1;
        private TextBox textBox4;
        private Label label4;
        private Button button3;
        private Label label5;
        private Label label1;
        private ComboBox comboBox1;
        private Button Ara;
        private TextBox textBox1;
        private Label label3;
        private Label label6;
        private Panel panel3;
    }
}