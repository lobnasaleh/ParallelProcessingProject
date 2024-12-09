namespace ParallelProcessingProject
{
    partial class ChangePIN
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
            pin = new TextBox();
            confirmpin = new TextBox();
            label5 = new Label();
            label2 = new Label();
            label1 = new Label();
            button1 = new Button();
            button2 = new Button();
            confirmerr = new Label();
            SuspendLayout();
            // 
            // pin
            // 
            pin.Location = new Point(135, 134);
            pin.Name = "pin";
            pin.PasswordChar = '*';
            pin.Size = new Size(247, 27);
            pin.TabIndex = 1;
            pin.UseSystemPasswordChar = true;
            // 
            // confirmpin
            // 
            confirmpin.Location = new Point(135, 224);
            confirmpin.Name = "confirmpin";
            confirmpin.PasswordChar = '*';
            confirmpin.Size = new Size(247, 27);
            confirmpin.TabIndex = 2;
            confirmpin.UseSystemPasswordChar = true;
            // 
            // label5
            // 
            label5.BackColor = SystemColors.Highlight;
            label5.Font = new Font("Microsoft New Tai Lue", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.White;
            label5.Location = new Point(2, 0);
            label5.Name = "label5";
            label5.Size = new Size(533, 42);
            label5.TabIndex = 8;
            label5.Text = "ATM Management System";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Tai Le", 13.8F, FontStyle.Bold);
            label2.ForeColor = SystemColors.Highlight;
            label2.Location = new Point(188, 192);
            label2.Name = "label2";
            label2.Size = new Size(146, 29);
            label2.TabIndex = 9;
            label2.Text = "Confirm PIN";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Tai Le", 13.8F, FontStyle.Bold);
            label1.ForeColor = SystemColors.Highlight;
            label1.Location = new Point(206, 102);
            label1.Name = "label1";
            label1.Size = new Size(106, 29);
            label1.TabIndex = 10;
            label1.Text = "New PIN";
            // 
            // button1
            // 
            button1.BackColor = SystemColors.ActiveCaption;
            button1.Font = new Font("Microsoft YaHei UI", 13.8F, FontStyle.Bold);
            button1.ForeColor = SystemColors.Highlight;
            button1.Location = new Point(62, 332);
            button1.Name = "button1";
            button1.Size = new Size(158, 41);
            button1.TabIndex = 11;
            button1.Text = "Change";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = SystemColors.ActiveCaption;
            button2.Font = new Font("Microsoft YaHei UI", 13.8F, FontStyle.Bold);
            button2.ForeColor = SystemColors.Highlight;
            button2.Location = new Point(319, 332);
            button2.Name = "button2";
            button2.Size = new Size(160, 41);
            button2.TabIndex = 12;
            button2.Text = "Back";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // confirmerr
            // 
            confirmerr.AutoSize = true;
            confirmerr.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            confirmerr.ForeColor = Color.Red;
            confirmerr.Location = new Point(240, 299);
            confirmerr.Name = "confirmerr";
            confirmerr.Size = new Size(0, 23);
            confirmerr.TabIndex = 14;
            // 
            // ChangePIN
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(539, 402);
            Controls.Add(confirmerr);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(label5);
            Controls.Add(confirmpin);
            Controls.Add(pin);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Name = "ChangePIN";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ChangePIN";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox pin;
        private TextBox confirmpin;
        private Label label5;
        private Label label2;
        private Label label1;
        private Button button1;
        private Button button2;
        private Label confirmerr;
    }
}