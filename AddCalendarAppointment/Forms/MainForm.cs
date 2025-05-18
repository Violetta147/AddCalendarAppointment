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
    public partial class MainForm : Form
    {
        private readonly IServiceProvider _rootProvider;
        private readonly IUserService _userSvc;
        private readonly IAppointmentService _appointmentService;
        private readonly IReminderService _reminderService;
        private Timer _reminderTimer;

        public MainForm(IServiceProvider rootProvider, IAppointmentService appointmentService, IUserService userSvc, IReminderService reminderService)
        {
            _rootProvider = rootProvider;
            _userSvc = userSvc;
            _appointmentService = appointmentService;
            _reminderService = reminderService;
            InitializeComponent();
            StartReminderTimer();
        }

        private void StartReminderTimer()
        {
            _reminderTimer = new Timer { Interval = 60 * 1000 }; // Check every minute
            _reminderTimer.Tick += (s, e) => CheckReminders();
            _reminderTimer.Start();
        }

        private void CheckReminders()
        {
            try
            {
                var now = DateTime.Now;
                var currentUser = _userSvc.CurrentUser;
                // Chỉ lấy reminder của người dùng hiện tại
                var dueReminders = _reminderService.GetDueReminders(now, currentUser.UserID);

                foreach (var reminder in dueReminders)
                {
                    // Fetch the associated appointment to show in the notification
                    var appointment = _appointmentService.GetAppointmentById(reminder.AppointmentID);
                    if (appointment == null) continue;

                    // Calculate time difference from now to appointment start time
                    string timeDescription;
                    TimeSpan difference = appointment.StartTime - now;

                    if (difference.TotalMinutes <= 1)
                    {
                        timeDescription = "Starting now";
                    }
                    else if (difference.TotalMinutes < 60)
                    {
                        timeDescription = $"Starting in {(int)difference.TotalMinutes} minutes";
                    }
                    else if (difference.TotalHours < 24)
                    {
                        timeDescription = $"Starting in {(int)difference.TotalHours} hours";
                    }
                    else
                    {
                        timeDescription = $"Starting in {(int)difference.TotalDays} days";
                    }

                    string message = $"Appointment: {appointment.Name}\nLocation: {appointment.Location}\n{timeDescription}\n\nReminder message: {reminder.Message}";

                    // Hiển thị tên sự kiện cụ thể trong tiêu đề thông báo
                    DialogResult result = MessageBox.Show(
                        message,
                        $"Reminder: {appointment.Name}",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    // Xóa reminder sau khi hiển thị thông báo
                    _reminderService.DeleteReminder(reminder.ReminderID);
                }
            }
            catch (Exception ex)
            {
                // Log error but don't show to user to avoid UI interruption
                Console.WriteLine($"Error checking reminders: {ex.Message}");
            }
        }

        private void LoadAppointments()
        {
            var user = _userSvc.CurrentUser;

            // Create a new scope to get a fresh IAppointmentService (with a new DbContext)
            using (var scope = _rootProvider.CreateScope())
            {
                var apptSvc = scope.ServiceProvider.GetRequiredService<IAppointmentService>();
                var appointments = apptSvc.GetAppointmentsByUserId(user.UserID);

                var displayList = appointments.Select(a => new
                {
                    ID = a.AppointmentID,
                    AppointmentName = a.Name,
                    Location = a.Location,
                    StartTime = a.StartTime.ToString("g"),
                    EndTime = a.EndTime.ToString("g"),
                    Type = a.IsGroup ? "Group" : "Personal"
                }).ToList();

                dGVListAppointment.Columns.Clear();
                dGVListAppointment.DataSource = null;
                dGVListAppointment.DataSource = displayList;
                dGVListAppointment.Columns["ID"].Visible = false;
                dGVListAppointment.Columns["AppointmentName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dGVListAppointment.Columns["Location"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dGVListAppointment.Columns["StartTime"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dGVListAppointment.Columns["EndTime"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dGVListAppointment.Columns["Type"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dGVListAppointment.Columns["AppointmentName"].HeaderText = "Appointment Name";
                dGVListAppointment.Columns["StartTime"].HeaderText = "Start Time";
                dGVListAppointment.Columns["EndTime"].HeaderText = "End Time";
                dGVListAppointment.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dGVListAppointment.MultiSelect = false;
                dGVListAppointment.ReadOnly = true;
                dGVListAppointment.ColumnHeadersVisible = true;
                dGVListAppointment.RowHeadersVisible = false;
            }
        }

        private void btAddAppointment_Click(object sender, EventArgs e)
        {
            DateTime selectedDate = monthCalendar.SelectionStart;
            DateTime Now = DateTime.Now;
            // Tạo DateTime với giây = 0 cho đơn giản
            DateTime selectedDateTime = new DateTime(selectedDate.Year, selectedDate.Month, selectedDate.Day, Now.Hour, Now.Minute, 0);
            var user = _userSvc.CurrentUser;
            try
            {
                Appointment_DTO appointment = new Appointment_DTO()
                {
                    Id = 0,
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

                    // Nếu user nhấn OK, cập nhật lại danh sách
                    if (apptForm.ShowDialog() == DialogResult.OK)
                    {
                        LoadAppointments();
                    }
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

                    // Kiểm tra nếu người dùng đã nhấn OK (nghĩa là đã lưu thay đổi)
                    if (detailForm.ShowDialog() == DialogResult.OK)
                    {
                        // Cập nhật lại danh sách appointment để hiển thị dữ liệu mới
                        LoadAppointments();
                    }
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

        protected override void OnHandleDestroyed(EventArgs e)
        {
            if (_reminderTimer != null)
            {
                _reminderTimer.Stop();
                _reminderTimer.Dispose();
            }

            base.OnHandleDestroyed(e);
        }

        private void btListReminders_Click(object sender, EventArgs e)
        {
            ShowAllReminders();
        }

        private void ShowAllReminders()
        {
            // Lấy danh sách tất cả các appointment của người dùng hiện tại
            var user = _userSvc.CurrentUser;
            var appointments = _appointmentService.GetAppointments()
                .Where(a => a.CreatedBy == user.UserID)
                .ToList();

            // Tạo form mới để hiển thị danh sách reminder
            var form = new Form();
            form.Text = "All Reminders";
            form.Size = new Size(800, 500);
            form.StartPosition = FormStartPosition.CenterParent;

            var dgv = new DataGridView();
            dgv.Dock = DockStyle.Fill;
            dgv.AutoGenerateColumns = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.ReadOnly = true;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.RowHeadersVisible = false;

            // Thêm các cột
            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "AppointmentName",
                HeaderText = "Appointment",
                Width = 200,
                DataPropertyName = "AppointmentName"
            });

            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Location",
                HeaderText = "Location",
                Width = 150,
                DataPropertyName = "Location"
            });

            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ReminderTime",
                HeaderText = "Reminder Time",
                Width = 150,
                DataPropertyName = "ReminderTime"
            });

            dgv.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Message",
                HeaderText = "Message",
                Width = 250,
                DataPropertyName = "Message"
            });

            // Lấy danh sách tất cả reminder
            var remindersList = GetAllRemindersList();

            // Hiển thị thông báo nếu không có reminder nào
            if (remindersList.Count == 0)
            {
                MessageBox.Show("You don't have any reminders scheduled.", "No Reminders", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Gán dữ liệu cho DataGridView
            dgv.DataSource = remindersList;

            // Tạo nút Refresh để tải lại dữ liệu
            var refreshButton = new Button
            {
                Text = "Refresh",
                Dock = DockStyle.Bottom,
                Height = 40
            };
            bool isRefreshing = false;

            refreshButton.Click += (s, args) =>
            {
                if (!isRefreshing)
                {
                    isRefreshing = true;
                    form.DialogResult = DialogResult.Retry;
                    form.Close();
                }

            };

            // Thêm controls vào form
            form.Controls.Add(dgv);
            form.Controls.Add(refreshButton);

            DialogResult result = form.ShowDialog();
            if (result == DialogResult.Retry)
            {
                Application.DoEvents(); //cho phép form cũ đóng hoàn toàn
                ShowAllReminders();
            }
        }
        private List<dynamic> GetAllRemindersList()
        {
            var user = _userSvc.CurrentUser;
            var appointments = _appointmentService.GetAppointmentsByUserId(user.UserID);

            var remindersList = new List<dynamic>();
            foreach (var appointment in appointments)
            {
                var reminders = _reminderService.GetRemindersForAppointment(appointment.AppointmentID);
                foreach (var reminder in reminders)
                {
                    remindersList.Add(new
                    {
                        AppointmentName = appointment.Name,
                        Location = appointment.Location,
                        ReminderTime = reminder.ReminderTime.ToString("g"),
                        Message = reminder.Message,
                        ReminderID = reminder.ReminderID,
                        AppointmentID = appointment.AppointmentID
                    });
                }
            }
            return remindersList;
        }

    }
}
