namespace ParallelProcessingProject
{
    partial class AddUser
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
            username = new TextBox();
            pin = new TextBox();
            balance = new TextBox();
            role = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            button4 = new Button();
            label5 = new Label();
            label6 = new Label();
            button1 = new Button();
            panel1 = new Panel();
            usernameerr = new Label();
            pinerr = new Label();
            balanceerr = new Label();
            roleerr = new Label();
            label7 = new Label();
            getallusers = new DataGridView();
            button5 = new Button();
            button6 = new Button();
            ((System.ComponentModel.ISupportInitialize)getallusers).BeginInit();
            SuspendLayout();
            // 
            // username
            // 
            username.Location = new Point(194, 142);
            username.Multiline = true;
            username.Name = "username";
            username.Size = new Size(247, 40);
            username.TabIndex = 0;
            username.TextChanged += username_TextChanged;
            // 
            // pin
            // 
            pin.Location = new Point(194, 333);
            pin.Name = "pin";
            pin.PasswordChar = '*';
            pin.Size = new Size(247, 27);
            pin.TabIndex = 0;
            pin.UseSystemPasswordChar = true;
            // 
            // balance
            // 
            balance.Location = new Point(194, 244);
            balance.Multiline = true;
            balance.Name = "balance";
            balance.Size = new Size(247, 35);
            balance.TabIndex = 0;
            // 
            // role
            // 
            role.FormattingEnabled = true;
            role.Items.AddRange(new object[] { "User", "Admin" });
            role.Location = new Point(194, 413);
            role.Name = "role";
            role.Size = new Size(247, 28);
            role.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Tai Le", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.Highlight;
            label1.Location = new Point(26, 156);
            label1.Name = "label1";
            label1.Size = new Size(120, 29);
            label1.TabIndex = 2;
            label1.Text = "Username";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Tai Le", 13.8F, FontStyle.Bold);
            label2.ForeColor = SystemColors.Highlight;
            label2.Location = new Point(26, 333);
            label2.Name = "label2";
            label2.Size = new Size(52, 29);
            label2.TabIndex = 2;
            label2.Text = "PIN";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Tai Le", 13.8F, FontStyle.Bold);
            label3.ForeColor = SystemColors.Highlight;
            label3.Location = new Point(26, 244);
            label3.Name = "label3";
            label3.Size = new Size(96, 29);
            label3.TabIndex = 2;
            label3.Text = "Balance";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = SystemColors.ActiveCaptionText;
            label4.Font = new Font("Microsoft Tai Le", 13.8F, FontStyle.Bold);
            label4.ForeColor = SystemColors.HighlightText;
            label4.Location = new Point(0, 72);
            label4.Name = "label4";
            label4.Size = new Size(85, 29);
            label4.TabIndex = 2;
            label4.Text = "Admin";
            label4.Click += label4_Click;
            // 
            // button4
            // 
            button4.BackColor = SystemColors.GradientActiveCaption;
            button4.Font = new Font("Microsoft YaHei UI", 13.8F, FontStyle.Bold);
            button4.ForeColor = SystemColors.Highlight;
            button4.Location = new Point(17, 506);
            button4.Name = "button4";
            button4.Size = new Size(177, 45);
            button4.TabIndex = 5;
            button4.Text = "Add";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // label5
            // 
            label5.BackColor = SystemColors.Highlight;
            label5.Font = new Font("Microsoft New Tai Lue", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.White;
            label5.Location = new Point(0, -6);
            label5.Name = "label5";
            label5.Size = new Size(1340, 78);
            label5.TabIndex = 6;
            label5.Text = "ATM Management System";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Tai Le", 13.8F, FontStyle.Bold);
            label6.ForeColor = SystemColors.Highlight;
            label6.Location = new Point(26, 413);
            label6.Name = "label6";
            label6.Size = new Size(61, 29);
            label6.TabIndex = 2;
            label6.Text = "Role";
            // 
            // button1
            // 
            button1.BackColor = SystemColors.GradientActiveCaption;
            button1.Font = new Font("Microsoft YaHei UI", 13.8F, FontStyle.Bold);
            button1.ForeColor = SystemColors.Highlight;
            button1.Location = new Point(149, 593);
            button1.Name = "button1";
            button1.Size = new Size(177, 45);
            button1.TabIndex = 5;
            button1.Text = "Log Out";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Highlight;
            panel1.Dock = DockStyle.Bottom;
            panel1.ForeColor = SystemColors.Highlight;
            panel1.Location = new Point(0, 684);
            panel1.Name = "panel1";
            panel1.Size = new Size(1323, 14);
            panel1.TabIndex = 7;
            // 
            // usernameerr
            // 
            usernameerr.AutoSize = true;
            usernameerr.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            usernameerr.ForeColor = Color.Red;
            usernameerr.Location = new Point(203, 185);
            usernameerr.Name = "usernameerr";
            usernameerr.Size = new Size(0, 23);
            usernameerr.TabIndex = 8;
            // 
            // pinerr
            // 
            pinerr.AutoSize = true;
            pinerr.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            pinerr.ForeColor = Color.Red;
            pinerr.Location = new Point(194, 359);
            pinerr.Name = "pinerr";
            pinerr.Size = new Size(0, 23);
            pinerr.TabIndex = 8;
            // 
            // balanceerr
            // 
            balanceerr.AutoSize = true;
            balanceerr.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            balanceerr.ForeColor = Color.Red;
            balanceerr.Location = new Point(194, 282);
            balanceerr.Name = "balanceerr";
            balanceerr.Size = new Size(0, 23);
            balanceerr.TabIndex = 8;
            balanceerr.Click += label8_Click;
            // 
            // roleerr
            // 
            roleerr.AutoSize = true;
            roleerr.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            roleerr.ForeColor = Color.Red;
            roleerr.Location = new Point(194, 446);
            roleerr.Name = "roleerr";
            roleerr.Size = new Size(0, 23);
            roleerr.TabIndex = 8;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft Tai Le", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = SystemColors.GrayText;
            label7.Location = new Point(1006, 24);
            label7.Name = "label7";
            label7.Size = new Size(153, 29);
            label7.TabIndex = 12;
            label7.Text = "Manage User";
            // 
            // getallusers
            // 
            getallusers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            getallusers.Location = new Point(467, 109);
            getallusers.Name = "getallusers";
            getallusers.RowHeadersWidth = 51;
            getallusers.Size = new Size(822, 456);
            getallusers.TabIndex = 13;
            getallusers.CellClick += getallusers_CellClick;
            getallusers.CellContentClick += getallusers_CellContentClick;
            // 
            // button5
            // 
            button5.BackColor = SystemColors.GradientActiveCaption;
            button5.Font = new Font("Microsoft YaHei UI", 13.8F, FontStyle.Bold);
            button5.ForeColor = SystemColors.Highlight;
            button5.Location = new Point(755, 607);
            button5.Name = "button5";
            button5.Size = new Size(318, 45);
            button5.TabIndex = 14;
            button5.Text = "TransactionsByDate";
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.BackColor = SystemColors.GradientActiveCaption;
            button6.Font = new Font("Microsoft YaHei UI", 13.8F, FontStyle.Bold);
            button6.ForeColor = SystemColors.Highlight;
            button6.Location = new Point(264, 506);
            button6.Name = "button6";
            button6.Size = new Size(177, 45);
            button6.TabIndex = 15;
            button6.Text = "Delete";
            button6.UseVisualStyleBackColor = false;
            button6.Click += button6_Click;
            // 
            // AddUser
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1323, 698);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(getallusers);
            Controls.Add(label7);
            Controls.Add(roleerr);
            Controls.Add(balanceerr);
            Controls.Add(pinerr);
            Controls.Add(usernameerr);
            Controls.Add(panel1);
            Controls.Add(label5);
            Controls.Add(button1);
            Controls.Add(button4);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label6);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(role);
            Controls.Add(balance);
            Controls.Add(pin);
            Controls.Add(username);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Name = "AddUser";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AddUser";
            Load += AddUser_Load;
            ((System.ComponentModel.ISupportInitialize)getallusers).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox username;
        private TextBox pin;
        private TextBox balance;
        private ComboBox role;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button button4;
        private Label label5;
        private Label label6;
        private Button button1;
        private Panel panel1;
        private Label usernameerr;
        private Label pinerr;
        private Label balanceerr;
        private Label roleerr;
        private Label label7;
        private DataGridView getallusers;
        private Button button5;
        private Button button6;
    }
}