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
using AddCalendarAppointment.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace AddCalendarAppointment.Forms
{
    public partial class ReminderForm: Form
    {   
        private readonly IReminderService _remSvc;
        private readonly IAppointmentService _apptSvc;
        private readonly int _appointmentId;
        private readonly IServiceProvider _rootProvider;
        
        public ReminderForm(IServiceProvider rootProvider, IReminderService remSvc, IAppointmentService apptSvc, int appointmentId, string appointmentName)
        {
            InitializeComponent();
            _rootProvider = rootProvider;
            _remSvc = remSvc;
            _apptSvc = apptSvc;
            _appointmentId = appointmentId;
            txtAppointmentName.Text = appointmentName;
            LoadReminders();
        }


        private void btAddReminder_Click(object sender, EventArgs e)
        {
            // Hiển thị menu để chọn loại reminder
            ContextMenuStrip reminderMenu = new ContextMenuStrip();
            
            reminderMenu.Items.Add("At time of event", null, (s, args) => CreateReminderWithOffset(TimeSpan.Zero));
            reminderMenu.Items.Add("10 minutes before", null, (s, args) => CreateReminderWithOffset(TimeSpan.FromMinutes(-10)));
            reminderMenu.Items.Add("1 hour before", null, (s, args) => CreateReminderWithOffset(TimeSpan.FromHours(-1)));
            reminderMenu.Items.Add("1 day before", null, (s, args) => CreateReminderWithOffset(TimeSpan.FromDays(-1)));
            reminderMenu.Items.Add("Custom...", null, (s, args) => ShowCustomReminderDialog());
            
            reminderMenu.Show(btAddReminder, new Point(0, btAddReminder.Height));
        }

        private void CreateReminderWithOffset(TimeSpan offset)
        {
            // Lấy thông tin về appointment - sử dụng _apptSvc thay vì _remSvc
            var appointment = _apptSvc.GetAppointmentById(_appointmentId);
            if (appointment == null) return;
            
            DateTime reminderTime = appointment.StartTime.Add(offset);
            string message = GenerateDefaultMessage(offset);
            
            // Tạo mới reminder
            var reminder = new Reminder
            {
                AppointmentID = _appointmentId,
                Message = message,
                ReminderTime = reminderTime
            };
            
            _remSvc.AddReminder(reminder);
            LoadReminders();
            
            MessageBox.Show($"Reminder set for {reminderTime.ToString("g")}", "Reminder Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private string GenerateDefaultMessage(TimeSpan offset)
        {
            if (offset == TimeSpan.Zero)
                return "Event starting now";
            else if (offset.TotalMinutes == -10)
                return "Event starting in 10 minutes";
            else if (offset.TotalHours == -1)
                return "Event starting in 1 hour";
            else if (offset.TotalDays == -1)
                return "Event starting tomorrow";
            else
            {
                // For custom offsets
                int value = (int)Math.Abs(offset.TotalMinutes);
                string unit = "minutes";
                
                if (value >= 1440) // 24 hours in minutes
                {
                    value = (int)Math.Abs(offset.TotalDays);
                    unit = value == 1 ? "day" : "days";
                }
                else if (value >= 60)
                {
                    value = (int)Math.Abs(offset.TotalHours);
                    unit = value == 1 ? "hour" : "hours";
                }
                
                return $"Event starting in {value} {unit}";
            }
        }

        private void ShowCustomReminderDialog()
        {
            // Tạo và hiển thị form để nhập cấu hình tùy chỉnh
            Form customForm = new Form
            {
                Text = "Custom Reminder",
                Size = new Size(300, 200),
                FormBorderStyle = FormBorderStyle.FixedDialog,
                StartPosition = FormStartPosition.CenterParent,
                MaximizeBox = false,
                MinimizeBox = false
            };
            
            Label valueLabel = new Label { Text = "Value:", Location = new Point(20, 20), AutoSize = true };
            NumericUpDown valueInput = new NumericUpDown
            {
                Location = new Point(120, 20),
                Minimum = 1,
                Maximum = 100,
                Value = 1,
                Width = 100
            };
            
            Label unitLabel = new Label { Text = "Unit:", Location = new Point(20, 50), AutoSize = true };
            ComboBox unitInput = new ComboBox
            {
                Location = new Point(120, 50),
                DropDownStyle = ComboBoxStyle.DropDownList,
                Width = 100
            };
            unitInput.Items.AddRange(new string[] { "Minutes", "Hours", "Days", "Weeks" });
            unitInput.SelectedIndex = 0;
            
            Button okButton = new Button
            {
                Text = "OK",
                Location = new Point(120, 100),
                DialogResult = DialogResult.OK
            };
            
            customForm.Controls.AddRange(new Control[] { valueLabel, valueInput, unitLabel, unitInput, okButton });
            customForm.AcceptButton = okButton;
            
            if (customForm.ShowDialog() == DialogResult.OK)
            {
                int value = (int)valueInput.Value;
                TimeSpan offset;
                
                switch (unitInput.SelectedIndex)
                {
                    case 0: // Minutes
                        offset = TimeSpan.FromMinutes(-value);
                        break;
                    case 1: // Hours
                        offset = TimeSpan.FromHours(-value);
                        break;
                    case 2: // Days
                        offset = TimeSpan.FromDays(-value);
                        break;
                    case 3: // Weeks
                        offset = TimeSpan.FromDays(-value * 7);
                        break;
                    default:
                        offset = TimeSpan.FromMinutes(-value);
                        break;
                }
                
                CreateReminderWithOffset(offset);
            }
        }

        private void LoadReminders()
        {
            // Fetch from DB
            var list = _remSvc
                .GetRemindersForAppointment(_appointmentId)
                .Select(r => new {
                    ReminderID = r.ReminderID,
                    Time = r.ReminderTime.ToString("g"),
                    Message = r.Message
                })
                .ToList();

            // Clear existing columns and data
            dGVListReminder.DataSource = null;
            dGVListReminder.Columns.Clear();

            // Add columns explicitly
            dGVListReminder.Columns.Add("Number", "#");
            dGVListReminder.Columns.Add("Time", "Time");
            dGVListReminder.Columns.Add("Message", "Message");
            dGVListReminder.Columns.Add("ReminderID", "ReminderID");

            // Set column properties
            dGVListReminder.Columns["Number"].Width = 40;
            dGVListReminder.Columns["Time"].Width = 150;
            dGVListReminder.Columns["Message"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dGVListReminder.Columns["ReminderID"].Visible = false;

            // Add data manually
            dGVListReminder.Rows.Clear();
            for (int i = 0; i < list.Count; i++)
            {
                var item = list[i];
                int rowIdx = dGVListReminder.Rows.Add();
                var row = dGVListReminder.Rows[rowIdx];
                
                row.Cells["Number"].Value = (i + 1).ToString();
                row.Cells["Time"].Value = item.Time;
                row.Cells["Message"].Value = item.Message;
                row.Cells["ReminderID"].Value = item.ReminderID;
            }

            // Configure grid appearance
            dGVListReminder.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dGVListReminder.ReadOnly = true;
            dGVListReminder.AllowUserToAddRows = false;
            dGVListReminder.AllowUserToDeleteRows = false;
            dGVListReminder.AllowUserToResizeRows = false;
            dGVListReminder.MultiSelect = false;
            dGVListReminder.RowHeadersVisible = false;
        }

        private void btView_Click(object sender, EventArgs e)
        {
            if (dGVListReminder.SelectedRows.Count == 1)
            {
                // Lấy ReminderID từ cột ẩn
                int reminderId = Convert.ToInt32(dGVListReminder.SelectedRows[0].Cells["ReminderID"].Value);
                
                // Clear panel trước khi thêm control mới
                pnReminder.Controls.Clear();

                var control = new ReminderControl();
                control.Init(_rootProvider, _remSvc, _appointmentId, reminderId);
                
                control.Dock = DockStyle.Fill;
                control.ReminderSaved += (_, __) => LoadReminders();
                control.ReminderDeleted += (_, __) => {
                    pnReminder.Controls.Clear();
                    LoadReminders();
                };

                pnReminder.Controls.Add(control);
            }
            else
            {
                MessageBox.Show("Please select one reminder to view.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
