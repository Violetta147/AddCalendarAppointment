namespace AddCalendarAppointment
{
    partial class MainForm
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
            this.monthCalendar = new System.Windows.Forms.MonthCalendar();
            this.btAddAppointment = new System.Windows.Forms.Button();
            this.dGVListAppointment = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Appointment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Reminder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btListAppointment = new System.Windows.Forms.Button();
            this.btDetailAppointment = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dGVListAppointment)).BeginInit();
            this.SuspendLayout();
            // 
            // monthCalendar
            // 
            this.monthCalendar.Location = new System.Drawing.Point(27, 6);
            this.monthCalendar.Name = "monthCalendar";
            this.monthCalendar.TabIndex = 0;
            // 
            // btAddAppointment
            // 
            this.btAddAppointment.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAddAppointment.Location = new System.Drawing.Point(348, 6);
            this.btAddAppointment.Name = "btAddAppointment";
            this.btAddAppointment.Size = new System.Drawing.Size(203, 78);
            this.btAddAppointment.TabIndex = 1;
            this.btAddAppointment.Text = "Add Appointment";
            this.btAddAppointment.UseVisualStyleBackColor = true;
            this.btAddAppointment.Click += new System.EventHandler(this.btAddAppointment_Click);
            // 
            // dGVListAppointment
            // 
            this.dGVListAppointment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVListAppointment.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Appointment,
            this.StartTime,
            this.Reminder});
            this.dGVListAppointment.Location = new System.Drawing.Point(12, 225);
            this.dGVListAppointment.Name = "dGVListAppointment";
            this.dGVListAppointment.RowHeadersWidth = 51;
            this.dGVListAppointment.RowTemplate.Height = 24;
            this.dGVListAppointment.Size = new System.Drawing.Size(805, 391);
            this.dGVListAppointment.TabIndex = 2;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.MinimumWidth = 6;
            this.ID.Name = "ID";
            this.ID.Width = 50;
            // 
            // Appointment
            // 
            this.Appointment.HeaderText = "Appointment Name";
            this.Appointment.MinimumWidth = 6;
            this.Appointment.Name = "Appointment";
            this.Appointment.Width = 300;
            // 
            // StartTime
            // 
            this.StartTime.HeaderText = "Start Time";
            this.StartTime.MinimumWidth = 6;
            this.StartTime.Name = "StartTime";
            this.StartTime.Width = 125;
            // 
            // Reminder
            // 
            this.Reminder.HeaderText = "Reminder";
            this.Reminder.MinimumWidth = 6;
            this.Reminder.Name = "Reminder";
            this.Reminder.Width = 75;
            // 
            // btListAppointment
            // 
            this.btListAppointment.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btListAppointment.Location = new System.Drawing.Point(348, 170);
            this.btListAppointment.Name = "btListAppointment";
            this.btListAppointment.Size = new System.Drawing.Size(226, 43);
            this.btListAppointment.TabIndex = 1;
            this.btListAppointment.Text = "List Appointment";
            this.btListAppointment.UseVisualStyleBackColor = true;
            this.btListAppointment.Click += new System.EventHandler(this.btListAppointment_Click);
            // 
            // btDetailAppointment
            // 
            this.btDetailAppointment.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btDetailAppointment.Location = new System.Drawing.Point(591, 170);
            this.btDetailAppointment.Name = "btDetailAppointment";
            this.btDetailAppointment.Size = new System.Drawing.Size(226, 43);
            this.btDetailAppointment.TabIndex = 1;
            this.btDetailAppointment.Text = "Detail Appointment";
            this.btDetailAppointment.UseVisualStyleBackColor = true;
            this.btDetailAppointment.Click += new System.EventHandler(this.btDetailAppointment_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 628);
            this.Controls.Add(this.dGVListAppointment);
            this.Controls.Add(this.btDetailAppointment);
            this.Controls.Add(this.btListAppointment);
            this.Controls.Add(this.btAddAppointment);
            this.Controls.Add(this.monthCalendar);
            this.Name = "MainForm";
            this.Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this.dGVListAppointment)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MonthCalendar monthCalendar;
        private System.Windows.Forms.Button btAddAppointment;
        private System.Windows.Forms.DataGridView dGVListAppointment;
        private System.Windows.Forms.Button btListAppointment;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Appointment;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Reminder;
        private System.Windows.Forms.Button btDetailAppointment;
    }
}

