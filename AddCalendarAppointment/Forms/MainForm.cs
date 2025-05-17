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

namespace AddCalendarAppointment
{
    public partial class MainForm: Form
    {   
        private readonly IAppointmentService _appointmentService;
        public MainForm(IAppointmentService appointmentService)
        {
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
                using (AppointmentForm appf = new AppointmentForm(appointment, _appointmentService))
                {
                    appf.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
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
        }

        private void loginbtn_Click(object sender, EventArgs e)
        {

        }
    }
}
