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
using Microsoft.Extensions.DependencyInjection;

namespace AddCalendarAppointment.Forms
{
    public partial class ReminderForm: Form
    {   
        private readonly IReminderService _remSvc;
        private readonly int _appointmentId;
        private readonly IServiceProvider _rootProvider;
        public ReminderForm(IServiceProvider rootProvider, IReminderService remSvc, int appointmentId, string appointmentName)
        {
            InitializeComponent();
            _rootProvider = rootProvider;
            _remSvc = remSvc;
            _appointmentId = appointmentId;
            txtAppointmentName.Text = appointmentName;
            LoadReminders();
        }


        private void btAddReminder_Click(object sender, EventArgs e)
        {
            //pnReminder.Controls.Clear();

            var control = new ReminderControl();
            control.Init(_rootProvider, _remSvc, _appointmentId, null);

            control.Dock = DockStyle.Fill;
            control.ReminderSaved += (_, __) => LoadReminders();
            //pnReminder.Controls.Clear();
            pnReminder.Controls.Add(control);
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
                int reminderId = Convert.ToInt32(dGVListReminder.SelectedRows[0].Cells["ReminderID"].Value);
                //pnReminder.Controls.Clear();

                var control = new ReminderControl();
                control.Init(_rootProvider, _remSvc, _appointmentId, reminderId);
                
                control.Dock = DockStyle.Fill;
                control.ReminderSaved += (_, __) => LoadReminders();
                control.ReminderDeleted += (_, __) => {
                    pnReminder.Controls.Clear();
                    LoadReminders();
                };

                pnReminder.Controls.Add(control);
            }
            else
            {
                MessageBox.Show("Please select one reminder to view.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
