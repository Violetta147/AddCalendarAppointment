using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AddCalendarAppointment.Services.Interfaces;

namespace AddCalendarAppointment.Forms
{
    public partial class ReminderControl: UserControl
    {
        private IReminderService _remSvc;
        private int _appointmentId;
        private int? _reminderId;
        private IServiceProvider _rootProvider;
        public event EventHandler ReminderSaved;
        public event EventHandler ReminderDeleted;

        public ReminderControl()
        {
            InitializeComponent();
        }

        public void Init(IServiceProvider rootProvider, IReminderService remSvc, int appointmentId, int? reminderId)
        {
            _remSvc = remSvc;
            _rootProvider = rootProvider;
            _appointmentId = appointmentId;
            _reminderId = reminderId;
            LoadData();
        }

        public ReminderControl(IServiceProvider rootProvider, IReminderService remSvc, int appointmentId, int? reminderId)
        {
            _remSvc = remSvc;
            _rootProvider = rootProvider;
            _appointmentId = appointmentId;
            _reminderId = reminderId;
            InitializeComponent();
            LoadData();
        }

        public void LoadData()
        {
            if (_reminderId.HasValue && _remSvc != null)
            {
                var reminder = _remSvc.GetReminderById(_reminderId.Value);
                if (reminder != null)
                {
                    txtMessage.Text = reminder.Message;
                    dTPTime.Value = reminder.ReminderTime;
                }
            }
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            if (_remSvc == null)
            {
                MessageBox.Show("Service not initialized");
                return;
            }

            var reminder = new Reminder()
            {
                AppointmentID = _appointmentId,
                Message = txtMessage.Text,
                ReminderTime = dTPTime.Value
            };

            if (_reminderId.HasValue)
            {
                reminder.ReminderID = _reminderId.Value;
                _remSvc.UpdateReminder(reminder);
            }
            else
            {
                _remSvc.AddReminder(reminder);
            }

            ReminderSaved?.Invoke(this, EventArgs.Empty);
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            if (_remSvc == null)
            {
                MessageBox.Show("Service not initialized");
                return;
            }

            if (_reminderId.HasValue)
            {
                _remSvc.DeleteReminder(_reminderId.Value);
                ReminderDeleted?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
