namespace AddCalendarAppointment
{
    partial class Login
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
            this.userlbl = new System.Windows.Forms.Label();
            this.usernametxt = new System.Windows.Forms.TextBox();
            this.passwordlbl = new System.Windows.Forms.Label();
            this.passwordtxt = new System.Windows.Forms.TextBox();
            this.loginbtn = new System.Windows.Forms.Button();
            this.registerbtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // userlbl
            // 
            this.userlbl.Location = new System.Drawing.Point(130, 56);
            this.userlbl.Name = "userlbl";
            this.userlbl.Size = new System.Drawing.Size(82, 20);
            this.userlbl.TabIndex = 0;
            this.userlbl.Text = "Username";
            this.userlbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // usernametxt
            // 
            this.usernametxt.Location = new System.Drawing.Point(264, 56);
            this.usernametxt.Name = "usernametxt";
            this.usernametxt.Size = new System.Drawing.Size(254, 20);
            this.usernametxt.TabIndex = 1;
            // 
            // passwordlbl
            // 
            this.passwordlbl.Location = new System.Drawing.Point(130, 101);
            this.passwordlbl.Name = "passwordlbl";
            this.passwordlbl.Size = new System.Drawing.Size(82, 20);
            this.passwordlbl.TabIndex = 2;
            this.passwordlbl.Text = "Password";
            this.passwordlbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // passwordtxt
            // 
            this.passwordtxt.Location = new System.Drawing.Point(264, 102);
            this.passwordtxt.Name = "passwordtxt";
            this.passwordtxt.PasswordChar = '*';
            this.passwordtxt.Size = new System.Drawing.Size(254, 20);
            this.passwordtxt.TabIndex = 3;
            // 
            // loginbtn
            // 
            this.loginbtn.Location = new System.Drawing.Point(133, 159);
            this.loginbtn.Name = "loginbtn";
            this.loginbtn.Size = new System.Drawing.Size(141, 51);
            this.loginbtn.TabIndex = 4;
            this.loginbtn.Text = "LOGIN";
            this.loginbtn.UseVisualStyleBackColor = true;
            this.loginbtn.Click += new System.EventHandler(this.loginbtn_Click);
            // 
            // registerbtn
            // 
            this.registerbtn.Location = new System.Drawing.Point(346, 159);
            this.registerbtn.Name = "registerbtn";
            this.registerbtn.Size = new System.Drawing.Size(141, 51);
            this.registerbtn.TabIndex = 5;
            this.registerbtn.Text = "REGISTER";
            this.registerbtn.UseVisualStyleBackColor = true;
            this.registerbtn.Click += new System.EventHandler(this.registerbtn_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 236);
            this.Controls.Add(this.registerbtn);
            this.Controls.Add(this.loginbtn);
            this.Controls.Add(this.passwordtxt);
            this.Controls.Add(this.passwordlbl);
            this.Controls.Add(this.usernametxt);
            this.Controls.Add(this.userlbl);
            this.Name = "Login";
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label userlbl;
        private System.Windows.Forms.TextBox usernametxt;
        private System.Windows.Forms.Label passwordlbl;
        private System.Windows.Forms.TextBox passwordtxt;
        private System.Windows.Forms.Button loginbtn;
        private System.Windows.Forms.Button registerbtn;
    }
}