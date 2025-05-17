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
        private readonly IAppointmentService _appointmentService;
        public AppointmentForm(IAppointmentService appointmentService,Appointment_DTO appointment)
        {
            _appointment = appointment;
            _appointmentService = appointmentService;
            //_reminderService = reminderService;
            InitializeComponent();
            LoadUI();
        }

        public void LoadUI() 
        {   
            txtCreaatorName.Text = _appointment.CreatorName;
            txtAppointmentName.Text = _appointment.Name;
            txtLocation.Text = _appointment.Location;
            dTPStartTime.Value = _appointment.startTime;
            dTPEndTime.Value = _appointment.endTime;
            if (_appointment.isGroup)
            {
                grouprb.Checked = true;
            }
            else
            {
                grouprb.Checked = false;
            }
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAppointmentName.Text))
            {
                MessageBox.Show("Appointment name cannot be empty.");
                return;
            }
            if (dTPEndTime.Value <= dTPStartTime.Value)
            {
                MessageBox.Show("End time must be after start time.");
                return;
            }
            _appointment.Name = txtAppointmentName.Text;
            _appointment.Location = txtLocation.Text;
            _appointment.startTime = dTPStartTime.Value;
            _appointment.endTime = dTPEndTime.Value;
            _appointment.createdBy = _appointment.createdBy;
            _appointment.isGroup = grouprb.Checked;
            //other properties
            Appointment appointmentEntity = _appointmentService.ConvertFromDTO(_appointment);
            //if new appointment
            _appointmentService.CreateAppointment(appointmentEntity);
            //if update appointment
            MessageBox.Show("Appointment created successfully");
            this.Close();
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
