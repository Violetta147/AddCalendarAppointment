using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AddCalendarAppointment.Services.Interfaces;

namespace AddCalendarAppointment.Services
{
    public class ReminderService : IReminderService, IDisposable
    {
        private readonly OOAD_AddCalendarAppointmentEntities _ctx;
        private bool _disposed = false;
        public ReminderService(OOAD_AddCalendarAppointmentEntities ctx)
        {
            _ctx = ctx;
        }

        public void AddReminder(Reminder r)
        {
            _ctx.Reminders.Add(r);
            _ctx.SaveChanges();
        }

        public void UpdateReminder(Reminder r)
        {
            var existing = _ctx.Reminders.Find(r.ReminderID);
            if (existing == null) throw new InvalidOperationException();
            _ctx.Entry(existing).CurrentValues.SetValues(r);
            _ctx.SaveChanges();
        }

        public void DeleteReminder(int reminderId)
        {
            var r = _ctx.Reminders.Find(reminderId);
            if (r != null)
            {
                _ctx.Reminders.Remove(r);
                _ctx.SaveChanges();
            }
        }

        public List<Reminder> GetRemindersForAppointment(int appointmentId)
            => _ctx.Reminders
                   .Where(r => r.AppointmentID == appointmentId)
                   .OrderBy(r => r.ReminderTime)
                   .ToList();

        public List<Reminder> GetDueReminders(DateTime upToTime)
            => _ctx.Reminders
                   .Where(r => r.ReminderTime <= upToTime)
                   .ToList();

        public void DeleteRemindersByAppointmentId(int appointmentId)
        {
            var reminders = _ctx.Reminders
                .Where(r => r.AppointmentID == appointmentId)
                .ToList();
            foreach (var reminder in reminders)
            {
                _ctx.Reminders.Remove(reminder);
            }
            _ctx.SaveChanges();
        }

        public void Dispose()
            => _ctx.Dispose();
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _ctx.Dispose();
                }
                _disposed = true;
            }
        }

    }
}
