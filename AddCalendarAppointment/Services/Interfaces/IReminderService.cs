using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddCalendarAppointment.Services.Interfaces
{
    public interface IReminderService
    {
        Reminder GetReminderById(int reminderId);
        void AddReminder(Reminder reminder);
        void UpdateReminder(Reminder reminder);
        void DeleteReminder(int reminderId);

        void DeleteRemindersByAppointmentId(int appointmentId);
        List<Reminder> GetRemindersForAppointment(int appointmentId);
        List<Reminder> GetDueReminders(DateTime upToTime);
        List<Reminder> GetDueReminders(DateTime upToTime, int currentUserId);
    }
}
