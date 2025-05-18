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
    public partial class AppointmentForm : Form
    {
        private readonly Appointment_DTO _appointment;
        private readonly IAppointmentService _appointmentService;
        private readonly IServiceProvider _rootProvider;
        private readonly IReminderService _remSvc;
        private bool _savedToDb;
        private bool _shouldCleanup = false;
        private bool _savedToDbInitially;

        public AppointmentForm(IServiceProvider rootProvider, IAppointmentService appointmentService, IReminderService reminderService, Appointment_DTO appointment)
        {
            InitializeComponent();
            _rootProvider = rootProvider;
            _appointmentService = appointmentService;
            _remSvc = reminderService;
            _appointment = appointment;
            _savedToDb = appointment.Id > 0;
            _savedToDbInitially = _savedToDb;

            // Lưu giá trị ban đầu để so sánh khi cần
            LoadUI();

            // Thiết lập sự kiện khi đóng form
            this.FormClosing += AppointmentForm_FormClosing;
            this.FormClosed += AppointmentForm_FormClosed;
            
            // Thêm event handler cho RadioButtons để cập nhật giao diện
            singlerb.CheckedChanged += RadioButton_CheckedChanged;
            grouprb.CheckedChanged += RadioButton_CheckedChanged;
            
            // Cập nhật giao diện ban đầu
            UpdateParticipantsPanelVisibility();
            
            // Nếu là appointment đã tồn tại và là group meeting, hiển thị danh sách người tham gia
            if (_savedToDb && _appointment.isGroup && _appointment.Id > 0)
            {
                LoadParticipants(_appointment.Id);
            }
        }

        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            UpdateParticipantsPanelVisibility();
        }

        private void UpdateParticipantsPanelVisibility()
        {
            // Chỉ hiện panel nếu đây là group meeting
            pnParticipants.Visible = grouprb.Checked;
            btnAddParticipant.Visible = false; // Không cần nút thêm participant, sẽ tự động thêm
            
            // Điều chỉnh kích thước form nếu cần
            if (grouprb.Checked)
            {
                // Đảm bảo panel luôn ở dưới các control khác
                int newHeight = Math.Max(this.Height, pnParticipants.Bottom + 100);
                this.Height = newHeight;
            }
        }

        private void LoadParticipants(int appointmentId)
        {
            try
            {
                // Lấy danh sách người tham gia
                var participants = _appointmentService.GetParticipants(appointmentId);
                
                // Xóa danh sách cũ
                lvParticipants.Items.Clear();
                
                // Thêm vào ListView
                foreach (var participant in participants)
                {
                    var item = new ListViewItem(participant.Username);
                    item.SubItems.Add(participant.Name ?? "");
                    item.Tag = participant.UserID; // Lưu ID để dễ tham chiếu sau này
                    lvParticipants.Items.Add(item);
                }
                
                // Cập nhật số lượng người tham gia vào label
                lblParticipants.Text = $"Participants ({participants.Count})";
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                MessageBox.Show($"Could not load participants: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            
            // Kiểm tra xung đột lịch hẹn
            if (_appointment.createdBy > 0)
            {
                List<Appointment> conflicts = _appointmentService.FindConflictingAppointments(
                    _appointment.startTime, 
                    _appointment.endTime, 
                    _appointment.createdBy,
                    _appointment.Id);
                    
                if (conflicts.Any())
                {
                    string conflictList = string.Join("\n", conflicts.Select(a => $"- {a.Name} ({a.StartTime:g} - {a.EndTime:g})"));
                    DialogResult result = MessageBox.Show(
                        "You already have an appointment at this time:\n" + conflictList +
                        "\n\nDo you want to replace the previous appointment?",
                        "Scheduling Conflict",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);
                        
                    if (result == DialogResult.No)
                    {
                        // Người dùng chọn không thay thế, có thể chọn thời gian khác
                        return;
                    }
                    
                    // Xóa các cuộc hẹn xung đột
                    foreach (var conflict in conflicts)
                    {
                        // First delete all reminders for this appointment
                        _remSvc.DeleteRemindersByAppointmentId(conflict.AppointmentID);
                        
                        // Then delete the appointment
                        _appointmentService.DeleteAppointment(conflict.AppointmentID);
                    }
                }
            }
            
            // Kiểm tra cuộc họp nhóm tương tự
            if (!_appointment.isGroup && _appointment.createdBy > 0)
            {
                List<Appointment> similarMeetings = _appointmentService.FindSimilarGroupMeetings(
                    _appointment.Name,
                    _appointment.startTime,
                    _appointment.endTime,
                    _appointment.createdBy);
                    
                if (similarMeetings.Any())
                {
                    var meeting = similarMeetings.First();
                    DialogResult result = MessageBox.Show(
                        $"There is a similar group meeting named '{meeting.Name}' at {meeting.StartTime:g}.\n\n" +
                        "Do you want to join this group meeting instead of creating your own?",
                        "Similar Group Meeting Found",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);
                        
                    if (result == DialogResult.Yes)
                    {
                        // Thêm người dùng vào cuộc họp nhóm
                        _appointmentService.AddUserToGroupMeeting(meeting.AppointmentID, _appointment.createdBy);
                        MessageBox.Show("You have joined the group meeting.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                        return;
                    }
                }
            }
            
            Appointment appointmentEntity = _appointmentService.ConvertFromDTO(_appointment);
            
            if (_savedToDb)
            {
                // We either drafted it above, or it was an existing record:
                bool success = _appointmentService.UpdateAppointment(appointmentEntity);
                if (!success)
                {
                    MessageBox.Show("Failed to update appointment. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Không đặt DialogResult.OK nếu cập nhật thất bại
                }
            }
            else
            {
                // A truly new (never-drafted/created) appointment
                int newId = _appointmentService.CreateAppointment(appointmentEntity);
                if (newId <= 0)
                {
                    MessageBox.Show("Failed to create appointment. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Không đặt DialogResult.OK nếu tạo thất bại
                }
                
                _appointment.Id = newId;
                _savedToDb = true;
            }
            
            // Nếu là cuộc họp nhóm, cập nhật danh sách người tham gia
            if (_appointment.isGroup && _appointment.Id > 0)
            {
                // Cập nhật trạng thái hiển thị panel participant
                UpdateParticipantsPanelVisibility();
                
                // Đảm bảo người tạo được thêm vào danh sách người tham gia (nếu cần)
                if (_appointment.createdBy > 0)
                {
                    _appointmentService.AddUserToGroupMeeting(_appointment.Id, _appointment.createdBy);
                }
                
                // Tải lại danh sách người tham gia
                LoadParticipants(_appointment.Id);
            }
            
            string action = _savedToDbInitially ? "updated" : "created";
            MessageBox.Show($"Appointment {action} successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Quan trọng: Đảm bảo đặt DialogResult.OK trước khi đóng form
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btReminder_Click(object sender, EventArgs e)
        {
            // If we haven't saved anything yet, create the appointment now
            if (!_savedToDb)
            {
                try
                {
                    _appointment.Name = txtAppointmentName.Text;
                    _appointment.Location = txtLocation.Text;
                    _appointment.startTime = dTPStartTime.Value;
                    _appointment.endTime = dTPEndTime.Value;
                    _appointment.isGroup = grouprb.Checked;
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
                    _appointment.Id,
                    _appointment.Name,
                    _appointmentService
                );

                reminderForm.ShowDialog();
            }
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            if (_appointment.Id > 0)
            {
                try
                {
                    // 1) Remove reminders explicitly (if needed)
                    _remSvc.DeleteRemindersByAppointmentId(_appointment.Id);

                    // 2) Remove the appointment
                    _appointmentService.DeleteAppointment(_appointment.Id);

                    MessageBox.Show("Appointment deleted successfully");

                    // 3) Prevent the "draft cleanup" from running:
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
                    _remSvc.DeleteRemindersByAppointmentId(_appointment.Id);
                }
                catch { /* swallow or log */ }

                try
                {
                    //then delete the appointment
                    _appointmentService.DeleteAppointment(_appointment.Id);
                }
                catch { /* swallow or log */ }
            }
        }

        private void AppointmentForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Nếu đã bấm OK hoặc Delete, không cần làm gì
            if (this.DialogResult == DialogResult.OK)
            {
                _shouldCleanup = false; // Đảm bảo không xóa
                return;
            }

            // Xử lý khi đóng form mà không bấm OK

            // Trường hợp 1: Đây là appointment mới - xóa bản draft
            if (_appointment.Id <= 0)
            {
                _shouldCleanup = true;
                return;
            }

            // Trường hợp 2: Đây là appointment đã tồn tại từ trước khi mở form
            // Kiểm tra nếu _savedToDb = true ngay từ constructor
            // Đóng form mà không bấm OK - giữ nguyên thông tin
            if (_savedToDb && _appointment.Id <= 0)
            {
                _shouldCleanup = false;
                return;
            }

            // Trường hợp 3: Đây là draft appointment được tạo khi bấm Reminder
            // Xóa nếu bấm X mà không bấm OK
            if (_savedToDb && this.DialogResult != DialogResult.OK && _appointment.Id > 0)
            {
                // Check if the appointment was initially empty (drafted via Reminder button)
                bool wasInitiallyDraft = !_savedToDbInitially;
                _shouldCleanup = wasInitiallyDraft;
            }
        }
        private bool IsEmptyAppointment()
        {
            // Lấy giá trị hiện tại từ form
            string name = txtAppointmentName.Text;
            string location = txtLocation.Text;

            // Kiểm tra xem người dùng đã nhập dữ liệu có ý nghĩa chưa
            // Chỉ cần có một trường có dữ liệu có ý nghĩa là appointment không trống
            bool hasValidName = !string.IsNullOrWhiteSpace(name);
            bool hasValidLocation = !string.IsNullOrWhiteSpace(location);

            // Appointment được coi là không trống nếu có ít nhất một trường có giá trị
            return !hasValidName && !hasValidLocation;
        }

        private void btnAddParticipant_Click(object sender, EventArgs e)
        {
            // Nút này hiện đã bị vô hiệu hóa và ẩn đi vì người dùng sẽ tự động được thêm vào group meeting
            // Code này chỉ để xử lý trong trường hợp cần thiết nếu sau này muốn mở lại chức năng
            MessageBox.Show("This functionality is disabled. Users are now automatically added to group meetings.", 
                "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnViewParticipants_Click(object sender, EventArgs e)
        {
            if (_appointment.Id <= 0 || !_appointment.isGroup)
            {
                MessageBox.Show("This is not a group meeting.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                // Display participants in the panel
                pnParticipants.Visible = true;
                
                // Load participants list
                LoadParticipants(_appointment.Id);
                
                // Adjust form height if needed
                int newHeight = Math.Max(this.Height, pnParticipants.Bottom + 100);
                this.Height = newHeight;
                
                // Display a message with the number of participants
                var participants = _appointmentService.GetParticipants(_appointment.Id);
                if (participants.Count > 0)
                {
                    string participantsList = string.Join("\n", participants.Select(p => $"- {p.Username} ({p.Name})"));
                    MessageBox.Show(
                        $"This group meeting has {participants.Count} participant(s):\n\n{participantsList}",
                        "Group Meeting Participants",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No participants found for this meeting.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading participants: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

