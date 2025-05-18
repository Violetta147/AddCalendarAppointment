using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using AddCalendarAppointment.Services.Interfaces;
using AddCalendarAppointment.DTO;

namespace AddCalendarAppointment.Services
{
    public class AppointmentService : IAppointmentService, IDisposable
    {
        private readonly OOAD_AddCalendarAppointmentEntities _context;
        private bool _disposed = false;
        public AppointmentService(OOAD_AddCalendarAppointmentEntities context)
        {
            _context = context;
        }
        public List<Appointment> GetAppointments()
        {
            return _context.Appointments.ToList();
        }
        public Appointment GetAppointmentById(int id)
        {
            return _context.Appointments.Find(id);
        }
        public int CreateAppointment(Appointment appointment)
        {
            _context.Appointments.Add(appointment);
            _context.SaveChanges();
            return appointment.AppointmentID;
        }
        public bool UpdateAppointment(Appointment appointment)
        {
            var existingAppointment = _context.Appointments.Find(appointment.AppointmentID);
            if (existingAppointment == null)
                return false;
            _context.Entry(existingAppointment).CurrentValues.SetValues(appointment);
            int result = _context.SaveChanges();
            return result > 0;
        }
        public bool DeleteAppointment(int id)
        {
            var appointment = _context.Appointments.Find(id);
            if (appointment == null)
                return false;
            
            // First, remove all participants (users) associated with this appointment
            appointment.Users.Clear();
            
            // Then remove the appointment
            _context.Appointments.Remove(appointment);
            int result = _context.SaveChanges();
            return result > 0;
        }

        public Appointment_DTO ConvertToDTO(Appointment appointment)
        {
            if (appointment == null)
                return null;
            return new Appointment_DTO
            {
                Id = appointment.AppointmentID,
                Name = appointment.Name,
                Location = appointment.Location,
                startTime = appointment.StartTime,
                endTime = appointment.EndTime,
                isGroup = appointment.IsGroup,
                createdBy = appointment.CreatedBy,
                //other properties
            };
        }
        public Appointment ConvertFromDTO(Appointment_DTO dto)
        {
            if (dto == null)
                return null;

            Appointment appointment = new Appointment
            {
                Name = dto.Name,
                Location = dto.Location,
                StartTime = dto.startTime,
                EndTime = dto.endTime,
                IsGroup = dto.isGroup,
                CreatedBy = dto.createdBy
                // Map other properties as needed
            };

            if (dto.Id > 0)
                appointment.AppointmentID = dto.Id;

            return appointment;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                _disposed = true;
            }
        }
        public List<Appointment> FindConflictingAppointments(DateTime startTime, DateTime endTime, int userId, int excludeAppointmentId = 0)
        {
            // Tìm các lịch hẹn chồng chéo về thời gian
            var query = _context.Appointments
                .Where(a =>
                    // Người dùng tạo hoặc tham gia
                    (a.CreatedBy == userId || a.Users.Any(u => u.UserID == userId)) &&
                    // Thời gian chồng chéo (bắt đầu hoặc kết thúc trong khoảng thời gian)
                    ((a.StartTime <= endTime && a.EndTime >= startTime)));

            // Loại trừ appointment hiện tại (nếu đang sửa)
            if (excludeAppointmentId > 0)
            {
                query = query.Where(a => a.AppointmentID != excludeAppointmentId);
            }

            return query.ToList();
        }

        public List<Appointment> FindSimilarGroupMeetings(string name, DateTime startTime, DateTime endTime, int userId)
        {
            // Tìm các cuộc họp nhóm có tên tương tự và thời gian gần giống
            int bufferMinutes = 15; // Buffer of 15 minutes

            // First get all group meetings with similar names not created by or including this user
            var similarNameMeetings = _context.Appointments
                .Where(a =>
                    a.IsGroup == true &&
                    a.Name.ToLower() == name.ToLower() &&
                    a.CreatedBy != userId &&
                    !a.Users.Any(u => u.UserID == userId))
                .ToList();

            // Then filter by time in memory
            return similarNameMeetings
                .Where(a => 
                    Math.Abs((a.StartTime - startTime).TotalMinutes) <= bufferMinutes &&
                    Math.Abs((a.EndTime - endTime).TotalMinutes) <= bufferMinutes)
                .ToList();
        }

        public bool AddUserToGroupMeeting(int appointmentId, int userId)
        {
            try
            {
                var appointment = _context.Appointments.Find(appointmentId);
                if (appointment == null || appointment.IsGroup != true)
                    return false;

                var user = _context.Users.Find(userId);
                if (user == null)
                    return false;

                // Nếu người dùng chưa tham gia, thêm vào
                if (!appointment.Users.Any(u => u.UserID == userId))
                {
                    appointment.Users.Add(user);
                    _context.SaveChanges();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<User> GetParticipants(int appointmentId)
        {
            var appointment = _context.Appointments
                .Include(a => a.Users)
                .FirstOrDefault(a => a.AppointmentID == appointmentId);

            if (appointment == null)
                return new List<User>();

            // Thêm người tạo nếu chưa có trong danh sách
            var participants = appointment.Users.ToList();
            var creator = _context.Users.Find(appointment.CreatedBy);

            if (creator != null && !participants.Any(p => p.UserID == creator.UserID))
            {
                participants.Add(creator);
            }

            return participants;
        }
    }
}
