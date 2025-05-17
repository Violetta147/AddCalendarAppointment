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

        //bool hasScheduleConflict(Appointment appointment);
    }
}
