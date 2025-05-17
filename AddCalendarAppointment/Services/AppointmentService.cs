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
    public class AppointmentService: IAppointmentService, IDisposable
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
                isGroup = appointment.IsGroup ?? false,
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
                AppointmentID = dto.Id.HasValue ? dto.Id.Value : 0,
                Name = dto.Name,
                Location = dto.Location,
                StartTime = dto.startTime,
                EndTime = dto.endTime,
                IsGroup = dto.isGroup,
                CreatedBy = dto.createdBy.HasValue ? dto.createdBy.Value : 0
                // Map other properties as needed
            };

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
    }
}
