namespace MdiTest
{
    partial class ViewData
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTemp = new System.Windows.Forms.TextBox();
            this.txtHumi = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(75, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "온    도    ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(349, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 27);
            this.label2.TabIndex = 1;
            this.label2.Text = "습    도";
            // 
            // txtTemp
            // 
            this.txtTemp.Font = new System.Drawing.Font("굴림", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtTemp.Location = new System.Drawing.Point(51, 98);
            this.txtTemp.Multiline = true;
            this.txtTemp.Name = "txtTemp";
            this.txtTemp.Size = new System.Drawing.Size(155, 39);
            this.txtTemp.TabIndex = 2;
            this.txtTemp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtHumi
            // 
            this.txtHumi.Font = new System.Drawing.Font("굴림", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtHumi.Location = new System.Drawing.Point(325, 98);
            this.txtHumi.Multiline = true;
            this.txtHumi.Name = "txtHumi";
            this.txtHumi.Size = new System.Drawing.Size(155, 39);
            this.txtHumi.TabIndex = 3;
            this.txtHumi.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ViewData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 300);
            this.Controls.Add(this.txtHumi);
            this.Controls.Add(this.txtTemp);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ViewData";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTemp;
        private System.Windows.Forms.TextBox txtHumi;
    }
}