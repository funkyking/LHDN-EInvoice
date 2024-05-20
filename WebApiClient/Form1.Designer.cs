namespace WebApiClient
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
            cmbAPI = new ComboBox();
            label1 = new Label();
            groupBox1 = new GroupBox();
            cmdSend = new Button();
            groupBox2 = new GroupBox();
            rtResponse = new RichTextBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // cmbAPI
            // 
            cmbAPI.FormattingEnabled = true;
            cmbAPI.Location = new Point(112, 31);
            cmbAPI.Name = "cmbAPI";
            cmbAPI.Size = new Size(261, 28);
            cmbAPI.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(42, 34);
            label1.Name = "label1";
            label1.Size = new Size(31, 20);
            label1.TabIndex = 1;
            label1.Text = "API";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(cmdSend);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(cmbAPI);
            groupBox1.Location = new Point(21, 21);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(696, 90);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Request";
            // 
            // cmdSend
            // 
            cmdSend.Location = new Point(401, 30);
            cmdSend.Name = "cmdSend";
            cmdSend.Size = new Size(94, 29);
            cmdSend.TabIndex = 2;
            cmdSend.Text = "Send";
            cmdSend.UseVisualStyleBackColor = true;
            cmdSend.Click += cmdSend_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(rtResponse);
            groupBox2.Location = new Point(21, 117);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(696, 358);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "Response";
            // 
            // rtResponse
            // 
            rtResponse.BackColor = Color.FromArgb(255, 255, 192);
            rtResponse.Location = new Point(17, 26);
            rtResponse.Name = "rtResponse";
            rtResponse.ReadOnly = true;
            rtResponse.RightToLeft = RightToLeft.No;
            rtResponse.Size = new Size(654, 310);
            rtResponse.TabIndex = 0;
            rtResponse.Text = "";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(739, 487);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "Form1";
            Text = "Form1";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private ComboBox cmbAPI;
        private Label label1;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private RichTextBox rtResponse;
        private Button cmdSend;
    }
}
