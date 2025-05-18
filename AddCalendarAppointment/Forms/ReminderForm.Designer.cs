namespace AddCalendarAppointment.Forms
{
    partial class ReminderForm
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
            this.btAddReminder = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dGVListReminder = new System.Windows.Forms.DataGridView();
            this.Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Message = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnReminder = new System.Windows.Forms.Panel();
            this.txtAppointmentName = new System.Windows.Forms.TextBox();
            this.btView = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dGVListReminder)).BeginInit();
            this.SuspendLayout();
            // 
            // btAddReminder
            // 
            this.btAddReminder.Location = new System.Drawing.Point(25, 80);
            this.btAddReminder.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btAddReminder.Name = "btAddReminder";
            this.btAddReminder.Size = new System.Drawing.Size(112, 19);
            this.btAddReminder.TabIndex = 0;
            this.btAddReminder.Text = "Add Reminder";
            this.btAddReminder.UseVisualStyleBackColor = true;
            this.btAddReminder.Click += new System.EventHandler(this.btAddReminder_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Appointment Name";
            // 
            // dGVListReminder
            // 
            this.dGVListReminder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVListReminder.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Number,
            this.Time,
            this.Message});
            this.dGVListReminder.Location = new System.Drawing.Point(4, 121);
            this.dGVListReminder.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dGVListReminder.Name = "dGVListReminder";
            this.dGVListReminder.RowHeadersWidth = 51;
            this.dGVListReminder.Size = new System.Drawing.Size(368, 244);
            this.dGVListReminder.TabIndex = 3;
            // 
            // Number
            // 
            this.Number.HeaderText = "Number";
            this.Number.MinimumWidth = 6;
            this.Number.Name = "Number";
            this.Number.Width = 50;
            // 
            // Time
            // 
            this.Time.HeaderText = "Time";
            this.Time.MinimumWidth = 6;
            this.Time.Name = "Time";
            this.Time.Width = 70;
            // 
            // Message
            // 
            this.Message.HeaderText = "Message";
            this.Message.MinimumWidth = 6;
            this.Message.Name = "Message";
            this.Message.Width = 250;
            // 
            // pnReminder
            // 
            this.pnReminder.Location = new System.Drawing.Point(375, 0);
            this.pnReminder.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnReminder.Name = "pnReminder";
            this.pnReminder.Size = new System.Drawing.Size(225, 366);
            this.pnReminder.TabIndex = 4;
            // 
            // txtAppointmentName
            // 
            this.txtAppointmentName.Location = new System.Drawing.Point(118, 23);
            this.txtAppointmentName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtAppointmentName.Name = "txtAppointmentName";
            this.txtAppointmentName.ReadOnly = true;
            this.txtAppointmentName.Size = new System.Drawing.Size(226, 20);
            this.txtAppointmentName.TabIndex = 5;
            // 
            // btView
            // 
            this.btView.Location = new System.Drawing.Point(182, 80);
            this.btView.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btView.Name = "btView";
            this.btView.Size = new System.Drawing.Size(114, 19);
            this.btView.TabIndex = 6;
            this.btView.Text = "View";
            this.btView.UseVisualStyleBackColor = true;
            this.btView.Click += new System.EventHandler(this.btView_Click);
            // 
            // ReminderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.btView);
            this.Controls.Add(this.txtAppointmentName);
            this.Controls.Add(this.pnReminder);
            this.Controls.Add(this.dGVListReminder);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btAddReminder);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ReminderForm";
            this.Text = "ReminderForm";
            ((System.ComponentModel.ISupportInitialize)(this.dGVListReminder)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btAddReminder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dGVListReminder;
        private System.Windows.Forms.Panel pnReminder;
        private System.Windows.Forms.TextBox txtAppointmentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn Time;
        private System.Windows.Forms.DataGridViewTextBoxColumn Message;
        private System.Windows.Forms.Button btView;
    }
}