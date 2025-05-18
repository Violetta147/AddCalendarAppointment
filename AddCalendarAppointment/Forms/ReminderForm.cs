using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AddCalendarAppointment.Forms;
using AddCalendarAppointment.Services.Interfaces;

namespace AddCalendarAppointment.Forms
{
    public partial class ReminderForm: Form
    {   
        private readonly IReminderService _remSvc;
        private readonly int _appointmentId;
        public ReminderForm(IReminderService remSvc, int appointmentId, string appointmentName)
        {
            InitializeComponent();
            _remSvc = remSvc;
            _appointmentId = appointmentId;
            txtAppointmentName.Text = appointmentName;
            LoadReminders();
        }


        private void btAddReminder_Click(object sender, EventArgs e)
        {
            pnReminder.Controls.Clear();
            UserControl reminderControl = new ReminderControl("");
            reminderControl.Dock = DockStyle.Fill;
            pnReminder.Controls.Add(reminderControl);
        }

        private void btListReminder_Click(object sender, EventArgs e)
        {
            LoadReminders();
        }
        private void LoadReminders()
        {
            // Fetch from DB
            var list = _remSvc
                .GetRemindersForAppointment(_appointmentId)
                .Select(r => new {
                    ReminderID = r.ReminderID,
                    Time = r.ReminderTime.ToString("g"),
                    Message = r.Message
                })
                .ToList();

            dGVListReminder.DataSource = list;
            dGVListReminder.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dGVListReminder.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void btView_Click(object sender, EventArgs e)
        {
            if (dGVListReminder.SelectedRows.Count == 1)
            {
                string reminderId = dGVListReminder.SelectedRows[0].Cells["Number"].Value.ToString();
                pnReminder.Controls.Clear();
                UserControl reminderControl = new ReminderControl(reminderId);
                reminderControl.Dock = DockStyle.Fill;
                pnReminder.Controls.Add(reminderControl);
            }
            else
            {
                MessageBox.Show("Please select one reminder to view.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
