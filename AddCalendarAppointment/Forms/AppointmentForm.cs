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
using AddCalendarAppointment.DTO;
using AddCalendarAppointment.Services.Interfaces;

namespace AddCalendarAppointment.Forms
{
    public partial class AppointmentForm: Form
    {
        private readonly Appointment_DTO _appointment;
        //private readonly IReminderService _reminderService; //later
        public AppointmentForm(Appointment_DTO appointment)
        {
            _appointment = appointment;
            //_reminderService = reminderService;
            InitializeComponent();
            LoadUI();
        }

        public void LoadUI() 
        {   
            txtID.Text = _appointment.Id == null ? string.Empty : _appointment.Id.ToString();
            txtUserId.Text = _appointment.createdBy == null ? string.Empty : _appointment.createdBy.ToString();
            txtCreaatorName.Text = _appointment.CreatorName;
            txtAppointmentName.Text = _appointment.Name;
            txtLocation.Text = _appointment.Location;
            dTPStartTime.Value = _appointment.startTime;
            dTPEndTime.Value = _appointment.endTime;
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            // xử lý thêm, sửa appointment

        }

        private void btReminder_Click(object sender, EventArgs e)
        {
            string appointmentName = txtAppointmentName.Text;
            ReminderForm reminderForm = new ReminderForm(appointmentName);
            reminderForm.ShowDialog();
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            // xử lý xóa appointment
            this.Close();
        }
    }
}
