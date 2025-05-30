﻿namespace AddCalendarAppointment
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.monthCalendar = new System.Windows.Forms.MonthCalendar();
            this.btAddAppointment = new System.Windows.Forms.Button();
            this.dGVListAppointment = new System.Windows.Forms.DataGridView();
            this.btListAppointment = new System.Windows.Forms.Button();
            this.btDetailAppointment = new System.Windows.Forms.Button();
            this.loginbtn = new System.Windows.Forms.Button();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EndTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Location = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Appointment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btListReminders = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dGVListAppointment)).BeginInit();
            this.SuspendLayout();
            // 
            // monthCalendar
            // 
            this.monthCalendar.Location = new System.Drawing.Point(20, 5);
            this.monthCalendar.Margin = new System.Windows.Forms.Padding(7);
            this.monthCalendar.Name = "monthCalendar";
            this.monthCalendar.TabIndex = 0;
            // 
            // btAddAppointment
            // 
            this.btAddAppointment.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAddAppointment.Location = new System.Drawing.Point(261, 5);
            this.btAddAppointment.Margin = new System.Windows.Forms.Padding(2);
            this.btAddAppointment.Name = "btAddAppointment";
            this.btAddAppointment.Size = new System.Drawing.Size(152, 63);
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
            this.Location,
            this.StartTime,
            this.EndTime,
            this.Type});
            this.dGVListAppointment.Location = new System.Drawing.Point(9, 183);
            this.dGVListAppointment.Margin = new System.Windows.Forms.Padding(2);
            this.dGVListAppointment.Name = "dGVListAppointment";
            this.dGVListAppointment.RowHeadersVisible = false;
            this.dGVListAppointment.RowHeadersWidth = 51;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DodgerBlue;
            this.dGVListAppointment.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dGVListAppointment.RowTemplate.Height = 24;
            this.dGVListAppointment.Size = new System.Drawing.Size(780, 318);
            this.dGVListAppointment.TabIndex = 2;
            // 
            // btListAppointment
            // 
            this.btListAppointment.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btListAppointment.Location = new System.Drawing.Point(261, 138);
            this.btListAppointment.Margin = new System.Windows.Forms.Padding(2);
            this.btListAppointment.Name = "btListAppointment";
            this.btListAppointment.Size = new System.Drawing.Size(170, 35);
            this.btListAppointment.TabIndex = 1;
            this.btListAppointment.Text = "List Appointment";
            this.btListAppointment.UseVisualStyleBackColor = true;
            this.btListAppointment.Click += new System.EventHandler(this.btListAppointment_Click);
            // 
            // btDetailAppointment
            // 
            this.btDetailAppointment.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btDetailAppointment.Location = new System.Drawing.Point(443, 138);
            this.btDetailAppointment.Margin = new System.Windows.Forms.Padding(2);
            this.btDetailAppointment.Name = "btDetailAppointment";
            this.btDetailAppointment.Size = new System.Drawing.Size(170, 35);
            this.btDetailAppointment.TabIndex = 1;
            this.btDetailAppointment.Text = "Detail Appointment";
            this.btDetailAppointment.UseVisualStyleBackColor = true;
            this.btDetailAppointment.Click += new System.EventHandler(this.btDetailAppointment_Click);
            // 
            // btListReminders
            // 
            this.btListReminders.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btListReminders.Location = new System.Drawing.Point(625, 138);
            this.btListReminders.Margin = new System.Windows.Forms.Padding(2);
            this.btListReminders.Name = "btListReminders";
            this.btListReminders.Size = new System.Drawing.Size(164, 35);
            this.btListReminders.TabIndex = 4;
            this.btListReminders.Text = "List All Reminders";
            this.btListReminders.UseVisualStyleBackColor = true;
            this.btListReminders.Click += new System.EventHandler(this.btListReminders_Click);
            // 
            // loginbtn
            // 
            this.loginbtn.BackColor = System.Drawing.Color.Lime;
            this.loginbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginbtn.Location = new System.Drawing.Point(714, 12);
            this.loginbtn.Name = "loginbtn";
            this.loginbtn.Size = new System.Drawing.Size(75, 23);
            this.loginbtn.TabIndex = 3;
            this.loginbtn.Text = "LOGIN";
            this.loginbtn.UseVisualStyleBackColor = false;
            this.loginbtn.Click += new System.EventHandler(this.loginbtn_Click);
            // 
            // Type
            // 
            this.Type.HeaderText = "Type";
            this.Type.Name = "Type";
            // 
            // EndTime
            // 
            this.EndTime.HeaderText = "End Time";
            this.EndTime.Name = "EndTime";
            // 
            // StartTime
            // 
            this.StartTime.HeaderText = "Start Time";
            this.StartTime.MinimumWidth = 6;
            this.StartTime.Name = "StartTime";
            this.StartTime.Width = 125;
            // 
            // Location
            // 
            this.Location.HeaderText = "Location";
            this.Location.Name = "Location";
            // 
            // Appointment
            // 
            this.Appointment.HeaderText = "Appointment Name";
            this.Appointment.MinimumWidth = 6;
            this.Appointment.Name = "Appointment";
            this.Appointment.Width = 300;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.MinimumWidth = 6;
            this.ID.Name = "ID";
            this.ID.Width = 50;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 510);
            this.Controls.Add(this.btListReminders);
            this.Controls.Add(this.loginbtn);
            this.Controls.Add(this.dGVListAppointment);
            this.Controls.Add(this.btDetailAppointment);
            this.Controls.Add(this.btListAppointment);
            this.Controls.Add(this.btAddAppointment);
            this.Controls.Add(this.monthCalendar);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dGVListAppointment)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MonthCalendar monthCalendar;
        private System.Windows.Forms.Button btAddAppointment;
        private System.Windows.Forms.DataGridView dGVListAppointment;
        private System.Windows.Forms.Button btListAppointment;
        private System.Windows.Forms.Button btDetailAppointment;
        private System.Windows.Forms.Button loginbtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Appointment;
        private System.Windows.Forms.DataGridViewTextBoxColumn Location;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn EndTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.Button btListReminders;
    }
}

