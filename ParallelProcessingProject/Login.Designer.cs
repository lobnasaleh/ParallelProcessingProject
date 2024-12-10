namespace ParallelProcessingProject
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            panel1 = new Panel();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            Id = new TextBox();
            Password = new TextBox();
            button1 = new Button();
            pictureBox1 = new PictureBox();
            checkpassword = new Label();
            checkId = new Label();
            Invalid = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Highlight;
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(768, 79);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.Highlight;
            label1.Font = new Font("Microsoft New Tai Lue", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(82, 9);
            label1.Name = "label1";
            label1.Size = new Size(522, 52);
            label1.TabIndex = 1;
            label1.Text = "ATM Management System";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft New Tai Lue", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.Highlight;
            label2.Location = new Point(626, 79);
            label2.Name = "label2";
            label2.Size = new Size(142, 58);
            label2.TabIndex = 1;
            label2.Text = "Login";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft New Tai Lue", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.Highlight;
            label3.Location = new Point(270, 125);
            label3.Name = "label3";
            label3.Size = new Size(349, 45);
            label3.TabIndex = 1;
            label3.Text = "Identification Number";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft New Tai Lue", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = SystemColors.Highlight;
            label4.Location = new Point(270, 228);
            label4.Name = "label4";
            label4.Size = new Size(161, 45);
            label4.TabIndex = 1;
            label4.Text = "Password";
            label4.Click += label3_Click;
            // 
            // Id
            // 
            Id.Location = new Point(270, 173);
            Id.Multiline = true;
            Id.Name = "Id";
            Id.Size = new Size(334, 29);
            Id.TabIndex = 2;
            Id.TextChanged += Id_TextChanged;
            // 
            // Password
            // 
            Password.Location = new Point(270, 276);
            Password.Name = "Password";
            Password.PasswordChar = '*';
            Password.Size = new Size(334, 27);
            Password.TabIndex = 2;
            Password.UseSystemPasswordChar = true;
            Password.TextChanged += Password_TextChanged;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.GradientActiveCaption;
            button1.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = SystemColors.Highlight;
            button1.Location = new Point(327, 380);
            button1.Name = "button1";
            button1.Size = new Size(113, 45);
            button1.TabIndex = 3;
            button1.Text = "Login";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(12, 145);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(179, 196);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // checkpassword
            // 
            checkpassword.AutoSize = true;
            checkpassword.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            checkpassword.ForeColor = Color.Red;
            checkpassword.Location = new Point(270, 306);
            checkpassword.Name = "checkpassword";
            checkpassword.Size = new Size(0, 23);
            checkpassword.TabIndex = 5;
            // 
            // checkId
            // 
            checkId.AutoSize = true;
            checkId.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            checkId.ForeColor = Color.Red;
            checkId.Location = new Point(270, 205);
            checkId.Name = "checkId";
            checkId.Size = new Size(0, 23);
            checkId.TabIndex = 5;
            // 
            // Invalid
            // 
            Invalid.AutoSize = true;
            Invalid.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Invalid.ForeColor = Color.Red;
            Invalid.Location = new Point(312, 348);
            Invalid.Name = "Invalid";
            Invalid.Size = new Size(0, 28);
            Invalid.TabIndex = 6;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(768, 437);
            Controls.Add(Invalid);
            Controls.Add(checkId);
            Controls.Add(checkpassword);
            Controls.Add(pictureBox1);
            Controls.Add(button1);
            Controls.Add(Password);
            Controls.Add(Id);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            FormClosing += Login_FormClosing;
            Load += Login_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox Id;
        private TextBox Password;
        private Button button1;
        private PictureBox pictureBox1;
        private Label checkpassword;
        private Label checkId;
        private Label Invalid;
    }
}