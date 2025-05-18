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
            this.CreatorName = new System.Windows.Forms.Label();
            this.txtCreaatorName = new System.Windows.Forms.TextBox();
            this.singlerb = new System.Windows.Forms.RadioButton();
            this.grouprb = new System.Windows.Forms.RadioButton();
            this.typegb = new System.Windows.Forms.GroupBox();
            this.pnParticipants = new System.Windows.Forms.Panel();
            this.lblParticipants = new System.Windows.Forms.Label();
            this.lvParticipants = new System.Windows.Forms.ListView();
            this.btnAddParticipant = new System.Windows.Forms.Button();
            this.btnViewParticipants = new System.Windows.Forms.Button();
            this.typegb.SuspendLayout();
            this.pnParticipants.SuspendLayout();
            this.SuspendLayout();
            // 
            // btOK
            // 
            this.btOK.Location = new System.Drawing.Point(257, 370);
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
            this.dTPStartTime.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dTPStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dTPStartTime.Location = new System.Drawing.Point(195, 179);
            this.dTPStartTime.Margin = new System.Windows.Forms.Padding(2);
            this.dTPStartTime.Name = "dTPStartTime";
            this.dTPStartTime.Size = new System.Drawing.Size(284, 20);
            this.dTPStartTime.TabIndex = 3;
            // 
            // dTPEndTime
            // 
            this.dTPEndTime.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dTPEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dTPEndTime.Location = new System.Drawing.Point(195, 234);
            this.dTPEndTime.Margin = new System.Windows.Forms.Padding(2);
            this.dTPEndTime.Name = "dTPEndTime";
            this.dTPEndTime.Size = new System.Drawing.Size(284, 20);
            this.dTPEndTime.TabIndex = 3;
            // 
            // btDelete
            // 
            this.btDelete.Location = new System.Drawing.Point(446, 370);
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
            this.btReminder.Location = new System.Drawing.Point(66, 370);
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
            this.txtCreaatorName.ReadOnly = true;
            this.txtCreaatorName.Size = new System.Drawing.Size(284, 20);
            this.txtCreaatorName.TabIndex = 6;
            // 
            // singlerb
            // 
            this.singlerb.AutoSize = true;
            this.singlerb.Checked = true;
            this.singlerb.Location = new System.Drawing.Point(11, 19);
            this.singlerb.Name = "singlerb";
            this.singlerb.Size = new System.Drawing.Size(58, 17);
            this.singlerb.TabIndex = 7;
            this.singlerb.TabStop = true;
            this.singlerb.Text = "Normal";
            this.singlerb.UseVisualStyleBackColor = true;
            // 
            // grouprb
            // 
            this.grouprb.AutoSize = true;
            this.grouprb.Location = new System.Drawing.Point(11, 42);
            this.grouprb.Name = "grouprb";
            this.grouprb.Size = new System.Drawing.Size(92, 17);
            this.grouprb.TabIndex = 8;
            this.grouprb.TabStop = true;
            this.grouprb.Text = "GroupMeeting";
            this.grouprb.UseVisualStyleBackColor = true;
            // 
            // typegb
            // 
            this.typegb.Controls.Add(this.grouprb);
            this.typegb.Controls.Add(this.singlerb);
            this.typegb.Location = new System.Drawing.Point(101, 272);
            this.typegb.Name = "typegb";
            this.typegb.Size = new System.Drawing.Size(200, 78);
            this.typegb.TabIndex = 9;
            this.typegb.TabStop = false;
            this.typegb.Text = "==Meeting Type==";
            // 
            // pnParticipants
            // 
            this.pnParticipants.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnParticipants.Controls.Add(this.lblParticipants);
            this.pnParticipants.Controls.Add(this.lvParticipants);
            this.pnParticipants.Controls.Add(this.btnAddParticipant);
            this.pnParticipants.Controls.Add(this.btnViewParticipants);
            this.pnParticipants.Location = new System.Drawing.Point(101, 430);
            this.pnParticipants.Name = "pnParticipants";
            this.pnParticipants.Size = new System.Drawing.Size(378, 200);
            this.pnParticipants.TabIndex = 10;
            this.pnParticipants.Visible = false;
            // 
            // lblParticipants
            // 
            this.lblParticipants.AutoSize = true;
            this.lblParticipants.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblParticipants.Location = new System.Drawing.Point(3, 10);
            this.lblParticipants.Name = "lblParticipants";
            this.lblParticipants.Size = new System.Drawing.Size(86, 13);
            this.lblParticipants.TabIndex = 0;
            this.lblParticipants.Text = "Participants (0)";
            // 
            // lvParticipants
            // 
            this.lvParticipants.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvParticipants.FullRowSelect = true;
            this.lvParticipants.GridLines = true;
            this.lvParticipants.HideSelection = false;
            this.lvParticipants.Location = new System.Drawing.Point(6, 30);
            this.lvParticipants.Name = "lvParticipants";
            this.lvParticipants.Size = new System.Drawing.Size(367, 135);
            this.lvParticipants.TabIndex = 1;
            this.lvParticipants.UseCompatibleStateImageBehavior = false;
            this.lvParticipants.View = System.Windows.Forms.View.Details;
            // Thêm cột cho listview
            System.Windows.Forms.ColumnHeader columnUsername = new System.Windows.Forms.ColumnHeader();
            System.Windows.Forms.ColumnHeader columnName = new System.Windows.Forms.ColumnHeader();
            columnUsername.Text = "Username";
            columnName.Text = "Name";
            columnUsername.Width = 150;
            columnName.Width = 210;
            this.lvParticipants.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { columnUsername, columnName });
            // 
            // btnAddParticipant
            // 
            this.btnAddParticipant.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right));
            this.btnAddParticipant.Location = new System.Drawing.Point(273, 171);
            this.btnAddParticipant.Name = "btnAddParticipant";
            this.btnAddParticipant.Size = new System.Drawing.Size(100, 23);
            this.btnAddParticipant.TabIndex = 2;
            this.btnAddParticipant.Text = "Add Participant";
            this.btnAddParticipant.UseVisualStyleBackColor = true;
            this.btnAddParticipant.Visible = false;
            this.btnAddParticipant.Click += new System.EventHandler(this.btnAddParticipant_Click);
            // 
            // btnViewParticipants
            // 
            this.btnViewParticipants.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left));
            this.btnViewParticipants.Location = new System.Drawing.Point(166, 171);
            this.btnViewParticipants.Name = "btnViewParticipants";
            this.btnViewParticipants.Size = new System.Drawing.Size(100, 23);
            this.btnViewParticipants.TabIndex = 3;
            this.btnViewParticipants.Text = "View Participants";
            this.btnViewParticipants.UseVisualStyleBackColor = true;
            this.btnViewParticipants.Visible = true;
            this.btnViewParticipants.Click += new System.EventHandler(this.btnViewParticipants_Click);
            // 
            // AppointmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 650);
            this.Controls.Add(this.pnParticipants);
            this.Controls.Add(this.typegb);
            this.Controls.Add(this.txtCreaatorName);
            this.Controls.Add(this.CreatorName);
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
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AppointmentForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AppointmentForm_FormClosed);
            this.typegb.ResumeLayout(false);
            this.typegb.PerformLayout();
            this.pnParticipants.ResumeLayout(false);
            this.pnParticipants.PerformLayout();
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
        private System.Windows.Forms.Label CreatorName;
        private System.Windows.Forms.TextBox txtCreaatorName;
        private System.Windows.Forms.RadioButton singlerb;
        private System.Windows.Forms.RadioButton grouprb;
        private System.Windows.Forms.GroupBox typegb;
        private System.Windows.Forms.Panel pnParticipants;
        private System.Windows.Forms.Label lblParticipants;
        private System.Windows.Forms.ListView lvParticipants;
        private System.Windows.Forms.Button btnAddParticipant;
        private System.Windows.Forms.Button btnViewParticipants;
    }
}