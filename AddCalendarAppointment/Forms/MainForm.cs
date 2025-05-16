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

namespace AddCalendarAppointment
{
    public partial class MainForm: Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void LoadAppointments()
        {
            // xư lý load appointment
        }

        private void btAddAppointment_Click(object sender, EventArgs e)
        {
            AppointmentForm appointmentForm = new AppointmentForm("");
            appointmentForm.ShowDialog();
        }

        private void btListAppointment_Click(object sender, EventArgs e)
        {
            LoadAppointments();
        }

        private void btDetailAppointment_Click(object sender, EventArgs e)
        {
            if (dGVListAppointment.SelectedRows.Count == 1)
            {
                string appointmentId = dGVListAppointment.SelectedRows[0].Cells["AppointmentID"].Value.ToString();
                AppointmentForm appointmentForm = new AppointmentForm(appointmentId);
                appointmentForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select an appointment to view details.");
            }
        }
    }
}
