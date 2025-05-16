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
    public partial class AppointmentForm: Form
    {
        public string AppointmentID { get; set; }

        public AppointmentForm(string AppointmentId)
        {
            InitializeComponent();
            AppointmentID = AppointmentId;
            LoadUI();
        }

        public void LoadUI()
        {
            if (AppointmentID == "")
            { 

            }
            else
            {
                // bll xử lý load appointment
                txtID.ReadOnly = true;
            }    

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
