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
            var user = _userSvc.CurrentUser;

            // Get appointments created by the current user
            var appointments = _appointmentService.GetAppointments()
                .Where(a => a.CreatedBy == user.UserID)
                .ToList();

            // Convert to a display-friendly format
            var displayList = appointments.Select(a => new
            {
                ID = a.AppointmentID,
                AppointmentName = a.Name,
                Location = a.Location,
                StartTime = a.StartTime.ToString("g"),
                EndTime = a.EndTime.ToString("g"),
                Type = a.IsGroup ? "Group" : "Personal"
                //other properties can be added here
            }).ToList();
            dGVListAppointment.Columns.Clear();
            dGVListAppointment.DataSource = null;
            dGVListAppointment.DataSource = displayList;


            dGVListAppointment.Columns["ID"].Visible = false;

            // Set column widths
            dGVListAppointment.Columns["AppointmentName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dGVListAppointment.Columns["Location"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dGVListAppointment.Columns["StartTime"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dGVListAppointment.Columns["EndTime"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dGVListAppointment.Columns["Type"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            // Rename headers
            dGVListAppointment.Columns["AppointmentName"].HeaderText = "Appointment Name";
            dGVListAppointment.Columns["StartTime"].HeaderText = "Start Time";
            dGVListAppointment.Columns["EndTime"].HeaderText = "End Time";

            // Enable full row selection
            dGVListAppointment.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dGVListAppointment.MultiSelect = false;
            dGVListAppointment.ReadOnly = true;

            // Optional: Make sure headers are visible
            dGVListAppointment.ColumnHeadersVisible = true;
            dGVListAppointment.RowHeadersVisible = false;
        }

        private void btAddAppointment_Click(object sender, EventArgs e)
        {
            DateTime selectedDate = monthCalendar.SelectionStart;
            DateTime Now = DateTime.Now;
            DateTime selectedDateTime = new DateTime(selectedDate.Year, selectedDate.Month, selectedDate.Day, Now.Hour, Now.Minute, Now.Second);
            var user = _userSvc.CurrentUser;
            try
            {
                Appointment_DTO appointment = new Appointment_DTO()
                {
                    Id = null,
                    CreatorName = user.Name,
                    Name = "Please enter the appointment name",
                    Location = "Please enter the Location",
                    startTime = selectedDateTime,
                    endTime = selectedDateTime.AddHours(1),
                    isGroup = false,
                    createdBy = user.UserID
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
                var selectedId = Convert.ToInt32(dGVListAppointment.SelectedRows[0].Cells["ID"].Value);
                var appointment = _appointmentService.GetAppointmentById(selectedId);
                if (appointment == null)
                {
                    MessageBox.Show("Could not find appointment details.");
                    return;
                }

                Appointment_DTO dto = _appointmentService.ConvertToDTO(appointment);
                dto.CreatorName = _userSvc.CurrentUser.Name;//workaround due to model Appointment not having this property

                using (var scope = _rootProvider.CreateScope())
                {
                    var detailForm = ActivatorUtilities.CreateInstance<AppointmentForm>(
                        scope.ServiceProvider,
                        dto
                    );

                    detailForm.ShowDialog();
                }
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
            loginbtn.BackColor = (u.UserID == 1)
                ? Color.LightGreen
                : Color.Red;
        }
        private void loginbtn_Click(object sender, EventArgs e)
        {
            if (_userSvc.CurrentUser.UserID == 1)
            {

                using (var scope = _rootProvider.CreateScope())
                {
                    var loginForm = scope.ServiceProvider.GetRequiredService<Login>();
                    if (loginForm.ShowDialog() == DialogResult.OK)
                        UpdateLoginButton();
                    //clear the appointment list only the data not the columns
                    dGVListAppointment.DataSource = null;
                }
            }
            else
            {
                // Perform Logout
                _userSvc.Logout();
                UpdateLoginButton();
                // Clear the appointment list
                dGVListAppointment.DataSource = null;
            }

        }
    }
}
