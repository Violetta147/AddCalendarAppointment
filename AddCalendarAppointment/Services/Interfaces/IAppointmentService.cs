using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace AddCalendarAppointment.Services.Interfaces
{
    public interface IAppointmentService
    {
        List<Appointment> GetAppointments();
        Appointment GetAppointmentById(int id);
        int CreateAppointment(Appointment appointment);
        bool UpdateAppointment(Appointment appointment);
        bool DeleteAppointment(int id);

        //bool hasScheduleConflict(Appointment appointment);
    }
}
