namespace ClientProgram
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
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txtServerIP = new TextBox();
            txtInt = new TextBox();
            txtFloat = new TextBox();
            txtString = new TextBox();
            btnConnect = new Button();
            btnSend = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("맑은 고딕", 12F, FontStyle.Bold);
            label1.Location = new Point(31, 30);
            label1.Name = "label1";
            label1.Size = new Size(85, 21);
            label1.TabIndex = 0;
            label1.Text = "Server IP ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("맑은 고딕", 12F, FontStyle.Bold);
            label2.Location = new Point(31, 107);
            label2.Name = "label2";
            label2.Size = new Size(72, 21);
            label2.TabIndex = 1;
            label2.Text = "int Data";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("맑은 고딕", 12F, FontStyle.Bold);
            label3.Location = new Point(33, 149);
            label3.Name = "label3";
            label3.Size = new Size(87, 21);
            label3.TabIndex = 2;
            label3.Text = "float Data";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("맑은 고딕", 12F, FontStyle.Bold);
            label4.Location = new Point(33, 188);
            label4.Name = "label4";
            label4.Size = new Size(95, 21);
            label4.TabIndex = 3;
            label4.Text = "string Data";
            // 
            // txtServerIP
            // 
            txtServerIP.BorderStyle = BorderStyle.FixedSingle;
            txtServerIP.Font = new Font("맑은 고딕", 11F, FontStyle.Bold);
            txtServerIP.Location = new Point(126, 30);
            txtServerIP.Multiline = true;
            txtServerIP.Name = "txtServerIP";
            txtServerIP.Size = new Size(243, 23);
            txtServerIP.TabIndex = 4;
            // 
            // txtInt
            // 
            txtInt.BorderStyle = BorderStyle.FixedSingle;
            txtInt.Font = new Font("맑은 고딕", 11F, FontStyle.Bold);
            txtInt.Location = new Point(126, 107);
            txtInt.Multiline = true;
            txtInt.Name = "txtInt";
            txtInt.Size = new Size(243, 23);
            txtInt.TabIndex = 5;
            // 
            // txtFloat
            // 
            txtFloat.BorderStyle = BorderStyle.FixedSingle;
            txtFloat.Font = new Font("맑은 고딕", 11F, FontStyle.Bold);
            txtFloat.Location = new Point(126, 149);
            txtFloat.Multiline = true;
            txtFloat.Name = "txtFloat";
            txtFloat.Size = new Size(243, 23);
            txtFloat.TabIndex = 6;
            // 
            // txtString
            // 
            txtString.BorderStyle = BorderStyle.FixedSingle;
            txtString.Font = new Font("맑은 고딕", 11F, FontStyle.Bold);
            txtString.Location = new Point(126, 188);
            txtString.Multiline = true;
            txtString.Name = "txtString";
            txtString.Size = new Size(243, 23);
            txtString.TabIndex = 7;
            // 
            // btnConnect
            // 
            btnConnect.Font = new Font("맑은 고딕", 11F, FontStyle.Bold);
            btnConnect.Location = new Point(388, 25);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(101, 32);
            btnConnect.TabIndex = 8;
            btnConnect.Text = "connect";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;
            // 
            // btnSend
            // 
            btnSend.Font = new Font("맑은 고딕", 11F, FontStyle.Bold);
            btnSend.Location = new Point(388, 184);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(101, 32);
            btnSend.TabIndex = 9;
            btnSend.Text = "SEND";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += btnSend_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(511, 251);
            Controls.Add(btnSend);
            Controls.Add(btnConnect);
            Controls.Add(txtString);
            Controls.Add(txtFloat);
            Controls.Add(txtInt);
            Controls.Add(txtServerIP);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Client Program";
            FormClosing += Form1_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtServerIP;
        private TextBox txtInt;
        private TextBox txtFloat;
        private TextBox txtString;
        private Button btnConnect;
        private Button btnSend;
    }
}
