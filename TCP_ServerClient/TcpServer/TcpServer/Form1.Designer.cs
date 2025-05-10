namespace TcpServer
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            btnConnect = new Button();
            label2 = new Label();
            txtServerIP = new TextBox();
            txtClientIP = new TextBox();
            btnStart = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("맑은 고딕", 12F, FontStyle.Bold);
            label1.Location = new Point(63, 42);
            label1.Name = "label1";
            label1.Size = new Size(95, 21);
            label1.TabIndex = 0;
            label1.Text = "Server IP : ";
            // 
            // btnConnect
            // 
            btnConnect.BackColor = SystemColors.GradientInactiveCaption;
            btnConnect.Font = new Font("맑은 고딕", 11F, FontStyle.Bold);
            btnConnect.Location = new Point(444, 39);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(114, 27);
            btnConnect.TabIndex = 5;
            btnConnect.Text = "Connect";
            btnConnect.UseVisualStyleBackColor = false;
            btnConnect.Click += btnConnect_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("맑은 고딕", 12F, FontStyle.Bold);
            label2.Location = new Point(63, 95);
            label2.Name = "label2";
            label2.Size = new Size(90, 21);
            label2.TabIndex = 6;
            label2.Text = "Client  IP :";
            // 
            // txtServerIP
            // 
            txtServerIP.BorderStyle = BorderStyle.FixedSingle;
            txtServerIP.Font = new Font("맑은 고딕", 11F, FontStyle.Bold);
            txtServerIP.Location = new Point(169, 41);
            txtServerIP.Multiline = true;
            txtServerIP.Name = "txtServerIP";
            txtServerIP.Size = new Size(237, 23);
            txtServerIP.TabIndex = 7;
            // 
            // txtClientIP
            // 
            txtClientIP.BorderStyle = BorderStyle.FixedSingle;
            txtClientIP.Font = new Font("맑은 고딕", 11F, FontStyle.Bold);
            txtClientIP.Location = new Point(169, 95);
            txtClientIP.Multiline = true;
            txtClientIP.Name = "txtClientIP";
            txtClientIP.Size = new Size(237, 23);
            txtClientIP.TabIndex = 8;
            // 
            // btnStart
            // 
            btnStart.BackColor = SystemColors.GradientInactiveCaption;
            btnStart.Font = new Font("맑은 고딕", 11F, FontStyle.Bold);
            btnStart.Location = new Point(169, 146);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(237, 27);
            btnStart.TabIndex = 9;
            btnStart.Text = "START";
            btnStart.UseVisualStyleBackColor = false;
            btnStart.Click += btnStart_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(639, 202);
            Controls.Add(btnStart);
            Controls.Add(txtClientIP);
            Controls.Add(txtServerIP);
            Controls.Add(label2);
            Controls.Add(btnConnect);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Server Program";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnConnect;
        private Label label2;
        private TextBox txtServerIP;
        private TextBox txtClientIP;
        private Button btnStart;
    }
}
