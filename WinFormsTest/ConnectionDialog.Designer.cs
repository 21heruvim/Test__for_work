namespace WinFormsTest
{
    partial class ConnectionDialog
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
            textBoxHost = new TextBox();
            textBoxPort = new TextBox();
            textBoxDatabase = new TextBox();
            textBoxUser = new TextBox();
            textBoxPassword = new TextBox();
            btnOk = new Button();
            btnCancel = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            SuspendLayout();
            // 
            // textBoxHost
            // 
            textBoxHost.Location = new Point(84, 36);
            textBoxHost.Name = "textBoxHost";
            textBoxHost.Size = new Size(180, 23);
            textBoxHost.TabIndex = 0;
            // 
            // textBoxPort
            // 
            textBoxPort.Location = new Point(84, 75);
            textBoxPort.Name = "textBoxPort";
            textBoxPort.Size = new Size(100, 23);
            textBoxPort.TabIndex = 1;
            // 
            // textBoxDatabase
            // 
            textBoxDatabase.Location = new Point(84, 113);
            textBoxDatabase.Name = "textBoxDatabase";
            textBoxDatabase.Size = new Size(180, 23);
            textBoxDatabase.TabIndex = 2;
            // 
            // textBoxUser
            // 
            textBoxUser.Location = new Point(84, 151);
            textBoxUser.Name = "textBoxUser";
            textBoxUser.Size = new Size(100, 23);
            textBoxUser.TabIndex = 3;
            // 
            // textBoxPassword
            // 
            textBoxPassword.Location = new Point(84, 189);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.Size = new Size(180, 23);
            textBoxPassword.TabIndex = 4;
            // 
            // btnOk
            // 
            btnOk.Location = new Point(82, 235);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(75, 23);
            btnOk.TabIndex = 6;
            btnOk.Text = "OK";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(189, 235);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 39);
            label1.Name = "label1";
            label1.Size = new Size(65, 15);
            label1.TabIndex = 8;
            label1.Text = "Host name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(13, 78);
            label2.Name = "label2";
            label2.Size = new Size(29, 15);
            label2.TabIndex = 9;
            label2.Text = "Port";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(13, 116);
            label3.Name = "label3";
            label3.Size = new Size(55, 15);
            label3.TabIndex = 10;
            label3.Text = "Database";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(13, 154);
            label4.Name = "label4";
            label4.Size = new Size(30, 15);
            label4.TabIndex = 11;
            label4.Text = "User";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(13, 192);
            label5.Name = "label5";
            label5.Size = new Size(57, 15);
            label5.TabIndex = 12;
            label5.Text = "Password";
            // 
            // ConnectionDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(290, 306);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnCancel);
            Controls.Add(btnOk);
            Controls.Add(textBoxPassword);
            Controls.Add(textBoxUser);
            Controls.Add(textBoxDatabase);
            Controls.Add(textBoxPort);
            Controls.Add(textBoxHost);
            Name = "ConnectionDialog";
            Text = "ConnectionDialog";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxHost;
        private TextBox textBoxPort;
        private TextBox textBoxDatabase;
        private TextBox textBoxUser;
        private TextBox textBoxPassword;
        private Button btnOk;
        private Button btnCancel;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
    }
}