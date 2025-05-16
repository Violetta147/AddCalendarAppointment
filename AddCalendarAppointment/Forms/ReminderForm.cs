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

namespace AddCalendarAppointment.Forms
{
    public partial class ReminderForm: Form
    {
        public ReminderForm(string appointmentName)
        {
            InitializeComponent();
            txtAppointmentName.Text = appointmentName;
        }

        private void LoadReminders()
        {
            // xử lý load reminder
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
