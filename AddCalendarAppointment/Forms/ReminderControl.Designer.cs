namespace AddCalendarAppointment.Forms
{
    partial class ReminderControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbTime = new System.Windows.Forms.Label();
            this.lbDiscription = new System.Windows.Forms.Label();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.dTPTime = new System.Windows.Forms.DateTimePicker();
            this.btOK = new System.Windows.Forms.Button();
            this.btDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbTime
            // 
            this.lbTime.AutoSize = true;
            this.lbTime.Location = new System.Drawing.Point(32, 56);
            this.lbTime.Name = "lbTime";
            this.lbTime.Size = new System.Drawing.Size(38, 16);
            this.lbTime.TabIndex = 0;
            this.lbTime.Text = "Time";
            // 
            // lbDiscription
            // 
            this.lbDiscription.AutoSize = true;
            this.lbDiscription.Location = new System.Drawing.Point(32, 182);
            this.lbDiscription.Name = "lbDiscription";
            this.lbDiscription.Size = new System.Drawing.Size(64, 16);
            this.lbDiscription.TabIndex = 0;
            this.lbDiscription.Text = "Message";
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(24, 211);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(250, 100);
            this.txtMessage.TabIndex = 1;
            // 
            // dTPTime
            // 
            this.dTPTime.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.dTPTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dTPTime.Location = new System.Drawing.Point(49, 88);
            this.dTPTime.Name = "dTPTime";
            this.dTPTime.Size = new System.Drawing.Size(200, 22);
            this.dTPTime.TabIndex = 2;
            // 
            // btOK
            // 
            this.btOK.Location = new System.Drawing.Point(59, 398);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(75, 23);
            this.btOK.TabIndex = 3;
            this.btOK.Text = "OK";
            this.btOK.UseVisualStyleBackColor = true;
            this.btOK.Click += new System.EventHandler(this.btOK_Click);
            // 
            // btDelete
            // 
            this.btDelete.Location = new System.Drawing.Point(163, 398);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(75, 23);
            this.btDelete.TabIndex = 3;
            this.btDelete.Text = "Delete";
            this.btDelete.UseVisualStyleBackColor = true;
            this.btDelete.Click += new System.EventHandler(this.btDelete_Click);
            // 
            // ReminderControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btDelete);
            this.Controls.Add(this.btOK);
            this.Controls.Add(this.dTPTime);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.lbDiscription);
            this.Controls.Add(this.lbTime);
            this.Name = "ReminderControl";
            this.Size = new System.Drawing.Size(300, 450);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbTime;
        private System.Windows.Forms.Label lbDiscription;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.DateTimePicker dTPTime;
        private System.Windows.Forms.Button btOK;
        private System.Windows.Forms.Button btDelete;
    }
}
