namespace YonetimSistemi
{
    partial class KullanıcıForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KullanıcıForm));
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button6 = new Button();
            button1 = new Button();
            pictureBox1 = new PictureBox();
            label2 = new Label();
            label1 = new Label();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            button2.Location = new Point(15, 122);
            button2.Name = "button2";
            button2.Size = new Size(330, 43);
            button2.TabIndex = 2;
            button2.Text = "Evrak Listesi";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            button3.Location = new Point(15, 221);
            button3.Name = "button3";
            button3.Size = new Size(330, 43);
            button3.TabIndex = 3;
            button3.Text = "Emanet Listesi";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            button4.Location = new Point(15, 419);
            button4.Name = "button4";
            button4.Size = new Size(330, 43);
            button4.TabIndex = 4;
            button4.Text = "İstatistikler";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button6
            // 
            button6.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            button6.Location = new Point(15, 514);
            button6.Name = "button6";
            button6.Size = new Size(330, 43);
            button6.TabIndex = 6;
            button6.Text = "Çıkış";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            button1.Location = new Point(15, 322);
            button1.Name = "button1";
            button1.Size = new Size(330, 43);
            button1.TabIndex = 7;
            button1.Text = "Evrak Sorgula";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(370, 123);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(295, 435);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(229, 62);
            label2.Name = "label2";
            label2.Size = new Size(194, 30);
            label2.TabIndex = 13;
            label2.Text = "Kullanıcı İşlemleri";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(191, 20);
            label1.Name = "label1";
            label1.Size = new Size(272, 30);
            label1.TabIndex = 12;
            label1.Text = "BELGE YÖNETİM SİSTEMİ";
            // 
            // panel1
            // 
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(button4);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(button6);
            panel1.Location = new Point(2, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(684, 580);
            panel1.TabIndex = 14;
            // 
            // KullanıcıForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(698, 592);
            Controls.Add(panel1);
            Name = "KullanıcıForm";
            Text = "KullanıcıForm";
            FormClosing += KullanıcıForm_FormClosing;
            Load += KullanıcıForm_Load;
            Resize += KullanıcıForm_Resize;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button button2;
        private Button button3;
        private Button button4;
        private Button button6;
        private Button button1;
        private PictureBox pictureBox1;
        private Label label2;
        private Label label1;
        private Panel panel1;
    }
}