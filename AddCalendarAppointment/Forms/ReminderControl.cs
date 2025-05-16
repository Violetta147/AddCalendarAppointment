using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AddCalendarAppointment.Forms
{
    public partial class ReminderControl: UserControl
    {
        public string ReminderID { get; set; }
        public ReminderControl(string reminderID)
        {
            InitializeComponent();
            ReminderID = reminderID;
            LoadData();
        }

        public void LoadData()
        {
            // bll xử lý loaddata gồm time và message
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            Reminder reminder = new Reminder()
            {
                Message = txtMessage.Text,
                ReminderTime = dTPTime.Value
            };
            // bll xử lý thêm, sửa reminder
            
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            // bll xử lý xóa reminder
        }
    }
}
