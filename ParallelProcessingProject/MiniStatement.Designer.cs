namespace ParallelProcessingProject
{
    partial class MiniStatement
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
            Ministgrid = new DataGridView();
            panel1 = new Panel();
            label5 = new Label();
            button2 = new Button();
            button1 = new Button();
            label1 = new Label();
            AccNum = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)Ministgrid).BeginInit();
            SuspendLayout();
            // 
            // Ministgrid
            // 
            Ministgrid.AllowUserToAddRows = false;
            Ministgrid.AllowUserToDeleteRows = false;
            Ministgrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Ministgrid.GridColor = SystemColors.MenuBar;
            Ministgrid.Location = new Point(42, 163);
            Ministgrid.Name = "Ministgrid";
            Ministgrid.ReadOnly = true;
            Ministgrid.RowHeadersWidth = 51;
            Ministgrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            Ministgrid.Size = new Size(662, 365);
            Ministgrid.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Highlight;
            panel1.Dock = DockStyle.Bottom;
            panel1.ForeColor = SystemColors.Highlight;
            panel1.Location = new Point(0, 614);
            panel1.Name = "panel1";
            panel1.Size = new Size(764, 14);
            panel1.TabIndex = 9;
            // 
            // label5
            // 
            label5.BackColor = SystemColors.Highlight;
            label5.Font = new Font("Microsoft New Tai Lue", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.White;
            label5.Location = new Point(0, -2);
            label5.Name = "label5";
            label5.Size = new Size(764, 57);
            label5.TabIndex = 10;
            label5.Text = "ATM Management System";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // button2
            // 
            button2.BackColor = SystemColors.GradientActiveCaption;
            button2.Font = new Font("Microsoft YaHei UI", 13.8F, FontStyle.Bold);
            button2.ForeColor = SystemColors.Highlight;
            button2.Location = new Point(130, 563);
            button2.Name = "button2";
            button2.Size = new Size(177, 45);
            button2.TabIndex = 11;
            button2.Text = "Log Out";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.GradientActiveCaption;
            button1.Font = new Font("Microsoft YaHei UI", 13.8F, FontStyle.Bold);
            button1.ForeColor = SystemColors.Highlight;
            button1.Location = new Point(440, 563);
            button1.Name = "button1";
            button1.Size = new Size(177, 45);
            button1.TabIndex = 12;
            button1.Text = "Back";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.BackColor = SystemColors.ControlLight;
            label1.Font = new Font("Microsoft New Tai Lue", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.Highlight;
            label1.Location = new Point(0, 55);
            label1.Name = "label1";
            label1.Size = new Size(764, 42);
            label1.TabIndex = 13;
            label1.Text = "Mini-Statement";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.Click += label1_Click;
            // 
            // AccNum
            // 
            AccNum.AutoSize = true;
            AccNum.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            AccNum.ForeColor = SystemColors.Highlight;
            AccNum.Location = new Point(424, 109);
            AccNum.Name = "AccNum";
            AccNum.Size = new Size(130, 38);
            AccNum.TabIndex = 16;
            AccNum.Text = "Acc Num";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft New Tai Lue", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.Highlight;
            label2.Location = new Point(102, 107);
            label2.Name = "label2";
            label2.Size = new Size(272, 40);
            label2.TabIndex = 15;
            label2.Text = "Account Number :";
            // 
            // MiniStatement
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(764, 628);
            Controls.Add(AccNum);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label5);
            Controls.Add(panel1);
            Controls.Add(Ministgrid);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Name = "MiniStatement";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MiniStatement";
            Load += MiniStatement_Load;
            ((System.ComponentModel.ISupportInitialize)Ministgrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView Ministgrid;
        private Panel panel1;
        private Label label5;
        private Button button2;
        private Button button1;
        private Label label1;
        private Label AccNum;
        private Label label2;
    }
}