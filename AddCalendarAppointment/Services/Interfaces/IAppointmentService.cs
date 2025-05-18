using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using AddCalendarAppointment.DTO;

namespace AddCalendarAppointment.Services.Interfaces
{
    public interface IAppointmentService
    {
        List<Appointment> GetAppointments();
        Appointment GetAppointmentById(int id);
        int CreateAppointment(Appointment appointment);
        bool UpdateAppointment(Appointment appointment);
        bool DeleteAppointment(int id);

        Appointment ConvertFromDTO(Appointment_DTO dto);
        Appointment_DTO ConvertToDTO(Appointment appointment);

        // Trong IAppointmentService.cs
        List<Appointment> FindConflictingAppointments(DateTime startTime, DateTime endTime, int userId, int excludeAppointmentId = 0);
        List<Appointment> FindSimilarGroupMeetings(string name, DateTime startTime, DateTime endTime, int userId);
        bool AddUserToGroupMeeting(int appointmentId, int userId);
        List<User> GetParticipants(int appointmentId);
    }
}
