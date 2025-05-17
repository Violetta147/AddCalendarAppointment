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
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtUserId = new System.Windows.Forms.TextBox();
            this.CreatorName = new System.Windows.Forms.Label();
            this.txtCreaatorName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btOK
            // 
            this.btOK.Location = new System.Drawing.Point(260, 303);
            this.btOK.Margin = new System.Windows.Forms.Padding(2);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(85, 43);
            this.btOK.TabIndex = 0;
            this.btOK.Text = "OK";
            this.btOK.UseVisualStyleBackColor = true;
            this.btOK.Click += new System.EventHandler(this.btOK_Click);
            // 
            // lbAppointmentName
            // 
            this.lbAppointmentName.AutoSize = true;
            this.lbAppointmentName.Location = new System.Drawing.Point(98, 84);
            this.lbAppointmentName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbAppointmentName.Name = "lbAppointmentName";
            this.lbAppointmentName.Size = new System.Drawing.Size(97, 13);
            this.lbAppointmentName.TabIndex = 1;
            this.lbAppointmentName.Text = "Appointment Name";
            // 
            // lbLocation
            // 
            this.lbLocation.AutoSize = true;
            this.lbLocation.Location = new System.Drawing.Point(98, 134);
            this.lbLocation.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbLocation.Name = "lbLocation";
            this.lbLocation.Size = new System.Drawing.Size(48, 13);
            this.lbLocation.TabIndex = 1;
            this.lbLocation.Text = "Location";
            // 
            // dTPStartTime
            // 
            this.dTPStartTime.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.dTPStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dTPStartTime.Location = new System.Drawing.Point(195, 179);
            this.dTPStartTime.Margin = new System.Windows.Forms.Padding(2);
            this.dTPStartTime.Name = "dTPStartTime";
            this.dTPStartTime.Size = new System.Drawing.Size(284, 20);
            this.dTPStartTime.TabIndex = 3;
            // 
            // dTPEndTime
            // 
            this.dTPEndTime.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.dTPEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dTPEndTime.Location = new System.Drawing.Point(195, 234);
            this.dTPEndTime.Margin = new System.Windows.Forms.Padding(2);
            this.dTPEndTime.Name = "dTPEndTime";
            this.dTPEndTime.Size = new System.Drawing.Size(284, 20);
            this.dTPEndTime.TabIndex = 3;
            // 
            // btDelete
            // 
            this.btDelete.Location = new System.Drawing.Point(447, 303);
            this.btDelete.Margin = new System.Windows.Forms.Padding(2);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(75, 43);
            this.btDelete.TabIndex = 0;
            this.btDelete.Text = "Delete";
            this.btDelete.UseVisualStyleBackColor = true;
            this.btDelete.Click += new System.EventHandler(this.btDelete_Click);
            // 
            // lbStartTime
            // 
            this.lbStartTime.AutoSize = true;
            this.lbStartTime.Location = new System.Drawing.Point(98, 183);
            this.lbStartTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbStartTime.Name = "lbStartTime";
            this.lbStartTime.Size = new System.Drawing.Size(55, 13);
            this.lbStartTime.TabIndex = 1;
            this.lbStartTime.Text = "Start Time";
            // 
            // lbEndTime
            // 
            this.lbEndTime.AutoSize = true;
            this.lbEndTime.Location = new System.Drawing.Point(98, 238);
            this.lbEndTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbEndTime.Name = "lbEndTime";
            this.lbEndTime.Size = new System.Drawing.Size(52, 13);
            this.lbEndTime.TabIndex = 1;
            this.lbEndTime.Text = "End Time";
            // 
            // btReminder
            // 
            this.btReminder.Location = new System.Drawing.Point(69, 303);
            this.btReminder.Margin = new System.Windows.Forms.Padding(2);
            this.btReminder.Name = "btReminder";
            this.btReminder.Size = new System.Drawing.Size(87, 43);
            this.btReminder.TabIndex = 0;
            this.btReminder.Text = "Reminder";
            this.btReminder.UseVisualStyleBackColor = true;
            this.btReminder.Click += new System.EventHandler(this.btReminder_Click);
            // 
            // txtAppointmentName
            // 
            this.txtAppointmentName.Location = new System.Drawing.Point(195, 82);
            this.txtAppointmentName.Margin = new System.Windows.Forms.Padding(2);
            this.txtAppointmentName.Name = "txtAppointmentName";
            this.txtAppointmentName.Size = new System.Drawing.Size(284, 20);
            this.txtAppointmentName.TabIndex = 2;
            // 
            // txtLocation
            // 
            this.txtLocation.Location = new System.Drawing.Point(195, 131);
            this.txtLocation.Margin = new System.Windows.Forms.Padding(2);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(284, 20);
            this.txtLocation.TabIndex = 2;
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(576, 11);
            this.txtID.Margin = new System.Windows.Forms.Padding(2);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(13, 20);
            this.txtID.TabIndex = 2;
            this.txtID.Visible = false;
            // 
            // txtUserId
            // 
            this.txtUserId.Location = new System.Drawing.Point(576, 37);
            this.txtUserId.Margin = new System.Windows.Forms.Padding(2);
            this.txtUserId.Name = "txtUserId";
            this.txtUserId.ReadOnly = true;
            this.txtUserId.Size = new System.Drawing.Size(13, 20);
            this.txtUserId.TabIndex = 4;
            this.txtUserId.Visible = false;
            // 
            // CreatorName
            // 
            this.CreatorName.AutoSize = true;
            this.CreatorName.Location = new System.Drawing.Point(98, 44);
            this.CreatorName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.CreatorName.Name = "CreatorName";
            this.CreatorName.Size = new System.Drawing.Size(72, 13);
            this.CreatorName.TabIndex = 5;
            this.CreatorName.Text = "Creator Name";
            // 
            // txtCreaatorName
            // 
            this.txtCreaatorName.Location = new System.Drawing.Point(195, 37);
            this.txtCreaatorName.Margin = new System.Windows.Forms.Padding(2);
            this.txtCreaatorName.Name = "txtCreaatorName";
            this.txtCreaatorName.Size = new System.Drawing.Size(284, 20);
            this.txtCreaatorName.TabIndex = 6;
            // 
            // AppointmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.txtCreaatorName);
            this.Controls.Add(this.CreatorName);
            this.Controls.Add(this.txtUserId);
            this.Controls.Add(this.txtID);
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
            this.Margin = new System.Windows.Forms.Padding(2);
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
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtUserId;
        private System.Windows.Forms.Label CreatorName;
        private System.Windows.Forms.TextBox txtCreaatorName;
    }
}