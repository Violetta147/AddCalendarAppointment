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
using Microsoft.Extensions.DependencyInjection;

namespace AddCalendarAppointment.Forms
{
    public partial class AppointmentForm: Form
    {
        private readonly Appointment_DTO _appointment;
        private readonly IAppointmentService _appointmentService;
        private readonly IServiceProvider _rootProvider;
        private readonly IReminderService _remSvc;
        private bool _savedToDb;
        private bool _shouldCleanup = false;

        public AppointmentForm(IAppointmentService appointmentService,Appointment_DTO appointment, IServiceProvider rootProvider, IReminderService reminderService)
        {

            _rootProvider = rootProvider;
            _appointment = appointment;
            _appointmentService = appointmentService;
            _remSvc = reminderService;
            _savedToDb = _appointment.Id.HasValue;
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
            if (string.IsNullOrWhiteSpace(txtLocation.Text))
            {
                MessageBox.Show("Location cannot be empty.");
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
            if (_savedToDb)
            {
                // We either drafted it above, or it was an existing record:
                _appointmentService.UpdateAppointment(appointmentEntity);
            }
            else
            {
                // A truly new (never-drafted/created) appointment
                int newId = _appointmentService.CreateAppointment(appointmentEntity);
                _appointment.Id = newId;
                _savedToDb = true;
            }
            MessageBox.Show("Appointment created successfully");
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btReminder_Click(object sender, EventArgs e)
        {
            // If we haven’t saved anything yet, create the appointment now
            if (!_savedToDb)
            {
                try
                {
                    // Convert DTO to an <entity—excluding> ID
                    var entity = _appointmentService.ConvertFromDTO(_appointment);

                    // Save it; this returns the new ID
                    int newId = _appointmentService.CreateAppointment(entity);

                    // Sync ID back to DTO and mark it saved
                    _appointment.Id = newId;
                    _savedToDb = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Could not create draft appointment:\n" + ex.Message,
                                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            // Now _dto.Id is non-null, safely open ReminderForm
            using (var scope = _rootProvider.CreateScope())
            {
                var reminderForm = ActivatorUtilities.CreateInstance<ReminderForm>(
                    scope.ServiceProvider,
                    _appointment.Id.Value,
                    _appointment.Name);

                reminderForm.ShowDialog();
            }
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            if (_appointment.Id.HasValue)
            {
                try
                {
                    // 1) Remove reminders explicitly (if needed)
                    _remSvc.DeleteRemindersByAppointmentId(_appointment.Id.Value);

                    // 2) Remove the appointment
                    _appointmentService.DeleteAppointment(_appointment.Id.Value);

                    MessageBox.Show("Appointment deleted successfully");

                    // 3) Prevent the “draft cleanup” from running:
                    _shouldCleanup = false;

                    // 4) We can set DialogResult to OK so that
                    //    FormClosing sees it as an intentional action
                    this.DialogResult = DialogResult.OK;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Could not delete appointment:\n" + ex.Message,
                                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No appointment to delete.");
            }

            // Finally, close the form
            this.Close();
        }

        private void AppointmentForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_shouldCleanup)
            {
                try
                {
                    //first delete all reminders
                    _remSvc.DeleteRemindersByAppointmentId(_appointment.Id.Value);
                }
                catch { /* swallow or log */ }

                try
                {
                    //then delete the appointment
                    _appointmentService.DeleteAppointment(_appointment.Id.Value);
                }
                catch { /* swallow or log */ }
            }
        }

        private void AppointmentForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // We only want to clean up if:
            //  1) We DID save something (_savedToDb == true)
            //  2) The user did NOT click OK (DialogResult != OK)
            if (_savedToDb && this.DialogResult != DialogResult.OK && _appointment.Id.HasValue)
            {
                _shouldCleanup = true;
            }
        }
    }
}
