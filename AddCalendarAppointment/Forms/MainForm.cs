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
using System.Data.Entity;
using AddCalendarAppointment.DTO;
using AddCalendarAppointment.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace AddCalendarAppointment
{
    public partial class MainForm: Form
    {
        private readonly IServiceProvider _rootProvider;
        private readonly IUserService _userSvc;
        private readonly IAppointmentService _appointmentService;
        public MainForm(IServiceProvider rootProvider,IAppointmentService appointmentService, IUserService userSvc)
        {
            _rootProvider = rootProvider;
            _userSvc = userSvc;
            _appointmentService = appointmentService;
            InitializeComponent();
        }

        private void LoadAppointments()
        {
            // xư lý load appointment
        }

        private void btAddAppointment_Click(object sender, EventArgs e)
        {
            DateTime selectedDate = monthCalendar.SelectionStart;
            DateTime Now = DateTime.Now;
            DateTime selectedDateTime = new DateTime(selectedDate.Year, selectedDate.Month, selectedDate.Day, Now.Hour, Now.Minute, Now.Second);

            try
            {
                Appointment_DTO appointment = new Appointment_DTO()
                {
                    Id = null,
                    CreatorName = "Please enter your name",
                    Name = "Please enter the appointment name",
                    Location = "Please enter the Location",
                    startTime = selectedDateTime,
                    endTime = selectedDateTime.AddHours(1),
                    isGroup = false,
                    createdBy = null,
                };
                using (var scope = _rootProvider.CreateScope())
                {
                    var apptForm = ActivatorUtilities.CreateInstance<AppointmentForm>(
                        scope.ServiceProvider,
                        appointment
                    );

                    apptForm.ShowDialog();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btListAppointment_Click(object sender, EventArgs e)
        {
            
            LoadAppointments();
        }

        private void btDetailAppointment_Click(object sender, EventArgs e)
        {
            if (dGVListAppointment.SelectedRows.Count > 0)
            {
            }
            else
            {
                MessageBox.Show("Please select an appointment to view details.");
            }
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            UpdateLoginButton();
        }
        private void UpdateLoginButton()
        {
            var u = _userSvc.CurrentUser;
            loginbtn.Text = (u.UserID == 1)
                ? "Login"
                : $"Logout ({u.Username})";
        }
        private void loginbtn_Click(object sender, EventArgs e)
        {
            if (_userSvc.CurrentUser.UserID == 1)
            {
                // Show LoginForm
                using (var login = _rootProvider.GetRequiredService<Login>())
                {
                    if (login.ShowDialog() == DialogResult.OK)
                        UpdateLoginButton();
                }
            }
            else
            {
                // Perform Logout
                _userSvc.Logout();
                UpdateLoginButton();
            }

        }
    }
}
