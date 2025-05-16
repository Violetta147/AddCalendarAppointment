namespace AddCalendarAppointment.Forms
{
    partial class AppointmentForm
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
            this.btOK = new System.Windows.Forms.Button();
            this.lbAppointmentName = new System.Windows.Forms.Label();
            this.lbLocation = new System.Windows.Forms.Label();
            this.dTPStartTime = new System.Windows.Forms.DateTimePicker();
            this.dTPEndTime = new System.Windows.Forms.DateTimePicker();
            this.btDelete = new System.Windows.Forms.Button();
            this.lbStartTime = new System.Windows.Forms.Label();
            this.lbEndTime = new System.Windows.Forms.Label();
            this.btReminder = new System.Windows.Forms.Button();
            this.txtAppointmentName = new System.Windows.Forms.TextBox();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.lbID = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btOK
            // 
            this.btOK.Location = new System.Drawing.Point(353, 386);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(75, 23);
            this.btOK.TabIndex = 0;
            this.btOK.Text = "OK";
            this.btOK.UseVisualStyleBackColor = true;
            this.btOK.Click += new System.EventHandler(this.btOK_Click);
            // 
            // lbAppointmentName
            // 
            this.lbAppointmentName.AutoSize = true;
            this.lbAppointmentName.Location = new System.Drawing.Point(142, 91);
            this.lbAppointmentName.Name = "lbAppointmentName";
            this.lbAppointmentName.Size = new System.Drawing.Size(122, 16);
            this.lbAppointmentName.TabIndex = 1;
            this.lbAppointmentName.Text = "Appointment Name";
            // 
            // lbLocation
            // 
            this.lbLocation.AutoSize = true;
            this.lbLocation.Location = new System.Drawing.Point(142, 152);
            this.lbLocation.Name = "lbLocation";
            this.lbLocation.Size = new System.Drawing.Size(58, 16);
            this.lbLocation.TabIndex = 1;
            this.lbLocation.Text = "Location";
            // 
            // dTPStartTime
            // 
            this.dTPStartTime.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.dTPStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dTPStartTime.Location = new System.Drawing.Point(271, 208);
            this.dTPStartTime.Name = "dTPStartTime";
            this.dTPStartTime.Size = new System.Drawing.Size(377, 22);
            this.dTPStartTime.TabIndex = 3;
            // 
            // dTPEndTime
            // 
            this.dTPEndTime.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.dTPEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dTPEndTime.Location = new System.Drawing.Point(271, 276);
            this.dTPEndTime.Name = "dTPEndTime";
            this.dTPEndTime.Size = new System.Drawing.Size(377, 22);
            this.dTPEndTime.TabIndex = 3;
            // 
            // btDelete
            // 
            this.btDelete.Location = new System.Drawing.Point(549, 386);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(75, 23);
            this.btDelete.TabIndex = 0;
            this.btDelete.Text = "Delete";
            this.btDelete.UseVisualStyleBackColor = true;
            this.btDelete.Click += new System.EventHandler(this.btDelete_Click);
            // 
            // lbStartTime
            // 
            this.lbStartTime.AutoSize = true;
            this.lbStartTime.Location = new System.Drawing.Point(142, 213);
            this.lbStartTime.Name = "lbStartTime";
            this.lbStartTime.Size = new System.Drawing.Size(68, 16);
            this.lbStartTime.TabIndex = 1;
            this.lbStartTime.Text = "Start Time";
            // 
            // lbEndTime
            // 
            this.lbEndTime.AutoSize = true;
            this.lbEndTime.Location = new System.Drawing.Point(142, 281);
            this.lbEndTime.Name = "lbEndTime";
            this.lbEndTime.Size = new System.Drawing.Size(65, 16);
            this.lbEndTime.TabIndex = 1;
            this.lbEndTime.Text = "End Time";
            // 
            // btReminder
            // 
            this.btReminder.Location = new System.Drawing.Point(155, 386);
            this.btReminder.Name = "btReminder";
            this.btReminder.Size = new System.Drawing.Size(75, 23);
            this.btReminder.TabIndex = 0;
            this.btReminder.Text = "Reminder";
            this.btReminder.UseVisualStyleBackColor = true;
            this.btReminder.Click += new System.EventHandler(this.btReminder_Click);
            // 
            // txtAppointmentName
            // 
            this.txtAppointmentName.Location = new System.Drawing.Point(271, 88);
            this.txtAppointmentName.Name = "txtAppointmentName";
            this.txtAppointmentName.Size = new System.Drawing.Size(377, 22);
            this.txtAppointmentName.TabIndex = 2;
            // 
            // txtLocation
            // 
            this.txtLocation.Location = new System.Drawing.Point(271, 149);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(377, 22);
            this.txtLocation.TabIndex = 2;
            // 
            // lbID
            // 
            this.lbID.AutoSize = true;
            this.lbID.Location = new System.Drawing.Point(145, 33);
            this.lbID.Name = "lbID";
            this.lbID.Size = new System.Drawing.Size(20, 16);
            this.lbID.TabIndex = 1;
            this.lbID.Text = "ID";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(271, 30);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(100, 22);
            this.txtID.TabIndex = 2;
            // 
            // AppointmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.lbID);
            this.Controls.Add(this.dTPEndTime);
            this.Controls.Add(this.dTPStartTime);
            this.Controls.Add(this.txtLocation);
            this.Controls.Add(this.txtAppointmentName);
            this.Controls.Add(this.lbEndTime);
            this.Controls.Add(this.lbStartTime);
            this.Controls.Add(this.lbLocation);
            this.Controls.Add(this.lbAppointmentName);
            this.Controls.Add(this.btDelete);
            this.Controls.Add(this.btReminder);
            this.Controls.Add(this.btOK);
            this.Name = "AppointmentForm";
            this.Text = "AppointmentForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btOK;
        private System.Windows.Forms.Label lbAppointmentName;
        private System.Windows.Forms.Label lbLocation;
        private System.Windows.Forms.DateTimePicker dTPStartTime;
        private System.Windows.Forms.DateTimePicker dTPEndTime;
        private System.Windows.Forms.Button btDelete;
        private System.Windows.Forms.Label lbStartTime;
        private System.Windows.Forms.Label lbEndTime;
        private System.Windows.Forms.Button btReminder;
        private System.Windows.Forms.TextBox txtAppointmentName;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.Label lbID;
        private System.Windows.Forms.TextBox txtID;
    }
}