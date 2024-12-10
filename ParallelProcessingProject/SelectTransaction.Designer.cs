namespace ParallelProcessingProject
{
    partial class SelectTransaction
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectTransaction));
            button2 = new Button();
            button1 = new Button();
            button3 = new Button();
            button4 = new Button();
            button6 = new Button();
            pictureBox1 = new PictureBox();
            panel1 = new Panel();
            label5 = new Label();
            button5 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // button2
            // 
            button2.BackColor = SystemColors.GradientActiveCaption;
            button2.Font = new Font("Microsoft YaHei UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.ForeColor = SystemColors.Highlight;
            button2.Location = new Point(68, 238);
            button2.Name = "button2";
            button2.Size = new Size(196, 52);
            button2.TabIndex = 4;
            button2.Text = "Deposit";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.GradientActiveCaption;
            button1.Font = new Font("Microsoft YaHei UI", 13.8F, FontStyle.Bold);
            button1.ForeColor = SystemColors.Highlight;
            button1.Location = new Point(68, 308);
            button1.Name = "button1";
            button1.Size = new Size(196, 56);
            button1.TabIndex = 4;
            button1.Text = "Check Balance";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button3
            // 
            button3.BackColor = SystemColors.GradientActiveCaption;
            button3.Font = new Font("Microsoft YaHei UI", 13.8F, FontStyle.Bold);
            button3.ForeColor = SystemColors.Highlight;
            button3.Location = new Point(605, 288);
            button3.Name = "button3";
            button3.Size = new Size(205, 56);
            button3.TabIndex = 4;
            button3.Text = "Mini Statement";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.BackColor = SystemColors.GradientActiveCaption;
            button4.Font = new Font("Microsoft YaHei UI", 13.8F, FontStyle.Bold);
            button4.ForeColor = SystemColors.Highlight;
            button4.Location = new Point(337, 497);
            button4.Name = "button4";
            button4.Size = new Size(177, 45);
            button4.TabIndex = 4;
            button4.Text = "Log out";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // button6
            // 
            button6.BackColor = SystemColors.GradientActiveCaption;
            button6.Font = new Font("Microsoft YaHei UI", 13.8F, FontStyle.Bold);
            button6.ForeColor = SystemColors.Highlight;
            button6.Location = new Point(605, 220);
            button6.Name = "button6";
            button6.Size = new Size(205, 52);
            button6.TabIndex = 4;
            button6.Text = "Withdraw";
            button6.UseVisualStyleBackColor = false;
            button6.Click += button6_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(270, 95);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(329, 386);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Highlight;
            panel1.Dock = DockStyle.Bottom;
            panel1.ForeColor = SystemColors.Highlight;
            panel1.Location = new Point(0, 561);
            panel1.Name = "panel1";
            panel1.Size = new Size(879, 14);
            panel1.TabIndex = 6;
            panel1.Paint += panel1_Paint;
            // 
            // label5
            // 
            label5.BackColor = SystemColors.Highlight;
            label5.Font = new Font("Microsoft New Tai Lue", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.White;
            label5.Location = new Point(0, 2);
            label5.Name = "label5";
            label5.Size = new Size(879, 57);
            label5.TabIndex = 11;
            label5.Text = "Select Your Transaction Please\r\n";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // button5
            // 
            button5.BackColor = SystemColors.GradientActiveCaption;
            button5.Font = new Font("Microsoft YaHei UI", 13.8F, FontStyle.Bold);
            button5.ForeColor = SystemColors.Highlight;
            button5.Location = new Point(605, 359);
            button5.Name = "button5";
            button5.Size = new Size(205, 56);
            button5.TabIndex = 12;
            button5.Text = "Change PIN";
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // SelectTransaction
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(879, 575);
            Controls.Add(button5);
            Controls.Add(label5);
            Controls.Add(panel1);
            Controls.Add(pictureBox1);
            Controls.Add(button6);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button1);
            Controls.Add(button2);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Name = "SelectTransaction";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SelectTransaction";
            Load += SelectTransaction_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Button button2;
        private Button button1;
        private Button button3;
        private Button button4;
        private Button button6;
        private PictureBox pictureBox1;
        private Panel panel1;
        private Label label5;
        private Button button5;
    }
}