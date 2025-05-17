using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using AddCalendarAppointment.DTO;

namespace AddCalendarAppointment.Services.Interfaces
{
    public interface IUserService
    {
        bool Register(string name, string username, string password);
        User Authenticate(string username, string password);
        void Logout();
        User GetById(int userId);
        User CurrentUser { get; }

    }
}
