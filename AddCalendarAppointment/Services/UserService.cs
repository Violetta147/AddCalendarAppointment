using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using AddCalendarAppointment.Services.Interfaces;
using AddCalendarAppointment.DTO;
using System.Runtime.Remoting.Contexts;


namespace AddCalendarAppointment.Services
{   

    public class UserService : IUserService, IDisposable
    {
        private readonly OOAD_AddCalendarAppointmentEntities _ctx;
        private User _current;
        private bool _disposed = false;

        public UserService(OOAD_AddCalendarAppointmentEntities ctx)
        {
            _ctx = ctx;
            _current = GetById(1); //default user
        }

        public bool Register(string name, string username, string password)
        {
            if (_ctx.Users.Any(u => u.Username == username))
                return false;

            _ctx.Users.Add(new User
            {
                Name = name,
                Username = username,
                Password = password
            });
            _ctx.SaveChanges();
            return true;
        }
        public User Authenticate(string username, string password)
        {
            var user = _ctx.Users
                .FirstOrDefault(u => u.Username == username && u.Password == password);

            if (user != null)
                _current = user;

            return user;
        }
        public void Logout() => _current = GetById(1);
        public User GetById(int userId)
            => _ctx.Users.Find(userId)
                ?? throw new InvalidOperationException($"User {userId} not found");
        public User CurrentUser => _current;
        public void Dispose()
        {
            _ctx?.Dispose();
        }
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
