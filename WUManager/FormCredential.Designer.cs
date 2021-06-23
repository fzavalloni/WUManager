namespace WUManager
{
    partial class FormCredential
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
            this.chkAltCred = new System.Windows.Forms.CheckBox();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.txtPasswd = new System.Windows.Forms.TextBox();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblPass = new System.Windows.Forms.Label();
            this.btnAltCred = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // chkAltCred
            // 
            this.chkAltCred.AutoSize = true;
            this.chkAltCred.Location = new System.Drawing.Point(12, 12);
            this.chkAltCred.Name = "chkAltCred";
            this.chkAltCred.Size = new System.Drawing.Size(146, 17);
            this.chkAltCred.TabIndex = 0;
            this.chkAltCred.Text = "Use alternative credential";
            this.chkAltCred.UseVisualStyleBackColor = true;
            this.chkAltCred.CheckedChanged += new System.EventHandler(this.chkAltCred_CheckedChanged);
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(12, 54);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(185, 20);
            this.txtUser.TabIndex = 1;
            // 
            // txtPasswd
            // 
            this.txtPasswd.Location = new System.Drawing.Point(12, 93);
            this.txtPasswd.Name = "txtPasswd";
            this.txtPasswd.PasswordChar = '*';
            this.txtPasswd.Size = new System.Drawing.Size(185, 20);
            this.txtPasswd.TabIndex = 2;
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(9, 38);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(55, 13);
            this.lblUser.TabIndex = 3;
            this.lblUser.Text = "Username";
            // 
            // lblPass
            // 
            this.lblPass.AutoSize = true;
            this.lblPass.Location = new System.Drawing.Point(9, 77);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(53, 13);
            this.lblPass.TabIndex = 4;
            this.lblPass.Text = "Password";
            // 
            // btnAltCred
            // 
            this.btnAltCred.Location = new System.Drawing.Point(12, 119);
            this.btnAltCred.Name = "btnAltCred";
            this.btnAltCred.Size = new System.Drawing.Size(185, 23);
            this.btnAltCred.TabIndex = 5;
            this.btnAltCred.Text = "OK";
            this.btnAltCred.UseVisualStyleBackColor = true;
            this.btnAltCred.Click += new System.EventHandler(this.btnAltCred_Click);
            // 
            // formCredential
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(206, 147);
            this.Controls.Add(this.btnAltCred);
            this.Controls.Add(this.lblPass);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.txtPasswd);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.chkAltCred);
            this.Name = "formCredential";
            this.Text = "Credential";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkAltCred;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.TextBox txtPasswd;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblPass;
        private System.Windows.Forms.Button btnAltCred;
    }
}