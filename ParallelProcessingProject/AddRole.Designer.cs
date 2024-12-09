namespace ParallelProcessingProject
{
    partial class AddRole
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
            label5 = new Label();
            label4 = new Label();
            rolename = new TextBox();
            label2 = new Label();
            label1 = new Label();
            button4 = new Button();
            rolee = new Label();
            SuspendLayout();
            // 
            // label5
            // 
            label5.BackColor = SystemColors.Highlight;
            label5.Font = new Font("Microsoft New Tai Lue", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.White;
            label5.Location = new Point(-8, 0);
            label5.Name = "label5";
            label5.Size = new Size(510, 78);
            label5.TabIndex = 7;
            label5.Text = "ATM Management System";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Tai Le", 13.8F, FontStyle.Bold);
            label4.ForeColor = SystemColors.Highlight;
            label4.Location = new Point(390, 78);
            label4.Name = "label4";
            label4.Size = new Size(85, 29);
            label4.TabIndex = 8;
            label4.Text = "Admin";
            // 
            // rolename
            // 
            rolename.Location = new Point(228, 223);
            rolename.Multiline = true;
            rolename.Name = "rolename";
            rolename.Size = new Size(247, 40);
            rolename.TabIndex = 9;
            rolename.TextChanged += username_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Tai Le", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.Highlight;
            label2.Location = new Point(53, 234);
            label2.Name = "label2";
            label2.Size = new Size(130, 29);
            label2.TabIndex = 10;
            label2.Text = "Role Name";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Tai Le", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.GrayText;
            label1.Location = new Point(163, 92);
            label1.Name = "label1";
            label1.Size = new Size(165, 29);
            label1.TabIndex = 11;
            label1.Text = "Add New Role";
            // 
            // button4
            // 
            button4.BackColor = SystemColors.GradientActiveCaption;
            button4.Font = new Font("Microsoft YaHei UI", 13.8F, FontStyle.Bold);
            button4.ForeColor = SystemColors.Highlight;
            button4.Location = new Point(151, 348);
            button4.Name = "button4";
            button4.Size = new Size(177, 45);
            button4.TabIndex = 12;
            button4.Text = "Add";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // rolee
            // 
            rolee.AutoSize = true;
            rolee.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rolee.ForeColor = Color.Red;
            rolee.Location = new Point(228, 266);
            rolee.Name = "rolee";
            rolee.Size = new Size(0, 23);
            rolee.TabIndex = 13;
            // 
            // AddRole
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(499, 450);
            Controls.Add(rolee);
            Controls.Add(button4);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(rolename);
            Controls.Add(label4);
            Controls.Add(label5);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Name = "AddRole";
            Text = "AddRole";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label5;
        private Label label4;
        private TextBox rolename;
        private Label label2;
        private Label label1;
        private Button button4;
        private Label rolee;
    }
}